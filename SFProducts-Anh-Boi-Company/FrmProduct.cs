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
    public partial class FrmProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;
        public FrmProduct()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT p.Pcode, p.Pname, b.BrandName, c.CategoryName, p.Price, p.Reorder FROM tblProduct AS p INNER JOIN tblBrand AS b ON b.BID = p.BID INNER JOIN tblCategory AS c on c.CID = p.CID", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule productModule = new ProductModule(this);
            productModule.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModule product = new ProductModule(this);
                product.txtProductcode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                product.txtProductName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                product.cbBrand.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                product.cbCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                product.txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                product.NumReOder.Value = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString());

                product.txtProductcode.Enabled = false;
                product.btnSave.Enabled = false;
                product.btnUpdate.Enabled = true;
                product.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do you sure you want to delete this record?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tblProduct WHERE Pcode LIKE '" + dgvProduct[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully deleted.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadProduct();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
