using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lib.Frame;
using Lib.Manager;
using System.IO;

namespace StockManagement.Windows.Pop
{
    public partial class ContactPop : MasterPop
    {
        private int m_ct_ucode = -1;
        public ContactPop()
        {
            InitializeComponent();
        }

        public override DialogResult ShowDialog(ePopMode aMode, object aParam)
        {
            Initialize(aMode, aParam);
            return base.ShowDialog(aMode, aParam);
        }
        private void Initialize(ePopMode aPopMode, object aParam)
        {
            if (aPopMode == ePopMode.add)
            {
                this.Text = "거래처 등록";
                //label_title.Text = "메뉴 추가";
                //cbox_category.SelectedIndex = 0;
                //tbox_name.Text = "새상품";
                //tbox_price.Text = "0";
                //tbox_description.Text = "";

            }
            else if (aPopMode == ePopMode.modify)
            {
                this.Text = "거래처 수정";
                if(aParam is DataRow)
                {
                    DataRow _dp_row = (DataRow)aParam;//타입케스팅

                    m_ct_ucode = Convert.ToInt32(_dp_row["ct_ucode"]);
                    tbox_name.Text = Convert.ToString(_dp_row["ct_name"]);
                    tbox_rep.Text = Convert.ToString(_dp_row["ct_rep"]);
                    tbox_bnumber.Text = Convert.ToString(_dp_row["ct_bnumber"]);

                    tbox_email.Text = Convert.ToString(_dp_row["ct_email"]);
                    tbox_fax.Text = Convert.ToString(_dp_row["ct_fax"]);
                    tbox_tel.Text = Convert.ToString(_dp_row["ct_tel"]);

                    tbox_manager.Text = Convert.ToString(_dp_row["ct_manger"]);
                    tbox_manger_tel.Text = Convert.ToString(_dp_row["ct_mangertel"]);
                    tbox_memo.Text = Convert.ToString(_dp_row["ct_memo"]);
                }
            }

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (m_popMode == ePopMode.add) {

                DoSave4Add();
            } else if(m_popMode == ePopMode.modify)
            {
                DoSave4Modify();
            }
        }

        private void DoSave4Add()
        {
            string _name = tbox_name.Text;
            string _rep = tbox_rep.Text;
            string _regnum = tbox_bnumber.Text;
            string _email = tbox_email.Text;
            string _fax = tbox_fax.Text;
            string _tel = tbox_tel.Text;

            string _manager = tbox_manager.Text;
            string _manager_tel = tbox_manger_tel.Text;
            string _memo = tbox_memo.Text;

            int _result = App.Instance().DBManager.AddContract(_name, _rep, _regnum, _email, _fax, _tel, _manager, _manager_tel, _memo);
            if (_result > 0)
            {
                MessageBox.Show("저장성공");
            }
            else if (_result == -999)
            {
                MessageBox.Show("접속실패");
            }
            else
            {
                MessageBox.Show("저장실패");
            }



        }
        private void DoSave4Modify()
        {
            string _name = tbox_name.Text;
            string _rep = tbox_rep.Text;
            string _regnum = tbox_bnumber.Text;
            string _email = tbox_email.Text;
            string _fax = tbox_fax.Text;
            string _tel = tbox_tel.Text;

            string _manager = tbox_manager.Text;
            string _manager_tel = tbox_manger_tel.Text;
            string _memo = tbox_memo.Text;

            int _result = App.Instance().DBManager.ModifyContract(this.m_ct_ucode, _name, _rep, _regnum, _email, _fax, _tel, _manager, _manager_tel, _memo);
            if (_result > 0)
            {
                MessageBox.Show("저장성공");
            }
            else if (_result == -999)
            {
                MessageBox.Show("접속실패");
            }
            else
            {
                MessageBox.Show("저장실패");
            }



        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;


        }
    }
}
