using Quản_lý_vudaco.services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class khachhang : IDisposable
    {

        private clsKetNoi cls;
        public khachhang()
        {
            cls = new clsKetNoi();
        }
        public DataTable dt_BangFileDebitDaTao_KH(DateTime TuNgay, DateTime DenNgay)
        {
            string sql = $@"
            SELECT kh.*,  0 AS Chon
            FROM FileDebit_KoHoaDon_KH kh
            WHERE kh.NgayTao >= '{TuNgay:yyyy-MM-dd}'
              AND kh.NgayTao <= '{DenNgay:yyyy-MM-dd}'";

            return cls.LoadTable(sql);
        }
        public DataRow GetDetailkh(string makh)
        {
            using (var _db = new clsKetNoi())
            {
                return _db.GetSingleRecord("DanhSachKhachHang", makh, "MaKhachHang");
            }
        }
        public List<CongNoChiTietKH> CongNoChiTietKH(DateTime TuNgay, DateTime? DenNgay = null, string makh = null, int dauky = 0)
        {
            List<CongNoChiTietKH> list = new List<CongNoChiTietKH>();
            string sql = $@"select ttf.MaKhachHang,fd.*,fdct.*,ttf.SoToKhai,ttf.SoBill,ttf.SoCont,ttf.TenSales,a.LoaiXe_KH,
                     a.BienSoXe,
                     ttf.SoLuong,
                     a.LoaiXe_NCC,
                     a.LuongHangVe,
                     a.MaDieuXe,
                     a.TuyenVC
            from FileDebitChiTiet fdct left join FileDebit fd on fd.IDDeBit = fdct.IDDeBit
            left join ThongTinFile ttf on ttf.IDLoHang = fd.IDLoHang left join FileGia fg on fg.IDLoHang = ttf.IDLoHang left join BangDieuXe a on a.MaDieuXe = fg.MaDieuXe
            where fd.SoFile is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and fd.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}' and fd.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and fd.ThoiGianLap < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(makh))
            {
                sql += $@" and ttf.MaKhachHang = N'{makh}'";
            }

            DataTable  table = cls.LoadTable(sql);

            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietKH
                {
                    IDDeBit = item["IDDeBit"] != DBNull.Value ? Convert.ToInt32(item["IDDeBit"]) : 0,
                    IDGia = item["IDGia"] != DBNull.Value ? Convert.ToInt32(item["IDGia"]) : 0,
                    IDLoHang = item["IDLoHang"] != DBNull.Value ? Convert.ToInt32(item["IDLoHang"]) : 0,
                    SoFile = item["SoFile"].ToString(),
                    ThoiGianLap = item["ThoiGianLap"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianLap"]) : DateTime.MinValue,
                    NgayHachToan = item["ThoiGianLap"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianLap"]) : DateTime.MinValue,
                    NguoiLap = item["NguoiLap"].ToString(),
                    SoHoaDon = item["SoHoaDon"].ToString(),
                    NgayHoaDon = item["NgayHoaDon"] != DBNull.Value ? Convert.ToDateTime(item["NgayHoaDon"]) : DateTime.MinValue,
                    MaDieuXe = item["MaDieuXe"].ToString(),
                    IDDeBitCT = item["IDDeBitCT"] != DBNull.Value ? Convert.ToInt32(item["IDDeBitCT"]) : 0,
                    TenDichVu = item["TenDichVu"].ToString(),
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    LaPhiChiHo = item["LaPhiChiHo"] != DBNull.Value ? Convert.ToInt32(item["LaPhiChiHo"]) : 0,
                    DoiTru = item["DoiTru"].ToString(),
                    PhiDichVu_DoiTru = item["PhiDichVu_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiDichVu_DoiTru"]) : 0,
                    MaKhachHang = item["MaKhachHang"].ToString(),
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    NoiDung = item["TenDichVu"].ToString(),
                    TenSales = item["TenSales"].ToString(),
                    LoaiXe_KH = item["LoaiXe_KH"].ToString(),
                    LoaiXe_NCC = item["LoaiXe_NCC"].ToString(),
                    SoLuong = item["SoLuong"].ToString(),
                    TuyenVC = item["TuyenVC"].ToString(),
                    BienSoXe = item["BienSoXe"].ToString(),
                    Key = "debitchitietkh",
                    ID = int.Parse(item["IDDeBitCT"].ToString()),
                };

                list.Add(obj);
            }
           
            sql = $@"SELECT 
                     ttf.SoToKhai,
	                 ttf.SoBill,
	                 ttf.SoCont,
                     ttf.TenSales,
                     a.IDBangPhi,
                     a.LaiXeThuCuoc,
                     a.LoaiXe_KH,
                     a.LoaiXe_NCC,
                     a.LuongHangVe,
                     a.MaDieuXe,
                     b.MaKhachHang,
                     b.TenKhachHang,
                     c.MaNhaCungCap,
                     c.TenNhaCungCap,
                     a.Ngay,
                     a.NguoiDuyet,
                     a.NguoiTao,
                     a.SoFile,
                     a.ThoiGianDuyet,
                     a.TienAn,
                     ttf.SoLuong,
                     a.QuaDem,
                     a.TienLuat,
                     a.TienVe,
                     a.TTHQ,
                     a.TuyenVC,
                     a.BienSoXe,
                     a.CuocBan,
                     a.CuocMua,
                     a.DiemTraHang,
                     a.DuyetChi,
                     a.LaiXe,
                     ISNULL(b.TenVietTat, '')  AS TenVietTat,
                     a.GhiChu,
                     CAST(0 AS bit) AS Chon,
                     'DieuXe' AS Bang
                     FROM BangDieuXe a
                     LEFT JOIN DanhSachKhachHang b ON a.MaKhachHang = b.MaKhachHang
                     LEFT JOIN DanhSachNhaCungCap c ON a.MaNhaCungCap = c.MaNhaCungCap
                     LEFT JOIN FileDebit_KoHoaDon_KH fd ON fd.MaDieuXe = a.MaDieuXe 
                     LEFT JOIN ThongTinFile ttf ON ttf.SoFile = a.SoFile 
                     WHERE
                     (
                     a.SoFile IS NULL 
                     OR TRY_CAST(a.SoFile AS NVARCHAR) = '' 
                     OR TRY_CAST(a.SoFile AS INT) = 0
                     )
                     AND fd.MaDieuXe IS NULL";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and a.Ngay >= '{TuNgay:yyyy-MM-dd}' and a.Ngay <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and a.Ngay < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(makh))
            {
                sql += $@" and b.MaKhachHang = N'{makh}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietKH
                {
                    IDBangPhi = item["IDBangPhi"] != DBNull.Value ? Convert.ToInt32(item["IDBangPhi"]) : 0,
                    LaiXeThuCuoc = item["LaiXeThuCuoc"] != DBNull.Value ? Convert.ToDouble(item["LaiXeThuCuoc"]) : 0,
                    LoaiXe_KH = item["LoaiXe_KH"].ToString(),
                    LoaiXe_NCC = item["LoaiXe_NCC"].ToString(),
                    LuongHangVe = item["LuongHangVe"] != DBNull.Value ? Convert.ToInt32(item["LuongHangVe"]) : 0,
                    MaDieuXe = item["MaDieuXe"].ToString(),
                    MaKhachHang = item["MaKhachHang"].ToString(),
                    TenKhachHang = item["TenKhachHang"].ToString(),
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    TenNhaCungCap = item["TenNhaCungCap"].ToString(),
                    Ngay = item["Ngay"] != DBNull.Value ? Convert.ToDateTime(item["Ngay"]) : DateTime.MinValue,
                    NgayHachToan = item["Ngay"] != DBNull.Value ? Convert.ToDateTime(item["Ngay"]) : DateTime.MinValue,
                    NguoiDuyet = item["NguoiDuyet"].ToString(),
                    NguoiTao = item["NguoiTao"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    ThoiGianDuyet = item["ThoiGianDuyet"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianDuyet"]) : DateTime.MinValue,
                    TienAn = item["TienAn"] != DBNull.Value ? Convert.ToDouble(item["TienAn"]) : 0,
                    QuaDem = item["QuaDem"] != DBNull.Value ? Convert.ToDouble(item["QuaDem"]) : 0,
                    TienLuat = item["TienLuat"] != DBNull.Value ? Convert.ToDouble(item["TienLuat"]) : 0,
                    TienVe = item["TienVe"] != DBNull.Value ? Convert.ToDouble(item["TienVe"]) : 0,
                    TTHQ = item["TTHQ"] != DBNull.Value ? Convert.ToDouble(item["TTHQ"]) : 0,
                    TuyenVC = item["TuyenVC"].ToString(),
                    TenDichVu = item["TuyenVC"].ToString(), // Nếu thực tế khác, map đúng cột TenDichVu
                    BienSoXe = item["BienSoXe"].ToString(),
                    CuocBan = item["CuocBan"] != DBNull.Value ? Convert.ToDouble(item["CuocBan"]) : 0,
                    CuocMua = item["CuocMua"] != DBNull.Value ? Convert.ToDouble(item["CuocMua"]) : 0,
                    SoTien = item["CuocBan"] != DBNull.Value ? Convert.ToDouble(item["CuocBan"]) : 0,
                    VAT = 0,
                    LaPhiChiHo = 0,
                    ThanhTien = item["CuocBan"] != DBNull.Value ? Convert.ToDouble(item["CuocBan"]) : 0,
                    DiemTraHang = item["DiemTraHang"].ToString(),
                    DuyetChi = item["DuyetChi"].ToString(),
                    LaiXe = item["LaiXe"].ToString(),
                    TenVietTat = item["TenVietTat"].ToString(),
                    GhiChu = item["GhiChu"].ToString(),
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    TenSales = item["TenSales"].ToString(),
                    SoLuong = item["SoLuong"].ToString(),
                    Key = "bangdieuxekh",
                    ID = int.Parse(item["IDBangPhi"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"select fd.*,ttf.SoToKhai,
	                 ttf.SoBill,
	                 ttf.SoCont,
                     ttf.TenSales,
                     a.LoaiXe_KH,
                     a.BienSoXe,
                     ttf.SoLuong
                     from FileDebit_KoHoaDon_KH fd LEFT JOIN BangDieuXe a ON fd.MaDieuXe = a.MaDieuXe LEFT JOIN ThongTinFile ttf ON ttf.SoFile = a.SoFile where fd.MaKhachHang IS NOT NULL AND LTRIM(RTRIM(fd.MaKhachHang)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and fd.NgayTao >= '{TuNgay:yyyy-MM-dd}' and fd.NgayTao <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and fd.NgayTao < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(makh))
            {
                sql += $@" and fd.MaKhachHang = N'{makh}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietKH
                {
                    IDDeBit = item["IDDeBit"] != DBNull.Value ? Convert.ToInt32(item["IDDeBit"]) : 0,
                    MaDieuXe = item["MaDieuXe"].ToString(),
                    MaKhachHang = item["MaKhachHang"].ToString(),
                    LoaiXe_KH = item["LoaiXe_KH"].ToString(),
                    BienSoXe = item["BienSoXe"].ToString(),
                    TuyenVC = item["TuyenVC"].ToString(),
                    CuocMua = item["CuocMua"] != DBNull.Value ? Convert.ToDouble(item["CuocMua"]) : 0,
                    CuocBan = item["CuocBan"] != DBNull.Value ? Convert.ToDouble(item["CuocBan"]) : 0,
                    LaiXeThuCuoc = item["LaiXeThuCuoc"] != DBNull.Value ? Convert.ToDouble(item["LaiXeThuCuoc"]) : 0,
                    NguoiTao = item["NguoiTao"].ToString(),
                    NgayTao = item["NgayTao"] != DBNull.Value ? Convert.ToDateTime(item["NgayTao"]) : DateTime.MinValue,
                    NgayHachToan = item["NgayTao"] != DBNull.Value ? Convert.ToDateTime(item["NgayTao"]) : DateTime.MinValue,
                    TenDichVu = item["TenDichVu"].ToString(),
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    GhiChu = item["GhiChu"].ToString(),
                    PhiCom = item["PhiCom"] != DBNull.Value ? Convert.ToDouble(item["PhiCom"]) : 0,
                    DoanhThuThuan = item["DoanhThuThuan"] != DBNull.Value ? Convert.ToDouble(item["DoanhThuThuan"]) : 0,
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    SoHoaDon = item["SoHoaDon"].ToString(),
                    DoiTru = item["DoiTru"].ToString(),
                    PhiDichVu_DoiTru = item["PhiDichVu_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiDichVu_DoiTru"]) : 0,
                    // PhiChiHo_DoiTru = item["PhiChiHo_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiChiHo_DoiTru"]) : 0,
                    NgayHoaDon = item["NgayHoaDon"] != DBNull.Value ? Convert.ToDateTime(item["NgayHoaDon"]) : DateTime.MinValue,
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    TenSales = item["TenSales"].ToString(),
                    SoLuong = item["SoLuong"].ToString(),
                    NoiDung = item["TenDichVu"].ToString(),
                    Key = "FileDebit_KoHoaDon_KH_kh",
                    ID = int.Parse(item["IDDeBit"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"select pct.IDCT,pc.MaChi,pc.SoChungTu,pct.SoFile,pct.MaDieuXe,pct.SoTien,pct.ThanhTien,pct.VAT,pct.MaDoiTuong,pct.TenDoiTuong,pc.NgayHachToan,pc.DienGiai,pc.HinhThucTT,pc.ChuTaiKhoan,pc.LyDoChi from PhieuChi_CT pct left join PhieuChi pc on pct.SoChungTu = pc.SoChungTu where pc.MaChi = N'003' and pc.LyDoChi = N'Chi hộ khách hàng' and pct.MaDoiTuong IS NOT NULL
                          AND LTRIM(RTRIM(pct.MaDoiTuong)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and pc.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and pc.NgayHachToan <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and pc.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(makh))
            {
                sql += $@" and pct.MaDoiTuong = N'{makh}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietKH
                {
                    SoChungTu = item["SoChungTu"].ToString(),
                    NgayHachToan = item["NgayHachToan"] != DBNull.Value ? Convert.ToDateTime(item["NgayHachToan"]) : DateTime.MinValue,
                    MaChi = item["MaChi"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    NoiDung = item["DienGiai"].ToString(),
                    MaDieuXe = item["MaDieuXe"].ToString(),
                    DienGiai = item["DienGiai"].ToString()+" "+ item["LyDoChi"].ToString(),
                    LaPhiChiHo = 1,
                    HinhThucTT = item["HinhThucTT"].ToString(),
                    ChuTaiKhoan = item["ChuTaiKhoan"].ToString(),
                    TenKhachHang = item["TenDoiTuong"].ToString(),
                    MaKhachHang = item["MaDoiTuong"].ToString(),
                    TongTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                   // Type = 4, // 4: Chi hộ khách hàng
                    ID = int.Parse(item["IDCT"].ToString()),
                    Key = "phieuchihokh"
                };

                list.Add(obj);
            }
            sql = $@"select A.*,B.DienGiai,B.LyDoThu,B.NgayHachToan,B.MaThu from PhieuThu_CT A left join PhieuThu B on A.SoChungTu = B.SoChungTu  where B.MaThu='004' and A.DoiTuong ='KH'";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and B.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and B.NgayHachToan <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and B.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(makh))
            {
                sql += $@" and A.MaDoiTuong = N'{makh}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietKH
                {
                    SoChungTu = item["SoChungTu"].ToString(),
                    NgayHachToan = item["NgayHachToan"] != DBNull.Value ? Convert.ToDateTime(item["NgayHachToan"]) : DateTime.MinValue,
                    MaThu = item["MaThu"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    NoiDung = item["DienGiai"].ToString(),
                    MaDieuXe = item["SoFile"].ToString(),
                    TuyenVC = item["LyDoThu"].ToString(),
                    DienGiai = item["DienGiai"].ToString(),
                    LaPhiChiHo = item["LaPhieuChiHo"] != DBNull.Value ? Convert.ToInt32(item["LaPhieuChiHo"]) : 0,
                    TenKhachHang = item["TenDoiTuong"].ToString(),
                    MaKhachHang = item["MaDoiTuong"].ToString(),
                    TongTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    Type = 5, // 5: phieu thu khách hàng
                    ID = int.Parse(item["IDCT"].ToString()),
                    Key = "phieuthuchitietkh",
                    KeyName = item["KeyName"].ToString(),
                    IDKey = item["IDKey"] == DBNull.Value ? 0 : Convert.ToInt32(item["IDKey"])
                };

                list.Add(obj);
            }

            return list;
        }
        public DataTable BangFileGiaDaTao_ChiTiet(int IDGia)
        {
            string sql = $@"
                select dx.MaNhaCungCap,fgct.*
                from FileGiaChiTiet fgct
                left join FileGia fg on fg.IDGia = fgct.IDGia
                left join (
                    select SoFile, max(MaNhaCungCap) as MaNhaCungCap
                    from BangDieuXe
                    group by SoFile
                ) dx on dx.SoFile = fg.SoFile
                where fg.IDGia ='{IDGia}'";
            return cls.LoadTable(sql);
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
