using DevExpress.Xpo;
using System;
using System.Data;

namespace Quản_lý_vudaco.services
{
    public class phieuchi : IDisposable
    {
        private clsKetNoi cls;

        public phieuchi()
        {
            cls = new clsKetNoi();
        }
        public DataTable DanhSachPhieuChi_Con_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = $@"
            SELECT  
                ((A.VAT * A.SoTien) / 100) AS TienVAT,
                A.*,
                C.TenKhachHang,
                C.DiaChi,
                D.HoVaTen,
                B.NgayHachToan,
                B.HinhThucTT
            FROM PhieuChi_Con_CT A
            LEFT JOIN PhieuChi_Con B ON A.SoChungTu = B.SoChungTu
            LEFT JOIN DanhSachKhachHang C ON C.MaKhachHang = A.MaDoiTuong AND DoiTuong = 'KH'
            LEFT JOIN DanhSachTaiKhoan D ON D.TaiKhoan = B.NguoiTao
            WHERE A.SoChungTu = N'{SoChungTu}'";   // thêm N để hỗ trợ Unicode
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
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