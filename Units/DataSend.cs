using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LeafSoft.Lib;
using System.Threading;


namespace LeafSoft.Units
{
    public partial class DataSend : UserControl
    {
        BindingList<Model.CMD> lstCMD = new BindingList<Model.CMD>();

        public event LeafEvent.DataSendHandler EventDataSend;

        /// <summary>
        /// 是否在自动循环发送状态
        /// </summary>
        bool AutoSend = false;

        public DataSend()
        {
            InitializeComponent();
            dgCMD.AutoGenerateColumns = false;
            lstCMD.Add(new Model.CMD(EnumType.CMDType.ASCII, new ASCIIEncoding().GetBytes("S00100111E\n")));
            dgCMD.DataSource = lstCMD;
        }

        private void dgCMD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex>=0)
            {//点击了发送按钮 
                if (EventDataSend != null)
                {
                    EventDataSend(lstCMD[e.RowIndex].Bytes);
                }
            }
        }

        private void dgCMD_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgCMD.Rows[e.RowIndex].Cells[3].Value = "发送";
        }

        /// <summary>
        /// 添加调试命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void MS_Add_Click(object sender, EventArgs e)
        //{
        //    frmCMD fCmd = new frmCMD();
        //    if (fCmd.ShowDialog() == DialogResult.OK)
        //    {
        //        lstCMD.Add(fCmd.NewCMD);
        //    }
        //}

        /// <summary>
        /// 编辑调试命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void MS_Edit_Click(object sender, EventArgs e)
        //{
        //    if (dgCMD.SelectedRows.Count > 0)
        //    {
        //        frmCMD fCmd = new frmCMD(lstCMD[dgCMD.SelectedRows[0].Index]);
        //        if (fCmd.ShowDialog() == DialogResult.OK)
        //        {
        //            lstCMD[dgCMD.SelectedRows[0].Index] = fCmd.NewCMD;
        //        }
        //    }
        //}

        /// <summary>
        /// 删除调试命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS_Delete_Click(object sender, EventArgs e)
        {
            if (dgCMD.SelectedRows.Count > 0)
            {
                lstCMD.RemoveAt(dgCMD.SelectedRows[0].Index);
            }
        }

        private void btnAutoSend_Click(object sender, EventArgs e)
        {
            if (AutoSend == false)
            {
                btnAutoSend.Text = "停止循环";
                dgCMD.Enabled = false;
                nmDelay.Enabled = false;
                AutoSend = true;
                Thread ThTestL = new Thread(new ParameterizedThreadStart(TAutoSend));
                ThTestL.IsBackground = true;
                ThTestL.Start(nmDelay.Value);
            }
            else
            {
                StopAutoSend();
            }
        }

        /// <summary>
        /// 自动发送命令线程
        /// </summary>
        private void TAutoSend(object Interval)
        {
            try
            {
                object sendlock = new object();
                int SendInterval = Convert.ToInt32(Interval);
                while (AutoSend)
                {
                    for (int i = 0; i < lstCMD.Count; i++)
                    {
                        if (AutoSend)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                object cbxValue = dgCMD.Rows[i].Cells[0].Value;
                                if (cbxValue is bool && cbxValue.Equals(true))
                                {
                                    if (EventDataSend != null)
                                    {
                                        if (EventDataSend(lstCMD[i].Bytes) == false)
                                        {
                                            StopAutoSend();
                                        }
                                    }
                                }
                            }));
                            Thread.Sleep(SendInterval);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch { };
        }

        /// <summary>
        /// 停止循环发送
        /// </summary>
        private void StopAutoSend()
        {
            AutoSend = false;
            btnAutoSend.Text = "循环发送";
            dgCMD.Enabled = true;
            nmDelay.Enabled = true;
        }
    }
}
