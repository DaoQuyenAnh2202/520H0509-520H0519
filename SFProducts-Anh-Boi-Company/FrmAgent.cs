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
    public partial class FrmAgent : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Dbconnection db = new Dbconnection();
        SqlDataReader dr;

        public FrmAgent()
        {
            InitializeComponent();
            cn = new SqlConnection(db.DBConnection());
            LoadAgent();
        }
        public void LoadAgent()
        {
                dgvAgent.Rows.Clear();
                int i = 0;
                cn.Open();
                cmd = new SqlCommand("SELECT * FROM tblAgent", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvAgent.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());

                }
                dr.Close();
                cn.Close();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AgentModule agentModule = new AgentModule(this);
            agentModule.ShowDialog();
        }

        private void dgvAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAgent.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                AgentModule agentModule = new AgentModule(this);
                agentModule.lblID.Text = dgvAgent.Rows[e.RowIndex].Cells[1].Value.ToString();
                agentModule.txtAgent.Text = dgvAgent.Rows[e.RowIndex].Cells[2].Value.ToString();
                agentModule.txtContact.Text = dgvAgent.Rows[e.RowIndex].Cells[3].Value.ToString();
                agentModule.txtAddress.Text = dgvAgent.Rows[e.RowIndex].Cells[4].Value.ToString();
                agentModule.txtPhone.Text = dgvAgent.Rows[e.RowIndex].Cells[5].Value.ToString();
                agentModule.txtMail.Text = dgvAgent.Rows[e.RowIndex].Cells[6].Value.ToString();

                agentModule.btnSave.Enabled = false;
                agentModule.btnUpdate.Enabled = true;
                agentModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Delete this record? click yes to confirm", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("Delete from tblAgent where ID like '" + dgvAgent.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully deleted.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            LoadAgent();
        }
    }
}
