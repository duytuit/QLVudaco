using DevExpress.Xpo;
using System;
using System.Data;

namespace Quản_lý_vudaco.services
{
    public class phieumuaban : IDisposable
    {
        private clsKetNoi cls;

        public phieumuaban()
        {
            cls = new clsKetNoi();
        }
        public DataTable DanhSachMuaHang_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            DateTime _DenNgay = DenNgay.AddDays(1);
            string sql = $@"
                SELECT 
                    A.[IDPhieuMua],
                    A.[SoPhieu],
                    A.[NgayMua],
                    A.[MaNhaCC],
                    A.[MaNhanVien],
                    A.[NguoiMuaHang],
                    A.[MaChi],
                    A.[MaChiCon],
                    A.[DienGiai],
                    A.[NguoiTao],
                    SUM(ISNULL(B.SoTien, 0)) AS SoTien,
                    SUM(ISNULL(B.SoTien * B.VAT / 100.0, 0)) AS TienVAT,
                    SUM(ISNULL(B.SoTien, 0)) + SUM(ISNULL(B.SoTien * B.VAT / 100.0, 0)) AS ThanhTien,
                    MAX(ISNULL(B.VAT, 0)) AS VAT
                FROM PhieuMua A
                LEFT JOIN PhieuMuaCT B 
                    ON A.[IDPhieuMua] = B.[IDPhieuMua]
                WHERE A.[NgayMua] BETWEEN '{TuNgay:yyyy-MM-dd}' AND '{_DenNgay:yyyy-MM-dd}'
                GROUP BY 
                    A.[IDPhieuMua],
                    A.[SoPhieu],
                    A.[NgayMua],
                    A.[MaNhaCC],
                    A.[MaNhanVien],
                    A.[NguoiMuaHang],
                    A.[MaChi],
                    A.[MaChiCon],
                    A.[DienGiai],
                    A.[NguoiTao]
                ORDER BY A.[NgayMua] DESC";

            DataTable dt = cls.LoadTable(sql);
            return dt;
        }
        public DataTable DanhSachBanHang_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            DateTime _DenNgay = DenNgay.AddDays(1);
            string sql = $@"
                SELECT 
                    A.[IDPhieuBan],
                    A.[SoPhieu],
                    A.[NgayBan],
                    A.[DoiTuong],
                    A.[MaNhaCC],
                    A.[MaNhanVien],
                    A.[NguoiBanHang],
                    A.[MaThu],
                    A.[DienGiai],
                    A.[NguoiTao],
                    SUM(ISNULL(B.SoTien, 0)) AS SoTien,
                    SUM(ISNULL(B.SoTien * B.VAT / 100.0, 0)) AS TienVAT,
                    SUM(ISNULL(B.SoTien, 0)) + SUM(ISNULL(B.SoTien * B.VAT / 100.0, 0)) AS ThanhTien,
                    MAX(ISNULL(B.VAT, 0)) AS VAT
                FROM PhieuBan A
                LEFT JOIN PhieuBanCT B 
                    ON A.[IDPhieuBan] = B.[IDPhieuBan]
                WHERE A.[NgayBan] BETWEEN '{TuNgay:yyyy-MM-dd}' AND '{_DenNgay:yyyy-MM-dd}'
                GROUP BY 
                    A.[IDPhieuBan],
                    A.[SoPhieu],
                    A.[NgayBan],
                    A.[DoiTuong],
                    A.[MaNhaCC],
                    A.[MaNhanVien],
                    A.[NguoiBanHang],
                    A.[MaThu],
                    A.[DienGiai],
                    A.[NguoiTao]
                ORDER BY A.[NgayBan] DESC";


            DataTable dt = cls.LoadTable(sql);
            return dt;
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