using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using LeafSoft.Model;


namespace LeafSoft.Lib
{
    public class LeafEvent
    {
        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void DataReceivedHandler(object sender,byte[] data);

        /// <summary>
        /// 发送数据事件
        /// </summary>
        /// <param name="data"></param>
        public delegate bool DataSendHandler(byte[] data);
    }
}
