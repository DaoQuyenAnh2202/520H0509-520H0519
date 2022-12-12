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
    public partial class CategoryModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        FrmCategory FrmCategory;
        public CategoryModule(FrmCategory frmCategory)
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            FrmCategory = frmCategory;
        }

        private void btnCloseCategory_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            //To insert Category name to Category table
            try
            {
                if (MessageBox.Show("Do you sure you want to save this Category?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tblCategory(CategoryName)VALUES(@CategoryName)", cn);
                    cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved.", "System");
                    Clear();
                    FrmCategory.LoadCategory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearCat_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtCategoryName.Clear();
            btnUpdateCat.Enabled = false;
            btnSaveCat.Enabled = true;
            txtCategoryName.Focus();
        }

        private void btnUpdateCat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you sure you want to update this Category?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cmd = new SqlCommand("UPDATE tblCategory SET CategoryName = @CategoryName WHERE CID LIKE'" + lblID.Text + "'", cn);
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record has been successfully saved.", "POS");
                Clear();
                this.Dispose();// To close this form after update data
            }
        }
    }
}
