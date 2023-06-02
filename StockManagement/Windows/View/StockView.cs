using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Manager;
using StockManagement.Lib.Frame;
using StockManagement.Windows.Pop;
using System.Windows;
using Lib.Frame;


namespace StockManagement.Windows.View
{
    public partial class StockView : MasterView
    {
        public StockView()
        {
            InitializeComponent();
            panel3.Visible = false;
            cbox_MainCon.SelectedIndex = 0;
          
        }

        private void ShowSubCon()
        {
            if(cbox_MainCon.SelectedIndex == 1) 
            {
            cbox_SubCon.SelectedIndex = 0;
            panel3.Visible=true;
            }
            else if(cbox_MainCon.SelectedIndex == 2)
            {
                panel3.Visible = true;
                cbox_SubCon.SelectedIndex = -1;
            }
            else
            {
                panel3.Visible=false;
                cbox_SubCon.SelectedIndex = -1;
            }            
            
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSubCon();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockPop _pop = new StockPop();
            _pop.ShowDialog(ePopMode.add, null);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
            DataRow _dp_row = GridManager.SelectedRow(grid_stock);    
            if(_dp_row == null)
            {
                MessageBox.Show("수정할 데이터를 선택해 주세요");
                return;
            }
            StockPop _pop = new StockPop();
            _pop.ShowDialog(ePopMode.modify, _dp_row);
        }



        private void btn_search_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            int _cond = cbox_MainCon.SelectedIndex;
            string _cond1 = cbox_SubCon.Text;
            string _seed = tbox_seed.Text;

            DataTable _db_table = App.Instance().DBManager.ReadStock(_cond, _cond1, _seed);

            DataTable _dp_table = DisplaySet.Tables["dp_stock"];
            _dp_table.Rows.Clear();

            foreach (DataRow _db_row in _db_table.Rows)
            {

                DataRow _dp_row = _dp_table.NewRow();

                _dp_row["sk_itemcode"] = _db_row["sk_itemcode"];
                _dp_row["sk_itemsort"] = _db_row["sk_itemsort"];
                _dp_row["sk_itemname"] = _db_row["sk_itemname"];
                _dp_row["sk_itemprice"] = _db_row["sk_itemprice"];
                _dp_row["sk_itemquan"] = _db_row["sk_itemquan"];
                _dp_row["sk_itemrecoquan"] = _db_row["sk_itemrecoquan"];
                _dp_row["sk_itemrecentin"] = _db_row["sk_itemrecentin"];
                _dp_row["sk_itemrecentout"] = _db_row["sk_itemrecentout"];
                _dp_row["sk_memo"] = _db_row["sk_memo"];
                _dp_row["sk_picture"] = _db_row["sk_picture"];
                
                
                int _status = Convert.ToInt32(_db_row["sk_status"]);
                if (_status == 0)
                {
                    foreach (DataColumn _col in _dp_table.Columns)
                    {
                        if (_col.ColumnName == "sk_status")
                        {
                            _dp_row[_col] = "0";
                            _dp_row.SetColumnError(_col, "삭제된 상품입니다");
                        }
                    }
                }
                else
                {
                    _dp_row["sk_status"] = _db_row["sk_status"];
                }


                _dp_table.Rows.Add(_dp_row);


            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DataRow _dp_row = GridManager.SelectedRow(grid_stock);
            if (_dp_row == null)
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요");
                
            }
            else { 
            int _sk_itemcode = Convert.ToInt32(_dp_row["sk_itemcode"]);
            int _sk_status = Convert.ToInt32(_dp_row["sk_status"]);
            if (_sk_status == 0)
            {
                if (MessageBox.Show("이미 삭제된 상품입니다. 재등록 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int _result = App.Instance().DBManager.StockViewLazyDelete(_sk_itemcode, _sk_status);
                    if (_result > 0)
                    {
                        MessageBox.Show("재등록 되었습니다.");
                    }
                    else if (_result == -999)
                    {
                        MessageBox.Show("DB접속실패");
                    }
                    else
                    {
                        MessageBox.Show("재등록 실패");
                    }
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
                DoSearch();
            }
            else if( _sk_status == 1)
            {
                if(MessageBox.Show("삭제처리 하시겠습니까? 데이터는 보존됩니다.","확인",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    int _result = App.Instance().DBManager.StockViewLazyDelete(_sk_itemcode, _sk_status);
                    if (_result > 0)
                    {
                        MessageBox.Show("삭제 되었습니다.");
                    }
                    else if (_result == -999)
                    {
                        MessageBox.Show("DB접속실패");
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패");
                    }
                    DoSearch() ;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
      
        }
        }


    }
}
