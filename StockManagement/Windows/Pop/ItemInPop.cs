using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagement.Windows.Pop;
using Lib.Frame;
using Lib.Manager;
using StockManagement.Windows.View;

namespace StockManagement.Windows.Pop
{
    public partial class ItemInPop : MasterPop
    {
        private int m_in_ucode = -1;
        public ItemInPop()
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
            if(aPopMode == ePopMode.add)
            {
                this.Text = "입고 등록";
            }
            else if(aPopMode == ePopMode.modify)
            {
                this.Text = "입고 수정";
                if(aParam is Dictionary<string,object>)
                {
                    Dictionary<string, object> _dic = (Dictionary<string, object>)aParam;

                    DataRow _dp_row = _dic["master"] as DataRow;//형변환
                    m_in_ucode = Convert.ToInt32(_dp_row["in_ucode"]);
                    date_ItemIn.Value = Convert.ToDateTime(_dp_row["in_date"]);
                    tbox_code.Text = Convert.ToString(_dp_row["in_ucode"]);
                    tbox_supplier.Text = Convert.ToString(_dp_row["in_from"]);
                    tbox_TotalPrice.Text = Convert.ToString(_dp_row["in_price"]);

                    DataTable _src_in_detail = _dic["detail"] as DataTable;
                    DataTable _dp_in_detail = DisplaySet.Tables["dp_in_detail"];
                    _dp_in_detail.Rows.Clear();
                    foreach (DataRow _src in _src_in_detail.Rows) {
                        DataRow _dp_sub_row = _dp_in_detail.NewRow();
                        _dp_sub_row["sk_ucode"] = _src["sk_ucode"];
                        _dp_sub_row["sk_itemname"] = _src["sk_itemname"];
                        _dp_sub_row["ind_quan"] = _src["ind_quan"];
                        _dp_sub_row["ind_price"] = _src["ind_price"];
                        _dp_in_detail.Rows.Add(_dp_sub_row);    
                    }




                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ItemSearchPop _pop = new ItemSearchPop();
            _pop.OnAddItem = AddItem;
          
            _pop.Show();            
        }

        private void AddItem(DataRow aRow, int aQuan)
        {
            string _sk_itemname = Convert.ToString(aRow["sk_itemname"]);
            //MessageBox.Show(_sk_itemname);

            int _sk_ucode = Convert.ToInt32(aRow["sk_itemcode"]);

            DataTable _dt = DisplaySet.Tables["dp_in_detail"];
            DataRow[] _dp_rows = _dt.Select(string.Format("sk_ucode = {0}", _sk_ucode));

            if (_dp_rows != null && _dp_rows.Length > 0)
            {
                DataRow _dp_row = _dp_rows[0];
                _dp_row["ind_quan"] = aQuan;
            }
            else
            {
                DataRow _dp_row = _dt.NewRow();
                _dp_row["sk_itemname"] = _sk_itemname;
                _dp_row["ind_price"] =  aRow["sk_itemprice"];
                _dp_row["sk_ucode"] = _sk_ucode;
                _dp_row["ind_quan"] = aQuan;

                _dt.Rows.Add(_dp_row);
            }

            DisplayTotalPrice();

        }

        private void DisplayTotalPrice() {

            DataTable _dp_in_detail = DisplaySet.Tables["dp_in_detail"];
            int _total_price = 0;
            foreach(DataRow _dp_row in _dp_in_detail.Rows)
            {
                int _price = Convert.ToInt32(_dp_row["ind_price"]);
                int _quan = Convert.ToInt32(_dp_row["ind_quan"]);
               
                _total_price += _price*_quan;
            }
            this.tbox_TotalPrice.Text = _total_price.ToString();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private string ValidateCheck()
        {
            string _errorMsg = "";
            //필수값 체크

            string _in_from = this.tbox_supplier.Text;
            if(_in_from.Length <= 0)
            {
                _errorMsg += "거래처는 필수 입력 사항입니다.\n";
            }

            DataTable _dp_in_detail = DisplaySet.Tables["dp_in_detail"];
            if (_dp_in_detail.Rows.Count <= 0)
            {
                _errorMsg += "거래품목은 한가지 이상이어야 합니다.\n";

            }
            //자료형 체크

            return _errorMsg;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            DisplayTotalPrice();
            if (m_popMode == ePopMode.add) {
                Save4Add(); 
            } else if (m_popMode == ePopMode.modify) {
                DoSave4modify();
            }
        }

        private void DoSave4modify()
        {
            string _in_date = date_ItemIn.Value.ToString("yyyy-MM-dd");
            string _in_from = this.tbox_supplier.Text;
            //this.tbox_TotalPrice.Text = "0";
            int _in_price = Convert.ToInt32(this.tbox_TotalPrice.Text);
            string _checkeMsg = ValidateCheck();
            if (_checkeMsg.Length > 0) { MessageBox.Show(_checkeMsg); return; }
            //입고번호를 얻어온다.
            //int _in_ucode = App.Instance().DBManager.ReadSeq("seq_in"); //시퀸스를 실행해서 얻은 번호가 여기에 담긴다 ex)144.. 145... 146...
            

            int _result0 = App.Instance().DBManager.ModifyIn(m_in_ucode, _in_from, _in_date, _in_price); //in_ucode는 시퀸스로 얻어온 값 나머지는 텍스트 박스에 들어있는 값이 되겠다
                                                                                                     //AddIn을 정상적으로 수행하였으면 Addin의 return값인 _code가 1이기에 _result0의 값은 1이된다. 아래도 마찬가지

            int _result1 = App.Instance().DBManager.DeleteInDetail(m_in_ucode);

            DataTable _dp_in_detail = DisplaySet.Tables["dp_in_detail"];

            foreach (DataRow _dp_row in _dp_in_detail.Rows)
            {
                int _result2 = App.Instance().DBManager.AddInDetail(m_in_ucode, _dp_row);
            }
            DialogResult = DialogResult.OK;


        }
        private void Save4Add()
        {

            string _in_date = date_ItemIn.Value.ToString("yyyy-MM-dd");
            string _in_from = this.tbox_supplier.Text;
            int _in_price = 0;           
            if(tbox_TotalPrice.Text.Length > 0)
            {
               
                _in_price = Convert.ToInt32(this.tbox_TotalPrice.Text);
            }                           
            //유효성 검사
            string _checkeMsg = ValidateCheck();
            if (_checkeMsg.Length > 0) { MessageBox.Show(_checkeMsg);  return; }
            //입고번호를 얻어온다.
            int _in_ucode = App.Instance().DBManager.ReadSeq("seq_in"); //시퀸스를 실행해서 얻은 번호가 여기에 담긴다 ex)144.. 145... 146...

            int _result0 = App.Instance().DBManager.AddIn(_in_ucode, _in_from, _in_date, _in_price); //in_ucode는 시퀸스로 얻어온 값 나머지는 텍스트 박스에 들어있는 값이 되겠다
                                                                                                     //AddIn을 정상적으로 수행하였으면 Addin의 return값인 _code가 1이기에 _result0의 값은 1이된다. 아래도 마찬가지

            int _result1 = App.Instance().DBManager.DeleteInDetail(_in_ucode);

            DataTable _dp_in_detail = DisplaySet.Tables["dp_in_detail"];
           
            foreach(DataRow _dp_row in _dp_in_detail.Rows)
            {
                int _result2 = App.Instance().DBManager.AddInDetail(_in_ucode, _dp_row);
            }
                DialogResult = DialogResult.OK;
                           
           
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            //목록 삭제 버튼 구현해야 함
            DataRow _row = GridManager.SelectedRow(this.grid_ItemIn);
            if (_row != null) {
                DisplaySet.Tables["dp_in_detail"].Rows.Remove(_row);
            } else
            {
                MessageBox.Show("삭제할 품목을 선택하세요");
            }
      
        }

    }
}
