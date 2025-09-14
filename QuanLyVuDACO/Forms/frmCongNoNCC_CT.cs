using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Quản_lý_vudaco.services;
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
    public partial class frmCongNoNCC_CT : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoNCC_CT()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        public frmCongNoNCC_CT(DateTime TuNgay,DateTime DenNgay,string MaKH,string TenKH)
        {
            InitializeComponent();
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _MaKH = MaKH;
            _TenKH = TenKH;
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        DateTime _TuNgay = new DateTime();
        DateTime _DenNgay = new DateTime();
        string _MaKH = "", _TenKH = "";

        private void bandedGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                int dong = e.RowHandle;
                if(dong>=0)
                {
                    if(bandedGridView1.GetRowCellDisplayText(dong,"Loai").ToString().Trim().ToLower()=="x")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }    
                }    

            }
            catch (Exception)
            {

            }
        }
        public static string _MaQuy = "";
        public static string _SotK = "", _ChiNhanh = "", _ChuTK = "", _TenNganHang = "", _HinhThucTT = "";
        public static double _SoTien = 0;
        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
        }

        private void bandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Chon")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_VanChuyen", bandedGridView1.GetFocusedRowCellValue("NoCuoiKi_VanChuyen").ToString());
                            bandedGridView1.SetFocusedRowCellValue("SoThu_NangHa", bandedGridView1.GetFocusedRowCellValue("NoCuoiKi_NangHa").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_VanChuyen", 0);
                            bandedGridView1.SetFocusedRowCellValue("SoThu_NangHa", 0);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static DateTime _Ngay = new DateTime();

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();

                using (var _ncc = new ncc())
                {
                    DataTable dt = _ncc.CongNoChiTietNhaCungCap_In(_TuNgay, _DenNgay, _MaKH);
                    double dauKy = _ncc.DauKy_NCC(_MaKH, _TuNgay, _DenNgay);
                    double thanhtoan = _ncc.ThanhToan_NCC(_MaKH, _TuNgay, _DenNgay);
                    reports.rpt_CongNoNCC rpt = new reports.rpt_CongNoNCC(dt, string.Format("Từ ngày {0} - Đến ngày {1}", _TuNgay.ToString("dd/MM/yyyy"), _DenNgay.ToString("dd/MM/yyyy")), dauKy, thanhtoan, _TenKH);
                    splashScreenManager1.CloseWaitForm();
                    rpt.ShowPreview();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int _In = 0;
        public static string _DienGiai = "";
        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            frmMain._Luu = 0;
            _Ngay = DateTime.Now;
            _In = 0;
            _MaQuy = ""; _SotK = ""; _ChiNhanh = ""; _ChuTK = ""; _TenNganHang = ""; _HinhThucTT = ""; _DienGiai = "";
            //frmPhieuThu frm = new frmPhieuThu(_MaKH);
            //frm.ShowDialog();
            bool isCheck = false, isCheck_DichVu = false, isCheck_ChiHo = false;
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                if (_Chon)
                {
                    isCheck = true;
                }
                if (bandedGridView1.GetRowCellValue(i, "SoThu_VanChuyen").ToString() != "")
                    isCheck_DichVu = true;
                if (bandedGridView1.GetRowCellValue(i, "SoThu_NangHa").ToString() != "")
                    isCheck_ChiHo = true;
            }
            if (!isCheck&&(isCheck_DichVu|| isCheck_ChiHo))
                MessageBox.Show("Vui lòng chọn dòng cần thu tiền!");
            else if (!isCheck_DichVu&& !isCheck_ChiHo)
                MessageBox.Show("Vui lòng nhập số tiền dịch vụ hoặc chi hộ để thu tiền!");
            else
            {
                //phieu chi nha cung cap
                frmQuyNCC frm1 = new frmQuyNCC();
                frm1.ShowDialog();
                if (frmMain._Luu == 1)
                {
                    string[] value = new string[15];
                    string[] arr = _Ngay.ToString("dd/MM/yyyy").Split('/');
                    value[0] = client.TaoSoChungTu_Chi_NCC(arr);
                    value[1] = _Ngay.ToString("yyyy-MM-dd");
                    value[2] = "006";
                    value[3] = "Chi trả tiền nhà cung cấp";
                    value[4] = _DienGiai;
                    value[5] = "";
                    value[6] = frmMain._TK;
                    value[7] = _Ngay.ToString("yyyy-MM-dd");
                    value[8] = frmMain._HoTen;
                    value[9] = _MaQuy;
                    value[10] = _HinhThucTT;
                    value[11] = _SotK;
                    value[12] = _TenNganHang;
                    value[13] = _ChiNhanh;
                    value[14] = _ChuTK;
                    client.DanhSachPhieuChi_NCC_Them(value);
                    var table = client.dsNCC_MaNCC(_MaKH);
                    foreach (var item in table)
                    {
                        for (int i = 0; i < bandedGridView1.RowCount; i++)
                        {
                            bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                            if (_Chon)
                            {
                                //phieuThuCT
                                //SoChungTu,IDCP,SoFile,MaNhanVien,SoTien,DoiTuong,MaDoiTuong,TenDoiTuong,DiaChi,VAT,ThanhTien,GhiChu,LaVanChuyen,MaDieuXe,Tien_DuyetUng
                                string[] value1 = new string[15];
                                if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_VanChuyen").ToString() != "" && bandedGridView1.GetRowCellDisplayText(i, "SoThu_VanChuyen").ToString() != "0")
                                {

                                    value1[0] = value[0];
                                    value1[1] = "0";
                                    value1[2] = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                                    value1[3] = "";
                                    value1[4] = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_VanChuyen").ToString()).ToString();
                                    value1[5] = "NCC";
                                    value1[6] = _MaKH;
                                    value1[7] = _TenKH;
                                    value1[8] = item.DiaChi;
                                    value1[9] = "0";
                                    value1[10] = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_VanChuyen").ToString()).ToString();
                                    value1[11] = "";
                                    value1[12] = "true";
                                    if (value1[2].ToString().Trim().Length > 5)
                                        value1[13] = "";
                                    else
                                        value1[13] = bandedGridView1.GetRowCellValue(i, "MaDieuXe").ToString();
                                    value1[14] = "0";
                                    client.DanhSachPhieuChi_NCC_CT_Them(value1);
                                }
                                if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_NangHa").ToString() != "" && bandedGridView1.GetRowCellDisplayText(i, "SoThu_NangHa").ToString() != "0")
                                {
                                    value1[0] = value[0];
                                    value1[1] = "0";
                                    value1[2] = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                                    value1[3] = "";
                                    value1[4] = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_NangHa").ToString()).ToString();
                                    value1[5] = "NCC";
                                    value1[6] = _MaKH;
                                    value1[7] = _TenKH;
                                    value1[8] = item.DiaChi;
                                    value1[9] = "0";
                                    value1[10] = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_NangHa").ToString()).ToString();
                                    value1[11] = "";
                                    value1[12] = "false";
                                    if (value1[2].ToString().Trim().Length > 5)
                                        value1[13] = "";
                                    else
                                        value1[13] = bandedGridView1.GetRowCellValue(i, "MaDieuXe").ToString();
                                    value1[14] = "0";
                                    client.DanhSachPhieuChi_NCC_CT_Them(value1);
                                }
                            }
                        }
                    }
                    if (_In == 1)
                    {
                        string _soChungTu = value[0];
                        DateTime _NgayHachToan = _Ngay;
                        DataTable dt = client.DanhSachPhieuChi_NCC_CT_TheoSoChungTu(_soChungTu);
                        reports.rpt_PhieuChiNCC rpt = new reports.rpt_PhieuChiNCC(dt, _NgayHachToan);
                        rpt.ShowPreview();
                    }
                    frmCongNoKH_CT_Load(sender, e);
                }
            }
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmCongNoKH_CT_Load(object sender, EventArgs e)
        {
            try
            {
                this.CenterToScreen();
                this.Text = "Công nợ chi tiết: " + _TenKH + " đến ngày " + _DenNgay.ToString("dd/MM/yyyy"); ;
               
                splashScreenManager1.ShowWaitForm();
                using (var _ncc = new ncc())
                {
                    gridControl1.DataSource = _ncc.CongNoChiTietNhaCungCap(_TuNgay, _DenNgay, _MaKH);
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}