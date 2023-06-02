using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace Lib.Manager
{
    class DBManager
    {
        private OracleManager m_OracleManager;

        public void SetConnectInfo(string aAddr, int aPort, string aId, string aPwd, string aDataBase)
        {
            m_OracleManager = new OracleManager(aAddr, aPort, aId, aPwd, aDataBase);
        }

        //4000자 이상 문자열 ToClob으로 처리하기
        public string MakeToClobQuery(string aSrc) {
            return MakeToClobQuery(aSrc, 4000);
        }
        public string MakeToClobQuery(string aSrc, int aBlock) {
            string _result = "";
            if (aSrc == null) {
                _result = "''";
            } else { 
                int _len = aSrc.Length;
                int _count = (_len + 1) / aBlock;
                for(int _idx = 0; _idx< _count; _idx++)
                {
                    if(_result.Length > 0) { _result += "||"; }
                    int _start = _idx * aBlock;
                    int _size = _len - _start;
                    if(_size> aBlock) {  _size = aBlock;}
                    _result += string.Format(" TO_CLOB('{0}') "
                        , aSrc.Substring(_start, _size));

                }
            }
            return _result;                             
        }

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
        
        public int AddContract(string _name,string _rep,string _regnum,string _email,string _fax,string _tel,string _manager,string _manager_tel, string _memo)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                //회원수정 쿼리문 만들기

                string _strQuery = "INSERT INTO cdh_contact( ";
                _strQuery += "ct_ucode, ct_name, ct_rep, ct_bnumber, ";
                _strQuery += "ct_email, ct_tel, ct_fax, ct_manger, ";
                _strQuery += "ct_mangertel, ct_memo)  ";
                _strQuery += string.Format("VALUES(SEQ_CONTACTOR.nextval, '{0}', '{1}', '{2}','{3}', '{4}', '{5}', '{6}','{7}', '{8}') "
                    , _name, _rep, _regnum, _email, _tel, _fax, _manager, _manager_tel, _memo );
                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }
        //출고 추가
        public int AddOut(int _out_ucode, string _out_date, string _out_to, string _out_place, int _out_totalprice)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection(); //새로 만든연결
            if(_Connection == null)
            {
                _code = -999;
            }
            else
            {
                string _strQuery = "INSERT INTO cdh_out(out_ucode, out_date, out_to, out_place, out_price, out_status) ";
                _strQuery += string.Format("VALUES({0}, '{1}', '{2}', '{3}', {4}, 0 ) ",
                                            _out_ucode, _out_date, _out_to, _out_place, _out_totalprice);

                _code = m_OracleManager.ExcuteQuery( _strQuery);
            }

            return _code;
        }

        public int ModifyOut(int _out_ucode, string _out_date, string _out_to, string _out_place, int _out_totalprice)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null)
            {
                _code = -999;
            }
            else
            {
                string _strQuery3 = "UPDATE cdh_out SET ";
                _strQuery3 += string.Format("out_date ='{0}', ", _out_date);
                _strQuery3 += string.Format("out_to ='{0}', ", _out_to);
                _strQuery3 += string.Format("out_place ='{0}', ", _out_place);
                _strQuery3 += string.Format("out_price ={0} ", _out_totalprice);
                _strQuery3 += string.Format("where out_ucode = {0}", _out_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery3);
            }
            return _code;
        }

        //입고수정
        public int ModifyIn(int _in_ucode, string _in_from, string _in_date, int _in_price) //받아오는 값으로는 입고번호, 거래처, 날짜, 가격
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection(); // 새로 만든 연결에서 어떠한 문제가 생기면 종료될 것임
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {

                string _strQuery3 = "UPDATE cdh_in SET ";
                _strQuery3 += string.Format("in_date = '{0}', ",_in_date);
                _strQuery3 += string.Format("in_from = '{0}', ",_in_from);
                _strQuery3 += string.Format("in_price = {0} ",_in_price);
                _strQuery3 += string.Format(" where in_ucode = {0} ",_in_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery3); //_strQuery가 성공적으로 실행되었으면 DB내용이 쿼리문을 통해 바뀌었을것이고
            }                                                   //excuteQuery()는 return값으로 1또는 -1을 배출함으로써 _code는 실패 또는 성공을 알려주는 값

            return _code;
        }
        //입고 추가
        public int AddIn(int _in_ucode,string _in_from,string _in_date,int _in_price) //받아오는 값으로는 입고번호, 거래처, 날짜, 가격
        {
            int _code = 0; 
            DbConnection _Connection = m_OracleManager.NewConnection(); // 새로 만든 연결에서 어떠한 문제가 생기면 종료될 것임
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                

                string _strQuery = "INSERT INTO cdh_in(in_ucode, in_date, in_from, in_price, in_status) "; //오라클디벨로퍼의 cdh_in테이블에 다음의 값을 넣는다

                _strQuery += string.Format("VALUES({0},'{1}','{2}',{3} , 0) " /*c# item_in_pop.cs에서 얻은 값들*/
                    , _in_ucode,_in_date, _in_from,  _in_price); //_in_ucode는 시퀸스에서 얻은 값, 나머지는 텍스트 박스에서 얻은 값

                _code = m_OracleManager.ExcuteQuery(_strQuery); //_strQuery가 성공적으로 실행되었으면 DB내용이 쿼리문을 통해 바뀌었을것이고
            }                                                   //excuteQuery()는 return값으로 1또는 -1을 배출함으로써 _code는 실패 또는 성공을 알려주는 값

            return _code;
        }

        public int StockViewLazyDelete(int _sk_itemcode, int _sk_status)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection (); 
            if(_Connection == null)
            {
                _code = -999;
            }
    
            else
            {
                //쿼리문 만들기
                string _strQuery = "Update cdh_stock SET ";
                
                if(_sk_status == 1)
                {
                    _strQuery += "sk_status = 0 ";
                    _strQuery += string.Format("where sk_itemcode = {0}", _sk_itemcode);

                }
                else if(_sk_status == 0)
                {
                    _strQuery += "sk_status = 1";
                    _strQuery += string.Format("where sk_itemcode = {0}", _sk_itemcode);
                }

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        public int DeleteOutDetail(int _out_ucode)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if( _Connection == null)
            {
                _code = -999;
            }
            else
            {
                string _strQuery = "DELETE FROM cdh_out_detail ";
                _strQuery += string.Format("Where out_ucode = {0}", _out_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }


        public int DeleteInDetail(int _in_ucode) {

            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                // 쿼리문 만들기
                string _strQuery = "DELETE FROM cdh_in_detail ";
                _strQuery += string.Format("WHERE in_ucode = {0}", _in_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        public int DeletedOutItem(int _out_ucode)
        {
            int _code = 0;
            DbConnection _Connection =m_OracleManager.NewConnection();
            if(_Connection == null)
            {
                _code = -999;
            }
            else
            {
                //쿼리문
                string _strQuery = "DELETE FROM cdh_out ";
                _strQuery += string.Format("Where out_ucode = {0}", _out_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        public int DeleteInItem(int _in_ucode)
        {
            int _code = 0;
            DbConnection _Conncetion = m_OracleManager.NewConnection();
            if(_Conncetion == null)
            {
                _code = -999;
            }
            else
            {
                //쿼리문
                string _strQuery = "DELETE FROM cdh_in ";
                _strQuery += string.Format("Where in_ucode = {0}", _in_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        
        //출고 상세
        public int AddOutDetail(int _out_ucode, DataRow _dp_row) {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null)
            {
                _code = -999;
            }
            else
            {
                //상세 입력 쿼리문 만들기

                string _strQuery = "INSERT INTO cdh_out_detail(outd_ucode, outd_quan , out_ucode, sk_ucode, sk_itemname, outd_price) ";
                _strQuery += string.Format("Values(seq_out_detail.nextval, {0}, {1}, {2}, '{3}', {4})"
                    , _dp_row["outd_quan"], _out_ucode
                    , _dp_row["sk_ucode"], _dp_row["sk_itemname"]
                    , _dp_row["outd_price"]);


                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }
            return _code;
        }
        public int AddInDetail(int _in_ucode, DataRow _dp_row) {

            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
              
                string _strQuery = "INSERT INTO cdh_in_detail(ind_ucode, ind_quan, in_ucode,sk_ucode, sk_itemname, ind_price) ";
                _strQuery += string.Format("VALUES(seq_in_detail.nextval, {0}, {1},{2},'{3}',{4}) "
                    , _dp_row["ind_quan"], _in_ucode
                    , _dp_row["sk_ucode"], _dp_row["sk_itemname"]
                    , _dp_row["ind_price"]);

                _code = m_OracleManager.ExcuteQuery(_strQuery);


            }




            return _code;
        }
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

        public DataTable ReadInDetail(int _cond)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                return _dt;
            }
            else
            {
                string _strQuery = "SELECT ind_ucode, ind_quan, ind_price, in_ucode ,sk_ucode , sk_itemname ";
                _strQuery += "FROM cdh_in_detail";

                if(_cond > 0)
                {
                    _strQuery += string.Format(" Where in_ucode = {0}", _cond);
                }
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "item_indetail");                
            }

            return _dt;
        }

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

        public int ModifyInItemStatus(int _in_status, int _in_ucode)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null)
            {
                _code = -999;
            }
            else
            {
                //쿼리문 만들기
                
                    string _strQuery = "Update cdh_in Set ";
                    _strQuery += string.Format("in_status = 1 ");
                    _strQuery += string.Format("where in_ucode = {0}", _in_ucode);
          

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


        public int ModifyStockQuanADD(int _sk_ucode,int _ind_quan)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                // 쿼리문 만들기
                string _strQuery = "UPDATE cdh_stock SET ";
                _strQuery += string.Format("sk_itemquan = sk_itemquan + {0} ", _ind_quan);
                _strQuery += string.Format("WHERE sk_itemcode = {0}", _sk_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        public int ModifyContract(int _ucode, string _name, string _rep, string _regnum, string _email, string _fax, string _tel, string _manager, string _manager_tel, string _memo)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                // 쿼리문 만들기
                string _strQuery = "UPDATE cdh_contact SET ";
                _strQuery += string.Format("ct_name = '{0}', ", _name);
                _strQuery += string.Format("ct_rep  = '{0}', ", _rep);
                _strQuery += string.Format("ct_bnumber  = '{0}', ", _regnum);
                _strQuery += string.Format("ct_email = '{0}', ", _email);
                _strQuery += string.Format("ct_tel  = '{0}', ", _tel);
                _strQuery += string.Format("ct_fax  = '{0}', ", _fax);
                _strQuery += string.Format("ct_manger  = '{0}', ", _manager);
                _strQuery += string.Format("ct_mangertel  = '{0}', ", _manager_tel);
                _strQuery += string.Format("ct_memo  = '{0}' ", _memo);
                _strQuery += string.Format("WHERE ct_ucode = {0}", _ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        public int DeleteContactor(int _ucode)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                _code = -999;
            }
            else
            {
                // 쿼리문 만들기
                string _strQuery = "DELETE FROM cdh_contact ";
                _strQuery += string.Format("WHERE ct_ucode = {0}", _ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);
            }

            return _code;
        }

        public DataTable ReadOutItems(int _cond,  string _seed)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                return _dt;
            }
            else
            {
                string _strQuery = "SELECT out_ucode, out_date, out_to, out_place, out_items, out_price, out_status ";
                _strQuery += "FROM cdh_out";

                if(_seed.Length >= 0)
                {
                    if(_cond == 0) 
                    {
                        if (_seed.Length > 0)
                        {
                            _strQuery += string.Format(" WHERE out_to like '%{1}%'", _cond, _seed);
                        }                        
                        else
                        {
                            _strQuery += string.Format("");
                        }
                    }
                    else if (_cond == 1) 
                    {
                        if (_seed.Length > 0)
                        {   
                            //진행중이면서 이름으로 검색
                            _strQuery += string.Format(" WHERE out_status = 0 and out_to like '%{1}%'", _cond, _seed);
                        }
                        else { 
                        //out_status = 0 은 진행중
                        _strQuery += string.Format(" WHERE out_status = 0 ");
                        }

                    }
                    else if (_cond == 2) 
                    {
                        if (_seed.Length > 0)
                        {
                            //완료면서 이름으로 검색
                            _strQuery += string.Format(" WHERE out_status = 1 and out_to like '%{1}%'", _cond, _seed);
                        }
                        else
                        { 
                        //out_status = 1은 완료
                        _strQuery += string.Format(" WHERE out_status = 1 ");
                        }

                    }
                    else if (_cond == 3) 
                    {
                        if (_seed.Length > 0)
                        {
                            //취소면서 이름으로 검색
                            _strQuery += string.Format(" WHERE out_status = 2 and out_to like '%{1}%'", _cond, _seed);
                        }
                        else
                        {
                        //out_status =2는 삭제된 데이터
                        _strQuery += string.Format(" WHERE out_status = 2 ");
                        }

                    }


                }
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "stock");
            }
            

            return _dt;
        }

        public DataTable ReadInItems(int _cond, int _cond1, string _seed)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if (_Connection == null)
            {
                return _dt;
            }
            else
            { 
                string _strQuery = "SELECT in_ucode, in_date, in_from, in_items, in_price, in_status ";
                _strQuery += "FROM cdh_in";

                if (_seed.Length >= 0)
                {
                    if (_cond == 0) 
                    {
                        if (_cond1 == 0)//거래처명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_from like '%{0}%'", _seed);
                        }
                        else if (_cond1 == 1)
                        {
                            _strQuery += string.Format(" WHERE in_items like '%{0}%'", _seed);
                        }
                        else
                        { 
                        _strQuery += "";
                        }
                    }
                    else if(_cond == 1) //진행중이면서
                    {   
                        if(_cond1 == 0)//거래처명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_status =0 and in_from like  '%{0}%'", _seed);
                        }
                        else if(_cond1 == 1)//상품명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_status =0 and in_items like '%{0}%'", _seed);
                        }
                        else 
                        { 
                        _strQuery += string.Format(" WHERE in_status =0");
                        }
                    }
                    else if (_cond == 2) //입고완료면서
                    {   
                        if(_cond1 == 0)//거래처명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_status =1 and in_from like  '%{0}%'", _seed);
                        }
                        else if (_cond1 == 1)//상품명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_status =1 and in_items like '%{0}%'", _seed);
                        }
                        else 
                        { 
                        _strQuery += string.Format(" Where in_status =1");
                        }
                    }
                    else if (_cond == 3) //입고취소면서
                    {
                        if (_cond1 == 0)//거래처명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_status =2 and in_from like '%{0}%'", _seed);
                        }
                        else if (_cond1 == 1)//상품명을 선택했을 때
                        {
                            _strQuery += string.Format(" WHERE in_status =2 and in_items like '%{0}%'", _seed);
                        }
                        else 
                        { 
                        _strQuery += string.Format(" Where in_status =2");
                        }
                    }

                }
                _dt = m_OracleManager.SelectQuery(_Connection, _strQuery, "stock");
            }

            return _dt;
        }


        public int AddItem(string _goods_code,string _goods_sort,string _goods_name,
            int _quan, int _reco_quan,int _price, string _date_ItemIN,string _date_ItemOut,string _goods_picture)
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
                string _strQuery = "INSERT INTO cdh_stock ";
                string _fieldQuery = " ";
                string _valueQuery = " ";
                _fieldQuery += "sk_ucode, ";
                _valueQuery += "seq_stock.nextval, ";

                _fieldQuery += "sk_itemcode, ";
                _valueQuery += string.Format("'{0}', ", _goods_code);
                _fieldQuery += "sk_itemsort, ";
                _valueQuery += string.Format("'{0}', ", _goods_sort);
                _fieldQuery += "sk_itemname,";
                _valueQuery += string.Format("'{0}', ", _goods_name);
                _fieldQuery += "sk_itemquan,";
                _valueQuery += string.Format("{0}, ", _quan);

                _fieldQuery += "sk_itemrecoquan,";
                _valueQuery += string.Format("{0}, ", _reco_quan);

                /////////
                if (_date_ItemIN.Length > 0)
                {
                    _fieldQuery += "sk_itemrecentin, ";
                    _valueQuery += string.Format("TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS'), ", _date_ItemIN);
                }
                if (_date_ItemOut.Length > 0)
                {
                    _fieldQuery += "sk_itemrecentout,";
                    _valueQuery += string.Format("TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS'), ", _date_ItemOut);
                }
                ///////////
                _fieldQuery += "sk_itemprice,";
                _valueQuery += string.Format("{0},", _price);

                if (_goods_picture != null && _goods_picture.Length > 0)
                {
                    _goods_picture = MakeToClobQuery(_goods_picture);
                    _fieldQuery += "sk_picture,";
                    _valueQuery += string.Format("{0},", _goods_picture);
                }

                _fieldQuery += "sk_status";
                _valueQuery += "1";

                _strQuery = _strQuery +"("+ _fieldQuery + ") VALUES ("+ _valueQuery + ")";

                try
                {
                    _code = m_OracleManager.ExcuteQuery(_strQuery);
                }
                catch (DbException ex)
                {
                    // 쿼리 실행 도중 오류가 발생한 경우 이곳으로 예외가 전달됩니다.
                    Console.WriteLine("오류 발생: " + ex.Message);
                    _code = -1;
                }
            }
            return _code;
        }

        public int ModifyItem(int _goodsCode, string _goodsSort,
                                int _goodsPrice, string _goodsName,
                                int _goodsQuan, int _goodsRecoQuan, string _inDate, string _outDate,
                                string _goods_picture)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null) 
            {
                _code = -999;
            }
            else 
            {
                //쿼리문 만들기

                string _StrQuery = "UPDATE cdh_stock SET ";
                _StrQuery += string.Format("sk_itemsort = '{0}', ", _goodsSort);
                _StrQuery += string.Format("sk_itemname = '{0}', ", _goodsName);
                _StrQuery += string.Format("sk_itemquan = {0}, ", _goodsQuan);
                _StrQuery += string.Format("sk_itemrecoquan = {0}, ", _goodsRecoQuan);        
                _StrQuery += string.Format("sk_itemprice ={0} ", _goodsPrice);

                if(_inDate.Length > 0) 
                {
                    _StrQuery += string.Format(", sk_itemrecentin = TO_DATE('{0}' , 'YYYY-MM-DD HH24:MI:SS'), )", _inDate);
                }
                if (_outDate.Length > 0)
                {
                    _StrQuery += string.Format(", sk_itemrecentout = TO_DATE('{0}' , 'YYYY-MM-DD HH24:MI:SS'), )", _outDate);
                }

                if(_goods_picture !=null && _goods_picture.Length > 0) 
                {
                    _goods_picture = MakeToClobQuery(_goods_picture);
                    _StrQuery += string.Format(", sk_picture = {0}", _goods_picture);
                }

                _StrQuery += string.Format("WHERE sk_itemcode = {0}", _goodsCode);

                try
                {
                    _code = m_OracleManager.ExcuteQuery(_StrQuery);
                }
                catch ( DbException ex)
                {   
                    //오류 발생시 이쪽으로
                    MessageBox.Show("수정중 오류가 발생" + ex.Message);
                }


            }


            return _code;
        }


        //아래는 참조만 할 뿐 사용하지 않는다.----------------------
        public int ModifyMember(int _mbr_ucode, string _mbr_name, string _mbr_sex
                                , string _mbr_tel, string _mbr_birthday
                                , string _mbr_regdate, string _mbr_picture)
        {
            int _code = 0;
            DbConnection _Connection = m_OracleManager.NewConnection();
            if(_Connection == null) {
                _code = -999;
            } else
            {
                //회원수정 쿼리문 만들기

                string _strQuery = "UPDATE kb_member SET ";
                _strQuery += string.Format("mbr_name = '{0}', ",_mbr_name);
                _strQuery += string.Format("mbr_sex  = '{0}', ",_mbr_sex);
                _strQuery += string.Format("mbr_tel  = '{0}', ",_mbr_tel);
                _strQuery += string.Format("mbr_birthday = '{0}', ",_mbr_birthday);
                _strQuery += string.Format("mbr_regdate  = '{0}', ",_mbr_regdate);
                _strQuery += string.Format("mbr_picture  = {0}  ",_mbr_picture);

                _strQuery += string.Format("WHERE mbr_ucode = {0}", _mbr_ucode);

                _code = m_OracleManager.ExcuteQuery(_strQuery);   
            }

            return _code;
        }




    }
}
