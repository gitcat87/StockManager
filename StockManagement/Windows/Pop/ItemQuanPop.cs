using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Windows.Pop
{
    public partial class ItemQuanPop : Form
    {
        public int Quan { get { return Convert.ToInt32(tbox_quan.Text); } }
        public ItemQuanPop()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
