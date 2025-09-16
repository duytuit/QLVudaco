using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Quản_lý_vudaco.services;
using Quản_lý_vudaco.services.Entity;
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
                        LoaiXe_KH = x.LoaiXe_KH,
                        MaDieuXe = x.MaDieuXe,
                        SoHoaDon = x.SoHoaDon,
                        TenSales = x.TenSales,
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
                        VAT = (x.Type == 0) ? (x.VAT * x.SoTien) / 100 : 0,
                        LaPhiChiHo = x.LaPhiChiHo,
                        TongTien = x.TongTien,
                        PhiCom = x.PhiCom,
                        Type = x.Type,
                        SoCont = x.SoCont,
                        Chon = false,
                        ID = x.ID,
                        Key = x.Key,
                        SoFile = x.SoFile + "/"+ x.MaDieuXe,
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var _khachhang = new khachhang())
                    {
                        var _khachhang_ct = _khachhang.CongNoChiTietKH(_TuNgay, _DenNgay, _MaKH);
                        ExportToExcel(_khachhang_ct,sfd.FileName);
                    }
                    MessageBox.Show("Xuất Excel thành công!");
                }
            }

        }
        public void ExportToExcel(List<CongNoChiTietKH> list, string filepath)
        {
            var _khachhang = list;
            var _khachhang_temp = list.OrderBy(x => x.NgayHachToan).ToList();

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Tháng 8");

                // ==== TIÊU ĐỀ ====
                ws.Range("A1:Q1").Merge();
                ws.Cell("A1").Value = "BẢNG KÊ CHI TIẾT THÁNG 08/2025";
                ws.Cell("A1").Style
                    .Font.SetBold()
                    .Font.SetFontSize(16)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                ws.Range("A2:Q2").Merge();
                ws.Cell("A2").Value = "Từ ngày 01/08/2025 đến ngày 31/08/2025";
                ws.Cell("A2").Style
                    .Font.SetBold()
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                ws.Range("A3:K3").Merge(); // merge trống theo mẫu

                // ==== THÔNG TIN ĐƠN VỊ ====

                var cell_benban = ws.Cell("A5");
                cell_benban.Clear();
                cell_benban.GetRichText().AddText("Đơn vị bán hàng: ")
                    .SetBold();
                cell_benban.GetRichText().AddText("Công ty TNHH VUDACO");
                ws.Cell("A6").Value = "Địa chỉ: Số 6C/195 Kiều Hạ, Phường Đông Hải, Thành Phố Hải Phòng, Việt Nam";
                ws.Cell("A7").Value = "MST: 0201723721";

                var cell_benmua = ws.Cell("A9");
                cell_benmua.Clear();
                cell_benmua.GetRichText().AddText("Đơn vị mua hàng: ")
                    .SetBold();
                cell_benmua.GetRichText().AddText("CÔNG TY TNHH CHARTER LINK LOGISTICS VIỆT NAM");
                ws.Cell("A10").Value = "Địa chỉ: Tầng 5, Tòa nhà Phúc Hải, số 94 phố Trần Phú, Phường Gia Viên, Thành phố Hải Phòng, Việt Nam";
                ws.Cell("A11").Value = "Mã số thuế: 0202216347";


                // ==== HEADER BẢNG ====
                // bắt đầu từ dòng 13, header chiếm 2 dòng: 13 và 14
                int headerRow1 = 13;
                int headerRow2 = 14;

                // merge các cột (dọc 2 dòng)
                ws.Range(headerRow1, 1, headerRow2, 1).Merge().Value = "STT";
                ws.Range(headerRow1, 2, headerRow2, 2).Merge().Value = "NGÀY";
                ws.Range(headerRow1, 3, headerRow2, 3).Merge().Value = "LOẠI XE";
                ws.Range(headerRow1, 4, headerRow2, 4).Merge().Value = "Số xe";
                ws.Range(headerRow1, 5, headerRow2, 5).Merge().Value = "TUYẾN VẬN CHUYỂN";
                ws.Range(headerRow1, 6, headerRow2, 6).Merge().Value = "ĐƠN VỊ";
                ws.Range(headerRow1, 7, headerRow2, 7).Merge().Value = "SỐ LƯỢNG";
                ws.Range(headerRow1, 8, headerRow2, 8).Merge().Value = "ĐƠN GIÁ";
                ws.Range(headerRow1, 9, headerRow2, 9).Merge().Value = "THUẾ SUẤT";
                ws.Range(headerRow1, 10, headerRow2, 10).Merge().Value = "TIỀN THUẾ GTGT";
                ws.Range(headerRow1, 11, headerRow2, 11).Merge().Value = "THÀNH TIỀN";
                ws.Range(headerRow1, 12, headerRow2, 12).Merge().Value = "CHI HỘ";
                ws.Range(headerRow1, 13, headerRow2, 13).Merge().Value = "TỔNG CỘNG";
                ws.Range(headerRow1, 14, headerRow2, 14).Merge().Value = "SỐ FILE";
                ws.Range(headerRow1, 15, headerRow2, 15).Merge().Value = "Số bill/booking (hoặc Số tờ khai)";
                ws.Range(headerRow1, 16, headerRow2, 16).Merge().Value = "Số HĐ";
                ws.Range(headerRow1, 17, headerRow2, 17).Merge().Value = "ND chi hộ";

                // format chung cho header
                var headerRange = ws.Range(headerRow1, 1, headerRow2, 17);
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                // Set width cho toàn bộ cột từ A → Q
                ws.Column(1).Width = 5;   // STT
                ws.Column(2).Width = 12;  // NGÀY
                ws.Column(3).Width = 15;  // LOẠI XE
                ws.Column(4).Width = 12;  // Số xe
                ws.Column(5).Width = 25;  // TUYẾN VẬN CHUYỂN
                ws.Column(6).Width = 18;  // ĐƠN VỊ
                ws.Column(7).Width = 12;  // SỐ LƯỢNG
                ws.Column(8).Width = 15;  // ĐƠN GIÁ
                ws.Column(9).Width = 12;  // THUẾ SUẤT
                ws.Column(10).Width = 18; // TIỀN THUẾ GTGT
                ws.Column(11).Width = 18; // THÀNH TIỀN
                ws.Column(12).Width = 12; // CHI HỘ
                ws.Column(13).Width = 18; // TỔNG CỘNG
                ws.Column(14).Width = 12; // SỐ FILE
                ws.Column(15).Width = 30; // Số bill/booking (hoặc Số tờ khai)
                ws.Column(16).Width = 15; // Số HĐ
                ws.Column(17).Width = 28; // ND chi hộ

                // Cho phép xuống dòng trong ô nếu text dài
                ws.Range(headerRow1, 1, headerRow2, 17).Style.Alignment.WrapText = true;
                // ==== DỮ LIỆU MẪU ====
                int startRow = 15;
                int currentRow = startRow;
                for (int i = 0; i < _khachhang_temp.Count; i++)
                {
                    int row = startRow + i;
                    var item = _khachhang_temp[i];
                    ws.Cell(row, 1).Value = i + 1; // STT
                    ws.Cell(row, 2).Value =  item.NgayHachToan;
                    ws.Cell(row, 3).Value = item.LoaiXe_KH;
                    ws.Cell(row, 4).Value = item.BienSoXe;
                    ws.Cell(row, 5).Value = item?.TuyenVC ?? item?.TenDichVu ?? "";
                    ws.Cell(row, 6).Value = "Chuyến";
                    ws.Cell(row, 7).Value = 1;
                    ws.Cell(row, 8).Value = item.SoTien;
                    ws.Cell(row, 8).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 9).Value = item.VAT +"%";
                    ws.Cell(row, 10).Value = (item.SoTien * item.VAT) / 100;
                    ws.Cell(row, 10).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 11).Value = (item.LaPhiChiHo == 0) ? item.ThanhTien : 0;
                    ws.Cell(row, 11).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 12).Value = (item.LaPhiChiHo == 1) ? item.ThanhTien : 0;
                    ws.Cell(row, 12).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 13).Value = item.ThanhTien;
                    ws.Cell(row, 13).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 14).Value = item.SoFile;
                    ws.Cell(row, 15).Value = item.SoBill + "/" + item.SoToKhai + "/";
                    ws.Cell(row, 16).Value = item.SoHoaDon;
                    ws.Cell(row, 17).Value = "";
                   // ws.Cell(currentRow, 10).FormulaA1 = $"H{currentRow}*I{currentRow}"; // TIỀN THUẾ GTGT
                }

                int dataStartRow = 15;
                int dataEndRow = ws.LastRowUsed().RowNumber();
                int totalRow = dataEndRow + 1;
                // range dữ liệu (A..Q)
                var dataRange = ws.Range(dataStartRow, 1, dataEndRow, 17);
                // set border all
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;


                // ghi chữ "TỔNG CỘNG"
                ws.Range(totalRow, 1, totalRow, 7).Merge();
                ws.Cell(totalRow, 1).Value = "TỔNG CỘNG";
                ws.Range(totalRow, 1, totalRow, 7).Style.Font.Bold = true;
                ws.Range(totalRow, 1, totalRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // công thức SUM cho các cột cần cộng
                ws.Cell(totalRow, 8).FormulaA1 = $"SUM(H{dataStartRow}:H{dataEndRow})";   // ĐƠN GIÁ
                ws.Cell(totalRow, 8).Style.NumberFormat.Format = "#,##0"; // format có dấu phẩy
                // ws.Cell(totalRow, 9).FormulaA1 = $"SUM(I{dataStartRow}:I{dataEndRow})";   // THUẾ SUẤT
                ws.Cell(totalRow, 10).FormulaA1 = $"SUM(J{dataStartRow}:J{dataEndRow})";  // TIỀN THUẾ GTGT
                ws.Cell(totalRow, 10).Style.NumberFormat.Format = "#,##0";
                ws.Cell(totalRow, 11).FormulaA1 = $"SUM(K{dataStartRow}:K{dataEndRow})";  // THÀNH TIỀN
                ws.Cell(totalRow, 11).Style.NumberFormat.Format = "#,##0";
                ws.Cell(totalRow, 12).FormulaA1 = $"SUM(L{dataStartRow}:L{dataEndRow})";  // CHI HỘ
                ws.Cell(totalRow, 12).Style.NumberFormat.Format = "#,##0";
                ws.Cell(totalRow, 13).FormulaA1 = $"SUM(M{dataStartRow}:M{dataEndRow})";  // TỔNG CỘNG
                ws.Cell(totalRow, 13).Style.NumberFormat.Format = "#,##0";

                // style cho dòng tổng
                var totalRange = ws.Range(totalRow, 1, totalRow, 17);
                totalRange.Style.Font.Bold = true;
                totalRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                totalRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                var fullRange = ws.Range(dataStartRow, 1, totalRow, 17);
                fullRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                fullRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                double tongCong = ws.Cell(totalRow, 13).GetDouble();
                dataEndRow = ws.LastRowUsed().RowNumber();
                // Lấy giá trị tổng cộng ở cột 13 (cột M)
                int textRow = dataEndRow + 1;
                // Thêm tiêu đề "Số tiền bằng chữ"
                ws.Range(textRow, 1, textRow, 7).Merge();
                ws.Cell(textRow, 1).Value = "Số tiền bằng chữ:";
                ws.Range(textRow, 1, textRow, 7).Style.Font.Bold = true;
                ws.Range(textRow, 1, textRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                ws.Range(textRow, 8, textRow, 17).Merge();
                ws.Cell(textRow, 8).Value = NumberToVietnameseWords(tongCong) + "./.";
                ws.Range(textRow, 8, textRow, 17).Style.Font.Bold = true;
                ws.Range(textRow, 8, textRow, 17).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                fullRange = ws.Range(textRow, 1, textRow, 17);
                fullRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                fullRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // Căn chỉnh cột
                // ws.Columns().AdjustToContents();

                // Freeze header
                //ws.SheetView.FreezeRows(14);

                // ==== LƯU FILE ====
                wb.SaveAs(filepath);
            }
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
        string NumberToVietnameseWords(double number)
        {
            if (number == 0) return "Không đồng";

            string[] unitNumbers = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = { "", "nghìn", "triệu", "tỷ" };

            string sNumber = number.ToString("#");
            int length = sNumber.Length;
            int placeValue = 0;
            string result = "";
            string suffix = "";

            while (length > 0)
            {
                int threeDigits = (length >= 3) ? int.Parse(sNumber.Substring(length - 3, 3)) : int.Parse(sNumber.Substring(0, length));
                length -= 3;

                if (threeDigits > 0 || placeValue == 3)
                {
                    string group = ReadThreeDigits(threeDigits, unitNumbers);
                    result = group + " " + placeValues[placeValue] + " " + suffix + result;
                    suffix = "";
                }
                placeValue++;
                if (placeValue > 3) placeValue = 1;
            }

            result = result.Trim();
            result = char.ToUpper(result[0]) + result.Substring(1) + " đồng";
            return result;
        }

        string ReadThreeDigits(int number, string[] unitNumbers)
        {
            int hundreds = number / 100;
            int tens = (number % 100) / 10;
            int units = number % 10;
            string result = "";

            if (hundreds > 0)
            {
                result += unitNumbers[hundreds] + " trăm";
                if (tens == 0 && units > 0) result += " linh";
            }

            if (tens > 1)
            {
                result += " " + unitNumbers[tens] + " mươi";
                if (units == 1) result += " mốt";
                else if (units == 5) result += " lăm";
                else if (units > 0) result += " " + unitNumbers[units];
            }
            else if (tens == 1)
            {
                result += " mười";
                if (units == 5) result += " lăm";
                else if (units > 0) result += " " + unitNumbers[units];
            }
            else if (tens == 0 && units > 0)
            {
                result += " " + unitNumbers[units];
            }

            return result.Trim();
        }
    }
}