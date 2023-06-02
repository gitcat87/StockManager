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
using StockManagement.Windows.Pop;

namespace StockManagement.Windows.Pop
{
    public partial class ItemOutPop : MasterPop
    {
        private int m_out_ucode = -1;
        public ItemOutPop()
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
                this.Text = "출고 등록";
            }
            else if (aPopMode == ePopMode.modify)
            {
                this.Text = "출고 수정";
                if (aParam is Dictionary<string, object>)
                {
                    Dictionary<string, object> _dic = (Dictionary<string, object>)aParam;

                    DataRow _dp_row = _dic["master"] as DataRow;//형변환
                    m_out_ucode = Convert.ToInt32(_dp_row["out_ucode"]);
                    date_ItemOut.Value = Convert.ToDateTime(_dp_row["out_date"]);
                    tbox_code.Text = Convert.ToString(_dp_row["out_ucode"]);
                    tbox_buyer.Text = Convert.ToString(_dp_row["out_to"]);
                    tbox_address.Text = Convert.ToString(_dp_row["out_place"]);
                    tbox_TotalPrice.Text = Convert.ToString(_dp_row["out_price"]);

                    DataTable _src_out_detail = _dic["detail"] as DataTable;
                    DataTable _dp_in_detail = DisplaySet.Tables["dp_out_detail"];
                    _dp_in_detail.Rows.Clear();
                    foreach (DataRow _src in _src_out_detail.Rows)
                    {
                        DataRow _dp_sub_row = _dp_in_detail.NewRow();
                        _dp_sub_row["sk_ucode"] = _src["sk_ucode"];
                        _dp_sub_row["sk_itemname"] = _src["sk_itemname"];
                        _dp_sub_row["outd_quan"] = _src["outd_quan"];
                        _dp_sub_row["outd_price"] = _src["outd_price"];
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
           

            DataTable _dt = DisplaySet.Tables["dp_out_detail"];
            DataRow[] _dp_rows = _dt.Select(string.Format("sk_ucode = {0}", _sk_ucode));

            if (_dp_rows != null && _dp_rows.Length > 0)
            {
                DataRow _dp_row = _dp_rows[0];
                _dp_row["outd_quan"] = aQuan;
            }
            else
            {
                DataRow _dp_row = _dt.NewRow(); 
                _dp_row["sk_itemname"] = _sk_itemname;           
                _dp_row["outd_price"] = aRow["sk_itemprice"];
                _dp_row["sk_ucode"] = _sk_ucode;
                _dp_row["outd_quan"] = aQuan;

                _dt.Rows.Add(_dp_row);
            }


            DisplayTotalPrice();

        }

   

        

        private void DisplayTotalPrice()
        {

            DataTable _dp_in_detail = DisplaySet.Tables["dp_out_detail"];
            int _total_price = 0;
            foreach (DataRow _dp_row in _dp_in_detail.Rows)
            {

                int _price = Convert.ToInt32(_dp_row["outd_price"]);
                int _quan = Convert.ToInt32(_dp_row["outd_quan"]);

                _total_price += _price * _quan;
            }
            this.tbox_TotalPrice.Text = _total_price.ToString();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private string ValidateCheck()
        {
            string _erroMsg = "";
            //필수값 체크

            string _out_buyer = this.tbox_buyer.Text;
            string _out_adress = this.tbox_address.Text;
            if(_out_buyer.Length <= 0)
            {
                _erroMsg += "고객명은 필수 입력 사항입니다.\n";
            }
            else if(_out_adress.Length <=0){
                _erroMsg += "배송지 주소는 필수 입력 사항입니다.\n";
            }

            DataTable _dp_out_detail = DisplaySet.Tables["dp_out_detail"];
            if(_dp_out_detail.Rows.Count <= 0) 
            {
                _erroMsg += "거래품목은 한가지 이상이어야 합니다.\n";
            }
            //자료형 체크

            return _erroMsg;
        }

        private void DoSave4modify()
        {
            string _out_date = date_ItemOut.Value.ToString("yyyy-MM-dd");
            string _out_to = this.tbox_buyer.Text;
            string _out_place = this.tbox_address.Text;
            int _out_price = Convert.ToInt32(this.tbox_TotalPrice.Text);

            //유효성 검사
            string _checkMsg = ValidateCheck();
            if(_checkMsg.Length > 0) { MessageBox.Show(_checkMsg); return; }
            //출고번호를 얻어온다.
            //int _out_ucode = App.Instance().DBManager.ReadSeq("seq_out"); //시퀸스를 실행해서 얻은 번호가 여기에 담긴다 ex)144.. 145... 146...
            //수정에서 필요없는 이유가 ePopmode 수정란에서 시퀸스 값을 읽게 설정해 있다.
            //처음에 폼을 ePopMode.modify로 열게되면 m_out_ucode == _out_ucode와 같으므로
            //다시 적어줄 필요가 없다 적게 되면 마찬가지로 또 시퀸스 값을 새로 생성하는 것
            int _result0 = App.Instance().DBManager.ModifyOut(m_out_ucode, _out_date, _out_to, _out_place, _out_price); //in_ucode는 시퀸스로 얻어온 값 나머지는 텍스트 박스에 들어있는 값이 되겠다
                                                                                                                    //을 정상적으로 수행하였으면 Addin의 return값인 _code가 1이기에 _result0의 값은 1이된다. 아래도 마찬가지

            int _result1 = App.Instance().DBManager.DeleteOutDetail(m_out_ucode);
            //기존에 있던 out_detail의 테이블을 정리해야 또 다시 생기지 않는다
            DataTable _dp_in_detail = DisplaySet.Tables["dp_out_detail"];

            foreach (DataRow _dp_row in _dp_in_detail.Rows)
            {
                int _result2 = App.Instance().DBManager.AddOutDetail(m_out_ucode, _dp_row);
            }
            DialogResult = DialogResult.OK;
        }

        private void Save4Add()
        {

            string _out_date = date_ItemOut.Value.ToString("yyyy-MM-dd");
            string _out_to = this.tbox_buyer.Text;
            string _out_place = this.tbox_address.Text;
            int _out_price = 0;
            if (tbox_TotalPrice.Text.Length > 0)
            {
                _out_price = Convert.ToInt32(this.tbox_TotalPrice.Text);
            }
            
            //유효성 검사
            string _checkMsg = ValidateCheck();
            if (_checkMsg.Length > 0) { MessageBox.Show(_checkMsg); return; }
            //출고번호를 얻어온다.
            int _out_ucode = App.Instance().DBManager.ReadSeq("seq_out"); //시퀸스를 실행해서 얻은 번호가 여기에 담긴다 ex)144.. 145... 146...

            int _result0 = App.Instance().DBManager.AddOut(_out_ucode, _out_date, _out_to, _out_place, _out_price); //in_ucode는 시퀸스로 얻어온 값 나머지는 텍스트 박스에 들어있는 값이 되겠다
                                                                                                                    //AddIn을 정상적으로 수행하였으면 Addin의 return값인 _code가 1이기에 _result0의 값은 1이된다. 아래도 마찬가지

            int _result1 = App.Instance().DBManager.DeleteInDetail(_out_ucode);

            DataTable _dp_in_detail = DisplaySet.Tables["dp_out_detail"];

            foreach (DataRow _dp_row in _dp_in_detail.Rows)
            {
                int _result2 = App.Instance().DBManager.AddOutDetail(_out_ucode, _dp_row);
            }
            DialogResult = DialogResult.OK;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DisplayTotalPrice();
            if(m_popMode == ePopMode.add)
            {
                Save4Add();
            }
            else if(m_popMode == ePopMode.modify)
            {
                DoSave4modify();
            }
          
        }
    }
}
