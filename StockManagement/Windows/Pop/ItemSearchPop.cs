using Lib.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagement.Windows.View;
using Lib.Frame;


namespace StockManagement.Windows.Pop
{
    public partial class ItemSearchPop : MasterPop
    {
        public Action<DataRow, int> OnAddItem = null;
        public ItemSearchPop()
        {
            InitializeComponent();
            panel3.Visible = false;
            cbox_MainCon.SelectedIndex = 0;
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
                //label_title.Text = "메뉴 추가";
                //cbox_category.SelectedIndex = 0;
                //tbox_name.Text = "새상품";
                //tbox_price.Text = "0";
                //tbox_description.Text = "";

            }
            else if (aPopMode == ePopMode.modify)
            {

                //label_title.Text = "메뉴 수정";
                //if (aParam is DataRow)
                //{
                //    DataRow _dp_row = (DataRow)aParam;

                //    m_goods_number = Convert.ToInt32(_dp_row["goods_number"]);
                //    if (_dp_row["ctr_typenumber"] != System.DBNull.Value)
                //    {
                //        cbox_category.SelectedIndex = Convert.ToInt32(_dp_row["ctr_typenumber"]) - 1;

                //    }
                //    else
                //    {

                //        cbox_category.SelectedIndex = 0;
                //    }

                //    tbox_name.Text = Convert.ToString(_dp_row["goods_name"]);// "새상품";
                //    tbox_price.Text = Convert.ToString(_dp_row["goods_price"]);
                //    tbox_description.Text = Convert.ToString(_dp_row["goods_description"]);

                //    string _goods_picture = Convert.ToString(_dp_row["goods_picture"]);
                //    if (_goods_picture.Length > 0)
                //    {
                //        byte[] _byte = HexStringToByteArray(_goods_picture);
                //        pbox_goods.Image = new Bitmap(new MemoryStream(_byte));
                //        pbox_goods.Tag = _goods_picture;

                //    }

                //}

            } else if(aPopMode == ePopMode.none)
            {
               //
            }

        }

        private void ShowSubCon()
        {
            if (cbox_MainCon.SelectedIndex == 1)
            {
                cbox_SubCon.SelectedIndex = 0;
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
                cbox_SubCon.SelectedIndex = -1;
            }

        }

        private void ItemBack()
        {
            if (cbox_MainCon.SelectedIndex == 2)
            {
                panel8.Visible = true;
            }
            else { panel8.Visible = false; }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

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

        private void cbox_MainCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSubCon();
  
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            DoAdd();
        }

        private void grid_ItemSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
