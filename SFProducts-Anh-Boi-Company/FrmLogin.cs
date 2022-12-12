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
    public partial class FrmLogin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;
        public string _Password = "";
        public bool _Isactive;
        public FrmLogin()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
        }


        private void btnclear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to clear ?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
            }

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string _Username = "", _Fullname = "", _Role = "";
                bool found;
                cn.Open();
                cmd = new SqlCommand("Select * From tblUser Where Username = @Username and Password = @Password", cn);
                cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _Username = dr["Username"].ToString();
                    _Fullname = dr["Fullname"].ToString();
                    _Role = dr["Role"].ToString();
                    _Password = dr["Password"].ToString();
                    _Isactive = bool.Parse(dr["Isactive"].ToString());

                }
                else
                {
                    found = false;
                }
                dr.Close();
                cn.Close();

                if (found)
                {
                    if (!_Isactive)
                    {
                        MessageBox.Show("Account is deactivate. Unable to login", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_Role == "Accountants")
                    {
                        MessageBox.Show("Welcome " + _Fullname , "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUser.Clear();
                        txtPass.Clear();
                        this.Hide();
                    }
                    if (_Role == "Admin")
                    {
                        MessageBox.Show("Welcome " + _Fullname , "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUser.Clear();
                        txtPass.Clear();
                        this.Hide();
                        SFProducts main = new SFProducts();
                        main.lblUsername.Text = _Username;
                        main.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to close ?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }    
            
        }

    }
}
