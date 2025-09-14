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
    public partial class frmCongNoKH_CT_V2 : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoKH_CT_V2()
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
            if (e.Column.FieldName == "NoCuoiKi_DichVu")
            {
                double ThanhTienDV = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienDV"));
                double ThanhToanDV = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanDV"));
                e.Value = ThanhTienDV - ThanhToanDV;
            }
            if (e.Column.FieldName == "NoCuoiKi_ChiHo")
            {
                double ThanhTienCH = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienCH"));
                double ThanhToanCH = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanCH"));
                e.Value = ThanhTienCH - ThanhToanCH;
            }
            if (e.Column.FieldName == "NoCuoiKi")
            {
                double ThanhTienDV = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienDV"));
                double ThanhToanDV = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanDV"));
                double ThanhTienCH = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienCH"));
                double ThanhToanCH = Convert.ToDouble(bandedGridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanCH"));
                e.Value = (ThanhTienDV- ThanhToanDV) +(ThanhTienCH - ThanhToanCH);
            }
        }
        public frmCongNoKH_CT_V2(DateTime TuNgay,DateTime DenNgay,string MaKH)
        {
            InitializeComponent();
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _MaKH = MaKH;
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.Columns["NoCuoiKi_DichVu"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            bandedGridView1.Columns["NoCuoiKi_ChiHo"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            bandedGridView1.Columns["NoCuoiKi"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
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
            try
            {
                this.CenterToScreen();
                string tg = string.Format("Từ ngày {0} - Đến ngày {1}", _TuNgay.ToString("dd/MM/yyyy"), _DenNgay.ToString("dd/MM/yyyy"));

                splashScreenManager1.ShowWaitForm();
                using (var _khachhang = new khachhang())
                {
                    var _khachhang_ct = _khachhang.CongNoChiTietKH(_TuNgay, _DenNgay, _MaKH);
                    var kh_dv_ch = _khachhang_ct.Where(x => new[] { 0 }.Contains(x.Type)).Select(x => new
                    {
                        NgayHachToan = x.NgayHachToan,
                        LoaiXe_NCC = x.LoaiXe_NCC,
                        MaDieuXe = x.MaDieuXe,
                        SoHoaDon = x.SoHoaDon,
                        DienGiai = x.DienGiai,
                        SoToKhai = x.SoToKhai,
                        SoBill = x.SoBill,
                        TuyenVC = x.TuyenVC,
                        NoiDung = x.NoiDung,
                        MaKhachHang = x.MaKhachHang,
                        BienSoXe = x.BienSoXe,
                        SoTien = (x.Type == 0) ? x.SoTien : 0,
                        ThanhTienDV = (x.LaPhiChiHo == 0) ? x.ThanhTien : 0,
                        ThanhTienCH = (x.LaPhiChiHo == 1) ? x.ThanhTien : 0,
                        VAT = (x.Type == 0) ? x.VAT : 0,
                        LaPhiChiHo = x.LaPhiChiHo,
                        TongTien = x.TongTien,
                        PhiCom = x.PhiCom,
                        Type = x.Type,
                        SoCont = x.SoCont,
                        Chon = false,
                        ID = x.ID,
                        Key = x.Key,
                        SoFile = x.SoFile,
                        ThanhToan = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 0).Sum(y => y.ThanhTien) + _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 1).Sum(y => y.ThanhTien),
                        ThanhToanDV = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 0).Sum(y => y.ThanhTien),
                        ThanhToanCH = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 1).Sum(y => y.ThanhTien),
                        SoThu_DichVu = 0,
                        SoThu_ChiHo = 0
                    })
                    .OrderBy(x => x.NgayHachToan)
                    .ToList();
                    DataRow kh = _khachhang.GetDetailkh(_MaKH);
                    reports.rpt_CongNoKH_V2 rpt = new reports.rpt_CongNoKH_V2(ToDataTable(kh_dv_ch), tg, kh["TenKhachHang"].ToString());
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
        private double SafeToDouble(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return 0;
            double result;
            return double.TryParse(value.ToString(), out result) ? result : 0;
        }
        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            DataTable dt_view = new DataTable();
            dt_view.Columns.Add("ID");
            dt_view.Columns.Add("Key");
            dt_view.Columns.Add("TenKhachHang");
            dt_view.Columns.Add("MaKhachHang");
            dt_view.Columns.Add("MaDieuXe");
            dt_view.Columns.Add("SoFile");
            dt_view.Columns.Add("GhiChu");
            dt_view.Columns.Add("LaPhiChiHo");
            dt_view.Columns.Add("DiaChi");
            dt_view.Columns.Add("ThuDichVu", typeof(double));
            dt_view.Columns.Add("ThuChiHo", typeof(double));
            dt_view.Columns.Add("Tong", typeof(double));
            bool check = false;
            using (var _khachhang = new khachhang())
            {
                DataRow kh = _khachhang.GetDetailkh(_MaKH);

                for (int i = 0; i < bandedGridView1.RowCount; i++)
                {
                    bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                  
                    if (_Chon)
                    {
                        int NoCuoiKi_DichVu = int.Parse(bandedGridView1.GetRowCellValue(i, "NoCuoiKi_DichVu")?.ToString());
                        int NoCuoiKi_ChiHo = int.Parse(bandedGridView1.GetRowCellValue(i, "NoCuoiKi_ChiHo")?.ToString());
                        if (NoCuoiKi_DichVu > 0 || NoCuoiKi_ChiHo > 0)
                        {
                            check = true;
                            DataRow row = dt_view.NewRow();
                            row["TenKhachHang"] = kh["TenKhachHang"].ToString();
                            row["MaKhachHang"] = kh["MaKhachHang"].ToString();
                            row["SoFile"] = bandedGridView1.GetRowCellValue(i, "SoFile").ToString();
                            row["MaDieuXe"] = bandedGridView1.GetRowCellValue(i, "MaDieuXe")?.ToString();
                            row["GhiChu"] = bandedGridView1.GetRowCellValue(i, "DienGiai")?.ToString();
                            row["ThuDichVu"] = bandedGridView1.GetRowCellValue(i, "NoCuoiKi_DichVu")?.ToString();
                            row["ThuChiHo"] = bandedGridView1.GetRowCellValue(i, "NoCuoiKi_ChiHo")?.ToString();
                            row["LaPhiChiHo"] = bandedGridView1.GetRowCellValue(i, "LaPhiChiHo")?.ToString();
                            row["DiaChi"] = kh["DiaChi"].ToString();
                            row["Tong"] = bandedGridView1.GetRowCellValue(i, "NoCuoiKi")?.ToString();
                            row["ID"] = bandedGridView1.GetRowCellValue(i, "ID")?.ToString();
                            row["Key"] = bandedGridView1.GetRowCellValue(i, "Key")?.ToString();
                            dt_view.Rows.Add(row);
                        }
                       
                    }
                }
            }
            if (check == true)
            {
                frmPhieuThuKH frm1 = new frmPhieuThuKH(dt_view);
                frm1.ShowDialog();
                LoadData();

            }
        }
        private void LoadData()
        {
            try
            {
                this.CenterToScreen();
                this.Text = "Công nợ chi tiết: " + _TenKH + " đến ngày " + _DenNgay.ToString("dd/MM/yyyy"); ;

                splashScreenManager1.ShowWaitForm();
                using (var _khachhang = new khachhang())
                {
                    var _khachhang_ct = _khachhang.CongNoChiTietKH(_TuNgay, _DenNgay, _MaKH);
                    var kh_dv_ch = _khachhang_ct.Where(x => new[] { 0 }.Contains(x.Type)).Select(x => new
                    {
                        NgayHachToan = x.NgayHachToan,
                        LoaiXe_NCC = x.LoaiXe_NCC,
                        MaDieuXe = x.MaDieuXe,
                        SoHoaDon = x.SoHoaDon,
                        DienGiai = x.DienGiai,
                        SoToKhai = x.SoToKhai,
                        SoBill = x.SoBill,
                        TuyenVC = x.TuyenVC,
                        NoiDung = x.NoiDung,
                        MaKhachHang = x.MaKhachHang,
                        BienSoXe = x.BienSoXe,
                        SoTien = (x.Type == 0) ? x.SoTien : 0,
                        ThanhTienDV = (x.LaPhiChiHo == 0) ? x.ThanhTien : 0,
                        ThanhTienCH = (x.LaPhiChiHo == 1) ? x.ThanhTien : 0,
                        VAT = (x.Type == 0) ? x.VAT : 0,
                        LaPhiChiHo = x.LaPhiChiHo,
                        TongTien = x.TongTien,
                        PhiCom = x.PhiCom,
                        Type = x.Type,
                        SoCont = x.SoCont,
                        Chon = false,
                        ID = x.ID,
                        Key = x.Key,
                        SoFile = x.SoFile,
                        ThanhToan = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 0).Sum(y => y.ThanhTien) + _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 1).Sum(y => y.ThanhTien),
                        ThanhToanDV = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 0).Sum(y => y.ThanhTien),
                        ThanhToanCH = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 1).Sum(y => y.ThanhTien),
                        SoThu_DichVu = 0,
                        SoThu_ChiHo = 0
                    })
                    .OrderBy(x => x.NgayHachToan)
                    .ToList();
                    gridControl1.DataSource = ToDataTable(kh_dv_ch);
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmCongNoKH_CT_V2_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Lấy các property của class
            var Props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in Props)
            {
                // Thiết lập kiểu dữ liệu Nullable nếu có
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            ? Nullable.GetUnderlyingType(prop.PropertyType)
                            : prop.PropertyType;

                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (var item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}