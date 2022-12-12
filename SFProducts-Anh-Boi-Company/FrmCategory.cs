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
    public partial class FrmCategory : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;
        public FrmCategory()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            LoadCategory();
        }

        //Data retrieve from tblCategory to dgvCategory on Category form
        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tblCategory ORDER BY CategoryName", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr["CID"].ToString(), dr["CategoryName"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryModule moduleForm = new CategoryModule(this);
            moduleForm.ShowDialog();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //For edit and delete Category by cell click icon from tblCategory
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CategoryModule formModule = new CategoryModule(this);
                formModule.lblID.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                formModule.btnSaveCat.Enabled = false;
                formModule.btnUpdateCat.Enabled = true;
                formModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tblCategory WHERE CID LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadCategory();
        }
    }
}
