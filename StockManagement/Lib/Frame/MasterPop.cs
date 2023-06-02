using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Frame
{

    public enum ePopMode { none, add, modify,};
    public partial class MasterPop : Form
    {
        protected ePopMode m_popMode;
        public MasterPop()
        {
            InitializeComponent();
            m_popMode = ePopMode.none;
        }

        public virtual DialogResult 
            ShowDialog(ePopMode aMode, object aParam) {
            m_popMode=aMode;
            return this.ShowDialog();   
            
        } 









        private void MasterPop_Load(object sender, EventArgs e)
        {

        }
    }
}
