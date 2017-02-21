using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using DataProcessingLibrary.SerialPort;

namespace UserWinFroms
{
    public partial class frmMian : Form
    {
        /// <summary>
        /// 系统组件定义
        /// </summary>
        private Action callback;
        private OpenFileDialog mOpenFileDialog;
        private SaveFileDialog mSaveFileDialog;
        private SerialPort mSerialPort;
        private Timer autoSendTimer;

        /// <summary>
        /// 用户自定义类定义 
        /// </summary>
        frmSetting mFrmSetting;
        
        IList<SerialPortInfo> serialInfoList = new List<SerialPortInfo>();// 可用串口集合
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。 
        private bool isHex = false;
        private bool isComPortOpen = false;
        private bool isListening = false;//用于检测是否没有执行完invoke相关操作，仅在单线程收发使用
        private bool isWaitSerialClose = false;// 等待关闭串口状态
        private long received_count = 0;//接收计数 

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="callback"></param>
        public frmMian(Action callback)
        {
            InitializeComponent();
            this.callback = callback;//实例化回调关闭起始界面
        }

        #region "Window"
        /// <summary>
        /// 主窗体载入方法 默认调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMian_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //webKitBrowser.Navigate("http://ie.icoa.cn/");

            AutoGetPorts();// 自动获取可用串口

            #region "User Controls Initial"
            mOpenFileDialog = new OpenFileDialog();
            mSaveFileDialog = new SaveFileDialog();
            mSerialPort = new SerialPort();
            autoSendTimer = new Timer();

            mFrmSetting = new frmSetting();// 属性配置窗口

            autoSendTimer.Tick += AutoSendTimer_Tick;
            #endregion
        }
        
        /// <summary>
        /// 关闭此窗体后回调主线程窗体，并关闭它
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMian_FormClosed(object sender, FormClosedEventArgs e)
        {
            callback();
        }

        /// <summary>
        /// 快捷键组合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.S )
            {
                userSettingToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }
        #endregion

        #region "ToolStripMenu-Setting"
        /// <summary>
        /// 用户配置属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mFrmSetting.Owner = this;
            mFrmSetting.Show();
        }
        #endregion

        #region "ToolStripMenu-help"
        /// <summary>
        /// 关于本软件的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" This software produced by Linzh (Gdin). The software you are using is second version. Thank you for Using this tool. If you have any quetions, you can contact me by email 547590520@qq.com or QQ 547590520.",
                "Something about this Software"   
            );
        }

        /// <summary>
        /// 用户反馈信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region "Serial Ctrl"
        /// <summary>
        /// 自动获取可用串口
        /// </summary>
        private void AutoGetPorts()
        {
            cmbCOMPort.Items.Clear();
            serialInfoList.Clear();
            foreach (var port in SerialPort.GetPortNames())
            {
                cmbCOMPort.Text = port;
                cmbCOMPort.Items.Add(port);
                serialInfoList.Add(new SerialPortInfo() { PortName = port });// 记录可用串口名
            }

            if (cmbCOMPort.Items != null)
                cmbCOMPort.SelectedIndex = 0;// 默认显示第一个可用串口
        }

        /// <summary>
        /// 成功打开串口后的设置
        /// </summary>
        private void SerialOpenedSetting()
        {
            btnSerialportCtrl.Text = "Close";
            tlblSerialStatus.Text = "Fighting";
            isComPortOpen = true;
            isWaitSerialClose = false;
            btnSerialSend.Enabled = true;
            btnSerialportSearch.Enabled = false;
            cmbCOMPort.Enabled = false;
            rbtnSerialChar.Enabled = true;
            rbtnSerialHex.Enabled = true;
            usrSettingToolStripMenuItem.Enabled = false;
            toolStripProgressBar.Value = 0;//状态栏进度条
            lblCOMStatus.Text = "COM port is open.";
        }

        /// <summary>
        /// 成功关闭串口或丢失串口后的设置
        /// </summary>
        private void SerialClosedSetting()
        {
            btnSerialportCtrl.Text = "Open";
            tlblSerialStatus.Text = "Ready";
            isComPortOpen = false;
            btnSerialSend.Enabled = true;
            usrSettingToolStripMenuItem.Enabled = true;
            rbtnSerialChar.Enabled = true;
            rbtnSerialHex.Enabled = true;
            toolStripProgressBar.Value = 0;//状态栏进度条
            lblCOMStatus.Text = "COM port is close.";
        }

        /// <summary>
        /// 串口丢失后的操作
        /// </summary>
        private void SerialLosedSetting()
        {
            autoSendTimer.Stop();
            checkBoxSerialAutoSend.Checked = false;
            isWaitSerialClose = true;
            while (isListening)
                Application.DoEvents();
            MessageBox.Show("Serial port is losed!");
            isWaitSerialClose = false;
            AutoGetPorts();//刷新串口
            SerialClosedSetting();
        }

        /// <summary>
        /// 将串口要发送的数据转换为十六进制的形式
        /// </summary>
        /// <returns></returns>
        private byte[] SerialHexModeSend()
        {
            byte[] buf = null;//发送数据缓冲区
            string sendData = txbSerialSendData.Text;//复制发送数据，以免发送过程中数据被手动改变

            try
            {
                sendData = sendData.Replace(" ", "");//去除16进制数据中的所有空格
                sendData = sendData.Replace("\r", "");//去除16进制数据中的所有换行
                sendData = sendData.Replace("\n", "");//去除16进制数据中的所有回车
                if (sendData.Length == 1)//待发送的数据长度为1时，在数据前补0
                    sendData = "0" + sendData;
                else if (sendData.Length % 2 != 0)//数据长度为奇数位时，去除最后一位数据
                    sendData = sendData.Remove(sendData.Length - 1, 1);

                List<string> hexData = new List<string>();//将发送的数据，2个合为1个，然后放在该缓存里 如：123456→12,34,56
                for (int i = 0; i < sendData.Length; i+=2)
                {
                    hexData.Add(sendData.Substring(i, 2));
                }
                buf = new byte[hexData.Count]; //长度设置为发送的数据2合1后的字节数
                for (int i = 0; i < hexData.Count; i++)
                {
                    buf[i] = (byte)(Convert.ToInt32(hexData[i], 16));//发送数据改为16进制
                }
            }
            catch //原字符串数据转换为十六进制失败
            {
                checkBoxSerialAutoSend.Checked = false;
                autoSendTimer.Stop();
                MessageBox.Show("Please input data which is valid.");
                return null;
            }

            return buf;
        }

        /// <summary>
        /// 将串口要发送的数据转码
        /// </summary>
        /// <returns></returns>
        private byte[] SerialCharModeSend()
        {
            string data = txbSerialSendData.Text;
            return Encoding.Default.GetBytes(data);
        }

        /// <summary>
        /// 串口发送数据
        /// </summary>
        private void SerialSendData()
        {
            byte[] buf;
            if (isHex == true)
                buf = SerialHexModeSend();
            else
                buf = SerialCharModeSend();

            //尝试发送数据
            try
            {
                //每1000byte发送一次
                int times = (buf.Length / 1000);
                for (int i = 0; i < times; i++)
                {
                    mSerialPort.Write(buf, i * 1000, 1000);
                    var tmp = tlblSerialTxCnt.Text;
                    tlblSerialTxCnt.Text = (Convert.ToInt32(tmp) + 1000).ToString();//刷新发送字节数
                }

                //发送字节小于1000Bytes或上面发送剩余的数据
                if (buf.Length % 1000 != 0)
                {
                    mSerialPort.Write(buf, times * 1000, buf.Length % 1000);
                    var tmp = tlblSerialTxCnt.Text;
                    tlblSerialTxCntNymber.Text = (Convert.ToInt32(tmp) + buf.Length % 1000).ToString();//刷新发送字节数
                }

                toolStripProgressBar.Value = 100;//状态栏进度条
            }
            catch //发送数据异常
            {
                if (mSerialPort.IsOpen == false)
                {
                    SerialLosedSetting();
                }
                else
                {
                    MessageBox.Show("Unable to close the serial port for an unknown reason!");
                }
            }
        }

        /// <summary>
        /// 自动发送触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoSendTimer_Tick(object sender, EventArgs e)
        {
            SerialSendData();
        }

        /// <summary>
        /// 串口接收数据触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isWaitSerialClose == true) return;//如果正在关闭串口，忽略操作，直接返回，尽快的完成串口监听线程的一次循环

            try
            {
                isListening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。

                int n = mSerialPort.BytesToRead;
                byte[] buf = new byte[n];
                received_count += n;
                mSerialPort.Read(buf, 0, n);//读取串口缓冲区中的数据

                builder.Clear();//清楚字符串构造器的内容
                this.Invoke((EventHandler)(delegate
                {
                    if (isHex == true)
                    {
                        foreach (var b in buf)
                        {
                            builder.Append(b.ToString("X2") + " ");
                        }
                    }
                    else
                    {
                        var data = Encoding.Default.GetString(buf);//转码
                        builder.Append(data);
                    }

                    //追加的形式添加到文本框末端，并滚动到最后。
                    txbSerialReceiveData.AppendText(builder.ToString());
                    tlblSerialRxCntNumber.Text = received_count.ToString();
                    toolStripProgressBar.Value = 0;//状态栏进度条
                }));
            }
            finally
            {
                isListening = false;
                rbtnSerialChar.Enabled = true;
                rbtnSerialHex.Enabled = true;
            }
        }

        /// <summary>
        /// 串口打开/关闭控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialportCtrl_Click(object sender, EventArgs e)
        {   
            // 检测当前是否有选择的串口可用
            if (cmbCOMPort.SelectedValue == null) 
            {
                MessageBox.Show("COM is invalid.");
                return;// 无串口可用，直接退出
            }

            #region "Open Serial Port"
            if (isComPortOpen == false)
            {
                try
                {
                    // 设置串口属性
                    mSerialPort.PortName = cmbCOMPort.SelectedValue.ToString();
                    mSerialPort.BaudRate = Convert.ToInt32(mFrmSetting.setting.BaudRate);
                    mSerialPort.Parity = (Parity)Convert.ToInt32(mFrmSetting.setting.Parity);
                    mSerialPort.DataBits = Convert.ToInt32(mFrmSetting.setting.DataBit);
                    mSerialPort.StopBits = (StopBits)Convert.ToInt32(mFrmSetting.setting.StopBit);
                    // 打开串口
                    mSerialPort.Open();
                }
                catch //打开失败
                {
                    MessageBox.Show("Can't open serial port, check that the serial port is valid or in use by other.");
                    AutoGetPorts();//刷新当前可用串口
                    return;
                }

                //成功打开串口后 调整控件属性
                SerialOpenedSetting();
                
                if (checkBoxSerialAutoSend.Checked == true)// 开启自动发送功能
                {
                    autoSendTimer.Interval = Convert.ToInt32(txbSerilaSendPeriodTime.Text);
                    autoSendTimer.Start();
                }
            }
            #endregion
            #region "Close Serial Port"
            else //isComPortOpen == true
            {
                try
                {
                    autoSendTimer.Stop();//停止自动发送
                    checkBoxSerialAutoSend.Checked = false;
                    mSerialPort.DiscardInBuffer();//清缓存
                    mSerialPort.DiscardOutBuffer();
                    isWaitSerialClose = true;//激活正在关闭状态字，用于在串口接收方法的invoke里判断是否正在关闭串口

                    //监听invoke是否结束
                    while (isListening == true)
                    {
                        // 循环时，仍进行等待事件中的进程
                        Application.DoEvents();
                    }
                    mSerialPort.Close();//关闭串口
                    isWaitSerialClose = false;//关闭正在关闭状态字，用于在串口接收方法的invoke里判断是否正在关闭串口
                    SerialClosedSetting();//成功关闭串口后的设置
                }
                catch //关闭串口异常
                {
                    if (mSerialPort.IsOpen == false)
                    {
                        SerialLosedSetting();
                    }
                    else//原因未知，无法关闭串口
                    {
                        MessageBox.Show("Unable to close the serial port for an unknown reason!");
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 扫描可用串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialportSearch_Click(object sender, EventArgs e)
        {
            AutoGetPorts();
        }

        /// <summary>
        /// 串口发送模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialSend_Click(object sender, EventArgs e)
        {
            if (isComPortOpen == true)
            {
                toolStripProgressBar.Value = 0;//状态栏进度条
                SerialSendData();
            }
        }

        /// <summary>
        /// 串口接收模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnSerialReceive_Click(object sender, EventArgs e)
        {
            if (isComPortOpen == true)//确保串口是开启状态
            {
                btnSerialSend.Enabled = false;
                rbtnSerialChar.Enabled = false;
                rbtnSerialHex.Enabled = false;
                toolStripProgressBar.Value = 100;//状态栏进度条

                mSerialPort.DataReceived += MSerialPort_DataReceived;
            }
            else
            {
                MessageBox.Show("Serial port is invalid.");
            }
        }

        /// <summary>
        /// 暂停串口操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialPause_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Hex改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSerialHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSerialHex.Checked == true)
                isHex = true;
            else
                isHex = false;
        }

        /// <summary>
        /// 重置串口接收发送计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSerialClearCnt_Click(object sender, EventArgs e)
        {
            tlblSerialRxCntNumber.Text = "0";
            tlblSerialTxCntNymber.Text = "0";
        }

        /// <summary>
        /// 清空接收区数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialClearRx_Click(object sender, EventArgs e)
        {
            txbSerialReceiveData.Text = string.Empty;
        }

        /// <summary>
        /// 清空发送区数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialClearTx_Click(object sender, EventArgs e)
        {
            txbSerialSendData.Text = string.Empty;
        }
        #endregion

        #region "File Ctrl"
        /// <summary>
        /// 读取并显示txt文件
        /// </summary>
        /// <param name="filename">待读取显示的文件</param>
        private void ShowTxtFile(string filename)
        {
            //清空串口数据接收区
            txbSerialReceiveData.Text = string.Empty;
            //读取并显示文件
            if (System.IO.File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.GetEncoding("gb2312")))//支持中文编码
                {
                    var str = sr.ReadToEnd();
                    txbSerialReceiveData.AppendText(str);//把txt文件内容显示到串口数据接收区中
                }
            }
            else
            {
                MessageBox.Show("Filen open failed, please check the file.", "Warning");
            }
        }

        /// <summary>
        /// 读取并显示图像文件
        /// </summary>
        /// <param name="filename"></param>
        private void ShowImageFile(string filename)
        {

        }

        /// <summary>
        /// 打开文件操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            //过滤文件格式
            mOpenFileDialog.Filter = "text file (*.txt)|*.txt|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            mOpenFileDialog.FilterIndex = 4;

            if (mOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string fName in mOpenFileDialog.FileNames)
                    {
                        listBoxFiles.Items.Add(Path.GetFileName(fName));
                    }

                    listBoxFiles.SelectedIndex = 0;
                    // Set the PictureBox to display the image. 
                    //pictureBox1.Image = BitmapConverter.ToBitmap(imgCollection[0].Img);

                    //文件格式识别
                    string filename = mOpenFileDialog.FileName;
                    string fileFormat = Path.GetExtension(filename).ToLower();
                    if (fileFormat == ".txt")
                    {
                        ShowTxtFile(filename);//显示Txt文件
                    }
                    else if (fileFormat == ".jpg" || fileFormat == ".bmp" || fileFormat == ".png")
                    {
                        ShowImageFile(filename);//显示图像文件
                    }
                }
                catch
                {
                    MessageBox.Show("There was an error." + "Check the path to correct file.");
                }
            }
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {

        }

        private void btnFileDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnFileNext_Click(object sender, EventArgs e)
        {

        }

        private void btnFileEmpty_Click(object sender, EventArgs e)
        {

        }

        private void btnFilePreviousClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region "Image Ctrl"
        private void btnImageBegin_Click(object sender, EventArgs e)
        {

        }

        private void btnImageAlgorithm_Click(object sender, EventArgs e)
        {

        }

        private void btnImageGray_Click(object sender, EventArgs e)
        {

        }

        private void btnFilp_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownImageThreshold_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
