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
    public partial class GoodsReceivedModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;
        int qty=0;
        public GoodsReceivedModule()
        {

            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            LoadAgent();
            LoadProduct();
        }
        public void LoadAgent()
        {
            dgvAgent.Rows.Clear();
            int i = 0;
            cn.Open();
            cmd = new SqlCommand("SELECT a.ID, a.Agent FROM tblAgent AS a", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvAgent.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            cn.Close();
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

        private void btnCloseCategory_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPcode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void dgvAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAID.Text = dgvAgent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAname.Text = dgvAgent.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void UDQty_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToInt16(UDQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = UDQty.Value - 1;
                return;
            }
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }
        public void GetQty()
        {
            cmd = new SqlCommand("SELECT Qty FROM tblProduct WHERE PID=@PID'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }
    }
}
