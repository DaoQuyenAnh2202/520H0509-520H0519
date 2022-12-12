using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFProducts_Anh_Boi_Company
{
    internal class Dbconnection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string con;
        public string DBConnection()
        {
            con = @"Data Source=DESKTOP-F4PQEE7\SQLEXPRESS;Initial Catalog=SFProcuct-Anh-Boi;Integrated Security=True";
            return con;

        }

        public DataTable getTable(string qury)
        {
            cn.ConnectionString = DBConnection();
            cmd = new SqlCommand(qury, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
