using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class nhacungcapDto
    {
        public int ID { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string STK { get; set; }
        public int? SoNgayDuocNo { get; set; }
        public decimal? NoToiDa { get; set; }
        public bool? LaKhachHang { get; set; }
        public string GhiChu { get; set; }
        public string TenVietTat { get; set; }
    }
}
