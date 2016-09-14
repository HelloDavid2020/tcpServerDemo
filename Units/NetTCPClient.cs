using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LeafSoft.Model;
using System.Net;
using System.Net.Sockets;


namespace LeafSoft.Units
{
    public partial class NetTCPClient :UserControl, ICommunication
    {
        /// <summary>
        /// 当前已连接客户端集合
        /// </summary>
        public BindingList<LeafTCPClient> lstClient = new BindingList<LeafTCPClient>();

        public event Lib.LeafEvent.DataReceivedHandler DataReceived;

        public NetTCPClient()
        {
            InitializeComponent();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in ipHostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {//筛选IPV4
                    txtServerIP.Text = ip.ToString();
                }
            }
        }

        /// <summary>
        /// 绑定客户端列表
        /// </summary>
        private void BindLstClient()
        {
            lstConn.Invoke(new MethodInvoker(delegate
            {
                lstConn.DataSource = null;
                lstConn.DataSource = lstClient;
                lstConn.DisplayMember = "Name";
            }));
        }

        /// <summary>
        /// 连接新的服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConn_Click(object sender, EventArgs e)
        {
            LeafTCPClient client = new LeafTCPClient();
            try
            {
                client.NetWork= new TcpClient();
                client.NetWork.Connect(txtServerIP.Text.Trim(), (int)nmServerPort.Value);//连接服务端
                client.SetName();
                client.NetWork.GetStream().BeginRead(client.buffer, 0, client.buffer.Length, new AsyncCallback(TCPCallBack), client);
                lstClient.Add(client);
                BindLstClient();
            }
            catch (Exception ex)
            {
                client.DisConnect();
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void TCPCallBack(IAsyncResult ar)
        {
            LeafTCPClient client = (LeafTCPClient)ar.AsyncState;
            if (client.NetWork.Connected)
            {
                NetworkStream ns = client.NetWork.GetStream();
                byte[] recdata = new byte[ns.EndRead(ar)];
                Array.Copy(client.buffer, recdata, recdata.Length);
                if (recdata.Length > 0)
                {
                    if (DataReceived != null)
                    {
                        DataReceived.BeginInvoke(client.Name, recdata, null, null);//异步输出数据
                    }
                    ns.BeginRead(client.buffer, 0, client.buffer.Length, new AsyncCallback(TCPCallBack), client);
                }
                else
                {
                    client.DisConnect();
                    lstClient.Remove(client);
                    BindLstClient();
                }
            }
        }


        public bool SendData(byte[] data)
        {
            if (lstConn.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lstConn.SelectedItems.Count; i++)
                {
                    LeafTCPClient selClient = (LeafTCPClient)lstConn.SelectedItems[i];
                    try
                    {
                        selClient.NetWork.GetStream().Write(data, 0, data.Length);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(selClient.Name + ":" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("无可用连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void MS_Delete_Click(object sender, EventArgs e)
        {
            if (lstConn.SelectedItems.Count > 0)
            {
                List<LeafTCPClient> WaitRemove = new List<LeafTCPClient>();
                for (int i = 0; i < lstConn.SelectedItems.Count; i++)
                {
                    WaitRemove.Add((LeafTCPClient)lstConn.SelectedItems[i]);
                }
                foreach (LeafTCPClient client in WaitRemove)
                {
                    client.DisConnect();
                    lstClient.Remove(client);
                }
            }
        }

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        public void ClearSelf()
        {
            foreach (LeafTCPClient client in lstClient)
            {
                client.DisConnect();
            }
            lstClient.Clear();
            BindLstClient();
        }
    }
}
