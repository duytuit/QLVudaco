using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    public class clsDsThongTinFile_Full
    {
        private int iDLoHang;
        private string soBill;
        private string soFile;
        private string soToKhai;
        private string soLuong;
        private string soCont;
        private float duyetUng;
        private string tenKhachHang;

        public int IDLoHang { get => iDLoHang; set => iDLoHang = value; }
        public string SoBill { get => soBill; set => soBill = value; }
        public string SoFile { get => soFile; set => soFile = value; }
        public string SoToKhai { get => soToKhai; set => soToKhai = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string SoCont { get => soCont; set => soCont = value; }
        public float DuyetUng { get => duyetUng; set => duyetUng = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
    }
}