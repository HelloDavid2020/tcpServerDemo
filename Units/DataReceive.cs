using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace LeafSoft.Units
{
    /// <summary>
    /// 数据接收文本框
    /// </summary>
    public partial class DataReceive : UserControl
    {
        public DataReceive()
        {
            InitializeComponent();
        }

        #region 公有方法
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data">单个字节数据</param>
        public void AddData(byte data)
        {
            if (rbtnHex.Checked)
            { //16进制显示
                AddContent(data.ToString("X").ToUpper() + " ");
            }
            else
            { //ASCII码显示
                AddContent(new ASCIIEncoding().GetString(new byte[1] { data }));
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data">字节数组</param>
        public void AddData(byte[] data)
        {
            if (rbtnHex.Checked)
            { //16进制显示
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
            }
            else
            { //ASCII码显示
                AddContent(new ASCIIEncoding().GetString(data));
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 添加文本内容
        /// </summary>
        /// <param name="content"></param>
        private void AddContent(string content)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (cbxAutoLine.Checked && txtData.Text.Length > 0)
                {
                    txtData.AppendText("\r\n");
                }
                txtData.AppendText(content);
                if (txtData.Text.Length > 60000)
                {
                    txtData.Text.Remove(0, 10000);
                }
                txtData.SelectionStart = txtData.Text.Length;
                txtData.ScrollToCaret();
            }));

            //数据库处理
            String num = content.Substring(1, 3);//车位号
            String sta = content.Substring(4, 3);//车位状态
            String d = content.Substring(7, 1);//车位电量
            String z = content.Substring(8, 1);//车位状态

            Class1.conn = new SqlConnection("server=.;database=" + Class1.DBName + ";uid=" + Class1.UserName + ";pwd=" + Class1.Pswd + "");
            Class1.conn.Open();
            SqlCommand cmd = new SqlCommand();//
            cmd.Connection = Class1.conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update " + Class1.TableName + " set 命令数据=" + sta + " where 水表号=" + num; cmd.ExecuteNonQuery();//更新车位状态
            cmd.CommandText = "update " + Class1.TableName + " set 命令数据标志=" + d + " where 水表号=" + num; cmd.ExecuteNonQuery();//更新车位电量
            cmd.CommandText = "update " + Class1.TableName + " set 状态=" + z + " where 水表号=" + num; cmd.ExecuteNonQuery();//更新车位电量
            Class1.conn.Dispose();   
        }
        #endregion

        #region 菜单事件
        private void MS_Clear_Click(object sender, EventArgs e)
        {
            txtData.Clear();
        }

        private void CMS_Main_VisibleChanged(object sender, EventArgs e)
        {
            if (CMS_Main.Visible == true)
            {//菜单被显示
                string[] SelectData = txtData.SelectedText.TrimEnd().TrimStart().Split(' ');//获取选中部分文本
                foreach (string data in SelectData)
                {
                    if (Regex.IsMatch(data, "^[0-9A-Fa-f]+$"))
                    {
                        continue;
                    }
                    else
                    {
                        MS_ToInt.Enabled = false;
                        MS_ToFloat.Enabled = false;
                        MS_ToDouble.Enabled = false;
                        return;
                    }
                }
                if (SelectData.Length == 2)
                {
                    MS_ToInt.Enabled = true;
                    MS_ToFloat.Enabled = false;
                    MS_ToDouble.Enabled = false;
                }
                else if (SelectData.Length == 4)
                {
                    MS_ToInt.Enabled = true;
                    MS_ToFloat.Enabled = true;
                    MS_ToDouble.Enabled = false;
                }
                else if (SelectData.Length == 8)
                {
                    MS_ToInt.Enabled = false;
                    MS_ToFloat.Enabled = false;
                    MS_ToDouble.Enabled = true;
                }
                else
                {
                    MS_ToInt.Enabled = false;
                    MS_ToFloat.Enabled = false;
                    MS_ToDouble.Enabled = false;
                }
            }
            else
            {
                MS_ToInt.Enabled = false;
                MS_ToFloat.Enabled = false;
                MS_ToDouble.Enabled = false;
            }
        }
        #endregion

        #region 数值转换
        /// <summary>
        /// 2字节或4字节转换为整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS_ToInt_Click(object sender, EventArgs e)
        {
            string[] SelectData = txtData.SelectedText.TrimEnd().TrimStart().Split(' ');//获取选中部分文本
            byte[] IntByte = StringsToBytes(SelectData);
            if (IntByte.Length == 2)
            {
                MessageBox.Show(BitConverter.ToInt16(IntByte, 0).ToString(), "整数值");
            }
            else
            {
                MessageBox.Show(BitConverter.ToInt32(IntByte, 0).ToString(), "整数值");
            }
        }
        /// <summary>
        /// 4字节转换为单精度浮点数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS_ToFloat_Click(object sender, EventArgs e)
        {
            string[] SelectData = txtData.SelectedText.TrimEnd().TrimStart().Split(' ');//获取选中部分文本
            byte[] IntByte = StringsToBytes(SelectData);
            MessageBox.Show(BitConverter.ToSingle(IntByte, 0).ToString(), "单精度浮点数值");
        }
        /// <summary>
        /// 8字节转换为双精度浮点数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS_ToDouble_Click(object sender, EventArgs e)
        {
            string[] SelectData = txtData.SelectedText.TrimEnd().TrimStart().Split(' ');//获取选中部分文本
            byte[] IntByte = StringsToBytes(SelectData);
            MessageBox.Show(BitConverter.ToDouble(IntByte, 0).ToString(), "双精度浮点数值");
        }

        /// <summary>
        /// 16进制字符串数组转byte数组
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        private byte[] StringsToBytes(string[] B)
        {
            byte[] BToInt32 = new byte[B.Length];
            for (int i = 0; i < B.Length; i++)
            {
                BToInt32[i] = (byte)Convert.ToInt32(B[i], 16);
            }
            return BToInt32;
        }
        #endregion

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
