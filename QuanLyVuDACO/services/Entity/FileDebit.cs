using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class FileDebit
    {
        public int IDDeBit { get; set; }
        public int IDGia { get; set; }
        public Nullable<int> IDLoHang { get; set; }
        public string SoFile { get; set; }
        public Nullable<System.DateTime> ThoiGianLap { get; set; }
        public string NguoiLap { get; set; }
        public string SoHoaDon { get; set; }
        public Nullable<System.DateTime> NgayHoaDon { get; set; }
        public string MaDieuXe { get; set; }
        public int Type { get; set; }
    }
}
