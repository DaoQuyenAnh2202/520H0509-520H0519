using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace SFProducts_Anh_Boi_Company
{
    public partial class SFProducts : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();

        public SFProducts()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            cn.Open();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to close ?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private Form ActiveForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            pnlSFProduct.Controls.Add(ChildForm);
            pnlSFProduct.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void btnGoodsProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmProduct());
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBrand());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCategory());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgent());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmUser());
        }

        private void btnGoodsReceived_Click(object sender, EventArgs e)
        {
            openChildForm(new GoodsReceived());
        }
    }
}
