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
using System.IO;
using System.Web;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace StockManagement.Windows.Pop
{
    public partial class StockPop : MasterPop
    {
        private string _m_itempicture = "";
        public StockPop()
        {
            InitializeComponent();
        }

        public override DialogResult ShowDialog(ePopMode aMode, object aParam)
        {
            Initialize(aMode, aParam);
            return base.ShowDialog(aMode, aParam);
        }

        private byte[] HexStringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            if (NumberChars % 2 == 0)
            {
                for (int i = 0; i < NumberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
            }
            return bytes;
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

        private void DisplayControls()
        {
            byte[] data = null;

            if (_m_itempicture.Length == 0) 
            {
                _m_itempicture = "사진이 없습니다";
            }
            else { 
            byte[] _byte = HexStringToByteArray(_m_itempicture);
            pbox_goods.Image = new Bitmap(new MemoryStream(_byte));
            pbox_goods.Tag = _m_itempicture;
            }
        }

        private void DoSave4Modify() 
        {

            string _code = tbox_code.Text;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            if (m_popMode == ePopMode.add)
            {
                Save4Add();
            }
            else if (m_popMode == ePopMode.modify)
            {
                Save4Modify();
            }

            //DialogResult= DialogResult.OK;
        }

        private void Save4Add()
        {
            string _goods_code = tbox_code.Text;
            string _goods_sort = tbox_sort.Text;
            string _goods_name = tbox_name.Text;
            int _quan = Convert.ToInt32(tbox_Quan.Text);
            int _reco_quan = Convert.ToInt32(tbox_RecoQuan.Text);
            int _price = Convert.ToInt32(tbox_price.Text);
            string _date_ItemIN = "";
            string _date_ItemOut = "";
            if (cbtn_in.Checked)
            {
                _date_ItemIN = date_ItemIN.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (cbtn_out.Checked)
            {
                _date_ItemOut = date_ItemOut.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            string _goods_picture = pbox_goods.Tag as string;

            //// 유효성 체크
            //if (_name.Trim().Length == 0)
            //{
            //    MessageBox.Show("상품명을 입력해주세요.");
            //    return;
            //}
            //if (_price <= 0)
            //{
            //    MessageBox.Show("상품 가격은 0보다 큰 값을 입력해주세요.");
            //    return;
            //}

            
            int _result = App.Instance().DBManager.AddItem(_goods_code, _goods_sort, _goods_name, _quan, _reco_quan, _price, _date_ItemIN, _date_ItemOut, _goods_picture);
            if (_result > 0)
            {
                MessageBox.Show("저장성공");
                DialogResult = DialogResult.OK;
            }
            else if (_result == 0)
            {
                MessageBox.Show("저장실패");
            }
            else if (_result == -999)
            {
                MessageBox.Show("접속실패");
            }
            else if (_result == -1)
            {
                MessageBox.Show("쿼리 실행 중 오류가 발생했습니다.");
            }
        }

        private void Save4Modify()
        {
            int _goodsCode = Convert.ToInt32(tbox_code.Text);
            string _goodsSort = tbox_sort.Text;
            int _goodsPrice = Convert.ToInt32(tbox_price.Text);
            string _goodsName = tbox_name.Text;
            int _goodsQuan = Convert.ToInt32(tbox_Quan.Text);
            int _goodsRecoQuan = Convert.ToInt32(tbox_RecoQuan.Text);
            string _inDate = "";
            string _outDate = "";
            string _goods_picture = pbox_goods.Tag as string;
        
            if (cbtn_in.Checked)
            {
                _inDate = date_ItemIN.Value.ToString("yyyy-MM-dd HH:mm:ss");

            }
            else { }
            if (cbtn_out.Checked)
            {
                 _outDate = date_ItemOut.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }           
            else { }        

       
            int _result = App.Instance().DBManager.ModifyItem(_goodsCode, _goodsSort, _goodsPrice, _goodsName, _goodsQuan, _goodsRecoQuan, _inDate , _outDate, _goods_picture);
            if (_result > 0)
            {
                MessageBox.Show("수정성공");

                DialogResult = DialogResult.OK;
            }
            else if (_result == -999)
            {
                MessageBox.Show("접속실패");
            }
            else
            {
                MessageBox.Show("수정실패");
            }
        }



        private void btn_file_Click(object sender, EventArgs e)
        {
            string _image_file = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|all files|*.*";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _image_file = ofd.FileName;
                pbox_goods.Image = Bitmap.FromFile(_image_file);


                FileStream fs = new FileStream(_image_file, FileMode.Open, FileAccess.Read);
                byte[] bImage = new byte[fs.Length];
                fs.Read(bImage, 0, (int)fs.Length);

                StringBuilder hex = new StringBuilder(bImage.Length * 2);
                foreach (byte b in bImage)
                {
                    hex.AppendFormat("{0:X2}", b);
                }
                string _hex_image = hex.ToString();
                pbox_goods.Tag = _hex_image;
            }


        }

        private void cbtn_in_CheckedChanged(object sender, EventArgs e)
        {
            if(cbtn_in.Checked) { date_ItemIN.Enabled = true; } else { date_ItemIN.Enabled = false;}
        }

        private void cbtn_out_CheckedChanged(object sender, EventArgs e)
        {
            date_ItemOut.Enabled = cbtn_out.Checked;
        }

        private void date_ItemOut_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
