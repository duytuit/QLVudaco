using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class BaoCaoTienMat
    {
        public DateTime NgayHachToan { get; set; }
        public string SoPhieu { get; set; }
        public string DienGiai { get; set; }
        public double Thu { get; set; }
        public double Chi { get; set; }
        public double Ton { get; set; }
        public string MaDoiTuong { get; set; }
        public string DoiTuong { get; set; }
        public string LoaiDoiTuong { get; set; }
        public string MaQuy { get; set; }
        public string TenQuy { get; set; }
        public string LyDo { get; set; }
    }
}
