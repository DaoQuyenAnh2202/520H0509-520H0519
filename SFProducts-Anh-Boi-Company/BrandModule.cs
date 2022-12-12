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
    public partial class BrandModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        FrmBrand FrmBrand;
        public BrandModule(FrmBrand frmBrand)
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            FrmBrand = frmBrand;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            //To insert Brand name to Brand table
            try
            {
                if (MessageBox.Show("Do you sure you want to save this Brand?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tblBrand(BrandName)VALUES(@BrandName)", cn);
                    cmd.Parameters.AddWithValue("@BrandName", txtBrandName.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved.", "System");
                    Clear();
                    FrmBrand.LoadBrand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtBrandName.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtBrandName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you sure you want to update this Brand?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cmd = new SqlCommand("UPDATE tblBrand SET BrandName = @BrandName WHERE BID LIKE'" + lblID.Text + "'", cn);
                cmd.Parameters.AddWithValue("@BrandName", txtBrandName.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record has been successfully saved.", "POS");
                Clear();
                this.Dispose();// To close this form after update data
            }
        }
    }
}
