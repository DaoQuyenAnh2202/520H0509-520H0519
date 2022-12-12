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
    public partial class FrmBrand : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;

        public FrmBrand()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            LoadBrand();
        }

        public void LoadBrand()
        {
            int i = 0;
            dgvBrand.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tblBrand ORDER BY BrandName", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvBrand.Rows.Add(i, dr["BID"].ToString(), dr["BrandName"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            BrandModule bmodule = new BrandModule(this);
            bmodule.ShowDialog();
        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //For edit and delete Category by cell click icon from tblCategory
            string colName = dgvBrand.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                BrandModule formModule = new BrandModule(this);
                formModule.lblID.Text = dgvBrand.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtBrandName.Text = dgvBrand.Rows[e.RowIndex].Cells[2].Value.ToString();
                formModule.btnSave.Enabled = false;
                formModule.btnUpdate.Enabled = true;
                formModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Brand?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tblBrand WHERE BID LIKE '" + dgvBrand.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadBrand();
        }
    }
}
