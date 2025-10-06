using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class doitru : IDisposable
    {
        private clsKetNoi cls;
        public doitru()
        {
            cls = new clsKetNoi();
        }
        public DataTable GetData(DateTime TuNgay, DateTime? DenNgay = null)
        {
            string sql = "SELECT dt.*,ncc.SoChungTu as ncc,kh.SoChungTu as kh FROM DoiTruCongNo dt left join PhieuChi_NCC ncc on ncc.IDDoiTru = dt.ID left join PhieuThu kh on kh.IDDoiTru = dt.ID where dt.ID is not null";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" AND dt.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' AND dt.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
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
