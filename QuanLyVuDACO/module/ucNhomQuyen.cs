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
using System.Globalization;
using System.Text;
using DevExpress.XtraEditors.Repository;

namespace Quản_lý_vudaco.module
{
    public partial class ucNhomQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNhomQuyen()
        {
            InitializeComponent();

        }

        private void btnQuyen_Click(object sender, EventArgs e)
        {
            using (var _db = new clsKetNoi())
            {

                var danhsach_quyen = new[]
                 {
                    new { TenQuyen = "menuStrip1", Quyen = "menuStrip1" },
                    new { TenQuyen = "Hệ thống", Quyen = "mnHeThong" },
                    new { TenQuyen = "Danh sách tài khoản", Quyen = "ucDanhSachTaiKhoan" },
                    new { TenQuyen = "Nhân viên", Quyen = "ucNhanVien" },
                    new { TenQuyen = "Thoát phiên đăng nhập", Quyen = "thoátPhiênĐăngNhậpToolStripMenuItem" },
                    new { TenQuyen = "Xoá dữ liệu", Quyen = "ucXoa" },
                    new { TenQuyen = "Thoát", Quyen = "thoátToolStripMenuItem" },
                    new { TenQuyen = "Danh mục", Quyen = "danhMụcToolStripMenuItem" },
                    new { TenQuyen = "Khách hàng", Quyen = "ucKhachHang" },
                    new { TenQuyen = "Nhà cung cấp", Quyen = "ucNhaCungCap" },
                    new { TenQuyen = "Danh mục thu chi", Quyen = "danhMụcThuChiToolStripMenuItem" },
                    new { TenQuyen = "Danh mục thu", Quyen = "ucThu" },
                    new { TenQuyen = "Danh mục chi", Quyen = "ucChi" },
                    new { TenQuyen = "Danh sách ngân hàng", Quyen = "ucDanhMucNganHang" },
                    new { TenQuyen = "Danh mục quỹ", Quyen = "ucDanhMucQuy" },
                    new { TenQuyen = "Danh sách xe - Công trình", Quyen = "ucDanhSachXe" },
                    new { TenQuyen = "Phòng ban", Quyen = "ucPhongBan" },
                    new { TenQuyen = "Kế toán", Quyen = "kếToánToolStripMenuItem" },
                    new { TenQuyen = "Bảng theo dõi số File", Quyen = "ucBangTheoDoiSoFile" },
                    new { TenQuyen = "Bảng theo dõi phơi nâng hạ", Quyen = "ucBangTheoDoiPhoiNangHa" },
                    new { TenQuyen = "Bảng theo dõi file giá", Quyen = "ucBangTheoDoiFileGia" },
                    new { TenQuyen = "Debit khách hàng", Quyen = "debitKháchHàngToolStripMenuItem" },
                    new { TenQuyen = "Debit KH các lô hàng đã lập file", Quyen = "ucBangTheoDoiDebit_File" },
                    new { TenQuyen = "Debit KH các lô hàng không lập file", Quyen = "ucBangTheoDoiDebit_KoFile_KH" },
                    new { TenQuyen = "Debit nhà cung cấp", Quyen = "ucBangTheoDoiDebit" },
                    new { TenQuyen = "Debit  NCC các lô hàng không lập file", Quyen = "ucBangTheoDoiDebit_KoFile_NCC" },
                    new { TenQuyen = "Debit NCC  các lô hàng có lập file", Quyen = "ucBangTheoDoiDebit_CoFile_NCC" },
                    new { TenQuyen = "Nhập số dư ban đầu", Quyen = "nhậpSốDưBanĐầuToolStripMenuItem" },
                    new { TenQuyen = "Số dư tiền mặt - Ngân hàng", Quyen = "ucSoDuTienMat" },
                    new { TenQuyen = "Số dư công nợ khách hàng", Quyen = "ucSoDuDauKyKH" },
                    new { TenQuyen = "Số dư công nợ nhà cung cấp", Quyen = "ucSoDuDauKyNCC" },
                    new { TenQuyen = "Giao nhận", Quyen = "giaoNhậnToolStripMenuItem" },
                    new { TenQuyen = "Bảng liệt kê chi phí", Quyen = "ucBangLietKeChiPhi" },
                    new { TenQuyen = "Bảng danh sách cược", Quyen = "ucBangDanhSachCuoc" },
                    new { TenQuyen = "Bảng tạm thu", Quyen = "ucBangTamThu" },
                    new { TenQuyen = "Điều xe", Quyen = "ucBangDieuXe3333" },
                    new { TenQuyen = "Nhật ký hàng ngày", Quyen = "ucBangDieuXe" },
                    new { TenQuyen = "Bảng tổng hợp điều xe", Quyen = "bảngTổngHợpĐiềuXeToolStripMenuItem" },
                    new { TenQuyen = "Lái xe", Quyen = "láiXeToolStripMenuItem" },
                    new { TenQuyen = "Bảng phí đi đường", Quyen = "ucBangPhiDiDuong" },
                    new { TenQuyen = "Thông báo", Quyen = "báoCáoToolStripMenuItem" },
                    new { TenQuyen = "Debit cần bổ sung", Quyen = "ucDebitCanBoSung" },
                    new { TenQuyen = "Công nợ đến hạn", Quyen = "côngNợĐếnHạnToolStripMenuItem" },
                    new { TenQuyen = "Công nợ khách hàng đến hạn", Quyen = "côngNợKháchHàngĐếnHạnToolStripMenuItem" },
                    new { TenQuyen = "Thông báo tự động", Quyen = "thôngBáoTựĐộngToolStripMenuItem" },
                    new { TenQuyen = "Setup thông báo", Quyen = "setupThôngBáoToolStripMenuItem" },
                    new { TenQuyen = "Công nợ nhà cung cấp đến hạn", Quyen = "côngNợNhàCungCấpĐếnHạnToolStripMenuItem" },
                    new { TenQuyen = "Công nợ", Quyen = "côngNợToolStripMenuItem" },
                    new { TenQuyen = "Công nợ khách hàng", Quyen = "ucCongNoKhachHang" },
                    new { TenQuyen = "Công nợ nhà cung cấp", Quyen = "ucCongNoNhaCungCap" },
                    new { TenQuyen = "Công nợ nhân viên", Quyen = "côngNợNhânViênToolStripMenuItem" },
                    new { TenQuyen = "Bộ phận giao nhận", Quyen = "ucCongNoGiaoNhan" },
                    new { TenQuyen = "Bộ phận lái xe", Quyen = "ucCongNoLaiXe" },
                    new { TenQuyen = "Bù trừ công nợ", Quyen = "ucCongNoDoiTru" },
                    new { TenQuyen = "Các khoản vay ngân hàng", Quyen = "cácKhoảnVayNgânHàngToolStripMenuItem" },
                    new { TenQuyen = "Công nợ nhà cung cấp mới", Quyen = "ucCongNoNhaCungCapV2" },
                    new { TenQuyen = "Công nợ khách hàng mới", Quyen = "ucCongNoKhachHangV2" },
                    new { TenQuyen = "Sổ quỹ", Quyen = "sổQuỹToolStripMenuItem" },
                    new { TenQuyen = "Tiền mặt", Quyen = "ucTienMat" },
                    new { TenQuyen = "Tiền gửi ngân hàng", Quyen = "tiềnGửiNgânHàngToolStripMenuItem" },
                    new { TenQuyen = "Báo Cáo", Quyen = "báoCáoToolStripMenuItem1" },
                    new { TenQuyen = "Báo cáo Sổ quỹ tiền mặt", Quyen = "ucBaoCaoSoQuyTM" },
                    new { TenQuyen = "Báo cáo Sổ TK ngân hàng", Quyen = "ucBaoCaoSoTK" },
                    new { TenQuyen = "Báo cáo chi phí", Quyen = "báoCáoChiPhíToolStripMenuItem" },
                    new { TenQuyen = "Quản lý chi phí ", Quyen = "chiPhíQuảnLýToolStripMenuItem" },
                    new { TenQuyen = "Chi phí hải quan", Quyen = "chiPhíHảiQuanToolStripMenuItem" },
                    new { TenQuyen = "Báo cáo doanh thu", Quyen = "báoCáoDoanhThuToolStripMenuItem" },
                    new { TenQuyen = "Báo cáo tài chính", Quyen = "báoCáoTàiChínhToolStripMenuItem" },
                    new { TenQuyen = "Lợi nhuận theo lô hàng", Quyen = "lợiNhuậnTheoLôHàngToolStripMenuItem" },
                    new { TenQuyen = "Lợi nhuận theo xe", Quyen = "ucLoiNhuanTheoXe" },
                    new { TenQuyen = "Lợi nhuận theo chuyến", Quyen = "lợiNhuậnTheoChuyếnToolStripMenuItem" },
                    new { TenQuyen = "Báo cáo kết quả kinh doanh", Quyen = "ucBaoCaoKetQuaKinhDoanh" },
                    new { TenQuyen = "Lợi nhuận theo từng lĩnh vực kinh doanh", Quyen = "ucLoiNhuanTheoTungLinhVuc" },
                    new { TenQuyen = "Quản lý", Quyen = "quảnLýToolStripMenuItem" },
                    new { TenQuyen = "Duyệt bảng kê chi phí", Quyen = "ucDuyetBangKechiPhi" },
                    new { TenQuyen = "Duyệt file giá", Quyen = "ucDuyetBangTheoDoiFileGia" },
                    new { TenQuyen = "Bảng Lương - Chấm công", Quyen = "bảngLươngToolStripMenuItem" },
                    new { TenQuyen = "Lương bộ phận lái xe", Quyen = "ucLuongLaiXe" },
                    new { TenQuyen = "Lương bộ phận văn phòng", Quyen = "ucLuongVanPhong" },
                    new { TenQuyen = "Bảng theo dõi phép năm", Quyen = "ucBangPhepNam" },
                    new { TenQuyen = "Khai báo mức lương cố định", Quyen = "ucLuongCoDinh" },
                    new { TenQuyen = "Chi phí cần phân bổ", Quyen = "chiPhíCầnPhânBổToolStripMenuItem" },
                    new { TenQuyen = "Tài sản cố định", Quyen = "ucTaiSanCoDinh" },
                    new { TenQuyen = "Chi phí trả trước", Quyen = "ucChiPhiTraTruoc" },
                    new { TenQuyen = "Phân bổ chi phí chung", Quyen = "ucChiPhiChung" },
                    new { TenQuyen = "Phân bổ chi phí theo lô hàng", Quyen = "phânBổChiPhíTheoLôHàngToolStripMenuItem" },
                    new { TenQuyen = "Mua hàng - Bán Hàng", Quyen = "muaHàngBánHàngToolStripMenuItem" },
                    new { TenQuyen = "Mua hàng", Quyen = "ucMuaHang" },
                    new { TenQuyen = "Bán hàng", Quyen = "ucBanHang" },
                    new { TenQuyen = "panelCha", Quyen = "panelCha" },
                    new { TenQuyen = "xtraTabControl1", Quyen = "xtraTabControl1" },
                    new { TenQuyen = "Home", Quyen = "tabHome" },
                    new { TenQuyen = "pictureBox1", Quyen = "pictureBox1" },
                    new { TenQuyen = "statusStrip1", Quyen = "statusStrip1" },
                    new { TenQuyen = "Tài khoản:", Quyen = "toolStripStatusLabel1" },
                    new { TenQuyen = "lblTK", Quyen = "lblTK" },
                    new { TenQuyen = "Truy cập lúc:", Quyen = "toolStripStatusLabel2" },
                    new { TenQuyen = "lblThoiGian", Quyen = "lblThoiGian" },
                    new { TenQuyen = "Nhóm Quyền", Quyen = "ucNhomQuyen" },
                    new { TenQuyen = "Phần mềm quản lý VUDACO", Quyen = "frmMain" }
                }.ToList();


                foreach (var item in danhsach_quyen)
                {
                    _db.UpsertFromObjectByColumn("Permissions", new { TenQuyen = item.TenQuyen, Quyen = item.Quyen }, new[] { "Quyen" });
                }
            }
        }
        public static string ChuyenDoiChuoiKhongDau(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Chuẩn hóa và bỏ dấu tiếng Việt
            string normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Xóa khoảng trắng + chuyển lowercase
            return sb.ToString().Normalize(NormalizationForm.FormC)
                     .Replace(" ", "")
                     .ToLower();
        }

        private void ucNhomQuyen_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenQuyen");
            dt.Columns.Add("Quyen");
            dt.Columns.Add("All", typeof(bool));
            dt.Columns.Add("Menu", typeof(bool));
            dt.Columns.Add("Xem", typeof(bool));
            dt.Columns.Add("Luu", typeof(bool));
            dt.Columns.Add("Xoa", typeof(bool));
            string sql = $@"
            SELECT p.*, 0 AS Menu,0 AS Xem,0 AS Luu,0 AS Xoa
            FROM Permissions p";
            using (var _db = new clsKetNoi())
            {
                DataTable table = _db.LoadTable(sql);
                foreach (DataRow item in table.Rows)
                {
                    DataRow row = dt.NewRow();
                    row["TenQuyen"] = item["TenQuyen"].ToString();
                    row["Quyen"] = item["Quyen"].ToString();
                    row["All"] = false;
                    row["Menu"] = Convert.ToBoolean(item["Menu"]);
                    row["Xem"] = Convert.ToBoolean(item["Xem"]);
                    row["Luu"] = Convert.ToBoolean(item["Luu"]);
                    row["Xoa"] = Convert.ToBoolean(item["Xoa"]);
                    dt.Rows.Add(row);
                }
            }
            gridControl1.DataSource = dt;
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "All")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, "Menu", 1);
                            gridView1.SetRowCellValue(e.RowHandle, "Xem", 1);
                            gridView1.SetRowCellValue(e.RowHandle, "Luu", 1);
                            gridView1.SetRowCellValue(e.RowHandle, "Xoa", 1);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, "Menu", 0);
                            gridView1.SetRowCellValue(e.RowHandle, "Xem", 0);
                            gridView1.SetRowCellValue(e.RowHandle, "Luu", 0);
                            gridView1.SetRowCellValue(e.RowHandle, "Xoa", 0);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemHyperSua_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemHyperXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
