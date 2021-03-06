﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;

namespace DataProcessingLibrary
{
    public class SerialPortHelper
    {
        System.IO.Ports.SerialPort mSerialPort;

        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public SerialPortHelper()
        {
            this.mSerialPort = new System.IO.Ports.SerialPort();
        }

        /// <summary>
        /// 接收一个串口类对象构造方法
        /// </summary>
        /// <param name="serialport"></param>
        public SerialPortHelper(System.IO.Ports.SerialPort serialport)
        {
            this.mSerialPort = serialport;
        }
    }
}
