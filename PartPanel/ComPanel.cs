using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace LeafSoft.PartPanel
{
    public partial class ComPanel : BasePanel
    {
        public ComPanel()
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
            DataReceiver.AddData(data);
            MDataCounter.PlusReceive(data.Length);
        }

        public override void ClearSelf()
        {
            Configer.ClearSelf();
        }
    }
}
