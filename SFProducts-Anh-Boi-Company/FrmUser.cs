using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SFProducts_Anh_Boi_Company
{
    public partial class FrmUser : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;
        public FrmUser()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
        }
        

        public void Clear()
        {
            txtUser.Clear();
            txtPass.Clear();
            cbRole.SelectedIndex = 0;
            txtFullname.Clear();
            txtUser.Focus();
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            try
            { 
                cn.Open();
                cmd = new SqlCommand("Insert into tblUser(Username, Password, Role, Fullname) Values (@Username, @Password, @Role, @Fullname)", cn);
                cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                cmd.Parameters.AddWithValue("@Role", cbRole.Text);
                cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New account has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
