using StockManagement.Windows.View;
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
using Lib.Manager;

namespace StockManagement
{

    public enum eViewMode
    {
        Stock = 0,
        ItemIn = 1,
        ItemOut = 2,
        Contact = 3,
    }
    public partial class MainForm : Form
    {
        private DBManager m_DBManager = null;
        private DocManager m_DocManager = null;


        private StockView m_StockView = null;
        private InItemsView m_InitemsView = null;
        private OutItemsView m_OutIemsView = null;
        private ContactView m_ContactView = null;

        public MainForm()
        {
            CreateObject();
            InitializeComponent();
            InitializeObject();
            ShowView(eViewMode.Stock);

        }

        private void CreateObject()
        {
            m_StockView = new StockView();
            m_InitemsView = new InItemsView();
            m_OutIemsView = new OutItemsView();
            m_ContactView = new ContactView();

            m_DocManager = new DocManager();
            m_DBManager = new DBManager();
        }

        private void InitializeObject()
        {
            m_StockView.Parent = WorkZonePanel;
            m_StockView.Dock = DockStyle.Fill;

            m_InitemsView.Parent = WorkZonePanel;
            m_InitemsView.Dock = DockStyle.Fill;

            m_OutIemsView.Parent = WorkZonePanel;
            m_OutIemsView.Dock = DockStyle.Fill;

            m_ContactView.Parent = WorkZonePanel;
            m_ContactView.Dock = DockStyle.Fill;

            DBInfo _db = m_DocManager.ReadDBInfo();
            m_DBManager.SetConnectInfo(_db._Addr, _db._Port, _db._Id, _db._Pwd, _db._DataBase);

            App.Instance().DocManager = m_DocManager;
            App.Instance().DBManager = m_DBManager;

        }

        private void ShowView(eViewMode aMode)
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
        private void Doexit()
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.Stock);
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.ItemIn);
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.ItemOut);
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.Contact);
        }

        private void 환경설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectSettingPop _pop = new ConnectSettingPop();
            _pop.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ConnectSettingPop _pop = new ConnectSettingPop();
            _pop.ShowDialog();
        }

        private void 재고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.Stock); 
        }

        private void 입고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.ItemIn);
        }

        private void 출고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.ItemOut);
        }

        private void 거래처ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowView(eViewMode.Contact);
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doexit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
