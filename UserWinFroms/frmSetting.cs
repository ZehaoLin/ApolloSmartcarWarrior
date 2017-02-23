using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinFroms
{
    public partial class frmSetting : Form
    {
        // 初始化要序列化的对象
        public SettingJsonSerializer setting = new SettingJsonSerializer();

        public frmSetting()
        {
            InitializeComponent();

            SettingPropertyInit();
        }

        /// <summary>
        /// 属性配置初始化
        /// </summary>
        public void SettingPropertyInit()
        {
            // 获取当前工程的完整路径
            //string currentPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            //初始化默认配置
            SerialPortSettingInit();
            ImageSettingInit();

            // 检测$PROJ$Setting目录下有没有存在的配置文件 若有则直接导入，否则生成默认配置
            if (Directory.Exists(@"Setting") == false) //检查setting文件是否存在，否则直接创建
            {
                Directory.CreateDirectory(@"Setting");
            }

            // 检测 "Setting\setting.json" 文件是否存在，存在则直接load，否则创建，并写入默认配置
            if (File.Exists(@"Setting\setting.json") == true)
            {
                LoadDefaultSetting();
            }
            else
            {
                SaveDefaultSettingToJson();
            }
        }

        /// <summary>
        /// Load已有配置
        /// </summary>
        private void LoadDefaultSetting()
        {
            using (StreamReader sr = new StreamReader(@"Setting\setting.json", Encoding.UTF8))
            {
                string json = sr.ReadToEnd();//读取json文件为字符串
                Deserialization(json);//反序列化

                // 载入配置文件信息
                cmbSerialBaudRate.Text = setting.BaudRate;
                cmbSerialDataBit.Text = setting.DataBit;
                cmbSerialParity.Text = setting.Parity;
                cmbSerialStopBit.Text = setting.StopBit;

                txbSerialParityData.Text = setting.ParityData;
                txbImageRow.Text = setting.ImageRow;
                txbImageCol.Text = setting.ImageCol;
                txbImageHeader1.Text = setting.ImageHeader1;
                txbImageHeader2.Text = setting.ImageHeader2;
            }
        }

        /// <summary>
        /// 保存默认配置为Json文件
        /// </summary>
        private void SaveDefaultSettingToJson()
        {
            // 串口配置部分
            setting.BaudRate = "115200";
            setting.DataBit = "8";
            setting.Parity = "None";
            setting.ParityData = string.Empty;
            setting.StopBit = "1";
            // 图像传输部分
            setting.ImageRow = "120";
            setting.ImageCol = "160";
            setting.ImageHeader1 = "00FF";
            setting.ImageHeader2 = "0100";

            // 序列化
            string json = Serialization();
            // 将json保存为json文件
            FileStream fs = new FileStream(@"setting\setting.json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(json);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public void SavaSettingToJson()
        {
            string json = Serialization();
            // 将json保存为json文件
            FileStream fs = new FileStream(@"setting\setting.json", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(json);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 序列化操作
        /// </summary>
        /// <returns>序列化后的json格式字符串</returns>
        private string Serialization()
        {
            // 序列化
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SettingJsonSerializer));
            MemoryStream ms = new MemoryStream();
            // 将序列后的json格式数据写入流中
            js.WriteObject(ms, setting);
            ms.Position = 0;
            // 从0位置开始读取流中的数据
            StreamReader sr = new StreamReader(ms, Encoding.UTF8);
            string json = sr.ReadToEnd();

            // 手动关闭
            sr.Close();
            ms.Close();

            return json;
        }

        /// <summary>
        /// 反序列化操作
        /// </summary>
        /// <param name="json"></param>
        private void Deserialization(string json)
        {
            // 反序列化
            string toDes = json;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(SettingJsonSerializer));
                setting = (SettingJsonSerializer)deserializer.ReadObject(ms);// 反序列化读取Object
            }
        }

        /// <summary>
        /// 关闭设置窗口时将配置信息写入json文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            SavaSettingToJson();
        }

        public int ParityConvert(string str)
        {
            int tmp = 0;
            switch (str)
            {
                case "None":
                    tmp = 0;
                    break;
                case "Odd":
                    tmp = 1;
                    break;
                case "Even":
                    tmp = 2;
                    break;
                case "Mark":
                    tmp = 3;
                    break;
                case "Space":
                    tmp = 4;
                    break;
                default:
                    tmp = 0;
                    break;
            }

            return tmp;
        }

        #region "Serial Port Setting Init"
        /// <summary>
        /// 串口配置选项初始化
        /// </summary>
        private void SerialPortSettingInit()
        {
            BaudRateSelectedItemsInit();
            DataBitSelectedItemsInit();
            ParityDataTextInit();
            ParitySelectedItemsInit();
            StopBitSelectedItemsInit();
        }

        /// <summary>
        /// 波特率选项初始化
        /// </summary>
        private void BaudRateSelectedItemsInit()
        {
            cmbSerialBaudRate.Items.Clear();

            cmbSerialBaudRate.Items.Add("1200");
            cmbSerialBaudRate.Items.Add("2400");
            cmbSerialBaudRate.Items.Add("4800");
            cmbSerialBaudRate.Items.Add("9600");
            cmbSerialBaudRate.Items.Add("19200");
            cmbSerialBaudRate.Items.Add("38400");

            cmbSerialBaudRate.Items.Add("43000");
            cmbSerialBaudRate.Items.Add("56000");
            cmbSerialBaudRate.Items.Add("57600");
            cmbSerialBaudRate.Items.Add("115200");

            // 默认波特率为 115200
            cmbSerialBaudRate.SelectedIndex = 9;
        }

        /// <summary>
        /// 数据位选项初始化
        /// </summary>
        private void DataBitSelectedItemsInit()
        {
            cmbSerialDataBit.Items.Clear();

            cmbSerialDataBit.Items.Add("8");
            cmbSerialDataBit.Items.Add("7");
            cmbSerialDataBit.Items.Add("6");

            cmbSerialDataBit.SelectedIndex = 0;
        }

        /// <summary>
        /// 校验位选项初始化
        /// </summary>
        private void ParitySelectedItemsInit()
        {
            cmbSerialParity.Items.Clear();

            cmbSerialParity.Items.Add("None");
            cmbSerialParity.Items.Add("Odd");
            cmbSerialParity.Items.Add("Even");
            cmbSerialParity.Items.Add("Mark");
            cmbSerialParity.Items.Add("Space");

            cmbSerialParity.SelectedIndex = 0;
        }

        /// <summary>
        /// 校验数据初始化
        /// </summary>
        private void ParityDataTextInit()
        {
            txbSerialParityData.Text = string.Empty;
        }

        /// <summary>
        /// 停止位选项初始化
        /// </summary>
        private void StopBitSelectedItemsInit()
        {
            cmbSerialStopBit.Items.Clear();

            cmbSerialStopBit.Items.Add("1");
            cmbSerialStopBit.Items.Add("1.5");
            cmbSerialStopBit.Items.Add("2");
            cmbSerialStopBit.SelectedIndex = 0;
        }
        #endregion

        #region "Image Setting Init"
        /// <summary>
        /// 图像接收属性初始化
        /// </summary>
        private void ImageSettingInit()
        {
            txbImageRow.Text = "120";
            txbImageCol.Text = "180";
            txbImageHeader1.Text = "00FF";
            txbImageHeader2.Text = "0100";
        }
        #endregion

        #region "Property Change"
        private void cmbSerialBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.BaudRate = cmbSerialBaudRate.Text;
        }

        private void cmbSerialDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.DataBit = cmbSerialDataBit.Text;
        }

        private void cmbSerialParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.Parity = cmbSerialParity.Text;
        }

        private void cmbSerialStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.StopBit = cmbSerialStopBit.Text;
        }

        private void txbSerialParityData_TextChanged(object sender, EventArgs e)
        {
            setting.ParityData = txbSerialParityData.Text;
        }

        private void txbImageRow_TextChanged(object sender, EventArgs e)
        {
            setting.ImageRow = txbImageRow.Text;
        }

        private void txbImageCol_TextChanged(object sender, EventArgs e)
        {
            setting.ImageCol = txbImageCol.Text;
        }

        private void txbImageHeader1_TextChanged(object sender, EventArgs e)
        {
            setting.ImageHeader1 = txbImageHeader1.Text;
        }

        private void txbImageHeader2_TextChanged(object sender, EventArgs e)
        {
            setting.ImageHeader2 = txbImageHeader2.Text;
        }
        #endregion

        /// <summary>
        /// Json序列化类
        /// </summary>
        [DataContract]
        public class SettingJsonSerializer
        {
            [DataMember]
            public string BaudRate { get; set; }

            [DataMember]
            public string DataBit { get; set; }

            [DataMember]
            public string Parity { get; set; }

            [DataMember]
            public string StopBit { get; set; }

            [DataMember]
            public string ParityData { get; set; }

            [DataMember]
            public string ImageRow { get; set; }

            [DataMember]
            public string ImageCol { get; set; }

            [DataMember]
            public string ImageHeader1 { get; set; }

            [DataMember]
            public string ImageHeader2 { get; set; }
        }
    }
}
