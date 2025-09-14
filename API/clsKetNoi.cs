using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace API
{
    public class clsKetNoi
    {
        SqlConnection con = new SqlConnection();
        public clsKetNoi()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public DataTable LoadTable(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public DataTable LoadTable(string sql,string[]name,object[]value,int thamso)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            for(int i=0;i< thamso;i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public int UpdateTable(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteNonQuery();//0=>ko thanh cong,1:thanh cong
        }
        public int UpdateTable(string sql,string[]name,object[]value,int thamso)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            for (int i = 0; i < thamso; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            return cmd.ExecuteNonQuery();
        }

    }
}
