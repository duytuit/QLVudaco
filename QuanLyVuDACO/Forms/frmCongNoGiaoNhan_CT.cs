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
    public partial class frmCongNoGiaoNhan_CT : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoGiaoNhan_CT()
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
        public frmCongNoGiaoNhan_CT(DateTime TuNgay,DateTime DenNgay,string TaiKhoan,string tenGiaoNhan)
        {
            InitializeComponent();
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _TaiKhoan = TaiKhoan;
            _TenGiaoNhan = tenGiaoNhan;
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        DateTime _TuNgay = new DateTime();
        DateTime _DenNgay = new DateTime();
        string _TaiKhoan = "", _TenGiaoNhan = "";
        private void bandedGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                int dong = e.RowHandle;
                if(dong>=0)
                {
                    //if(bandedGridView1.GetRowCellDisplayText(dong,"Loai").ToString().Trim().ToLower()=="x")
                    //{
                    //    e.Appearance.BackColor = Color.Red;
                    //    e.Appearance.ForeColor = Color.White;
                    //}    
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
                            bandedGridView1.SetFocusedRowCellValue("SoThu_Cuoc", bandedGridView1.GetFocusedRowCellValue("ConLai_Cuoc").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_Cuoc", 0);
                        }
                    }
                   else if (e.Column.FieldName == "ChonTamThu_BangKe")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangKe", bandedGridView1.GetFocusedRowCellValue("ConLai_TamUng_BangKe").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangKe", 0);
                        }
                    }
                    else if (e.Column.FieldName == "ChonTamThu_BangPhoi")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangPhoi", bandedGridView1.GetFocusedRowCellValue("ConLai_TamUng_BangPhoi").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangPhoi", 0);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static DateTime _Ngay = new DateTime();
        private void TaoPhieuThu1()
        {
            string[] arr = _Ngay.ToString("dd/MM/yyyy").Split('/');
            string _SoChungTu = client.TaoSoChungTu_ThuHoanCuocGiaoNhan(arr);
            bool isOK = false;
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                if (_Chon)
                {

                    if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_Cuoc").ToString() != "")
                    {
                        isOK = true;
                        ServiceReference1.PhieuThu_GiaoNhan_CT p11 = new ServiceReference1.PhieuThu_GiaoNhan_CT();
                        p11.SoChungTu = _SoChungTu;
                        p11.DiaChi = "";
                        p11.DoiTuong = "NV";
                        p11.GhiChu = "";
                        p11.MaDoiTuong = _TaiKhoan;
                        p11.SoFile = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                        p11.SoTien = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_Cuoc").ToString());
                        p11.VAT = 0;
                        p11.ThanhTien = p11.SoTien;
                        p11.TenDoiTuong = _TenGiaoNhan;
                        p11.IDCP = int.Parse(bandedGridView1.GetRowCellValue(i, "IDCP").ToString());
                        p11.MaNhanVien = _TaiKhoan;//
                        p11.LaPhieuChiHo = true;
                        p11.MaDieuXe = "";
                        client.DanhSachPhieuThuGiaoNhan_CT_Them(p11);
                    }
                }

            }
            if (isOK)
            {
                ServiceReference1.PhieuThu_GiaoNhan p = new ServiceReference1.PhieuThu_GiaoNhan();
                p.DienGiai = _DienGiai;
                p.LyDoThu = _DienGiai;
                p.MaThu = "005";
                p.LaLKCP = true;
                p.MaQuy = _MaQuy;
                DateTime Ngay1 = _Ngay;
                p.NgayHachToan = Ngay1;
                p.NguoiNhan = frmMain._HoTen;
                p.NguoiTao = frmMain._TK;
                p.SoChungTu = _SoChungTu;
                p.SoHoaDon = "";
                p.ThoiGianTao = _Ngay;
                p.HinhThucTT = _HinhThucTT;
                p.SoTK = _SotK;
                p.TenNganHang = _TenNganHang;
                p.ChiNhanh = _ChiNhanh;
                p.ChuTaiKhoan = _ChuTK;
                p.LaLKCP = true;
                client.DanhSachPhieuThuGiaoNhan_Them(p);
            }
        }
        private void TaoPhieuThu2()
        {
            string[] arr = _Ngay.ToString("dd/MM/yyyy").Split('/');
            string _SoChungTu = client.TaoSoChungTu_ThuHoanCuocGiaoNhan(arr);
            bool isOK = false;
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "ChonTamThu_BangKe").ToString());
                if (_Chon)
                {

                    if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_TamUng_BangKe").ToString() != "")
                    {
                        isOK = true;
                        ServiceReference1.PhieuThu_GiaoNhan_CT p11 = new ServiceReference1.PhieuThu_GiaoNhan_CT();
                        p11.SoChungTu = _SoChungTu;
                        p11.DiaChi = "";
                        p11.DoiTuong = "NV";
                        p11.GhiChu = "";
                        p11.MaDoiTuong = _TaiKhoan;
                        p11.SoFile = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                        p11.SoTien = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_TamUng_BangKe").ToString());
                        p11.VAT = 0;
                        p11.ThanhTien = p11.SoTien;
                        p11.TenDoiTuong = _TenGiaoNhan;
                        p11.IDCP = int.Parse(bandedGridView1.GetRowCellValue(i, "IDCP").ToString());
                        p11.MaNhanVien = _TaiKhoan;//
                        p11.LaPhieuChiHo = true;
                        p11.MaDieuXe = "";
                        client.DanhSachPhieuThuGiaoNhan_CT_Them(p11);
                    }
                }

            }
            if (isOK)
            {
                ServiceReference1.PhieuThu_GiaoNhan p = new ServiceReference1.PhieuThu_GiaoNhan();
                p.DienGiai = _DienGiai;
                p.LyDoThu = _DienGiai;
                p.MaThu = "006";
                p.LaLKCP = true;
                p.MaQuy = _MaQuy;
                DateTime Ngay1 = _Ngay;
                p.NgayHachToan = Ngay1;
                p.NguoiNhan = frmMain._HoTen;
                p.NguoiTao = frmMain._TK;
                p.SoChungTu = _SoChungTu;
                p.SoHoaDon = "";
                p.ThoiGianTao = _Ngay;
                p.HinhThucTT = _HinhThucTT;
                p.SoTK = _SotK;
                p.TenNganHang = _TenNganHang;
                p.ChiNhanh = _ChiNhanh;
                p.ChuTaiKhoan = _ChuTK;
                p.LaLKCP = true;
                client.DanhSachPhieuThuGiaoNhan_Them(p);
            }
        }
        private void TaoPhieuThu3()
        {
            string[] arr = _Ngay.ToString("dd/MM/yyyy").Split('/');
            string _SoChungTu = client.TaoSoChungTu_ThuHoanCuocGiaoNhan(arr);
            bool isOK = false;
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "ChonTamThu_BangPhoi").ToString());
                if (_Chon)
                {

                    if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_TamUng_BangPhoi").ToString() != "")
                    {
                        isOK = true;
                        ServiceReference1.PhieuThu_GiaoNhan_CT p11 = new ServiceReference1.PhieuThu_GiaoNhan_CT();
                        p11.SoChungTu = _SoChungTu;
                        p11.DiaChi = "";
                        p11.DoiTuong = "NV";
                        p11.GhiChu = "";
                        p11.MaDoiTuong = _TaiKhoan;
                        p11.SoFile = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                        p11.SoTien = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_TamUng_BangPhoi").ToString());
                        p11.VAT = 0;
                        p11.ThanhTien = p11.SoTien;
                        p11.TenDoiTuong = _TenGiaoNhan;
                        p11.IDCP = int.Parse(bandedGridView1.GetRowCellValue(i, "IDCP").ToString());
                        p11.MaNhanVien = _TaiKhoan;//
                        p11.LaPhieuChiHo = true;
                        p11.MaDieuXe = "";
                        client.DanhSachPhieuThuGiaoNhan_CT_Them(p11);
                    }
                }

            }
            if (isOK)
            {
                ServiceReference1.PhieuThu_GiaoNhan p = new ServiceReference1.PhieuThu_GiaoNhan();
                p.DienGiai = _DienGiai;
                p.LyDoThu = _DienGiai;
                p.MaThu = "006";
                p.LaLKCP = true;
                p.MaQuy = _MaQuy;
                DateTime Ngay1 = _Ngay;
                p.NgayHachToan = Ngay1;
                p.NguoiNhan = frmMain._HoTen;
                p.NguoiTao = frmMain._TK;
                p.SoChungTu = _SoChungTu;
                p.SoHoaDon = "";
                p.ThoiGianTao = _Ngay;
                p.HinhThucTT = _HinhThucTT;
                p.SoTK = _SotK;
                p.TenNganHang = _TenNganHang;
                p.ChiNhanh = _ChiNhanh;
                p.ChuTaiKhoan = _ChuTK;
                p.LaLKCP = false;
                client.DanhSachPhieuThuGiaoNhan_Them(p);
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
                            bandedGridView1.SetFocusedRowCellValue("SoThu_Cuoc", bandedGridView1.GetFocusedRowCellValue("ConLai_Cuoc").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_Cuoc", 0);
                        }
                    }
                    else if (e.Column.FieldName == "ChonTamThu_BangKe")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangKe", bandedGridView1.GetFocusedRowCellValue("ConLai_TamUng_BangKe").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangKe", 0);
                        }
                    }
                    else if (e.Column.FieldName == "ChonTamThu_BangPhoi")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangPhoi", bandedGridView1.GetFocusedRowCellValue("ConLai_TamUng_BangPhoi").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng_BangPhoi", 0);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnHoanTra_Click(object sender, EventArgs e)
        {
            _Ngay = DateTime.Now;
            _In = 0;
            _MaQuy = ""; _SotK = ""; _ChiNhanh = ""; _ChuTK = ""; _TenNganHang = ""; _HinhThucTT = ""; _DienGiai = "";

            //phieu thu hoan cuoc
            #region phieu thu hoan cuoc
            frmHoanTraPhieuTamThu frm1 = new frmHoanTraPhieuTamThu();
            frm1.ShowDialog();
            #endregion
            if (frmMain._Luu == 1)
            {
                for (int i = 0; i < bandedGridView1.RowCount; i++)
                {
                    bool _ChonBangKe = bool.Parse(bandedGridView1.GetRowCellValue(i, "ChonTamThu_BangKe").ToString());
                    bool _ChonBangPhoi = bool.Parse(bandedGridView1.GetRowCellValue(i, "ChonTamThu_BangPhoi").ToString());
                    string _IDCP = bandedGridView1.GetRowCellValue(i, "IDCP").ToString().Trim();
                    if (_ChonBangKe)
                    {
                        ServiceReference1.PhieuTamThu table = new ServiceReference1.PhieuTamThu();
                        DataTable dt = client.DanhSachTamThu_TheoIDCP(int.Parse(_IDCP), "bangke");
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            table.SoFile = row["SoFile"].ToString();
                            table.MaKhachHang = row["MaKhachHang"].ToString().Trim();
                            table.NgayTao = DateTime.Now;
                            table.TienCuoc = double.Parse(row["TienCuoc"].ToString());
                            table.NguoiGiaoNhan = row["MaNhanVien"].ToString().Trim();
                            table.GhiChu = _DienGiai.Trim();
                            table.NguoiTao = frmMain._TK;
                            table.DaXacNhan = false;
                            table.NguoiXacNhan = "";
                            table.LaLKCP = true;
                            table.IDCP = int.Parse(row["IDCP"].ToString());
                            client.PhieuTamThu_Luu(table);
                        }
                       
                    }
                    if (_ChonBangPhoi)
                    {
                        ServiceReference1.PhieuTamThu table = new ServiceReference1.PhieuTamThu();
                        DataTable dt = client.DanhSachTamThu_TheoIDCP(int.Parse(_IDCP), "bangphoi");
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            table.SoFile = row["SoFile"].ToString();
                            table.MaKhachHang = row["MaKhachHang"].ToString().Trim();
                            table.NgayTao = DateTime.Now;
                            table.TienCuoc = double.Parse(row["TienCuoc"].ToString());
                            table.NguoiGiaoNhan = row["MaNhanVien"].ToString().Trim();
                            table.GhiChu = _DienGiai.Trim();
                            table.NguoiTao = frmMain._TK;
                            table.DaXacNhan = false;
                            table.NguoiXacNhan = "";
                            table.LaLKCP = false;
                            table.IDCP = int.Parse(row["IDCP"].ToString());
                            client.PhieuTamThu_Luu(table);
                        }

                    }
                }
               
                frmCongNoKH_CT_Load(sender, e);
            }
        }

        public static int _In = 0;
        public static string _DienGiai = "";
        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            _Ngay = DateTime.Now;
            _In = 0;
            _MaQuy = ""; _SotK = ""; _ChiNhanh = ""; _ChuTK = ""; _TenNganHang = ""; _HinhThucTT = ""; _DienGiai = "";

           
                //phieu thu hoan cuoc
                #region phieu thu hoan cuoc
                frmQuyHoanCuocNhanVien frm1 = new frmQuyHoanCuocNhanVien();
                frm1.ShowDialog();

            #endregion
            if (frmMain._Luu == 1)
            {
                TaoPhieuThu1();
                TaoPhieuThu2();
                TaoPhieuThu3();
                //if (_In == 1)
                //{
                //    string _soChungTu = p.SoChungTu;
                //    DateTime _NgayHachToan = Ngay1;
                //    DataTable dt = client.DanhSachPhieuThu_GiaoNhan_CT_TheoSoChungTu(_soChungTu);
                //    reports.rpt_PhieuThuHoanCuoc rpt = new reports.rpt_PhieuThuHoanCuoc(dt, _NgayHachToan);
                //    rpt.ShowPreview();
                //}
                frmCongNoKH_CT_Load(sender, e);
            }
            
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmCongNoKH_CT_Load(object sender, EventArgs e)
        {
            try
            {
                this.CenterToScreen();
                this.Text = "Công nợ chi tiết: " + _TenGiaoNhan + " đến ngày " + _DenNgay.ToString("dd/MM/yyyy"); ;
               
                splashScreenManager1.ShowWaitForm();
                gridControl1.DataSource = client.CongNoChiTietGiaoNhan(_TuNgay, _DenNgay, _TaiKhoan);
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}