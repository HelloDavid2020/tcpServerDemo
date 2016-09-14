using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LeafSoft
{
    public class Class1
    {
        public static string DBName = ""; //定义全局变量
        public static string UserName = "";
        public static string Pswd = "";
        public static string TableName = "";
        public static string sqlStr = "";
        public static SqlConnection conn = null;
        public static SqlDataAdapter adapter = null;

        public Class1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.conn;
            cmd.CommandText = Class1.sqlStr;
            cmd.CommandType = CommandType.Text;
        }

    }
}
