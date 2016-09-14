using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LeafSoft
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
        }


        private Boolean dbUpdate()
        {
            string strSql = "select * from " + Class1.TableName + "";
            DataTable dtUpdate = new DataTable();
            dtUpdate = this.dbconn(strSql);
            dtUpdate.Rows.Clear();
            DataTable dtShow = new DataTable();
            dtShow = (DataTable)this.dataGridView1.DataSource;
            for (int i = 0; i < dtShow.Rows.Count; i++)
            {
                dtUpdate.ImportRow(dtShow.Rows[i]);
            }
            try
            {
                Class1.conn.Open();
                SqlCommandBuilder CommandBuiler;
                CommandBuiler = new SqlCommandBuilder(Class1.adapter);
                Class1.adapter.Update(dtUpdate);
                Class1.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            dtUpdate.AcceptChanges();
            return true;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.DBName = textBoxDB.Text; Class1.UserName = textBoxUser.Text; Class1.Pswd = textBoxPswd.Text; Class1.TableName = textBoxTable.Text;
                Class1.conn = new SqlConnection("server=.;database=" + Class1.DBName + ";uid=" + Class1.UserName + ";pwd=" + Class1.Pswd + "");
                SqlDataAdapter sda = new SqlDataAdapter("select * from " + Class1.TableName + "", Class1.conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Width = 105;
                }
                //buttonLoad.Enabled = false;
                dataGridView1.Columns[0].ReadOnly = true;

                //连接

                string msg = String.Format("共{0}个; 当前:第{1}行,第{2}列;", dataGridView1.RowCount, dataGridView1.CurrentCell.RowIndex,
                                            dataGridView1.CurrentCell.ColumnIndex);
                label4.Text = msg;
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("连接失败！","Error:");
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show("连接失败！\n" + errorMessages.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbUpdate())
            {
                MessageBox.Show("修改成功！", "修改成功：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable dbconn(string strSql)
        {
            Class1.conn = new SqlConnection("server=.;database=" + Class1.DBName + ";uid=" + Class1.UserName + ";pwd=" + Class1.Pswd + "");
            Class1.conn.Open();
            Class1.adapter = new SqlDataAdapter(strSql, Class1.conn);
            DataTable dtSelect = new DataTable();
            int rnt = Class1.adapter.Fill(dtSelect);
            Class1.conn.Close();
            return dtSelect;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string msg = String.Format("共{0}个; 当前:第{1}行,第{2}列;", dataGridView1.RowCount, dataGridView1.CurrentCell.RowIndex,
                                        dataGridView1.CurrentCell.ColumnIndex);
            label4.Text = msg;
            //label4.Visible = true;
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }
    }
}
