using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.Forms
{
    public partial class frmFileDebitBoSung : DevExpress.XtraEditors.XtraForm
    {
        public frmFileDebitBoSung()
        {
            InitializeComponent();
        }
        public frmFileDebitBoSung(string IDCP,string IDLoHang)
        {
            InitializeComponent();
            _IDCP= int.Parse(IDCP);
            _IDLoHang = int.Parse(IDLoHang);
        }
        public frmFileDebitBoSung(int IDGia,int sua)
        {
            InitializeComponent();
            _IDGia = IDGia;
            _sua = sua;
        }
        public frmFileDebitBoSung(int IDLoHang,int IDGia, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _IDGia = IDGia;
            _sua = sua;
        }
        public frmFileDebitBoSung(int IDCP, int IDLoHang,int IDGia, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _IDGia = IDGia;
            _IDCP = IDCP;
            _sua = sua;
        }
        int _IDGia = 0, _sua = 0, _IDLoHang = 0, _IDDeBit = 0;
        int _IDCP =0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

        DataTable dtFull = new DataTable("table");
        private void LoadVAT()
        {
            DataTable dt = new DataTable("VAT");
            dt.Columns.Add("VAT");
            dt.Columns.Add("Ten");
            DataRow row = dt.NewRow();
            row["VAT"] = 0;
            row["Ten"] = 0;
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["VAT"] = 5;
            row1["Ten"] = 5;
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["VAT"] = 8;
            row2["Ten"] = 8;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["VAT"] = 10;
            row3["Ten"] = 10;
            dt.Rows.Add(row3);

            DataRow row4 = dt.NewRow();
            row4["VAT"] = -1;
            row4["Ten"] = "Khác";
            dt.Rows.Add(row4);
            repositoryItemVAT.DataSource = dt;
        }
        bool _luu = false;
        private void frmBangKeChiPhi_Load(object sender, EventArgs e)
        {

            LoadVAT();
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable dt = client.DsThongTinFile_Full_TheoIDLoHang_FileGia(_IDLoHang);
            if(dt.Rows.Count>0)
            {
                DataRow row = dt.Rows[0];
                lblKh.Text = row["TenKhachHang"].ToString();
                lblSoFile.Text= row["SoFile"].ToString();
                lblSoToKhai.Text = row["SoToKhai"].ToString();
                lblSoBill.Text = row["SoBill"].ToString();
                lblSoLuong.Text = row["SoLuong"].ToString();
                lblSoCont.Text = row["SoCont"].ToString();
                lblTenSales.Text = row["TenSales"].ToString();
                _IDLoHang = int.Parse(row["IDLoHang"].ToString());

                //chi tiet

                DataTable dtCT= client.ChiTietNoiDungTaoDebit_BoSung(_IDGia,_IDCP);
                gridControl1.DataSource = dtCT;
                dtFull = dtCT;
                gridColumn2.OptionsColumn.ReadOnly = false;
                gridColumn5.OptionsColumn.ReadOnly = false;
            }    
            if(_sua==1)
            {
                DataTable dtCT = client.ChiTietNoiDungTaoDebit_Sua(_IDDeBit);
                gridControl1.DataSource = dtCT;
                dtFull = dtCT;
                btnLuu.Enabled = false;
                //
                DataTable dt1 = client.DsThongTinFile_Full_TheoIDLoHang_FileGia(_IDLoHang);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt1.Rows[0];
                    lblKh.Text = row["TenKhachHang"].ToString();
                    lblSoFile.Text = row["SoFile"].ToString();
                    lblSoToKhai.Text = row["SoToKhai"].ToString();
                    lblSoBill.Text = row["SoBill"].ToString();
                    lblSoLuong.Text = row["SoLuong"].ToString();
                    lblSoCont.Text = row["SoCont"].ToString();
                    lblTenSales.Text = row["TenSales"].ToString();
                    _IDLoHang = int.Parse(row["IDLoHang"].ToString());


                }
                gridColumn2.OptionsColumn.ReadOnly = true;
                gridColumn5.OptionsColumn.ReadOnly = true;
            }    
            else
            {
                btnLuu.Enabled = true;
            }
           
        }
       


        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            _luu = true;
            if (gridView1.RowCount==0)
                MessageBox.Show("Không có thông tin cần truy vấn!");
            else
            {
               
              
                //
                ServiceReference1.FileDebit p1 = new ServiceReference1.FileDebit();
                p1.IDGia = _IDGia;
                p1.SoFile = lblSoFile.Text;
                string[] arr = dtpNgay.Text.Split('/');
                if (arr.Length == 3)
                    p1.ThoiGianLap = new DateTime(int.Parse(arr[2]),int.Parse(arr[1]),int.Parse(arr[0]));
                p1.NguoiLap = frmMain._TK;
                p1.IDLoHang = _IDLoHang;
                client.LuuFileDebit(p1);
                //
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!gridView1.IsNewItemRow(i))
                    {
                        ServiceReference1.FileDebitChiTiet p2 = new ServiceReference1.FileDebitChiTiet();
                        p2.TenDichVu = gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim();
                        if (gridView1.GetRowCellDisplayText(i, "SoTien").Trim() == "")
                            p2.SoTien = 0;
                        if (gridView1.GetRowCellDisplayText(i, "ThanhTien") != "")
                            p2.ThanhTien = float.Parse(gridView1.GetRowCellDisplayText(i, "ThanhTien").ToLower().Trim());
                        else
                            p2.ThanhTien = 0;
                        // }    
                        if (gridView1.GetRowCellDisplayText(i, "SoTien") != "")
                            p2.SoTien = float.Parse(gridView1.GetRowCellDisplayText(i, "SoTien").ToLower().Trim());
                        else
                            p2.SoTien = 0;
                        if (gridView1.GetRowCellDisplayText(i, "VAT").ToLower() != "khác")
                        {
                            if (gridView1.GetRowCellDisplayText(i, "VAT").ToLower() != "")
                                p2.VAT = float.Parse(gridView1.GetRowCellDisplayText(i, "VAT").ToLower().Trim());
                            else
                                p2.VAT = 0;
                        }
                        else
                        {
                            p2.VAT = -1;
                            p2.SoTien = 0;
                        }
                        p2.IDDeBit = client.Top1FileDebit();
                       p2.GhiChu = gridView1.GetRowCellDisplayText(i, "GhiChu").Trim();
                       p2.LaPhiChiHo=bool.Parse( gridView1.GetRowCellValue(i, "LaPhiChiHo").ToString().Trim());
                        if (p2.TenDichVu!="")
                          client.LuuFileDebitChiTiet(p2);
                    }
                }
                MessageBox.Show("Thao tác thành công!");
                _IDDeBit = 0;
                client.XoaBangKe_BoSung_IDCP(_IDCP);
                this.Close();
            }
        }
        double _giaMua = 0;
       

       
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_IDDeBit > 0)
            {
                client.XoaFileDebit(_IDDeBit);
                btnLuu_Click_1(sender, e);
            }
        }

        private void frmFileDebitBoSung_FormClosed(object sender, FormClosedEventArgs e)
        {
           
               
        }

        private void frmFileDebitBoSung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_luu)
            {
                //MessageBox.Show("Bạn chưa nhấn nút lưu để tạo FileDebit. Vui lòng phải tạo File Debit!");
                //e.Cancel = true;
                client.XoaFileGia_TheoIDGia(_IDGia);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "ThanhTienVAT")
            {
              
                float _SoTien = (gridView1.GetFocusedRowCellDisplayText("SoTien").Trim()=="")?0:float.Parse(gridView1.GetFocusedRowCellDisplayText( "SoTien").Trim());
                float _SoTienVAT = (gridView1.GetFocusedRowCellDisplayText("ThanhTienVAT").Trim()=="")?0:float.Parse(gridView1.GetFocusedRowCellDisplayText("ThanhTienVAT").Trim());
                gridView1.SetFocusedRowCellValue("ThanhTien", _SoTien + _SoTienVAT);
            }    
        }

        private void repositoryItemVAT_EditValueChanged(object sender, EventArgs e)
        {
            int _index = gridView1.FocusedRowHandle;
            try
            {
                LookUpEdit lookUpEdit = (LookUpEdit)sender;
                if (lookUpEdit.EditValue.ToString().Trim().ToLower() == "-1")
                {
                       gridView1.SetRowCellValue(_index, "VAT", -1);
                        gridView1.SetRowCellValue(_index, "ThanhTien", 0);
                }
                else
                {
                    gridView1.SetRowCellValue(_index, "VAT", lookUpEdit.EditValue.ToString());
                    float _vat = float.Parse(gridView1.GetRowCellDisplayText(_index, "VAT").Trim());
                    float _SoTien = float.Parse(gridView1.GetRowCellDisplayText(_index, "SoTien").Trim());
                    float _SoTienVAT = (_vat * _SoTien) / 100;
                    gridView1.SetRowCellValue(_index, "ThanhTienVAT", _SoTienVAT);
                    gridView1.SetRowCellValue(_index, "ThanhTien", _SoTien + _SoTienVAT);

                }
               
            }
            catch (Exception)
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                client.XoaFileDebit(_IDDeBit);
                frmBangKeChiPhi_Load(sender, e);
            }    
        }

    }
}