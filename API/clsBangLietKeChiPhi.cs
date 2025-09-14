using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    public class clsBangLietKeChiPhi
    {
        private int iDLoHang;
        private string maKhachHang;
        private string soFile;
        private string soToKhai;
        private string soBill;
        private string soLuong;
        private string soCont;
        private string tenSales;
        private string tenGiaoNhan;
        private string loaiHang;
        private string tinhChat;
        private int soLuongToKhai;
        private string loaiToKhai;
        private string nghiepVu;
        private string phatSinh;
        private double duyetUng;
        private string taiKhoanThucHien;
        private DateTime thoiGianThucHien;
        private string ghiChu;
        private bool chon;

        public int IDLoHang { get => iDLoHang; set => iDLoHang = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string SoFile { get => soFile; set => soFile = value; }
        public string SoToKhai { get => soToKhai; set => soToKhai = value; }
        public string SoBill { get => soBill; set => soBill = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string SoCont { get => soCont; set => soCont = value; }
        public string TenSales { get => tenSales; set => tenSales = value; }
        public string TenGiaoNhan { get => tenGiaoNhan; set => tenGiaoNhan = value; }
        public string LoaiHang { get => loaiHang; set => loaiHang = value; }
        public string TinhChat { get => tinhChat; set => tinhChat = value; }
        public int SoLuongToKhai { get => soLuongToKhai; set => soLuongToKhai = value; }
        public string LoaiToKhai { get => loaiToKhai; set => loaiToKhai = value; }
        public string NghiepVu { get => nghiepVu; set => nghiepVu = value; }
        public string PhatSinh { get => phatSinh; set => phatSinh = value; }
        public double DuyetUng { get => duyetUng; set => duyetUng = value; }
        public string TaiKhoanThucHien { get => taiKhoanThucHien; set => taiKhoanThucHien = value; }
        public DateTime ThoiGianThucHien { get => thoiGianThucHien; set => thoiGianThucHien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public bool Chon { get => chon; set => chon = value; }
    }
}