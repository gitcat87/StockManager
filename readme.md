# 재고 관리 프로그램

재고 관리 프로그램을 통해서 상품관리를 할 수 있습니다.
<br>
<br>

## 작동 목표

* 사용자는 재고 관리 프로그램을 통해서 상품관리(등록,삭제,수정 등) 및 연락처 관리를 할 수 있다.
* 사용자는 재고관리 뿐만 아니라 상품의 입/출고를 관리 할 수 있다.
* 사용자는 DB정보와 사용자 정보를 읽고 변경할 수 있다.
<br>
<br>

## 개발 환경

* C#, Visual Studio, Oracle DB, Oracle Dvelopement
<br>
<br>

<span style="color: red;">작성한 코드 양의 관계로 주요 기능만 소개하였습니다.</span>


## 구동 과정

![](https://github.com/gitcat87/StockManager/blob/main/images/capture1.png?raw=true)
#
```C#
//mainform.cs
        private void CreateObject() //객체 생성
        {
            m_StockView = new StockView();
            m_InitemsView = new InItemsView();
            m_OutIemsView = new OutItemsView();
            m_ContactView = new ContactView();

            m_DocManager = new DocManager();
            m_DBManager = new DBManager();
        }


        private void InitializeObject() //datagridview를 mainform에 띄우기 위하여 부모-자식 관계 지정
        {
            m_StockView.Parent = WorkZonePanel;
            m_StockView.Dock = DockStyle.Fill;

            m_InitemsView.Parent = WorkZonePanel;
            m_InitemsView.Dock = DockStyle.Fill;

            m_OutIemsView.Parent = WorkZonePanel;
            m_OutIemsView.Dock = DockStyle.Fill;

            m_ContactView.Parent = WorkZonePanel;
            m_ContactView.Dock = DockStyle.Fill;

            DBInfo _db = m_DocManager.ReadDBInfo(); //프로그램 시작시 DB에 자동 연결
            m_DBManager.SetConnectInfo(_db._Addr, _db._Port, _db._Id, _db._Pwd, _db._DataBase);

            App.Instance().DocManager = m_DocManager;
            App.Instance().DBManager = m_DBManager;

        }

                private void ShowView(eViewMode aMode) //각 작업영역 구분을 쉽게 하기 위하여 작성
        {
            if (aMode == eViewMode.Stock)
            {
                m_StockView.Show();
                m_InitemsView.Visible = false;
                m_OutIemsView.Visible = false;
                m_ContactView.Visible = false;
                this.Text = "StockManageMent[재고관리]";
            }
            else if (aMode == eViewMode.ItemIn)
            {
                m_StockView.Visible = false;
                m_InitemsView.Show();
                m_OutIemsView.Visible = false;
                m_ContactView.Visible = false;
                this.Text = "StockManageMent[입고관리]";
            }
            else if (aMode == eViewMode.ItemOut)
            {
                m_StockView.Visible = false;
                m_InitemsView.Visible = false;
                m_OutIemsView.Show();
                m_ContactView.Visible = false;
                this.Text = "StockManageMent[출고관리]";
            }
            else
            {
                m_StockView.Visible = false;
                m_InitemsView.Visible = false;
                m_OutIemsView.Visible = false;
                m_ContactView.Show();

                this.Text = "StockManageMent[거래처]";
            }
        }
```

```C#
//mainform.cs
        public MainForm()
        {
            CreateObject();
            InitializeComponent();
            InitializeObject();
            ShowView(eViewMode.Stock);

        }
```
* 프로그램을 시작하면 Mainform이 출력되고 Oracle DB에 미리 입력한 사용자 정보를 바탕으로 연결이 된다.
* 위 화면은 조회 버튼을 눌렀을 때 정상적으로 작동하여 DB에 있던 내용이 불러와졌다.
<br>
<br>

## 조회버튼을 눌렀을 때

![](https://github.com/gitcat87/StockManager/blob/main/images/capture1.png?raw=true)
#
```C#
//stockview.cs
 private void DoSearch()
        {
            int _cond = cbox_MainCon.SelectedIndex; //텍스트 박스에 값을 저장하기 위한 변수 선언
            string _cond1 = cbox_SubCon.Text;
            string _seed = tbox_seed.Text;

            DataTable _db_table = App.Instance().DBManager.ReadStock(_cond, _cond1, _seed); //Oracle DB를 읽어오기 위하여 DBManager.cs소스코드를 미리 작성 하였다.
                                                                                            //Manager/OracleManager.cs와 연동된다.

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
```

<br>
<br>

![](https://github.com/gitcat87/StockManager/blob/main/images/capture13.png?raw=true)
<br>
<br>

```C#
//Dbmanger.cs
public DataTable ReadStock(int _cond, string _cond1, string _seed)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null)
            {
                return _dt;
            }
            else
            {
                //쿼리문 만들기
                string _strQuery = "SELECT sk_ucode, sk_itemcode, " +
                    "sk_itemsort, sk_itemname, sk_itemquan, sk_itemrecoquan, ";
                _strQuery += "sk_itemrecentin, sk_itemrecentout," +
                    " sk_memo, sk_status, sk_itemprice, sk_picture ";
                _strQuery += "FROM cdh_stock ";

                if(_seed.Length >= 0)
                {
                    if(_cond == 0)
                    {
                        //전체
                        if(_seed.Length > 0)
                        {
                            _strQuery += string.Format(" WHERE  sk_itemname like '%{0}%'", _seed);
                        }
                        else{
                            _strQuery += string.Format("");
                        }
                    }
                    else if(_cond == 1)
                    {   //품목명
                        if (_seed.Length == 0)
                        {
                            
                            _strQuery += string.Format(" WHERE sk_itemsort = '{0}'", _cond1);
                        }
                        else
                        {
                            _strQuery += string.Format(" WHERE sk_itemsort = '{0}' and sk_itemname like '%{1}%'", _cond1, _seed);
                        }

                    }
                    else if(_cond == 2)
                    {
                        if(_seed.Length == 0 && _cond1.Length ==0 ) {
                            //텍스트박스 입력 값이 거나 보조조건이 선택 되어 있지 않을 때
                            _strQuery += string.Format(" WHERE sk_status = 0");
                            //삭제된 상품을 전부 보여주기
                        }
                        else if(_seed.Length > 0 && _cond1.Length > 0)
                        {
                            //텍스트박스 입력 값이 있고 보조조건이 선택되어 있을 때
                           _strQuery += string.Format(" WHERE sk_status = 0 and sk_itemsort = '{0}' and sk_itemname like '%{1}%'",_cond1, _seed);
                            //삭제됐고 검색한 상품을 보여주기
                        }
                        else if(_seed.Length == 0 && _cond1.Length >0) {
             
                            //텍스트 박스 입력 값이 없고 보조조건은 선택이 됐을때
                        _strQuery += string.Format(" WHERE sk_status =0 and sk_itemsort ='{0}'", _cond1);                            
                            //삭제됐고 보조조건 품목으로만 보여주기
                        }
                
                        
                    }
                }               
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "stock");               
            }

            return _dt;
        }
```
* DBManger.cs에 Oracle DB에서 수행할 SQL문을 작성해 준다. 이는 OracleManager.cs라는 파일과 같이 연동하여 데이터를 조회 할 수 있게 도와준다.
* 데이터 삭제는 게으른 삭제(lazy deletion)방식으로 진행
<br>
<br>

## 상품 등록과 수정
![](https://github.com/gitcat87/StockManager/blob/main/images/capture2.png?raw=true)
![](https://github.com/gitcat87/StockManager/blob/main/images/capture3.png?raw=true)

```C#
//stockview.cs
       private void button1_Click(object sender, EventArgs e)
        {
            StockPop _pop = new StockPop();
            _pop.ShowDialog(ePopMode.add, null);
        }

```
<br>

```C#
//stockpop.cs
public override DialogResult ShowDialog(ePopMode aMode, object aParam)
{
    Initialize(aMode, aParam);
    return base.ShowDialog(aMode, aParam);
}

private void Initialize(ePopMode aPopMode, object aParam)
        {
            if (aPopMode == ePopMode.add){

                this.Text = "상품 등록";
                tbox_code.ReadOnly = false;
            }
            else if(aPopMode == ePopMode.modify)
            {
          
                tbox_code.Enabled = false;
                this.Text = "재고 수정";
                if(aParam is DataRow)
                {
                    DataRow _dp_row =(DataRow)aParam;
                    tbox_code.Text = Convert.ToString(_dp_row["sk_itemcode"]);
                    tbox_sort.Text = Convert.ToString(_dp_row["sk_itemsort"]);
                    tbox_name.Text = Convert.ToString(_dp_row["sk_itemname"]);
                    tbox_Quan.Text = Convert.ToString(_dp_row["sk_itemquan"]);
                    tbox_RecoQuan.Text = Convert.ToString(_dp_row["sk_itemrecoquan"]);
                    tbox_price.Text = Convert.ToString(_dp_row["sk_itemprice"]);
                    _m_itempicture = Convert.ToString(_dp_row["sk_picture"]);

                    DisplayControls();

                    if (_dp_row["sk_itemrecentin"] == DBNull.Value)
                    {
                        
                    } else
                    {
                        date_ItemIN.Value = Convert.ToDateTime(_dp_row["sk_itemrecentin"]);
                    }
                    if (_dp_row["sk_itemrecentout"] == DBNull.Value)
                    {
                        
                    }
                    else
                    {
                        date_ItemOut.Value = Convert.ToDateTime(_dp_row["sk_itemrecentout"]);
                    }


                    if (Convert.IsDBNull(_dp_row["sk_itemrecentin"]))
                    {
                        date_ItemIN.Enabled =false;
                    }
                    else
                    {
                        date_ItemIN.Enabled=true;
                        date_ItemIN.Value = Convert.ToDateTime(_dp_row["sk_itemrecentin"]);
                    }


                    if (Convert.IsDBNull(_dp_row["sk_itemrecentout"]))
                    {
                        date_ItemOut.Enabled =false;
                        //tbox_out.Text = "출고 이력이 없음";
                    }
                    else
                    {
                        date_ItemOut.Enabled = true;
                        //tbox_out.Visible = false;
                        date_ItemOut.Value = Convert.ToDateTime(_dp_row["sk_itemrecentout"]);
                    }
                }

            }
        }
```

* 등록 또는 수정 버튼을 눌렀을 경우 stockpop.cs가 출력되며 오버라이딩을 통해 하나의 두개의 pop창을 만들지 않고 하나만 사용한다.
* DBmanger.cs를 통해 값을 읽어오고 수정/저장이 가능하다.

<br>
<br>


## 입출고 조회



![](https://github.com/gitcat87/StockManager/blob/main/images/capture4.png?raw=true)
![](https://github.com/gitcat87/StockManager/blob/main/images/capture14.png?raw=true)
<p class="p1">(예시)출고 화면</p>
<style type="text/css">
    [class*="p1"]{margin-left:45%; color:gray}
</style>


#
```C#
//outitemsview.cs
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
```
<br>
<br>

```C#
//DBmanger.cs
 public DataTable ReadOutDetail(int _cond)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null)
            {
                return _dt;
            }
            else
            {
                string _strQuery = "SELECT outd_ucode, outd_quan, outd_price, out_ucode, sk_ucode, sk_itemname ";
                _strQuery += "FROM cdh_out_detail";

                if( _cond > 0 )
                {
                    _strQuery += string.Format(" Where out_ucode = {0}", _cond);
                }
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "item_outdetail");
            }

            return _dt;
        }

```
<br>

```C#
       public int ReadSeq(string aSeqName) {
            int _result = -1;
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                return _result;
            }
            else
            {
                //쿼리문 만들기
                string _strQuery = string.Format("SELECT  {0}.nextval FROM DUAL ",aSeqName);   
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "contact");
                if(_dt != null && _dt.Rows.Count>0)
                {
                    _result = Convert.ToInt32(_dt.Rows[0][0]);  
                    //_strQuery에는 결국 "Select (참조할 시퀸스 이름).nextval From Dual"의
                    //첫번째 줄 첫번째 행의 값을 불러오는 것이다.
                    //실행할 때마다 returnd 에144.. 145... 146... 147...이 담기게 될 것
                    
                }
            }
            return _result;
        }
```
* 셀을 이동시에 실행되는 이벤트 함수를 부여하고 왼쪽의 gridview 선택한 row값들을 읽어온다.(CDH_OUT)
* 읽어온 row의 값의 출고번호를 바탕으로 오른쪽 gridview에 출력한다(CDH_OUTDETAIL)
* 출고 번호는 Oracle DB의 Sequence기능을 이용하여 자동으로 1씩 증가하는 숫자를 생성해 받아오도록 하였다.
* 입고도 같은 방식으로 진행한다.

<br>
<br>

## 입출고 등록


![](https://github.com/gitcat87/StockManager/blob/main/images/capture5.png?raw=true)

#

```C#
//outitemsview.cs
       private void button2_Click(object sender, EventArgs e)
        {
            ItemOutPop _pop = new ItemOutPop();
            DialogResult _dresult = _pop.ShowDialog(ePopMode.add,null);
            if(_dresult == DialogResult.OK)
            {
                DoSearch();
            }
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

```

* 등록을 클릭하면 출고를 담당하는 outitemspop.cs를 출력한다. 등록을 완료 하면 Dosearch 함수 실행으로 목록을 갱신한다.

<br>
<br>

```C#
//itemoutpop.cs

 
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
```



* ItemPop.cs창이 열리고 추가 버튼을 누르게 되면 itemSearchPop을 띄우게 된다.

<br>
<br>

#

![](https://github.com/gitcat87/StockManager/blob/main/images/capture15.png?raw=true)

#

```C#
//ItemPop.cs
private void btn_search_Click(object sender, EventArgs e)
        {
            int _cond = cbox_MainCon.SelectedIndex;
            string _cond1 = cbox_SubCon.Text;
            string _seed = tbox_seed.Text;

            DataTable _db_table = App.Instance().DBManager.ReadStock(_cond, _cond1, _seed);

            DataTable _dp_table = DisplaySet.Tables["dp_table"];
            _dp_table.Rows.Clear();

            foreach (DataRow _db_row in _db_table.Rows)
            {

                DataRow _dp_row = _dp_table.NewRow();

                _dp_row["sk_itemcode"] = _db_row["sk_itemcode"];
                _dp_row["sk_itemsort"] = _db_row["sk_itemsort"];
                _dp_row["sk_itemname"] = _db_row["sk_itemname"];
                _dp_row["sk_itemquan"] = _db_row["sk_itemquan"];
                _dp_row["sk_itemprice"] = _db_row["sk_itemprice"];


                _dp_table.Rows.Add(_dp_row);
            }

            }

        private void grid_ItemSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoAdd();
        }

         private void DoAdd()
        {
            DataRow _selected_row = GridManager.SelectedRow(grid_ItemSearch);
            if (_selected_row != null)
            {
                if (OnAddItem != null)
                {
                    ItemQuanPop _pop = new ItemQuanPop();
                    if (_pop.ShowDialog() == DialogResult.OK)
                    {
                        this.OnAddItem(_selected_row, _pop.Quan);
                    }
                }
            }
        } 

```
* 조회는 StockView.cs와 같지만 row를 더블 클릭 하면 추가로 ItemQuanPop.cs 창이 열리고 수량을 기입 할 수 있게 된다.

<br>
<br>


#

![](https://github.com/gitcat87/StockManager/blob/main/images/capture6.png?raw=true)

#

```C#
//ItemOutPop.cs
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
```
* 확인을 누르면 빈칸이 있는지 유효성 검사를 진행 후 저장하게 된다. 

<br>
<br>

#

![](https://github.com/gitcat87/StockManager/blob/main/images/capture8.png?raw=true)
![](https://github.com/gitcat87/StockManager/blob/main/images/capture9.png?raw=true)
![](https://github.com/gitcat87/StockManager/blob/main/images/capture16.png?raw=true)


#

```C#
//OutItemsView.cs
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
```

<br>
<br>

```C#
//DBmanager.cs
       public int ModifyOutItemStatus(int _out_status, int _out_ucode)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                //쿼리문 만들기

                string _strQuery = "Update cdh_out Set ";
                _strQuery += string.Format("out_status = 1 ");
                _strQuery += string.Format("where out_ucode = {0}", _out_ucode);


                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }


       public int ModifyStockQuanMINUS(int _sk_ucode, int _outd_quan)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if( _Connection == null)
            {
                _code = -999;
            }
            else
            {
                //쿼리문 만들기
                string _strQuery = "UPDATE cdh_stock SET ";
                _strQuery += string.Format("sk_itemquan = sk_itemquan - {0} ", _outd_quan);
                _strQuery += string.Format("WHERE sk_itemcode = {0}", _sk_ucode);

                _code = m_OracleManager.ExcuteQuery( _strQuery);
            }
            return _code;
        }

```

* 출고 완료된 항목은 삭제하지 못하게 하고 또한 재고에 반영되도록 작성 하였다.
* 입고도 같은 방식으로 진행된다.

## 거래처 관리
#

![](https://github.com/gitcat87/StockManager/blob/main/images/capture11.png?raw=true)
![](https://github.com/gitcat87/StockManager/blob/main/images/capture12.png?raw=true)


#

```C#

//ContactView.cs
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

              private void btn_search_Click(object sender, EventArgs e)
        { 
            DoSearch();
        }

```

<br>

```C#
//DBmanager.cs
public DataTable ReadContact( int _cond,string _seed)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                return _dt;
            }
            else
            {
                //쿼리문 만들기

                string _strQuery = "SELECT ct_ucode, ct_name, ct_rep, ct_bnumber, ct_email, ";
                _strQuery += "ct_tel,ct_fax, ct_manger, ct_mangertel, ct_memo ";
                _strQuery += "FROM cdh_contact ";

                if (_seed.Length > 0) {
                    if (_cond == 0) {
                        //전체
                        _strQuery += string.Format(" WHERE ct_name like '%{0}%' or ct_manger like '%{0}%' or ct_tel like '%{0}%'  ", _seed, _seed, _seed);
                    } else if (_cond == 1) {//업체명
                        _strQuery += string.Format(" WHERE ct_name like '%{0}%' ", _seed);
                    } else if (_cond == 2)
                    {//담당자명
                        _strQuery += string.Format(" WHERE ct_manger like '%{0}%' ", _seed);
                    } else if (_cond == 3)
                    {//전화번호
                        _strQuery += string.Format(" WHERE ct_tel like '%{0}%' ", _seed);
                    }
                }
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "contact");
            }
            return _dt;
        }
```

* DB에 저장된 거래처 정보를 읽어오거나 등록/수정을 할 수 있다.
