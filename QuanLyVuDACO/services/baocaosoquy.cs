using Quản_lý_vudaco.services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class baocaosoquy : IDisposable
    {
        private clsKetNoi cls;
        public baocaosoquy()
        {
            cls = new clsKetNoi();
        }
        public List<BaoCaoSoQuy> BaoCaoQuy(DateTime TuNgay, DateTime? DenNgay = null, string madoituong = null, string hinhthucTT =null, int dauky = 0)
        {
            List<BaoCaoSoQuy> list = new List<BaoCaoSoQuy>();

            string sql = $@"select MaNhanVien,TenNhanVien from NhanVien";
            DataTable table_NhanVien = cls.LoadTable(sql);
            sql = $@"select MaKhachHang,TenKhachHang,TenVietTat from DanhSachKhachHang";
            DataTable table_DanhSachKhachHang = cls.LoadTable(sql);
            sql = $@"select MaNhaCungCap,TenNhaCungCap,TenVietTat from DanhSachNhaCungCap";
            DataTable table_DanhSachNhaCungCap = cls.LoadTable(sql);
            sql = $@"select * from DanhMucQuy";
            DataTable table_Quy = cls.LoadTable(sql);

            sql = $@"Select B.MaQuy,B.HinhThucTT,B.SoTK,B.ChuTaiKhoan,B.TenNganHang,B.DienGiai,B.LyDoThu,B.NgayHachToan,B.MaThu,A.* from PhieuThu_CT A left join PhieuThu B on A.SoChungTu = B.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            DataTable table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string maQuy = item["MaQuy"]?.ToString();
                string tenDT = "";
                string tenQuy = "";

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Thu = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Chi = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoThu"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.SoTK,B.ChuTaiKhoan,B.TenNganHang,B.DienGiai, B.LyDoThu,B.NgayHachToan, B.MaQuy, A.* from PhieuThu_GiaoNhan_CT A left join PhieuThu_GiaoNhan B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Thu = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Chi = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoThu"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy, A.* from PhieuChi_LaiXe_CT A left join PhieuChi_LaiXe B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Thu = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Chi = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoThu"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy, A.* from PhieuChi_LaiXe_CT A left join PhieuChi_LaiXe B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Thu = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Chi = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoThu"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy, A.* from PhieuChi_CT A left join PhieuChi B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Chi = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Thu = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoThu"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy, A.* from PhieuChi_LaiXe_CT A left join PhieuChi_LaiXe B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Chi = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Thu = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoThu"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy,B.LyDoChi, A.* from PhieuChi_NCC_CT A left join PhieuChi_NCC B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Chi = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Thu = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoChi"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy,B.LyDoChi, A.* from PhieuChi_NoiBo_CT A left join PhieuChi_NoiBo B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Chi = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Thu = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoChi"]?.ToString()
                };

                list.Add(obj);
            }
            sql = $@"Select B.HinhThucTT,B.DienGiai,B.SoTK,B.TenNganHang,B.ChuTaiKhoan,B.NgayHachToan, B.MaQuy,B.LyDoChi, A.* from PhieuChi_Con_CT A left join PhieuChi_Con B on B.SoChungTu=A.SoChungTu where B.SoChungTu is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and A.MaDoiTuong = N'{madoituong}'";
            }
            if (!string.IsNullOrEmpty(hinhthucTT))
            {
                sql += $@" and B.HinhThucTT = N'{hinhthucTT}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                string doiTuong = item["DoiTuong"]?.ToString();
                string maDT = item["MaDoiTuong"]?.ToString();
                string tenDT = "";
                string tenQuy = "";
                string maQuy = item["MaQuy"]?.ToString();

                if (doiTuong == "KH")
                {
                    DataRow[] rows = table_DanhSachKhachHang.Select($"MaKhachHang = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NCC")
                {
                    DataRow[] rows = table_DanhSachNhaCungCap.Select($"MaNhaCungCap = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenVietTat"].ToString();
                }
                else if (doiTuong == "NV")
                {
                    DataRow[] rows = table_NhanVien.Select($"MaNhanVien = '{maDT}'");
                    if (rows.Length > 0)
                        tenDT = rows[0]["TenNhanVien"].ToString();
                }
                if (maQuy != "")
                {
                    DataRow[] rows = table_Quy.Select($"MaQuy = '{maQuy}'");
                    if (rows.Length > 0)
                        tenQuy = rows[0]["TenQuy"].ToString();
                }

                var obj = new BaoCaoSoQuy
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoChungTu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Chi = item["ThanhTien"] == DBNull.Value ? 0 : Convert.ToDouble(item["ThanhTien"]),
                    Thu = 0,
                    Ton = 0,
                    DoiTuong = tenDT,
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = doiTuong,
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = tenQuy,
                    LyDo = item["LyDoChi"]?.ToString()
                };

                list.Add(obj);
            }
            return list;
        }
        public void Dispose()
        {
            if (cls != null)
            {
                cls.Dispose();
                cls = null;
            }
        }
    }
}
