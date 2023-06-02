using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Lib.Manager
{
    class OracleManager
    {
        private String m_connectString = "";
        protected OracleConnection m_sqlConnection = null;
        public OracleManager() {
            m_connectString = "";        
        }

        public OracleManager(String aHost, int aPort, string aID, string aPWD ,string aDatabase) {
            m_connectString = string.Format(@"Data Source={0}:{1}/{2};User ID={3};Password={4}", aHost, aPort, aDatabase, aID, aPWD);
            m_sqlConnection = new OracleConnection(m_connectString);

        }
        public String MakeConnectString(string aHost, int aPort, string aID, string aPWD, string aDatabase)
        {
            if (aPort < 0){
                aPort = 1521;
            }

            m_connectString = String.Format(@"Data Source={0}:{1}/{2};User ID={3};Password={4}", aHost, aPort, aDatabase, aID, aPWD);

            //string sql = "Data Source=127.0.0.1:1521/xe;User ID=hr;Password=hr";
            return m_connectString;
        }

        public bool TestConnection()
        {
            bool _success = false;
            try { 
                m_sqlConnection.Open();
                _success = true;
                m_sqlConnection.Close();
            } catch { _success = false; }

            return _success;
        }

        public DbConnection NewConnection() {

            OracleConnection _connection = null;

            try {
                _connection = GetNewConnection();
                _connection.Open();
                _connection.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } finally { 
                if( _connection != null){
                    _connection.Close();
                }            
            }

            return _connection as DbConnection; 
        }

        public OracleConnection GetNewConnection()
        {
            return new OracleConnection(m_connectString);
        }

        public DataTable SelectQuery(DbConnection _db_connection,
            string aQuery, string TableName)
        {
            OracleConnection connection = _db_connection as OracleConnection;

            DataTable _DataTable = new DataTable();
            try { 
                if(connection == null)
                {
                    connection = GetNewConnection();
                }
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                OracleDataAdapter _SqlAdapter 
                    = new OracleDataAdapter(aQuery, connection);

                int _count = _SqlAdapter.Fill(_DataTable);
            } catch (OracleException ex) {
                Console.WriteLine(ex.Message);  
            
            } finally { 
                connection.Close();            
            }

            try {
                if (TableName.Length > 0)
                {
                    _DataTable.TableName = TableName;
                }
                else { }
            } catch { }
            return _DataTable; 
        }

        public int ExcuteQuery( string aQuery) //쿼리문 실행 함수
        {
            int _count = 1; //이 함수가 제대로 수행 됐는지 아닌지
            OracleConnection _connection = GetNewConnection();
            _connection.Open();
            OracleTransaction _trans = _connection.BeginTransaction(); //정보 전송
            try { 
                OracleCommand _cmd = new OracleCommand(); //그냥 cmd창이라고 생각하면 될듯
                _cmd.Connection  = _connection; //오라클 DB연결
                _cmd.Transaction = _trans; //오라클 DB 이동관련
                _cmd.CommandText = aQuery; //실행할 쿼리문
                _cmd.ExecuteNonQuery(); //쿼리에 영향을 받은 행 숫자(성공적으로 쿼리문 실행한 것들)
                _trans.Commit();            
            } catch(Exception ex) {
                Console.WriteLine(ex.Message); //에러가 떴을때
                _trans.Rollback(); //실행전으로 되돌리기
                _count = -1; 
            } finally { 
                _connection.Close();    
            }

            return _count; //만약 try를 거쳤으면 정상수행으로 판단 catch로 갔으면  -1을 뱉으며 실행중지
        }


    }
}
