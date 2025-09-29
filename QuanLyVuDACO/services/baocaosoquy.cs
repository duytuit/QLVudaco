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
            string sql = $@"";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                DateTime _DenNgay = DenNgay.Value.AddDays(1);
                sql += $@" and fd.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and fd.NgayHachToan <= '{_DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and fd.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(madoituong))
            {
                sql += $@" and fd.MaDoiTuong = N'{madoituong}'";
            }
            DataTable table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new BaoCaoTienMat
                {
                    NgayHachToan = item["NgayHachToan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["NgayHachToan"]),
                    SoPhieu = item["SoPhieu"]?.ToString(),
                    DienGiai = item["DienGiai"]?.ToString(),
                    Thu = item["Thu"] == DBNull.Value ? 0 : Convert.ToDouble(item["Thu"]),
                    Chi = item["Chi"] == DBNull.Value ? 0 : Convert.ToDouble(item["Chi"]),
                    Ton = 0,
                    DoiTuong = item["DoiTuong"]?.ToString(),
                    MaDoiTuong = item["MaDoiTuong"]?.ToString(),
                    LoaiDoiTuong = item["LoaiDoiTuong"]?.ToString(),
                    MaQuy = item["MaQuy"]?.ToString(),
                    TenQuy = item["TenQuy"]?.ToString(),
                    LyDo = item["LyDo"]?.ToString()
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
