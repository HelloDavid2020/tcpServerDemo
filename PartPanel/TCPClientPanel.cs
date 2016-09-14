using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace LeafSoft.PartPanel
{
    public partial class TCPClientPanel : BasePanel
    {
        public TCPClientPanel()
        {
            InitializeComponent();
        }

        private bool DataSender_EventDataSend(byte[] data)
        {
            if (Configer.SendData(data) == true)
            {
                MDataCounter.PlusSend(data.Length);
                return true;
            }
            return false;
        }

        private void Configer_DataReceived(object sender, byte[] data)
        {
            tabDataReceiver.AddData(sender.ToString(), data);
            MDataCounter.PlusReceive(data.Length);
        }

        public override void ClearSelf()
        {
            Configer.ClearSelf();
        }
    }
}
