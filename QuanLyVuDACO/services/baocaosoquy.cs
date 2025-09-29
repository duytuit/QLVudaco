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
        public List<BaoCaoTienMat> BaoCaoQuyTM(DateTime TuNgay, DateTime? DenNgay = null, string madoituong = null, int dauky = 0)
        {
            List<BaoCaoTienMat> list = new List<BaoCaoTienMat>();
            string sql = $@"select fd.*,ttf.SoToKhai,
	                 ttf.SoBill,
	                 ttf.SoCont,
                     ttf.TenSales,
                     a.LoaiXe_KH,
                     a.BienSoXe,
                     ttf.SoLuong
                     from FileDebit_KoHoaDon_KH fd LEFT JOIN BangDieuXe a ON fd.MaDieuXe = a.MaDieuXe LEFT JOIN ThongTinFile ttf ON ttf.SoFile = a.SoFile where fd.MaKhachHang IS NOT NULL AND LTRIM(RTRIM(fd.MaKhachHang)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and fd.NgayTao >= '{TuNgay:yyyy-MM-dd}' and fd.NgayTao <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and fd.NgayTao < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and fd.MaKhachHang = N'{madoituong}'";
            }
            DataTable table = cls.LoadTable(sql);
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
