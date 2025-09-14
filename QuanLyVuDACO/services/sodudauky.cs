using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class sodudauky : IDisposable
    {
        private clsKetNoi cls;
        public sodudauky()
        {
            cls = new clsKetNoi();
        }
        public DataTable GetDataKH(int? id = null, string orderBy = "ID DESC")
        {
            string sql = "SELECT sddk.*,kh.TenKhachHang FROM SoDuDauKy sddk left join DanhSachKhachHang kh on sddk.MaDoiTuong = kh.MaKhachHang where sddk.Loai=2 order by sddk.ID desc";
            return cls.LoadTable(sql);
        }
        public DataTable GetDataNCC(int? id = null, string orderBy = "ID DESC")
        {
            string sql = "SELECT sddk.*,ncc.TenNhaCungCap FROM SoDuDauKy sddk left join DanhSachNhaCungCap ncc on sddk.MaDoiTuong = ncc.MaNhaCungCap where sddk.Loai=1 order by sddk.ID desc";
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
