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

        /// <summary>
        /// 用户自定义类定义 
        /// </summary>
        frmSetting mFrmSetting;
        
        IList<SerialPortInfo> serialInfoList = new List<SerialPortInfo>();// 可用串口集合
        private bool isHex = false;
        private bool isComPortOpen = false;

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

            mFrmSetting = new frmSetting();// 属性配置窗口
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

            if (cmbCOMPort.Text != string.Empty)
                cmbCOMPort.SelectedIndex = 0;// 默认显示第一个可用串口
        }

        /// <summary>
        /// 串口打开/关闭控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrialportCtrl_Click(object sender, EventArgs e)
        {   
            if (cmbCOMPort.SelectedValue == null) // 检测当前是否有选择的串口可用
            {
                MessageBox.Show("COM is null.");
                return;// 无串口可用，直接退出
            }

            #region "Open Serial Port"
            if (isComPortOpen == false)
            {

            }
            #endregion
            #region "Close Serial Port"
            else
            {

            }
            #endregion
        }

        /// <summary>
        /// 扫描可用串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCOMSearch_Click(object sender, EventArgs e)
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

        }

        /// <summary>
        /// 串口接收模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnSerialReceive_Click(object sender, EventArgs e)
        {

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
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            mOpenFileDialog.Filter = "text file (*.txt)|*.txt|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            mOpenFileDialog.FilterIndex = 1;
            mOpenFileDialog.Multiselect = true;

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
                }
                catch
                {
                    MessageBox.Show("There was an error." + "Check the path to corret file.");
                }
            }

            string filename = string.Empty;
            if (Path.GetExtension(filename).ToLower() == "txt")
            {

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
