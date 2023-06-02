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
    public partial class InItemsView : MasterView
    {
        public InItemsView()
        {
            InitializeComponent();
            cbox_MainCon.SelectedIndex = 0;
            cbox_SubCon.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemInPop _pop = new ItemInPop();
            DialogResult _dresult = _pop.ShowDialog(ePopMode.add, null);
            if(_dresult == DialogResult.OK)
            {
                DoSearch();
            }
        }

        private void SubChange()
        {
            cbox_SubCon.SelectedIndex = -1;
        }

        private void DoSearch()
        {
            int _cond = cbox_MainCon.SelectedIndex;
            int _cond1 = cbox_SubCon.SelectedIndex;
            string _seed = tbox_seed.Text;

            DataTable _db_table = App.Instance().DBManager.ReadInItems(_cond, _cond1, _seed);

            DataTable _dp_table = DisplaySet.Tables["dp_InItems"];
            _dp_table.Rows.Clear();

            foreach (DataRow _db_row in _db_table.Rows)
            {

                DataRow _dp_row = _dp_table.NewRow();

                _dp_row["in_ucode"] = _db_row["in_ucode"];
                _dp_row["in_date"] = _db_row["in_date"];
                _dp_row["in_from"] = _db_row["in_from"];
                _dp_row["in_items"] = _db_row["in_items"];
                _dp_row["in_price"] = _db_row["in_price"];
                _dp_row["in_status"] = _db_row["in_status"];

                _dp_table.Rows.Add(_dp_row);

            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            DoSearch();

        }

        private void cbox_MainCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubChange();
            tbox_seed.Clear();
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            DataRow _dp_row = GridManager.SelectedRow(grid_in);
            if(_dp_row == null)
            {
                MessageBox.Show("삭제할 입고 내역을 선택하세요");   
                return;
            }
            int _status = Convert.ToInt32(_dp_row["in_status"]);
            if(_status == 0) { 
            int _index = grid_in.SelectedRows[0].Index;     
            DataRow _selected_row = DisplaySet.Tables["dp_InItems"].Rows[_index];
            string _code = string.Format("{0}", _selected_row["in_ucode"]);
            int _in_code = int.Parse(_code);
            int _result = App.Instance().DBManager.DeleteInItem(_in_code);
            int _result_sub = App.Instance().DBManager.DeleteInDetail(_in_code);
                if (MessageBox.Show("입고번호" + _code + "를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
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
                MessageBox.Show("입고 처리된 상품은 삭제 할 수 없습니다.");
            }
        }
      

        private void btn_modify_Click(object sender, EventArgs e)
        {
            DataRow _dp_row1 = GridManager.SelectedRow(grid_in);
            
            //수정 버튼을 눌렀을 때 신규로 등록 되는 버그가 있음
            if(grid_in.SelectedRows.Count > 0)
            {
                int _status = Convert.ToInt32(_dp_row1["in_status"]);
                if (_status == 0) { 
                Dictionary<string, object> _ItemDic = new Dictionary<string, object>(); 
                DataRow _dp_row = GridManager.SelectedRow(grid_in); //_dp_row는 grid_in 데이터셋이 들어가 있다             
                _ItemDic.Clear();
                _ItemDic.Add("master", _dp_row);
                _ItemDic.Add("detail", this.DisPlaySet_Sub.Tables["dp_Initems_sub"]);

                ItemInPop _pop = new ItemInPop(); //pop창을 만든다
                DialogResult _dresult = _pop.ShowDialog(ePopMode.modify, _ItemDic); //ePopMode로 modify enum값과 grid_in datarow가 있는 _dp_row를 넘겨준다
                if(_dresult == DialogResult.OK) {
                    DoSearch(); 
                }
                }
                else
                {
                    MessageBox.Show("입고처리된 상품은 수정 할 수 없습니다.");
                }

                //_pop.ShowDialog(ePopMode.modify, _dp_row_sub);


            }
            else
            {
                MessageBox.Show("수정할 거래처를 선택하세요");
            }
         

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //if (grid_in.SelectedRows.Count > 0) {

            //    int _index = grid_in.SelectedRows[0].Index;
            //    if (MessageBox.Show("입고처리 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        //in_ucode
            //        //디테일
            //        DataTable _in_detail = this.DisPlaySet_Sub.Tables["dp_Initems_sub"];
            //        //DataTable _in = this.DisplaySet.Tables["dp_itemins"];
            //        int _result_sum = 0;
            //        foreach (DataRow row in _in_detail.Rows)
            //        {
            //            int _sk_ucode = Convert.ToInt32(row["sk_ucode"]);
            //            int _ind_quan = Convert.ToInt32(row["ind_quan"]);
            //            int _result = App.Instance().DBManager.ModifyStockQuan(_sk_ucode, _ind_quan);
            //            _result_sum += _result;
            //        }
            //        if (_result_sum == _in_detail.Rows.Count)
            //        {
            //            MessageBox.Show("성공");
            //        }



            //        //DataRow _selected_row = DisplaySet.Tables["dp_Initems_sub"].Rows[_index];
            //    }
            //    else
            //    {

            //    }
            //} else { 
            //    MessageBox.Show("입고내역을 선택하세요"); 
            //}


            if (grid_in.SelectedRows.Count > 0)
            {

                int _index = grid_in.SelectedRows[0].Index;
                if (MessageBox.Show("입고처리 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //in_ucode
                    //디테일
                    DataTable _in_detail = this.DisPlaySet_Sub.Tables["dp_Initems_sub"];
                    DataRow _dp_row = GridManager.SelectedRow(grid_in);
                    int _in_status = Convert.ToInt32(_dp_row["in_status"]);
                    int _in_ucode = Convert.ToInt32(_dp_row["in_ucode"]);

                    int _result_sum = 0;
                 
                    foreach (DataRow row in _in_detail.Rows)
                    {
                        int _sk_ucode = Convert.ToInt32(row["sk_ucode"]);
                        int _ind_quan = Convert.ToInt32(row["ind_quan"]);                        
                        int _result = App.Instance().DBManager.ModifyStockQuanADD(_sk_ucode, _ind_quan);
                        _result_sum += _result;
                    }
                    if (_result_sum == _in_detail.Rows.Count && _in_status == 0)
                    {
                        int _result = App.Instance().DBManager.ModifyInItemStatus(_in_status, _in_ucode);
                        MessageBox.Show("재고 반영 성공");
                        DoSearch();
                    }
                    else
                    {
                        MessageBox.Show("이미 입고처리된 상품입니다.");
                    }
                }
       
            }
            else
            {
                MessageBox.Show("입고내역을 선택하세요");
            }
        }

        private void grid_in_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_in.SelectedRows.Count >0) {
                int _index = grid_in.SelectedRows[0].Index;
                DataRow _selected_row = DisplaySet.Tables["dp_InItems"].Rows[_index];
                string _code = string.Format("{0}", _selected_row["in_ucode"]);
                int _in_code = int.Parse(_code);

                DataTable _db_table = App.Instance().DBManager.ReadInDetail(_in_code);

                DataTable _dp_table = DisPlaySet_Sub.Tables["dp_Initems_sub"];
                _dp_table.Rows.Clear();

                foreach (DataRow _db_row in _db_table.Rows)
                {
                    DataRow _dp_row = _dp_table.NewRow();

                    _dp_row["ind_ucode"] = _db_row["ind_ucode"];
                    _dp_row["ind_quan"] = _db_row["ind_quan"];
                    _dp_row["ind_price"] = _db_row["ind_price"];
                    _dp_row["in_ucode"] = _db_row["in_ucode"];
                    _dp_row["sk_ucode"] = _db_row["sk_ucode"];
                    _dp_row["sk_itemname"] = _db_row["sk_itemname"];

                    _dp_table.Rows.Add(_dp_row);

                }
            }

        }

        private void grid_in_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

   
    }
}
