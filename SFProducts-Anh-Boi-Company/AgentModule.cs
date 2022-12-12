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

namespace SFProducts_Anh_Boi_Company
{
    public partial class AgentModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        FrmAgent FrmAgent = new FrmAgent();
        public AgentModule(FrmAgent frmAgent)
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            FrmAgent = frmAgent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
            txtAgent.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtMail.Clear();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtAgent.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you sure you want to save this Brand?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("Insert into tblAgent (Agent, Contact, Address, Phone, Mail) values (@Agent, @Contact, @Address, @Phone, @Mail) ", cn);
                    cmd.Parameters.AddWithValue("@Agent", txtAgent.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Mail", txtMail.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    FrmAgent.LoadAgent();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you sure you want to save this Brand?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("Update tblAgent set Agent=@Agent, Contact=@Contact, Address=@Address, Phone=@Phone, Mail=@Mail where ID=@ID ", cn);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@Agent", txtAgent.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Mail", txtMail.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning");
            }
        }
    }
}
