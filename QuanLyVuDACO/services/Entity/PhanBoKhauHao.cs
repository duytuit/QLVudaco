using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class PhanBoKhauHao
    {
        public int ID { get; set; }
        public string SoChungTu { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public int Loai { get; set; }
        public string GhiChu { get; set; }

        public string DienGiai { get; set; }
        
    }
}
