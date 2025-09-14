using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    public class clsPhanBo_KhauHao_Tong
    {
        private string soChungTu;
        private DateTime ngay;
        private string noiDungPhanBo;
        private double soTienPhanBo;
        private string nguoiTao;

        public string NguoiTao { get => nguoiTao; set => nguoiTao = value; }
        public string SoChungTu { get => soChungTu; set => soChungTu = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public string NoiDungPhanBo { get => noiDungPhanBo; set => noiDungPhanBo = value; }
        public double SoTienPhanBo { get => soTienPhanBo; set => soTienPhanBo = value; }
    }
}