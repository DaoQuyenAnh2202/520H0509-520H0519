using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFProducts_Anh_Boi_Company
{
    public partial class GoodsReceived : Form
    {
        public GoodsReceived()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            GoodsReceivedModule goodsReceivedModule = new GoodsReceivedModule();
            goodsReceivedModule.ShowDialog();
        }
    }
}
