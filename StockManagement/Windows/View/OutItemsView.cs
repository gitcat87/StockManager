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
using Microsoft.SqlServer.Server;
using StockManagement.Lib.Frame;
using StockManagement.Windows.Pop;


namespace StockManagement.Windows.View
{
    public partial class OutItemsView : MasterView
    {
        public OutItemsView()
        {
            InitializeComponent();
            cbox_MainCon.SelectedIndex = 0;
            cbox_SubCon.SelectedIndex = -1;

        }

        private void ShowSubCon()
        {
            if (cbox_MainCon.SelectedIndex == 1 || cbox_MainCon.SelectedIndex == 2 || cbox_MainCon.SelectedIndex == 3)
            {
                cbox_SubCon.SelectedIndex = 0;
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
                cbox_SubCon.SelectedIndex = -1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemOutPop _pop = new ItemOutPop();
            DialogResult _dresult = _pop.ShowDialog(ePopMode.add,null);
            if(_dresult == DialogResult.OK)
            {
                DoSearch();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            int _cond = cbox_MainCon.SelectedIndex;
            //int _cond1 = cbox_SubCon.SelectedIndex;
            string _seed = tbox_seed.Text;

            DataTable _db_table = App.Instance().DBManager.ReadOutItems(_cond, _seed);

            DataTable _dp_table = DisplaySet.Tables["dp_OutItems"];
            _dp_table.Rows.Clear();

            foreach (DataRow _db_row in _db_table.Rows)
            {

                DataRow _dp_row = _dp_table.NewRow();

                _dp_row["out_ucode"] = _db_row["out_ucode"];
                _dp_row["out_date"] = _db_row["out_date"];
                _dp_row["out_to"] = _db_row["out_to"];
                _dp_row["out_place"] = _db_row["out_place"];
                _dp_row["out_items"] = _db_row["out_items"];
                _dp_row["out_price"] = _db_row["out_price"];
                _dp_row["out_status"] = _db_row["out_status"];

                _dp_table.Rows.Add(_dp_row);

            }
        }

        private void cbox_MainCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_seed.Clear();
        }

        private void grid_out_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_out.SelectedRows.Count > 0)
            {
                int _index = grid_out.SelectedRows[0].Index;
                DataRow _selected_row = DisplaySet.Tables["dp_OutItems"].Rows[_index];
                string _code = string.Format("{0}", _selected_row["out_ucode"]);
                int _out_code = int.Parse(_code);

                DataTable _db_table = App.Instance().DBManager.ReadOutDetail(_out_code);

                DataTable _dp_table = DisplaySet.Tables["dp_Sub_OutItems"];
                _dp_table.Rows.Clear();

                foreach (DataRow _db_row in _db_table.Rows)
                {
                    DataRow _dp_row = _dp_table.NewRow();

                    _dp_row["outd_ucode"] = _db_row["outd_ucode"];
                    _dp_row["outd_quan"] = _db_row["outd_quan"];
                    _dp_row["outd_price"] = _db_row["outd_price"];
                    _dp_row["out_ucode"] = _db_row["out_ucode"];
                    _dp_row["sk_ucode"] = _db_row["sk_ucode"];
                    _dp_row["sk_itemname"] = _db_row["sk_itemname"];

                    _dp_table.Rows.Add(_dp_row);

                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DataRow _dp_row = GridManager.SelectedRow(grid_out);
            if(_dp_row == null)
            {
                MessageBox.Show("삭제할 출고 내역을 선택하세요");
                return;
            }
            int _status = Convert.ToInt32(_dp_row["out_status"]);
            if(_status == 0) { 
            int _index = grid_out.SelectedRows[0].Index;
            DataRow _selected_row = DisplaySet.Tables["dp_OutItems"].Rows[_index];
            string _code = string.Format("{0}", _selected_row["out_ucode"]);
            int _out_code = int.Parse(_code);

            int _result = App.Instance().DBManager.DeletedOutItem(_out_code);
            int _result_sub = App.Instance().DBManager.DeleteOutDetail(_out_code);
            if(MessageBox.Show("출고번호 "+_code+" 를 삭제하시겠습니까?","삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes) { 
            if (_result > 0 && _result_sub > 0)
            {
                MessageBox.Show("삭제성공");
                DoSearch();
            }
            else if (_result == -999)
            {
                MessageBox.Show("DB 접속실패");
            }
            else
            {
                MessageBox.Show("삭제실패");
            }
            }
            }
            else if(_status == 1)
            {
                MessageBox.Show("출고 처리된 상품은 삭제 할 수 없습니다.");
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            DataRow _dp_row1 = GridManager.SelectedRow(grid_out);
            if (grid_out.SelectedRows.Count > 0)
            {
                int _status = Convert.ToInt32(_dp_row1["out_status"]);
                if(_status == 0) { 
                Dictionary<string, object> _ItemDic = new Dictionary<string, object>();
                DataRow _dp_row = GridManager.SelectedRow(grid_out);
                _ItemDic.Clear();
                _ItemDic.Add("master", _dp_row);
                _ItemDic.Add("detail", this.DisplaySet.Tables["dp_sub_outitems"]);

                ItemOutPop _pop = new ItemOutPop();
                DialogResult _dresult = _pop.ShowDialog(ePopMode.modify, _ItemDic);
                if (_dresult == DialogResult.OK) { 
                    DoSearch();
                }
                }
                else
                {
                    MessageBox.Show("출고 처리된 상품은 수정 할 수 없습니다.");
                }
                
            }
            else
            {
                MessageBox.Show("수정할 출고처를 선택하세요");
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (grid_out.SelectedRows.Count > 0)
            {

                int _index = grid_out.SelectedRows[0].Index;
                if (MessageBox.Show("출고처리 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //out_ucode
                    //디테일
                    DataTable _out_detail = this.DisplaySet.Tables["dp_sub_OutItems"];
                    DataRow _dp_row = GridManager.SelectedRow(grid_out);
                    int _out_status = Convert.ToInt32(_dp_row["out_status"]);
                    int _out_ucode = Convert.ToInt32(_dp_row["out_ucode"]);

                    int _result_sum = 0;

                    foreach (DataRow row in _out_detail.Rows)
                    {
                        int _sk_ucode = Convert.ToInt32(row["sk_ucode"]);
                        int _outd_quan = Convert.ToInt32(row["outd_quan"]);
                        int _result = App.Instance().DBManager.ModifyStockQuanMINUS(_sk_ucode, _outd_quan);
                        _result_sum += _result;
                    }
                    if (_result_sum == _out_detail.Rows.Count && _out_status == 0)
                    {
                        int _result = App.Instance().DBManager.ModifyOutItemStatus(_out_status, _out_ucode);
                        MessageBox.Show("재고 반영 성공");
                        DoSearch();
                    }
                    else
                    {
                        MessageBox.Show("이미 출고 처리된 상품입니다.");
                    }
                }

            }
            else
            {
                MessageBox.Show("입고내역을 선택하세요");
            }
        }

        private void cbox_SubCon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }    
}
