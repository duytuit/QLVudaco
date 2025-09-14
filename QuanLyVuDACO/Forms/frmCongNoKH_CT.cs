using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class frmCongNoKH_CT : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoKH_CT()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        public frmCongNoKH_CT(DateTime TuNgay,DateTime DenNgay,string MaKH,string TenKH)
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
                            bandedGridView1.SetFocusedRowCellValue("SoThu_DichVu", bandedGridView1.GetFocusedRowCellValue("NoCuoiKi_DichVu").ToString());
                            bandedGridView1.SetFocusedRowCellValue("SoThu_ChiHo", bandedGridView1.GetFocusedRowCellValue("NoCuoiKi_ChiHo").ToString());
                           
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_DichVu", 0);
                            bandedGridView1.SetFocusedRowCellValue("SoThu_ChiHo", 0);
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
        DataTable dt=    client.CongNoChiTietKhachHang_In(_TuNgay, _DenNgay, _MaKH);
            string tg = string.Format("Từ ngày {0} - Đến ngày {1}",_TuNgay.ToString("dd/MM/yyyy"),_DenNgay.ToString("dd/MM/yyyy"));
            double DauKy = client.DauKy_KH(_TuNgay, _MaKH);
            double ThanhToan = client.ThanhToan_KH(_TuNgay, _DenNgay, _MaKH);
            reports.rpt_CongNoKH rpt = new reports.rpt_CongNoKH(dt,tg, DauKy, ThanhToan,_TenKH);
            rpt.ShowPreview();
        }

        public static int _In = 0;
        public static string _DienGiai = "";
        private double SafeToDouble(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return 0;
            double result;
            return double.TryParse(value.ToString(), out result) ? result : 0;
        }
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
                if (bandedGridView1.GetRowCellValue(i, "SoThu_DichVu").ToString() != "")
                    isCheck_DichVu = true;
                if (bandedGridView1.GetRowCellValue(i, "SoThu_ChiHo").ToString() != "")
                    isCheck_ChiHo = true;
            }
            if (!isCheck&&(isCheck_DichVu|| isCheck_ChiHo))
                MessageBox.Show("Vui lòng chọn dòng cần thu tiền!");
            else if (!isCheck_DichVu&& !isCheck_ChiHo)
                MessageBox.Show("Vui lòng nhập số tiền dịch vụ hoặc chi hộ để thu tiền!");
            else
            {
                //phieu thu
                DataTable dt_view = new DataTable();
                dt_view.Columns.Add("TenKhachHang");
                dt_view.Columns.Add("SoFile");
                dt_view.Columns.Add("SoThu_DichVu", typeof(double));
                dt_view.Columns.Add("SoThu_ChiHo", typeof(double));
                dt_view.Columns.Add("TongThu", typeof(double));

                for (int i = 0; i < bandedGridView1.RowCount; i++)
                {
                    bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                    if (_Chon)
                    {
                        DataRow row = dt_view.NewRow();
                        row["TenKhachHang"] = _TenKH;
                        row["SoFile"] = bandedGridView1.GetRowCellValue(i, "SoFile")?.ToString();

                        double soThuDV = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_DichVu").ToString());
                        double soThuChiHo = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_ChiHo").ToString());

                        row["SoThu_DichVu"] = soThuDV;
                        row["SoThu_ChiHo"] = soThuChiHo;
                        row["TongThu"] = soThuDV + soThuChiHo;

                        dt_view.Rows.Add(row);
                    }
                }
                frmQuy frm1 = new frmQuy(dt_view);
                frm1.ShowDialog();
                if (frmMain._Luu == 1)
                {
                    ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
                    string[] arr = _Ngay.ToString("dd/MM/yyyy").Split('/');
                    p.DienGiai = _DienGiai;
                    p.LyDoThu = "Thu công nợ khách hàng";
                    p.MaThu = "004";
                    p.MaQuy = _MaQuy;
                    DateTime Ngay1 = _Ngay;
                    p.NgayHachToan = Ngay1;
                    p.NguoiNhan = frmMain._HoTen;
                    p.NguoiTao = frmMain._TK;
                    p.SoChungTu = client.TaoSoChungTu_Thu(arr);
                    p.SoHoaDon = "";
                    p.ThoiGianTao = _Ngay;
                    p.HinhThucTT = _HinhThucTT;
                    p.SoTK = _SotK;
                    p.TenNganHang = _TenNganHang;
                    p.ChiNhanh = _ChiNhanh;
                    p.ChuTaiKhoan = _ChuTK;
                    client.DanhSachPhieuThu_Them(p);
                    var table = client.dsKH_MaKH(_MaKH);
                    foreach (var item in table)
                    {
                        for (int i = 0; i < bandedGridView1.RowCount; i++)
                        {
                            bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                            if (_Chon)
                            {
                                //phieuThuCT
                                if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_DichVu").ToString() != "")
                                {
                                    ServiceReference1.PhieuThu_CT p1 = new ServiceReference1.PhieuThu_CT();
                                    p1.SoChungTu = p.SoChungTu;
                                    p1.DiaChi = item.DiaChi;
                                    p1.DoiTuong = "KH";
                                    p1.GhiChu = "";
                                    p1.MaDoiTuong = _MaKH;
                                    p1.SoFile = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                                    p1.SoTien = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_DichVu").ToString());
                                    p1.VAT = 0;
                                    p1.ThanhTien = p1.SoTien;
                                    p1.TenDoiTuong = _TenKH;
                                    p1.IDCP = 0;
                                    p1.MaNhanVien = "";//
                                    p1.LaPhieuChiHo = false;
                                    p1.MaDieuXe = bandedGridView1.GetRowCellValue(i, "MaDieuXe").ToString();
                                    client.DanhSachPhieuThu_CT_Them(p1);
                                }
                                if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_ChiHo").ToString() != "")
                                {
                                    ServiceReference1.PhieuThu_CT p1 = new ServiceReference1.PhieuThu_CT();
                                    p1.SoChungTu = p.SoChungTu;
                                    p1.DiaChi = item.DiaChi;
                                    p1.DoiTuong = "KH";
                                    p1.GhiChu = "";
                                    p1.MaDoiTuong = _MaKH;
                                    p1.SoFile = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                                    p1.SoTien = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_ChiHo").ToString());
                                    p1.VAT = 0;
                                    p1.ThanhTien = p1.SoTien;
                                    p1.TenDoiTuong = _TenKH;
                                    p1.IDCP = 0;
                                    p1.MaNhanVien = "";//
                                    p1.LaPhieuChiHo = true;
                                    p1.MaDieuXe = bandedGridView1.GetRowCellValue(i, "MaDieuXe").ToString();
                                    client.DanhSachPhieuThu_CT_Them(p1);
                                }
                            }
                        }
                    }
                    if (_In == 1)
                    {
                        string _soChungTu = p.SoChungTu;
                        DateTime _NgayHachToan = Ngay1;
                        DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
                        reports.rpt_PhieuThu rpt = new reports.rpt_PhieuThu(dt, _NgayHachToan);
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
                gridControl1.DataSource = client.CongNoChiTietKhachHang(_TuNgay, _DenNgay, _MaKH);
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}