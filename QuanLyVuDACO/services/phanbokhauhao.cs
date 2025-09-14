using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class phanbokhauhao:IDisposable
    {
        private clsKetNoi cls;
        public phanbokhauhao()
        {
            cls = new clsKetNoi();
        }
        public DataTable GetPhanBoKhauHao(int Loai = 0)
        {
            string sql = "SELECT kh.*,(select sum(pbct.GiaTriKhauHaoThang) from PhanBoKhauHao_CT pbct where pbct.IDPhanBoKhauHao = kh.ID) AS GiaTriKhauHaoThang_CT FROM PhanBoKhauHao kh";
            if (Loai > 0)
            {
                sql += $@" WHERE Loai = '{Loai}'";
            }
            return cls.LoadTable(sql);
        }
        public DataTable GetChiTietPhanBoKhauHao(int idPhanBo)
        {
            string sql = $@"SELECT ct.*,kh.*
             FROM [vua45987_vudaco].[dbo].[PhanBoKhauHao_CT] ct left join KhauHao kh on kh.id = ct.IDKhauHao where IDPhanBoKhauHao = '{idPhanBo}'";
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
