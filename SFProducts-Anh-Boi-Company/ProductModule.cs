using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFProducts_Anh_Boi_Company
{
    public partial class ProductModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        FrmProduct frmProduct;
        public ProductModule(FrmProduct frmProduct)
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            LoadBrand();
            LoadCategory();
            this.frmProduct = frmProduct;
        }

        public void LoadCategory()
        {
            cbCategory.Items.Clear();
            cbCategory.DataSource = db.getTable("SELECT * FROM tblCategory");
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CID";
        }
        public void LoadBrand()
        {
            cbBrand.Items.Clear();
            cbBrand.DataSource = db.getTable("SELECT * FROM tblBrand");
            cbBrand.DisplayMember = "BrandName";
            cbBrand.ValueMember = "BID";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            txtProductcode.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            cbBrand.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
            NumReOder.Value = 1;

            txtProductcode.Enabled = true;
            txtProductcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you sure want to save this product?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tblProduct(Pcode, Pname, BID, CID, Price, Reorder)VALUES (@pcode,@Pname,@BID,@CID,@Price, @Reorder)", cn);
                    cmd.Parameters.AddWithValue("@Pcode", txtProductcode.Text);
                    cmd.Parameters.AddWithValue("@Pname", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@BID", cbBrand.SelectedValue);
                    cmd.Parameters.AddWithValue("@CID", cbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Reorder", NumReOder.Value);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully saved.", "System");
                    Clear();
                    frmProduct.LoadProduct();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to update this product?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tblProduct SET Pcode=@Pcode,Pname=@Pname,BID=@BID,CID=@CID,Price=@Price, Reorder=@Reorder WHERE Pcode LIKE @Pcode", cn);
                    cmd.Parameters.AddWithValue("@Pcode", txtProductcode.Text);
                    cmd.Parameters.AddWithValue("@Pname", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@BID", cbBrand.SelectedValue);
                    cmd.Parameters.AddWithValue("@CID", cbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Reorder", NumReOder.Value);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully updated.", "System");
                    Clear();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
