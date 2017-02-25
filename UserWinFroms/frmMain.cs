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
using DataProcessingLibrary.Image;
using System.Threading;

namespace UserWinFroms
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 系统组件定义
        /// </summary>
        private Action callback;
        private OpenFileDialog mOpenFileDialog;
        private SaveFileDialog mSaveFileDialog;
        private SerialPort mSerialPort;
        private ToolTip mToolTip;
        private System.Windows.Forms.Timer autoSendTimer;

        /// <summary>
        /// 用户自定义类定义 
        /// </summary>
        frmImageAlgorithm imageAlgorithm;
        frmSetting mFrmSetting;
        ImageInfo imageInfo;

        #region "串口全局变量"
        IList<SerialPortInfo> serialInfoList = new List<SerialPortInfo>();// 可用串口集合
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。 
        private bool isHex = false;
        private bool isComPortOpen = false;
        private bool isListening = false;//用于检测是否没有执行完invoke相关操作，仅在单线程收发使用
        private bool isWaitSerialClose = false;// 等待关闭串口状态
        private long received_count = 0;//接收计数 
        #endregion

        #region "文件操作全局变量"
        List<string> openFileList = new List<string>();
        #endregion

        #region "图像处理全局变量"
        private int imageThreshold;
        private bool isImageFilp = false;//图像是否翻转
        private bool isBinaryGet = false;//是否以二值化图像的形式接收的
        private int isImageSelectDoubleBuf = 1;
        private bool isImageGetSuccess = false;
        private byte[] imageDoubleBuf1;
        private byte[] imageDoubleBuf2;
        private byte[,] Image;
        private byte[,] afterImage;//算法处理后的二维图像
        //接收图像和显示图像的线程
        private Thread getImageThread;
        private Thread showImageThread;
        //显示的原始和处理后的bitmap
        private Bitmap originalBitmap;
        private Bitmap binaryBitmap;
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="callback"></param>
        public frmMain(Action callback)
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
            mToolTip = new ToolTip();
            autoSendTimer = new System.Windows.Forms.Timer();

            mFrmSetting = new frmSetting();// 属性配置窗口
            imageAlgorithm = new frmImageAlgorithm();
            imageInfo = new ImageInfo();

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
            btnSerialportSearch.Enabled = true;
            usrSettingToolStripMenuItem.Enabled = true;
            rbtnSerialChar.Enabled = true;
            rbtnSerialHex.Enabled = true;
            cmbCOMPort.Enabled = true;
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
                    var tmp = tlblSerialTxCntNymber.Text;
                    tlblSerialTxCnt.Text = (Convert.ToInt32(tmp) + 1000).ToString();//刷新发送字节数
                }

                //发送字节小于1000Bytes或上面发送剩余的数据
                if (buf.Length % 1000 != 0)
                {
                    mSerialPort.Write(buf, times * 1000, buf.Length % 1000);
                    var tmp = tlblSerialTxCntNymber.Text;
                    tlblSerialTxCntNymber.Text = (Convert.ToInt32(tmp) + buf.Length % 1000).ToString();//刷新发送字节数
                }

                toolStripProgressBar.Value = 100;//状态栏进度条
            }
            catch (Exception ex)//发送数据异常
            {
                if (mSerialPort.IsOpen == false)
                {
                    SerialLosedSetting();
                }
                else
                {
                    MessageBox.Show(ex.Message + "\nUnable to close the serial port for an unknown reason!");
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
            if (cmbCOMPort.SelectedItem == null) 
            {
                MessageBox.Show("Serial port is invalid.");
                return;// 无串口可用，直接退出
            }

            #region "Open Serial Port"
            if (isComPortOpen == false)
            {
                try
                {
                    // 设置串口属性
                    mSerialPort.ReadTimeout = 8000;//串口读超时8秒
                    mSerialPort.WriteTimeout = 8000;//串口写超时8秒，在1ms自动发送数据时拔掉串口，写超时5秒后，会自动停止发送，如果无超时设定，这时程序假死
                    mSerialPort.ReadBufferSize = 1024;//数据读缓存
                    mSerialPort.WriteBufferSize = 1024;//数据写缓存
                    mSerialPort.PortName = cmbCOMPort.SelectedItem.ToString();
                    mSerialPort.BaudRate = Convert.ToInt32(mFrmSetting.setting.BaudRate);
                    mSerialPort.Parity = (Parity)mFrmSetting.ParityConvert(mFrmSetting.setting.Parity);
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
                    autoSendTimer.Enabled = true;
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
                //btnSerialSend.Enabled = false;
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

        /// <summary>
        /// 激活或关闭自动发送功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSerialAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSerialAutoSend.Checked == true)// 开启自动发送功能
            {
                autoSendTimer.Interval = Convert.ToInt32(txbSerilaSendPeriodTime.Text);
                autoSendTimer.Enabled = true;
                autoSendTimer.Start();
            }
            else
            {
                autoSendTimer.Enabled = false;
            }
        }
        #endregion

        #region "File Ctrl"
        /// <summary>
        /// 根据索引打开文件
        /// </summary>
        /// <param name="index"></param>
        private void OpenFile(int index)
        {
            //文件格式识别
            //string filename = mOpenFileDialog.FileName;
            string filename = openFileList[index];
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
                    txbSerialReceiveData.AppendText("Filename:" + filename + "\r\n\n\n");
                    txbSerialReceiveData.AppendText(str);//把txt文件内容显示到串口数据接收区中
                    tabControl.SelectedIndex = 0;//将tabcontrol切换到serial模块
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
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(filename);//将打开的图像文件转为bitmap

                if ((bitmap.Size.Height != imageInfo.Row) || (bitmap.Size.Width != imageInfo.Col))
                {
                    lblImageRowNumber.Text = bitmap.Size.Height.ToString();
                    lblImageColNumber.Text = bitmap.Size.Width.ToString();
                    imageInfo.Col = bitmap.Size.Width;
                    imageInfo.Row = bitmap.Size.Height;
                    originalBitmap = new Bitmap(imageInfo.Col, imageInfo.Row, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    binaryBitmap = new Bitmap(imageInfo.Col, imageInfo.Row, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Image = new byte[imageInfo.Row, imageInfo.Col];//初始数组大小
                    imageDoubleBuf1 = new byte[imageInfo.Col * imageInfo.Row];
                    imageDoubleBuf2 = new byte[imageInfo.Col * imageInfo.Row];
                    tabControl.SelectedIndex = 1;
                }
                for (int i = 0; i < bitmap.Height; i++)//将彩图转换为灰度图
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        Image[i, j] = bitmap.GetPixel(j, i).R;
                    }
                }

                Buf2OriginalBitmap();
                Original2BinaryBitmap();
                //显示
                DrawPicture(originalImagePictureBox, (Bitmap)originalBitmap.Clone());
                DrawPicture(binaryImagePictureBox, (Bitmap)binaryBitmap.Clone());
            }
        }

        /// <summary>
        /// 保存txt文件
        /// </summary>
        private void SaveTxtFile()
        {
            string str = txbSerialReceiveData.Text;//将要存储的文本信息装入临时字符串变量
            
            if (mSaveFileDialog.ShowDialog() == DialogResult.OK)//选择了文件
            {
                File.WriteAllText(mSaveFileDialog.FileName, str);
                File.AppendAllText(mSaveFileDialog.FileName, "\r\n<!------" + DateTime.Now.ToString() + "------>\r\n");//数据最后插入时间戳
            }
        }

        /// <summary>
        /// 保存image文件
        /// </summary>
        private void SaveImageFile()
        {
            mSaveFileDialog.FileName = System.DateTime.Now.ToString("yyy年MM月dd日hh时mm分ss秒", System.Globalization.DateTimeFormatInfo.InvariantInfo) + ".jpg";
            if (DialogResult.OK == mSaveFileDialog.ShowDialog())//正常打开保存文件窗口
            {
                originalImagePictureBox.Image.Save(mSaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else
            {
                MessageBox.Show("Image Box is null!", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
            }
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
            mOpenFileDialog.Multiselect = true;//支持多选打开，并把文件列表显示到listbox上

            if (mOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string fName in mOpenFileDialog.FileNames)
                    {
                        listBoxFiles.Items.Add(Path.GetFileName(fName));
                        openFileList.Add(fName);
                    }

                    listBoxFiles.SelectedIndex = 0;
                    
                    OpenFile(listBoxFiles.SelectedIndex);
                }
                catch 
                {
                    MessageBox.Show("Check the path to correct file first.");
                }
            }
        }

        /// <summary>
        /// 保存文件操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileSave_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)//保存txt文件
            {
                if (txbSerialReceiveData.Text != string.Empty)//存在可保存的TXT信息
                {
                    SaveTxtFile();
                }
                else
                {
                    MessageBox.Show("Save infomation is empty.");
                }
            }
            else if (tabControl.SelectedIndex == 1)//保存图像文件
            {
                if (originalImagePictureBox.Image != null)//存在已显示的原始图像
                {
                    SaveImageFile();
                }
                else
                {
                    MessageBox.Show("Image is null!");
                }
            }
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileClose_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)//关闭文本文件
            {
                if (txbSerialReceiveData.Text != string.Empty)
                {
                    txbSerialReceiveData.Text = string.Empty;
                }
            }
            else if (tabControl.SelectedIndex == 1)
            {
                originalImagePictureBox.Image = null;
                binaryImagePictureBox.Image = null;
            }
        }
        
        /// <summary>
        /// 清空图像显示组件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileEmpty_Click(object sender, EventArgs e)
        {
            originalImagePictureBox.Image = null;
            binaryImagePictureBox.Image = null;
        }

        /// <summary>
        /// 打开目录中当前索引的上一个文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilePreviousClick(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex == 0)
            {
                listBoxFiles.SelectedIndex = openFileList.Count - 1;
                OpenFile(listBoxFiles.SelectedIndex);
            }
            else
            {
                listBoxFiles.SelectedIndex--;
                OpenFile(listBoxFiles.SelectedIndex - 1);
            }
        }

        /// <summary>
        /// 打开下一个文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileNext_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex == openFileList.Count - 1)//当前为listbox中的最后一个文件
            {
                listBoxFiles.SelectedIndex = 0;
                OpenFile(0);//打开第一个文件
            }
            else
            {
                listBoxFiles.SelectedIndex++;
                OpenFile(listBoxFiles.SelectedIndex);
            }
        }

        /// <summary>
        /// 双击ListBox框选项打开对应文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFile(listBoxFiles.SelectedIndex);
        }
        #endregion

        #region "Image Ctrl"
        /// <summary>
        /// 接收图像线程
        /// </summary>
        private void GetImage()
        {
            //帧设置
            int temp1 = Convert.ToInt32("0x" + mFrmSetting.setting.ImageHeader1, 16);
            int temp2 = Convert.ToInt32("0x" + mFrmSetting.setting.ImageHeader2, 16);
            int head1 = temp1 >> 8;
            int head2 = temp1 & 0x00ff;
            int head3 = temp2 >> 8;
            int head4 = temp2 & 0x00ff;
            int read1 = head1, read2 = head2, read3 = head3, read4 = head4;
            progressbarTimer.Enabled = true;

            while (true)
            {
                toolStripProgressBar.Value = 0;
                mSerialPort.DiscardInBuffer();//清空串口接收缓存
                while ((read1 != head1) || (read2 != head2) || (read3 != head3) || (read4 != head4))
                {
                    read1 = read2;
                    read2 = read3;
                    read3 = read4;
                    read4 = mSerialPort.ReadByte();
                }
                while (mSerialPort.BytesToRead < (imageInfo.Row * imageInfo.Col)) ;//将数据存到fifo里面里面去，等fifo存到有一幅图像数据的数据量的时候 在帮一幅图像一次性取出来
                //双缓冲切换接收
                if (isImageSelectDoubleBuf == 1)
                {
                    isImageSelectDoubleBuf = 2;
                    mSerialPort.Read(imageDoubleBuf1, 0, imageInfo.Row * imageInfo.Col - 1);
                }
                else if (isImageSelectDoubleBuf == 2)
                {
                    isImageSelectDoubleBuf = 1;
                    mSerialPort.Read(imageDoubleBuf2, 0, imageInfo.Row * imageInfo.Col - 1);
                }

                isImageGetSuccess = true;//成功接收图像标志
                //toolStripProgressBar.Value = 100;
            }
        }

        /// <summary>
        /// 显示图像线程
        /// </summary>
        private void ShowImage()
        {
            while (true)
            {
                if (isImageGetSuccess == true)//成功接收图像
                {
                    isImageGetSuccess = false;
                    //将接收到的一维图像转为二维图像
                    if (isImageSelectDoubleBuf == 1)
                    {
                        Buf2ImageBuf(Image, imageDoubleBuf1);
                    }
                    else if (isImageSelectDoubleBuf == 2)
                    {
                        Buf2ImageBuf(Image, imageDoubleBuf2);
                    }

                    Buf2OriginalBitmap();//将二维数组转为bitmap
                    Original2BinaryBitmap();//将原始图像二值化

                    //使用对象复制 可以解决两个线程同时使用一个资源的问题
                    DrawPicture(originalImagePictureBox, (Bitmap)originalBitmap.Clone());
                    DrawPicture(binaryImagePictureBox, (Bitmap)binaryBitmap.Clone());
                }
            }
        }

        delegate void DrawPictureDelegate(PictureBox picture, Bitmap bitmap);
        /// <summary>
        /// 对象复制 两个线程同时使用一个资源
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="bitmap"></param>
        private void DrawPicture(PictureBox picture, Bitmap bitmap)
        {
            if (picture.InvokeRequired)
            {
                DrawPictureDelegate tDelegate = new DrawPictureDelegate(DrawPicture);
                picture.Invoke(tDelegate, new object[] { picture, bitmap });
            }
            else
            {
                picture.Refresh();//刷新图像控件
                picture.Image = bitmap;//显示图像
            }
        }

        /// <summary>
        /// 将一维图像转为二维图像
        /// </summary>
        /// <param name="dstImage"></param>
        /// <param name="srcBuf"></param>
        private void Buf2ImageBuf(byte[,] dstImage, byte[] srcBuf)
        {
            if (isImageFilp == false)
            {
                for (int i = 0; i < imageInfo.Row; i++)
                {
                    for (int j = 0; j < imageInfo.Col; j++)
                    {
                        dstImage[i, j] = srcBuf[i * imageInfo.Col + j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < imageInfo.Row; i++)
                {
                    for (int j = 0; j < imageInfo.Col; j++)
                    {
                        dstImage[imageInfo.Row - 1 - i, imageInfo.Col - 1 - j] = srcBuf[i * imageInfo.Col + j];
                    }
                }
            }
        }

        /// <summary>
        /// 将原始图像转换为三色图显示
        /// </summary>
        private void Buf2OriginalBitmap()
        {
            if (isBinaryGet == true)//以二值化后的形式接收数据
            {
                for (int i = 0; i < imageInfo.Row; i++)
                {
                    for (int j = 0; j < imageInfo.Col; j++)
                    {
                        Color color;
                        if (Image[i, j] >= 1)
                            color = Color.FromArgb(0, 255, 255, 255);
                        else
                            color = Color.FromArgb(0, 0, 0, 0);
                        originalBitmap.SetPixel(j, i, color);
                    }
                }
            }
            else//以灰度图的形式接收图像
            {
                for (int i = 0; i < imageInfo.Row; i++)
                {
                    for (int j = 0; j < imageInfo.Col; j++)
                    {
                        Color color;
                        color = Color.FromArgb(0, Image[i, j], Image[i, j], Image[i, j]);
                        originalBitmap.SetPixel(j, i, color);
                    }
                }
            }
        }

        /// <summary>
        /// 将原始图像二值化，并转换后的图像以三色图的形式显示
        /// </summary>
        private void Original2BinaryBitmap()
        {
            Color color;
            if (isBinaryGet == true)//以二值化后的形式接收数据
            {
                for (int i = 0; i < imageInfo.Row; i++)
                {
                    for (int j = 0; j < imageInfo.Col; j++)
                    {
                        if (Image[i, j] >= 1)
                        {
                            color = Color.FromArgb(0, 255, 255, 255);
                        }
                        else
                        {
                            color = Color.FromArgb(0, 0, 0, 0);
                        }
                        binaryBitmap.SetPixel(j, i, color);
                    }
                }
            }
            else//以灰度图的形式接收图像
            {
                //获取当前设定图像二值化阈值
                int thresholdValue = imageThreshold;

                for (int i = 0; i < imageInfo.Row; i++)
                {
                    for (int j = 0; j < imageInfo.Col; j++)
                    {
                        if (Image[i, j] >= thresholdValue)
                        {
                            color = Color.FromArgb(0, 255, 255, 255);
                        }
                        else
                        {
                            color = Color.FromArgb(0, 0, 0, 0);
                        }
                        binaryBitmap.SetPixel(j, i, color);
                    }
                }
            }
        }

        /// <summary>
        /// 打开和关闭图像接收操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageBegin_Click(object sender, EventArgs e)
        {
            if (isComPortOpen == true)//确保串口已正常打开
            {
                if (btnImageBegin.Text == "Begin")
                {
                    imageThreshold = Convert.ToInt32(numericUpDownImageThreshold.Text);
                    imageInfo.Row = Convert.ToInt32(mFrmSetting.setting.ImageRow);
                    imageInfo.Col = Convert.ToInt32(mFrmSetting.setting.ImageCol);
                    //实例化显示处理的bitmap
                    originalBitmap = new Bitmap(imageInfo.Col, imageInfo.Row, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    binaryBitmap = new Bitmap(imageInfo.Col, imageInfo.Row, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Image = new byte[imageInfo.Row, imageInfo.Col];//初始数组大小
                    imageDoubleBuf1 = new byte[imageInfo.Col * imageInfo.Row];
                    imageDoubleBuf2 = new byte[imageInfo.Col * imageInfo.Row];
                    //实例化图像接收和显示线程
                    getImageThread = new Thread(GetImage);
                    showImageThread = new Thread(ShowImage);
                    getImageThread.Start();
                    showImageThread.Start();
                    btnImageBegin.Text = "Stop";

                    //组件属性设置
                    btnSerialportCtrl.Enabled = false;
                    btnFileOpen.Enabled = false;
                    btnFileSave.Enabled = false;
                    btnFilePrevious.Enabled = false;
                    btnFileNext.Enabled = false;
                    btnFileDelete.Enabled = false;

                    usrSettingToolStripMenuItem.Enabled = false;//开始接收图像后无法设置图像属性
                    tlblSerialStatus.Text = "Imager go";
                    lblImageRowNumber.Text = imageInfo.Row.ToString();
                    lblImageColNumber.Text = imageInfo.Col.ToString();
                }
                else //if (btnImageBegin.Text == "Stop")
                {
                    btnImageBegin.Text = "Begin";
                    getImageThread.Abort();//中止线程
                    showImageThread.Abort();

                    btnSerialportCtrl.Enabled = true;
                    btnFileOpen.Enabled = true;
                    btnFileSave.Enabled = true;
                    btnFilePrevious.Enabled = true;
                    btnFileNext.Enabled = true;
                    btnFileDelete.Enabled = true;

                    usrSettingToolStripMenuItem.Enabled = true;//开始接收图像后无法设置图像属性
                    tlblSerialStatus.Text = "Ready";
                    toolStripProgressBar.Value = 0;//进度条回归起点
                    progressbarTimer.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please open serial port first.");
            }
        }

        /// <summary>
        /// 图像算法处理操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageAlgorithm_Click(object sender, EventArgs e)
        {
            if (binaryImagePictureBox.Image != null)//确保有图像处理
            {
                imageAlgorithm.Image = this.Image;
                Bitmap bitmap = (Bitmap)binaryImagePictureBox.Image.Clone();

                imageAlgorithm.ShowDialog();//显示动态编译代码窗口，且占用主动权
                afterImage = imageAlgorithm.Image;//处理后的图像
                
                DrawPicture(binaryImagePictureBox, (Bitmap)bitmap.Clone());
            }
            else
            {
                MessageBox.Show("Not image can be proccessed.");
            }
        }

        /// <summary>
        /// 显示图像灰度直方图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageGray_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)originalImagePictureBox.Image.Clone();
            int k = 0;//临时计数
            int[] gray = new int[256];//灰度统计
            byte[] allcolor = new byte[bitmap.Width * bitmap.Height];

            if (bitmap != null)//确保图像不为空
            {
                //统计灰度值对应的次数
                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        if (k < bitmap.Width * bitmap.Height)
                        {
                            allcolor[k] = bitmap.GetPixel(j, i).R;
                            gray[BitConverter.ToInt32(allcolor, k)]++;
                        }
                    }
                }

                for (int i = 0; i < 256; i++)
                {
                    chartImageGray.Series[0].Points.AddXY(i + 1, gray[i] + 1);
                }
            }
        }

        /// <summary>
        /// 图像翻转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageFilp_Click(object sender, EventArgs e)
        {
            if (isImageFilp == true)
            {
                isImageFilp = false;
                btnImageFilp.Text = "nFilp";
            }
            else
            {
                isImageFilp = true;
                btnImageFilp.Text = "Filp";
            }
        }

        /// <summary>
        /// 二值化或者灰度图的形式接收图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinaryGray_Click(object sender, EventArgs e)
        {
            if (isBinaryGet == true)
            {
                isBinaryGet = false;
                btnBinaryGray.Text = "Binary";
            }
            else
            {
                isBinaryGet = true;
                btnBinaryGray.Text = "Pixel";
            }
        }

        /// <summary>
        /// 图像阈值调节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownImageThreshold_ValueChanged(object sender, EventArgs e)
        {
            imageThreshold = Convert.ToInt32(numericUpDownImageThreshold.Text);
        }

        /// <summary>
        /// 鼠标移动显示图片信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originalImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (originalImagePictureBox.Image != null)
            {
                Bitmap bitmap = new Bitmap(originalImagePictureBox.Image);
                if (bitmap != null)
                {
                    int X = e.X * bitmap.Size.Width / originalImagePictureBox.Size.Width;
                    int Y = e.Y * bitmap.Size.Height / originalImagePictureBox.Size.Height;

                    if (X <= bitmap.Size.Width && Y <= bitmap.Size.Height)
                    {
                        Color color = bitmap.GetPixel(X, Y);
                        mToolTip.SetToolTip(originalImagePictureBox, "X:" + X + " Y:" + Y + " Threshold:" + imageThreshold);
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标移动显示图片信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void binaryImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (binaryImagePictureBox.Image != null)
            {
                Bitmap bitmap = new Bitmap((Bitmap)binaryImagePictureBox.Image.Clone());
                if (bitmap != null)
                {
                    int X = e.X * bitmap.Size.Width / binaryImagePictureBox.Size.Width;
                    int Y = e.Y * bitmap.Size.Height / binaryImagePictureBox.Size.Height;

                    if (X <= bitmap.Size.Width && Y <= bitmap.Size.Height)
                    {
                        Color color = bitmap.GetPixel(X, Y);
                        mToolTip.SetToolTip(binaryImagePictureBox, "X:" + X + " Y:" + Y);
                    }
                }
            }
        }

        /// <summary>
        /// 图像接收进度条定时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void progressbarTimer_Tick(object sender, EventArgs e)
        {
            if (toolStripProgressBar.Value != 100)
                toolStripProgressBar.Value += 1;
        }
        #endregion
    }
}
