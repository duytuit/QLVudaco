using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
   public class lietkechiphi : IDisposable
    {
        private clsKetNoi cls;
        public lietkechiphi()
        {
            cls = new clsKetNoi();
        }
        public DataTable DsThongTinFile_Full_TheoIDLoHang(int IDLoHang)
        {
            string sql = $@"
                SELECT 
                    a.IDLoHang,
                    a.ThoiGianThucHien,
                    a.SoBill,
                    a.SoFile,
                    a.SoToKhai,
                    a.SoLuong,
                    a.SoCont,
                    ISNULL(kh.TenKhachHang, '') AS TenKhachHang,
                    a.TenSales,
                    STUFF((
                        SELECT ',' + nv.TenNhanVien
                        FROM ThongTinFile_NguoiGiaoNhan gn
                        INNER JOIN NhanVien nv ON gn.MaNhanVien = nv.MaNhanVien
                        WHERE gn.SoFile = a.SoFile
                        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, ''
                    ) AS TenGiaoNhan,
                    CASE a.LoaiHang 
                        WHEN 'HangLe' THEN N'Hàng Lẻ'
                        WHEN 'HangCont' THEN N'Hàng Cont'
                    END AS LoaiHang,
                    CASE a.TinhChat 
                        WHEN 'HangNhap' THEN N'Hàng nhập'
                        WHEN 'HangXuat' THEN N'Hàng xuất'
                    END AS TinhChat,
                    a.SoLuongToKhai,
                    CASE a.LoaiToKhai
                        WHEN '0' THEN N'Luồng xanh'
                        WHEN '1' THEN N'Luồng vàng'
                        WHEN '2' THEN N'Luồng đỏ'
                    END AS LoaiToKhai,
                    CASE a.NghiepVu
                        WHEN '0' THEN N'Thông quan'
                        WHEN '1' THEN N'Đổi lệnh dưới kho'
                        WHEN '2' THEN N'Rút ruột'
                        WHEN '3' THEN N'Thông quan kèm kiểm dịch/KTC'
                        WHEN '4' THEN N'Không có trucking'
                    END AS NghiepVu,
                    CASE a.PhatSinh
                        WHEN '0' THEN N'Nhiều tờ khai'
                        WHEN '1' THEN N'Không'
                    END AS PhatSinh,
                    ISNULL((
                        SELECT SUM(ISNULL(gn.DuyetUng,0)) 
                        FROM ThongTinFile_NguoiGiaoNhan gn 
                        WHERE gn.SoFile = a.SoFile
                    ),0) AS DuyetUng,
                    ISNULL((
                        SELECT TOP 1 fg.IDGia 
                        FROM FileGia fg 
                        WHERE fg.IDLoHang = a.IDLoHang
                    ),0) AS IDGia
                FROM ThongTinFile a
                LEFT JOIN DanhSachKhachHang kh ON a.MaKhachHang = kh.MaKhachHang
                WHERE a.IDLoHang = {IDLoHang}";

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
