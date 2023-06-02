using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagement.Lib.Frame;
using StockManagement.Windows.Pop;

using Lib.Manager;
using Lib.Frame;

namespace StockManagement.Windows.View
{
    public partial class ContactView : MasterView
    {
        public ContactView()
        {
            InitializeComponent();
            cbox_MainCon.SelectedIndex = 0;
        }

        private void btn_add_contactor_Click(object sender, EventArgs e)
        {
            ContactPop _pop = new ContactPop();
            _pop.ShowDialog(ePopMode.add, null);
        }


        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (grid_contact.SelectedRows.Count > 0)
            {
                DataRow _dp_row = GridManager.SelectedRow(grid_contact);
                ContactPop _pop = new ContactPop();
                _pop.ShowDialog(ePopMode.modify, _dp_row);
            } else
            {
                MessageBox.Show("수정할 거래처를 선택하세요");
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (grid_contact.SelectedRows.Count > 0)
            {
                DialogResult _dresult = MessageBox.Show("거래처를 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);
                if (_dresult == DialogResult.Yes)
                {
                    DataRow _dp_row = GridManager.SelectedRow(grid_contact);
                    int _ct_ucode = Convert.ToInt32(_dp_row["ct_ucode"]);
                    int _result = App.Instance().DBManager.DeleteContactor(_ct_ucode);
                    if (_result > 0)
                    {
                        MessageBox.Show("삭제성공");
                        DoSearch();

                    }
                    else if (_result == -999)
                    {
                        MessageBox.Show("접속실패");
                    }
                    else
                    {
                        MessageBox.Show("삭제실패");
                    }
                }


            }
            else
            {
                MessageBox.Show("수정할 거래처를 선택하세요");
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        { 
            DoSearch();
        }

        private void DoSearch() { 
            int _cond = cbox_MainCon.SelectedIndex;
            string _seed = tbox_seed.Text;

            DataTable _db_table = App.Instance().DBManager.ReadContact(_cond, _seed);

            DataTable _dp_table = DisplaySet.Tables["dp_contact"];
            _dp_table.Rows.Clear();
            foreach(DataRow _db_row in _db_table.Rows)
            {
                DataRow _dp_row = _dp_table.NewRow();
                _dp_row["ct_ucode"] = _db_row["ct_ucode"];
                _dp_row["ct_name"] = _db_row["ct_name"];
                _dp_row["ct_rep"] = _db_row["ct_rep"];
                _dp_row["ct_bnumber"] = _db_row["ct_bnumber"];
                _dp_row["ct_email"] = _db_row["ct_email"];
                _dp_row["ct_tel"] = _db_row["ct_tel"];
                _dp_row["ct_fax"] = _db_row["ct_fax"];
                _dp_row["ct_manger"] = _db_row["ct_manger"];
                _dp_row["ct_mangertel"] = _db_row["ct_mangertel"];
                _dp_row["ct_memo"] = _db_row["ct_memo"];

                _dp_table.Rows.Add(_dp_row);
            }
        }

    }
}
