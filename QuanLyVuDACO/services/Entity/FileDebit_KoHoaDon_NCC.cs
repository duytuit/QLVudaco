using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class FileDebit_KoHoaDon_NCC
    {
        public int IDDeBit { get; set; }
        public string MaDieuXe { get; set; }
        public string MaNhaCungCap { get; set; }
        public string LoaiXe_KH { get; set; }
        public string TuyenVC { get; set; }
        public Nullable<double> CuocMua { get; set; }
        public Nullable<double> CuocBan { get; set; }
        public Nullable<double> LaiXeThuCuoc { get; set; }
        public string NguoiTao { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string TenDichVu { get; set; }
        public Nullable<double> SoTien { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public string SoHoaDon { get; set; }
        public string DoiTru { get; set; }
        public Nullable<double> PhiChiHo_DoiTru { get; set; }
        public string SoFile { get; set; }
        public Nullable<double> PhiCom { get; set; }
        public Nullable<double> DoanhThuThuan { get; set; }
        public int ver { get; set; }
    }
}
