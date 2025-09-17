using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class khachangDto
    {
        public int ID { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string STK { get; set; }
        public int SoNgayDuocNo { get; set; }
        public decimal NoToiDa { get; set; }
        public bool LaNhaCungCap { get; set; }
        public string GhiChu { get; set; }
        public string TenVietTat { get; set; }
    }
}
