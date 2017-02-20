using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingLibrary.SerialPort
{
    /// <summary>
    /// 串口信息类
    /// </summary>
    public class SerialPortInfo
    {
        // 可用串口
        public string PortName { set; get; }

        // 临时串口
        public string tPortName { set; get; }

        // 波特率
        public string BaudRate { set; get; }

        // 数据位
        public string DataBit { get; set; }

        // 校验位
        public string Parity { set; get; }

        // 校验位数据
        public string ParityData { set; get; }

        // 停止位
        public string StopBit { set; get; }
    }
}
