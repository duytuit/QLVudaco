using ClosedXML.Excel;
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
using System.Globalization;

namespace Quản_lý_vudaco.Forms
{
    public partial class frmCongNoNCC_CT_V2 : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoNCC_CT_V2()
        {
            InitializeComponent();
           // colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
            if (e.Column.FieldName == "ConLai")
            {
                double ChiNangHa = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "PhiNangHa"));
                double ThanhTien = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTien"));
                double ThanhToan = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToan"));
                double UngTruoc = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "UngTruoc"));
                e.Value = (ChiNangHa + ThanhTien) - (ThanhToan + UngTruoc);
            }

        }
        public frmCongNoNCC_CT_V2(DateTime TuNgay,DateTime DenNgay,string MaKH,string TenKH = null)
        {
            InitializeComponent();
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _MaKH = MaKH;
            _TenKH = TenKH;
            // colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.Columns["ConLai"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
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
                    if(gridView1.GetRowCellDisplayText(dong,"Loai").ToString().Trim().ToLower()=="x")
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
                            gridView1.SetFocusedRowCellValue("SoThu_VanChuyen", gridView1.GetFocusedRowCellValue("NoCuoiKi_VanChuyen").ToString());
                            gridView1.SetFocusedRowCellValue("SoThu_NangHa", gridView1.GetFocusedRowCellValue("NoCuoiKi_NangHa").ToString());
                        }
                        else
                        {
                            gridView1.SetFocusedRowCellValue("SoThu_VanChuyen", 0);
                            gridView1.SetFocusedRowCellValue("SoThu_NangHa", 0);
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
                    var ncc_dk = _ncc.CongNoChiTietNcc(_TuNgay, null, _MaKH, null, 1);
                    // Group 1 lần duy nhất
                    var ncc_du_no_dau_ky = ncc_dk
                        .GroupBy(x => x.MaNhaCungCap)
                        .Select(g => new
                        {
                            MaNhaCungCap = g.Key,
                            DichVuDk = g.Where(x => x.Type == 0).Sum(x => x.ThanhTien),
                            NangHaDk = g.Where(x => x.Type == 3).Sum(x => x.ThanhTien),
                            DichVuTTDK = g.Where(x => x.Type == 2).Sum(x => x.ThanhTien),
                            NangHaTTDK = g.Where(x => x.Type == 1).Sum(x => x.ThanhTien),
                        })
                        .FirstOrDefault(); // chỉ lấy 1 NCC
                    double du_no = (ncc_du_no_dau_ky.DichVuTTDK + ncc_du_no_dau_ky.NangHaTTDK) - (ncc_du_no_dau_ky.DichVuDk + ncc_du_no_dau_ky.NangHaDk);
                    var ncc_ct = _ncc.CongNoChiTietNcc(_TuNgay, _DenNgay, _MaKH);
                    var ncc_dv_nh = ncc_ct.Where(x => new[] { 0, 3 }.Contains(x.Type)).Select(x => new
                                   {
                                        Ngay = x.NgayHachToan,
                                        SoFile = x.SoFile,
                                        LoaiXe_NCC = x.LoaiXe_NCC,
                                        MaDieuXe = x.MaDieuXe,
                                        TuyenVC = x.TuyenVC,
                                        SoHoaDon = x.SoHoaDon,
                                        SoToKhai = x.SoToKhai,
                                        SoBill = x.SoBill,
                                        NoiDung = x.NoiDung,
                                        MaNhaCungCap = x.MaNhaCungCap,
                                        BienSoXe = x.BienSoXe,
                                        SoCont = x.SoCont,
                                        SoTien = (x.Type == 0) ? x.SoTien : 0,
                                        TienVAT= (x.Type ==0) ? (x.VAT * x.SoTien)/100 : 0,
                                        ThanhTien = (x.Type == 0) ? x.ThanhTien : 0,
                                        PhiNangHa = (x.Type == 3) ? x.ThanhTien : 0,
                                        ThanhToan = ncc_ct.Where(y => y.IDName == x.ID && y.KeyName == x.Key).Sum(y => y.ThanhTien),
                                        UngTruoc = ncc_ct.Where(y => y.Type == 4 && y.SoFile == x.SoFile).Sum(y => y.ThanhTien),
                                        ConLai = x.ThanhTien - (ncc_ct.Where(y => y.IDName == x.ID && y.KeyName == x.Key).Sum(y => y.ThanhTien)+ ncc_ct.Where(y => y.Type == 4 && y.SoFile == x.SoFile).Sum(y => y.ThanhTien)),
                                        Type = x.Type,
                                        Chon = x.Chon,
                                    })
                                    .OrderBy(x => x.Ngay)
                                    .ToList();
                    DataRow nhacungcap = _ncc.GetDetailNCC(_MaKH);
                    reports.rpt_CongNoNCC_v1 rpt = new reports.rpt_CongNoNCC_v1(string.Format("Từ ngày {0} - Đến ngày {1}", _TuNgay.ToString("dd/MM/yyyy"), _DenNgay.ToString("dd/MM/yyyy")), du_no, 0, nhacungcap["TenNhaCungCap"].ToString());
                    rpt.DataSource = ToDataTable(ncc_dv_nh);
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

        private void gridView1_CustomUnboundColumnData_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
          
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (var _ncc = new ncc())
            {
                var ncc_ct = _ncc.CongNoChiTietNcc(_TuNgay, _DenNgay, _MaKH);

                var ncc_dv_nh = ncc_ct.Where(x => new[] { 0 ,3 }.Contains(x.Type)).GroupBy(x=>x.SoFile)
                      .Select(g => new
                      {
                          MaNhaCungCap = g.First().MaNhaCungCap,
                          SoToKhai = g.First().SoToKhai,
                          SoBill = g.First().SoBill,
                          SoCont = g.First().SoCont,
                          SoFile = g.Key,
                          //SoTien = ncc_ct.Where(y => y.Type == 0 && y.SoFile == g.Key).Sum(y => y.SoTien),
                          //VAT = ncc_ct.Where(y => y.Type == 0 && y.SoFile == g.Key).Sum(y => y.VAT),
                          ThanhTien = ncc_ct.Where(y => y.Type == 0 && y.SoFile == g.Key).Sum(y => y.ThanhTien),
                          ChiNangHa = ncc_ct.Where(y => y.Type == 3 && y.SoFile == g.Key).Sum(y => y.ThanhTien),
                          UngTruocNCC = ncc_ct.Where(y => new[] { 1,2,4 }.Contains(y.Type) && y.SoFile == g.Key).Sum(y => y.ThanhTien),
                      })
                    .ToList();

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(ToDataTable(ncc_dv_nh), sfd.FileName);
                        MessageBox.Show("Xuất Excel thành công!");
                    }
                }
            }
        }

        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            DataTable dt_view = new DataTable();
            dt_view.Columns.Add("ID");
            dt_view.Columns.Add("Key");
            dt_view.Columns.Add("TenNhaCungCap");
            dt_view.Columns.Add("MaNhaCungCap");
            dt_view.Columns.Add("SoFile");
            dt_view.Columns.Add("Type");
            dt_view.Columns.Add("SoTien", typeof(double));
            bool check = false;
            using (var _ncc = new ncc())
            {
                DataRow nhacungcap = _ncc.GetDetailNCC(_MaKH);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool _Chon = bool.Parse(gridView1.GetRowCellValue(i, "Chon").ToString());
                   
                    if (_Chon)
                    {
                        int sotien = int.Parse(gridView1.GetRowCellValue(i, "SoTra")?.ToString());
                        if (sotien > 0)
                        {
                            check = true;
                            DataRow row = dt_view.NewRow();
                            row["TenNhaCungCap"] = nhacungcap["TenNhaCungCap"].ToString();
                            row["MaNhaCungCap"] = _MaKH;
                            row["SoFile"] = gridView1.GetRowCellValue(i, "SoFile").ToString();
                            row["SoTien"] = gridView1.GetRowCellValue(i, "SoTra")?.ToString();
                            row["Type"] = gridView1.GetRowCellValue(i, "Type")?.ToString();
                            row["ID"] = gridView1.GetRowCellValue(i, "ID")?.ToString();
                            row["Key"] = gridView1.GetRowCellValue(i, "Key")?.ToString();
                            dt_view.Rows.Add(row);
                        }
                    }
                }
            }
            if (check == true)
            {
                frmChiNCC frm1 = new frmChiNCC(dt_view);
                frm1.ShowDialog();
                LoadData();
             
            }
           
        }
        private void LoadData()
        {
            try
            {
                using (var _ncc = new ncc())
                {
                    DataRow nhacungcap = _ncc.GetDetailNCC(_MaKH);

                    this.CenterToScreen();
                    this.Text = "Công nợ chi tiết: " + nhacungcap["TenNhaCungCap"].ToString() + " Từ ngày: " + _TuNgay.ToString("dd/MM/yyyy") + " đến ngày: " + _DenNgay.ToString("dd/MM/yyyy");

                    splashScreenManager1.ShowWaitForm();

                    var ncc_dk = _ncc.CongNoChiTietNcc(_TuNgay, null, _MaKH, null, 1);
                    // Group 1 lần duy nhất
                    var ncc_du_no_dau_ky = ncc_dk
                        .GroupBy(x => x.MaNhaCungCap)
                        .Select(g => new
                        {
                            MaNhaCungCap = g.Key,
                            DichVuDk = g.Where(x => x.Type == 0).Sum(x => x.ThanhTien),
                            NangHaDk = g.Where(x => x.Type == 3).Sum(x => x.ThanhTien),
                            DichVuTTDK = g.Where(x => x.Type == 2).Sum(x => x.ThanhTien),
                            NangHaTTDK = g.Where(x => x.Type == 1).Sum(x => x.ThanhTien),
                        })
                        .FirstOrDefault(); // chỉ lấy 1 NCC
                    double du_no = ((ncc_du_no_dau_ky?.DichVuTTDK ?? 0)
                               + (ncc_du_no_dau_ky?.NangHaTTDK ?? 0))
                              - ((ncc_du_no_dau_ky?.DichVuDk ?? 0)
                               + (ncc_du_no_dau_ky?.NangHaDk ?? 0));
                    //  double du_no = 0;
                    var ncc_ct = _ncc.CongNoChiTietNcc(_TuNgay, _DenNgay, _MaKH);
                    var ncc_dv_nh = ncc_ct.Where(x => new[] { 0, 3 }.Contains(x.Type)).Select(x => new
                    {
                        NgayHachToan = x.NgayHachToan,
                        LoaiXe_NCC = x.LoaiXe_NCC,
                        MaDieuXe = x.MaDieuXe,
                        SoToKhai = x.SoToKhai,
                        SoBill = x.SoBill,
                        NoiDung = x.NoiDung,
                        MaNhaCungCap = x.MaNhaCungCap,
                        BienSoXe = x.BienSoXe,
                        SoTien = (x.Type == 0) ? x.SoTien : 0,
                        ThanhTien = (x.Type == 0) ? x.ThanhTien : 0,
                        VAT = (x.Type == 0) ? x.VAT : 0,
                        LaPhiChiHo = x.LaPhiChiHo,
                        TongTien = x.TongTien,
                        PhiCom = x.PhiCom,
                        Type = x.Type,
                        SoCont = x.SoCont,
                        Chon = x.Chon,
                        ID = x.ID,
                        Key = x.Key,
                        SoFile = x.SoFile,
                        PhiNangHa = (x.Type == 3) ? x.ThanhTien : 0,
                        ThanhToan = ncc_ct.Where(y=>y.IDName == x.ID && y.KeyName == x.Key).Sum(y=>y.ThanhTien),
                        UngTruoc = ncc_ct.Where(y => y.Type == 4 && y.SoFile == x.SoFile).Sum(y => y.ThanhTien),
                        SoTra = 0
                    })
                    .OrderBy(x => x.NgayHachToan)
                    .ToList();
                    lbducodauky.Text = "Dư nợ đầu kỳ: " + du_no.ToString("N0", CultureInfo.InvariantCulture);
                    gridControl1.DataSource = ToDataTable(ncc_dv_nh);
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0 && e.Column.FieldName == "Chon")
                {
                    bool isCheck = Convert.ToBoolean(e.Value);

                    if (isCheck)
                    {
                        // Lấy giá trị an toàn (tránh null hoặc DBNull)
                        double chiNangHa = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "PhiNangHa") ?? 0);
                        double thanhTien = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "ThanhTien") ?? 0);
                        double ThanhToan = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "ThanhToan") ?? 0);
                        double UngTruoc = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, "UngTruoc") ?? 0);

                        double conLai = (chiNangHa + thanhTien) - (ThanhToan + UngTruoc);

                        // Nếu còn lại > 0 thì gán SoTra
                        gridView1.SetRowCellValue(e.RowHandle, "SoTra", conLai > 0 ? conLai : 0);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, "SoTra", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log nếu cần
                Console.WriteLine("Lỗi khi gán SoTra: " + ex.Message);
            }
        }

        public void ExportToExcel(DataTable dt, string filePath)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sheet1");
                wb.SaveAs(filePath);
            }
        }

        public static string _DienGiai = "";
      
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmCongNoKH_CT_Load(object sender, EventArgs e)
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