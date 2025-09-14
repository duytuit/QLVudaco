using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    public class clsPhoiNangHa
    {
        private string soFile;
        private string tenKhachHang;
        private string soCont;
        private string soLuong;
        private float soTien;
        private string soHoaDon;
        private string ghiChu;
        private DateTime ngayTaoBangKe;

        public string SoFile { get => soFile; set => soFile = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string SoCont { get => soCont; set => soCont = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public float SoTien { get => soTien; set => soTien = value; }
        public string SoHoaDon { get => soHoaDon; set => soHoaDon = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public DateTime NgayTaoBangKe { get => ngayTaoBangKe; set => ngayTaoBangKe = value; }
    }
}