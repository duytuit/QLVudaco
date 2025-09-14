using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class FileDebitChiTiet
    {
        public int IDDeBitCT { get; set; }
        public Nullable<int> IDDeBit { get; set; }
        public string TenDichVu { get; set; }
        public Nullable<double> SoTien { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> LaPhiChiHo { get; set; }
        public string SoHoaDon { get; set; }
        public string DoiTru { get; set; }
        public string PhiDichVu_DoiTru { get; set; }
        public string MaNhaCungCap { get; set; }
        public int IDKey { get; set; }
        public string KeyName { get; set; }
    }
}
