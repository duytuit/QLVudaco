using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.Entity
{
    public class CongNoChiTietKH
    {
        public int IDGiaCT { get; set; }
        public int IDGia { get; set; }
        public string TenDichVu { get; set; }
        public double GiaMua { get; set; }
        public double GiaBan { get; set; }
        public string GhiChu { get; set; }
        public int IDCP { get; set; }
        public string MaNhaCungCap { get; set; }
        public string DoiTru { get; set; }
        public string TenSales { get; set; }
        public string PhiChiHo_DoiTru { get; set; }
        public string Tg { get; set; }
        public string LinhVucKhac { get; set; }
        public int IDLoHang { get; set; }
        public string SoFile { get; set; }
        public DateTime ThoiGianLap { get; set; }
        public string NguoiLap { get; set; }
        public string MaDieuXe { get; set; }
        public int Duyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string NguoiDuyet { get; set; }
        public string LyDoDuyet { get; set; }
        public int IDDeBit { get; set; }
        public string SoHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public int IDBangPhi { get; set; }
        public double LaiXeThuCuoc { get; set; }
        public string LoaiXe_KH { get; set; }
        public string LoaiXe_NCC { get; set; }
        public int LuongHangVe { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string TenNhaCungCap { get; set; }
        public DateTime Ngay { get; set; }
        public string NguoiTao { get; set; }
        public DateTime ThoiGianDuyet { get; set; }
        public double TienAn { get; set; }
        public double QuaDem { get; set; }
        public double TienLuat { get; set; }
        public double TienVe { get; set; }
        public double TTHQ { get; set; }
        public string TuyenVC { get; set; }
        public string BienSoXe { get; set; }
        public double CuocBan { get; set; }
        public double CuocMua { get; set; }
        public string DiemTraHang { get; set; }
        public string DuyetChi { get; set; }
        public string LaiXe { get; set; }
        public string TenVietTat { get; set; }
        public int IDPhieuChiNCC { get; set; }
        public string SoChungTu { get; set; }
        public string SoCont { get; set; }
        public DateTime NgayHachToan { get; set; }
        public string MaChi { get; set; }
        public string MaThu { get; set; }
        public string LyDoChi { get; set; }
        public string DienGiai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public int IDPhieuChi { get; set; }
        public string NguoiNhan { get; set; }
        public string MaQuy { get; set; }
        public string HinhThucTT { get; set; }
        public string SoTK { get; set; }
        public string TenNganHang { get; set; }
        public string ChiNhanh { get; set; }
        public string ChuTaiKhoan { get; set; }
        public double SoTien { get; set; }
        public double VAT { get; set; }
        public double ThanhTien { get; set; }
        public double PhiCom { get; set; }
        public double DoanhThuThuan { get; set; }
        public double PhiDichVu_DoiTru { get; set; }
        public double TongPhi_VAT { get; set; }
        public double TongPhiChiHo { get; set; }
        public double TongChiPhiLoHang { get; set; }
        public int IDDeBitCT { get; set; }
        public int LaPhiChiHo { get; set; }
        public int IDPhieuMua { get; set; }
        public string SoPhieu { get; set; }
        public DateTime NgayMua { get; set; }
        public string MaNhanVien { get; set; }
        public string NguoiMuaHang { get; set; }
        public string MaChiCon { get; set; }
        public string SoToKhai { get; set; }
        public string SoBill { get; set; }
        public string DoiTuong { get; set; }
        public string DiaChi { get; set; }
        public string TenDoiTuong { get; set; }
        public string TenQuy { get; set; }
        public double TongTien { get; set; }
        public string NoiDung { get; set; }
        public bool Chon { get; set; }
        public int Type { get; set; } = 0;  // 1: là các phiếu thu,chi
        public string Key { get; set; }
        public int ID { get; set; }
        public string KeyName { get; set; }
        public int IDKey { get; set; }
    }
}
