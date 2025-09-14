using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Services;

namespace API
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

       
        [WebMethod]
        public List<DanhSachTaiKhoan>DanhSachTaiKhoan(string tk)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachTaiKhoans.Where(p => p.TaiKhoan ==tk);
            return table.ToList();
        }
        [WebMethod]
        public List<ThongTinFile>DsThongTinFile_Full()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table= context.ThongTinFiles;
           
            return table.ToList();
        }
        [WebMethod]
        public DataTable DsThongTinFile_NguoiGiaoNhan_Full(string SoFile)
        {
            DataTable dt = new DataTable("table");
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenNhanVien");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table =(from a in context.ThongTinFile_NguoiGiaoNhan
                       join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien select new { a.MaNhanVien, b.TenNhanVien,a.SoFile}).Where(p => p.SoFile == SoFile);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["MaNhanVien"] = item.MaNhanVien;
                row["TenNhanVien"] = item.TenNhanVien;
                dt.Rows.Add(row);
            }
            dt.TableName = "nhanvien";
            return dt;
        }

        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_TinhChat(DateTime Ngay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.ThoiGianThucHien.Value.Year == Ngay.Year &&
                     p.ThoiGianThucHien.Value.Month == Ngay.Month && p.TinhChat == "HangNhap").OrderByDescending(p => p.IDLoHang).Take(1);
            return table.ToList();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_TinhChat2(DateTime Ngay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.ThoiGianThucHien.Value.Year == Ngay.Year &&
                     p.ThoiGianThucHien.Value.Month == Ngay.Month && p.TinhChat == "HangXuat").OrderByDescending(p => p.IDLoHang).Take(1);
            return table.ToList();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_Full_SoFile(string SoFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p=>p.SoFile==SoFile);
            return table.ToList();
        }
        [WebMethod]
        public void DsThongTinFile_Them(ThongTinFile table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.ThongTinFiles.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_Full_SoToKhai_Trung(string SoToKhai,int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.SoToKhai == SoToKhai && p.SoToKhai != "" && p.IDLoHang != IDLoHang);
            return table.ToList();
        }
        [WebMethod]
        public void DsThongTinFile_Sua(ThongTinFile a)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table1 = context.ThongTinFiles.Single(p => p.IDLoHang == a.IDLoHang);
            table1.ThoiGianThucHien = a.ThoiGianThucHien;
            table1.MaKhachHang = a.MaKhachHang;
            table1.SoFile = a.SoFile;
            table1.SoToKhai = a.SoToKhai;
            table1.SoBill = a.SoBill;
            table1.SoLuong = a.SoLuong;
            table1.SoCont = a.SoCont;
            table1.TenSales = a.TenSales;
           // table1.TenGiaoNhan = a.TenGiaoNhan;
            table1.LoaiHang = a.LoaiHang;
            table1.TinhChat = a.TinhChat;
            table1.LoaiToKhai = a.LoaiToKhai;
            table1.NghiepVu = a.NghiepVu;
            table1.PhatSinh = a.PhatSinh;
           // table1.DuyetUng = a.DuyetUng;
            table1.GhiChu = a.GhiChu;
            table1.TaiKhoanThucHien = a.TaiKhoanThucHien;
            context.SaveChanges();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_Full_SoToKhai_Trung1(string SoBill, int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.SoBill == SoBill && p.SoBill != "" && p.IDLoHang != IDLoHang);
            return table.ToList();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_Full_SoToKhai_Trung2(string SoFile, int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.SoFile == SoFile && p.SoFile != "" && p.IDLoHang != IDLoHang);
            return table.ToList();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_Full_SoToKhai(string SoToKhai)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.SoToKhai == SoToKhai && p.SoToKhai != "");
            return table.ToList();
        }
        [WebMethod]
        public List<ThongTinFile> DsThongTinFile_Full_SoBill(string SoBill)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.SoBill == SoBill && p.SoBill != "");
            return table.ToList();
        }
        [WebMethod]
        public DataTable DsThongTinFile_Full_TheoIDLoHang(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("DuyetUng",typeof(double));
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("IDGia", typeof(int));
         
            var table = (from a in context.ThongTinFiles
                        // join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                        
                         select new { a.IDLoHang, a.SoBill, a.SoFile, a.SoToKhai, a.SoLuong, a.SoCont,
                         a.MaKhachHang,
                            // b.TenKhachHang,
                             a.TenSales,
                             a.LoaiHang,a.TinhChat,a.SoLuongToKhai,a.LoaiToKhai,a.NghiepVu,a.PhatSinh }
                             ).Where(p => p.IDLoHang == IDLoHang);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                string _Ten = "";
                var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                      join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien select new { a.SoFile,b.TenNhanVien}).Where(p=>p.SoFile==item.SoFile);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten += item1.TenNhanVien + ",";
                }
                if (_Ten.Trim().Length > 0)
                    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;

                if (item.PhatSinh.Trim() == "0")
                    row["PhatSinh"] = "Nhiều tờ khai";
                else if (item.PhatSinh.Trim() == "1")
                    row["PhatSinh"] = "Không";
                if (item.NghiepVu.Trim() == "0")
                    row["NghiepVu"] = "Thông quan";
                else if (item.NghiepVu.Trim() == "1")
                    row["NghiepVu"] = "Đổi lệnh dưới kho";
                else if (item.NghiepVu.Trim() == "2")
                    row["NghiepVu"] = "Rút ruột";
                else if (item.NghiepVu.Trim() == "3")
                    row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                else if (item.NghiepVu.Trim() == "4")
                    row["NghiepVu"] = "Không có trucking";
                if (item.LoaiToKhai.Trim() == "0")
                    row["LoaiToKhai"] = "Luồng xanh";
                else if (item.LoaiToKhai.Trim() == "1")
                    row["LoaiToKhai"] = "Luồng vàng";
                else if (item.LoaiToKhai.Trim() == "2")
                    row["LoaiToKhai"] = "Luồng đỏ";
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                if (item.LoaiHang.Trim() == "HangLe")
                    row["LoaiHang"] = "Hàng Lẻ";
                else if (item.LoaiHang.Trim() == "HangCont")
                    row["LoaiHang"] = "Hàng Cont";
                if (item.TinhChat.Trim() == "HangNhap")
                    row["TinhChat"] = "Hàng nhập";
                else if (item.TinhChat.Trim() == "HangXuat")
                    row["TinhChat"] = "Hàng xuất";
                //

               
                row["TenSales"] = item.TenSales;
                row["IDLoHang"] = item.IDLoHang;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoToKhai"] = item.SoToKhai;
                row["SoLuong"] = item.SoLuong;
                row["SoCont"] = item.SoCont;
                //update 28.09
                double TongDuyetUng = 0;
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
                row["DuyetUng"] = TongDuyetUng;
                var t_kh = context.DanhSachKhachHangs.Where(p=>p.MaKhachHang==item.MaKhachHang);
                foreach (var item1 in t_kh)
                {
                    row["TenKhachHang"] = item1.TenKhachHang;
                }
                
                var t2 = context.FileGias.Where(p=>p.IDLoHang==item.IDLoHang);
                foreach (var item1 in t2)
                {
                    row["IDGia"] = item1.IDGia;
                }
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public List<ThongTinFile> ThongTinFile_TheoIDLoHang(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles.Where(p => p.IDLoHang == IDLoHang);
            return table.ToList();
        }
        [WebMethod]
        public DataTable ThongTinFileChuaLapBangKe(DateTime TuNgay,DateTime DenNgay)
        {
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TaiKhoanThucHien");
            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("Chon", typeof(bool));
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFiles
                       .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
          DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0);
            foreach (var item in table)
            {
                // var tCheck = context.BangDieuXe.Where(p=>p.SoFile==item.SoFile);
                var tCheck = DSBangDieuXe(item.SoFile);
                if (tCheck.Count() == 0)
                {
                    DataRow row = dt.NewRow();
                    // var t = context.BangPhiDiDuong.Where(p => p.SoFile == item.SoFile);
                    var t = DSBangPhiDiDuong(item.SoFile);
                    if (t.Count() == 0)
                    {
                        row["IDLoHang"] = item.IDLoHang;
                        // var t1 = context.DanhSachKhachHang.Where(p => p.MaKhachHang == item.MaKhachHang);
                        var t1 = dsKH_MaKH(item.MaKhachHang);
                        foreach (var item1 in t1)
                        {
                            row["MaKhachHang"] = item1.TenVietTat;
                        }
                        row["SoFile"] = item.SoFile;
                        row["SoToKhai"] = item.SoToKhai;
                        row["SoBill"] = item.SoBill;
                        row["SoLuong"] = item.SoLuong;
                        row["SoCont"] = item.SoCont;
                        row["TenSales"] = item.TenSales;
                        // 
                        string _Ten = "";
                        var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                               join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                               select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                        foreach (var item1 in t_NguoiGiaoNhan)
                        {
                            _Ten += item1.TenNhanVien + ",";
                        }
                        if (_Ten.Trim().Length > 0)
                            _Ten = _Ten.Substring(0, _Ten.Length - 1);
                        row["TenGiaoNhan"] = _Ten;
                        //
                        if (item.LoaiHang.Trim() == "HangLe")
                            row["LoaiHang"] = "Hàng Lẻ";
                        else if (item.LoaiHang.Trim() == "HangCont")
                            row["LoaiHang"] = "Hàng Cont";


                        if (item.TinhChat.Trim() == "HangNhap")
                            row["TinhChat"] = "Hàng nhập";
                        else if (item.TinhChat.Trim() == "HangXuat")
                            row["TinhChat"] = "Hàng xuất";
                        row["SoLuongToKhai"] = item.SoLuongToKhai;
                        if (item.LoaiToKhai.Trim() == "0")
                            row["LoaiToKhai"] = "Luồng xanh";
                        else if (item.LoaiToKhai.Trim() == "1")
                            row["LoaiToKhai"] = "Luồng vàng";
                        else if (item.LoaiToKhai.Trim() == "2")
                            row["LoaiToKhai"] = "Luồng đỏ";

                        if (item.NghiepVu.Trim() == "0")
                            row["NghiepVu"] = "Thông quan";
                        else if (item.NghiepVu.Trim() == "1")
                            row["NghiepVu"] = "Đổi lệnh dưới kho";
                        else if (item.NghiepVu.Trim() == "2")
                            row["NghiepVu"] = "Rút ruột";
                        else if (item.NghiepVu.Trim() == "3")
                            row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                        else if (item.NghiepVu.Trim() == "4")
                            row["NghiepVu"] = "Không có trucking";

                        if (item.PhatSinh.Trim() == "0")
                            row["PhatSinh"] = "Nhiều tờ khai";
                        else if (item.PhatSinh.Trim() == "1")
                            row["PhatSinh"] = "Không";
                        //update 28.09
                        double TongDuyetUng = 0;
                        var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p=>p.SoFile==item.SoFile);
                        foreach (var itemDuyetUng in t_duyetUng)
                        {
                            TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                        }
                        row["DuyetUng"] = TongDuyetUng;
                        row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
                        row["ThoiGianThucHien"] = item.ThoiGianThucHien;
                        row["GhiChu"] = item.GhiChu;
                        row["Chon"] = false;
                        dt.Rows.Add(row);
                    }
                }
            }
            dt.TableName = "xem";
            return dt;
        }
        //bang dieu xe
        [WebMethod]
        public List<BangDieuXe>DSBangDieuXe(string SoFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var tCheck = context.BangDieuXes.Where(p => p.SoFile == SoFile);
            return tCheck.ToList();
        }
        [WebMethod]
        public List<BangDieuXe> DSBangDieuXe_TheoIDBangPhi(int IDBangPhi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var tCheck = context.BangDieuXes.Where(p => p.IDBangPhi == IDBangPhi);
            return tCheck.ToList();
        }
        [WebMethod]
        public void DsBangDieuXe_Them(BangDieuXe p)
        {
            //
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            //BangDieuXe t = context.BangDieuXes.Single(b=>b.SoFile==b.SoFile);
            //context.BangDieuXes.Remove(t);
            //context.SaveChanges();
            //
            // p.MaDieuXe = LoadMaDieuXe(p.Ngay.Value); 
            var t = context.BangDieuXes.Where(a=>a.MaDieuXe==p.MaDieuXe);
            if (t.Count() == 0)
            {
                context.BangDieuXes.Add(p);
                context.SaveChanges();
            }
            else//neu lo trung ma cu thi se auto tao ma moi
            {
                string _Ma = p.MaDieuXe.Substring(p.MaDieuXe.Trim().Length-5,5);
                string _MaAuto = "KS" + p.Ngay.Value.Year.ToString() + (int.Parse(_Ma) + 1).ToString("0000#");
                p.MaDieuXe = _MaAuto;
                context.BangDieuXes.Add(p);
                context.SaveChanges();
            }
        }
        [WebMethod]
        public void DsBangPhiDiDuong_Them(BangPhiDiDuong table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangPhiDiDuongs.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public void DsBangPhiDiDuong_Temp_Them(BangPhiDiDuong_Temp table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhiDiDuong_Temp.Where(p => p.IDBangPhi==table1.IDBangPhi);
            if (table.Count() == 0)
            {
                context.BangPhiDiDuong_Temp.Add(table1);
                context.SaveChanges();
            }
        }
        [WebMethod]
        public void DsBangPhiDiDuong_ChiKhac_Them(BangPhiDiDuong_ChiKhac table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
           
            context.BangPhiDiDuong_ChiKhac.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public List<BangPhiDiDuong_ChiKhac_Temp> DsBangPhiDiDuong_ChiKhac_Temp_TheoIDBangPhi(int IDBangPhi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhiDiDuong_ChiKhac_Temp.Where(p=>p.IDBangPhi==IDBangPhi);
            return table.ToList();
        }
        [WebMethod]
        public List<BangPhiDiDuong_ChiKhac_Temp> DsBangPhiDiDuong_ChiKhac_Temp_TheoIDBangPhi2()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhiDiDuong_ChiKhac_Temp;
            return table.ToList();
        }
        [WebMethod]
        public void DsBangPhiDiDuong_ChiKhac_Temp_Them(BangPhiDiDuong_ChiKhac_Temp table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhiDiDuong_ChiKhac_Temp.Where(p=>p.NoiDungChi== table1.NoiDungChi);
            if (table.Count() == 0)
            {
                context.BangPhiDiDuong_ChiKhac_Temp.Add(table1);
                context.SaveChanges();
            }
            else
            {
                BangPhiDiDuong_ChiKhac_Temp table2 = context.BangPhiDiDuong_ChiKhac_Temp.Single(p => p.NoiDungChi == table1.NoiDungChi);
                context.BangPhiDiDuong_ChiKhac_Temp.Remove(table2);
                context.SaveChanges();
                //
                context.BangPhiDiDuong_ChiKhac_Temp.Add(table1);
                context.SaveChanges();
            }    
        }
        [WebMethod]
        public List<BangPhiDiDuong> DSBangPhiDiDuong_Top1()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t=context.BangPhiDiDuongs.OrderByDescending(p => p.IDBangPhi).Take(1);
            return t.ToList();
        }
        [WebMethod]
        public List<BangPhiDiDuong>DSBangPhiDiDuong(string SoFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangPhiDiDuongs.Where(p => p.SoFile == SoFile);
            return t.ToList();
        }
        [WebMethod]
        public void BangDieuXe_Sua2( string MaDieuXe, BangPhiDiDuong_Temp item)
        {
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                var table2 = context1.BangDieuXes.Single(p => p.MaDieuXe == MaDieuXe);
                table2.TienAn = item.TienAn.Value;
                table2.TienLuat = item.TienLuat.Value;
                table2.TienVe = item.TienVe.Value;
                table2.QuaDem = item.QuaDem.Value;
                table2.NguoiDuyet = item.NguoiDuyet;
                table2.ThoiGianDuyet = item.ThoiGianDuyet;
                table2.DiemTraHang = item.DiemTraHang.Value;
                context1.SaveChanges();
            }
        }
        [WebMethod]
        public void BangDieuXe_Sua(int _IDBangPhi, string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            //  var table1 = DSBangPhiDiDuong_TheoIDBangPhi(_IDBangPhi);
            var table1 = DSBangPhiDiDuong_Temp_TheoIDBangPhi2();
            foreach (var item in table1)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    var table2 = context1.BangDieuXes.Single(p => p.MaDieuXe == MaDieuXe);
                    table2.TienAn = item.TienAn.Value;
                    table2.TienLuat = item.TienLuat.Value;
                    table2.TienVe = item.TienVe.Value;
                    table2.QuaDem = item.QuaDem.Value;
                    table2.NguoiDuyet = item.NguoiDuyet;
                    table2.ThoiGianDuyet = item.ThoiGianDuyet;
                    table2.DiemTraHang = item.DiemTraHang.Value;
                    context1.SaveChanges();
                }
            }
            //
            // var table3 = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == _IDBangPhi);
            var table3 = DsBangPhiDiDuong_ChiKhac_Temp_TheoIDBangPhi2();
            foreach (var item in table3)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    BangDieuXe_ChiTiet table4 = new BangDieuXe_ChiTiet();
                    table4.IDBangPhi = _IDBangPhi;
                    table4.NoiDungChi = item.NoiDungChi;
                    table4.SoTienChi = item.SoTienChi.Value;
                    context1.BangDieuXe_ChiTiet.Add(table4);
                    context1.SaveChanges();
                }
            }
            //xoa du lieu temp
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                var t1 = context1.BangPhiDiDuong_Temp;
                foreach (var item3 in t1)
                {
                    BangPhiDiDuong_Temp table4 = context1.BangPhiDiDuong_Temp.Single(p => p.IDBangPhi== item3.IDBangPhi);
                    context1.BangPhiDiDuong_Temp.Remove(table4);
                    context1.SaveChanges();
                }
               
            }
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                var t1 = context1.BangPhiDiDuong_ChiKhac_Temp;
                foreach (var item3 in t1)
                {
                    BangPhiDiDuong_ChiKhac_Temp table4 = context1.BangPhiDiDuong_ChiKhac_Temp.Single(p => p.IDBangPhi ==item3.IDBangPhi);
                    context1.BangPhiDiDuong_ChiKhac_Temp.Remove(table4);
                    context1.SaveChanges();
                }
                
            }
        }
        [WebMethod]
        public List<BangPhiDiDuong> DSBangPhiDiDuong_TheoIDBangPhi(int IDBangPhi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangPhiDiDuongs.Where(p => p.IDBangPhi == IDBangPhi);
            return t.ToList();
        }
        [WebMethod]
        public List<BangPhiDiDuong_Temp> DSBangPhiDiDuong_Temp_TheoIDBangPhi(int IDBangPhi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangPhiDiDuong_Temp.Where(p => p.IDBangPhi == IDBangPhi);
            return t.ToList();
        }
        [WebMethod]
        public List<BangPhiDiDuong_Temp> DSBangPhiDiDuong_Temp_TheoIDBangPhi2()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangPhiDiDuong_Temp;
            return t.ToList();
        }
        [WebMethod]
        public List<BangPhiDiDuong_ChiKhac> DSBangPhiDiDuong_ChiKhac_TheoIDBangPhi(int IDBangPhi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == IDBangPhi);
            return t.ToList();
        }

        [WebMethod]
        public List<NhanVien>DsNhanVien_GiaoNhan(string TenGiaoNhan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.NhanViens.Where(p => p.MaNhanVien == TenGiaoNhan);
            return t2.ToList();
        }
        [WebMethod]
        public List<BangPhiDiDuong> DSBangPhiDiDuong_DuyetChi(DateTime TuNgay,DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhiDiDuongs
                       .Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
          DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0 && p.DuyetChi != true);
            return table.ToList();
        }
        [WebMethod]
        public List<clsBangDieuXe> DSBangPhiDiDuong_DuyetChi_KhongCoFile(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            List<clsBangDieuXe> q = new List<clsBangDieuXe>();
            var table = (from a in context.BangDieuXes
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang into c1
                         from sub1 in c1.DefaultIfEmpty()
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             a.IDBangPhi,
                             a.LaiXeThuCuoc,
                             a.LoaiXe_KH,
                             a.LoaiXe_NCC,
                             a.LuongHangVe,
                             a.MaDieuXe,
                             MaKhachHang = sub1.TenKhachHang,
                             MaNhaCungCap = sub2.TenNhaCungCap,
                             a.Ngay,
                             a.NguoiDuyet,
                             a.NguoiTao,
                             a.SoFile,
                             a.ThoiGianDuyet,
                             a.TienAn,
                             a.QuaDem,
                             a.TienLuat,
                             a.TienVe,
                             a.TTHQ,
                             a.TuyenVC,
                             a.BienSoXe,
                             a.CuocBan,
                             a.CuocMua,
                             a.DiemTraHang,
                             a.DuyetChi,
                             a.LaiXe,
                             Chon = false,
                             sub1.TenVietTat,
                             a.GhiChu
                         }).Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
           DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0&&(p.SoFile==""||p.SoFile=="0"));
            foreach (var item in table)
            {
                var t_check = context.FileDebit_KoHoaDon_KH.Where(p=>p.MaDieuXe==item.MaDieuXe);
                if (t_check.Count() == 0)
                {
                    clsBangDieuXe p1 = new clsBangDieuXe();
                    p1.TenVietTat = item.TenVietTat;
                    p1.IDBangPhi = item.IDBangPhi;
                    p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                    p1.LoaiXe_KH = item.LoaiXe_KH;
                    p1.LoaiXe_NCC = item.LoaiXe_NCC;
                    p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                    p1.MaDieuXe = item.MaDieuXe;
                    p1.MaKhachHang = item.MaKhachHang;
                    p1.MaNhaCungCap = item.MaNhaCungCap;
                    p1.Ngay = item.Ngay.Value;
                    p1.NguoiDuyet = item.NguoiDuyet;
                    p1.NguoiTao = item.NguoiTao;
                    p1.SoFile = item.SoFile;
                    if (item.ThoiGianDuyet != null)
                        p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                    p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                    p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                    p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                    p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                    p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                    p1.TuyenVC = item.TuyenVC;
                    p1.BienSoXe = item.BienSoXe;
                    p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                    p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                    p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                    p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                    p1.LaiXe = item.LaiXe;
                    p1.Chon = item.Chon;
                    p1.GhiChu = item.GhiChu;
                    q.Add(p1);
                }
            }
            return q;
        }
        
        [WebMethod]
        public List<clsBangDieuXe2> DSBangPhiDiDuong_DuyetChi_KhongCoFile_NCC(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            List<clsBangDieuXe2> q = new List<clsBangDieuXe2>();
            var table = (from a in context.BangDieuXes
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang into c1
                         from sub1 in c1.DefaultIfEmpty()
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             a.IDBangPhi,
                             a.LaiXeThuCuoc,
                             a.LoaiXe_KH,
                             a.LoaiXe_NCC,
                             a.LuongHangVe,
                             a.MaDieuXe,
                             MaKhachHang = sub1.TenKhachHang,
                             MaNhaCungCap = sub2.TenNhaCungCap,
                             a.Ngay,
                             a.NguoiDuyet,
                             a.NguoiTao,
                             a.SoFile,
                             a.ThoiGianDuyet,
                             a.TienAn,
                             a.QuaDem,
                             a.TienLuat,
                             a.TienVe,
                             a.TTHQ,
                             a.TuyenVC,
                             a.BienSoXe,
                             a.CuocBan,
                             a.CuocMua,
                             a.DiemTraHang,
                             a.DuyetChi,
                             a.LaiXe,
                             Chon = false,
                             sub1.TenVietTat,
                             a.GhiChu,
                             Bang="DieuXe"
                         }).Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0 && p.CuocMua > 0&&p.SoFile.Length<=3);
            foreach (var item in table)
            {
                var t2 = context.FileDebit_KoHoaDon_NCC.Where(p=>p.MaDieuXe==item.MaDieuXe);
                if (t2.Count() == 0)
                {
                    clsBangDieuXe2 p1 = new clsBangDieuXe2();
                    p1.TenVietTat = item.TenVietTat;
                    p1.IDBangPhi = item.IDBangPhi;
                    p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                    p1.LoaiXe_KH = item.LoaiXe_KH;
                    p1.LoaiXe_NCC = item.LoaiXe_NCC;
                    p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                    p1.MaDieuXe = item.MaDieuXe;
                    p1.MaKhachHang = item.MaKhachHang;
                    p1.MaNhaCungCap = item.MaNhaCungCap;
                    p1.Ngay = item.Ngay.Value;
                    p1.NguoiDuyet = item.NguoiDuyet;
                    p1.NguoiTao = item.NguoiTao;
                    p1.SoFile = item.SoFile;
                    if (item.ThoiGianDuyet != null)
                        p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                    p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                    p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                    p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                    p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                    p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                    p1.TuyenVC = item.TuyenVC;
                    p1.BienSoXe = item.BienSoXe;
                    p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                    p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                    p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                    p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                    p1.LaiXe = item.LaiXe;
                    p1.Chon = item.Chon;
                    p1.GhiChu = item.GhiChu;
                    p1.Bang = item.Bang;
                    q.Add(p1);
                }
            }
            //lấy từ file giá có nhà cung cấp
            var table2=(from a in context.FileGiaChiTiets 
                       join b in context.FileGias on a.IDGia equals b.IDGia
                       join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap
                       join e in context.ThongTinFiles on b.SoFile equals e.SoFile
                       join d in context.DanhSachKhachHangs on e.MaKhachHang equals d.MaKhachHang
                       select new
                       {
                           IDBangPhi=a.IDGiaCT,
                           LaiXeThuCuoc=0,
                           LoaiXe_KH="",
                           LoaiXe_NCC="",
                           LuongHangVe=0,
                           b.MaDieuXe,
                           MaKhachHang = d.TenKhachHang,
                           MaNhaCungCap = c.TenNhaCungCap,
                           Ngay=b.ThoiGianLap,
                           NguoiDuyet=b.NguoiDuyet,
                           NguoiTao=b.NguoiLap,
                           b.SoFile,
                           ThoiGianDuyet=b.NgayDuyet,
                           TienAn=0,
                           QuaDem=0,
                           TienLuat=0,
                           TienVe=0,
                           TTHQ=0,
                           TuyenVC="",
                           BienSoXe="",
                           CuocBan=a.GiaBan,
                           CuocMua=a.GiaMua,
                           DiemTraHang="",
                           DuyetChi=b.Duyet,
                           LaiXe="",
                           Chon = false,
                           d.TenVietTat,
                           a.GhiChu,
                           Bang="FileGia"
                       }).Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0 && p.CuocMua > 0&&p.MaNhaCungCap!=""&&p.MaDieuXe!=""&&p.SoFile.Length<=3);
            foreach (var item in table)
            {
                var t2 = context.FileDebit_KoHoaDon_NCC.Where(p => p.MaDieuXe == item.MaDieuXe);
                if (t2.Count() == 0)
                {
                    clsBangDieuXe2 p1 = new clsBangDieuXe2();
                    p1.TenVietTat = item.TenVietTat;
                    p1.IDBangPhi = item.IDBangPhi;
                    p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                    p1.LoaiXe_KH = item.LoaiXe_KH;
                    p1.LoaiXe_NCC = item.LoaiXe_NCC;
                    p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                    p1.MaDieuXe = item.MaDieuXe;
                    p1.MaKhachHang = item.MaKhachHang;
                    p1.MaNhaCungCap = item.MaNhaCungCap;
                    p1.Ngay = item.Ngay.Value;
                    p1.NguoiDuyet = item.NguoiDuyet;
                    p1.NguoiTao = item.NguoiTao;
                    p1.SoFile = item.SoFile;
                    if (item.ThoiGianDuyet != null)
                        p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                    p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                    p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                    p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                    p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                    p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                    p1.TuyenVC = item.TuyenVC;
                    p1.BienSoXe = item.BienSoXe;
                    p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                    p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                    p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                    p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                    p1.LaiXe = item.LaiXe;
                    p1.Chon = item.Chon;
                    p1.GhiChu = item.GhiChu;
                    p1.Bang = item.Bang;
                    q.Add(p1);
                }
            }
            return q;
        }
        [WebMethod]
        public List<clsBangDieuXe2> DSBangPhiDiDuong_DuyetChi_CoFile_NCC(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            List<clsBangDieuXe2> q = new List<clsBangDieuXe2>();
            var table = (from a in context.BangDieuXes
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang into c1
                         from sub1 in c1.DefaultIfEmpty()
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             a.IDBangPhi,
                             a.LaiXeThuCuoc,
                             a.LoaiXe_KH,
                             a.LoaiXe_NCC,
                             a.LuongHangVe,
                             a.MaDieuXe,
                             MaKhachHang = sub1.TenKhachHang,
                             MaNhaCungCap = sub2.TenNhaCungCap,
                             a.Ngay,
                             a.NguoiDuyet,
                             a.NguoiTao,
                             a.SoFile,
                             a.ThoiGianDuyet,
                             a.TienAn,
                             a.QuaDem,
                             a.TienLuat,
                             a.TienVe,
                             a.TTHQ,
                             a.TuyenVC,
                             a.BienSoXe,
                             a.CuocBan,
                             a.CuocMua,
                             a.DiemTraHang,
                             a.DuyetChi,
                             a.LaiXe,
                             Chon = false,
                             sub1.TenVietTat,
                             a.GhiChu,
                             Bang = "DieuXe"
                         }).Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0 && p.CuocMua > 0&& p.SoFile.Length>=3);
            foreach (var item in table)
            {
                var t2 = context.FileDebit_KoHoaDon_NCC.Where(p => p.MaDieuXe == item.MaDieuXe);
                if (t2.Count() == 0)
                {
                    clsBangDieuXe2 p1 = new clsBangDieuXe2();
                    p1.TenVietTat = item.TenVietTat;
                    p1.IDBangPhi = item.IDBangPhi;
                    p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                    p1.LoaiXe_KH = item.LoaiXe_KH;
                    p1.LoaiXe_NCC = item.LoaiXe_NCC;
                    p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                    p1.MaDieuXe = item.MaDieuXe;
                    p1.MaKhachHang = item.MaKhachHang;
                    p1.MaNhaCungCap = item.MaNhaCungCap;
                    p1.Ngay = item.Ngay.Value;
                    p1.NguoiDuyet = item.NguoiDuyet;
                    p1.NguoiTao = item.NguoiTao;
                    p1.SoFile = item.SoFile;
                    if (item.ThoiGianDuyet != null)
                        p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                    p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                    p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                    p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                    p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                    p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                    p1.TuyenVC = item.TuyenVC;
                    p1.BienSoXe = item.BienSoXe;
                    p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                    p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                    p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                    p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                    p1.LaiXe = item.LaiXe;
                    p1.Chon = item.Chon;
                    p1.GhiChu = item.GhiChu;
                    p1.Bang = item.Bang;
                    q.Add(p1);
                }
            }
            //lấy từ file giá có nhà cung cấp
            var table2 = (from a in context.FileGiaChiTiets
                          join b in context.FileGias on a.IDGia equals b.IDGia
                          join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap
                          join e in context.ThongTinFiles on b.SoFile equals e.SoFile
                          join d in context.DanhSachKhachHangs on e.MaKhachHang equals d.MaKhachHang
                          select new
                          {
                              IDBangPhi = a.IDGiaCT,
                              LaiXeThuCuoc = 0,
                              LoaiXe_KH = "",
                              LoaiXe_NCC = "",
                              LuongHangVe = 0,
                              b.MaDieuXe,
                              MaKhachHang = d.TenKhachHang,
                              MaNhaCungCap = c.TenNhaCungCap,
                              Ngay = b.ThoiGianLap,
                              NguoiDuyet = b.NguoiDuyet,
                              NguoiTao = b.NguoiLap,
                              b.SoFile,
                              ThoiGianDuyet = b.NgayDuyet,
                              TienAn = 0,
                              QuaDem = 0,
                              TienLuat = 0,
                              TienVe = 0,
                              TTHQ = 0,
                              TuyenVC = "",
                              BienSoXe = "",
                              CuocBan = a.GiaBan,
                              CuocMua = a.GiaMua,
                              DiemTraHang = "",
                              DuyetChi = b.Duyet,
                              LaiXe = "",
                              Chon = false,
                              d.TenVietTat,
                              a.GhiChu,
                              Bang = "FileGia"
                          }).Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 && 
                             DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0 && p.CuocMua > 0 &&p.SoFile.Length>3 && p.MaNhaCungCap != "" && p.MaDieuXe != "");
            foreach (var item in table)
            {
                var t2 = context.FileDebit_KoHoaDon_NCC.Where(p => p.MaDieuXe == item.MaDieuXe);
                if (t2.Count() == 0)
                {
                    clsBangDieuXe2 p1 = new clsBangDieuXe2();
                    p1.TenVietTat = item.TenVietTat;
                    p1.IDBangPhi = item.IDBangPhi;
                    p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                    p1.LoaiXe_KH = item.LoaiXe_KH;
                    p1.LoaiXe_NCC = item.LoaiXe_NCC;
                    p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                    p1.MaDieuXe = item.MaDieuXe;
                    p1.MaKhachHang = item.MaKhachHang;
                    p1.MaNhaCungCap = item.MaNhaCungCap;
                    p1.Ngay = item.Ngay.Value;
                    p1.NguoiDuyet = item.NguoiDuyet;
                    p1.NguoiTao = item.NguoiTao;
                    p1.SoFile = item.SoFile;
                    if (item.ThoiGianDuyet != null)
                        p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                    p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                    p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                    p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                    p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                    p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                    p1.TuyenVC = item.TuyenVC;
                    p1.BienSoXe = item.BienSoXe;
                    p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                    p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                    p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                    p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                    p1.LaiXe = item.LaiXe;
                    p1.Chon = item.Chon;
                    p1.GhiChu = item.GhiChu;
                    p1.Bang = item.Bang;
                    q.Add(p1);
                }
            }
            return q;
        }
        [WebMethod]
        public List<BangDieuXe_ChiTiet>BangDieuXe_CT_TheoID(int id)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var tablect = context.BangDieuXe_ChiTiet.Where(p => p.IDBangPhi == id);
            return tablect.ToList();

        }
        [WebMethod]
        public DataTable BangDieuXe_TaoDeBitHangLoat(string strMaDieuXe)
        {
            DataTable dt = new DataTable("DieuXe");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("SoTien",typeof(double));
            dt.Columns.Add("VAT",typeof(int));
            dt.Columns.Add("PhiCom");
            dt.Columns.Add("MaNhaCungCap");
            //
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("LoaiXe_KH");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("CuocMua");
            dt.Columns.Add("CuocBan");
            dt.Columns.Add("LaiXeThuCuoc");
            dt.Columns.Add("TenDichVu");
            if (strMaDieuXe.Trim().Length>0)
            {
                string[] arr = strMaDieuXe.Split('-');
                for (int i = 0; i < arr.Length; i++)
                {
                    var table = BangDieuXe_CanTaoHoaDon_KH(arr[i]);
                    foreach (var item in table)
                    {
                        DataRow row = dt.NewRow();
                        row["TuyenVC"] = item.TuyenVC;
                        row["MaDieuXe"] = item.MaDieuXe;
                        row["SoTien"] = item.CuocBan+item.LaiXeThuCuoc;
                        row["VAT"] = 0;
                        row["PhiCom"] =0;
                        row["MaNhaCungCap"] = item.MaNhaCungCap;
                        //
                        row["MaKhachHang"] = item.MaKH;
                        row["LoaiXe_KH"] = item.LoaiXe_KH;
                        row["SoHoaDon"] = "";
                        row["CuocMua"] = item.CuocMua;
                        row["CuocBan"] = item.CuocBan;
                        row["LaiXeThuCuoc"] = item.LaiXeThuCuoc;
                        row["TenDichVu"] = item.TuyenVC;
                        dt.Rows.Add(row);
                    }
                }
            }
            dt.TableName = "DieuXe";
            return dt;
        }
        [WebMethod]
        public List<clsBangDieuXe1> BangDieuXe_CanTaoHoaDon_KH(string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            List<clsBangDieuXe1> q = new List<clsBangDieuXe1>();
            var table = (from a in context.BangDieuXes
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang into c1
                         from sub1 in c1.DefaultIfEmpty()
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             a.IDBangPhi,
                             a.LaiXeThuCuoc,
                             a.LoaiXe_KH,
                             a.LoaiXe_NCC,
                             a.LuongHangVe,
                             a.MaDieuXe,
                             MaKH= sub1.MaKhachHang,
                             MaKhachHang = sub1.TenKhachHang,
                             MaNhaCungCap = sub2.TenNhaCungCap,
                             a.Ngay,
                             a.NguoiDuyet,
                             a.NguoiTao,
                             a.SoFile,
                             a.ThoiGianDuyet,
                             a.TienAn,
                             a.QuaDem,
                             a.TienLuat,
                             a.TienVe,
                             a.TTHQ,
                             a.TuyenVC,
                             a.BienSoXe,
                             a.CuocBan,
                             a.CuocMua,
                             a.DiemTraHang,
                             a.DuyetChi,
                             a.LaiXe,
                             Chon = false,
                             sub1.TenVietTat,
                             a.GhiChu
                         }).Where(p=>p.MaDieuXe==MaDieuXe);
            foreach (var item in table)
            {
                clsBangDieuXe1 p1 = new clsBangDieuXe1();
                p1.TenVietTat = item.TenVietTat;
                p1.IDBangPhi = item.IDBangPhi;
                p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                p1.LoaiXe_KH = item.LoaiXe_KH;
                p1.LoaiXe_NCC = item.LoaiXe_NCC;
                p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                p1.MaDieuXe = item.MaDieuXe;
                p1.MaKH = item.MaKH;
                p1.MaKhachHang = item.MaKhachHang;
                p1.MaNhaCungCap = item.MaNhaCungCap;
                p1.Ngay = item.Ngay.Value;
                p1.NguoiDuyet = item.NguoiDuyet;
                p1.NguoiTao = item.NguoiTao;
                p1.SoFile = item.SoFile;
                if (item.ThoiGianDuyet != null)
                    p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                p1.TuyenVC = item.TuyenVC;
                p1.BienSoXe = item.BienSoXe;
                p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                p1.LaiXe = item.LaiXe;
                p1.Chon = item.Chon;
                p1.GhiChu = item.GhiChu;
                q.Add(p1);
            }
            return q;
        }
        [WebMethod]
        public List<clsBangDieuXe1> BangDieuXe_CanTaoHoaDon_NCC(string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            List<clsBangDieuXe1> q = new List<clsBangDieuXe1>();
            var table = (from a in context.BangDieuXes
                        
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             a.IDBangPhi,
                             a.LaiXeThuCuoc,
                             a.LoaiXe_KH,
                             a.LoaiXe_NCC,
                             a.LuongHangVe,
                             a.MaDieuXe,
                             a.MaNhaCungCap,
                             a.Ngay,
                             a.NguoiDuyet,
                             a.NguoiTao,
                             a.SoFile,
                             a.ThoiGianDuyet,
                             a.TienAn,
                             a.QuaDem,
                             a.TienLuat,
                             a.TienVe,
                             a.TTHQ,
                             a.TuyenVC,
                             a.BienSoXe,
                             a.CuocBan,
                             a.CuocMua,
                             a.DiemTraHang,
                             a.DuyetChi,
                             a.LaiXe,
                             Chon = false,
                             sub2.TenVietTat,
                             a.GhiChu
                         }).Where(p => p.MaDieuXe == MaDieuXe);
            foreach (var item in table)
            {
                clsBangDieuXe1 p1 = new clsBangDieuXe1();
                p1.TenVietTat = item.TenVietTat;
                p1.IDBangPhi = item.IDBangPhi;
                p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                p1.LoaiXe_KH = item.LoaiXe_KH;
                p1.LoaiXe_NCC = item.LoaiXe_NCC;
                p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                p1.MaDieuXe = item.MaDieuXe;
                p1.MaNhaCungCap = item.MaNhaCungCap;
                p1.Ngay = item.Ngay.Value;
                p1.NguoiDuyet = item.NguoiDuyet;
                p1.NguoiTao = item.NguoiTao;
                p1.SoFile = item.SoFile;
                if (item.ThoiGianDuyet != null)
                    p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                p1.TuyenVC = item.TuyenVC;
                p1.BienSoXe = item.BienSoXe;
                p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                p1.LaiXe = item.LaiXe;
                p1.Chon = item.Chon;
                p1.GhiChu = item.GhiChu;
                q.Add(p1);
            }
            return q;
        }
        [WebMethod]
        public List<clsBangDieuXe1> BangFileGia_CanTaoHoaDon_NCC(string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            List<clsBangDieuXe1> q = new List<clsBangDieuXe1>();
            var table = (from a in context.FileGiaChiTiets
                         join b in context.FileGias on a.IDGia equals b.IDGia
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             IDBangPhi=a.IDGiaCT,
                             LaiXeThuCuoc=0,
                             LoaiXe_KH="",
                             LoaiXe_NCC="",
                             LuongHangVe=0,
                             b.MaDieuXe,
                             a.MaNhaCungCap,
                             Ngay=b.ThoiGianLap,
                             NguoiDuyet=b.NguoiDuyet,
                             NguoiTao=b.NguoiLap,
                             b.SoFile,
                             ThoiGianDuyet=b.NgayDuyet,
                             TienAn=0,
                             QuaDem=0,
                             TienLuat=0,
                             TienVe=0,
                             TTHQ=0,
                             TuyenVC="",
                             BienSoXe="",
                             CuocBan=a.GiaBan,
                             CuocMua=a.GiaMua,
                             DiemTraHang=0,
                             DuyetChi=b.Duyet,
                             LaiXe="",
                             Chon = false,
                             sub2.TenVietTat,
                             a.GhiChu
                         }).Where(p => p.MaDieuXe == MaDieuXe);
            foreach (var item in table)
            {
                clsBangDieuXe1 p1 = new clsBangDieuXe1();
                p1.TenVietTat = item.TenVietTat;
                p1.IDBangPhi = item.IDBangPhi;
                p1.LaiXeThuCuoc = 0;
                p1.LoaiXe_KH = item.LoaiXe_KH;
                p1.LoaiXe_NCC = item.LoaiXe_NCC;
                p1.LuongHangVe = 0;
                p1.MaDieuXe = item.MaDieuXe;
                p1.MaNhaCungCap = item.MaNhaCungCap;
                p1.Ngay = item.Ngay.Value;
                p1.NguoiDuyet = item.NguoiDuyet;
                p1.NguoiTao = item.NguoiTao;
                p1.SoFile = item.SoFile;
                if (item.ThoiGianDuyet != null)
                    p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                p1.TienAn = 0;
                p1.QuaDem = 0;
                p1.TienLuat = 0;
                p1.TienVe = 0;
                p1.TTHQ = 0;
                p1.TuyenVC = item.TuyenVC;
                p1.BienSoXe = item.BienSoXe;
                p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                p1.DiemTraHang = 0;
                p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                p1.LaiXe = item.LaiXe;
                p1.Chon = item.Chon;
                p1.GhiChu = item.GhiChu;
                q.Add(p1);
            }
            return q;
        }
        [WebMethod]
        public List<clsBangDieuXe> BangDieuXe_Xem(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            List<clsBangDieuXe> q = new List<clsBangDieuXe>();
            var table = (from a in context.BangDieuXes
                          join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang into c1
                          from sub1 in c1.DefaultIfEmpty()
                          join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                          from sub2 in c2.DefaultIfEmpty()
                          select new
                          {
                              a.IDBangPhi,
                              a.LaiXeThuCuoc,
                              a.LoaiXe_KH,
                              a.LoaiXe_NCC,
                              a.LuongHangVe,
                              a.MaDieuXe,
                              MaKhachHang = sub1.TenKhachHang,
                              MaNhaCungCap = sub2.TenNhaCungCap,
                              a.Ngay,
                              a.NguoiDuyet,
                              a.NguoiTao,
                              a.SoFile,
                              a.ThoiGianDuyet,
                              a.TienAn,
                              a.QuaDem,
                              a.TienLuat,
                              a.TienVe,
                              a.TTHQ,
                              a.TuyenVC,
                              a.BienSoXe,
                              a.CuocBan,
                              a.CuocMua,
                              a.DiemTraHang,
                              a.DuyetChi,
                              a.LaiXe,
                              Chon = false,
                              sub1.TenVietTat,
                              TenVietTat2=sub2.TenVietTat,
                              a.GhiChu
                              
                          }).Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
            foreach (var item in table)
            {
                clsBangDieuXe p1 = new clsBangDieuXe();
                p1.TenVietTat2 = item.TenVietTat2;
                p1.TenVietTat = item.TenVietTat;
                p1.IDBangPhi = item.IDBangPhi;
                p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0: item.LaiXeThuCuoc.Value;
                p1.LoaiXe_KH = item.LoaiXe_KH;
                p1.LoaiXe_NCC = item.LoaiXe_NCC;
                p1.LuongHangVe =(item.LuongHangVe==null)?0: item.LuongHangVe.Value;
                p1.MaDieuXe = item.MaDieuXe;
                p1.MaKhachHang = item.MaKhachHang;
                p1.MaNhaCungCap = item.MaNhaCungCap;
                p1.Ngay = item.Ngay.Value;
                p1.NguoiDuyet = item.NguoiDuyet;
                p1.NguoiTao = item.NguoiTao;
                p1.SoFile = item.SoFile;
                var tTemp = context.ThongTinFiles.Where(p=>p.SoFile==p1.SoFile);
                foreach (var item2 in tTemp)
                {
                    p1.SoCont = item2.SoCont;
                }
                if (item.ThoiGianDuyet!=null)
                   p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                p1.TienAn = (item.TienAn == null) ? 0: item.TienAn.Value;
                p1.QuaDem =(item.QuaDem==null)?0: item.QuaDem.Value;
                p1.TienLuat = (item.TienLuat == null) ? 0: item.TienLuat.Value;
                p1.TienVe = (item.TienVe==null)?0:item.TienVe.Value;
                p1.TTHQ = (item.TTHQ==null)?0:item.TTHQ.Value;
                p1.TuyenVC = item.TuyenVC;
                p1.BienSoXe = item.BienSoXe;
                p1.CuocBan =(item.CuocBan==null)?0: item.CuocBan.Value;
                p1.CuocMua = (item.CuocMua==null)?0:item.CuocMua.Value;
                p1.DiemTraHang = (item.DiemTraHang==null)?0:item.DiemTraHang.Value;
                p1.DuyetChi =(item.DuyetChi==null)?false: item.DuyetChi.Value;
                p1.LaiXe = item.LaiXe;
                p1.Chon = item.Chon;
                p1.GhiChu = item.GhiChu;
                q.Add(p1);
            }
            return q;
        }
        [WebMethod]
        public List<clsBangDieuXe> BangDieuXe_TheoMaDieuXe(string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            List<clsBangDieuXe> q = new List<clsBangDieuXe>();
            var table = (from a in context.BangDieuXes
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang into c1
                         from sub1 in c1.DefaultIfEmpty()
                         join c in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals c.MaNhaCungCap into c2
                         from sub2 in c2.DefaultIfEmpty()
                         select new
                         {
                             a.IDBangPhi,
                             a.LaiXeThuCuoc,
                             a.LoaiXe_KH,
                             a.LoaiXe_NCC,
                             a.LuongHangVe,
                             a.MaDieuXe,
                             MaKhachHang = sub1.TenKhachHang,
                             MaNhaCungCap = sub2.TenNhaCungCap,
                             a.Ngay,
                             a.NguoiDuyet,
                             a.NguoiTao,
                             a.SoFile,
                             a.ThoiGianDuyet,
                             a.TienAn,
                             a.QuaDem,
                             a.TienLuat,
                             a.TienVe,
                             a.TTHQ,
                             a.TuyenVC,
                             a.BienSoXe,
                             a.CuocBan,
                             a.CuocMua,
                             a.DiemTraHang,
                             a.DuyetChi,
                             a.LaiXe,
                             Chon = false,
                             sub1.TenVietTat,
                             TenVietTat2 = sub2.TenVietTat,
                             a.GhiChu

                         }).Where(p =>p.MaDieuXe==MaDieuXe);
            foreach (var item in table)
            {
                clsBangDieuXe p1 = new clsBangDieuXe();
                p1.TenVietTat2 = item.TenVietTat2;
                p1.TenVietTat = item.TenVietTat;
                p1.IDBangPhi = item.IDBangPhi;
                p1.LaiXeThuCuoc = (item.LaiXeThuCuoc == null) ? 0 : item.LaiXeThuCuoc.Value;
                p1.LoaiXe_KH = item.LoaiXe_KH;
                p1.LoaiXe_NCC = item.LoaiXe_NCC;
                p1.LuongHangVe = (item.LuongHangVe == null) ? 0 : item.LuongHangVe.Value;
                p1.MaDieuXe = item.MaDieuXe;
                p1.MaKhachHang = item.MaKhachHang;
                p1.MaNhaCungCap = item.MaNhaCungCap;
                p1.Ngay = item.Ngay.Value;
                p1.NguoiDuyet = item.NguoiDuyet;
                p1.NguoiTao = item.NguoiTao;
                p1.SoFile = item.SoFile;
                var tTemp = context.ThongTinFiles.Where(p => p.SoFile == p1.SoFile);
                foreach (var item2 in tTemp)
                {
                    p1.SoCont = item2.SoCont;
                }
                if (item.ThoiGianDuyet != null)
                    p1.ThoiGianDuyet = item.ThoiGianDuyet.Value;
                p1.TienAn = (item.TienAn == null) ? 0 : item.TienAn.Value;
                p1.QuaDem = (item.QuaDem == null) ? 0 : item.QuaDem.Value;
                p1.TienLuat = (item.TienLuat == null) ? 0 : item.TienLuat.Value;
                p1.TienVe = (item.TienVe == null) ? 0 : item.TienVe.Value;
                p1.TTHQ = (item.TTHQ == null) ? 0 : item.TTHQ.Value;
                p1.TuyenVC = item.TuyenVC;
                p1.BienSoXe = item.BienSoXe;
                p1.CuocBan = (item.CuocBan == null) ? 0 : item.CuocBan.Value;
                p1.CuocMua = (item.CuocMua == null) ? 0 : item.CuocMua.Value;
                p1.DiemTraHang = (item.DiemTraHang == null) ? 0 : item.DiemTraHang.Value;
                p1.DuyetChi = (item.DuyetChi == null) ? false : item.DuyetChi.Value;
                p1.LaiXe = item.LaiXe;
                p1.Chon = item.Chon;
                p1.GhiChu = item.GhiChu;
                q.Add(p1);
            }
            return q;
        }
        [WebMethod]
        public void XoaThongTinFile(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            ThongTinFile table = context.ThongTinFiles.Single(p => p.IDLoHang == IDLoHang);
            context.ThongTinFiles.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public int KiemTra_File_CoLapBangKeCP(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangLietKeCPs.Where(p=>p.IDLoHang==IDLoHang);
           return table.Count();
        }
        [WebMethod]
        public void XoaBangDieuXe(int IDBangPhi)
        {
            if (IDBangPhi > 0)
            {
                vua45987_vudacoEntities context = new vua45987_vudacoEntities();
                var t4 = context.BangDieuXes.Where(p => p.IDBangPhi == IDBangPhi).Take(1);
                string id = "";
                foreach (var item in t4)
                {
                    id = item.MaDieuXe;
                }
                BangDieuXe t1 = context.BangDieuXes.Single(p => p.IDBangPhi == IDBangPhi);
                context.BangDieuXes.Remove(t1);
                context.SaveChanges();

                if (id != "")
                {
                    if (context.BangPhiDiDuongs.Where(p => p.MaDieuXe == id).Count() > 0)
                    {
                        BangPhiDiDuong t3 = context.BangPhiDiDuongs.SingleOrDefault(p => p.MaDieuXe == id);
                        t3.DuyetChi = false;
                        t3.NguoiDuyet = "";
                        t3.ThoiGianDuyet = null;
                        context.SaveChanges();
                    }
                }
                //xoa bang ke chi tiet
                var t2 = context.BangDieuXe_ChiTiet.Where(p => p.IDBangPhi == IDBangPhi);
                foreach (var item in t2)
                {
                    using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                    {
                        BangDieuXe_ChiTiet t11 = context1.BangDieuXe_ChiTiet.Single(p => p.IDCT == item.IDCT);
                        context1.BangDieuXe_ChiTiet.Remove(t11);
                        context1.SaveChanges();
                    }
                }
            }
        }
        //bang kê chi phi
        [WebMethod]
        public List<BangLietKeCP>BangKe_TheoIDLoHang(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table= context.BangLietKeCPs.Where(p => p.IDLoHang == IDLoHang);
            return table.ToList();

        }
        [WebMethod]
        public DataTable BangKeCP_ChiTiet_HQ(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("MaChiPhi");
            dt.Columns.Add("TenChiPhi");
            dt.Columns.Add("SoTien",typeof(double));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("IDCPCT", typeof(int));
            var t4 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.DanhMuc_CPHQ on a.MaChiPhi_HQ equals b.MaChiPhi
                      select new { a.MaChiPhi_HQ, b.TenChiPhi, SoTien = a.SoTien_HQ, GhiChu = a.GhiChu_HQ, a.IDLoHang, a.IDCPCT })
                         .Where(p => p.IDLoHang == IDLoHang && p.MaChiPhi_HQ != null);
            foreach (var item in t4)
            {
                DataRow row = dt.NewRow();
                row["MaChiPhi"] = item.MaChiPhi_HQ;
                row["TenChiPhi"] = item.TenChiPhi;
                row["SoTien"] = item.SoTien;
                row["GhiChu"] = item.GhiChu;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable BangKeCP_ChiTiet_HQ_IDCP(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("MaChiPhi");
            dt.Columns.Add("TenChiPhi");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("IDCPCT", typeof(int));
            var t4 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.DanhMuc_CPHQ on a.MaChiPhi_HQ equals b.MaChiPhi
                      select new { a.MaChiPhi_HQ, b.TenChiPhi, SoTien = a.SoTien_HQ, GhiChu = a.GhiChu_HQ, a.IDLoHang, a.IDCPCT,a.IDCP })
                         .Where(p => p.IDCP == IDCP && p.MaChiPhi_HQ != null);
            foreach (var item in t4)
            {
                DataRow row = dt.NewRow();
                row["MaChiPhi"] = item.MaChiPhi_HQ;
                row["TenChiPhi"] = item.TenChiPhi;
                row["SoTien"] = item.SoTien;
                row["GhiChu"] = item.GhiChu;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable BangKeCP_ChiTiet_ChiHo_IDCP(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("LinkTaiHoaDon");
            dt.Columns.Add("MaTraCuu");
            dt.Columns.Add("MaChiHo");
            dt.Columns.Add("TenChiHo");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("IDCPCT", typeof(int));
            var t4 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.DanhMuc_PhiChiHo on a.MaChiHo equals b.MaChiHo
                      select new { MaChiPhi_HQ = a.MaChiHo, TenChiPhi = b.TenChiHo, SoTien = a.SoTien_ChiHo, GhiChu = a.GhiChu_ChiHo, a.IDLoHang, a.IDCPCT,a.IDCP,a.LinkTaiHoaDon,a.MaTraCuu })
                         .Where(p => p.IDCP == IDCP && p.MaChiPhi_HQ != null);
            foreach (var item in t4)
            {
                DataRow row = dt.NewRow();
                row["LinkTaiHoaDon"] = item.LinkTaiHoaDon;
                row["MaTraCuu"] = item.MaTraCuu;
                row["MaChiHo"] = item.MaChiPhi_HQ;
                row["TenChiHo"] = item.TenChiPhi;
                row["SoTien"] = item.SoTien;
                row["GhiChu"] = item.GhiChu;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public List<BangLietKeCP>BangLietKeCP_TheoIDCP(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangLietKeCPs.Where(p=>p.IDCP==IDCP);
            return table.ToList();
        }
        [WebMethod]
        public DataTable BangKeCP_ChiTiet_ChiHo(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("MaChiHo");
            dt.Columns.Add("TenChiHo");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("IDCPCT", typeof(int));
            var t4 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.DanhMuc_PhiChiHo on a.MaChiHo equals b.MaChiHo
                      select new { MaChiPhi_HQ= a.MaChiHo, TenChiPhi= b.TenChiHo, SoTien = a.SoTien_ChiHo, GhiChu = a.GhiChu_ChiHo, a.IDLoHang, a.IDCPCT })
                         .Where(p => p.IDLoHang == IDLoHang && p.MaChiPhi_HQ != null);
            foreach (var item in t4)
            {
                DataRow row = dt.NewRow();
                row["MaChiHo"] = item.MaChiPhi_HQ;
                row["TenChiHo"] = item.TenChiPhi;
                row["SoTien"] = item.SoTien;
                row["GhiChu"] = item.GhiChu;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable BangKeChiPhiNangHa_ChiTiet(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("MaChiHo");
            dt.Columns.Add("MaNhaCungCap");
            dt.Columns.Add("TenChiHo");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("IDCPCT", typeof(int));
            var t4 = (from a in context.BangPhoiNangHa_ChiTiet
                      join b in context.DanhMuc_PhiChiHo on a.MaChiHo equals b.MaChiHo
                      select new { MaChiPhi_HQ = a.MaChiHo, TenChiPhi = b.TenChiHo, SoTien = a.SoTien_ChiHo, GhiChu = a.GhiChu_ChiHo, a.IDLoHang, a.IDCPCT,a.SoHoaDon,a.MaNhaCungCap })
                         .Where(p => p.IDLoHang == IDLoHang && p.MaChiPhi_HQ != null);
            foreach (var item in t4)
            {
                DataRow row = dt.NewRow();
                row["MaChiHo"] = item.MaChiPhi_HQ;
                row["TenChiHo"] = item.TenChiPhi;
                row["SoTien"] = item.SoTien;
                row["GhiChu"] = item.GhiChu;
                row["SoHoaDon"] = item.SoHoaDon;
                row["MaNhaCungCap"] = item.MaNhaCungCap;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public List<BangLietKeCP_BoSung>BangLietKeBoSung_TheoIDCP(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangLietKeCP_BoSung.Where(p=>p.IDCP==IDCP);
            return table.ToList();
        }
        [WebMethod]
        public void BangKeCP_BoSUNG_Them(BangLietKeCP_BoSung table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangLietKeCP_BoSung.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public void BangKeCP_Them(BangLietKeCP table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangLietKeCPs.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public int Top1_IDCP()
        {
            int id = 0;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangLietKeCPs.OrderByDescending(p=>p.IDCP).Take(1);
            foreach (var item in table)
            {
                id = item.IDCP;
            }
            return id;
        }
        [WebMethod]
        public int IDLoHang_Theo_IDCP(int IDCP)
        {
            int id = 0;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangLietKeCPs.Where(p=>p.IDCP== IDCP);
            foreach (var item in table)
            {
                id = item.IDLoHang.Value;
            }
            return id;
        }
        [WebMethod]
        public void BangKeCPCT_Them(BangLietKeCP_ChiTiet table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangLietKeCP_ChiTiet.Add(table1);
            context.SaveChanges();
        }
        //[WebMethod]
        //public DataTable BangLietKeChiPhi_Xem(DateTime TuNgay, DateTime DenNgay)
        //{
        //    vua45987_vudacoEntities context = new vua45987_vudacoEntities();
        //    DataTable dt = new DataTable("table");
        //    dt.Columns.Add("IDLoHang");
        //    dt.Columns.Add("MaKhachHang");
        //    dt.Columns.Add("SoFile");
        //    dt.Columns.Add("SoToKhai");
        //    dt.Columns.Add("SoBill");
        //    dt.Columns.Add("SoLuong");
        //    dt.Columns.Add("SoCont");
        //    dt.Columns.Add("TenSales");
        //    dt.Columns.Add("TenGiaoNhan");
        //    dt.Columns.Add("LoaiHang");
        //    dt.Columns.Add("TinhChat");
        //    dt.Columns.Add("SoLuongToKhai");
        //    dt.Columns.Add("LoaiToKhai");
        //    dt.Columns.Add("NghiepVu");
        //    dt.Columns.Add("PhatSinh");
        //    dt.Columns.Add("DuyetUng", typeof(double));
        //    dt.Columns.Add("TaiKhoanThucHien");
        //    dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
        //    dt.Columns.Add("GhiChu");
        //    dt.Columns.Add("Chon", typeof(bool));
        //    List<clsBangLietKeChiPhi> q = new List<clsBangLietKeChiPhi>();
        //    var table = context.ThongTinFiles
        //              .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
        // DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0&&p.LoaiHang.Contains("HangCont")==true);
        //    foreach (var item in table)
        //    {

        //        var t = context.BangLietKeCPs.Where(p => p.IDLoHang == item.IDLoHang);
        //        if (t.Count() == 0)
        //        {
        //            DataRow row = dt.NewRow();
        //            row["IDLoHang"] = item.IDLoHang;
        //            var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
        //            foreach (var item1 in t1)
        //            {
        //                row["MaKhachHang"] = item1.TenVietTat;
        //            }
        //            row["SoFile"] = item.SoFile;
        //            row["SoToKhai"] = item.SoToKhai;
        //            row["SoBill"] = item.SoBill;
        //            row["SoLuong"] = item.SoLuong;
        //            row["SoCont"] = item.SoCont;
        //            row["TenSales"] = item.TenSales;
        //            //
        //            string _Ten = "";
        //            var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
        //                                   join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
        //                                   select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
        //            foreach (var item1 in t_NguoiGiaoNhan)
        //            {
        //                _Ten += item1.TenNhanVien + ",";
        //            }
        //            if (_Ten.Trim().Length > 0)
        //                _Ten = _Ten.Substring(0, _Ten.Length - 1);
        //            row["TenGiaoNhan"] = _Ten;
        //            //
        //            if (item.LoaiHang.Trim() == "HangLe")
        //                row["LoaiHang"] = "Hàng Lẻ";
        //            else if (item.LoaiHang.Trim() == "HangCont")
        //                row["LoaiHang"] = "Hàng Cont";


        //            if (item.TinhChat.Trim() == "HangNhap")
        //                row["TinhChat"] = "Hàng nhập";
        //            else if (item.TinhChat.Trim() == "HangXuat")
        //                row["TinhChat"] = "Hàng xuất";
        //            row["SoLuongToKhai"] = item.SoLuongToKhai;
        //            if (item.LoaiToKhai.Trim() == "0")
        //                row["LoaiToKhai"] = "Luồng xanh";
        //            else if (item.LoaiToKhai.Trim() == "1")
        //                row["LoaiToKhai"] = "Luồng vàng";
        //            else if (item.LoaiToKhai.Trim() == "2")
        //                row["LoaiToKhai"] = "Luồng đỏ";

        //            if (item.NghiepVu.Trim() == "0")
        //                row["NghiepVu"] = "Thông quan";
        //            else if (item.NghiepVu.Trim() == "1")
        //                row["NghiepVu"] = "Đổi lệnh dưới kho";
        //            else if (item.NghiepVu.Trim() == "2")
        //                row["NghiepVu"] = "Rút ruột";
        //            else if (item.NghiepVu.Trim() == "3")
        //                row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
        //            else if (item.NghiepVu.Trim() == "4")
        //                row["NghiepVu"] = "Không có trucking";

        //            if (item.PhatSinh.Trim() == "0")
        //                row["PhatSinh"] = "Nhiều tờ khai";
        //            else if (item.PhatSinh.Trim() == "1")
        //                //row["PhatSinh"] = "Không";
        //                row["DuyetUng"] = item.DuyetUng;
        //            row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
        //            row["ThoiGianThucHien"] = item.ThoiGianThucHien;
        //            row["GhiChu"] = item.GhiChu;
        //            row["Chon"] = false;
        //            dt.Rows.Add(row);
        //        }
        //    }
        //    dt.TableName = "xem";
        //    return dt;
        //}
        [WebMethod]
        public DataTable BangFileChuaTaoPhiNangHa_Xem(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TaiKhoanThucHien");
            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("Chon", typeof(bool));
            List<clsBangLietKeChiPhi> q = new List<clsBangLietKeChiPhi>();
            var table = context.ThongTinFiles
                      .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
         DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0 && p.LoaiHang.Contains("HangCont") == true);
            foreach (var item in table)
            {

                var t = context.BangPhoiNangHas.Where(p => p.IDLoHang == item.IDLoHang);
                if (t.Count() == 0)
                {
                    double TongDuyetUng = 0;
                    DataRow row = dt.NewRow();
                    row["IDLoHang"] = item.IDLoHang;
                    var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
                    foreach (var item1 in t1)
                    {
                        row["MaKhachHang"] = item1.TenVietTat;
                    }
                    row["SoFile"] = item.SoFile;
                    row["SoToKhai"] = item.SoToKhai;
                    row["SoBill"] = item.SoBill;
                    row["SoLuong"] = item.SoLuong;
                    row["SoCont"] = item.SoCont;
                    row["TenSales"] = item.TenSales;
                    //
                    string _Ten = "";
                    var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                           join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                           select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                    foreach (var item1 in t_NguoiGiaoNhan)
                    {
                        _Ten += item1.TenNhanVien + ",";
                    }
                    if (_Ten.Trim().Length > 0)
                        _Ten = _Ten.Substring(0, _Ten.Length - 1);
                    row["TenGiaoNhan"] = _Ten;
                    //
                    if (item.LoaiHang.Trim() == "HangLe")
                        row["LoaiHang"] = "Hàng Lẻ";
                    else if (item.LoaiHang.Trim() == "HangCont")
                        row["LoaiHang"] = "Hàng Cont";


                    if (item.TinhChat.Trim() == "HangNhap")
                        row["TinhChat"] = "Hàng nhập";
                    else if (item.TinhChat.Trim() == "HangXuat")
                        row["TinhChat"] = "Hàng xuất";
                    row["SoLuongToKhai"] = item.SoLuongToKhai;
                    if (item.LoaiToKhai.Trim() == "0")
                        row["LoaiToKhai"] = "Luồng xanh";
                    else if (item.LoaiToKhai.Trim() == "1")
                        row["LoaiToKhai"] = "Luồng vàng";
                    else if (item.LoaiToKhai.Trim() == "2")
                        row["LoaiToKhai"] = "Luồng đỏ";

                    if (item.NghiepVu.Trim() == "0")
                        row["NghiepVu"] = "Thông quan";
                    else if (item.NghiepVu.Trim() == "1")
                        row["NghiepVu"] = "Đổi lệnh dưới kho";
                    else if (item.NghiepVu.Trim() == "2")
                        row["NghiepVu"] = "Rút ruột";
                    else if (item.NghiepVu.Trim() == "3")
                        row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                    else if (item.NghiepVu.Trim() == "4")
                        row["NghiepVu"] = "Không có trucking";

                    if (item.PhatSinh.Trim() == "0")
                        row["PhatSinh"] = "Nhiều tờ khai";
                    else if (item.PhatSinh.Trim() == "1")
                        //row["PhatSinh"] = "Không";

                     


                    row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
                    row["ThoiGianThucHien"] = item.ThoiGianThucHien;
                    row["GhiChu"] = item.GhiChu;
                    row["Chon"] = false;
                    //update 28.09
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                    row["DuyetUng"] = TongDuyetUng;
                    dt.Rows.Add(row);
                }
            }
            dt.TableName = "xem";
            return dt;
        }
        //[WebMethod]
        //public DataTable BangFileChuaTaoBangKeChiPhi(DateTime TuNgay, DateTime DenNgay)
        //{
        //    vua45987_vudacoEntities context = new vua45987_vudacoEntities();
        //    DataTable dt = new DataTable("table");
        //    dt.Columns.Add("IDLoHang");
        //    dt.Columns.Add("MaKhachHang");
        //    dt.Columns.Add("SoFile");
        //    dt.Columns.Add("SoToKhai");
        //    dt.Columns.Add("SoBill");
        //    dt.Columns.Add("SoLuong");
        //    dt.Columns.Add("SoCont");
        //    dt.Columns.Add("TenSales");
        //    dt.Columns.Add("TenGiaoNhan");
        //    dt.Columns.Add("LoaiHang");
        //    dt.Columns.Add("TinhChat");
        //    dt.Columns.Add("SoLuongToKhai");
        //    dt.Columns.Add("LoaiToKhai");
        //    dt.Columns.Add("NghiepVu");
        //    dt.Columns.Add("PhatSinh");
        //    dt.Columns.Add("DuyetUng", typeof(double));
        //    dt.Columns.Add("TaiKhoanThucHien");
        //    dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
        //    dt.Columns.Add("GhiChu");
        //    dt.Columns.Add("Chon", typeof(bool));
        //    List<clsBangLietKeChiPhi> q = new List<clsBangLietKeChiPhi>();
        //    var table = context.ThongTinFiles
        //              .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
        // DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0 );
        //    foreach (var item in table)
        //    {

        //        var t = context.BangLietKeCPs.Where(p => p.IDLoHang == item.IDLoHang);
        //        if (t.Count() == 0)
        //        {
        //            DataRow row = dt.NewRow();
        //            row["IDLoHang"] = item.IDLoHang;
        //            var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
        //            foreach (var item1 in t1)
        //            {
        //                row["MaKhachHang"] = item1.TenVietTat;
        //            }
        //            row["SoFile"] = item.SoFile;
        //            row["SoToKhai"] = item.SoToKhai;
        //            row["SoBill"] = item.SoBill;
        //            row["SoLuong"] = item.SoLuong;
        //            row["SoCont"] = item.SoCont;
        //            row["TenSales"] = item.TenSales;
        //            //
        //            string _Ten = "";
        //            var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
        //                                   join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
        //                                   select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
        //            foreach (var item1 in t_NguoiGiaoNhan)
        //            {
        //                _Ten += item1.TenNhanVien + ",";
        //            }
        //            if (_Ten.Trim().Length > 0)
        //                _Ten = _Ten.Substring(0, _Ten.Length - 1);
        //            row["TenGiaoNhan"] = _Ten;
        //            //
        //            if (item.LoaiHang.Trim() == "HangLe")
        //                row["LoaiHang"] = "Hàng Lẻ";
        //            else if (item.LoaiHang.Trim() == "HangCont")
        //                row["LoaiHang"] = "Hàng Cont";


        //            if (item.TinhChat.Trim() == "HangNhap")
        //                row["TinhChat"] = "Hàng nhập";
        //            else if (item.TinhChat.Trim() == "HangXuat")
        //                row["TinhChat"] = "Hàng xuất";
        //            row["SoLuongToKhai"] = item.SoLuongToKhai;
        //            if (item.LoaiToKhai.Trim() == "0")
        //                row["LoaiToKhai"] = "Luồng xanh";
        //            else if (item.LoaiToKhai.Trim() == "1")
        //                row["LoaiToKhai"] = "Luồng vàng";
        //            else if (item.LoaiToKhai.Trim() == "2")
        //                row["LoaiToKhai"] = "Luồng đỏ";

        //            if (item.NghiepVu.Trim() == "0")
        //                row["NghiepVu"] = "Thông quan";
        //            else if (item.NghiepVu.Trim() == "1")
        //                row["NghiepVu"] = "Đổi lệnh dưới kho";
        //            else if (item.NghiepVu.Trim() == "2")
        //                row["NghiepVu"] = "Rút ruột";
        //            else if (item.NghiepVu.Trim() == "3")
        //                row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
        //            else if (item.NghiepVu.Trim() == "4")
        //                row["NghiepVu"] = "Không có trucking";

        //            if (item.PhatSinh.Trim() == "0")
        //                row["PhatSinh"] = "Nhiều tờ khai";
        //            else if (item.PhatSinh.Trim() == "1")
        //                //row["PhatSinh"] = "Không";
        //            row["DuyetUng"] = (item.DuyetUng==null)?0:item.DuyetUng.Value;
        //            row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
        //            row["ThoiGianThucHien"] = item.ThoiGianThucHien;
        //            row["GhiChu"] = item.GhiChu;
        //            row["Chon"] = false;
        //            dt.Rows.Add(row);
        //        }
        //    }
        //    dt.TableName = "xem";
        //    return dt;
        //}
        [WebMethod]
        public DataTable BangFileChuaTaoBangKeChiPhi_TheoTK(DateTime TuNgay, DateTime DenNgay,string TK)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TaiKhoanThucHien");
            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("Chon", typeof(bool));
            List<clsBangLietKeChiPhi> q = new List<clsBangLietKeChiPhi>();
            var table = context.ThongTinFiles
                      .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
         DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0);
            foreach (var item in table)
            {
                //kiem tra file nay có thuộc ncc ngoài hay không, nếu phải thì bỏ qua
                var t_ncc_ngoai = (from a in context.ThongTinFile_NguoiGiaoNhan
                                   join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                   select new { a.MaNhanVien, b.NCCNgoai, a.SoFile }).Where(p=>p.SoFile==item.SoFile&&p.NCCNgoai==true);
                if (t_ncc_ngoai.Count() == 0)
                {
                    var t = context.BangLietKeCPs.Where(p => p.IDLoHang == item.IDLoHang && p.NguoiTaoBangKe == TK);
                    if (t.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["IDLoHang"] = item.IDLoHang;
                        var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
                        foreach (var item1 in t1)
                        {
                            row["MaKhachHang"] = item1.TenVietTat;
                        }
                        row["SoFile"] = item.SoFile;
                        row["SoToKhai"] = item.SoToKhai;
                        row["SoBill"] = item.SoBill;
                        row["SoLuong"] = item.SoLuong;
                        row["SoCont"] = item.SoCont;
                        row["TenSales"] = item.TenSales;
                        //
                        string _Ten = "";
                        var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                               join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                               select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                        foreach (var item1 in t_NguoiGiaoNhan)
                        {
                            _Ten += item1.TenNhanVien + ",";
                        }
                        if (_Ten.Trim().Length > 0)
                            _Ten = _Ten.Substring(0, _Ten.Length - 1);
                        row["TenGiaoNhan"] = _Ten;
                        //
                        if (item.LoaiHang.Trim() == "HangLe")
                            row["LoaiHang"] = "Hàng Lẻ";
                        else if (item.LoaiHang.Trim() == "HangCont")
                            row["LoaiHang"] = "Hàng Cont";


                        if (item.TinhChat.Trim() == "HangNhap")
                            row["TinhChat"] = "Hàng nhập";
                        else if (item.TinhChat.Trim() == "HangXuat")
                            row["TinhChat"] = "Hàng xuất";
                        row["SoLuongToKhai"] = item.SoLuongToKhai;
                        if (item.LoaiToKhai.Trim() == "0")
                            row["LoaiToKhai"] = "Luồng xanh";
                        else if (item.LoaiToKhai.Trim() == "1")
                            row["LoaiToKhai"] = "Luồng vàng";
                        else if (item.LoaiToKhai.Trim() == "2")
                            row["LoaiToKhai"] = "Luồng đỏ";

                        if (item.NghiepVu.Trim() == "0")
                            row["NghiepVu"] = "Thông quan";
                        else if (item.NghiepVu.Trim() == "1")
                            row["NghiepVu"] = "Đổi lệnh dưới kho";
                        else if (item.NghiepVu.Trim() == "2")
                            row["NghiepVu"] = "Rút ruột";
                        else if (item.NghiepVu.Trim() == "3")
                            row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                        else if (item.NghiepVu.Trim() == "4")
                            row["NghiepVu"] = "Không có trucking";

                        if (item.PhatSinh.Trim() == "0")
                            row["PhatSinh"] = "Nhiều tờ khai";
                        else if (item.PhatSinh.Trim() == "1")
                            //row["PhatSinh"] = "Không";
                            //    row["DuyetUng"] = (item.DuyetUng == null) ? 0 : item.DuyetUng.Value;
                            row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
                        row["ThoiGianThucHien"] = item.ThoiGianThucHien;
                        row["GhiChu"] = item.GhiChu;
                        row["Chon"] = false;
                        //update 28.09
                        double TongDuyetUng = 0;
                        var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                        foreach (var itemDuyetUng in t_duyetUng)
                        {
                            TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                        }
                        row["DuyetUng"] = TongDuyetUng;
                        dt.Rows.Add(row);
                    }
                }
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable BangKe_BoSUNG(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("IDLoHang");
            dt1.Columns.Add("IDCP");
            dt1.Columns.Add("Chon", typeof(bool));
            dt1.Columns.Add("NgayTaoBangKe", typeof(DateTime));
            dt1.Columns.Add("NgayHoanUng");
            dt1.Columns.Add("NgayHoanUngNhanVien");
            dt1.Columns.Add("XacNhanHoanUng", typeof(bool));
            dt1.Columns.Add("XacNhanHoangUngNhanVien", typeof(bool));
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("SoBill");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("SoCont");
            dt1.Columns.Add("SoLuong");
            dt1.Columns.Add("DuyetUng", typeof(double));
            dt1.Columns.Add("SoLuongToKhai");
            dt1.Columns.Add("TenKhachHang");
            dt1.Columns.Add("TenGiaoNhan");
            dt1.Columns.Add("TongPhiHQ", typeof(double));
            dt1.Columns.Add("PhiKTCL", typeof(double));
            dt1.Columns.Add("TongPhiChiHo", typeof(double));
            dt1.Columns.Add("TienCuoc", typeof(double));
            dt1.Columns.Add("ConLai", typeof(double));
            var t3 = (from d in context.BangLietKeCP_BoSung
                    join a in context.BangLietKeCPs on d.IDCP equals a.IDCP
                          //join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join b in context.ThongTinFiles on d.IDLoHang equals b.IDLoHang into c1
                      from sub1 in c1.DefaultIfEmpty()
                      join c in context.DanhSachKhachHangs on sub1.MaKhachHang equals c.MaKhachHang
                      //  join d in context.NhanViens on b.TenGiaoNhan equals d.MaNhanVien
                      select new
                      {
                          d.ThoiGianTao,
                          d.NguoiTao,
                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          sub1.SoBill,
                          sub1.SoFile,
                          sub1.SoCont,
                          sub1.SoLuong,
                        //  d.DuyetUng,
                          sub1.SoLuongToKhai,
                          c.TenVietTat,
                          a.NgayHoanUng,
                          a.NgayHoanUngNhanVien,
                          a.XacNhanHoanUng,
                          a.XacNhanHoangUngNhanVien,
                          a.IDCP
                         
                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianTao) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.ThoiGianTao) <= 0);

            foreach (var item in t3)
            {
                double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                DataRow row = dt1.NewRow();
                row["Chon"] = false;
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                       join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                       select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten += item1.TenNhanVien + ",";
                }
                if (_Ten.Trim().Length > 0)
                    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;
                //

                row["IDCP"] = item.IDCP;
                row["IDLoHang"] = item.IDLoHang;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe;
                row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                if (item.NgayHoanUng == null)
                    row["NgayHoanUng"] = "";
                else
                    row["NgayHoanUng"] = item.NgayHoanUng.Value.ToString("dd/MM/yyyy");
                if (item.NgayHoanUngNhanVien == null)
                    row["NgayHoanUngNhanVien"] = "";
                else
                    row["NgayHoanUngNhanVien"] = item.NgayHoanUngNhanVien.Value.ToString("dd/MM/yyyy");
                if (item.XacNhanHoanUng == null)
                    row["XacNhanHoanUng"] = false;
                else
                    row["XacNhanHoanUng"] = item.XacNhanHoanUng;
                if (item.XacNhanHoangUngNhanVien == null)
                    row["XacNhanHoangUngNhanVien"] = false;
                else
                    row["XacNhanHoangUngNhanVien"] = item.XacNhanHoangUngNhanVien;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                //update 28.09
                double TongDuyetUng = 0;
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile&&p.MaNhanVien==item.NguoiTao);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
                row["DuyetUng"] = TongDuyetUng;
                // row["DuyetUng"] = (item.DuyetUng == null) ? 0 : item.DuyetUng.Value;
                tamung = TongDuyetUng;
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                row["TenKhachHang"] = item.TenVietTat;
                row["PhiKTCL"] = item.PhiDangKy;
                phiKTCL = item.PhiDangKy.Value;

                var tongHQ = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item1 in tongHQ)
                {
                    tong_HQ += item1.SoTien_HQ.Value;
                }
                row["TongPhiHQ"] = tong_HQ;
                var tongCH = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item1 in tongCH)
                {
                    tong_chiHo += item1.SoTien_ChiHo.Value;
                }
                row["TongPhiChiHo"] = tong_chiHo;
                row["ConLai"] = tong_HQ + phiKTCL + tong_chiHo - tamung;
                //tien cuoc
                var t4 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo == "CH01");
                foreach (var item1 in t4)
                {
                    row["TienCuoc"] = item1.SoTien_ChiHo.Value;
                }
                dt1.Rows.Add(row);
            }
            dt1.TableName = "xem";
            return dt1;
        }
        [WebMethod]
        public DataTable BangKe(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("IDLoHang");
            dt1.Columns.Add("IDCP");
            dt1.Columns.Add("Chon",typeof(bool));
            dt1.Columns.Add("NgayTaoBangKe", typeof(DateTime));
            dt1.Columns.Add("NgayHoanUng");
            dt1.Columns.Add("NgayHoanUngNhanVien");
            dt1.Columns.Add("XacNhanHoanUng", typeof(bool));
            dt1.Columns.Add("XacNhanHoangUngNhanVien", typeof(bool));
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("SoBill");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("SoCont");
            dt1.Columns.Add("SoLuong");
            dt1.Columns.Add("DuyetUng", typeof(double));
            dt1.Columns.Add("SoLuongToKhai");
            dt1.Columns.Add("TenKhachHang");
            dt1.Columns.Add("MaKhachHang");
            dt1.Columns.Add("MaNhanVien");
            dt1.Columns.Add("TenGiaoNhan");
            dt1.Columns.Add("TongPhiHQ", typeof(double));
            dt1.Columns.Add("PhiKTCL", typeof(double));
            dt1.Columns.Add("TongPhiChiHo", typeof(double));
            dt1.Columns.Add("TienCuoc", typeof(double));
            dt1.Columns.Add("ConLai", typeof(double));
            dt1.Columns.Add("Duyet", typeof(bool));
            dt1.Columns.Add("NgayDuyet", typeof(DateTime));
            dt1.Columns.Add("NguoiDuyet");
            dt1.Columns.Add("LyDoDuyet");

            var t3 = (from a in context.BangLietKeCPs
                          //      //join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                          //  join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang into c1
                          //  from sub1 in c1.DefaultIfEmpty()
                          //  join c in context.DanhSachKhachHangs on sub1.MaKhachHang equals c.MaKhachHang
                          ////  join d in context.NhanViens on b.TenGiaoNhan equals d.MaNhanVien
                          join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                      //  join d in context.NhanViens on b.TenGiaoNhan equals d.MaNhanVien
                      select new
                      {
                         
                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          b.SoBill,
                          b.SoFile,
                          b.SoCont,
                          b.SoLuong,
                         // sub1.DuyetUng,
                          b.SoLuongToKhai,
                          c.TenVietTat,
                          a.NgayHoanUng,
                          a.NgayHoanUngNhanVien,
                          a.XacNhanHoanUng,
                          a.XacNhanHoangUngNhanVien,
                          a.MaNhanVien,
                          a.IDCP,
                          b.MaKhachHang,
                          a.Duyet,
                          a.LyDoDuyet,
                          a.NgayDuyet,
                          a.NguoiDuyet
                         
                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0);                                                      

            foreach (var item in t3)
            {                                                    
                double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                DataRow row = dt1.NewRow();
                row["Duyet"] =(item.Duyet==null)?false: item.Duyet;
                row["LyDoDuyet"] = item.LyDoDuyet;
                if(item.NgayDuyet!=null)
                  row["NgayDuyet"] = item.NgayDuyet.Value;
                row["NguoiDuyet"] = item.NguoiDuyet;
                row["Chon"] = false;
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = context.NhanViens.Where(p=>p.MaNhanVien==item.MaNhanVien);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten = item1.TenNhanVien ;
                }
                //if (_Ten.Trim().Length > 0)
                //    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;
                //
                row["MaKhachHang"] = item.MaKhachHang;
                row["MaNhanVien"] = item.MaNhanVien;
                row["IDCP"] = item.IDCP;                                                                                                                                                                                                                                                            
                row["IDLoHang"] = item.IDLoHang;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe;
                row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                if (item.NgayHoanUng == null)
                    row["NgayHoanUng"] = "";
                else
                   row["NgayHoanUng"] = item.NgayHoanUng.Value.ToString("dd/MM/yyyy");
                if (item.NgayHoanUngNhanVien == null)
                    row["NgayHoanUngNhanVien"] = "";
                else
                    row["NgayHoanUngNhanVien"] = item.NgayHoanUngNhanVien.Value.ToString("dd/MM/yyyy");
                if (item.XacNhanHoanUng == null)
                    row["XacNhanHoanUng"] = false;
                else
                    row["XacNhanHoanUng"] = item.XacNhanHoanUng;
                if (item.XacNhanHoangUngNhanVien == null)
                    row["XacNhanHoangUngNhanVien"] = false;
                else
                    row["XacNhanHoangUngNhanVien"] = item.XacNhanHoangUngNhanVien;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                //update 28.09
                double TongDuyetUng = 0;
                int demSL = context.BangLietKeCPs.Where(p =>p.SoFile == item.SoFile).Count();
                if (demSL == 0)
                    TongDuyetUng = 0;
                else if (demSL == 1)
                {
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                }
                else
                {
                    int dem = context.BangLietKeCPs.Where(p =>  p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien).OrderBy(p=>p.IDCP).Take(1).Count();
                    if (dem == 1)//dòng đầu tiên của lô hàng
                    {
                        var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien);
                        foreach (var itemDuyetUng in t_duyetUng)
                        {
                            TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                        }
                    }
                    else
                        TongDuyetUng = 0;
                }
                row["DuyetUng"] = TongDuyetUng;
                // row["DuyetUng"] = (item.DuyetUng==null)?0:item.DuyetUng.Value;
                tamung = TongDuyetUng;
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                row["TenKhachHang"] = item.TenVietTat;
                row["PhiKTCL"] = item.PhiDangKy;
                phiKTCL = item.PhiDangKy.Value;

                var tongHQ = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item1 in tongHQ)
                {
                    tong_HQ += item1.SoTien_HQ.Value;
                }
                row["TongPhiHQ"] = tong_HQ;
                var tongCH = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item1 in tongCH)
                {
                    tong_chiHo += item1.SoTien_ChiHo.Value;
                }
                row["TongPhiChiHo"] = tong_chiHo;
                row["ConLai"] = tamung- tong_HQ - phiKTCL - tong_chiHo;
              
                //tien cuoc
                var t4 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo == "CH01");
                foreach (var item1 in t4)
                {
                    row["TienCuoc"] = item1.SoTien_ChiHo.Value;
                }
                dt1.Rows.Add(row);
            }
            dt1.TableName = "xem";
            return dt1;
        }
        [WebMethod]
        public List<FileGiaChiTiet>FileGiaChiTiet_TheoIDCP(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileGiaChiTiets.Where(p=>p.IDCP==IDCP);
            return table.ToList();
        }
        [WebMethod]
        public DataTable BangKe_ChuaDuyet(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("IDLoHang");
            dt1.Columns.Add("IDCP");
            dt1.Columns.Add("Chon", typeof(bool));
            dt1.Columns.Add("NgayTaoBangKe", typeof(DateTime));
            dt1.Columns.Add("NgayHoanUng");
            dt1.Columns.Add("NgayHoanUngNhanVien");
            dt1.Columns.Add("XacNhanHoanUng", typeof(bool));
            dt1.Columns.Add("XacNhanHoangUngNhanVien", typeof(bool));
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("SoBill");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("SoCont");
            dt1.Columns.Add("SoLuong");
            dt1.Columns.Add("DuyetUng", typeof(double));
            dt1.Columns.Add("SoLuongToKhai");
            dt1.Columns.Add("TenKhachHang");
            dt1.Columns.Add("MaKhachHang");
            dt1.Columns.Add("MaNhanVien");
            dt1.Columns.Add("TenGiaoNhan");
            dt1.Columns.Add("TongPhiHQ", typeof(double));
            dt1.Columns.Add("PhiKTCL", typeof(double));
            dt1.Columns.Add("TongPhiChiHo", typeof(double));
            dt1.Columns.Add("TienCuoc", typeof(double));
            dt1.Columns.Add("ConLai", typeof(double));

            var t3 = (from a in context.BangLietKeCPs
                          //join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang into c1
                      from sub1 in c1.DefaultIfEmpty()
                      join c in context.DanhSachKhachHangs on sub1.MaKhachHang equals c.MaKhachHang
                      //  join d in context.NhanViens on b.TenGiaoNhan equals d.MaNhanVien
                      select new
                      {

                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          sub1.SoBill,
                          sub1.SoFile,
                          sub1.SoCont,
                          sub1.SoLuong,
                          // sub1.DuyetUng,
                          sub1.SoLuongToKhai,
                          c.TenVietTat,
                          a.NgayHoanUng,
                          a.NgayHoanUngNhanVien,
                          a.XacNhanHoanUng,
                          a.XacNhanHoangUngNhanVien,
                          a.MaNhanVien,
                          a.IDCP,
                          sub1.MaKhachHang,
                          a.Duyet

                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0&&p.Duyet!=true);

            foreach (var item in t3)
            {
                double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                DataRow row = dt1.NewRow();
                row["Chon"] = false;
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten = item1.TenNhanVien;
                }
                //if (_Ten.Trim().Length > 0)
                //    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;
                //
                row["MaKhachHang"] = item.MaKhachHang;
                row["MaNhanVien"] = item.MaNhanVien;
                row["IDCP"] = item.IDCP;
                row["IDLoHang"] = item.IDLoHang;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe;
                row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                if (item.NgayHoanUng == null)
                    row["NgayHoanUng"] = "";
                else
                    row["NgayHoanUng"] = item.NgayHoanUng.Value.ToString("dd/MM/yyyy");
                if (item.NgayHoanUngNhanVien == null)
                    row["NgayHoanUngNhanVien"] = "";
                else
                    row["NgayHoanUngNhanVien"] = item.NgayHoanUngNhanVien.Value.ToString("dd/MM/yyyy");
                if (item.XacNhanHoanUng == null)
                    row["XacNhanHoanUng"] = false;
                else
                    row["XacNhanHoanUng"] = item.XacNhanHoanUng;
                if (item.XacNhanHoangUngNhanVien == null)
                    row["XacNhanHoangUngNhanVien"] = false;
                else
                    row["XacNhanHoangUngNhanVien"] = item.XacNhanHoangUngNhanVien;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                //update 28.09
                double TongDuyetUng = 0;
                int demSL = context.BangLietKeCPs.Where(p => p.SoFile == item.SoFile).Count();
                if (demSL == 0)
                    TongDuyetUng = 0;
                else if (demSL == 1)
                {
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                }
                else
                {
                    int dem = context.BangLietKeCPs.Where(p => p.IDCP < item.IDCP && p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien).Count();
                    if (dem == 0)//dòng đầu tiên của lô hàng
                    {
                        var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien);
                        foreach (var itemDuyetUng in t_duyetUng)
                        {
                            TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                        }
                    }
                    else
                        TongDuyetUng = 0;
                }
                row["DuyetUng"] = TongDuyetUng;
                // row["DuyetUng"] = (item.DuyetUng==null)?0:item.DuyetUng.Value;
                tamung = TongDuyetUng;
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                row["TenKhachHang"] = item.TenVietTat;
                row["PhiKTCL"] = item.PhiDangKy;
                phiKTCL = item.PhiDangKy.Value;

                var tongHQ = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item1 in tongHQ)
                {
                    tong_HQ += item1.SoTien_HQ.Value;
                }
                row["TongPhiHQ"] = tong_HQ;
                var tongCH = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item1 in tongCH)
                {
                    tong_chiHo += item1.SoTien_ChiHo.Value;
                }
                row["TongPhiChiHo"] = tong_chiHo;
                row["ConLai"] = tamung - tong_HQ - phiKTCL - tong_chiHo;

                //tien cuoc
                var t4 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo == "CH01");
                foreach (var item1 in t4)
                {
                    row["TienCuoc"] = item1.SoTien_ChiHo.Value;
                }
                dt1.Rows.Add(row);
            }
            dt1.TableName = "xem";
            return dt1;
        }
        [WebMethod]
        public DataTable BangKe_DaDuyet(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("IDLoHang");
            dt1.Columns.Add("IDCP");
            dt1.Columns.Add("Chon", typeof(bool));
            dt1.Columns.Add("NgayTaoBangKe", typeof(DateTime));
            dt1.Columns.Add("NgayHoanUng");
            dt1.Columns.Add("NgayHoanUngNhanVien");
            dt1.Columns.Add("XacNhanHoanUng", typeof(bool));
            dt1.Columns.Add("XacNhanHoangUngNhanVien", typeof(bool));
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("SoBill");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("SoCont");
            dt1.Columns.Add("SoLuong");
            dt1.Columns.Add("DuyetUng", typeof(double));
            dt1.Columns.Add("SoLuongToKhai");
            dt1.Columns.Add("TenKhachHang");
            dt1.Columns.Add("MaKhachHang");
            dt1.Columns.Add("MaNhanVien");
            dt1.Columns.Add("TenGiaoNhan");
            dt1.Columns.Add("TongPhiHQ", typeof(double));
            dt1.Columns.Add("PhiKTCL", typeof(double));
            dt1.Columns.Add("TongPhiChiHo", typeof(double));
            dt1.Columns.Add("TienCuoc", typeof(double));
            dt1.Columns.Add("ConLai", typeof(double));
            dt1.Columns.Add("Duyet", typeof(bool));
            dt1.Columns.Add("NgayDuyet", typeof(DateTime));
            dt1.Columns.Add("NguoiDuyet");
            dt1.Columns.Add("LyDoDuyet");

            var t3 = (from a in context.BangLietKeCPs
                          //join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang into c1
                      from sub1 in c1.DefaultIfEmpty()
                      join c in context.DanhSachKhachHangs on sub1.MaKhachHang equals c.MaKhachHang
                      //  join d in context.NhanViens on b.TenGiaoNhan equals d.MaNhanVien
                      select new
                      {

                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          sub1.SoBill,
                          sub1.SoFile,
                          sub1.SoCont,
                          sub1.SoLuong,
                          // sub1.DuyetUng,
                          sub1.SoLuongToKhai,
                          c.TenVietTat,
                          a.NgayHoanUng,
                          a.NgayHoanUngNhanVien,
                          a.XacNhanHoanUng,
                          a.XacNhanHoangUngNhanVien,
                          a.MaNhanVien,
                          a.IDCP,
                          sub1.MaKhachHang,
                          a.Duyet,
                          a.LyDoDuyet,
                          a.NguoiDuyet,
                          a.NgayDuyet

                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0 && p.Duyet == true);

            foreach (var item in t3)
            {
                double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                DataRow row = dt1.NewRow();
                row["Chon"] = false;
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten = item1.TenNhanVien;
                }
                //if (_Ten.Trim().Length > 0)
                //    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["Duyet"] = item.Duyet;
                row["LyDoDuyet"] = item.LyDoDuyet;
                row["NguoiDuyet"] = item.NguoiDuyet;
                row["NgayDuyet"] = item.NgayDuyet;
                row["TenGiaoNhan"] = _Ten;
                //
                row["MaKhachHang"] = item.MaKhachHang;
                row["MaNhanVien"] = item.MaNhanVien;
                row["IDCP"] = item.IDCP;
                row["IDLoHang"] = item.IDLoHang;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe;
                row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                if (item.NgayHoanUng == null)
                    row["NgayHoanUng"] = "";
                else
                    row["NgayHoanUng"] = item.NgayHoanUng.Value.ToString("dd/MM/yyyy");
                if (item.NgayHoanUngNhanVien == null)
                    row["NgayHoanUngNhanVien"] = "";
                else
                    row["NgayHoanUngNhanVien"] = item.NgayHoanUngNhanVien.Value.ToString("dd/MM/yyyy");
                if (item.XacNhanHoanUng == null)
                    row["XacNhanHoanUng"] = false;
                else
                    row["XacNhanHoanUng"] = item.XacNhanHoanUng;
                if (item.XacNhanHoangUngNhanVien == null)
                    row["XacNhanHoangUngNhanVien"] = false;
                else
                    row["XacNhanHoangUngNhanVien"] = item.XacNhanHoangUngNhanVien;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                //update 28.09
                double TongDuyetUng = 0;
                int demSL = context.BangLietKeCPs.Where(p => p.SoFile == item.SoFile).Count();
                if (demSL == 0)
                    TongDuyetUng = 0;
                else if (demSL == 1)
                {
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                }
                else
                {
                    int dem = context.BangLietKeCPs.Where(p => p.IDCP < item.IDCP && p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien).Count();
                    if (dem == 0)//dòng đầu tiên của lô hàng
                    {
                        var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile && p.MaNhanVien == item.MaNhanVien);
                        foreach (var itemDuyetUng in t_duyetUng)
                        {
                            TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                        }
                    }
                    else
                        TongDuyetUng = 0;
                }
                row["DuyetUng"] = TongDuyetUng;
                // row["DuyetUng"] = (item.DuyetUng==null)?0:item.DuyetUng.Value;
                tamung = TongDuyetUng;
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                row["TenKhachHang"] = item.TenVietTat;
                row["PhiKTCL"] = item.PhiDangKy;
                phiKTCL = item.PhiDangKy.Value;

                var tongHQ = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item1 in tongHQ)
                {
                    tong_HQ += item1.SoTien_HQ.Value;
                }
                row["TongPhiHQ"] = tong_HQ;
                var tongCH = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item1 in tongCH)
                {
                    tong_chiHo += item1.SoTien_ChiHo.Value;
                }
                row["TongPhiChiHo"] = tong_chiHo;
                row["ConLai"] = tamung - tong_HQ - phiKTCL - tong_chiHo;

                //tien cuoc
                var t4 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo == "CH01");
                foreach (var item1 in t4)
                {
                    row["TienCuoc"] = item1.SoTien_ChiHo.Value;
                }
                dt1.Rows.Add(row);
            }
            dt1.TableName = "xem";
            return dt1;
        }
        [WebMethod]
        public void BangKe_Duyet(int IDCP,string LyDo,string NguoiDuyet,DateTime ThoiGianDuyet)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var tablec = context.BangLietKeCPs.Single(p=>p.IDCP==IDCP);
            tablec.LyDoDuyet = LyDo;
            tablec.NguoiDuyet = NguoiDuyet;
            tablec.NgayDuyet = ThoiGianDuyet;
            tablec.Duyet = true;
            context.SaveChanges();
        }
        [WebMethod]
        public void BangKe_Duyet_Xoa(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var tablec = context.BangLietKeCPs.Single(p => p.IDCP == IDCP);
            tablec.LyDoDuyet = "";
            tablec.NguoiDuyet = "";
            tablec.NgayDuyet = null;
            tablec.Duyet = false;
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable BangKe_PhieuHoanUng(DateTime TuNgay, DateTime DenNgay,string keyword)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("STT");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("SoFile1");
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("TamUng", typeof(double));
            dt1.Columns.Add("ChiPhi", typeof(double));
            dt1.Columns.Add("HoanLai", typeof(double));

            var t3 = (from a in context.BangLietKeCPs
                      join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                      select new
                      {
                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          b.SoBill,
                          b.SoFile,
                          b.SoCont,
                          b.SoLuong,
                         // b.DuyetUng,
                          b.SoLuongToKhai,
                          c.TenVietTat,
                          a.NgayHoanUng,
                          a.XacNhanHoanUng,
                          a.XacNhanHoangUngNhanVien,
                          a.MaNhanVien,
                          a.IDCP
                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 &&
             //DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0&&p.XacNhanHoangUngNhanVien == true&&(p.XacNhanHoanUng==false|| p.XacNhanHoanUng==null));
             DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0 && p.XacNhanHoangUngNhanVien == true);
            int STT = 0;
            if (keyword != "")
                keyword = keyword.Substring(0, keyword.Length - 1);
            keyword = "," + keyword + ",";
            //  dt.DefaultView.RowFilter = $"SoFile1 IN('{values}')";

            foreach (var item in t3)
            {
                if (keyword.Contains("," + item.SoFile.Trim() + ","))
                {
                    STT++;
                    double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                    DataRow row = dt1.NewRow();
                    row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                    row["STT"] = STT;
                    row["SoFile"] = string.Format("{0} {1}", item.SoFile, item.TenVietTat);
                    row["SoFile1"] = item.SoFile;
                    //update 28.09
                    double TongDuyetUng = 0;
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile&&p.MaNhanVien==item.MaNhanVien);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                 //   row["DuyetUng"] = TongDuyetUng;
                    row["TamUng"] = TongDuyetUng;
                    var tongHQ = context.BangLietKeCP_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang&&p.IDCP==item.IDCP && p.MaChiPhi_HQ != null);
                    foreach (var item1 in tongHQ)
                    {
                        tong_HQ += item1.SoTien_HQ.Value;
                    }
                    var tongCH = context.BangLietKeCP_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang && p.IDCP == item.IDCP && p.MaChiHo != null);
                    foreach (var item1 in tongCH)
                    {
                        tong_chiHo += item1.SoTien_ChiHo.Value;
                    }
                    row["ChiPhi"] = tong_HQ + tong_chiHo;
                    row["HoanLai"] = tong_HQ + phiKTCL + tong_chiHo - double.Parse(row["TamUng"].ToString());

                    dt1.Rows.Add(row);
                }
            }
            dt1.TableName = "xem";
            return dt1;
        }
        [WebMethod]
        public DataTable BangKe_PhieuHoanUng_NguoiTaoBangKe(DateTime TuNgay, DateTime DenNgay,string NguoiTaoBangKe, string keyword)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("STT");
            dt1.Columns.Add("SoFile1");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("TamUng", typeof(double));
            dt1.Columns.Add("ChiPhi", typeof(double));
            dt1.Columns.Add("HoanLai", typeof(double));

            var t3 = (from a in context.BangLietKeCPs
                      join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                      select new
                      {
                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          b.SoBill,
                          b.SoFile,
                          b.SoCont,
                          b.SoLuong,
                       //   b.DuyetUng,
                          b.SoLuongToKhai,
                          c.TenVietTat,
                          a.NgayHoanUng,
                          a.XacNhanHoanUng,
                          a.XacNhanHoangUngNhanVien,
                          a.MaNhanVien,
                          a.IDCP
                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 && p.NguoiTaoBangKe==NguoiTaoBangKe&&
             DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0 && p.XacNhanHoangUngNhanVien == true && (p.XacNhanHoanUng == false || p.XacNhanHoanUng == null));
            // DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0 && p.XacNhanHoangUngNhanVien == true);

            int STT = 0;
            if (keyword != "")
                keyword = keyword.Substring(0, keyword.Length - 1);
            keyword = "," + keyword + ",";
            foreach (var item in t3)
            {
                if (keyword.Contains("," + item.SoFile.Trim() + ","))
                {
                    STT++;
                    double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                    DataRow row = dt1.NewRow();
                    row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                    row["STT"] = STT;
                    row["SoFile"] = string.Format("{0} {1}", item.SoFile, item.TenVietTat);
                    row["SoFile1"] = item.SoFile;
                    //update 28.09
                    double TongDuyetUng = 0;
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile&&p.MaNhanVien== item.MaNhanVien);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                  // row["DuyetUng"] = TongDuyetUng;
                    row["TamUng"] = TongDuyetUng;
                    var tongHQ = context.BangLietKeCP_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang && p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                    foreach (var item1 in tongHQ)
                    {
                        tong_HQ += item1.SoTien_HQ.Value;
                    }
                    var tongCH = context.BangLietKeCP_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang && p.IDCP == item.IDCP && p.MaChiHo != null);
                    foreach (var item1 in tongCH)
                    {
                        tong_chiHo += item1.SoTien_ChiHo.Value;
                    }
                    row["ChiPhi"] = tong_HQ + tong_chiHo;
                    row["HoanLai"] = tong_HQ + phiKTCL + tong_chiHo - double.Parse(row["TamUng"].ToString());

                    dt1.Rows.Add(row);
                }
            }
            dt1.TableName = "xem";
            return dt1;
        }
        [WebMethod]
        public void BangKeChiPhi_XacNhanHoanUng(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangLietKeCPs.Single(p=>p.IDCP==IDCP);
            t.XacNhanHoanUng = true;
            t.NgayHoanUng = DateTime.Now;
            context.SaveChanges();
        }
        [WebMethod]
        public void BangKeChiPhi_XacNhanHoanUng_Huy(int IDCP)
        {
            DateTime? nullDateTime = null;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangLietKeCPs.Single(p => p.IDCP == IDCP);
            t.XacNhanHoanUng = false;
            t.NgayHoanUng = nullDateTime;
            context.SaveChanges();
        }
        [WebMethod]
        public void BangKeChiPhi_XacNhanHoanUng_NhanVien(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangLietKeCPs.Single(p => p.IDCP == IDCP);
            t.XacNhanHoangUngNhanVien = true;
            t.NgayHoanUngNhanVien = DateTime.Now;
            context.SaveChanges();
        }
        [WebMethod]
        public void BangKeChiPhi_XacNhanHoanUng_Huy_NhanVien(int IDCP)
        {
            DateTime? nullDateTime = null;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.BangLietKeCPs.Single(p => p.IDCP == IDCP);
            t.XacNhanHoangUngNhanVien = false;
            t.NgayHoanUngNhanVien = nullDateTime;
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable BangKeChiPhiNangHa_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("IDLoHang");
            dt1.Columns.Add("IDCP");
            dt1.Columns.Add("NgayTaoBangKe", typeof(DateTime));
            dt1.Columns.Add("NguoiTaoBangKe");
            dt1.Columns.Add("SoBill");
            dt1.Columns.Add("SoFile");
            dt1.Columns.Add("SoCont");
            dt1.Columns.Add("SoLuong");
            dt1.Columns.Add("DuyetUng", typeof(double));
            dt1.Columns.Add("SoLuongToKhai");
            dt1.Columns.Add("TenKhachHang");
         //   dt1.Columns.Add("MaNhaCungCap");
           // dt1.Columns.Add("TenNhaCungCap");
            dt1.Columns.Add("TongPhiHQ", typeof(double));
            dt1.Columns.Add("PhiKTCL", typeof(double));
            dt1.Columns.Add("TongPhiChiHo", typeof(double));
            dt1.Columns.Add("TienCuoc", typeof(double));
            dt1.Columns.Add("ConLai", typeof(double));
            var t3 = (from a in context.BangPhoiNangHas
                      join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                     
                     
                      select new
                      {
                          a.IDCP,
                          a.PhiDangKy,
                          a.IDLoHang,
                          a.NgayTaoBangKe,
                          a.NguoiTaoBangKe,
                          b.SoBill,
                          b.SoFile,
                          b.SoCont,
                          b.SoLuong,
                         // b.DuyetUng,
                          b.SoLuongToKhai,
                          c.TenVietTat,
                         // a.MaNhaCungCap,
                        //  TenNhaCungCap=""
                      }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0);

            foreach (var item in t3)
            {
                double tong_HQ = 0, tong_chiHo = 0, phiKTCL = 0, tamung = 0;
                DataRow row = dt1.NewRow();
                row["IDCP"] = item.IDCP;
                row["IDLoHang"] = item.IDLoHang;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe;
                row["NguoiTaoBangKe"] = item.NguoiTaoBangKe;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                //update 28.09
                double TongDuyetUng = 0;
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
                row["DuyetUng"] = TongDuyetUng;
             //   row["DuyetUng"] = (item.DuyetUng == null) ? 0 : item.DuyetUng.Value;
                tamung = TongDuyetUng;
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                row["TenKhachHang"] = item.TenVietTat;
                row["PhiKTCL"] = item.PhiDangKy;
               // row["MaNhaCungCap"] = item.MaNhaCungCap;
                //var t2 = context.DanhSachNhaCungCaps.Where(p=>p.MaNhaCungCap==item.MaNhaCungCap);
                //foreach (var item2 in t2)
                //{
                //    row["TenNhaCungCap"] = item2.TenNhaCungCap;
                //}
               phiKTCL = item.PhiDangKy.Value;

                var tongHQ = context.BangPhoiNangHa_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang && p.MaChiPhi_HQ != null);
                foreach (var item1 in tongHQ)
                {
                    tong_HQ += item1.SoTien_HQ.Value;
                }
                row["TongPhiHQ"] = tong_HQ;
                var tongCH = context.BangPhoiNangHa_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang && p.MaChiHo != null);
                foreach (var item1 in tongCH)
                {
                    tong_chiHo += item1.SoTien_ChiHo.Value;
                }
                row["TongPhiChiHo"] = tong_chiHo;
                row["ConLai"] = tong_HQ + phiKTCL + tong_chiHo - tamung;
                //tien cuoc
                var t4 = context.BangPhoiNangHa_ChiTiet.Where(p => p.IDLoHang == item.IDLoHang && p.MaChiHo == "CH01");
                foreach (var item1 in t4)
                {
                    row["TienCuoc"] = item1.SoTien_ChiHo.Value;
                }
                dt1.Rows.Add(row);
            }
            dt1.TableName = "xem";
            return dt1;
        }
        //[WebMethod]
        //public void XoaBangKe(int IDLoHang)
        //{
        //    vua45987_vudacoEntities context = new vua45987_vudacoEntities();
        //    BangLietKeCP t1 = context.BangLietKeCPs.Single(p => p.IDLoHang == IDLoHang);
        //    context.BangLietKeCPs.Remove(t1);
        //    context.SaveChanges();
        //    //xoa bang ke chi tiet
        //    var t2 = context.BangLietKeCP_ChiTiet.Where(p => p.IDLoHang == IDLoHang);
        //    foreach (var item in t2)
        //    {
        //        using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
        //        {
        //            BangLietKeCP_ChiTiet t11 = context1.BangLietKeCP_ChiTiet.Single(p => p.IDCPCT == item.IDCPCT);
        //            context1.BangLietKeCP_ChiTiet.Remove(t11);
        //            context1.SaveChanges();
        //        }
        //    }
        //}
        [WebMethod]
        public void XoaBangKe_IDCP(int IDCP)
        {
            using (vua45987_vudacoEntities context = new vua45987_vudacoEntities())
            {
                var t = context.BangLietKeCPs.Where(p => p.IDCP == IDCP);
                if (t.Count() > 0)
                {
                    BangLietKeCP t1 = context.BangLietKeCPs.Single(p => p.IDCP == IDCP);
                    context.BangLietKeCPs.Remove(t1);
                    context.SaveChanges();
                }
            }
            //xoa bang ke chi tiet
            using (vua45987_vudacoEntities context = new vua45987_vudacoEntities())
            {

                var t2 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == IDCP);
                foreach (var item in t2)
                {
                    using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                    {
                        BangLietKeCP_ChiTiet t11 = context1.BangLietKeCP_ChiTiet.Single(p => p.IDCPCT == item.IDCPCT);
                        context1.BangLietKeCP_ChiTiet.Remove(t11);
                        context1.SaveChanges();
                    }

                }
            }
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                var t = context1.BangLietKeCP_BoSung.Where(p => p.IDCP == IDCP);
                if (t.Count() > 0)
                {
                    BangLietKeCP_BoSung t11 = context1.BangLietKeCP_BoSung.SingleOrDefault(p => p.IDCP == IDCP);
                    context1.BangLietKeCP_BoSung.Remove(t11);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public void XoaBangKe_BoSung_IDCP(int IDCP)
        {
            vua45987_vudacoEntities context1 = new vua45987_vudacoEntities();
            BangLietKeCP_BoSung t11 = context1.BangLietKeCP_BoSung.Single(p => p.IDCP == IDCP);
            context1.BangLietKeCP_BoSung.Remove(t11);
            context1.SaveChanges();
        }
        //bang phi di duong
        [WebMethod]
        public List<BangPhiDiDuong> BangDiDuong_MaDieuXe(string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table=  context.BangPhiDiDuongs.Where(p => p.MaDieuXe == MaDieuXe);
            return table.ToList();
        }
        [WebMethod]
        public void BangDiDuong_DuyetChi(BangPhiDiDuong a)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhiDiDuongs.Single(p => p.IDBangPhi == a.IDBangPhi);
            table.MaDieuXe = a.MaDieuXe;
            table.DuyetChi = true;
            table.NguoiDuyet = a.NguoiDuyet;
            table.ThoiGianDuyet = DateTime.Now;
            table.PhanHoi = a.PhanHoi;
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable BangPhiDiDuong_Xem(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("STT");
            dt.Columns.Add("IDBangPhi");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("ThoiGianDuyet");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("LaiXeThuCuoc", typeof(double));
            dt.Columns.Add("TienAn", typeof(double));
            dt.Columns.Add("TienVe", typeof(double));
            dt.Columns.Add("QuaDem", typeof(double));
            dt.Columns.Add("TienLuat", typeof(double));
            dt.Columns.Add("LuongHangVe", typeof(double));
            dt.Columns.Add("DuyetChi");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("NguoiDuyet");
            dt.Columns.Add("PhanHoi");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("DiemTraHang", typeof(double));
            dt.Columns.Add("Chon", typeof(double));
            dt.Columns.Add("TongTien", typeof(double));
            dt.Columns.Add("TongChiPhiKhac", typeof(double));
            //thong tin file chua tao bang ke
            var table = (from a in context.BangPhiDiDuongs
                         select new
                         {
                             a.IDBangPhi,
                             a.Ngay,
                             a.TuyenVC,
                             a.LaiXeThuCuoc,
                             a.TienAn,
                             a.TienVe,
                             a.QuaDem,
                             a.TienLuat,
                             a.LuongHangVe,
                             a.DuyetChi,
                             a.NguoiTao,
                             a.NguoiDuyet,
                             a.SoFile,
                             a.GhiChu,
                             a.ThoiGianDuyet,
                             a.DiemTraHang,
                             Chon = false,
                             a.PhanHoi
                         })
                         .Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
            int stt = 0;
            foreach (var item in table)
            {
                stt++;
                double tongPhi = 0;
                DataRow row = dt.NewRow();
                row["STT"] = stt;
                row["IDBangPhi"] = item.IDBangPhi;
                row["PhanHoi"] = item.PhanHoi;
                row["Ngay"] = item.Ngay.Value;
                row["TuyenVC"] = item.TuyenVC;
                row["LaiXeThuCuoc"] = item.LaiXeThuCuoc;
                row["TienAn"] = item.TienAn;
                row["TienVe"] = item.TienVe;
                row["QuaDem"] = item.QuaDem;
                row["TienLuat"] = item.TienLuat;
                row["LuongHangVe"] = item.LuongHangVe;
                //if (item.DuyetChi.Value == true)
                //    row["DuyetChi"] = "Đã duyệt";
                row["NguoiTao"] = item.NguoiTao;
                row["NguoiDuyet"] = item.NguoiDuyet;
                row["ThoiGianDuyet"] = (item.ThoiGianDuyet == null) ? "" : item.ThoiGianDuyet.Value.ToString("dd/MM/yyyy hh:mm");
                row["SoFile"] = item.SoFile;
                row["GhiChu"] = item.GhiChu;
                row["DiemTraHang"] = item.DiemTraHang;
                row["Chon"] = item.Chon;
                var t = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == item.IDBangPhi);
                tongPhi += item.TienAn.Value + item.TienVe.Value + item.QuaDem.Value + item.TienLuat.Value + item.LuongHangVe.Value + item.DiemTraHang.Value;
                foreach (var item1 in t)
                {
                    tongPhi += item1.SoTienChi.Value;
                }
                row["TongTien"] = tongPhi;
                //sum tong chi phi khac
                var t_Khac = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == item.IDBangPhi);
                double _TongCPKhac = 0;
                foreach (var itemKhac in t_Khac)
                {
                    _TongCPKhac += itemKhac.SoTienChi.Value;
                }
                row["TongChiPhiKhac"] = _TongCPKhac;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public void BangDiDuong_xoa(int IDBangPhi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var a1 = context.BangPhiDiDuongs.Where(p=>p.IDBangPhi==IDBangPhi);
            if (a1.Count() > 0)
            {
                BangPhiDiDuong table = context.BangPhiDiDuongs.Single(p => p.IDBangPhi == IDBangPhi);
                context.BangPhiDiDuongs.Remove(table);
                context.SaveChanges();
            }
            //
            var a2 = context.BangPhiDiDuong_Temp.Where(p => p.IDBangPhi == IDBangPhi);
            if (a2.Count() > 0)
            {
                BangPhiDiDuong_Temp table11 = context.BangPhiDiDuong_Temp.Single(p => p.IDBangPhi == IDBangPhi);
                context.BangPhiDiDuong_Temp.Remove(table11);
                context.SaveChanges();
            }
            //
            var a3 = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == IDBangPhi);
            if (a3.Count() > 0)
            {
                var t = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == IDBangPhi);
                foreach (var item in t)
                {
                    int idct = item.IDCT;
                    using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                    {
                        BangPhiDiDuong_ChiKhac table2 = context1.BangPhiDiDuong_ChiKhac.Single(p => p.IDCT == idct);
                        context1.BangPhiDiDuong_ChiKhac.Remove(table2);
                        context1.SaveChanges();
                    }

                }
            }
            //
            var a4 = context.BangPhiDiDuong_ChiKhac_Temp.Where(p => p.IDBangPhi == IDBangPhi);
            if (a4.Count() > 0)
            {
                var t11 = context.BangPhiDiDuong_ChiKhac_Temp.Where(p => p.IDBangPhi == IDBangPhi);
                foreach (var item in t11)
                {
                    int idct = item.IDCT;
                    using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                    {
                        BangPhiDiDuong_ChiKhac_Temp table2 = context1.BangPhiDiDuong_ChiKhac_Temp.Single(p => p.IDCT == idct);
                        context1.BangPhiDiDuong_ChiKhac_Temp.Remove(table2);
                        context1.SaveChanges();
                    }

                }
            }
        }
        //chi phi nang ha
        [WebMethod]
        public void Ds_BangPhoiNangHa_Them(BangPhoiNangHa table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangPhoiNangHas.Add(table1);
            context.SaveChanges();
           
        }
        [WebMethod]
        public void Ds_BangPhoiNangHaCT_Them(BangPhoiNangHa_ChiTiet table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangPhoiNangHa_ChiTiet.Add(table1);
            context.SaveChanges();
            
        }
        [WebMethod]
        public List<BangPhoiNangHa>Ds_BangPhoiNangHa(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t3 = context.BangPhoiNangHas.Where(p => p.IDLoHang == IDLoHang);
            return t3.ToList();
        }
        [WebMethod]
        public DataTable ChiPhiNangHa(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenNhaCungCap");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoTien",typeof(double));
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("NgayTaoBangKe",typeof(DateTime));
            var table5 = (from a in context.BangPhoiNangHa_ChiTiet
                          join d in context.BangPhoiNangHas on a.IDLoHang equals d.IDLoHang
                          join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                          join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                          join f in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals f.MaNhaCungCap
                          select new
                          {
                              b.SoFile,
                              c.TenKhachHang,
                              b.SoCont,
                              b.SoLuong,
                              SoTien = a.SoTien_ChiHo,
                              a.SoHoaDon,
                              GhiChu = a.GhiChu_ChiHo,
                              d.NgayTaoBangKe,
                              f.TenNhaCungCap
                          }).Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) >= 0 &&
             DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0);
            foreach (var item in table5)
            {
                DataRow row = dt.NewRow();
                row["SoFile"] = item.SoFile;
                row["TenKhachHang"] = item.TenKhachHang;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                row["SoTien"] = item.SoTien.Value;
                row["SoHoaDon"] = item.SoHoaDon;
                row["GhiChu"] = item.GhiChu;
                row["TenNhaCungCap"] = item.TenNhaCungCap;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe.Value;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable ChiPhiNangHa_TheoIDLoHang(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenNhaCungCap");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("NgayTaoBangKe", typeof(DateTime));
            var table5 = (from a in context.BangPhoiNangHa_ChiTiet
                          join d in context.BangPhoiNangHas on a.IDLoHang equals d.IDLoHang
                          join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                          join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                          join f in context.DanhSachNhaCungCaps on a.MaNhaCungCap equals f.MaNhaCungCap
                          select new
                          {
                              d.IDLoHang,
                              b.SoFile,
                              c.TenKhachHang,
                              b.SoCont,
                              b.SoLuong,
                              SoTien = a.SoTien_ChiHo,
                              a.SoHoaDon,
                              GhiChu = a.GhiChu_ChiHo,
                              d.NgayTaoBangKe,
                              f.TenNhaCungCap
                          }).Where(p => p.IDLoHang==IDLoHang);
            foreach (var item in table5)
            {
                DataRow row = dt.NewRow();
                row["SoFile"] = item.SoFile;
                row["TenKhachHang"] = item.TenKhachHang;
                row["SoCont"] = item.SoCont;
                row["SoLuong"] = item.SoLuong;
                row["SoTien"] = item.SoTien.Value;
                row["SoHoaDon"] = item.SoHoaDon;
                row["GhiChu"] = item.GhiChu;
                row["TenNhaCungCap"] = item.TenNhaCungCap;
                row["NgayTaoBangKe"] = item.NgayTaoBangKe.Value;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        //bang phi nang ha
        [WebMethod]
        public void dsBangPhoiNangHa_Xoa(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            BangPhoiNangHa t1 = context.BangPhoiNangHas.Single(p => p.IDLoHang == IDLoHang);
            context.BangPhoiNangHas.Remove(t1);
            context.SaveChanges();
            var t2 = context.BangPhoiNangHa_ChiTiet.Where(p => p.IDLoHang == IDLoHang);
            foreach (var item in t2)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    BangPhoiNangHa_ChiTiet t11 = context1.BangPhoiNangHa_ChiTiet.Single(p => p.IDCPCT == item.IDCPCT);
                    context1.BangPhoiNangHa_ChiTiet.Remove(t11);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public void dsBangPhoiNangHa_Xoa1(int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int _IDLoHang = 0;
            var t5 = context.BangPhoiNangHas.Where(p=>p.IDCP== IDCP);
            foreach (var item in t5)
            {
                _IDLoHang = item.IDLoHang.Value;
            }
            if(_IDLoHang>0)
            {
                //xoa toan bo du lieu fileDebit
                var t41 = (from a in context.FileDebitChiTiets
                           join b in context.FileDebits on a.IDDeBit equals b.IDDeBit
                           select new { a.IDDeBitCT, b.IDLoHang }).Where(p => p.IDLoHang == _IDLoHang);
                foreach (var item4 in t41)
                {
                    using (vua45987_vudacoEntities context2 = new vua45987_vudacoEntities())
                    {
                        FileDebitChiTiet t6 = context2.FileDebitChiTiets.Single(p => p.IDDeBitCT == item4.IDDeBitCT);
                        context2.FileDebitChiTiets.Remove(t6);
                        context2.SaveChanges();
                    }
                }

                var t4 = context.FileDebits.Where(p => p.IDLoHang == _IDLoHang);
                foreach (var item44 in t4)
                {
                    using (vua45987_vudacoEntities context2 = new vua45987_vudacoEntities())
                    {
                        FileDebit t7 = context2.FileDebits.Single(p => p.IDDeBit == item44.IDDeBit);
                        context2.FileDebits.Remove(t7);
                        context2.SaveChanges();
                    }

                }
                //
                DataTable dt = DsThongTinFile_Full_TheoIDLoHang_FileGia(_IDLoHang);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    int IDGia = int.Parse(row["IDGia"].ToString());
                    int IDLoHang = int.Parse(row["IDLoHang"].ToString());
                    DataTable dtCT = ChiTietNoiDungTaoDebit(IDGia);
                    ThemLaiFileDebit(IDGia, row["SoFile"].ToString(), "admin", IDLoHang, dtCT);
                }
            }    
            var t2 = (from a in context.BangPhoiNangHa_ChiTiet
                     join b in context.BangPhoiNangHas on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhMuc_PhiChiHo on a.MaChiHo equals c.MaChiHo
                      select new {a.IDCPCT,a.IDLoHang,b.IDCP,a.MaChiHo,c.TenChiHo}
                     ).Where(p => p.IDCP == IDCP);
           
            foreach (var item in t2)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    
                    BangPhoiNangHa_ChiTiet t11 = context1.BangPhoiNangHa_ChiTiet.Single(p => p.IDCPCT == item.IDCPCT);
                    context1.BangPhoiNangHa_ChiTiet.Remove(t11);
                    context1.SaveChanges();
                }
                

            }
            BangPhoiNangHa t1 = context.BangPhoiNangHas.Single(p => p.IDCP == IDCP);
            context.BangPhoiNangHas.Remove(t1);
            context.SaveChanges();
           

        }
        [WebMethod]
        public void ThemLaiFileDebit(int IDGia,string SoFile,string NguoiLap,int IDLoHang,DataTable dt)
        {
            FileDebit p1 = new FileDebit();
            p1.IDGia = IDGia;
            p1.SoFile = SoFile;
            p1.ThoiGianLap = DateTime.Now;
            p1.NguoiLap = NguoiLap;
            p1.IDLoHang = IDLoHang;
            LuuFileDebit(p1);
            //
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                    FileDebitChiTiet p2 = new FileDebitChiTiet();
                    p2.TenDichVu = row["TenDichVu"].ToString().Trim();
                    if (row["SoTien"].ToString().Trim() == "")
                        p2.SoTien = 0;
                    if (row["ThanhTien"].ToString().Trim() != "")
                        p2.ThanhTien = float.Parse(row["ThanhTien"].ToString().Trim());
                    else
                        p2.ThanhTien = 0;
                    // }    
                    if (row["SoTien"].ToString().Trim() != "")
                        p2.SoTien = float.Parse(row["SoTien"].ToString().Trim());
                    else
                        p2.SoTien = 0;
                    if (row["VAT"].ToString().Trim().ToLower() != "khác")
                    {
                        if (row["VAT"].ToString().Trim().ToLower() != "")
                            p2.VAT = float.Parse(row["VAT"].ToString().Trim().ToLower());
                        else
                            p2.VAT = 0;
                    }
                    else
                    {
                        p2.VAT = -1;
                        p2.SoTien = 0;
                    }
                    p2.IDDeBit = Top1FileDebit();
                    p2.GhiChu = row["GhiChu"].ToString().Trim();
                    p2.LaPhiChiHo = false;
                    if (p2.TenDichVu != "")
                        LuuFileDebitChiTiet(p2);
                
            }
        }
        [WebMethod]
        public bool FileDebit_KoHoaDon_KH_TheoMaDieuXe(string MaDieuXe)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileDebit_KoHoaDon_KH.Where(p=>p.MaDieuXe==MaDieuXe);
            if (table.Count() > 0)
                return true;
            else
                return false;
        }

        [WebMethod]
        public void ThemFileDebit_KoHoaDon_KH(FileDebit_KoHoaDon_KH p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.FileDebit_KoHoaDon_KH.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void ThemFileDebit_KoHoaDon_NCC(FileDebit_KoHoaDon_NCC p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.FileDebit_KoHoaDon_NCC.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void Xoa_FileDebit_KoHoaDon_KH(int IDDeBit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            FileDebit_KoHoaDon_KH table = context.FileDebit_KoHoaDon_KH.Single(p=>p.IDDeBit==IDDeBit);
            context.FileDebit_KoHoaDon_KH.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public void Xoa_FileDebit_KoHoaDon_NCC(int IDDeBit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            FileDebit_KoHoaDon_NCC table = context.FileDebit_KoHoaDon_NCC.Single(p => p.IDDeBit == IDDeBit);
            context.FileDebit_KoHoaDon_NCC.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public List<FileDebit_KoHoaDon_KH> FileDebit_KoHoaDon_KH_Xem(int IDDeBit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileDebit_KoHoaDon_KH.Where(p=>p.IDDeBit==IDDeBit);
            return table.ToList();
        }
        [WebMethod]
        public List<FileDebit_KoHoaDon_NCC> FileDebit_KoHoaDon_NCC_Xem(int IDDeBit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileDebit_KoHoaDon_NCC.Where(p => p.IDDeBit == IDDeBit);
            return table.ToList();
        }
        [WebMethod]
        public void ChiPhiNangHa_xoa(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            BangPhoiNangHa t1 = context.BangPhoiNangHas.Single(p => p.IDLoHang == IDLoHang);
            context.BangPhoiNangHas.Remove(t1);
            context.SaveChanges();
            //xoa bang ke chi tiet
            var t2 = context.BangPhoiNangHa_ChiTiet.Where(p => p.IDLoHang == IDLoHang);
            foreach (var item in t2)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    BangPhoiNangHa_ChiTiet t11 = context1.BangPhoiNangHa_ChiTiet.Single(p => p.IDCPCT == item.IDCPCT);
                    context1.BangPhoiNangHa_ChiTiet.Remove(t11);
                    context1.SaveChanges();
                }
            }
        }
        //thong tin file
        [WebMethod]
        public DataTable DsThongTinFile(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("STT");
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TaiKhoanThucHien");
            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("Chon", typeof(bool));
            int stt = 0;
          
            var table = context.ThongTinFiles
                        .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
           DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0);
            foreach (var item in table)
            {
                stt++;
                DataRow row = dt.NewRow();
                row["STT"] = stt;
                row["IDLoHang"] = item.IDLoHang;
                var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
                foreach (var item1 in t1)
                {
                    row["MaKhachHang"] = item1.TenKhachHang;
                    row["TenVietTat"] = item1.TenVietTat;
                }
                row["SoFile"] = item.SoFile;
                row["SoToKhai"] = item.SoToKhai;
                row["SoBill"] = item.SoBill;
                row["SoLuong"] = item.SoLuong;
                row["SoCont"] = item.SoCont;
                row["TenSales"] = item.TenSales;
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                       join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                       select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten += item1.TenNhanVien + ",";
                }
                if (_Ten.Trim().Length > 0)
                    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;
                //
                if (item.LoaiHang.Trim() == "HangLe")
                    row["LoaiHang"] = "Hàng Lẻ";
                else if (item.LoaiHang.Trim() == "HangCont")
                    row["LoaiHang"] = "Hàng Cont";
                if (item.TinhChat.Trim() == "HangNhap")
                    row["TinhChat"] = "Hàng nhập";
                else if (item.TinhChat.Trim() == "HangXuat")
                    row["TinhChat"] = "Hàng xuất";
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                if (item.LoaiToKhai.Trim() == "0")
                    row["LoaiToKhai"] = "Luồng xanh";
                else if (item.LoaiToKhai.Trim() == "1")
                    row["LoaiToKhai"] = "Luồng vàng";
                else if (item.LoaiToKhai.Trim() == "2")
                    row["LoaiToKhai"] = "Luồng đỏ";

                if (item.NghiepVu.Trim() == "0")
                    row["NghiepVu"] = "Thông quan";
                else if (item.NghiepVu.Trim() == "1")
                    row["NghiepVu"] = "Đổi lệnh dưới kho";
                else if (item.NghiepVu.Trim() == "2")
                    row["NghiepVu"] = "Rút ruột";
                else if (item.NghiepVu.Trim() == "3")
                    row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                else if (item.NghiepVu.Trim() == "4")
                    row["NghiepVu"] = "Không có trucking";
                else if (item.NghiepVu.Trim() == "4")
                    row["NghiepVu"] = "Không có trucking";
                if (item.PhatSinh.Trim() == "0")
                    row["PhatSinh"] = "Nhiều tờ khai";
                else if (item.PhatSinh.Trim() == "1")
                    row["PhatSinh"] = "Không";
                //update 28.09
                double TongDuyetUng = 0;
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
                row["DuyetUng"] = TongDuyetUng;
                //row["DuyetUng"] = item.DuyetUng.Value;
                row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
                row["ThoiGianThucHien"] = item.ThoiGianThucHien;
                row["GhiChu"] = item.GhiChu;
                row["Chon"] = false;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        //danh sach tai khoan
        [WebMethod]
        public List<DanhSachTaiKhoan>DsTaiKhoan()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachTaiKhoans;
            return table.ToList();
        }
        [WebMethod]
        public DataTable DsTaiKhoan_LXE()
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = cls.LoadTable("select A.* from DanhSachTaiKhoan A left join NhanVien B on A.MaNhanVien=B.MaNhanVien where B.MaPhongBan='LXE'");
            dt.TableName = "DanhSachTaiKhoan";
            return dt;
        }
        [WebMethod]
        public List<DanhSachTaiKhoan> DsTaiKhoan_TaiKhoan(string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachTaiKhoans.Where(p => p.TaiKhoan == TaiKhoan);
            return table.ToList();
        }
        [WebMethod]
        public void DsTaiKhoan_Them(DanhSachTaiKhoan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhSachTaiKhoan table1 = new DanhSachTaiKhoan();
            table1.TaiKhoan = p.TaiKhoan;
            table1.MatKhau = p.MatKhau;
            table1.TrangThai =p.TrangThai;
            table1.HoVaTen = p.HoVaTen;
            table1.MaNhanVien = p.MaNhanVien;
            context.DanhSachTaiKhoans.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public List<DanhSachTaiKhoan> DsTaiKhoan_TaiKhoan_ID(string TaiKhoan,int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachTaiKhoans.Where(p => p.TaiKhoan == TaiKhoan && p.IDTaiKhoan != ID);
            return table.ToList();
        }
        [WebMethod]
        public void DsTaiKhoan_Sua(DanhSachTaiKhoan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table1 = context.DanhSachTaiKhoans.Single(a =>a.IDTaiKhoan == p.IDTaiKhoan);
            table1.TaiKhoan = p.TaiKhoan;
            table1.MatKhau = p.MatKhau;
            table1.TrangThai = p.TrangThai;
            table1.HoVaTen = p.HoVaTen;
            table1.MaNhanVien = p.MaNhanVien;
            context.SaveChanges();
        }
        [WebMethod]
        public void DsTaiKhoan_Xoa(DanhSachTaiKhoan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhSachTaiKhoan table = context.DanhSachTaiKhoans.Single(a => a.IDTaiKhoan == p.IDTaiKhoan);
            context.DanhSachTaiKhoans.Remove(table);
            context.SaveChanges();
        }
        //khach hang
        [WebMethod]
        public List<DanhSachKhachHang>dsKH()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachKhachHangs.OrderBy(p=>p.TenKhachHang);
            return table.ToList();
        }
        [WebMethod]
        public List<DanhSachKhachHang> dsKH_MaKH(string MAKH)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachKhachHangs.Where(p=>p.MaKhachHang== MAKH);
            return table.ToList();
        }
        [WebMethod]
        public void dsKH_Them(DanhSachKhachHang table1)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DanhSachKhachHangs.Add(table1);
            context.SaveChanges();
        }
        [WebMethod]
        public void ds_NCC_Them(DanhSachNhaCungCap table2)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DanhSachNhaCungCaps.Add(table2);
            context.SaveChanges();
        }
        [WebMethod]
        public List<DanhSachKhachHang> dsKH_MaKH_ID(string MAKH,int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MAKH&&p.ID!=ID);
            return table.ToList();
        }
        [WebMethod]
        public List<DanhSachNhaCungCap> dsNCC_MaNCC_ID(string MaNCC, int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaNCC && p.ID != ID);
            return table.ToList();
        }
        [WebMethod]
        public List<DanhSachNhaCungCap> dsNCC_MaNCC(string MaNCC)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaNCC);
            return table.ToList();
        }
        [WebMethod]
        public void ds_KH_Sua(DanhSachKhachHang table)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table1 = context.DanhSachKhachHangs.Single(p => p.ID == table.ID);
            table1.TenVietTat = table.TenVietTat;
            table1.MaKhachHang = table.MaKhachHang;
            table1.TenKhachHang = table.TenKhachHang;
            table1.DiaChi = table.DiaChi;
            table1.MaSoThue = table.MaSoThue;
            table1.SoDienThoai = table.SoDienThoai;
            table1.Email = table.Email;
            table1.STK = table.STK;
            table1.SoNgayDuocNo = table.SoNgayDuocNo;
            table1.NoToiDa = table.NoToiDa;
            table1.LaNhaCungCap = table.LaNhaCungCap;
            table1.GhiChu = table.GhiChu;
            context.SaveChanges();
        }
        [WebMethod]
        public void ds_KH_Sua_TheoMa(DanhSachKhachHang table)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();

            var table1 = context.DanhSachKhachHangs.Single(p => p.MaKhachHang == table.MaKhachHang);
            table1.TenVietTat = table.TenVietTat;
            table1.MaKhachHang = table.MaKhachHang;
            table1.TenKhachHang = table.TenKhachHang;
            table1.DiaChi = table.DiaChi;
            table1.MaSoThue = table.MaSoThue;
            table1.SoDienThoai = table.SoDienThoai;
            table1.Email = table.Email;
            table1.STK = table.STK;
            table1.SoNgayDuocNo = table.SoNgayDuocNo;
            table1.NoToiDa = table.NoToiDa;
            table1.LaNhaCungCap = table.LaNhaCungCap;
            table1.GhiChu = table.GhiChu;
            context.SaveChanges();
        }
        [WebMethod]
        public void ds_KH_Xoa(int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhSachKhachHang table = context.DanhSachKhachHangs.Single(p => p.ID == ID);
            context.DanhSachKhachHangs.Remove(table);
            context.SaveChanges();
            //
            var t = context.DanhSachKhachHangs.Where(p => p.ID == ID);
            foreach (var item in t)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    var t2 = context1.DanhSachNhaCungCaps.Single(p => p.MaNhaCungCap == item.MaKhachHang);
                    context1.DanhSachNhaCungCaps.Remove(t2);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public void ds_NCC_Sua(DanhSachNhaCungCap table)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table1 = context.DanhSachNhaCungCaps.Single(p => p.ID == table.ID);
            table1.TenVietTat = table.TenVietTat;
            table1.MaNhaCungCap = table.MaNhaCungCap;
            table1.TenNhaCungCap = table.TenNhaCungCap;
            table1.DiaChi = table.DiaChi;
            table1.MaSoThue = table.MaSoThue;
            table1.SoDienThoai = table.SoDienThoai;
            table1.Email = table.Email;
            table1.STK = table.STK;
            table1.SoNgayDuocNo = table.SoNgayDuocNo;
            table1.NoToiDa = table.NoToiDa;
            table1.LaKhachHang = table.LaKhachHang;
            table1.GhiChu = table.GhiChu;
            context.SaveChanges();
        }
        [WebMethod]
        public void ds_NCC_Sua_TheoMaKH(DanhSachNhaCungCap table, string MaKH)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table1 = context.DanhSachNhaCungCaps.Single(p => p.MaNhaCungCap == MaKH);
            table1.TenVietTat = table.TenVietTat;
            table1.MaNhaCungCap = table.MaNhaCungCap;
            table1.TenNhaCungCap = table.TenNhaCungCap;
            table1.DiaChi = table.DiaChi;
            table1.MaSoThue = table.MaSoThue;
            table1.SoDienThoai = table.SoDienThoai;
            table1.Email = table.Email;
            table1.STK = table.STK;
            table1.SoNgayDuocNo = table.SoNgayDuocNo;
            table1.NoToiDa = table.NoToiDa;
            table1.LaKhachHang = table.LaKhachHang;
            table1.GhiChu = table.GhiChu;
            context.SaveChanges();
        }
        [WebMethod]
        public List<DanhSachNhaCungCap>ds_NCC()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachNhaCungCaps.OrderBy(p=>p.TenNhaCungCap);
            return table.ToList();
        }
        [WebMethod]
        public void ds_NCC_Xoa(int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhSachNhaCungCap table = context.DanhSachNhaCungCaps.Single(p => p.ID == ID);
            context.DanhSachNhaCungCaps.Remove(table);
            context.SaveChanges();
            //xoa khach hang
            var t = context.DanhSachNhaCungCaps.Where(p => p.ID == ID);
            foreach (var item in t)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    var t2 = context1.DanhSachKhachHangs.Single(p => p.MaKhachHang == item.MaNhaCungCap);
                    context1.DanhSachKhachHangs.Remove(t2);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public string LoadMaDieuXe(DateTime Ngay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string s = "";
            //var table = context.BangDieuXes.Where(p => p.Ngay.Value.Year == Ngay.Year &&
            //       p.Ngay.Value.Month == Ngay.Month).OrderByDescending(p => p.IDBangPhi).Take(1);
            var table = context.Database.SqlQuery<clsValue>("select isnull(Max(cast(SUBSTRING(MaDieuXe,len(MaDieuXe)-3,4) as int)),0) as MaDieuXe from BangDieuXe where year(Ngay)=" + Ngay.Year.ToString());
            //if (table.Count() == 0)//neu chua co
            //    s = "KS" + Ngay.Year.ToString() + Ngay.Month.ToString("0#") + "0001";
            //else
            //{
            foreach (var item in table)
            {
                if (item.MaDieuXe == 0)
                    s = "KS" + Ngay.Year.ToString()  + "00001";
                else
                {
                   
                    int stt = item.MaDieuXe + 1;
                    s = "KS" + Ngay.Year.ToString() + stt.ToString("0000#");
                }
            }
            return s;
        }
        //xe
        [WebMethod]
        public List<DanhSachXe> ds_Xe()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachXes;
            return table.ToList();
        }
        [WebMethod]
        public List<DanhSachXe> ds_Xe_Cty()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachXes.Where(p=>p.LaXeNgoai==false);
            return table.ToList();
        }
        [WebMethod]
        public List<DanhSachXe> ds_Xe_Ngoai()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachXes.Where(p => p.LaXeNgoai == true);
            return table.ToList();
        }
        [WebMethod]
        public void DanhSachXe_Them(DanhSachXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
             context.DanhSachXes.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachXe_Sua(DanhSachXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.DanhSachXes.Single(b=>b.IDXe==p.IDXe);
            t.BienSoXe = p.BienSoXe;
            t.LaXeNgoai = p.LaXeNgoai;
            t.GhiChu = p.GhiChu;
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachXe_Xoa(DanhSachXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhSachXe t = context.DanhSachXes.Single(b => b.IDXe == p.IDXe);
            context.DanhSachXes.Remove(t);
            context.SaveChanges();
        }

        [WebMethod]
        public List<DanhMuc_CPHQ>Ds_CPHQ()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMuc_CPHQ.ToList();
        }
        [WebMethod]
        public List<DanhMuc_PhiChiHo> Ds_CPChiHo()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMuc_PhiChiHo.ToList();
        }
        //nhan vien
        [WebMethod]
        public List<NhanVien>dsNhanVien()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.NhanViens.ToList();
        }
        [WebMethod]
        public bool KiemTraNCC_Ngoai_TheoIDLoHang(string SoFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t_ncc_ngoai = (from a in context.ThongTinFile_NguoiGiaoNhan
                               join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                               select new { a.SoFile, b.NCCNgoai }).Where(p => p.SoFile == SoFile && p.NCCNgoai == true);
            if (t_ncc_ngoai.Count() > 0)
                return true;
            else
                return false;
        }
        //file gia
        [WebMethod]
        public DataTable BangFileChuaTaoFileGia_Xem(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi clsKN = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TaiKhoanThucHien");
            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("Chon", typeof(bool));
            List<clsBangLietKeChiPhi> q = new List<clsBangLietKeChiPhi>();
            var table = context.ThongTinFiles
                      .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianThucHien) >= 0 &&
         DbFunctions.DiffDays(DenNgay, p.ThoiGianThucHien) <= 0);
         
            foreach (var item in table)
            {

                var t_ncc_ngoai = (from a in context.ThongTinFile_NguoiGiaoNhan
                                   join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                   select new { a.MaNhanVien, b.NCCNgoai, a.SoFile }).Where(p => p.SoFile == item.SoFile && p.NCCNgoai == true);
                if (t_ncc_ngoai.Count() > 0)
                {
                    #region file co NCC Ngoai
                    string sqlCheck = "select * from FileGia where IDGia  in(select IDGia from FileGiaChiTiet where IDCP =0 ) and SoFile = '" + item.SoFile + "'";
                    DataTable dtCheck = clsKN.LoadTable(sqlCheck);
                    if (dtCheck.Rows.Count == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["MaDieuXe"] = "";
                        row["IDLoHang"] = item.IDLoHang;
                        row["IDCP"] = 0;//file ko co bangLietKeCP nen IDCP=0
                        var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
                        foreach (var item1 in t1)
                        {
                            row["MaKhachHang"] = item1.TenVietTat;
                        }
                        row["SoFile"] = item.SoFile;
                        row["SoToKhai"] = item.SoToKhai;
                        row["SoBill"] = item.SoBill;
                        row["SoLuong"] = item.SoLuong;
                        row["SoCont"] = item.SoCont;
                        row["TenSales"] = item.TenSales;
                        //
                        string _Ten = "";
                        var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                               join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                               select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                        foreach (var item1 in t_NguoiGiaoNhan)
                        {
                            _Ten += item1.TenNhanVien + ",";
                        }
                        if (_Ten.Trim().Length > 0)
                            _Ten = _Ten.Substring(0, _Ten.Length - 1);
                        row["TenGiaoNhan"] = _Ten;
                        //
                        if (item.LoaiHang.Trim() == "HangLe")
                            row["LoaiHang"] = "Hàng Lẻ";
                        else if (item.LoaiHang.Trim() == "HangCont")
                            row["LoaiHang"] = "Hàng Cont";


                        if (item.TinhChat.Trim() == "HangNhap")
                            row["TinhChat"] = "Hàng nhập";
                        else if (item.TinhChat.Trim() == "HangXuat")
                            row["TinhChat"] = "Hàng xuất";
                        row["SoLuongToKhai"] = item.SoLuongToKhai;
                        if (item.LoaiToKhai.Trim() == "0")
                            row["LoaiToKhai"] = "Luồng xanh";
                        else if (item.LoaiToKhai.Trim() == "1")
                            row["LoaiToKhai"] = "Luồng vàng";
                        else if (item.LoaiToKhai.Trim() == "2")
                            row["LoaiToKhai"] = "Luồng đỏ";

                        if (item.NghiepVu.Trim() == "0")
                            row["NghiepVu"] = "Thông quan";
                        else if (item.NghiepVu.Trim() == "1")
                            row["NghiepVu"] = "Đổi lệnh dưới kho";
                        else if (item.NghiepVu.Trim() == "2")
                            row["NghiepVu"] = "Rút ruột";
                        else if (item.NghiepVu.Trim() == "3")
                            row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                        else if (item.NghiepVu.Trim() == "4")
                            row["NghiepVu"] = "Không có trucking";
                        if (item.PhatSinh.Trim() == "0")
                            row["PhatSinh"] = "Nhiều tờ khai";
                        else if (item.PhatSinh.Trim() == "1")
                            //row["PhatSinh"] = "Không";
                            //    row["DuyetUng"] = item.DuyetUng;
                            row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
                        row["ThoiGianThucHien"] = item.ThoiGianThucHien;
                        row["GhiChu"] = item.GhiChu;
                        row["Chon"] = false;
                        //update 28.09
                        double TongDuyetUng = 0;
                        var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                        foreach (var itemDuyetUng in t_duyetUng)
                        {
                            TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                        }
                        row["DuyetUng"] = TongDuyetUng;
                        dt.Rows.Add(row);
                    }
                    #endregion
                }
                else
                {
                    DataTable dtCheck1 = clsKN.LoadTable("select IDCP,NguoiTaoBangKe,MaNhanVien from BangLietKeCP where Duyet=1 and  SoFile='" + item.SoFile + "'");
                    string sqlCheck = "select * from FileGia where IDGia  in(select IDGia from FileGiaChiTiet where IDCP =0 or IDCP in(select IDCP from BangLietKeCP )) and SoFile = '" + item.SoFile + "'";
                    DataTable dtCheck = clsKN.LoadTable(sqlCheck);
                    if ((dtCheck.Rows.Count == 0 && dtCheck1.Rows.Count > 0))
                    {
                        for (int i = 0; i < dtCheck1.Rows.Count; i++)
                        {
                            DataRow row = dt.NewRow();
                            row["MaDieuXe"] = "";
                            row["IDLoHang"] = item.IDLoHang;
                            if (dtCheck1.Rows.Count > 0)
                                row["IDCP"] = dtCheck1.Rows[i]["IDCP"].ToString().Trim();
                            else
                                row["IDCP"] = 0;
                            var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
                            foreach (var item1 in t1)
                            {
                                row["MaKhachHang"] = item1.TenVietTat;
                            }
                            row["SoFile"] = item.SoFile;
                            row["SoToKhai"] = item.SoToKhai;
                            row["SoBill"] = item.SoBill;
                            row["SoLuong"] = item.SoLuong;
                            row["SoCont"] = item.SoCont;
                            row["TenSales"] = item.TenSales;
                            //
                            string _Ten = "";
                            //var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                            //                       join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                            //                       select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                            //foreach (var item1 in t_NguoiGiaoNhan)
                            //{
                            //    _Ten += item1.TenNhanVien + ",";
                            //}
                            //if (_Ten.Trim().Length > 0)
                            //    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                            string _tk = dtCheck1.Rows[i]["NguoiTaoBangKe"].ToString().Trim();
                            var t = context.DanhSachTaiKhoans.Where(p=>p.TaiKhoan== _tk);
                            foreach (var item1 in t)
                            {
                                row["TenGiaoNhan"] = item1.HoVaTen;
                            }
                            //
                            if (item.LoaiHang.Trim() == "HangLe")
                                row["LoaiHang"] = "Hàng Lẻ";
                            else if (item.LoaiHang.Trim() == "HangCont")
                                row["LoaiHang"] = "Hàng Cont";


                            if (item.TinhChat.Trim() == "HangNhap")
                                row["TinhChat"] = "Hàng nhập";
                            else if (item.TinhChat.Trim() == "HangXuat")
                                row["TinhChat"] = "Hàng xuất";
                            row["SoLuongToKhai"] = item.SoLuongToKhai;
                            if (item.LoaiToKhai.Trim() == "0")
                                row["LoaiToKhai"] = "Luồng xanh";
                            else if (item.LoaiToKhai.Trim() == "1")
                                row["LoaiToKhai"] = "Luồng vàng";
                            else if (item.LoaiToKhai.Trim() == "2")
                                row["LoaiToKhai"] = "Luồng đỏ";

                            if (item.NghiepVu.Trim() == "0")
                                row["NghiepVu"] = "Thông quan";
                            else if (item.NghiepVu.Trim() == "1")
                                row["NghiepVu"] = "Đổi lệnh dưới kho";
                            else if (item.NghiepVu.Trim() == "2")
                                row["NghiepVu"] = "Rút ruột";
                            else if (item.NghiepVu.Trim() == "3")
                                row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                            else if (item.NghiepVu.Trim() == "4")
                                row["NghiepVu"] = "Không có trucking";
                            if (item.PhatSinh.Trim() == "0")
                                row["PhatSinh"] = "Nhiều tờ khai";
                            else if (item.PhatSinh.Trim() == "1")
                                //row["PhatSinh"] = "Không";
                                //    row["DuyetUng"] = item.DuyetUng;
                                row["TaiKhoanThucHien"] = item.TaiKhoanThucHien;
                            row["ThoiGianThucHien"] = item.ThoiGianThucHien;
                            row["GhiChu"] = item.GhiChu;
                            row["Chon"] = false;
                            //update 28.09
                            double TongDuyetUng = 0;
                            string _MaNhanvien = dtCheck1.Rows[i]["MaNhanVien"].ToString().Trim();
                            var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.MaNhanVien == _MaNhanvien&&p.SoFile==item.SoFile);
                            foreach (var itemDuyetUng in t_duyetUng)
                            {
                                TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                            }
                            row["DuyetUng"] = TongDuyetUng;
                            dt.Rows.Add(row);
                        }
                      
                    }
                }
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public List<FileGia> FileGia_TheoIDGia(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileGias.Where(p=>p.IDGia==IDGia);
            return table.ToList();
        }
        [WebMethod]
        public List<FileGia> BangFileGiaDaTao(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileGias.Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            return t2.ToList();
        }
        [WebMethod]
        public DataTable dt_BangFileGiaDaTao(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("IDGia",typeof(int));
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("ThoiGianLap",typeof(DateTime));
            dt.Columns.Add("NguoiLap");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TongMua",typeof(double));
            dt.Columns.Add("TongBan", typeof(double));
            dt.Columns.Add("LoiNhuan", typeof(double));
            dt.Columns.Add("Duyet", typeof(bool));
            dt.Columns.Add("NgayDuyet", typeof(DateTime));
            dt.Columns.Add("NguoiDuyet");
            dt.Columns.Add("LyDoDuyet");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileGias.Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            foreach (var item in t2)
            {
                DataRow row = dt.NewRow();
                row["Duyet"] = item.Duyet;
                if (item.NgayDuyet != null)
                    row["NgayDuyet"] = item.NgayDuyet.Value;
                row["NguoiDuyet"] = item.NguoiDuyet;
                row["LyDoDuyet"] = item.LyDoDuyet;
                row["IDGia"] = item.IDGia;
                row["IDLoHang"] = item.IDLoHang;
                row["SoFile"] = item.SoFile;
                row["ThoiGianLap"] = item.ThoiGianLap;
                row["NguoiLap"] = item.NguoiLap;
                //
                double tongMua = 0, tongBan = 0, loiNhuan = 0;
                var t21 = context.FileGiaChiTiets.Where(p=>p.IDGia==item.IDGia);
                foreach (var item2 in t21)
                {
                    tongMua += item2.GiaMua.Value;
                    tongBan += item2.GiaBan.Value;
                }
                loiNhuan = tongBan - tongMua;
                row["TongMua"] = tongMua;
                row["TongBan"] = tongBan;
                row["LoiNhuan"] = loiNhuan;
                //
                var t22 = (from a in context.ThongTinFiles
                           join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                           select new { b.TenKhachHang,a.IDLoHang,b.TenVietTat }).Where(p=>p.IDLoHang==item.IDLoHang);
                foreach (var item22 in t22)
                {
                    row["TenKhachHang"] = item22.TenKhachHang;
                    row["TenVietTat"] = item22.TenVietTat;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public DataTable dt_BangFileGiaDaTao_ChuaDuyet(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("IDGia", typeof(int));
            dt.Columns.Add("IDCP", typeof(int));
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("ThoiGianLap", typeof(DateTime));
            dt.Columns.Add("NguoiLap");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TongMua", typeof(double));
            dt.Columns.Add("TongBan", typeof(double));
            dt.Columns.Add("LoiNhuan", typeof(double));
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileGias.Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0&&p.Duyet==false);
            foreach (var item in t2)
            {
                DataRow row = dt.NewRow();
                row["IDGia"] = item.IDGia;
                row["IDLoHang"] = item.IDLoHang;
                row["SoFile"] = item.SoFile;
                row["ThoiGianLap"] = item.ThoiGianLap;
                row["NguoiLap"] = item.NguoiLap;
                //
                double tongMua = 0, tongBan = 0, loiNhuan = 0;
                int _IDCP = 0;
                var t21 = context.FileGiaChiTiets.Where(p => p.IDGia == item.IDGia);
                foreach (var item2 in t21)
                {
                    tongMua += item2.GiaMua.Value;
                    tongBan += item2.GiaBan.Value;
                    _IDCP = item2.IDCP.Value;
                }
                loiNhuan = tongBan - tongMua;
                row["IDCP"] = _IDCP;
                row["TongMua"] = tongMua;
                row["TongBan"] = tongBan;
                row["LoiNhuan"] = loiNhuan;
                //
                var t22 = (from a in context.ThongTinFiles
                           join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                           select new { b.TenKhachHang, a.IDLoHang, b.TenVietTat }).Where(p => p.IDLoHang == item.IDLoHang);
                foreach (var item22 in t22)
                {
                    row["TenKhachHang"] = item22.TenKhachHang;
                    row["TenVietTat"] = item22.TenVietTat;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public DataTable dt_BangFileGiaDaTao_DaDuyet(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("IDGia", typeof(int));
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("ThoiGianLap", typeof(DateTime));
            dt.Columns.Add("NguoiLap");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TongMua", typeof(double));
            dt.Columns.Add("TongBan", typeof(double));
            dt.Columns.Add("LoiNhuan", typeof(double));
            dt.Columns.Add("Duyet", typeof(bool));
            dt.Columns.Add("NgayDuyet", typeof(DateTime));
            dt.Columns.Add("NguoiDuyet");
            dt.Columns.Add("LyDoDuyet");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileGias.Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0 && p.Duyet == true);
            foreach (var item in t2)
            {
                DataRow row = dt.NewRow();
                row["Duyet"] = item.Duyet;
                if(item.NgayDuyet!=null)
                 row["NgayDuyet"] = item.NgayDuyet.Value;
                row["NguoiDuyet"] = item.NguoiDuyet;
                row["LyDoDuyet"] = item.LyDoDuyet;
                row["IDGia"] = item.IDGia;
                row["IDLoHang"] = item.IDLoHang;
                row["SoFile"] = item.SoFile;
                row["ThoiGianLap"] = item.ThoiGianLap;
                row["NguoiLap"] = item.NguoiLap;
                //
                double tongMua = 0, tongBan = 0, loiNhuan = 0;
                var t21 = context.FileGiaChiTiets.Where(p => p.IDGia == item.IDGia);
                foreach (var item2 in t21)
                {
                    tongMua += item2.GiaMua.Value;
                    tongBan += item2.GiaBan.Value;
                }
                loiNhuan = tongBan - tongMua;
                row["TongMua"] = tongMua;
                row["TongBan"] = tongBan;
                row["LoiNhuan"] = loiNhuan;
                //
                var t22 = (from a in context.ThongTinFiles
                           join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                           select new { b.TenKhachHang, a.IDLoHang, b.TenVietTat }).Where(p => p.IDLoHang == item.IDLoHang);
                foreach (var item22 in t22)
                {
                    row["TenKhachHang"] = item22.TenKhachHang;
                    row["TenVietTat"] = item22.TenVietTat;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public void BangFileGia_Duyet_Xoa(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileGias.Single(p=>p.IDGia==IDGia);
            table.Duyet = false;
            table.NguoiDuyet = "";
            table.NgayDuyet = null;
            table.LyDoDuyet = "";
            context.SaveChanges();
        }
        [WebMethod]
        public void BangFileGia_Duyet(int IDGia,string NguoiDuyet,DateTime NgayDuyet,string LyDoDuyet)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileGias.Single(p => p.IDGia == IDGia);
            table.Duyet = true;
            table.NguoiDuyet = NguoiDuyet;
            table.NgayDuyet = NgayDuyet;
            table.LyDoDuyet = LyDoDuyet;
            context.SaveChanges();
        }
        [WebMethod]
        public List<FileGia>LoadTop1FileGia()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileGias.OrderByDescending(p => p.IDGia).Take(1);
            return t2.ToList();
        }
        [WebMethod]
        public List<FileGiaChiTiet> BangFileGiaDaTao_ChiTiet(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileGiaChiTiets.Where(p => p.IDGia == IDGia);
            return t2.ToList();
        }
        [WebMethod]
        public void FielGia_Xoa(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            FileGia t1 = context.FileGias.Single(p => p.IDGia == IDGia);
            context.FileGias.Remove(t1);
            context.SaveChanges();
            //xoa bang ke chi tiet
            var t2 = context.FileGiaChiTiets.Where(p => p.IDGia == IDGia);
            foreach (var item in t2)
            {
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    FileGiaChiTiet t11 = context1.FileGiaChiTiets.Single(p => p.IDGiaCT == item.IDGiaCT);
                    context1.FileGiaChiTiets.Remove(t11);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public DataTable DsChiPhiHQ_TheoLoHang(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("GiaMua", typeof(double));
            dt1.Columns.Add("GiaBan", typeof(double));
            dt1.Columns.Add("GhiChu");
            dt1.TableName = "xem";
            double TongHQ = 0, phi_KTCL = 0, c_mua = 0, c_ban = 0;
            string tuyenvc = "";
            var t1 = context.BangLietKeCP_ChiTiet.Where(p=>p.IDLoHang==IDLoHang&&p.MaChiPhi_HQ!=null);
            foreach (var item in t1)
            {
                TongHQ += item.SoTien_HQ.Value;
            }
            var t2 = context.BangLietKeCPs.Where(p=>p.IDLoHang==IDLoHang);
            foreach (var item in t2)
            {
                phi_KTCL = item.PhiDangKy.Value;
            }
            DataRow row1 = dt1.NewRow();
            row1["TenDichVu"] = "Chi phí hải quan";
            row1["GiaMua"] = TongHQ;
            row1["GiaBan"] = 0;
            dt1.Rows.Add(row1);
            //
            DataRow row2 = dt1.NewRow();
            row2["TenDichVu"] = "Phí đăng ký kiểm tra chất lượng";
            row2["GiaMua"] = phi_KTCL;
            row2["GiaBan"] = 0;
            dt1.Rows.Add(row2);
            //
            var t3 = (from a in context.BangDieuXes
                      join b in context.ThongTinFiles on a.SoFile equals b.SoFile
                      select new {Mua = a.CuocMua.Value,
                          Ban=a.CuocBan.Value+ a.LaiXeThuCuoc.Value,
                          b.IDLoHang,a.TuyenVC }).Where(p=>p.IDLoHang==IDLoHang);
            foreach (var item in t3)
            {
                c_mua = item.Mua;
                c_ban = item.Ban;
                tuyenvc = item.TuyenVC;
            }
            DataRow row3 = dt1.NewRow();
            row3["TenDichVu"] = (tuyenvc=="")?"Vui lòng nhập tuyến vận chuyển": tuyenvc;
            row3["GiaMua"] = c_mua;
            row3["GiaBan"] = c_ban;
            dt1.Rows.Add(row3);
            ////
            //DataRow row4 = dt1.NewRow();
            //row4["TenDichVu"] = "COMISSION";
            //row4["GiaMua"] = 0;
            //row4["GiaBan"] = 0;
            //dt1.Rows.Add(row4);
            return dt1;
        }
        [WebMethod]//update không cộng dồn số tiền 30/08
        public DataTable DsChiPhiHQ_TheoSoFile(string SoFile, int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("GiaMua", typeof(double));
            dt1.Columns.Add("GiaBan", typeof(double));
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("IDCP");
            dt1.TableName = "xem";
          
            string tuyenvc = "";
            double c_mua = 0, c_ban = 0;
            var t9 = (from a in context.FileGiaChiTiets
                      join b in context.FileGias on a.IDGia equals b.IDGia select new { b.IDLoHang, a.IDCP }).Where(p => p.IDLoHang == IDLoHang);
            var t2 = context.BangLietKeCPs.Where(p => p.IDLoHang == IDLoHang&& !t9.Any(p1=>p1.IDCP==p.IDCP));
            foreach (var item in t2)
            {
                double TongHQ = 0, phi_KTCL = 0, TongCH = 0;
                phi_KTCL = item.PhiDangKy.Value;
                //
                var t1 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item2 in t1)
                {
                    TongHQ += item2.SoTien_HQ.Value;
                }
                //update 19.01
                var t11 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item2 in t11)
                {
                    TongCH += item2.SoTien_ChiHo.Value;
                }
                //
                DataRow row1 = dt1.NewRow();
                row1["TenDichVu"] = "Chi phí hải quan";
                row1["GiaMua"] = TongHQ;
                row1["GiaBan"] = 0;
                row1["IDCP"] = item.IDCP;
                dt1.Rows.Add(row1);
                //
                DataRow row2 = dt1.NewRow();
                row2["TenDichVu"] = "Phí đăng ký kiểm tra chất lượng";
                row2["GiaMua"] = phi_KTCL;
                row2["GiaBan"] = 0;
                row2["IDCP"] = item.IDCP;
                dt1.Rows.Add(row2);
                //update 19.01
                //
                //DataRow row3 = dt1.NewRow();
                //row3["TenDichVu"] = "Phí chi hộ";
                //row3["GiaMua"] = TongCH;
                //row3["GiaBan"] = TongCH;
                //row3["IDCP"] = item.IDCP;
                //dt1.Rows.Add(row3);
            }
            
            //
            var t3 = (from a in context.BangDieuXes
                          // join b in context.ThongTinFiles on a.SoFile equals b.SoFile
                      join b in context.ThongTinFiles on a.SoFile equals b.SoFile into c1
                      from sub1 in c1.DefaultIfEmpty()
                      select new
                      {
                          Mua = a.CuocMua.Value,
                          Ban = a.CuocBan.Value + a.LaiXeThuCuoc.Value,
                          sub1.IDLoHang,
                          a.TuyenVC,
                          a.SoFile
                      }).Where(p => p.SoFile == SoFile);
            foreach (var item in t3)
            {
                c_mua = item.Mua;
                c_ban = item.Ban;
                tuyenvc = item.TuyenVC;
                //
                DataRow row3 = dt1.NewRow();
                row3["TenDichVu"] = (tuyenvc == "") ? "Vui lòng nhập tuyến vận chuyển" : tuyenvc;
                row3["GiaMua"] = c_mua;
                row3["GiaBan"] = c_ban;
                dt1.Rows.Add(row3);
            }

            ////
            //DataRow row4 = dt1.NewRow();
            //row4["TenDichVu"] = "COMISSION";
            //row4["GiaMua"] = 0;
            //row4["GiaBan"] = 0;
            //dt1.Rows.Add(row4);
            //lay thong tin so tien MaChi chi phi kinh doanh
            var t4 = (from a in context.PhieuChi_Con_CT
                      join b in context.PhieuChi_Con on a.SoChungTu equals b.SoChungTu select new {a.SoTien,a.SoFile,b.MaChi,a.GhiChu }).Where(p=>p.SoFile==SoFile&&p.MaChi== "004");
            foreach (var item in t4)
            {
                DataRow row3 = dt1.NewRow();
                row3["TenDichVu"] = item.GhiChu;
                row3["GiaMua"] = item.SoTien;
                row3["GiaBan"] = 0;
                dt1.Rows.Add(row3);
            }
            return dt1;
        }
        [WebMethod]
        public DataTable DsChiPhiHQ_TheoSoFile2(string SoFile, int IDLoHang,int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("GiaMua", typeof(double));
            dt1.Columns.Add("GiaBan", typeof(double));
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("IDCP");
            dt1.TableName = "xem";

            string tuyenvc = "";
            double c_mua = 0, c_ban = 0;
            var t2 = context.BangLietKeCPs.Where(p => p.IDLoHang == IDLoHang && p.IDCP== IDCP);
            foreach (var item in t2)
            {
                double TongHQ = 0, phi_KTCL = 0, TongCH = 0;
                phi_KTCL = (item.PhiDangKy == null) ? 0: item.PhiDangKy.Value;
                //
                var t1 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item2 in t1)
                {
                    TongHQ +=(item2.SoTien_HQ==null)?0: item2.SoTien_HQ.Value;
                }
                //update 19.01
                var t11 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item2 in t11)
                {
                    TongCH +=(item2.SoTien_ChiHo==null)?0: item2.SoTien_ChiHo.Value;
                }
                //
                DataRow row1 = dt1.NewRow();
                row1["TenDichVu"] = "Chi phí hải quan";
                row1["GiaMua"] = TongHQ;
                row1["GiaBan"] = 0;
                row1["IDCP"] = item.IDCP;
                dt1.Rows.Add(row1);
                //
                DataRow row2 = dt1.NewRow();
                row2["TenDichVu"] = "Phí đăng ký kiểm tra chất lượng";
                row2["GiaMua"] = phi_KTCL;
                row2["GiaBan"] = 0;
                row2["IDCP"] = item.IDCP;
                dt1.Rows.Add(row2);
                //update 19.01
                //
                //DataRow row3 = dt1.NewRow();
                //row3["TenDichVu"] = "Phí chi hộ";
                //row3["GiaMua"] = TongCH;
                //row3["GiaBan"] = TongCH;
                //row3["IDCP"] = item.IDCP;
                //dt1.Rows.Add(row3);
            }

            //
            var t3 = (from a in context.BangDieuXes
                          // join b in context.ThongTinFiles on a.SoFile equals b.SoFile
                      join b in context.ThongTinFiles on a.SoFile equals b.SoFile into c1
                      from sub1 in c1.DefaultIfEmpty()
                      select new
                      {
                          Mua = (a.CuocMua == null) ? 0: a.CuocMua.Value,
                          Ban =((a.CuocBan==null)?0: a.CuocBan.Value) + ((a.LaiXeThuCuoc==null)?0:a.LaiXeThuCuoc.Value),
                          sub1.IDLoHang,
                          a.TuyenVC,
                          a.SoFile
                      }).Where(p => p.SoFile == SoFile);
            foreach (var item in t3)
            {
                c_mua = item.Mua;
                c_ban = item.Ban;
                tuyenvc = item.TuyenVC;
                //
                DataRow row3 = dt1.NewRow();
                row3["TenDichVu"] = (tuyenvc == "") ? "Vui lòng nhập tuyến vận chuyển" : tuyenvc;
                row3["GiaMua"] = c_mua;
                row3["GiaBan"] = c_ban;
                dt1.Rows.Add(row3);
            }

            ////
            //DataRow row4 = dt1.NewRow();
            //row4["TenDichVu"] = "COMISSION";
            //row4["GiaMua"] = 0;
            //row4["GiaBan"] = 0;
            //dt1.Rows.Add(row4);
            //lay thong tin so tien MaChi chi phi kinh doanh
            var t4 = (from a in context.PhieuChi_Con_CT
                      join b in context.PhieuChi_Con on a.SoChungTu equals b.SoChungTu
                      select new { a.SoTien, a.SoFile, b.MaChi, a.GhiChu }).Where(p => p.SoFile == SoFile && p.MaChi == "004");
            foreach (var item in t4)
            {
                DataRow row3 = dt1.NewRow();
                row3["TenDichVu"] = item.GhiChu;
                row3["GiaMua"] = item.SoTien;
                row3["GiaBan"] = 0;
                dt1.Rows.Add(row3);
            }
            return dt1;
        }
        [WebMethod]
        public DataTable DsChiPhiHQ_TheoSoFile_BoSung(string SoFile, int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("GiaMua", typeof(double));
            dt1.Columns.Add("GiaBan", typeof(double));
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("IDCP");
            dt1.TableName = "xem";

            string tuyenvc = "";
            double c_mua = 0, c_ban = 0;
            var t9 = (from a in context.FileGiaChiTiets
                      join b in context.FileGias on a.IDGia equals b.IDGia
                      select new { b.IDLoHang, a.IDCP }).Where(p => p.IDLoHang == IDLoHang);
            var t2 = context.BangLietKeCPs.Where(p => p.IDLoHang == IDLoHang && !t9.Any(p1 => p1.IDCP == p.IDCP));
            foreach (var item in t2)
            {
                double TongHQ = 0, phi_KTCL = 0, TongCH = 0;
                phi_KTCL = item.PhiDangKy.Value;
                //
                var t1 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiPhi_HQ != null);
                foreach (var item2 in t1)
                {
                    TongHQ += item2.SoTien_HQ.Value;
                }
                //update 19.01
                var t11 = context.BangLietKeCP_ChiTiet.Where(p => p.IDCP == item.IDCP && p.MaChiHo != null);
                foreach (var item2 in t11)
                {
                    TongCH += item2.SoTien_ChiHo.Value;
                }
                //
                DataRow row1 = dt1.NewRow();
                row1["TenDichVu"] = "Chi phí hải quan";
                row1["GiaMua"] = TongHQ;
                row1["GiaBan"] = 0;
                row1["IDCP"] = item.IDCP;
                dt1.Rows.Add(row1);
                //
                DataRow row2 = dt1.NewRow();
                row2["TenDichVu"] = "Phí đăng ký kiểm tra chất lượng";
                row2["GiaMua"] = phi_KTCL;
                row2["GiaBan"] = 0;
                row2["IDCP"] = item.IDCP;
                dt1.Rows.Add(row2);
                //update 19.01
                //
                DataRow row3 = dt1.NewRow();
                row3["TenDichVu"] = "Phí chi hộ";
                row3["GiaMua"] = TongCH;
                row3["GiaBan"] = TongCH;
                row3["IDCP"] = item.IDCP;
                dt1.Rows.Add(row3);
            }

           
            return dt1;
        }
        //public DataTable DsChiPhiHQ_TheoSoFile(string SoFile,int IDLoHang)
        //{
        //    vua45987_vudacoEntities context = new vua45987_vudacoEntities();
        //    DataTable dt1 = new DataTable("table");
        //    dt1.Columns.Add("TenDichVu");
        //    dt1.Columns.Add("GiaMua", typeof(double));
        //    dt1.Columns.Add("GiaBan", typeof(double));
        //    dt1.Columns.Add("GhiChu");
        //    dt1.TableName = "xem";
        //    double TongHQ = 0, phi_KTCL = 0, c_mua = 0, c_ban = 0;
        //    string tuyenvc = "";
        //    var t1 = context.BangLietKeCP_ChiTiet.Where(p => p.IDLoHang == IDLoHang && p.MaChiPhi_HQ != null);

        //    foreach (var item in t1)
        //    {
        //        TongHQ += item.SoTien_HQ.Value;
        //    }
        //    var t2 = context.BangLietKeCPs.Where(p => p.IDLoHang == IDLoHang);
        //    foreach (var item in t2)
        //    {
        //        phi_KTCL = item.PhiDangKy.Value;

        //    }
        //    DataRow row1 = dt1.NewRow();
        //    row1["TenDichVu"] = "Chi phí hải quan";
        //    row1["GiaMua"] = TongHQ;
        //    row1["GiaBan"] = 0;
        //    dt1.Rows.Add(row1);
        //    //
        //    DataRow row2 = dt1.NewRow();
        //    row2["TenDichVu"] = "Phí đăng ký kiểm tra chất lượng";
        //    row2["GiaMua"] = phi_KTCL;
        //    row2["GiaBan"] = 0;
        //    dt1.Rows.Add(row2);
        //    //
        //    var t3 = (from a in context.BangDieuXes
        //             // join b in context.ThongTinFiles on a.SoFile equals b.SoFile
        //              join b in context.ThongTinFiles on a.SoFile equals b.SoFile into c1
        //              from sub1 in c1.DefaultIfEmpty()
        //              select new
        //              {
        //                  Mua = a.CuocMua.Value,
        //                  Ban = a.CuocBan.Value + a.LaiXeThuCuoc.Value,
        //                  sub1.IDLoHang,
        //                  a.TuyenVC,
        //                  a.SoFile
        //              }).Where(p => p.SoFile == SoFile);
        //    foreach (var item in t3)
        //    {
        //        c_mua += item.Mua;
        //        c_ban += item.Ban;
        //        tuyenvc = item.TuyenVC;
        //    }
        //    DataRow row3 = dt1.NewRow();
        //    row3["TenDichVu"] = (tuyenvc == "") ? "Vui lòng nhập tuyến vận chuyển" : tuyenvc;
        //    row3["GiaMua"] = c_mua;
        //    row3["GiaBan"] = c_ban;
        //    dt1.Rows.Add(row3);
        //    ////
        //    //DataRow row4 = dt1.NewRow();
        //    //row4["TenDichVu"] = "COMISSION";
        //    //row4["GiaMua"] = 0;
        //    //row4["GiaBan"] = 0;
        //    //dt1.Rows.Add(row4);
        //    return dt1;
        //}
        [WebMethod]
        public void LuuFileGia(FileGia p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.FileGias.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void LuuFileGiaChiTiet(FileGiaChiTiet p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int _IDGia = 0;
            var t = LoadTop1FileGia();
            foreach (var item in t)
            {
                _IDGia = item.IDGia;
            }
            p.IDGia = _IDGia;
            context.FileGiaChiTiets.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void LuuFileGiaChiTiet1(FileGiaChiTiet p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
          
            context.FileGiaChiTiets.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        //check bang nhat ki dieu xe
        public bool BangKeChiPhi_KiemTraFileGia(int IDLoHang)
        {
           
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileGias.Where(p=>p.IDLoHang==IDLoHang);
            if (table.Count() > 0)
                return true;
            else
                return false;
        }
        [WebMethod]
        //check bang nhat ki dieu xe
        public bool BangDieuXe_KiemTraFileGia(int IDBangPhi)
        {
            int IdLoHang = 0;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = (from a in context.BangDieuXes
                        join b in context.ThongTinFiles on a.SoFile equals b.SoFile
                        select new {a.IDBangPhi,b.IDLoHang})
                .Where(p => p.IDBangPhi == IDBangPhi);
            foreach (var item in table)
            {
                IdLoHang = item.IDLoHang;
            }
            var table1 = context.FileGias.Where(p => p.IDLoHang == IdLoHang);
            if (table1.Count() > 0)
                return true;
            else
                return false;
        }
        [WebMethod]
        public bool BangPhoiNangHa_KiemTraFileGia(int IDCP)
        {
            int IdLoHang = 0;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangPhoiNangHas.Where(p => p.IDCP == IDCP);
            foreach (var item in table)
            {
                IdLoHang = item.IDLoHang.Value;
            }
            var table1 = context.FileGias.Where(p => p.IDLoHang == IdLoHang);
            if (table1.Count() > 0)
                return true;
            else
                return false;
        }
        [WebMethod]
        public bool FileGia_KiemTraFileDebit(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.FileDebits.Where(p=>p.IDGia== IDGia);
            if (table.Count() > 0)
                return true;
            else
                return false;
        }
        [WebMethod]
        public void XoaFileGia(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int IDGia =0;
            var t3= context.FileGias.Where(p => p.IDLoHang == IDLoHang);
            foreach (var item in t3)
            {
                IDGia = item.IDGia;
            }

            FileGia table = context.FileGias.Single(p=>p.IDGia== IDGia);
            context.FileGias.Remove(table);
            context.SaveChanges();
            var t2 = context.FileGiaChiTiets.Where(p=>p.IDGia==IDGia);
            using(vua45987_vudacoEntities context1=new vua45987_vudacoEntities())
            {
                foreach (var item in t2)
                {
                    FileGiaChiTiet table2 = context1.FileGiaChiTiets.Single(p=>p.IDGiaCT==item.IDGiaCT);
                    context1.FileGiaChiTiets.Remove(table2);
                    context1.SaveChanges();
                }
            }    
        }
        [WebMethod]
        public void XoaFileGia_TheoIDGia(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
           

            FileGia table = context.FileGias.Single(p => p.IDGia == IDGia);
            context.FileGias.Remove(table);
            context.SaveChanges();
            var t2 = context.FileGiaChiTiets.Where(p => p.IDGia == IDGia);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item in t2)
                {
                    FileGiaChiTiet table2 = context1.FileGiaChiTiets.Single(p => p.IDGiaCT == item.IDGiaCT);
                    context1.FileGiaChiTiets.Remove(table2);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public void XoaFileGiaChiTiet_TheoIDGia(int IDGia)
        {
            clsKetNoi cls = new clsKetNoi();
            cls.UpdateTable("delete from FileGiaChiTiet where IDGia="+IDGia);
           
            //vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            //var t2 = context.FileGiaChiTiets.Where(p => p.IDGia == IDGia);
            //using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            //{
            //    foreach (var item in t2)
            //    {
            //        FileGiaChiTiet table2 = context1.FileGiaChiTiets.Single(p => p.IDGiaCT == item.IDGiaCT);
            //        context1.FileGiaChiTiets.Remove(table2);
            //        context1.SaveChanges();
            //    }
            //}
        }
        //debit
        [WebMethod]
        public DataTable BangFileGiaChuaTaoDebit_Xem(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("IDGia");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TaiKhoanThucHien");
            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("Chon", typeof(bool));
            List<clsBangLietKeChiPhi> q = new List<clsBangLietKeChiPhi>();
            var table = (from a in context.ThongTinFiles
                        join b in context.FileGias on a.IDLoHang equals b.IDLoHang
                        select new {
                        a.SoFile,
                        a.SoToKhai,
                        a.SoBill,
                        a.SoLuong,
                        a.SoLuongToKhai,
                        a.SoCont,
                        a.TenSales,
                        a.LoaiHang,
                        a.TinhChat,
                        a.LoaiToKhai,
                        a.NghiepVu,
                        a.PhatSinh,
                       // a.DuyetUng,
                        Chon=false,
                        b.NguoiLap,
                        b.ThoiGianLap,
                        a.GhiChu,
                        a.IDLoHang,
                        a.MaKhachHang,
                        b.IDGia,
                        b.Duyet
                        })
                      .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
         DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0&&p.Duyet==true);//update 06.02.2025
            foreach (var item in table)
            {

                var t = context.FileDebits.Where(p => p.IDGia == item.IDGia);
                if (t.Count() == 0)
                {
                    DataRow row = dt.NewRow();
                    row["IDLoHang"] = item.IDLoHang;
                    row["IDGia"] = item.IDGia;
                    var t1 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == item.MaKhachHang);
                    foreach (var item1 in t1)
                    {
                        row["MaKhachHang"] = item1.TenVietTat;
                    }
                    row["SoFile"] = item.SoFile;
                    row["SoToKhai"] = item.SoToKhai;
                    row["SoBill"] = item.SoBill;
                    row["SoLuong"] = item.SoLuong;
                    row["SoCont"] = item.SoCont;
                    row["TenSales"] = item.TenSales;
                    //
                    string _Ten = "";
                    var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                           join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                           select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                    foreach (var item1 in t_NguoiGiaoNhan)
                    {
                        _Ten += item1.TenNhanVien + ",";
                    }
                    if (_Ten.Trim().Length > 0)
                        _Ten = _Ten.Substring(0, _Ten.Length - 1);
                    row["TenGiaoNhan"] = _Ten;
                    //
                    if (item.LoaiHang.Trim() == "HangLe")
                        row["LoaiHang"] = "Hàng Lẻ";
                    else if (item.LoaiHang.Trim() == "HangCont")
                        row["LoaiHang"] = "Hàng Cont";


                    if (item.TinhChat.Trim() == "HangNhap")
                        row["TinhChat"] = "Hàng nhập";
                    else if (item.TinhChat.Trim() == "HangXuat")
                        row["TinhChat"] = "Hàng xuất";
                    row["SoLuongToKhai"] = item.SoLuongToKhai;
                    if (item.LoaiToKhai.Trim() == "0")
                        row["LoaiToKhai"] = "Luồng xanh";
                    else if (item.LoaiToKhai.Trim() == "1")
                        row["LoaiToKhai"] = "Luồng vàng";
                    else if (item.LoaiToKhai.Trim() == "2")
                        row["LoaiToKhai"] = "Luồng đỏ";

                    if (item.NghiepVu.Trim() == "0")
                        row["NghiepVu"] = "Thông quan";
                    else if (item.NghiepVu.Trim() == "1")
                        row["NghiepVu"] = "Đổi lệnh dưới kho";
                    else if (item.NghiepVu.Trim() == "2")
                        row["NghiepVu"] = "Rút ruột";
                    else if (item.NghiepVu.Trim() == "3")
                        row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                    else if (item.NghiepVu.Trim() == "4")
                        row["NghiepVu"] = "Không có trucking";
                    if (item.PhatSinh.Trim() == "0")
                        row["PhatSinh"] = "Nhiều tờ khai";
                    else if (item.PhatSinh.Trim() == "1")
                        //row["PhatSinh"] = "Không";
                    //    row["DuyetUng"] = item.DuyetUng;
                    row["TaiKhoanThucHien"] = item.NguoiLap;
                    row["ThoiGianThucHien"] = item.ThoiGianLap;
                    row["GhiChu"] = item.GhiChu;
                    row["Chon"] = false;
                    //update 28.09
                    double TongDuyetUng = 0;
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                    row["DuyetUng"] = TongDuyetUng;
                    dt.Rows.Add(row);
                }
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public List<FileDebit> BangFileDebitDaTao(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebits.Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            return t2.ToList();
        }
        //code cũ
        [WebMethod]
        public DataTable dt_BangFileDebitDaTao(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDDeBit",typeof(int));
            dt.Columns.Add("IDGia", typeof(int));
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("ThoiGianLap", typeof(DateTime));
            dt.Columns.Add("NguoiLap");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("ThanhTien", typeof(double));
            dt.Columns.Add("TongPhi", typeof(double));
            dt.Columns.Add("TongPhi_VAT", typeof(double));
            dt.Columns.Add("TongPhiChiHo", typeof(double));
            dt.Columns.Add("TongChiPhiLoHang", typeof(double));
            dt.Columns.Add("VAT", typeof(double));
            dt.Columns.Add("SoBill"); 
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("Chon",typeof(bool));
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("NgayHoaDon",typeof(DateTime));
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = (from a in context.FileDebits
                     join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                     join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                     select new {
                     a.IDDeBit,
                     a.IDGia,
                     a.IDLoHang,
                     a.NguoiLap,
                     a.SoFile,
                     a.ThoiGianLap,
                     c.TenKhachHang,
                     c.TenVietTat,
                     b.SoBill,
                     b.SoToKhai,
                     b.TenSales,
                     Chon=false,
                     a.SoHoaDon,
                     a.NgayHoaDon
                     })
                     .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            foreach (var item in t2)
            {
                DataRow row = dt.NewRow();
                row["IDDeBit"] = item.IDDeBit;
                row["IDGia"] = item.IDGia;
                row["IDLoHang"] = item.IDLoHang;
                row["NguoiLap"] = item.NguoiLap;
                row["SoFile"] = item.SoFile;
                row["ThoiGianLap"] = item.ThoiGianLap;
                row["TenKhachHang"] = item.TenKhachHang;
                row["TenVietTat"] = item.TenVietTat;
                row["SoBill"] = item.SoBill;
                row["SoToKhai"] = item.SoToKhai;
                row["TenSales"] = item.TenSales;
                row["Chon"] = item.Chon;
                row["SoHoaDon"] = item.SoHoaDon;
                if(item.NgayHoaDon!=null)
                   row["NgayHoaDon"] = item.NgayHoaDon.Value;
                //sum thanh tien
                double _TT = 0, _VAT = 0, _TongPhi = 0, _TongPhiChiHo = 0, _TongPhi_VAT = 0;
                var t22 = context.FileDebitChiTiets.Where(p=>p.IDDeBit==item.IDDeBit);
                foreach (var item2 in t22)
                {
                    _TT += item2.ThanhTien.Value;
                  
                    _VAT += (item2.VAT.Value* item2.SoTien.Value)/100;
                    if(item2.LaPhiChiHo.Value)
                        _TongPhiChiHo += item2.ThanhTien.Value;
                    else
                        _TongPhi += item2.SoTien.Value;
                    _TongPhi_VAT = _VAT + _TongPhi;
                }
                row["ThanhTien"] = _TT;
                row["TongPhi"] = _TongPhi;
                row["TongPhi_VAT"] = _TongPhi_VAT;
                row["TongChiPhiLoHang"] = _TT;
                row["TongPhiChiHo"] = _TongPhiChiHo;
                row["VAT"] = _VAT;
                dt.Rows.Add(row);
            }
           return dt;
        }
        [WebMethod]
        public void FileDeBit_XuatHoaDon(bool XuatHD,string arr,string SoHoaDon,DateTime Ngay)
        {
            if(arr.Length>0)
            {
                string[] arr1 = arr.Split('-');
                for (int i = 0; i < arr1.Length; i++)
                {
                    int key = int.Parse(arr1[i]);
                    vua45987_vudacoEntities context = new vua45987_vudacoEntities();
                    var table = context.FileDebits.Single(p => p.IDDeBit == key);
                    if (!XuatHD)
                    {
                        table.SoHoaDon = "";
                        table.NgayHoaDon = null;
                    }
                    else
                    {
                        table.SoHoaDon = SoHoaDon;
                        table.NgayHoaDon = Ngay;
                    }
                    context.SaveChanges();
                }
            }    
            
              
        }
        [WebMethod]
        public void FileDeBit_KoLapFile_XuatHoaDon(bool XuatHD, string arr, string SoHoaDon, DateTime Ngay)
        {
            if (arr.Length > 0)
            {
                string[] arr1 = arr.Split('-');
                for (int i = 0; i < arr1.Length; i++)
                {
                    int key = int.Parse(arr1[i]);
                    vua45987_vudacoEntities context = new vua45987_vudacoEntities();
                    var table = context.FileDebit_KoHoaDon_KH.Single(p => p.IDDeBit == key);
                    if (!XuatHD)
                    {
                        table.SoHoaDon = "";
                        table.NgayHoaDon = null;
                    }
                    else
                    {
                        table.SoHoaDon = SoHoaDon;
                        table.NgayHoaDon = Ngay;
                    }
                    context.SaveChanges();
                }
            }


        }
        [WebMethod]
        public List<FileDebit_KoHoaDon_NCC> dt_BangFileDebitDaTao_NCC(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebit_KoHoaDon_NCC.Where(p=>DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
          
            return t2.ToList();
        }
        [WebMethod]
        public List<FileDebit_KoHoaDon_NCC> dt_BangFileDebitDaTao_NCC_CoFile(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebit_KoHoaDon_NCC.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0&&p.SoFile.Length>3);

            return t2.ToList();
        }
        [WebMethod]
        public List<FileDebit_KoHoaDon_NCC> dt_BangFileDebitDaTao_NCC_KhongFile(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebit_KoHoaDon_NCC.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0 && p.SoFile.Length < 3);

            return t2.ToList();
        }
        [WebMethod]
        public List<FileDebit_KoHoaDon_KH> dt_BangFileDebitDaTao_KH(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebit_KoHoaDon_KH.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);

            return t2.ToList();
        }
        //code mới, update hàm dt_BangFileDebitDaTao show nhiều dòng theo SoFile
        [WebMethod]
        public DataTable dt_BangFileDebitDaTao_PhiDiDuong(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable("table");
            dt.Columns.Add("IDDeBit", typeof(int));
            dt.Columns.Add("IDGia", typeof(int));
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("ThoiGianLap", typeof(DateTime));
            dt.Columns.Add("NguoiLap");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("ThanhTien", typeof(double));
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("TenSales");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = (
                 from d in context.BangPhiDiDuongs
                 join a in context.FileDebits on d.SoFile equals a.SoFile
                      join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                      select new
                      {
                          a.IDDeBit,
                          a.IDGia,
                          a.IDLoHang,
                          a.NguoiLap,
                          a.SoFile,
                          a.ThoiGianLap,
                          c.TenKhachHang,
                          c.TenVietTat,
                          b.SoBill,
                          b.SoToKhai,
                          b.TenSales
                      })
                     .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 &&
               DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            foreach (var item in t2)
            {
                DataRow row = dt.NewRow();
                row["IDDeBit"] = item.IDDeBit;
                row["IDGia"] = item.IDGia;
                row["IDLoHang"] = item.IDLoHang;
                row["NguoiLap"] = item.NguoiLap;
                row["SoFile"] = item.SoFile;
                row["ThoiGianLap"] = item.ThoiGianLap;
                row["TenKhachHang"] = item.TenKhachHang;
                row["TenVietTat"] = item.TenVietTat;
                row["SoBill"] = item.SoBill;
                row["SoToKhai"] = item.SoToKhai;
                row["TenSales"] = item.TenSales;
                //sum thanh tien
                double _TT = 0;
                var t22 = context.FileDebitChiTiets.Where(p => p.IDDeBit == item.IDDeBit);
                foreach (var item2 in t22)
                {
                    _TT += item2.ThanhTien.Value;
                }
                row["ThanhTien"] = _TT;
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public List<FileDebitChiTiet> BangFileDebitDaTao_ChiTiet(int IDDeBit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebitChiTiets.Where(p => p.IDDeBit == IDDeBit);
            return t2.ToList();
        }
        [WebMethod]
        public DataTable DsFileDebit_IDDEDIT_In(int IDDeBit)
        {
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            //
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("TenDichVu");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("VAT", typeof(double));
            dt.Columns.Add("ThanhTien",typeof(double));
            dt.Columns.Add("GhiChu");
            //
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t2 = context.FileDebitChiTiets.Where(p => p.IDDeBit == IDDeBit);
            foreach (var item in t2)
            {
                DataRow row = dt.NewRow();
                row["SoHoaDon"] = item.SoHoaDon;
                row["TenDichVu"] = item.TenDichVu;
                row["SoTien"] = item.SoTien;
                row["VAT"] = item.VAT;
                row["ThanhTien"] = item.ThanhTien;
                row["GhiChu"] = item.GhiChu;
                var t1 = (from a in context.FileDebits
                         join b in context.ThongTinFiles on a.IDLoHang equals b.IDLoHang
                         join c in context.DanhSachKhachHangs on b.MaKhachHang equals c.MaKhachHang
                         select new
                         {
                             Ngay= a.ThoiGianLap,
                             b.SoFile,b.SoToKhai,b.SoBill,c.TenKhachHang,
                             b.SoLuong,b.SoCont,b.TenSales,a.IDDeBit
                         }
                         )
                         .Where(p => p.IDDeBit == IDDeBit);
                foreach (var item1 in t1)
                {
                    row["Ngay"] = item1.Ngay; 
                    row["SoFile"] = item1.SoFile;
                    row["SoToKhai"] = item1.SoToKhai;
                    row["SoBill"] = item1.SoBill;
                    row["TenKhachHang"] = item1.TenKhachHang;
                    row["SoLuong"] = item1.SoLuong;
                    row["SoCont"] = item1.SoCont;
                    row["TenSales"] = item1.TenSales;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public DataTable DsThongTinFile_Full_TheoIDLoHang_TheoIDGia(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("IDGia");
            var table = (from a in context.ThongTinFiles
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.FileGias on a.IDLoHang equals c.IDLoHang
                         select new
                         {
                             c.ThoiGianLap,
                             a.IDLoHang,
                             a.SoBill,
                             a.SoFile,
                             a.SoToKhai,
                             a.SoLuong,
                             a.SoCont,
                            // a.DuyetUng,
                             b.TenKhachHang,
                             a.TenSales,
                             a.LoaiHang,
                             a.TinhChat,
                             a.SoLuongToKhai,
                             a.LoaiToKhai,
                             a.NghiepVu,
                             a.PhatSinh,
                             c.IDGia
                         }
                             ).Where(p => p.IDGia == IDGia);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["Ngay"] = item.ThoiGianLap;
                if (item.PhatSinh.Trim() == "0")
                    row["PhatSinh"] = "Nhiều tờ khai";
                else if (item.PhatSinh.Trim() == "1")
                    row["PhatSinh"] = "Không";
                if (item.NghiepVu.Trim() == "0")
                    row["NghiepVu"] = "Thông quan";
                else if (item.NghiepVu.Trim() == "1")
                    row["NghiepVu"] = "Đổi lệnh dưới kho";
                else if (item.NghiepVu.Trim() == "2")
                    row["NghiepVu"] = "Rút ruột";
                else if (item.NghiepVu.Trim() == "3")
                    row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                else if (item.NghiepVu.Trim() == "4")
                    row["NghiepVu"] = "Không có trucking";

                if (item.LoaiToKhai.Trim() == "0")
                    row["LoaiToKhai"] = "Luồng xanh";
                else if (item.LoaiToKhai.Trim() == "1")
                    row["LoaiToKhai"] = "Luồng vàng";
                else if (item.LoaiToKhai.Trim() == "2")
                    row["LoaiToKhai"] = "Luồng đỏ";
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                if (item.LoaiHang.Trim() == "HangLe")
                    row["LoaiHang"] = "Hàng Lẻ";
                else if (item.LoaiHang.Trim() == "HangCont")
                    row["LoaiHang"] = "Hàng Cont";
                if (item.TinhChat.Trim() == "HangNhap")
                    row["TinhChat"] = "Hàng nhập";
                else if (item.TinhChat.Trim() == "HangXuat")
                    row["TinhChat"] = "Hàng xuất";
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                       join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                       select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten += item1.TenNhanVien + ",";
                }
                if (_Ten.Trim().Length > 0)
                    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;
                //
                row["TenSales"] = item.TenSales;
                row["IDLoHang"] = item.IDLoHang;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoToKhai"] = item.SoToKhai;
                row["SoLuong"] = item.SoLuong;
                row["SoCont"] = item.SoCont;
                //update 28.09
                double TongDuyetUng = 0;
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
                row["DuyetUng"] = TongDuyetUng;
                //  row["DuyetUng"] = item.DuyetUng.Value;
                row["TenKhachHang"] = item.TenKhachHang;
                row["IDGia"] = item.IDGia;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DsThongTinFile_Full_TheoIDLoHang_FileGia(int IDLoHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("IDLoHang", typeof(int));
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("DuyetUng", typeof(double));
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("LoaiHang");
            dt.Columns.Add("TinhChat");
            dt.Columns.Add("SoLuongToKhai");
            dt.Columns.Add("LoaiToKhai");
            dt.Columns.Add("NghiepVu");
            dt.Columns.Add("PhatSinh");
            dt.Columns.Add("IDGia");
            dt.Columns.Add("ThoiGianLap",typeof(DateTime));//ngay lap file gia
            var table = (from a in context.ThongTinFiles
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.FileGias on a.IDLoHang equals c.IDLoHang
                         select new
                         {
                             a.IDLoHang,
                             a.SoBill,
                             a.SoFile,
                             a.SoToKhai,
                             a.SoLuong,
                             a.SoCont,
                            // a.DuyetUng,
                             b.TenKhachHang,
                             a.TenSales,
                             a.LoaiHang,
                             a.TinhChat,
                             a.SoLuongToKhai,
                             a.LoaiToKhai,
                             a.NghiepVu,
                             a.PhatSinh,
                             c.IDGia,
                             c.ThoiGianLap
                         }
                             ).Where(p => p.IDLoHang == IDLoHang);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["ThoiGianLap"] = item.ThoiGianLap;
                if (item.PhatSinh.Trim() == "0")
                    row["PhatSinh"] = "Nhiều tờ khai";
                else if (item.PhatSinh.Trim() == "1")
                    row["PhatSinh"] = "Không";
                if (item.NghiepVu.Trim() == "0")
                    row["NghiepVu"] = "Thông quan";
                else if (item.NghiepVu.Trim() == "1")
                    row["NghiepVu"] = "Đổi lệnh dưới kho";
                else if (item.NghiepVu.Trim() == "2")
                    row["NghiepVu"] = "Rút ruột";
                else if (item.NghiepVu.Trim() == "3")
                    row["NghiepVu"] = "Thông quan kèm kiểm dịch/KTC";
                else if (item.NghiepVu.Trim() == "4")
                    row["NghiepVu"] = "Không có trucking";

                if (item.LoaiToKhai.Trim() == "0")
                    row["LoaiToKhai"] = "Luồng xanh";
                else if (item.LoaiToKhai.Trim() == "1")
                    row["LoaiToKhai"] = "Luồng vàng";
                else if (item.LoaiToKhai.Trim() == "2")
                    row["LoaiToKhai"] = "Luồng đỏ";
                row["SoLuongToKhai"] = item.SoLuongToKhai;
                if (item.LoaiHang.Trim() == "HangLe")
                    row["LoaiHang"] = "Hàng Lẻ";
                else if (item.LoaiHang.Trim() == "HangCont")
                    row["LoaiHang"] = "Hàng Cont";
                if (item.TinhChat.Trim() == "HangNhap")
                    row["TinhChat"] = "Hàng nhập";
                else if (item.TinhChat.Trim() == "HangXuat")
                    row["TinhChat"] = "Hàng xuất";
                //
                string _Ten = "";
                var t_NguoiGiaoNhan = (from a in context.ThongTinFile_NguoiGiaoNhan
                                       join b in context.NhanViens on a.MaNhanVien equals b.MaNhanVien
                                       select new { a.SoFile, b.TenNhanVien }).Where(p => p.SoFile == item.SoFile);
                foreach (var item1 in t_NguoiGiaoNhan)
                {
                    _Ten += item1.TenNhanVien + ",";
                }
                if (_Ten.Trim().Length > 0)
                    _Ten = _Ten.Substring(0, _Ten.Length - 1);
                row["TenGiaoNhan"] = _Ten;
                //
                row["TenSales"] = item.TenSales;
                row["IDLoHang"] = item.IDLoHang;
                row["SoBill"] = item.SoBill;
                row["SoFile"] = item.SoFile;
                row["SoToKhai"] = item.SoToKhai;
                row["SoLuong"] = item.SoLuong;
                row["SoCont"] = item.SoCont;
                //update 28.09
                double TongDuyetUng = 0;
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == item.SoFile);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
                row["DuyetUng"] = TongDuyetUng;
                // row["DuyetUng"] = item.DuyetUng.Value;
                row["TenKhachHang"] = item.TenKhachHang;
                row["IDGia"] = item.IDGia;
                dt.Rows.Add(row);
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable ChiTietNoiDungTaoDebit(int IDGia)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("SoTien", typeof(double));
            dt1.Columns.Add("VAT", typeof(double));
            dt1.Columns.Add("ThanhTienVAT", typeof(double));
            dt1.Columns.Add("ThanhTien", typeof(double));
            dt1.Columns.Add("LaPhiChiHo", typeof(bool));
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("SoHoaDon");
            dt1.TableName = "xem";
         
            var t1 = context.FileGiaChiTiets.Where(p => p.IDGia == IDGia);
            foreach (var item in t1)
            {
                DataRow row1 = dt1.NewRow();
                row1["LaPhiChiHo"] = false;
                row1["SoHoaDon"] = "";
                row1["TenDichVu"] = item.TenDichVu;
                row1["SoTien"] = item.GiaBan.Value;
                dt1.Rows.Add(row1);
            }
            var t2 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.FileGias on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhMuc_PhiChiHo on a.MaChiHo equals c.MaChiHo
                      select new { 
                          b.IDGia,
                          c.TenChiHo,
                          a.SoTien_ChiHo,
                          a.MaChiHo
                      
                      }).Where(p=>p.IDGia==IDGia&&p.MaChiHo!=null);

            foreach (var item in t2)
            {
                DataRow row1 = dt1.NewRow();

                row1["SoHoaDon"] = "";
                row1["LaPhiChiHo"] = true;
                row1["TenDichVu"] = item.TenChiHo;
                row1["SoTien"] = item.SoTien_ChiHo.Value;
                if(!item.TenChiHo.ToLower().Contains("cược"))
                 dt1.Rows.Add(row1);
            }
            //chi phi nang ha
            var t3 = (from a in context.BangPhoiNangHa_ChiTiet
                     // join d in context.BangPhoiNangHas on a.IDLoHang equals d.IDLoHang
                      join b in context.FileGias on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhMuc_PhiChiHo on a.MaChiHo equals c.MaChiHo
                      select new
                      {
                          b.IDGia,
                          c.TenChiHo,
                          a.SoTien_ChiHo,
                          a.MaChiHo

                      }).Where(p => p.IDGia == IDGia && p.MaChiHo != null);
            foreach (var item in t3)
            {
                DataRow row1 = dt1.NewRow();

                row1["SoHoaDon"] = "";
                row1["LaPhiChiHo"] = true;
                row1["TenDichVu"] = item.TenChiHo;
                row1["SoTien"] = item.SoTien_ChiHo.Value;
                if (!item.TenChiHo.ToLower().Contains("cược"))
                    dt1.Rows.Add(row1);
            }
            return dt1;
        }
        [WebMethod]
        public DataTable ChiTietNoiDungTaoDebit_BoSung(int IDGia,int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("SoTien", typeof(double));
            dt1.Columns.Add("VAT", typeof(double));
            dt1.Columns.Add("ThanhTienVAT", typeof(double));
            dt1.Columns.Add("ThanhTien", typeof(double));
            dt1.Columns.Add("LaPhiChiHo", typeof(bool));
            dt1.Columns.Add("SoHoaDon");
            dt1.Columns.Add("GhiChu");
            dt1.TableName = "xem";

            var t1 = context.FileGiaChiTiets.Where(p => p.IDGia == IDGia);
            foreach (var item in t1)
            {
                DataRow row1 = dt1.NewRow();
                row1["SoHoaDon"] = "";
                row1["LaPhiChiHo"] = false;
                row1["TenDichVu"] = item.TenDichVu;
                row1["SoTien"] = item.GiaBan.Value;
                dt1.Rows.Add(row1);
            }
            var t2 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.FileGias on a.IDLoHang equals b.IDLoHang
                      join c in context.DanhMuc_PhiChiHo on a.MaChiHo equals c.MaChiHo
                      select new
                      {
                          b.IDGia,
                          c.TenChiHo,
                          a.SoTien_ChiHo,
                          a.MaChiHo,
                          a.IDCP

                      }).Where(p => p.IDGia == IDGia && p.MaChiHo != null&&p.IDCP==IDCP);

            foreach (var item in t2)
            {
                DataRow row1 = dt1.NewRow();
                row1["SoHoaDon"] = "";
                row1["LaPhiChiHo"] = false;
                row1["TenDichVu"] = item.TenChiHo;
                row1["SoTien"] = item.SoTien_ChiHo.Value;
                if (!item.TenChiHo.ToLower().Contains("cược"))
                    dt1.Rows.Add(row1);
            }
           
            return dt1;
        }
        [WebMethod]
        public DataTable ChiTietNoiDungTaoDebit_Sua(int IDDebit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt1 = new DataTable("table");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("SoTien", typeof(double));
            dt1.Columns.Add("VAT", typeof(double));
            dt1.Columns.Add("ThanhTienVAT", typeof(double));
            dt1.Columns.Add("ThanhTien", typeof(double));
            dt1.Columns.Add("LaPhiChiHo", typeof(bool));
            dt1.Columns.Add("SoHoaDon");
            dt1.Columns.Add("GhiChu");
            dt1.TableName = "xem";

            var t1 = context.FileDebitChiTiets.Where(p => p.IDDeBit == IDDebit);
            foreach (var item in t1)
            {
                DataRow row1 = dt1.NewRow();
                row1["TenDichVu"] = item.TenDichVu;
                row1["SoTien"] = item.SoTien.Value;
                row1["VAT"] = item.VAT.Value;
                row1["SoHoaDon"] = item.SoHoaDon;
                if (item.VAT.Value == -1)
                    row1["ThanhTienVAT"] = 0;
                else
                    row1["ThanhTienVAT"] = double.Parse("0" + item.SoTien.Value.ToString()) * double.Parse(item.VAT.Value.ToString()) / 100;
                row1["ThanhTien"] = item.ThanhTien.Value;
                row1["GhiChu"] = item.GhiChu;
                row1["LaPhiChiHo"] = item.LaPhiChiHo.Value;
                dt1.Rows.Add(row1);
            }
           
            return dt1;
        }
        [WebMethod]
        public void LuuFileDebit(FileDebit p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.FileDebits.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public int Top1FileDebit()
        {
            int IDDeBit = 0;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.FileDebits.OrderByDescending(p => p.IDDeBit).Take(1);
            foreach (var item in t)
            {
                IDDeBit = item.IDDeBit;
            }
            return IDDeBit;
        }
        [WebMethod]
        public void LuuFileDebitChiTiet(FileDebitChiTiet p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.FileDebitChiTiets.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void XoaFileDebit(int _IDDebit)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
           
            FileDebit table = context.FileDebits.Single(p => p.IDDeBit == _IDDebit);
            context.FileDebits.Remove(table);
            context.SaveChanges();
            var t2 = context.FileDebitChiTiets.Where(p => p.IDDeBit == _IDDebit);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item in t2)
                {
                    FileDebitChiTiet table2 = context1.FileDebitChiTiets.Single(p => p.IDDeBitCT == item.IDDeBitCT);
                    context1.FileDebitChiTiets.Remove(table2);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public List<DanhMucThu> DanhsachThu()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucThus.ToList();
        }
        [WebMethod]
        public List<DanhMucThu> DanhsachThu_001()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucThus.Where(p=>p.MaThu!="001").ToList();
        }
        [WebMethod]
        public List<DanhMucThu> DanhsachThu_TheoMa(string Ma)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucThus.Where(p=>p.MaThu==Ma).ToList();
        }
        [WebMethod]
        public List<DanhMucThu> DanhsachThu_TheoMaID(string Ma,int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucThus.Where(p => p.MaThu == Ma&&p.IDThu!=ID).ToList();
        }
        [WebMethod]
        public void DanhSachThu_Them(DanhMucThu p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DanhMucThus.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachThu_Sua(DanhMucThu a)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhMucThus.Single(p=>p.IDThu==a.IDThu);
            table.MaThu = a.MaThu;
            table.TenThu = a.TenThu;
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachThu_Xoa(DanhMucThu a)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhMucThu table = context.DanhMucThus.Single(p => p.IDThu == a.IDThu);
            context.DanhMucThus.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = from a in context.DanhSachChis
                        join b in context.DanhSachChis on a.MaCha equals b.MaChi
                        select new { a.IDChi,a.MaChi,a.TenChi,TenCha=b.TenChi,a.MaCha};
            return context.DanhSachChis.ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_001()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p=>p.MaChi!="001").ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_004()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p => p.MaChi == "004").ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_001_004_Con()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p => p.MaChi != "001"&&p.MaChi!="004"&& p.MaChi != "009" && p.MaChi != "010" && p.MaChi != "011" && p.MaChi != "012" && p.MaChi != "013").ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_Cha()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p => p.MaCha == null).ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_001_Con(string MaCha)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p => p.MaCha == MaCha).ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_TheoMa(string Ma)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p => p.MaChi == Ma).ToList();
        }
        [WebMethod]
        public List<DanhSachChi> DanhsachChi_TheoMaID(string Ma, int ID)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhSachChis.Where(p => p.MaChi == Ma && p.IDChi != ID).ToList();
        }
        [WebMethod]
        public void DanhSachChi_Them(DanhSachChi p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DanhSachChis.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachChi_Sua(DanhSachChi a)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.DanhSachChis.Single(p => p.IDChi == a.IDChi);
            table.MaChi = a.MaChi;
            table.TenChi = a.TenChi;
            table.MaCha = a.MaCha;
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachChi_Xoa(DanhSachChi a)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhSachChi table = context.DanhSachChis.Single(p => p.IDChi == a.IDChi);
            context.DanhSachChis.Remove(table);
            context.SaveChanges();
        }
        //nhan vien
        [WebMethod]
        public bool NhanVien_KTra_luu(NhanVien p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.NhanViens.Where(b=>b.MaNhanVien==p.MaNhanVien);
            if (table.Count() > 0)
                return true;
            else
                return false;
        }
        [WebMethod]
        public bool NhanVien_KTra_sua(NhanVien p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.NhanViens.Where(b => b.MaNhanVien == p.MaNhanVien&&b.ID!=p.ID);
            if (table.Count() > 0)
                return true;
            else
                return false;
        }
        [WebMethod]
        public void NhanVien_Them(NhanVien p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.NhanViens.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void NhanVien_Sua(NhanVien p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.NhanViens.Single(a=>a.ID==p.ID);
            table.TenNhanVien = p.TenNhanVien;
            table.DiaChi = p.DiaChi;
            table.DienThoai = p.DienThoai;
            table.CCCD = p.CCCD;
            table.GPLX = p.GPLX;
            table.MaPhongBan = p.MaPhongBan;
            table.BienSoXe = p.BienSoXe;
            context.SaveChanges();
        }
        [WebMethod]
        public void NhanVien_LuongCDinh(NhanVien p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.NhanViens.Single(a => a.ID == p.ID);
            table.LuongCoDinh = p.LuongCoDinh;
            table.MaPhongBan = p.MaPhongBan;
            context.SaveChanges();
        }
        [WebMethod]
        public double TongTienLaiXe(int thang,int nam,string TaiKhoan,double LuongCoDinh)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double TongTienHang = 0, SoNgayNghi = 0,TruLuong=0, ThucNhan = 0;
            var table = context.BangDieuXes.Where(p=>p.LaiXe==TaiKhoan&&p.Ngay.Value.Year==nam&&p.Ngay.Value.Month==thang);
            foreach (var item in table)
            {
                if (item.DiemTraHang != null)
                    TongTienHang += item.DiemTraHang.Value;
                if (item.TienAn != null)
                    TongTienHang += item.TienAn.Value;
                if (item.TienVe != null)
                    TongTienHang += item.TienVe.Value;
                if (item.QuaDem != null)
                    TongTienHang += item.QuaDem.Value;
                if (item.TienLuat != null)
                    TongTienHang += item.TienLuat.Value;
                if (item.LuongHangVe != null)
                    TongTienHang+=item.LuongHangVe.Value;
                
            }
            var table11 = context.BangPhiDiDuong_ChiKhac.Where(p => p.TaiKhoan == TaiKhoan && p.Ngay.Value.Year == nam && p.Ngay.Value.Month == thang);
            foreach (var item1 in table11)
            {
                if (item1.SoTienChi != null)
                    TongTienHang += item1.SoTienChi.Value;
            }
            var table2 = context.BangTheoDoiNghiPhepNams.Where(p=>p.NguoiTao==TaiKhoan&&p.NgayBatDau.Value.Year==nam&&p.NgayBatDau.Value.Month==thang&&p.NgayKetThuc.Value.Year==nam&&p.NgayKetThuc.Value.Month==thang);
            double SoNgayFull = 0, SoNgayLe = 0;
            foreach (var item in table2)
            {
                if (item.CaNgay.Value)
                    SoNgayFull++;
                else
                    SoNgayLe++;
            }
            int so = DateTime.DaysInMonth(nam, thang);
            double Luong1Ngay = LuongCoDinh / so;
            double SoNgay = SoNgayFull + (SoNgayLe / 2);
            if(SoNgay!=0)
               TruLuong = Luong1Ngay* SoNgay;
            ThucNhan = LuongCoDinh - TruLuong;
            return TongTienHang + ThucNhan;
        }
        [WebMethod]
        public double TongTienVP(int thang, int nam, string TaiKhoan, double LuongCoDinh)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double TongTienHang = 0, SoNgayNghi = 0, TruLuong = 0, ThucNhan = 0;
          
            var table2 = context.BangTheoDoiNghiPhepNams.Where(p => p.NguoiTao == TaiKhoan && p.NgayBatDau.Value.Year == nam && p.NgayBatDau.Value.Month == thang && p.NgayKetThuc.Value.Year == nam && p.NgayKetThuc.Value.Month == thang);
            double SoNgayFull = 0, SoNgayLe = 0;
            foreach (var item in table2)
            {
                if (item.CaNgay.Value)
                    SoNgayFull++;
                else
                    SoNgayLe++;
            }
            double SoNgay = SoNgayFull + (SoNgayLe / 2);
            int so = DateTime.DaysInMonth(nam, thang);
            double Luong1Ngay = LuongCoDinh / so;
            if (SoNgay != 0)
                TruLuong = Luong1Ngay* SoNgay;
            ThucNhan = LuongCoDinh - TruLuong;
            return TongTienHang + ThucNhan;
        }
        [WebMethod]
        public DataTable Luong_VP_TongHop(int thang, int nam)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("luong");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenNhanVien");
            dt.Columns.Add("TongLuong", typeof(double));
            dt.Columns.Add("TraLuong", typeof(double));

            dt.TableName = "luong";
            var table = context.NhanViens.Where(p => p.MaPhongBan == "VP");
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["MaNhanVien"] = item.MaNhanVien;
                row["TenNhanVien"] = item.TenNhanVien;
                double LuongCoDinh = item.LuongCoDinh.Value;
                //chỉ 1 nhân viên gắn cho 1 tài khoản theo quan hệ 1-1
                var table1 = context.DanhSachTaiKhoans.Where(p => p.MaNhanVien == item.MaNhanVien).Take(1);
                foreach (var item1 in table1)
                {
                    row["TaiKhoan"] = item1.TaiKhoan;
                    row["TongLuong"] = TongTienVP(thang, nam, item1.TaiKhoan, LuongCoDinh);
                    //tra luong
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        [WebMethod]
        public DataTable Luong_LaiXe_TongHop(int thang,int nam)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("luong");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenNhanVien");
            dt.Columns.Add("BienSoXe");
            dt.Columns.Add("TongLuong", typeof(double));
            dt.Columns.Add("TraLuong", typeof(double));
           
            dt.TableName = "luong";
            var table = context.NhanViens.Where(p=>p.MaPhongBan== "LXE");
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["MaNhanVien"] = item.MaNhanVien;
                row["TenNhanVien"] = item.TenNhanVien;
                row["BienSoXe"] = item.BienSoXe;
                double LuongCoDinh =(item.LuongCoDinh==null)?0: item.LuongCoDinh.Value;
                //chỉ 1 nhân viên gắn cho 1 tài khoản theo quan hệ 1-1
                var table1 = context.DanhSachTaiKhoans.Where(p=>p.MaNhanVien==item.MaNhanVien).Take(1);
                foreach (var item1 in table1)
                {
                    row["TaiKhoan"] = item1.TaiKhoan;
                    row["TongLuong"] = TongTienLaiXe(thang, nam, item1.TaiKhoan, LuongCoDinh);
                    //tra luong
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        [WebMethod]
        public DataTable LuongLaiXe_Chitiet(string TaiKhoan,int thang,int nam)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("luong");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("DiemTraHang", typeof(double));
            dt.Columns.Add("TienAn", typeof(double));
            dt.Columns.Add("TienVe", typeof(double));
            dt.Columns.Add("QuaDem", typeof(double));
            dt.Columns.Add("TienLuat", typeof(double));
            dt.Columns.Add("LuongHangVe", typeof(double));
            dt.Columns.Add("ChiKhac", typeof(double));
            dt.Columns.Add("TongCong", typeof(double));
          
            var table = context.BangDieuXes.Where(p => p.LaiXe == TaiKhoan && p.Ngay.Value.Year == nam && p.Ngay.Value.Month == thang);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["Ngay"] = item.Ngay;
                row["TuyenVC"] = item.TuyenVC;
                row["DiemTraHang"] = (item.DiemTraHang==null)?0: item.DiemTraHang.Value;
                row["TienAn"] = (item.TienAn==null)?0:item.TienAn.Value;
                row["TienVe"] = (item.TienVe==null)?0:item.TienVe.Value;
                row["QuaDem"] = (item.QuaDem==null)?0:item.QuaDem.Value;
                row["TienLuat"] =(item.TienLuat==null)?0: item.TienLuat.Value;
                row["LuongHangVe"] =(item.LuongHangVe==null)?0: item.LuongHangVe.Value;
                var table1 = (from a in context.BangPhiDiDuong_ChiKhac
                              join b in context.BangPhiDiDuongs on a.IDBangPhi equals b.IDBangPhi
                              select new { a.TaiKhoan, a.SoTienChi, b.MaDieuXe,a.Ngay }).Where(p=>p.TaiKhoan==TaiKhoan&&p.MaDieuXe==item.MaDieuXe&&p.Ngay.Value.Month==thang&&p.Ngay.Value.Year==nam);
                double ChiKhac = 0;
                foreach (var item1 in table1)
                {
                    ChiKhac += item1.SoTienChi.Value;
                }
                row["ChiKhac"] = ChiKhac;
                row["TongCong"] =double.Parse(row["DiemTraHang"].ToString())+ double.Parse(row["TienAn"].ToString()) + double.Parse(row["TienVe"].ToString())+ double.Parse(row["QuaDem"].ToString())+
                                  double.Parse(row["TienLuat"].ToString()) + double.Parse(row["LuongHangVe"].ToString())+ ChiKhac;
                dt.Rows.Add(row);
            }
            dt.TableName = "luong";
            return dt;
        }
        [WebMethod]
        public void ThemPhuCap_Nhanvien(NhanVien_PhuCap p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            NhanVien_PhuCap table = new NhanVien_PhuCap();
            table.MaNhanVien = p.MaNhanVien;
            table.Nam = p.Nam;
            table.Thang = p.Thang;
            table.TienPhuCap = p.TienPhuCap;
            table.TenNhanVien = p.TenNhanVien;
            table.TenPhuCap = p.TenPhuCap;
            context.NhanVien_PhuCap.Add(table);
            context.SaveChanges();
        }
        [WebMethod]
        public void XoaPhuCap_NhanVien(NhanVien_PhuCap p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            NhanVien_PhuCap table = context.NhanVien_PhuCap.Single(b=>b.IDLuong==p.IDLuong);
            context.NhanVien_PhuCap.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable ChiTietLuong_VP(string TaiKhoan, string ManhanVien, int thang, int nam)
        {
            DataTable dt = new DataTable("luong");
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenNhanVien");
            dt.Columns.Add("LuongCoDinh",typeof(double));
            dt.Columns.Add("SoNgayNghi", typeof(double));
            dt.Columns.Add("LuongThucTe", typeof(double));
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.NhanViens.Where(p=>p.MaNhanVien==ManhanVien);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["MaNhanVien"] = item.MaNhanVien;
                row["TenNhanVien"] = item.TenNhanVien;
                row["LuongCoDinh"] = item.LuongCoDinh.Value;
                //
                var table2 = context.BangTheoDoiNghiPhepNams.Where(p => p.NguoiTao == TaiKhoan && p.NgayBatDau.Value.Year == nam && p.NgayBatDau.Value.Month == thang && p.NgayKetThuc.Value.Year == nam && p.NgayKetThuc.Value.Month == thang);
                double SoNgayFull = 0, SoNgayLe = 0;
                foreach (var item1 in table2)
                {
                    if (item1.CaNgay.Value)
                        SoNgayFull++;
                    else
                        SoNgayLe++;
                }
                int so = DateTime.DaysInMonth(nam, thang);
              
                double SoNgay = SoNgayFull + (SoNgayLe / 2);
                double TruLuong = 0, ThucNhan = 0, LuongCoDinh = 0;
                LuongCoDinh =(item.LuongCoDinh==null)?0: item.LuongCoDinh.Value;
                double Luong1Ngay = LuongCoDinh / so;
                if (SoNgay != 0)
                    TruLuong = Luong1Ngay* SoNgay;
                ThucNhan = LuongCoDinh - TruLuong;
                row["SoNgayNghi"] = SoNgay;
                row["LuongThucTe"] = ThucNhan;
                dt.Rows.Add(row);
            }
            dt.TableName = "luong";
            return dt;
        }
        [WebMethod]
        public DataTable LuongLaiXe_CacKhoanTinhLuong(string TaiKhoan,string ManhanVien, int thang, int nam)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("luong");
            dt.Columns.Add("NoiDung");
            dt.Columns.Add("SoTien", typeof(double));
            double LuongCung = 0, TruLuong = 0, ThucNhan = 0, SoNgay = 0;
            double DiemTraHang = 0, TienAn = 0, TienVe = 0, LuongHangVe = 0, TienLuat = 0, QuaDem = 0, ChiKhac = 0;
            var table1 = context.BangDieuXes.Where(p => p.LaiXe == TaiKhoan && p.Ngay.Value.Year == nam && p.Ngay.Value.Month == thang);
            foreach (var item in table1)
            {
                if(item.DiemTraHang!=null)
                   DiemTraHang += item.DiemTraHang.Value;
                if (item.TienAn != null)
                    TienAn += item.TienAn.Value;
                if (item.TienVe != null)
                    TienVe += item.TienVe.Value;
                if (item.LuongHangVe != null)
                    LuongHangVe += item.LuongHangVe.Value;
                if (item.TienLuat != null)
                    TienLuat += item.TienLuat.Value;
                if (item.QuaDem != null)
                    QuaDem += item.QuaDem.Value;
               
            }
            var table22 = context.BangPhiDiDuong_ChiKhac.Where(p => p.TaiKhoan == TaiKhoan && p.Ngay.Value.Year == nam && p.Ngay.Value.Month == thang);
            foreach (var item1 in table22)
            {
                ChiKhac += item1.SoTienChi.Value;
            }
            double TongLuong = 0;
            for (int i = 1; i <= 11; i++)
            {
               
                switch (i)
                {
                    case 1:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Lương cứng";
                            var table = context.NhanViens.Where(p => p.MaNhanVien == ManhanVien);
                            foreach (var item in table)
                            {
                                row["SoTien"] = item.LuongCoDinh.Value;
                                if(item.LuongCoDinh!=null)
                                  LuongCung = item.LuongCoDinh.Value;
                               
                            }
                            dt.Rows.Add(row);
                            break;
                        }
                    case 2:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Số ngày nghỉ";
                            var table2 = context.BangTheoDoiNghiPhepNams.Where(p => p.NguoiTao == TaiKhoan && p.NgayBatDau.Value.Year == nam && p.NgayBatDau.Value.Month == thang && p.NgayKetThuc.Value.Year == nam && p.NgayKetThuc.Value.Month == thang);
                            double SoNgayFull = 0, SoNgayLe = 0;
                            foreach (var item in table2)
                            {
                                if (item.CaNgay.Value)
                                    SoNgayFull++;
                                else
                                    SoNgayLe++;
                            }
                             SoNgay = SoNgayFull + (SoNgayLe / 2);
                            row["SoTien"] = SoNgay;
                            dt.Rows.Add(row);
                            break;
                        }
                    case 3:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Lương thực tế";
                            if(SoNgay>0)
                            {
                                int so = DateTime.DaysInMonth(nam, thang);
                                double Luong1Ngay = LuongCung / so;
                                TruLuong = Luong1Ngay* SoNgay;
                            }    
                             
                            ThucNhan = LuongCung - TruLuong;
                            row["SoTien"] = ThucNhan;
                            dt.Rows.Add(row);
                            TongLuong += ThucNhan;
                            break;
                        }
                    case 4:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Điểm trả hàng";
                            row["SoTien"] = DiemTraHang;
                            dt.Rows.Add(row);
                            TongLuong += DiemTraHang;
                            break;
                        }
                    case 5:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Tiền ăn";
                            row["SoTien"] = TienAn;
                            TongLuong += TienAn;
                            dt.Rows.Add(row);
                            break;
                        }
                    case 6:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Tiền vé";
                            row["SoTien"] = TienVe;
                            TongLuong += TienVe;
                            dt.Rows.Add(row);
                            break;
                        }
                    case 7:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Qua đêm";
                            row["SoTien"] = QuaDem;
                            TongLuong += QuaDem;
                            dt.Rows.Add(row);
                            break;
                        }
                    case 8:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Tiền luật";
                            row["SoTien"] = TienLuat;
                            TongLuong += TienLuat;
                            dt.Rows.Add(row);
                            break;
                        }
                    case 9:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Lương hàng về";
                            row["SoTien"] = LuongHangVe;
                            TongLuong += LuongHangVe;
                            dt.Rows.Add(row);
                            break;
                        }
                    case 10:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Chi khác";
                            row["SoTien"] = ChiKhac;
                            dt.Rows.Add(row);
                            TongLuong += ChiKhac;
                            break;
                        }
                    case 11:
                        {
                            DataRow row = dt.NewRow();
                            row["NoiDung"] = "Tổng lương";
                            row["SoTien"] = TongLuong;
                            dt.Rows.Add(row);
                            break;
                        }
                    default:
                        break;
                }
            }
            dt.TableName = "luong";
            return dt;
        }
        [WebMethod]
        public void NhanVien_Xo(NhanVien p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            NhanVien table = context.NhanViens.Single(a => a.ID == p.ID);
            context.NhanViens.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public List<NhanVien_PhuCap>NhanVien_PhuCap_TheoMaNhanVien(string MaNhanVien,int thang,int nam)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.NhanVien_PhuCap.Where(p=>p.MaNhanVien==p.MaNhanVien&&p.Thang==thang&&p.Nam==nam);
            return table.ToList();
        }
        [WebMethod]
        public List<DanhMucNganHang>DanhMucNganHang_Load()
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucNganHangs.ToList();
        }
        [WebMethod]
        public List<DanhMucNganHang> DanhMucNganHang_Load_ThéoTK(DanhMucNganHang p)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucNganHangs.Where(a=>a.SoTK==p.SoTK).ToList();
        }
        [WebMethod]
        public List<DanhMucNganHang> DanhMucNganHang_Load_ThéoTKID(DanhMucNganHang p)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucNganHangs.Where(a => a.SoTK == p.SoTK&&a.IDNganHang!=p.IDNganHang).ToList();
        }
        [WebMethod]
        public void DanhMucNganHang_Them(DanhMucNganHang p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DanhMucNganHangs.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhMucNganHang_Sua(DanhMucNganHang p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.DanhMucNganHangs.Single(a=>a.IDNganHang==p.IDNganHang);
            t.ChiNhanh = p.ChiNhanh;
            t.ChuTaiKhoan = p.ChuTaiKhoan;
            t.SoTK = p.SoTK;
            t.TenNganHang = p.TenNganHang;
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhMucNganHang_Xoa(DanhMucNganHang p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhMucNganHang t = context.DanhMucNganHangs.Single(a => a.IDNganHang == p.IDNganHang);
            context.DanhMucNganHangs.Remove(t);
            context.SaveChanges();
        }
        //quy
        [WebMethod]
        public List<DanhMucQuy> DanhMucQuy_Load()
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucQuys.ToList();
        }
        [WebMethod]
        public List<DanhMucQuy> DanhMucQuy_Load_ThéoMaQuy(DanhMucQuy p)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucQuys.Where(a => a.MaQuy == p.MaQuy).ToList();
        }
        [WebMethod]
        public List<DanhMucQuy> DanhMucQuy_Load_ThéoMaQuyID(DanhMucQuy p)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.DanhMucQuys.Where(a => a.MaQuy == p.MaQuy && a.IDQuy != p.IDQuy).ToList();
        }
        [WebMethod]
        public void DanhMucQuy_Them(DanhMucQuy p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DanhMucQuys.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhMucQuy_Sua(DanhMucQuy p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.DanhMucQuys.Single(a => a.IDQuy == p.IDQuy);
            t.MaQuy = p.MaQuy;
            t.TenQuy = p.TenQuy;
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhMucQuy_Xoa(DanhMucQuy p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DanhMucQuy t = context.DanhMucQuys.Single(a => a.IDQuy == p.IDQuy);
            context.DanhMucQuys.Remove(t);
            context.SaveChanges();
        }
        //phieu chi
        [WebMethod]
        public DataTable DanhSachPhieuChi_TheoNgay(DateTime TuNgay,DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as TenDoiTuong,";
            sql +="(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as TongTien from PhieuChi where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_Con_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_Con_CT where SoChungTu=PhieuChi_Con.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_Con_CT where SoChungTu=PhieuChi_Con.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_Con_CT where SoChungTu=PhieuChi_Con.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_Con.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_Con_CT where SoChungTu=PhieuChi_Con.SoChungTu)as TongTien from PhieuChi_Con where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_NoiBo_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_NoiBo_CT where SoChungTu=PhieuChi_NoiBo.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_NoiBo_CT where SoChungTu=PhieuChi_NoiBo.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_NoiBo_CT where SoChungTu=PhieuChi_NoiBo.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_NoiBo.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_NoiBo_CT where SoChungTu=PhieuChi_NoiBo.SoChungTu)as TongTien from PhieuChi_NoiBo where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        //phieu chi tam ung lai xe
        [WebMethod]
        public DataTable DanhSachPhieuChiTamUngLaiXe_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_LaiXe_CT where SoChungTu=PhieuChi_LaiXe.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_LaiXe_CT where SoChungTu=PhieuChi_LaiXe.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_LaiXe_CT where SoChungTu=PhieuChi_LaiXe.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_LaiXe.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_LaiXe_CT where SoChungTu=PhieuChi_LaiXe.SoChungTu)as TongTien from PhieuChi_LaiXe where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi.MaQuy)as TenQuy from PhieuChi where SoChungTu in(select SoChungTu from PhieuChi_CT where SoFile like '%"+SoFile+"%')";
            int ts = 2;
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_Con_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_Con.MaQuy)as TenQuy from PhieuChi_Con where SoChungTu in(select SoChungTu from PhieuChi_Con_CT where SoFile like '%" + SoFile + "%')";
            int ts = 2;
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChiTamUngLaiXe_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_LaiXe.MaQuy)as TenQuy from PhieuChi_LaiXe where SoChungTu in(select SoChungTu from PhieuChi_LaiXe_CT where SoFile like '%" + SoFile + "%')";
            int ts = 2;
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select dbo.fn_TienDichVu(A.IDCP) as SoTien_DichVu,dbo.fn_TienChiHo(A.IDCP)as SoTien_ChiHo, A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_CT A left join PhieuChi B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_Con_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select  ((A.VAT*A.SoTien)/100) as TienVAT,A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_Con_CT A left join PhieuChi_Con B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_NoiBo_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select  A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_NoiBo_CT A left join PhieuChi_NoiBo B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChiTamUngLaiXe_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select  A.*,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_LaiXe_CT A left join PhieuChi_LaiXe B on A.SoChungTu=B.SoChungTu
                   left join DanhSachTaiKhoan C on C.TaiKhoan = A.MaDoiTuong and DoiTuong = 'NV'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_NCC_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_NCC.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as TongTien from PhieuChi_NCC where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_NCC_TheoSoFile(string Sofile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi_NCC.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_NCC_CT where SoChungTu=PhieuChi_NCC.SoChungTu)as TongTien from PhieuChi_NCC where PhieuChi_NCC_CT.SoFILE='" + Sofile+"'";
          
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_NCC_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select (select ThanhTien from PhieuChi_NCC_CT where IDCTNCC=A.IDCTNCC and LaVanChuyen=1) as SoTien_VanChuyen,(select ThanhTien from PhieuChi_NCC_CT where IDCTNCC=A.IDCTNCC and LaVanChuyen=0)as SoTien_NangHa,B.LyDoChi, A.*,C.TenNhaCungCap,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_NCC_CT A left join PhieuChi_NCC B on A.SoChungTu=B.SoChungTu
                    left join DanhSachNhaCungCap C on C.MaNhaCungCap = A.MaDoiTuong and DoiTuong = 'NCC'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoFile='" + SoFile + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_NCC_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select (select ThanhTien from PhieuChi_NCC_CT where IDCTNCC=A.IDCTNCC and LaVanChuyen=1) as SoTien_VanChuyen,(select ThanhTien from PhieuChi_NCC_CT where IDCTNCC=A.IDCTNCC and LaVanChuyen=0)as SoTien_NangHa,B.LyDoChi, A.*,C.TenNhaCungCap,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_NCC_CT A left join PhieuChi_NCC B on A.SoChungTu=B.SoChungTu
                    left join DanhSachNhaCungCap C on C.MaNhaCungCap = A.MaDoiTuong and DoiTuong = 'NCC'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
        
            string sql = @"select dbo.fn_TienDichVu(A.IDCP) as SoTien_DichVu,dbo.fn_TienChiHo(A.IDCP)as SoTien_ChiHo, A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_CT A left join PhieuChi B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.Sofile like'%" + SoFile + "%'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public bool KiemTraPhieuThuTheo_IDCP(int IDCP)
        {
            bool isCheck = false;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuThu_CT.Where(p=>p.IDCP== IDCP);
            if (table.Count()>0)
                return true;
            else
                return false;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChi_Con_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();

            string sql = @"select  A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_Con_CT A left join PhieuChi_Con B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.Sofile like'%" + SoFile + "%'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuChiTamUngLaiXe_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();

            string sql = @"select  A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuChi_LaiXe_CT A left join PhieuChi_LaiXe B on A.SoChungTu=B.SoChungTu
                    left join DanhSachTaiKhoan C on C.TaiKhoan = A.MaDoiTuong and DoiTuong = 'NV'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.Sofile like'%" + SoFile + "%'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public List<PhieuChi_CT> DanhSachPhieuChi_CT_TheoIDPhieuChi(int IDPhieuChi)
        {
          
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChi_CT.Where(p=>p.IDPhieuChi==IDPhieuChi);
            return table.ToList();
        }
        [WebMethod]/*bo đi 02/01/2025*/
        public List<PhieuChi_Con_CT> DanhSachPhieuChi_Con_CT_TheoIDPhieuChi(int IDPhieuChi)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChi_Con_CT.Where(p => p.IDPhieuChi == IDPhieuChi);
            return table.ToList();
        }
       
        [WebMethod]
        public List<PhieuChi_NoiBo_CT> DanhSachPhieuChi_NoiBo_CT_TheoIDPhieuChi(int IDPhieuChi)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChi_NoiBo_CT.Where(p => p.IDPhieuChi == IDPhieuChi);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuChi_LaiXe_CT> DanhSachPhieuChiTamUngLaiXe_CT_TheoIDPhieuChi(int IDPhieuChi)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChi_LaiXe_CT.Where(p => p.IDPhieuChi == IDPhieuChi);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuThu_CT> DanhSachPhieuThu_CT_TheoIDPhieuThu(int IDPhieuThu)
        {

            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuThu_CT.Where(p => p.IDPhieuThu == IDPhieuThu);
            return table.ToList();
        }
        [WebMethod]
        public void DanhSachPhieuChi_Them(PhieuChi p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuChis.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChi_Con_Them(PhieuChi_Con p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuChi_Con.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChiNoiBo_Them(PhieuChi_NoiBo p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuChi_NoiBo.Add(p);
            context.SaveChanges();
        }

        [WebMethod]
        public void DanhSachPhieuChiTamUngLaiXe_Them(PhieuChi_LaiXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuChi_LaiXe.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThu_Them(PhieuThu p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuThus.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThu_NoiBo_Them(PhieuThu_NoiBo p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuThu_NoiBo.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThuGiaoNhan_Them(PhieuThu_GiaoNhan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuThu_GiaoNhan.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThuLaiXe_Them(PhieuThu_LaiXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuThu_LaiXe.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChi_NCC_Them(string[]value)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "insert into PhieuChi_NCC(SoChungTu,NgayHachToan,MaChi,LydoChi,DienGiai,SoHoaDon,NguoiTao,ThoiGianTao,NguoiNhan,MaQuy,HinhThucTT,SoTK,TenNganHang,ChiNhanh,ChuTaiKhoan)values(";
            for (int i = 0; i <14; i++)
            {
                sql += "N'" + value[i] + "',";
            }
            sql += "N'"+value[14]+"'";
            sql += ")";
            cls.UpdateTable(sql);
        }
        [WebMethod]
        public void DanhSachPhieuChi_NCC_CT_Them(string[] value)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "insert into PhieuChi_NCC_CT(SoChungTu,IDCP,SoFile,MaNhanVien,SoTien,DoiTuong,MaDoiTuong,TenDoiTuong,DiaChi,VAT,ThanhTien,GhiChu,LaVanChuyen,MaDieuXe,Tien_DuyetUng)values(";
            for (int i = 0; i < 14; i++)
            {
                sql += "N'" + value[i] + "',";
            }
            sql += "N'" + value[14] + "'";
            sql += ")";
            cls.UpdateTable(sql);
        }
        [WebMethod]
        public void DanhSachPhieuChi_CT_Them(PhieuChi_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuChis.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a=>a.IDPhieuChi).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuChi;
            }
            p.IDPhieuChi = ID;
            context.PhieuChi_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChi_Con_CT_Them(PhieuChi_Con_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuChi_Con.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a => a.IDPhieuChi).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuChi;
            }
            p.IDPhieuChi = ID;
            context.PhieuChi_Con_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChi_NoiBo_CT_Them(PhieuChi_NoiBo_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuChi_NoiBo.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a => a.IDPhieuChi).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuChi;
            }
            p.IDPhieuChi = ID;
            context.PhieuChi_NoiBo_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChiTamUngLaiXe_CT_Them(PhieuChi_LaiXe_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuChi_LaiXe.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a => a.IDPhieuChi).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuChi;
            }
            p.IDPhieuChi = ID;
            context.PhieuChi_LaiXe_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThu_CT_Them(PhieuThu_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuThus.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a => a.IDPhieuThu).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuThu;
            }
            p.IDPhieuThu = ID;
            context.PhieuThu_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThu_NoiBo_CT_Them(PhieuThu_NoiBo_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuThu_NoiBo.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a => a.IDPhieuThu).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuThu;
            }
            p.IDPhieuThu = ID;
            context.PhieuThu_NoiBo_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThuGiaoNhan_CT_Them(PhieuThu_GiaoNhan_CT p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            int ID = 0;
            var t = context.PhieuThu_GiaoNhan.Where(a => a.SoChungTu == p.SoChungTu).OrderByDescending(a => a.IDPhieuThu).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuThu;
            }
            p.IDPhieuThu = ID;
            context.PhieuThu_GiaoNhan_CT.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThuLaiXe_CT_Them(object[]arr,string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            int ID = 0;
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.PhieuThu_GiaoNhan.Where(a => a.SoChungTu == SoChungTu).OrderByDescending(a => a.IDPhieuThu).Take(1);
            foreach (var item in t)
            {
                ID = item.IDPhieuThu;
            }
            string sql = "insert into PhieuThu_LaiXe_CT(SoChungTu,MaNhanVien,SoTien,DoiTuong,MaDoiTuong,TenDoiTuong,VAT,ThanhTien,LaPhieuHoanUng,IDPhieuThu,MaDieuXe,SoFile)values(";
            sql += "@SoChungTu,@MaNhanVien,@SoTien,@DoiTuong,@MaDoiTuong,@TenDoiTuong,@VAT,@ThanhTien,@LaPhieuHoanUng,@IDPhieuThu,@MaDieuXe,@SoFile)";
            int ts = 12;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@SoChungTu";
            name[1] = "@MaNhanVien";
            name[2] = "@SoTien";
            name[3] = "@DoiTuong";
            name[4] = "@MaDoiTuong";
            name[5] = "@TenDoiTuong";
            name[6] = "@VAT";
            name[7] = "@ThanhTien";
            name[8] = "@LaPhieuHoanUng";
            name[9] = "@IDPhieuThu";
            name[10] = "@MaDieuXe";
            name[11] = "@SoFile";
            value[0] = SoChungTu;
            value[1] = arr[1];
            value[2] = arr[2];
            value[3] = arr[3];
            value[4] = arr[4];
            value[5] = arr[5];
            value[6] = arr[6];
            value[7] = arr[7];
            value[8] = arr[8];
            value[9] = ID;
            value[10] = arr[10];
            value[11]= arr[11];
            cls.UpdateTable(sql, name, value, ts);
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuThu_CT where SoChungTu=PhieuThu.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuThu_CT where SoChungTu=PhieuThu.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuThu_CT where SoChungTu=PhieuThu.SoChungTu)as TenDoiTuong,";
            sql +="(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu.MaQuy)as TenQuy,(select sum(SoTien) from PhieuThu_CT where SoChungTu=PhieuThu.SoChungTu)as TongTien from PhieuThu where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_NoiBo_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuThu_NoiBo_CT where SoChungTu=PhieuThu_NoiBo.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuThu_NoiBo_CT where SoChungTu=PhieuThu_NoiBo.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuThu_NoiBo_CT where SoChungTu=PhieuThu_NoiBo.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu_NoiBo.MaQuy)as TenQuy,(select sum(SoTien) from PhieuThu_NoiBo_CT where SoChungTu=PhieuThu_NoiBo.SoChungTu)as TongTien from PhieuThu_NoiBo where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThuGiaoNhan_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuThu_GiaoNhan_CT where SoChungTu=PhieuThu_GiaoNhan.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuThu_GiaoNhan_CT where SoChungTu=PhieuThu_GiaoNhan.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuThu_GiaoNhan_CT where SoChungTu=PhieuThu_GiaoNhan.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu_GiaoNhan.MaQuy)as TenQuy,(select sum(SoTien) from PhieuThu_GiaoNhan_CT where SoChungTu=PhieuThu_GiaoNhan.SoChungTu)as TongTien from PhieuThu_GiaoNhan where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThuHoanUngLaiXe_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuThu_LaiXe_CT where SoChungTu=PhieuThu_LaiXe.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuThu_LaiXe_CT where SoChungTu=PhieuThu_LaiXe.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuThu_LaiXe_CT where SoChungTu=PhieuThu_LaiXe.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu_LaiXe.MaQuy)as TenQuy,(select sum(SoTien) from PhieuThu_LaiXe_CT where SoChungTu=PhieuThu_LaiXe.SoChungTu)as TongTien from PhieuThu_LaiXe where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
            int ts = 2;
            string[] name = new string[ts];
            object[] value = new object[ts];
            name[0] = "@TuNgay";
            name[1] = "@DenNgay";
            value[0] = TuNgay;
            value[1] = DenNgay;
            DataTable dt = cls.LoadTable(sql, name, value, ts);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu.MaQuy)as TenQuy from PhieuThu where SoChungTu in(select SoChungTu from PhieuThu_CT where SoFile like '%"+SoFile+"%')";
            int ts = 2;
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThuGiaoNhan_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu_GiaoNhan.MaQuy)as TenQuy from PhieuThu_GiaoNhan where SoChungTu in(select SoChungTu from PhieuThu_GiaoNhan_CT where SoFile like '%" + SoFile + "%')";
            int ts = 2;
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThuLaiXe_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = "select *,(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuThu_LaiXe.MaQuy)as TenQuy from PhieuThu_LaiXe where SoChungTu in(select SoChungTu from PhieuThu_LaiXe_CT where SoFile like '%" + SoFile + "%')";
            int ts = 2;
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select (select ThanhTien from PhieuThu_CT where IDCT=A.IDCT and LaPhieuChiHo=0) as SoTien_DichVu,(select ThanhTien from PhieuThu_CT where IDCT=A.IDCT and LaPhieuChiHo=1)as SoTien_ChiHo, A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuThu_CT A left join PhieuThu B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_NoiBo_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select  A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuThu_NoiBo_CT A left join PhieuThu_NoiBo B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThuLaiXe_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select  A.*,C.HoVaTen,B.NgayHachToan,B.HinhThucTT,C.* from PhieuThu_LaiXe_CT A left join PhieuThu_LaiXe B on A.SoChungTu=B.SoChungTu
                    left join DanhSachTaiKhoan C on C.TaiKhoan = A.MaDoiTuong and DoiTuong = 'NV'
                     where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.Columns.Add("TenChungTu");
            dt.Columns.Add("LoaiThu");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                dt.Rows[i]["TenChungTu"] = row["SoFile"].ToString();
                if (bool.Parse(row["LaPhieuHoanUng"].ToString()))
                    dt.Rows[i]["LoaiThu"] = "Số thu tạm ứng";
                else
                    dt.Rows[i]["LoaiThu"] = "Số thu cước";
            }
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_GiaoNhan_CT_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select A.*,C.TenKhachHang,B.*,C.TenVietTat,D.HoVaTen from PhieuThu_GiaoNhan_CT A left join PhieuThu_GiaoNhan B on A.SoChungTu=B.SoChungTu
            left join ThongTinFile E on E.SoFile = A.SoFile                   
            left join DanhSachKhachHang C on C.MaKhachHang = E.MaKhachHang
                    left join DanhSachTaiKhoan D on D.TaiKhoan = A.MaDoiTuong where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_GiaoNhan_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select A.*,C.TenKhachHang,B.*,C.TenVietTat,D.HoVaTen from PhieuThu_GiaoNhan_CT A left join PhieuThu_GiaoNhan B on A.SoChungTu=B.SoChungTu
            left join ThongTinFile E on E.SoFile = A.SoFile                   
            left join DanhSachKhachHang C on C.MaKhachHang = E.MaKhachHang
                    left join DanhSachTaiKhoan D on D.TaiKhoan = A.MaDoiTuong where A.SoFile like N'%" + SoFile + "%'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_LaiXe_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select A.* from PhieuThu_LaiXe_CT A left join PhieuThu_LaiXe B on A.SoChungTu=B.SoChungTu
            left join DanhSachTaiKhoan C on C.TaiKhoan = A.MaDoiTuong
                    left join DanhSachTaiKhoan D on D.TaiKhoan = A.MaDoiTuong where A.SoFile like N'%" + SoFile + "%'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_HoanUng_TheoSoChungTu(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"with abc as
                    (
                    select  (select ThanhTien from PhieuThu_CT where IDCT=A.IDCT and LaPhieuChiHo=0) as SoTien_DichVu,(select ThanhTien from PhieuThu_CT where IDCT=A.IDCT and LaPhieuChiHo=1)as SoTien_ChiHo,isnull(dbo.fn_DuyetUng(A.SoFile,A.MaNhanVien,A.IDCP),0)as DuyetUng, A.*,C.TenKhachHang,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuThu_CT A left join PhieuThu B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao
					)
					select *,SoTien_DichVu+SoTien_ChiHo-DuyetUng as PhaiThanhToan from abc where A.SoChungTu='" + SoChungTu + "'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachPhieuThu_CT_TheoSoFile(string SoFile)
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            string sql = @"select dbo.fn_TienDichVu(A.IDCT) as SoTien_DichVu,dbo.fn_TienChiHo(A.IDCT)as SoTien_ChiHo, A.*,C.TenKhachHang,C.DiaChi,D.HoVaTen,B.NgayHachToan,B.HinhThucTT from PhieuThu_CT A left join PhieuThu B on A.SoChungTu=B.SoChungTu
                    left join DanhSachKhachHang C on C.MaKhachHang = A.MaDoiTuong and DoiTuong = 'KH'
                    left join DanhSachTaiKhoan D on D.TaiKhoan = B.NguoiTao where A.SoFile like '%" + SoFile + "%'";
            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        [WebMethod]
        public void DanhSachPhieuChi_Sua(PhieuChi p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.PhieuChis.Single(a=>a.IDPhieuChi==p.IDPhieuChi);
            t.SoChungTu = p.SoChungTu;
            t.NgayHachToan = p.NgayHachToan;
            t.DienGiai = p.DienGiai;
            //t.SoTien = p.SoTien;
            //t.DoiTuong = p.DoiTuong;
            //t.MaDoiTuong = p.MaDoiTuong;
            t.NguoiNhan = p.NguoiNhan;
           // t.DiaChi = p.DiaChi;
            t.MaChi = p.MaChi;
            t.LyDoChi = p.LyDoChi;
          //  t.VAT = p.VAT;
          //  t.ThanhTien = p.ThanhTien;
            t.SoHoaDon = p.SoHoaDon;
           // t.GhiChu = p.GhiChu;
            t.NguoiTao = p.NguoiTao;
            t.MaQuy = p.MaQuy;
            t.ThoiGianTao = p.ThoiGianTao;
            context.SaveChanges();
            //
            
        }
        [WebMethod]
        public void DanhSachPhieuThu_Sua(PhieuThu p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.PhieuThus.Single(a => a.IDPhieuThu == p.IDPhieuThu);
            t.SoChungTu = p.SoChungTu;
            t.NgayHachToan = p.NgayHachToan;
            t.DienGiai = p.DienGiai;
            //t.SoTien = p.SoTien;
            //t.DoiTuong = p.DoiTuong;
            //t.MaDoiTuong = p.MaDoiTuong;
            t.NguoiNhan = p.NguoiNhan;
            // t.DiaChi = p.DiaChi;
            t.MaThu = p.MaThu;
            t.LyDoThu = p.LyDoThu;
            //  t.VAT = p.VAT;
            //  t.ThanhTien = p.ThanhTien;
            t.SoHoaDon = p.SoHoaDon;
            // t.GhiChu = p.GhiChu;
            t.NguoiTao = p.NguoiTao;
            t.MaQuy = p.MaQuy;
            t.ThoiGianTao = p.ThoiGianTao;
            context.SaveChanges();
            //

        }
        [WebMethod]
        public void PhieuChi_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuChi_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuChi_CT.Single(b => b.IDCT == item1.IDCT);
                    context1.PhieuChi_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void PhieuChi_NoiBo_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuChi_NoiBo_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuChi_NoiBo_CT.Single(b => b.IDCT == item1.IDCT);
                    context1.PhieuChi_NoiBo_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void PhieuChiTamUngLaiXe_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuChi_LaiXe_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuChi_LaiXe_CT.Single(b => b.IDCTNCC == item1.IDCTNCC);
                    context1.PhieuChi_LaiXe_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void PhieuChi_NCC_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuChi_NCC_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuChi_NCC_CT.Single(b => b.IDCTNCC == item1.IDCTNCC);
                    context1.PhieuChi_NCC_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void PhieuThu_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuThu_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuThu_CT.Single(b => b.IDCT == item1.IDCT);
                    context1.PhieuThu_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void PhieuThuGiaoNhan_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuThu_GiaoNhan_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuThu_GiaoNhan_CT.Single(b => b.IDCT == item1.IDCT);
                    context1.PhieuThu_GiaoNhan_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void PhieuThuLaiXe_CT_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t1 = context.PhieuThu_LaiXe_CT.Where(a => a.SoChungTu == SoChungTu);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item1 in t1)
                {
                    var t11 = context1.PhieuThu_LaiXe_CT.Single(b => b.IDCT == item1.IDCT);
                    context1.PhieuThu_LaiXe_CT.Remove(t11);
                    context1.SaveChanges();
                }

            }
        }
        [WebMethod]
        public void DanhSachPhieuChi_Xoa(PhieuChi p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuChi t = context.PhieuChis.Single(a => a.IDPhieuChi == p.IDPhieuChi);
            context.PhieuChis.Remove(t);
            context.SaveChanges();
            clsKetNoi cls = new clsKetNoi();
            cls.UpdateTable("delete from PhieuChi_CT where IDPhieuChi="+p.IDPhieuChi);
        }
        [WebMethod]
        public void DanhSachPhieuChi_Con_Xoa(PhieuChi_Con p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuChi_Con t = context.PhieuChi_Con.Single(a => a.IDPhieuChi == p.IDPhieuChi);
            context.PhieuChi_Con.Remove(t);
            context.SaveChanges();
            clsKetNoi cls = new clsKetNoi();
            cls.UpdateTable("delete from PhieuChi_Con_CT where IDPhieuChi=" + p.IDPhieuChi);
        }
        [WebMethod]
        public void DanhSachPhieuChi_NoiBo_Xoa(PhieuChi_NoiBo p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuChi_NoiBo t = context.PhieuChi_NoiBo.Single(a => a.IDPhieuChi == p.IDPhieuChi);
            context.PhieuChi_NoiBo.Remove(t);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChi_NoiBo_Xoa2(string SoChungTu)
        {
            clsKetNoi cls = new clsKetNoi();
            cls.UpdateTable("delete from PhieuThu_NoiBo where SoChungTu='"+SoChungTu+"'");
            cls.UpdateTable("delete from PhieuThu_NoiBo_CT where SoChungTu='" + SoChungTu + "'");
            //
            cls.UpdateTable("delete from PhieuChi_NoiBo where SoChungTu='" + SoChungTu + "'");
            cls.UpdateTable("delete from PhieuChi_NoiBo_CT where SoChungTu='" + SoChungTu + "'");
        }
        [WebMethod]
        public void DanhSachPhieuChiTamUngLaiXe_Xoa(PhieuChi_LaiXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuChi_LaiXe t = context.PhieuChi_LaiXe.Single(a => a.IDPhieuChi == p.IDPhieuChi);
            context.PhieuChi_LaiXe.Remove(t);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuChiNCC_Xoa(string SoChungTu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuChi_NCC t = context.PhieuChi_NCC.Single(a => a.SoChungTu == SoChungTu);
            context.PhieuChi_NCC.Remove(t);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThu_Xoa(PhieuThu p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuThu t = context.PhieuThus.Single(a => a.IDPhieuThu == p.IDPhieuThu);
            context.PhieuThus.Remove(t);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThu_NoiBo_Xoa(int IDPhieuThu)
        {
            clsKetNoi cls = new clsKetNoi();
            cls.UpdateTable("delete from PhieuThu_NoiBo where IDPhieuThu="+IDPhieuThu);
            cls.UpdateTable("delete from PhieuThu_NoiBo_CT where IDPhieuThu=" + IDPhieuThu);
        }
        [WebMethod]
        public void DanhSachPhieuThuGiaoNhan_Xoa(PhieuThu_GiaoNhan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuThu_GiaoNhan t = context.PhieuThu_GiaoNhan.Single(a => a.IDPhieuThu == p.IDPhieuThu);
            context.PhieuThu_GiaoNhan.Remove(t);
            context.SaveChanges();
        }
        [WebMethod]
        public void DanhSachPhieuThuLaiXe_Xoa(PhieuThu_LaiXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuThu_LaiXe t = context.PhieuThu_LaiXe.Single(a => a.IDPhieuThu == p.IDPhieuThu);
            context.PhieuThu_LaiXe.Remove(t);
            context.SaveChanges();
        }
        [WebMethod]
        public string TaoSoChungTu(string[]arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuChi where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString())+1;
            return string.Format("PC{0}{1}{2}",arr[2].Trim(),arr[1].Trim(),stt.ToString("00#"));
        }
        [WebMethod]
        public string TaoSoChungTu_Con(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuChi_Con where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("PC{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
        [WebMethod]
        public string TaoSoChungTu_NoiBo(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuChi_NoiBo where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("NB{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
       
        [WebMethod]
        public string TaoSoChungTu_LaiXe(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuChi_LaiXe where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("PC{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
        [WebMethod]
        public string TaoSoChungTu_Thu(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuThu where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("PT{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
        [WebMethod]
        public string TaoSoChungTu_ThuHoanCuocGiaoNhan(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuThu_GiaoNhan where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("PT{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
        [WebMethod]
        public string TaoSoChungTu_ThuLaiXe(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuThu_LaiXe where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("PT{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
        [WebMethod]
        public string TaoSoChungTu_Chi_NCC(string[] arr)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select isnull(max(substring(SoChungTu,len(rtrim(SoChungTu))-2,3)),0) from PhieuChi_NCC where month(NgayHachToan)='" + int.Parse(arr[1]) + "' and year(NgayHachToan)='" + arr[2] + "'";
            DataTable dt = cls.LoadTable(sql);
            int stt = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return string.Format("PC{0}{1}{2}", arr[2].Trim(), arr[1].Trim(), stt.ToString("00#"));
        }
        [WebMethod]
        public List<ThongTinFile_NguoiGiaoNhan>DanhSachNguoiGiaoNhan_TheoSoFile(string soFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t_NguoiGiaoNhan = context.ThongTinFile_NguoiGiaoNhan.Where(p=>p.SoFile==soFile);
            return t_NguoiGiaoNhan.ToList();
        }
        [WebMethod]
        public void XoaDanhSachNguoiGiaoNhan(ThongTinFile_NguoiGiaoNhan p)
        {
           
            clsKetNoi cls = new clsKetNoi();
            cls.UpdateTable("delete from ThongTinFile_NguoiGiaoNhan where SoFile='" + p.SoFile + "'");
        }
        [WebMethod]
        public void ThemDanhSachNguoiGiaoNhan(ThongTinFile_NguoiGiaoNhan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.ThongTinFile_NguoiGiaoNhan.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public bool KiemTraPhieuChi_DuyetUngDaTao(string soFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = (from a in context.PhieuChi_CT
                        join b in context.PhieuChis on a.SoChungTu equals b.SoChungTu
                        select new {a.SoFile,b.MaChi})
                        .Where(p=>p.MaChi=="007"&&p.SoFile==soFile);
            if (table.Count() > 0)
                return true;
            else return false;
        }
        [WebMethod]
        public void CapNhatDuyetUng_TheoSoFile(string soFile,string MaNhanVien)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double SoTien = 0;
            var table = context.PhieuChi_CT.Where(p=>p.SoFile==soFile &&p.MaNhanVien==MaNhanVien);
            foreach (var item in table)
            {
                SoTien += item.ThanhTien.Value;
            }
            var table_file = context.ThongTinFile_NguoiGiaoNhan.Single(p=>p.SoFile==soFile&&p.MaNhanVien==MaNhanVien);
            table_file.DuyetUng = SoTien;
            context.SaveChanges();
        }
        [WebMethod]
        public List<PhieuChi> DanhSachPhieuChi_TheoIdPhieuChi(int IDPhieuChi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChis.Where(p=>p.IDPhieuChi==IDPhieuChi);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuChi_Con> DanhSachPhieuChi_Con_TheoIdPhieuChi(int IDPhieuChi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChi_Con.Where(p => p.IDPhieuChi == IDPhieuChi);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuChi_LaiXe> DanhSachPhieuChiTamUngLaiXe_TheoIdPhieuChi(int IDPhieuChi)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuChi_LaiXe.Where(p => p.IDPhieuChi == IDPhieuChi);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuThu> DanhSachPhieuThu_TheoIdPhieuThu(int IDPhieuThu)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuThus.Where(p => p.IDPhieuThu == IDPhieuThu);
            return table.ToList();
        }


        [WebMethod]
        public bool KiemTraPhieuChi_XacNhanHoanUng_Admin_TheoSoFile(string SoFile)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            bool isCheck = false;
            var table = context.ThongTinFiles.Where(p => p.SoFile == SoFile);
            foreach (var item in table)
            {
                var t_check = context.BangLietKeCPs.Where(p=>p.IDLoHang==item.IDLoHang&&p.XacNhanHoanUng==true);
                if(t_check.Count()>0)
                {
                    isCheck = true;
                    break;
                }    
            }
            return isCheck;
        }
        [WebMethod]
        public List<ThongTinFile_NguoiGiaoNhan>ThongTinFile_TheoNguoiGiaoNhan(string SoFile,string MaNhanVien)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.ThongTinFile_NguoiGiaoNhan.Where(p=>p.SoFile==SoFile&&p.MaNhanVien==MaNhanVien);
            return table.ToList();
        }
        [WebMethod]
        public double TongDuyetUng(string SoFile,string MaNhanVien,int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double TongDuyetUng = 0;
            int demSL = context.BangLietKeCPs.Where(p => p.SoFile == SoFile).Count();
            if (demSL == 0||demSL==1)
            {
                var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == SoFile && p.MaNhanVien == MaNhanVien);
                foreach (var itemDuyetUng in t_duyetUng)
                {
                    TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                }
            }
            else
            {
                int dem = context.BangLietKeCPs.Where(p => p.IDCP < IDCP && p.SoFile == SoFile && p.MaNhanVien == MaNhanVien).Count();
                if (dem == 0)//dòng đầu tiên của lô hàng
                {
                    var t_duyetUng = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.SoFile == SoFile && p.MaNhanVien == MaNhanVien);
                    foreach (var itemDuyetUng in t_duyetUng)
                    {
                        TongDuyetUng += itemDuyetUng.DuyetUng.Value;
                    }
                }
                else
                    TongDuyetUng = 0;
            }
            return TongDuyetUng;
        }
        [WebMethod]
        public bool KiemTraTonTaiMaNhanVien(string MaNhanVien)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            bool ischeck = false;
            var t1 = context.BangLietKeCPs.Where(p=>p.MaNhanVien==MaNhanVien);
            if (t1.Count() > 0)
                ischeck= true;
            var t2 = context.ThongTinFile_NguoiGiaoNhan.Where(p => p.MaNhanVien == MaNhanVien);
            if (t2.Count() > 0)
                ischeck = true;
            return ischeck;

        }
        [WebMethod]
        public bool KiemTraTonTaiMaKH(string MaKH)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            bool ischeck = false;
            var t1 = context.ThongTinFiles.Where(p => p.MaKhachHang == MaKH);
            if (t1.Count() > 0)
                ischeck = true;
            return ischeck;

        }
        //cong no lai xe
        [WebMethod]
        public DataTable CongNoTongHopLaiXe(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("TenLaiXe");
            dt.Columns.Add("DauKy_TamUng", typeof(double));
            dt.Columns.Add("DauKy_ThuCuoc", typeof(double));
            dt.Columns.Add("PhatSinh_TamUng", typeof(double));
            dt.Columns.Add("PhatSinh_ThuCuoc", typeof(double));
            dt.Columns.Add("DaThu_TamUng", typeof(double));
            dt.Columns.Add("DaThu_ThuCuoc", typeof(double));
            dt.Columns.Add("CuoiKy_TamUng", typeof(double));
            dt.Columns.Add("CuoiKy_ThuCuoc", typeof(double));
            string sqlKH = "select * from DanhSachTaiKhoan ";
            if (TaiKhoan != "")
                sqlKH += " where TaiKhoan=N'" + TaiKhoan + "'";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["TaiKhoan"] = dtKH.Rows[i]["TaiKhoan"].ToString().Trim();
                row["TenLaiXe"] = dtKH.Rows[i]["HoVaTen"].ToString().Trim();
                #region dau ki
                string tk = row["TaiKhoan"].ToString().Trim();
                var t4 = (from a in context.PhieuChi_LaiXe_CT
                          join b in context.PhieuChi_LaiXe on a.IDPhieuChi equals b.IDPhieuChi
                          select new { a.SoTien, b.NgayHachToan, a.MaDoiTuong })
                         .Where(p => p.MaDoiTuong == tk && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) < 0);
                foreach (var item in t4)
                {
                    SoTien += item.SoTien.Value;
                }

                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_LaiXe_CT A left
                             join PhieuThu_LaiXe B on A.SoChungTu = B.SoChungTu where A.LaPhieuHoanUng=1 and A.MaDoituong=N'" + tk + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DauKy_TamUng"] = SoTien - ThuTien;
                //thu cuoc
                SoTien = 0;
                var t44 = context.BangDieuXes.Where(p=>p.LaiXe==tk && DbFunctions.DiffDays(TuNgay, p.Ngay) < 0);
                foreach (var item in t44)
                {
                    
                    SoTien += item.LaiXeThuCuoc.Value;
                }
                 sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_LaiXe_CT A left
                             join PhieuThu_LaiXe B on A.SoChungTu = B.SoChungTu where A.LaPhieuHoanUng=0 and A.MaDoituong=N'" + tk + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DauKy_ThuCuoc"] = SoTien - ThuTien;
                #endregion
                #region phat sinh trong ky
                //tam ung
                SoTien = 0;
                t4 = (from a in context.PhieuChi_LaiXe_CT
                      join b in context.PhieuChi_LaiXe on a.IDPhieuChi equals b.IDPhieuChi
                      select new { a.SoTien, b.NgayHachToan, a.MaDoiTuong })
                          .Where(p => p.MaDoiTuong == tk && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0&& DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t4)
                {
                    SoTien += item.SoTien.Value;
                }
                row["PhatSinh_TamUng"] = SoTien;
                SoTien = 0;
                var t45 = context.BangDieuXes.Where(p => p.LaiXe == tk && DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0&& DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
                foreach (var item in t45)
                {
                    SoTien += item.LaiXeThuCuoc.Value;
                }
                row["PhatSinh_ThuCuoc"] = SoTien;
                #endregion
                #region thanh toan
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_LaiXe_CT A left
                             join PhieuThu_LaiXe B on A.SoChungTu = B.SoChungTu where A.LaPhieuHoanUng=1 and A.MaDoituong=N'" + tk + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                 dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DaThu_TamUng"] = ThuTien;
                //
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_LaiXe_CT A left
                             join PhieuThu_LaiXe B on A.SoChungTu = B.SoChungTu where A.LaPhieuHoanUng=0 and A.MaDoituong=N'" + tk + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DaThu_ThuCuoc"] = ThuTien;
                #endregion
                #region cuoi ki
                row["CuoiKy_TamUng"] = double.Parse(row["DauKy_TamUng"].ToString()) + double.Parse(row["PhatSinh_TamUng"].ToString()) - double.Parse(row["DaThu_TamUng"].ToString());
                row["CuoiKy_ThuCuoc"] = double.Parse(row["DauKy_ThuCuoc"].ToString()) + double.Parse(row["PhatSinh_ThuCuoc"].ToString()) - double.Parse(row["DaThu_ThuCuoc"].ToString());

                dt.Rows.Add(row);
                #endregion
            }


            dt.TableName = "CongNo";
            return dt;
        }
        [WebMethod]
        public DataTable CongNoTongHopGiaoNhan(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("DauKy_PhiCuoc", typeof(double));
            dt.Columns.Add("PhatSinh_PhiCuoc", typeof(double));
            dt.Columns.Add("DaHoan_PhiCuoc", typeof(double));
            dt.Columns.Add("CuoiKy_PhiCuoc", typeof(double));
            string sqlKH = "select * from DanhSachTaiKhoan ";
            if (TaiKhoan != "")
                sqlKH += " where TaiKhoan=N'" + TaiKhoan + "'";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["TaiKhoan"] = dtKH.Rows[i]["TaiKhoan"].ToString().Trim();
                row["TenGiaoNhan"] = dtKH.Rows[i]["HoVaTen"].ToString().Trim();
                #region dau ki
                string tk = row["TaiKhoan"].ToString().Trim();
                //lấy phiếu tạm thu và phiếu cược ở bảng liệt kê cp
                var t4 = (from a in context.BangLietKeCP_ChiTiet
                         join b in context.BangLietKeCPs on a.IDCP equals b.IDCP select new {a.SoTien_ChiHo,b.NgayTaoBangKe,b.NguoiTaoBangKe,a.MaChiHo })
                         .Where(p => (p.MaChiHo == "CH01"||p.MaChiHo=="CH15")&& DbFunctions.DiffDays(TuNgay,p.NgayTaoBangKe)<0 && p.NguoiTaoBangKe == tk);
                foreach (var item in t4)
                {
                    SoTien += item.SoTien_ChiHo.Value;
                }
                //lấy thêm phiếu tạm thu ở bảng phơi nâng hạ (theo note mới 22.02.2025
                var t41 = (from a in context.BangPhoiNangHa_ChiTiet
                          join b in context.BangPhoiNangHas on a.IDLoHang equals b.IDLoHang
                           select new { a.SoTien_ChiHo, b.NgayTaoBangKe, b.NguoiTaoBangKe, a.MaChiHo })
                         .Where(p => ( p.MaChiHo == "CH15") && DbFunctions.DiffDays(TuNgay, p.NgayTaoBangKe) < 0);
                foreach (var item in t41)
                {
                    SoTien += item.SoTien_ChiHo.Value;
                }

                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_GiaoNhan_CT A left
                             join PhieuThu_GiaoNhan B on A.SoChungTu = B.SoChungTu where  A.DoiTuong ='NV' and A.MaDoituong=N'" + tk + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DauKy_PhiCuoc"] = SoTien  - ThuTien;

                #endregion
                SoTien = 0;
                #region phat sinh
                string sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangLietKeCP_ChiTiet A left
                             join BangLietKeCP B on A.IDCP = B.IDCP where (A.MaChiHo='CH01' or A.MaChiHo='CH15') and B.NguoiTaoBangKe =N'" + tk + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<=0)";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien += double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;

                string sql11 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang where ( A.MaChiHo='CH15')  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<=0)";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    SoTien += double.Parse(dt11.Rows[0][0].ToString());
                else
                    SoTien = 0;

                row["PhatSinh_PhiCuoc"] = SoTien;
                #endregion
                #region thanh toan
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_GiaoNhan_CT A left
                             join PhieuThu_GiaoNhan B on A.SoChungTu = B.SoChungTu where  A.DoiTuong ='NV' and A.MaDoituong=N'" + tk + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                
                row["DaHoan_PhiCuoc"] = ThuTien;
                #endregion
                #region cuoi ki
                row["CuoiKy_PhiCuoc"] = double.Parse(row["DauKy_PhiCuoc"].ToString()) + double.Parse(row["PhatSinh_PhiCuoc"].ToString()) - double.Parse(row["DaHoan_PhiCuoc"].ToString());
               
                dt.Rows.Add(row);
                #endregion
            }


            dt.TableName = "CongNo";
            return dt;
        }
        //cong nợ đối trừ
        [WebMethod]
        public DataTable CongNoDoiTru(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("Ten");
            dt.Columns.Add("PhaiThu", typeof(double));
            dt.Columns.Add("PhaiTra", typeof(double));
            //khach hang
            string sqlKH = "select * from DanhSachKhachHang where LaNhaCungCap=1";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            double KhongFile_CuocMua = 0, PhiCom = 0, CuocMua = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
                KhongFile_CuocMua = 0; PhiCom = 0; CuocMua = 0;
                DataRow row = dt.NewRow();
                row["MaKhachHang"] = dtKH.Rows[i]["MaKhachHang"].ToString().Trim();
                row["Ten"] = dtKH.Rows[i]["TenKhachHang"].ToString().Trim();
                row["Loai"] = "khachhang";

                #region phat sinh phai thu
                string sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru!='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=0 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;

                sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  DoiTru!='R' and len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and( DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and  DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocBan = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where DoiTru!='R' and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                double PhatSinh_DichVu = SoTien + KhongFile_CuocBan + KhongFile_ThanhTien;

                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru!='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=1 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                double PhatSinh_ChiHo = SoTien + BangPhoiNangHa_ChiHo;
                #endregion
                row["PhaiThu"] = PhatSinh_DichVu + PhatSinh_ChiHo;
                //
                #region phat sinh phai tra
                 sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where DoiTru!='R' and MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + row["MaKhachHang"].ToString() + "') and  MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                 dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    KhongFile_CuocMua = double.Parse(dt1.Rows[0][0].ToString());
                else
                    KhongFile_CuocMua = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where DoiTru!='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                 dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                //
                sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where DoiTru!='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    PhiCom = double.Parse(dt12.Rows[0][0].ToString());
                else
                    PhiCom = 0;
                //
                sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where A.DoiTru!='R' and  A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dt122 = cls.LoadTable(sql1);
                if (dt122.Rows.Count > 0)
                    CuocMua = double.Parse(dt122.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                double PhatSinh_VanChuyen = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom;

                sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.DoiTru!='R' and A.MaChiHo in ('CH06','CH07','CH08','CH09','CH12') and A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                double PhatSinh_NangHa = SoTien;
                row["PhaiTra"] = PhatSinh_VanChuyen + PhatSinh_NangHa;
                dt.Rows.Add(row);
                #endregion
                dt.Rows.Add(row);
            }
            DataView view = dt.DefaultView;
            view.RowFilter = "PhaiThu>0 and PhaiTra>0";
            dt = view.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public DataTable CongNoDaDoiTru(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("Ten");
            dt.Columns.Add("PhaiThu", typeof(double));
            dt.Columns.Add("PhaiTra", typeof(double));
            //khach hang
            string sqlKH = "select * from DanhSachKhachHang where LaNhaCungCap=1";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            double KhongFile_CuocMua = 0, PhiCom = 0, CuocMua = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
                KhongFile_CuocMua = 0; PhiCom = 0; CuocMua = 0;
                DataRow row = dt.NewRow();
                row["MaKhachHang"] = dtKH.Rows[i]["MaKhachHang"].ToString().Trim();
                row["Ten"] = dtKH.Rows[i]["TenKhachHang"].ToString().Trim();
                row["Loai"] = "khachhang";

                #region phat sinh phai thu
                string sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru=='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=0 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;

                sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  DoiTru=='R' and len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and( DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and  DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocBan = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where DoiTru=='R' and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                double PhatSinh_DichVu = SoTien + KhongFile_CuocBan + KhongFile_ThanhTien;

                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru=='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=1 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                double PhatSinh_ChiHo = SoTien + BangPhoiNangHa_ChiHo;
                #endregion
                row["PhaiThu"] = PhatSinh_DichVu + PhatSinh_ChiHo;
                #region phat sinh pai tra
                 sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where DoiTru=='R' and MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + row["MaKhachHang"].ToString() + "') and  MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                 dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    KhongFile_CuocMua = double.Parse(dt1.Rows[0][0].ToString());
                else
                    KhongFile_CuocMua = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where DoiTru=='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                 dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                //
                sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where DoiTru=='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    PhiCom = double.Parse(dt12.Rows[0][0].ToString());
                else
                    PhiCom = 0;
                //
                sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where A.DoiTru=='R' and  A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dt122 = cls.LoadTable(sql1);
                if (dt122.Rows.Count > 0)
                    CuocMua = double.Parse(dt122.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                double PhatSinh_VanChuyen = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom;

                sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.DoiTru=='R' and A.MaChiHo in ('CH06','CH07','CH08','CH09','CH12') and A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                double PhatSinh_NangHa = SoTien;
                row["PhaiTra"] = PhatSinh_VanChuyen + PhatSinh_NangHa;
                dt.Rows.Add(row);
                #endregion
                dt.Rows.Add(row);
            }
            //nha cung cap
            DataView view = dt.DefaultView;
            view.RowFilter = "PhaiThu>0 or PhaiTra>0";
            dt = view.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public DataTable CongNoDaDoiTruChiTiet(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("Ten");
            dt.Columns.Add("Loai");
            dt.Columns.Add("PhaiThu", typeof(double));
            dt.Columns.Add("PhaiTra", typeof(double));
            //khach hang
            string sqlKH = "select * from DanhSachKhachHang ";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["MaKhachHang"] = dtKH.Rows[i]["MaKhachHang"].ToString().Trim();
                row["Ten"] = dtKH.Rows[i]["TenKhachHang"].ToString().Trim();
                row["Loai"] = "khachhang";

                #region phat sinh
                string sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru=='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=0 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;

                sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  DoiTru=='R' and len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and( DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and  DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocBan = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where DoiTru=='R' and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                double PhatSinh_DichVu = SoTien + KhongFile_CuocBan + KhongFile_ThanhTien;

                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru=='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=1 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                double PhatSinh_ChiHo = SoTien + BangPhoiNangHa_ChiHo;
                #endregion
                row["PhaiThu"] = PhatSinh_DichVu + PhatSinh_ChiHo;
                dt.Rows.Add(row);
            }
            //nha cung cap
            sqlKH = "select * from DanhSachNhaCungCap ";
            dtKH = cls.LoadTable(sqlKH);
            double KhongFile_CuocMua = 0, PhiCom = 0, CuocMua = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["MaKhachHang"] = dtKH.Rows[i]["MaNhaCungCap"].ToString().Trim();
                row["Ten"] = dtKH.Rows[i]["TenNhaCungCap"].ToString().Trim();
                row["Loai"] = "nhacungcap";
                #region phat sinh
                string sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where DoiTru=='R' and MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + row["MaKhachHang"].ToString() + "') and  MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    KhongFile_CuocMua = double.Parse(dt1.Rows[0][0].ToString());
                else
                    KhongFile_CuocMua = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where DoiTru=='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                //
                sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where DoiTru=='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    PhiCom = double.Parse(dt12.Rows[0][0].ToString());
                else
                    PhiCom = 0;
                //
                sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where A.DoiTru=='R' and  A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dt122 = cls.LoadTable(sql1);
                if (dt122.Rows.Count > 0)
                    CuocMua = double.Parse(dt122.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                double PhatSinh_VanChuyen = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom;

                sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.DoiTru=='R' and A.MaChiHo in ('CH06','CH07','CH08','CH09','CH12') and A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                double PhatSinh_NangHa = SoTien;
                row["PhaiTra"] = PhatSinh_VanChuyen + PhatSinh_NangHa;
                dt.Rows.Add(row);
                #endregion
            }

            return dt;
        }
        [WebMethod]
        public DataTable CongNoDoiCanTaoDoiTru(string MaKH,DateTime TuNgay, DateTime DenNgay,bool LaPhaiThu)
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Chon",typeof(bool));
            dt.Columns.Add("Ngay",typeof(DateTime));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("PhiDichVu",typeof(double));
            dt.Columns.Add("PhiChiHo", typeof(double));
            dt.Columns.Add("PhiDichVuDoiTru", typeof(double));
            dt.Columns.Add("PhiChiHoDoiTru", typeof(double));

            ////khach hang
            //string sqlKH = "select * from DanhSachKhachHang where MaKhachHang='"+MaKH+"'";
            //DataTable dtKH = cls.LoadTable(sqlKH);
            //double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            //double KhongFile_CuocMua = 0, PhiCom = 0, CuocMua = 0;
            //for (int i = 0; i < dtKH.Rows.Count; i++)
            //{
            //    SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
            //    KhongFile_CuocMua = 0; PhiCom = 0; CuocMua = 0;
            //    #region phat sinh phai thu
            //    string sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
            //                 join FileDebit B on A.IDDeBit = B.IDDeBit left
            //                  join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru!='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=0 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
            //    DataTable dt1 = cls.LoadTable(sql1);
            //    if (dt1.Rows.Count > 0)
            //        for (int j = 0; j < dt1.Rows.Count; j++)
            //        {
            //            DataRow row = dt.NewRow();
            //            row["Chon"] = false;
            //            row["Ngay"] = DateTime.Parse(dt1.Rows[j]["ThoiGianLap"].ToString());
            //            row["SoFile"] = dt1.Rows[j]["SoFile"].ToString().Trim();

            //        }
            //    //    SoTien = double.Parse(dt1.Rows[0][0].ToString());
            //    //else
            //    //    SoTien = 0;

            //    sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  DoiTru!='R' and len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and( DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and  DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
            //    DataTable dt11 = cls.LoadTable(sql1);
            //    if (dt11.Rows.Count > 0)
            //        KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
            //    else
            //        KhongFile_CuocBan = 0;
            //    sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where DoiTru!='R' and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
            //    DataTable dt12 = cls.LoadTable(sql1);
            //    if (dt12.Rows.Count > 0)
            //        KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
            //    else
            //        KhongFile_ThanhTien = 0;
            //    double PhatSinh_DichVu = SoTien + KhongFile_CuocBan + KhongFile_ThanhTien;

            //    sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
            //                 join FileDebit B on A.IDDeBit = B.IDDeBit left
            //                  join ThongTinFile C on B.SoFile = C.SoFile where A.DoiTru!='R' and C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=1 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
            //    dt1 = cls.LoadTable(sql1);
            //    if (dt1.Rows.Count > 0)
            //        SoTien = double.Parse(dt1.Rows[0][0].ToString());
            //    else
            //        SoTien = 0;
            //    double PhatSinh_ChiHo = SoTien + BangPhoiNangHa_ChiHo;
            //    #endregion
            //    row["PhaiThu"] = PhatSinh_DichVu + PhatSinh_ChiHo;
            //    //
            //    #region phat sinh phai tra
            //    sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where DoiTru!='R' and MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + row["MaKhachHang"].ToString() + "') and  MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
            //    dt1 = cls.LoadTable(sql1);
            //    if (dt1.Rows.Count > 0)
            //        KhongFile_CuocMua = double.Parse(dt1.Rows[0][0].ToString());
            //    else
            //        KhongFile_CuocMua = 0;
            //    sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where DoiTru!='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
            //    dt12 = cls.LoadTable(sql1);
            //    if (dt12.Rows.Count > 0)
            //        KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
            //    else
            //        KhongFile_ThanhTien = 0;
            //    //
            //    sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where DoiTru!='R' and MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
            //    dt12 = cls.LoadTable(sql1);
            //    if (dt12.Rows.Count > 0)
            //        PhiCom = double.Parse(dt12.Rows[0][0].ToString());
            //    else
            //        PhiCom = 0;
            //    //
            //    sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where A.DoiTru!='R' and  A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
            //    DataTable dt122 = cls.LoadTable(sql1);
            //    if (dt122.Rows.Count > 0)
            //        CuocMua = double.Parse(dt122.Rows[0][0].ToString());
            //    else
            //        CuocMua = 0;
            //    double PhatSinh_VanChuyen = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom;

            //    sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
            //                 join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.DoiTru!='R' and A.MaChiHo in ('CH06','CH07','CH08','CH09','CH12') and A.MaNhaCungCap =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0)";
            //    dt1 = cls.LoadTable(sql1);
            //    if (dt1.Rows.Count > 0)
            //        SoTien = double.Parse(dt1.Rows[0][0].ToString());
            //    else
            //        SoTien = 0;
            //    double PhatSinh_NangHa = SoTien;
            //    row["PhaiTra"] = PhatSinh_VanChuyen + PhatSinh_NangHa;
            //    dt.Rows.Add(row);
            //    #endregion
            //    dt.Rows.Add(row);
            //}
            //DataView view = dt.DefaultView;
            //view.RowFilter = "PhaiThu>0 and PhaiTra>0";
            //dt = view.ToTable();
            //dt.TableName = "CongNo";

            return dt;
        }
        /*Tinh cong no khach hang*/
        [WebMethod]
        public DataTable CongNoTongHopKhachHang(DateTime TuNgay,DateTime DenNgay,string MaKH)
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("DauKi_DichVu",typeof(double));
            dt.Columns.Add("DauKi_ChiHo", typeof(double));
            dt.Columns.Add("PhatSinh_DichVu", typeof(double));
            dt.Columns.Add("PhatSinh_ChiHo", typeof(double));
            dt.Columns.Add("ThanhToan_DichVu", typeof(double));
            dt.Columns.Add("ThanhToan_ChiHo", typeof(double));
            dt.Columns.Add("CuoiKi_DichVu", typeof(double));
            dt.Columns.Add("CuoiKi_ChiHo", typeof(double));
            dt.Columns.Add("CuoiKi_TongNo", typeof(double));
            string sqlKH = "select * from DanhSachKhachHang ";
            if (MaKH != "")
                sqlKH += " where MaKhachHang=N'"+MaKH+"'";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, ThuTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, BangPhoiNangHa_ChiHo = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; ThuTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["MaKhachHang"] = dtKH.Rows[i]["MaKhachHang"].ToString().Trim();
                row["TenKhachHang"] = dtKH.Rows[i]["TenKhachHang"].ToString().Trim();
                row["TenVietTat"] = dtKH.Rows[i]["TenVietTat"].ToString().Trim();
                #region dau ki
               // double DauKi_DichVu = 0, DauKi_ChiHo = 0;
                string sql1=@"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.MaKhachHang =N'"+ row["MaKhachHang"].ToString().Trim()+ "' and A.LaPhiChiHo=0 and DATEDIFF(day,'"+TuNgay.ToString("yyyy-MM-dd")+"',B.ThoiGianLap)<0";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                #region an
                sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)<0";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocBan = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where  MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)<0";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                #endregion

                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu where  A.LaPhieuChiHo=0 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + row["MaKhachHang"].ToString().Trim()+"' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                double BangHang_DauKy = 0;

                //string sqlbh_dauky = @"select isnull(sum(ThanhTienVAT),0) from PhieuBanCT A left
                //             join PhieuBan B on A.IDPhieuBan = B.IDPhieuBan where  B.DoiTuong ='KH' and B.MaNhaCC=N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayBan)<0";
                //DataTable dtbh_dauky = cls.LoadTable(sqlbh_dauky);
                //if (dtbh_dauky.Rows.Count > 0)
                //    BangHang_DauKy = double.Parse(dtbh_dauky.Rows[0][0].ToString());
                //else
                //    BangHang_DauKy = 0;
                row["DauKi_DichVu"] = SoTien+ KhongFile_CuocBan+ KhongFile_ThanhTien - ThuTien+ BangHang_DauKy;
                //
                 sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=1 and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<0";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                //sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                //             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang left
                //              join ThongTinFile C on B.IDLoHang = C.IDLoHang where C.MaKhachHang ='" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<0";
                //dt1 = cls.LoadTable(sql1);
                //if (dt1.Rows.Count > 0)
                //    BangPhoiNangHa_ChiHo = double.Parse(dt1.Rows[0][0].ToString());
                //else
                //    BangPhoiNangHa_ChiHo = 0;


                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where A.LaPhieuChiHo=1 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                 dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DauKi_ChiHo"] = SoTien+ BangPhoiNangHa_ChiHo - ThuTien;
                #endregion
                #region phat sinh
                 sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=0 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                 dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;

                sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and( DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and  DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocBan = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where  MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                double BangHang_PhatSinh = 0;
                //string sqlbh_phatsinh = @"select isnull(sum(ThanhTienVAT),0) from PhieuBanCT A left
                //             join PhieuBan B on A.IDPhieuBan = B.IDPhieuBan where  B.DoiTuong ='KH' and B.MaNhaCC=N'" + row["MaKhachHang"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayBan)>=0  and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayBan)<=0";
                //DataTable dtbh_phatsinh = cls.LoadTable(sqlbh_phatsinh);
                //if (dtbh_phatsinh.Rows.Count > 0)
                //    BangHang_PhatSinh = double.Parse(dtbh_phatsinh.Rows[0][0].ToString());
                //else
                //    BangHang_PhatSinh = 0;
                row["PhatSinh_DichVu"] = SoTien+ KhongFile_CuocBan+ KhongFile_ThanhTien+ BangHang_PhatSinh;

                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.MaKhachHang =N'" + row["MaKhachHang"].ToString().Trim() + "' and A.LaPhiChiHo=1 and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                //sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                //             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang left
                //              join ThongTinFile C on B.IDLoHang = C.IDLoHang where C.MaKhachHang ='" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<=0)";
                //dt1 = cls.LoadTable(sql1);
                //if (dt1.Rows.Count > 0)
                //    BangPhoiNangHa_ChiHo = double.Parse(dt1.Rows[0][0].ToString());
                //else
                //    BangPhoiNangHa_ChiHo = 0;
                row["PhatSinh_ChiHo"] = SoTien+ BangPhoiNangHa_ChiHo;
                #endregion
                #region thanh toan
                 sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where  A.LaPhieuChiHo=0 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
                 dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["ThanhToan_DichVu"] = ThuTien;
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where  A.LaPhieuChiHo=1 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + row["MaKhachHang"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["ThanhToan_ChiHo"] = ThuTien;
                #endregion
                #region cuoi ki
                row["CuoiKi_DichVu"] = double.Parse(row["DauKi_DichVu"].ToString())+double.Parse(row["PhatSinh_DichVu"].ToString())- double.Parse(row["ThanhToan_DichVu"].ToString());
                row["CuoiKi_ChiHo"] = double.Parse(row["DauKi_ChiHo"].ToString()) + double.Parse(row["PhatSinh_ChiHo"].ToString()) - double.Parse(row["ThanhToan_ChiHo"].ToString());
                row["CuoiKi_TongNo"] = double.Parse(row["CuoiKi_DichVu"].ToString()) + double.Parse(row["CuoiKi_ChiHo"].ToString());
                dt.Rows.Add(row);
                #endregion
            }


            dt.TableName = "CongNo";
            return dt;
        }
        [WebMethod]
        public DataTable CongNoTongHopNhaCungCap(DateTime TuNgay, DateTime DenNgay, string MaNhaCungCap)
        {
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("MaNhaCungCap");
            dt.Columns.Add("TenNhaCungCap");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("DauKi_VanChuyen", typeof(double));
            dt.Columns.Add("DauKi_NangHa", typeof(double));
            dt.Columns.Add("PhatSinh_VanChuyen", typeof(double));
            dt.Columns.Add("PhatSinh_NangHa", typeof(double));
            dt.Columns.Add("ThanhToan_VanChuyen", typeof(double));
            dt.Columns.Add("ThanhToan_NangHa", typeof(double));
            dt.Columns.Add("CuoiKi_VanChuyen", typeof(double));
            dt.Columns.Add("CuoiKi_NangHa", typeof(double));
            dt.Columns.Add("CuoiKi_TongNo", typeof(double));
            string sqlKH = "select * from DanhSachNhaCungCap ";
            if (MaNhaCungCap != "")
                sqlKH += " where MaNhaCungCap=N'" + MaNhaCungCap + "'";
            DataTable dtKH = cls.LoadTable(sqlKH);
            double SoTien = 0, TraTien = 0, KhongFile_CuocMua = 0, KhongFile_ThanhTien = 0;
            double CuocMua = 0, PhiCom = 0;
            for (int i = 0; i < dtKH.Rows.Count; i++)
            {
                SoTien = 0; TraTien = 0; KhongFile_CuocMua = 0; KhongFile_ThanhTien = 0; CuocMua = 0;
                 DataRow row = dt.NewRow();
                row["MaNhaCungCap"] = dtKH.Rows[i]["MaNhaCungCap"].ToString().Trim();
                row["TenNhaCungCap"] = dtKH.Rows[i]["TenNhaCungCap"].ToString().Trim();
                row["TenVietTat"] = dtKH.Rows[i]["TenVietTat"].ToString().Trim();
                #region dau ki
                // double DauKi_DichVu = 0, DauKi_ChiHo = 0;
                string sql1 = "";
                sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + row["MaNhaCungCap"].ToString() + "') and  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)<0";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocMua = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocMua = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)<0";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                //
                sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)<0";
                DataTable dt112 = cls.LoadTable(sql1);
                if (dt112.Rows.Count > 0)
                    PhiCom = double.Parse(dt112.Rows[0][0].ToString());
                else
                    PhiCom = 0;
                //file gia
                sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where  A.MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<0";
                DataTable dt122 = cls.LoadTable(sql1);
                if (dt122.Rows.Count > 0)
                    CuocMua = double.Parse(dt122.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                //
                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=1 and B.MaChi='006' and  A.MaDoituong=N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["DauKi_VanChuyen"] =  KhongFile_CuocMua + KhongFile_ThanhTien+ CuocMua+ PhiCom - TraTien;
                //
                sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.MaChiHo in('CH06','CH07','CH08','CH09','CH12','CH15') and A.MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<0";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=0 and B.MaChi in ('006','007','008','009','012') and  A.MaDoituong=N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
              
                row["DauKi_NangHa"] = SoTien  - TraTien;
                #endregion
                #region phat sinh
                sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'"+row["MaNhaCungCap"].ToString()+"') and  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    KhongFile_CuocMua = double.Parse(dt1.Rows[0][0].ToString());
                else
                    KhongFile_CuocMua = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                //
                sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    PhiCom = double.Parse(dt12.Rows[0][0].ToString());
                else
                    PhiCom = 0;
                //
                sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where  A.MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                 dt122 = cls.LoadTable(sql1);
                if (dt122.Rows.Count > 0)
                    CuocMua = double.Parse(dt122.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                row["PhatSinh_VanChuyen"] = KhongFile_CuocMua + KhongFile_ThanhTien+ CuocMua+ PhiCom;

                sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.MaChiHo in ('CH06','CH07','CH08','CH09','CH12') and A.MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0)";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                row["PhatSinh_NangHa"] = SoTien;
                #endregion
                #region thanh toan
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=1 and B.MaChi='006' and  A.MaDoituong=N'" + row["MaNhaCungCap"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
                 dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["ThanhToan_VanChuyen"] = TraTien;
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=0 and B.MaChi in ('006','007','008','009','012') and  A.MaDoituong=N'" + row["MaNhaCungCap"].ToString().Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["ThanhToan_NangHa"] = TraTien;
                #endregion
                #region cuoi ki
                row["CuoiKi_VanChuyen"] = double.Parse(row["DauKi_VanChuyen"].ToString()) + double.Parse(row["PhatSinh_VanChuyen"].ToString()) - double.Parse(row["ThanhToan_VanChuyen"].ToString());
                row["CuoiKi_NangHa"] = double.Parse(row["DauKi_NangHa"].ToString()) + double.Parse(row["PhatSinh_NangHa"].ToString()) - double.Parse(row["ThanhToan_NangHa"].ToString());
                row["CuoiKi_TongNo"] = double.Parse(row["CuoiKi_VanChuyen"].ToString()) + double.Parse(row["CuoiKi_NangHa"].ToString());
                dt.Rows.Add(row);
                #endregion
            }


            dt.TableName = "CongNo";
            return dt;
        }
        [WebMethod]
        public DataTable CongNoChiTietKhachHang(DateTime TuNgay,DateTime DenNgay,string MaKH)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Ngay",typeof(DateTime));
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("No_DichVu", typeof(double));
            dt.Columns.Add("No_ChiHo", typeof(double));
            dt.Columns.Add("No_Tong", typeof(double));
            dt.Columns.Add("Thu_DichVu", typeof(double));
            dt.Columns.Add("Thu_ChiHo", typeof(double));
            dt.Columns.Add("Thu_Tong", typeof(double));
            dt.Columns.Add("NoCuoiKi_DichVu", typeof(double));
            dt.Columns.Add("NoCuoiKi_ChiHo", typeof(double));
            dt.Columns.Add("NoCuoiKi", typeof(double));
            dt.Columns.Add("SoThu_DichVu", typeof(double));
            dt.Columns.Add("SoThu_ChiHo", typeof(double));
            // dt.Columns.Add("LoaiChungTu");
            //  dt.Columns.Add("Loai");
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0;
            double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            double Tong_DauKi_DichVu = 0, Tong_DauKi_ChiHo = 0;
          
            string _SoFile = "", _MaDieuXe = "";
            //theo số file
            string sqlFile = "select * from ThongTinFile where MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianThucHien)<=0";
            DataTable dtFile = cls.LoadTable(sqlFile);
            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                row["Ngay"] = Convert.ToDateTime(dtFile.Rows[i]["ThoiGianThucHien"].ToString()) ;
                row["SoFile"] = dtFile.Rows[i]["SoFile"].ToString();
                string sqlDieuXe = "select * from BangDieuXe where SoFile ='" + row["SoFile"].ToString().Trim()+"'";
                DataTable dtDieuXe = cls.LoadTable(sqlDieuXe);
                if (dtDieuXe.Rows.Count > 0)
                {
                    row["MaDieuXe"] = dtDieuXe.Rows[0]["MaDieuXe"].ToString();
                    row["TuyenVC"] = dtDieuXe.Rows[0]["TuyenVC"].ToString();
                    string _ma = row["MaDieuXe"].ToString();
                    var t_sohd = context.FileDebit_KoHoaDon_KH.Where(p => p.MaDieuXe ==_ma);
                    foreach (var item2 in t_sohd)
                    {
                        row["SoHoaDon"] = item2.SoHoaDon;
                    }
                }
             
                
                #region no dich vu
                string sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                             join ThongTinFile C on B.SoFile = C.SoFile where C.SoFile='"+row["SoFile"].ToString()+ "' and C.MaKhachHang =N'" + MaKH.Trim() + "' and A.LaPhiChiHo=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                //sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where len(SoFile)<5  and MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
                //DataTable dt11 = cls.LoadTable(sql1);
                //if (dt11.Rows.Count > 0)
                //    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                //else
                //    KhongFile_CuocBan = 0;
                row["No_DichVu"] = SoTien + KhongFile_CuocBan + KhongFile_ThanhTien;

                #endregion
                #region no chi ho
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.SoFile='" + row["SoFile"].ToString() + "' and C.MaKhachHang =N'" + MaKH.Trim() + "' and A.LaPhiChiHo=1 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0";
                dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                //sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                //             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang left
                //              join ThongTinFile C on B.IDLoHang = C.IDLoHang where C.SoFile='"+row["SoFile"].ToString()+"' and C.MaKhachHang ='" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<=0";
                //dt1 = cls.LoadTable(sql1);
                //if (dt1.Rows.Count > 0)
                //    BangPhoiNangHa_ChiHo = double.Parse(dt1.Rows[0][0].ToString());
                //else
                //    BangPhoiNangHa_ChiHo = 0;
                row["No_ChiHo"] = SoTien + BangPhoiNangHa_ChiHo;
                #endregion
               
                row["No_Tong"] = double.Parse(row["No_DichVu"].ToString()) + double.Parse(row["No_ChiHo"].ToString());
                #region thu tien
                //dich vu
                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu where A.SoFile='"+ row["SoFile"].ToString()+ "' and A.LaPhieuChiHo=0 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["Thu_DichVu"] = ThuTien;
                //chi ho
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where A.SoFile='" + row["SoFile"].ToString() + "' and A.LaPhieuChiHo=1 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                #endregion
                row["Thu_ChiHo"] = ThuTien;
                row["Thu_Tong"] = double.Parse(row["Thu_DichVu"].ToString())+ double.Parse(row["Thu_ChiHo"].ToString());
                row["NoCuoiKi_DichVu"] = double.Parse(row["No_DichVu"].ToString()) - double.Parse(row["Thu_DichVu"].ToString());
                row["NoCuoiKi_ChiHo"] = double.Parse(row["No_ChiHo"].ToString()) - double.Parse(row["Thu_ChiHo"].ToString());
                row["NoCuoiKi"] = double.Parse(row["No_Tong"].ToString())- double.Parse(row["Thu_Tong"].ToString());
                dt.Rows.Add(row);
            }
            //
            //double BangHang_DauKy = 0;
            //string sqlPhieuBan = "select distinct SoPhieu,NgayBan from PhieuBan where DoiTuong ='KH' and MaNhaCC=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayBan)<=0 ";
            //DataTable dtPhieuBan = cls.LoadTable(sqlPhieuBan);
            //for (int i = 0; i < dtPhieuBan.Rows.Count; i++)
            //{

            //    DataRow row = dt.NewRow();
            //    row["Chon"] = false;
            //    row["Ngay"] = Convert.ToDateTime(dtPhieuBan.Rows[i]["NgayBan"].ToString());
            //    row["SoFile"] = dtPhieuBan.Rows[i]["SoPhieu"].ToString();
            //    string sqlbh_dauky = @"select isnull(sum(ThanhTienVAT),0) from PhieuBanCT A left
            //                 join PhieuBan B on A.IDPhieuBan = B.IDPhieuBan where  B.DoiTuong ='KH' and B.MaNhaCC=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayBan)<=0";
            //    DataTable dtbh_dauky = cls.LoadTable(sqlbh_dauky);
            //    if (dtbh_dauky.Rows.Count > 0)
            //        BangHang_DauKy = double.Parse(dtbh_dauky.Rows[0][0].ToString());
            //    else
            //        BangHang_DauKy = 0;
            //    row["No_DichVu"] = BangHang_DauKy;
            //    row["No_ChiHo"] = 0;
            //    row["No_Tong"] = double.Parse(row["No_DichVu"].ToString())+0;
            //}
            //theo mã điều xe(MaDieuXe)
            string sqlFile2 = "select * from BangDieuXe where len(SoFile)<5 and MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
            DataTable dtFile2 = cls.LoadTable(sqlFile2);
            for (int i = 0; i < dtFile2.Rows.Count; i++)
            {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                row["Ngay"] = Convert.ToDateTime(dtFile2.Rows[i]["Ngay"].ToString());
                row["SoFile"] = dtFile2.Rows[i]["SoFile"].ToString();
                row["MaDieuXe"] = dtFile2.Rows[i]["MaDieuXe"].ToString();
                row["TuyenVC"] = dtFile2.Rows[i]["TuyenVC"].ToString();
                string _ma = row["MaDieuXe"].ToString();
                var t_sohd = context.FileDebit_KoHoaDon_KH.Where(p => p.MaDieuXe ==_ma);
                foreach (var item2 in t_sohd)
                {
                    row["SoHoaDon"] = item2.SoHoaDon;
                }
                #region no dich vu
                string sql1 = "";
                sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and MaDieuXe='" + row["MaDieuXe"].ToString().Trim()+ "' and MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocBan = 0;
                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where MaDieuXe ='" + row["MaDieuXe"].ToString().Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                row["No_DichVu"] =KhongFile_CuocBan + KhongFile_ThanhTien;
                #endregion
                #region no chi ho
                row["No_ChiHo"] = 0;
                #endregion
                row["No_Tong"] = double.Parse(row["No_DichVu"].ToString()) + double.Parse(row["No_ChiHo"].ToString());
                #region thu tien
                //dich vu
                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu where MaDieuXe='"+ row["MaDieuXe"].ToString()+"' and   A.LaPhieuChiHo=0 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["Thu_DichVu"] = ThuTien;
                //chi ho
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where  MaDieuXe='" + row["MaDieuXe"].ToString() + "' and A.LaPhieuChiHo=1 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                #endregion
                row["Thu_ChiHo"] = ThuTien;
                row["Thu_Tong"] = double.Parse(row["Thu_DichVu"].ToString()) + double.Parse(row["Thu_ChiHo"].ToString());
                row["NoCuoiKi_DichVu"] = double.Parse(row["No_DichVu"].ToString()) - double.Parse(row["Thu_DichVu"].ToString());
                row["NoCuoiKi_ChiHo"] = double.Parse(row["No_ChiHo"].ToString()) - double.Parse(row["Thu_ChiHo"].ToString());
                row["NoCuoiKi"] = double.Parse(row["No_Tong"].ToString()) - double.Parse(row["Thu_Tong"].ToString());
                dt.Rows.Add(row);
            }
            DataView view = dt.DefaultView;
           // view.RowFilter = "NoCuoiKi>0";
            DataView view1 = view.ToTable().Copy().DefaultView;
            view1.Sort = "Ngay asc";
            dt = view1.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public double DauKy_KH(DateTime TuNgay,string MaKH)
        {
            clsKetNoi cls = new clsKetNoi();
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0, DauKi_DichVu = 0, DauKi_ChiHo = 0;
            #region dau ki
            // double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            string sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.MaKhachHang =N'" + MaKH.Trim() + "' and A.LaPhiChiHo=0 and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<0";
            DataTable dt1 = cls.LoadTable(sql1);
            if (dt1.Rows.Count > 0)
                SoTien = double.Parse(dt1.Rows[0][0].ToString());
            else
                SoTien = 0;
            #region an
            sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and len(SoFile)<5 and MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)<0";
            DataTable dt11 = cls.LoadTable(sql1);
            if (dt11.Rows.Count > 0)
                KhongFile_CuocBan = double.Parse(dt11.Rows[0][0].ToString());
            else
                KhongFile_CuocBan = 0;
            sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where  MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)<0";
            DataTable dt12 = cls.LoadTable(sql1);
            if (dt12.Rows.Count > 0)
                KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
            else
                KhongFile_ThanhTien = 0;
            #endregion

            string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu where  A.LaPhieuChiHo=0 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
            DataTable dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                ThuTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                ThuTien = 0;
            DauKi_DichVu = SoTien + KhongFile_CuocBan + KhongFile_ThanhTien - ThuTien;
            //
            sql1 = @"select isnull(sum(ThanhTien),0) from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                              join ThongTinFile C on B.SoFile = C.SoFile where C.MaKhachHang =N'" + MaKH.Trim() + "' and A.LaPhiChiHo=1 and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<0";
            dt1 = cls.LoadTable(sql1);
            if (dt1.Rows.Count > 0)
                SoTien = double.Parse(dt1.Rows[0][0].ToString());
            else
                SoTien = 0;
            

            sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where A.LaPhieuChiHo=1 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
            dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                ThuTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                ThuTien = 0;
            DauKi_ChiHo = SoTien + BangPhoiNangHa_ChiHo - ThuTien;
            #endregion
            return DauKi_DichVu + DauKi_ChiHo;
        }
        [WebMethod]
        public double ThanhToan_KH(DateTime TuNgay,DateTime DenNgay,string MaKH)
        {
            double ThanhToan_DichVu = 0, ThanhToan_ChiHo = 0, ThuTien = 0;
            clsKetNoi cls = new clsKetNoi();
            #region thanh toan
           string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where  A.LaPhieuChiHo=0 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
            DataTable dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                ThuTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                ThuTien = 0;
            ThanhToan_DichVu = ThuTien;
            sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_CT A left
                             join PhieuThu B on A.SoChungTu = B.SoChungTu  where  A.LaPhieuChiHo=1 and B.MaThu='004' and A.DoiTuong ='KH' and A.MaDoituong=N'" + MaKH.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
            dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                ThuTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                ThuTien = 0;
            ThanhToan_ChiHo = ThuTien;
            #endregion
            return ThanhToan_DichVu + ThanhToan_ChiHo;
        }
        [WebMethod]
        public DataTable CongNoChiTietKhachHang_In(DateTime TuNgay, DateTime DenNgay, string MaKH)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Ngay", typeof(DateTime));
           // dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("SoFile");
          //  dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("TuyenVC");
            //dt.Columns.Add("No_DichVu", typeof(double));
            //dt.Columns.Add("No_ChiHo", typeof(double));
            //dt.Columns.Add("No_Tong", typeof(double));
            //dt.Columns.Add("Thu_DichVu", typeof(double));
            //dt.Columns.Add("Thu_ChiHo", typeof(double));
            //dt.Columns.Add("Thu_Tong", typeof(double));
            //dt.Columns.Add("NoCuoiKi_DichVu", typeof(double));
            //dt.Columns.Add("NoCuoiKi_ChiHo", typeof(double));
            //dt.Columns.Add("NoCuoiKi", typeof(double));
            //dt.Columns.Add("SoThu_DichVu", typeof(double));
            //dt.Columns.Add("SoThu_ChiHo", typeof(double));
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("LoaiXe_KH");
            dt.Columns.Add("BienSoXe");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDDeBit");
            dt.Columns.Add("TenDichVu");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("TienVAT", typeof(double));
            dt.Columns.Add("ThanhTien", typeof(double));
            dt.Columns.Add("ThanhTien_ChiHo", typeof(double));
            dt.Columns.Add("ThanhTien_Ung", typeof(double));
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0;
            double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            double Tong_DauKi_DichVu = 0, Tong_DauKi_ChiHo = 0;

            string _SoFile = "";
            //theo số file
            string sqlFile = "select * from ThongTinFile where MaKhachHang =N'" + MaKH.Trim() + "'and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianThucHien)<=0";
            DataTable dtFile = cls.LoadTable(sqlFile);
            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                DataRow row1 = dtFile.Rows[i];
                string sql11 = @"select A.* from FileDebitChiTiet A left
                             join FileDebit B on A.IDDeBit = B.IDDeBit left
                             join ThongTinFile C on B.SoFile = C.SoFile where C.SoFile='" + row1["SoFile"].ToString() + "' and C.MaKhachHang =N'" + MaKH.Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)>=0  and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.ThoiGianLap)<=0)";
                DataTable dt1 = cls.LoadTable(sql11);
                string _file = "";
                for (int k = 0; k < dt1.Rows.Count; k++)
                {
                    DataRow row = dt.NewRow();
                    row["Ngay"] = Convert.ToDateTime(dtFile.Rows[i]["ThoiGianThucHien"].ToString());
                    row["SoFile"] = dtFile.Rows[i]["SoFile"].ToString().Trim();
                   
                    row["SoToKhai"] = dtFile.Rows[i]["SoToKhai"].ToString();
                    row["SoBill"] = dtFile.Rows[i]["SoBill"].ToString();
                    row["SoCont"] = dtFile.Rows[i]["SoCont"].ToString();
                    row["TenSales"] = dtFile.Rows[i]["TenSales"].ToString();
                    row["SoLuong"] = dtFile.Rows[i]["SoLuong"].ToString();
                    string sqlDieuXe = "select * from BangDieuXe where SoFile ='" + row1["SoFile"].ToString().Trim() + "' and MaKhachHang =N'" + MaKH.Trim() + "'";
                    DataTable dtDieuXe = cls.LoadTable(sqlDieuXe);
                    if (dtDieuXe.Rows.Count > 0)
                    {
                        row["TuyenVC"] = dtDieuXe.Rows[0]["TuyenVC"].ToString();
                        row["LoaiXe_KH"] = dtDieuXe.Rows[0]["LoaiXe_KH"].ToString();
                        row["BienSoXe"] = dtDieuXe.Rows[0]["BienSoXe"].ToString();
                        row["GhiChu"] = dtDieuXe.Rows[0]["GhiChu"].ToString();
                        //
                        string _ma = dtDieuXe.Rows[0]["MaDieuXe"].ToString();
                        var t_sohd = context.FileDebit_KoHoaDon_KH.Where(p => p.MaDieuXe == _ma);
                        foreach (var item2 in t_sohd)
                        {
                            row["SoHoaDon"] = item2.SoHoaDon;
                        }
                    }
                    row["IDDeBit"] = dt1.Rows[k]["IDDeBit"].ToString();
                    row["TenDichVu"] = dt1.Rows[k]["TenDichVu"].ToString();
                    //dich vu: LaPhiChiHo=0
                    if (!bool.Parse(dt1.Rows[k]["LaPhiChiHo"].ToString()))
                    {
                        row["SoTien"] = double.Parse(dt1.Rows[k]["SoTien"].ToString());
                        row["TienVAT"] = (double.Parse(dt1.Rows[k]["SoTien"].ToString())*double.Parse(dt1.Rows[k]["VAT"].ToString()))/100;
                        row["ThanhTien"] = double.Parse(dt1.Rows[k]["ThanhTien"].ToString());
                    }
                    else
                    {
                        //row["SoTien"] = double.Parse(dt1.Rows[k]["SoTien"].ToString());
                        row["SoTien"] = 0;//edit theo sheet giai doan 2 08.02/2025
                        row["TienVAT"] = 0;
                        row["ThanhTien_ChiHo"] = double.Parse(dt1.Rows[k]["ThanhTien"].ToString());
                    }
                    if (_file != row["SoFile"].ToString()&& row["SoFile"].ToString().Trim().Length>5)
                    {
                        _file = row["SoFile"].ToString();
                        string sqlPhieuThu_004 = "select isnull(sum(ThanhTien),0) from PhieuThu_CT where SoFile='" + _file + "' and MaDoiTuong =N'" + MaKH.Trim() + "'   and SoChungTu in(select SoChungTu from PhieuThu where DATEDIFF(day,'"+ 
                            TuNgay.ToString("yyyy-MM-dd")+"',NgayHachToan)>=0 and DATEDIFF(day,'"+DenNgay.ToString("yyyy-MM-dd")+"',NgayHachToan)<= 0)";
                        DataTable dtPhieuThu_004 = cls.LoadTable(sqlPhieuThu_004);
                        if (dtPhieuThu_004.Rows.Count > 0)
                            row["ThanhTien_Ung"] = double.Parse(dtPhieuThu_004.Rows[0][0].ToString());
                    }
                    dt.Rows.Add(row);
                }
              
            }
            //theo mã điều xe(MaDieuXe)
          //  string sqlFile2 = "select * from BangDieuXe where len(SoFile)<5  and MaKhachHang =N'" + MaKH.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
           // DataTable dtFile2 = cls.LoadTable(sqlFile2);
           // for (int i = 0; i < dtFile2.Rows.Count; i++)
           // {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0;
             
                string sql1 = "";
              //  sql1 = @"select isnull(sum(CuocBan+LaiXeThuCuoc),0) from BangDieuXe  where  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and MaDieuXe='" + row["MaDieuXe"].ToString().Trim() + "' and MaKhachHang =N'" + MaKH.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
                sql1 = @"select * from BangDieuXe  where len(SoFile)<5 and  MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_KH) and MaKhachHang =N'" + MaKH.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
                DataTable dt11 = cls.LoadTable(sql1);
               if(dt11.Rows.Count>0)
                {
                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {
                        string _MaDieuXe = dt11.Rows[k]["MaDieuXe"].ToString();
                        DataRow row = dt.NewRow();
                        row["Ngay"] = Convert.ToDateTime(dt11.Rows[k]["Ngay"].ToString());
                        row["SoFile"] = dt11.Rows[k]["MaDieuXe"].ToString().Trim();
                        row["TuyenVC"] = dt11.Rows[k]["TuyenVC"].ToString();
                        row["TenDichVu"]= dt11.Rows[k]["TuyenVC"].ToString();
                        row["SoTien"] = double.Parse(dt11.Rows[k]["CuocBan"].ToString())+ double.Parse(dt11.Rows[k]["LaiXeThuCuoc"].ToString());
                        row["TienVAT"] = 0;
                        row["ThanhTien"] = double.Parse(row["SoTien"].ToString());
                        row["ThanhTien_ChiHo"] = 0;

                        string sqlPhieuThu_004 = "select isnull(sum(ThanhTien),0) from PhieuThu_CT where MaDieuXe='" + row["SoFile"].ToString() + "' and MaDoiTuong =N'" + MaKH.Trim() + "'   and SoChungTu in(select SoChungTu from PhieuThu where DATEDIFF(day,'" +
                             TuNgay.ToString("yyyy-MM-dd") + "',NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayHachToan)<= 0)";
                        DataTable dtPhieuThu_004 = cls.LoadTable(sqlPhieuThu_004);
                        if (dtPhieuThu_004.Rows.Count > 0)
                            row["ThanhTien_Ung"] = double.Parse(dtPhieuThu_004.Rows[0][0].ToString());
                        dt.Rows.Add(row);
                    }
                }    
               else
                {
                    // sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_KH  where MaDieuXe ='" + _MaDieuXe.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
                    sql1 = @"select * from FileDebit_KoHoaDon_KH  where MaKhachHang =N'" + MaKH.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0)";
                    DataTable dt1x = cls.LoadTable(sql1);
                    for (int k = 0; k < dt1x.Rows.Count; k++)
                    {
                        DataRow row = dt.NewRow();
                        row["Ngay"] = Convert.ToDateTime(dt1x.Rows[k]["NgayTao"].ToString());
                     row["TenDichVu"] = dt1x.Rows[k]["TenDichVu"].ToString();
                    row["SoFile"] = dt1x.Rows[k]["MaDieuXe"].ToString();
                    string _ma = row["SoFile"].ToString();
                    var t_sohd = context.FileDebit_KoHoaDon_KH.Where(p=>p.MaDieuXe== _ma);
                    foreach (var item2 in t_sohd)
                    {
                        row["SoHoaDon"] = item2.SoHoaDon;
                    }
                        row["TuyenVC"] = dt1x.Rows[k]["TuyenVC"].ToString();
                        row["SoTien"] = double.Parse(dt1x.Rows[k]["SoTien"].ToString());
                        row["TienVAT"] = (double.Parse(dt1x.Rows[k]["SoTien"].ToString()) * double.Parse(dt1x.Rows[k]["VAT"].ToString())) / 100;
                        row["ThanhTien"] = double.Parse(dt1x.Rows[k]["ThanhTien"].ToString());
                        row["ThanhTien_ChiHo"] = 0;
                        string sqlPhieuThu_004 = "select isnull(sum(ThanhTien),0) from PhieuThu_CT where MaDieuXe='" + row["SoFile"].ToString() + "' and MaDoiTuong =N'" + MaKH.Trim() + "'   and SoChungTu in(select SoChungTu from PhieuThu where DATEDIFF(day,'" +
                           TuNgay.ToString("yyyy-MM-dd") + "',NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayHachToan)<= 0)";
                        DataTable dtPhieuThu_004 = cls.LoadTable(sqlPhieuThu_004);
                        if (dtPhieuThu_004.Rows.Count > 0)
                            row["ThanhTien_Ung"] = double.Parse(dtPhieuThu_004.Rows[0][0].ToString());
                        dt.Rows.Add(row);
                    }
                }
              
           // }
            DataView view = dt.DefaultView;
            // view.RowFilter = "NoCuoiKi>0";
            DataView view1 = view.ToTable().Copy().DefaultView;
            view1.Sort = "Ngay asc";
            dt = view1.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public DataTable CongNoChiTietNhaCungCap(DateTime TuNgay, DateTime DenNgay, string MaNhaCungCap)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("SoFile");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("No_VanChuyen", typeof(double));
            dt.Columns.Add("No_NangHa", typeof(double));
            dt.Columns.Add("No_Tong", typeof(double));
            dt.Columns.Add("Thu_VanChuyen", typeof(double));
            dt.Columns.Add("Thu_NangHa", typeof(double));
            dt.Columns.Add("Thu_Tong", typeof(double));
            dt.Columns.Add("NoCuoiKi_VanChuyen", typeof(double));
            dt.Columns.Add("NoCuoiKi_NangHa", typeof(double));
            dt.Columns.Add("NoCuoiKi", typeof(double));
            dt.Columns.Add("SoThu_VanChuyen", typeof(double));
            dt.Columns.Add("SoThu_NangHa", typeof(double));
            //// dt.Columns.Add("LoaiChungTu");
            ////  dt.Columns.Add("Loai");
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0, KhongFile_CuocMua = 0;
            double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            double Tong_DauKi_DichVu = 0, Tong_DauKi_ChiHo = 0, TraTien = 0, PhiCom = 0;

            string  _MaDieuXe = "";
            //theo so file
            DataTable dtF = cls.LoadTable("select distinct IDLoHang,SoFile from FileGia A left join FileGiaChiTiet B on A.IdGia=B.IDGia where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0");
            string sqlFile = "select distinct IDLoHang,(select top 1 SoFile from ThongTinFile where IDLoHang=BangPhoiNangHa.IDLoHang)as SoFile from BangPhoiNangHa where IDLoHang in(select IDLoHang from BangPhoiNangHa_ChiTiet where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "') and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0";
            DataTable dtFile = cls.LoadTable(sqlFile);
            dtFile.Merge(dtF);
            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0; KhongFile_CuocMua = 0;
                TraTien = 0;
                DataRow row1 = dtFile.Rows[i];
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                string tk= row1["SoFile"].ToString();
                row["SoFile"] = tk;
                // row["Ngay"] = Convert.ToDateTime(row1["NgayTaoBangKe"].ToString());
                //ngay lay theo file debit (27/11/2024)
                var t_ngay = context.FileDebits.Where(p=>p.SoFile== tk);
                foreach (var item in t_ngay)
                {
                    row["Ngay"] = item.ThoiGianLap;
                }
              
                row["SoHoaDon"] = "";//để code sau
                KhongFile_CuocMua = 0;
                KhongFile_ThanhTien = 0;
                double CuocMua = 0;
                string s = "select isnull(sum(GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where MaNhaCungCap=N'" + MaNhaCungCap.Trim() + "' and  SoFile ='" + tk + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dts = cls.LoadTable(s);
                if (dts.Rows.Count > 0)
                    CuocMua = double.Parse(dts.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                row["No_VanChuyen"] = KhongFile_CuocBan + KhongFile_ThanhTien+CuocMua;
                #region no nang ha
                string sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.MaChiHo in ('CH06','CH07','CH08','CH09','CH12','CH15') and  B.IDLoHang='" + row1["IDLoHang"].ToString().Trim() + "' and A.MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<=0";
                DataTable dt1 = cls.LoadTable(sql1);
                if (dt1.Rows.Count > 0)
                    SoTien = double.Parse(dt1.Rows[0][0].ToString());
                else
                    SoTien = 0;
                row["No_NangHa"] = SoTien;
                row["No_Tong"] = double.Parse(row["No_VanChuyen"].ToString()) + double.Parse(row["No_NangHa"].ToString());
                #endregion
                #region chi tien nha cung cap VanChuyen

                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.SoFile='" + row1["SoFile"].ToString().Trim() + "' and A.LaVanChuyen=1 and B.MaChi='006' and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["Thu_VanChuyen"] = TraTien;
                #endregion
                #region chi tien nha cung cap NangHa
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                         join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where    A.SoFile='" + row1["SoFile"].ToString().Trim() + "' and  A.LaVanChuyen=0 and B.MaChi in ('006','007','008','009','012') and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["Thu_NangHa"] = TraTien;
                row["Thu_Tong"] = double.Parse(row["Thu_VanChuyen"].ToString()) + double.Parse(row["Thu_NangHa"].ToString());
                #endregion
                row["NoCuoiKi_VanChuyen"] = double.Parse(row["No_VanChuyen"].ToString()) - double.Parse(row["Thu_VanChuyen"].ToString());
                row["NoCuoiKi_NangHa"] = double.Parse(row["No_NangHa"].ToString()) - double.Parse(row["Thu_NangHa"].ToString());
                row["NoCuoiKi"] = double.Parse(row["No_Tong"].ToString())- double.Parse(row["Thu_Tong"].ToString());
                dt.Rows.Add(row);
            }

            //theo mã điều xe(MaDieuXe)
            string sqlFile2 = "select Ngay,MaDieuXe,TuyenVC from BangDieuXe where  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
           string sql_NgayKhac = @"select NgayTao as Ngay,MaDieuXe,TenDichVu as TuyenVC from FileDebit_KoHoaDon_KH  where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
            DataTable dtFile2 = cls.LoadTable(sqlFile2);
            DataTable dtFile2_Khac = cls.LoadTable(sql_NgayKhac);
            dtFile2.Merge(dtFile2_Khac);
            for (int i = 0; i < dtFile2.Rows.Count; i++)
            {
                DataRow row1 = dtFile2.Rows[i];
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                row["Ngay"] = Convert.ToDateTime(dtFile2.Rows[i]["Ngay"].ToString());
                row["MaDieuXe"] = dtFile2.Rows[i]["MaDieuXe"].ToString();
                row["TuyenVC"] = dtFile2.Rows[i]["TuyenVC"].ToString();
                row["SoFile"] = "";//dtFile2.Rows[i]["SoFile"].ToString();
                var t_sohd = context.FileDebit_KoHoaDon_NCC.Where(p=>p.MaDieuXe== dtFile2.Rows[i]["MaDieuXe"].ToString());
                foreach (var item2 in t_sohd)
                {
                    row["SoHoaDon"] = item2.SoHoaDon;//để code sau
                }
               

                #region no van chuyen
                string sql1 = "";
                sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + MaNhaCungCap.Trim() + "') and  MaDieuXe ='" + row1["MaDieuXe"].ToString().Trim() + "' and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
                DataTable dt11 = cls.LoadTable(sql1);
                if (dt11.Rows.Count > 0)
                    KhongFile_CuocMua = double.Parse(dt11.Rows[0][0].ToString());
                else
                    KhongFile_CuocMua = 0;

                sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where MaDieuXe='" + row1["MaDieuXe"].ToString().Trim() + "' and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
                DataTable dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
                else
                    KhongFile_ThanhTien = 0;
                //
                sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where MaDieuXe='" + row1["MaDieuXe"].ToString().Trim() + "' and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
                dt12 = cls.LoadTable(sql1);
                if (dt12.Rows.Count > 0)
                    PhiCom = double.Parse(dt12.Rows[0][0].ToString());
                else
                    PhiCom = 0;
                //
                row["No_VanChuyen"] = KhongFile_CuocMua + KhongFile_ThanhTien+ PhiCom;
                #endregion
                #region no nang ha

                SoTien = 0;
                row["No_NangHa"] = SoTien;
                row["No_Tong"] = double.Parse(row["No_VanChuyen"].ToString()) + double.Parse(row["No_NangHa"].ToString());
                #endregion
                #region chi tien nha cung cap VanChuyen
                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.MaDieuXe='" + row1["MaDieuXe"].ToString().Trim() + "' and A.LaVanChuyen=1 and B.MaChi='006' and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["Thu_VanChuyen"] = TraTien;
                #endregion
                #region chi tien nha cung cap NangHa
                sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where   A.MaDieuXe='" + row1["MaDieuXe"].ToString().Trim() + "' and  A.LaVanChuyen=0 and B.MaChi in('006','007','008','009','012') and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    TraTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    TraTien = 0;
                row["Thu_NangHa"] = TraTien;
                row["Thu_Tong"] = double.Parse(row["Thu_VanChuyen"].ToString()) + double.Parse(row["Thu_NangHa"].ToString());
                #endregion
                row["NoCuoiKi_VanChuyen"] = double.Parse(row["No_VanChuyen"].ToString()) - double.Parse(row["Thu_VanChuyen"].ToString());
                row["NoCuoiKi_NangHa"] = double.Parse(row["No_NangHa"].ToString()) - double.Parse(row["Thu_NangHa"].ToString());
                row["NoCuoiKi"] = double.Parse(row["No_Tong"].ToString())- double.Parse(row["Thu_Tong"].ToString());
                dt.Rows.Add(row);
            }
            DataView view = dt.DefaultView;
            //// view.RowFilter = "NoCuoiKi>0";
            DataView view1 = view.ToTable().Copy().DefaultView;
            view1.Sort = "Ngay asc";
            dt = view1.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public double DauKy_NCC(string MaNhaCungCap,DateTime TuNgay, DateTime DenNgay)
        {
            double DauKy = 0;
            #region dau ki
            clsKetNoi cls = new clsKetNoi();
            double KhongFile_CuocMua = 0, KhongFile_ThanhTien = 0, PhiCom = 0, CuocMua = 0, TraTien = 0, SoTien = 0, DauKi_VanChuyen = 0, DauKi_NangHa = 0;
            string sql1 = "";
            sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + MaNhaCungCap + "') and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)<0";
            DataTable dt11 = cls.LoadTable(sql1);
            if (dt11.Rows.Count > 0)
                KhongFile_CuocMua = double.Parse(dt11.Rows[0][0].ToString());
            else
                KhongFile_CuocMua = 0;
            sql1 = @"select isnull(sum(ThanhTien),0) from FileDebit_KoHoaDon_NCC  where  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)<0";
            DataTable dt12 = cls.LoadTable(sql1);
            if (dt12.Rows.Count > 0)
                KhongFile_ThanhTien = double.Parse(dt12.Rows[0][0].ToString());
            else
                KhongFile_ThanhTien = 0;
            //
            sql1 = @"select isnull(sum(PhiCom),0) from FileDebit_KoHoaDon_KH  where  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)<0";
            DataTable dt112 = cls.LoadTable(sql1);
            if (dt112.Rows.Count > 0)
                PhiCom = double.Parse(dt112.Rows[0][0].ToString());
            else
                PhiCom = 0;
            //file gia
            sql1 = @"select isnull(sum(A.GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where  A.MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<0";
            DataTable dt122 = cls.LoadTable(sql1);
            if (dt122.Rows.Count > 0)
                CuocMua = double.Parse(dt122.Rows[0][0].ToString());
            else
                CuocMua = 0;
            //
            string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=1 and B.MaChi='006' and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
            DataTable dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                TraTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                TraTien = 0;
            DauKi_VanChuyen = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom - TraTien;
            //
            sql1 = @"select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet A left
                             join BangPhoiNangHa B on A.IDLoHang = B.IDLoHang  where A.MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<0";
            DataTable dt1 = cls.LoadTable(sql1);
            if (dt1.Rows.Count > 0)
                SoTien = double.Parse(dt1.Rows[0][0].ToString());
            else
                SoTien = 0;
            sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=0 and B.MaChi='006' and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<0";
            dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                TraTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                TraTien = 0;

            DauKi_NangHa = SoTien - TraTien;
            #endregion
            DauKy = DauKi_VanChuyen + DauKi_NangHa;
            return DauKy;
        }
        [WebMethod]
        public double ThanhToan_NCC(string MaNhaCungCap,DateTime TuNgay,DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            double TraTien=0, ThanhToan_VanChuyen = 0, ThanhToan_NangHa = 0;
            #region thanh toan
           string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=1 and B.MaChi='006' and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
            DataTable dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                TraTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                TraTien = 0;
            ThanhToan_VanChuyen = TraTien;
            sql2 = @"select isnull(sum(ThanhTien),0) from PhieuChi_NCC_CT A left
                             join PhieuChi_NCC B on A.SoChungTu = B.SoChungTu where  A.LaVanChuyen=0 and B.MaChi='006' and  A.MaDoituong=N'" + MaNhaCungCap.Trim() + "' and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0)";
            dt2 = cls.LoadTable(sql2);
            if (dt2.Rows.Count > 0)
                TraTien = double.Parse(dt2.Rows[0][0].ToString());
            else
                TraTien = 0;
            ThanhToan_NangHa = TraTien;
            #endregion
            return ThanhToan_VanChuyen + ThanhToan_NangHa;
        }
        [WebMethod]
        public DataTable CongNoChiTietNhaCungCap_In(DateTime TuNgay, DateTime DenNgay, string MaNhaCungCap)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("LoaiXe_NCC");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NoiDung");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("TienVAT", typeof(double));
            dt.Columns.Add("ThanhTien", typeof(double));
            dt.Columns.Add("BienSoXe");
            dt.Columns.Add("SoCont");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("PhiNang", typeof(double));
            dt.Columns.Add("PhiHa", typeof(double));
            dt.Columns.Add("PhiNangHa", typeof(double));
            dt.Columns.Add("PhiCSHT", typeof(double));
            dt.Columns.Add("PhiKhac", typeof(double));
            dt.Columns.Add("PhieuTamThu", typeof(double));
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0, KhongFile_CuocMua = 0;
            double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            double Tong_DauKi_DichVu = 0, Tong_DauKi_ChiHo = 0, TraTien = 0, PhiCom = 0;
            //theo so file
            DataTable dtF = cls.LoadTable("select distinct IDLoHang,SoFile from FileGia A left join FileGiaChiTiet B on A.IdGia=B.IDGia where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "'  and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0");
            // string sqlFile = "select distinct IDLoHang,(select top 1 SoFile from ThongTinFile where IDLoHang=BangPhoiNangHa.IDLoHang)as SoFile from BangPhoiNangHa where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "'  and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0";
            string sqlFile = "select distinct IDLoHang,(select top 1 SoFile from ThongTinFile where IDLoHang=BangPhoiNangHa.IDLoHang)as SoFile from BangPhoiNangHa where IDLoHang in(select IDLoHang from BangPhoiNangHa_ChiTiet where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "') and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0";
            DataTable dtFile = cls.LoadTable(sqlFile);
            DataView viewTong = dtFile.Copy().DefaultView;
            for (int i = 0; i < dtF.Rows.Count; i++)
            {
                viewTong.RowFilter = "IDLoHang='" + dtF.Rows[i]["IDLoHang"].ToString().Trim() + "'";
                if (viewTong.ToTable().Rows.Count == 0)
                {
                    DataRow row = dtFile.NewRow();
                    row["IDLoHang"] = dtF.Rows[i]["IDLoHang"].ToString().Trim();
                    row["SoFile"] = dtF.Rows[i]["SoFile"].ToString().Trim();
                    dtFile.Rows.Add(row);
                }
            }
            dtFile.Merge(dtF);
            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0; KhongFile_CuocMua = 0;
                TraTien = 0;
                DataRow row1 = dtFile.Rows[i];
                string tk = row1["SoFile"].ToString();

                // row["Ngay"] = Convert.ToDateTime(row1["NgayTaoBangKe"].ToString());
                //ngay lay theo file debit (27/11/2024)
                string _LoaiXe_NCC = "", _TuyenVC = "", _BienSoXe = "", _SoCont = "";

                KhongFile_CuocMua = 0;
                KhongFile_ThanhTien = 0;
                double CuocMua = 0;
                string s = "select * from FileGiaChiTiet A,FileGia B where B.SoFile='" + tk + "' and A.IDGia=B.IDGia and MaNhaCungCap=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dts = cls.LoadTable(s);
                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    var t = context.BangDieuXes.Where(p => p.SoFile == tk).Take(1);
                    foreach (var item in t)
                    {
                        _LoaiXe_NCC = item.LoaiXe_NCC;
                        _TuyenVC = item.TuyenVC;
                        _BienSoXe = item.BienSoXe;
                    }
                    var t1 = context.ThongTinFiles.Where(p => p.SoFile == tk);
                    foreach (var item in t1)
                    {
                        _SoCont = item.SoCont;
                    }
                    DataRow row = dt.NewRow();
                    row["Ngay"] = DateTime.Parse(dts.Rows[k]["ThoiGianLap"].ToString());
                    row["SoFile"] = tk;
                    row["LoaiXe_NCC"] = _LoaiXe_NCC;
                    row["TuyenVC"] = _TuyenVC;
                    row["NoiDung"] = dts.Rows[k]["TenDichVu"].ToString();
                    row["SoTien"] = double.Parse(dts.Rows[k]["GiaMua"].ToString());
                    row["TienVAT"] = 0;
                    row["ThanhTien"] = double.Parse(dts.Rows[k]["GiaMua"].ToString());
                    row["BienSoXe"] = _BienSoXe;
                    row["SoCont"] = _SoCont;
                    row["PhiNang"] = 0;
                    row["PhiHa"] = 0;
                    row["PhiNangHa"] = 0;
                    row["PhiCSHT"] = 0;
                    row["PhiKhac"] = 0;
                    row["PhieuTamThu"] = 0;
                    #region show cac phi o bang phoi nang ha

                    #endregion
                    dt.Rows.Add(row);

                }
                #region no nang ha
                s = @"select B.*,A.SoFile from  BangPhoiNangHa B
                      left join ThongTinFile A on A.IDLoHang=B.IDLoHang
                     where A.SoFile='" + tk + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayTaoBangKe)<=0";
                dts = cls.LoadTable(s);
                // DataView viewCon = dts.Copy().DefaultView;
                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    int _IDLoHang = int.Parse(dts.Rows[k]["IDLoHang"].ToString());
                    var tCheck = context.BangPhoiNangHa_ChiTiet.Where(p => p.IDLoHang == _IDLoHang && p.MaNhaCungCap == MaNhaCungCap).Take(1);
                    foreach (var item4 in tCheck)
                    {
                        var t = context.BangDieuXes.Where(p => p.SoFile == tk).Take(1);
                        foreach (var item in t)
                        {
                            _LoaiXe_NCC = item.LoaiXe_NCC;
                            _TuyenVC = item.TuyenVC;
                            _BienSoXe = item.BienSoXe;
                        }
                        var t1 = context.ThongTinFiles.Where(p => p.SoFile == tk);
                        foreach (var item in t1)
                        {
                            _SoCont = item.SoCont;
                        }
                        DataRow row = dt.NewRow();
                        row["Ngay"] = DateTime.Parse(dts.Rows[k]["NgayTaoBangKe"].ToString());
                        row["SoFile"] = tk;
                        row["LoaiXe_NCC"] = _LoaiXe_NCC;
                        row["TuyenVC"] = _TuyenVC;
                        row["NoiDung"] = _TuyenVC;
                        row["SoTien"] = 0;// double.Parse(dts.Rows[k]["SoTien_ChiHo"].ToString());
                        row["TienVAT"] = 0;
                        row["ThanhTien"] = 0;// double.Parse(dts.Rows[k]["SoTien_ChiHo"].ToString());
                        row["BienSoXe"] = _BienSoXe;
                        row["SoCont"] = _SoCont;
                        row["PhiNang"] = cls.LoadTable("select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet where MaChiHo='CH06' and IDLoHang='" + dts.Rows[k]["IDLoHang"].ToString().Trim() + "' and MaNhaCungCap='" + MaNhaCungCap + "'").Rows[0][0].ToString();
                        row["PhiHa"] = cls.LoadTable("select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet where MaChiHo='CH07' and IDLoHang='" + dts.Rows[k]["IDLoHang"].ToString().Trim() + "' and MaNhaCungCap='" + MaNhaCungCap + "'").Rows[0][0].ToString();
                        row["PhiNangHa"] = cls.LoadTable("select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet where MaChiHo='CH08' and IDLoHang='" + dts.Rows[k]["IDLoHang"].ToString().Trim() + "' and MaNhaCungCap='" + MaNhaCungCap + "'").Rows[0][0].ToString();
                        row["PhiCSHT"] = cls.LoadTable("select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet where MaChiHo='CH09' and IDLoHang='" + dts.Rows[k]["IDLoHang"].ToString().Trim() + "' and MaNhaCungCap='" + MaNhaCungCap + "'").Rows[0][0].ToString();
                        row["PhiKhac"] = cls.LoadTable("select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet where MaChiHo='CH12' and IDLoHang='" + dts.Rows[k]["IDLoHang"].ToString().Trim() + "' and MaNhaCungCap='" + MaNhaCungCap + "'").Rows[0][0].ToString();
                        row["PhieuTamThu"] = cls.LoadTable("select isnull(sum(SoTien_ChiHo),0) from BangPhoiNangHa_ChiTiet where MaChiHo='CH15' and IDLoHang='" + dts.Rows[k]["IDLoHang"].ToString().Trim() + "' and MaNhaCungCap='" + MaNhaCungCap + "'").Rows[0][0].ToString();

                        dt.Rows.Add(row);
                    }


                }
                #endregion

            }

            //theo mã điều xe(MaDieuXe)
            string sqlFile2 = "select Ngay,MaDieuXe,TuyenVC from BangDieuXe where  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "'  and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
            string sql_NgayKhac = @"select NgayTao as Ngay,MaDieuXe,TenDichVu as TuyenVC from FileDebit_KoHoaDon_KH  where MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
            DataTable dtFile2 = cls.LoadTable(sqlFile2);
            DataTable dtFile2_Khac = cls.LoadTable(sql_NgayKhac);
            dtFile2.Merge(dtFile2_Khac);
            for (int i = 0; i < dtFile2.Rows.Count; i++)
            {
                DataRow row1 = dtFile2.Rows[i];
                string tk = row1["MaDieuXe"].ToString();

                #region no van chuyen
                string sql1 = "";
                sql1 = @"select * from BangDieuXe  where MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + MaNhaCungCap.Trim() + "') and  MaDieuXe ='" + tk.Trim() + "' and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "'  and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
                DataTable dts = cls.LoadTable(sql1);
                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    string file = dts.Rows[k]["SoFile"].ToString().Trim();
                    string _LoaiXe_NCC = "", _TuyenVC = "", _BienSoXe = "", _SoCont = "";
                    string _f = dts.Rows[k]["SoFile"].ToString().Trim();
                    if (_f != "")
                    {
                        var t = context.BangDieuXes.Where(p => p.SoFile == _f).Take(1);
                        foreach (var item in t)
                        {
                            _LoaiXe_NCC = item.LoaiXe_NCC;
                            _TuyenVC = item.TuyenVC;
                            _BienSoXe = item.BienSoXe;
                        }

                        var t1 = context.ThongTinFiles.Where(p => p.SoFile == _f);
                        foreach (var item in t1)
                        {
                            _SoCont = item.SoCont;
                        }
                    }
                    DataRow row = dt.NewRow();
                    row["Ngay"] = DateTime.Parse(dts.Rows[k]["Ngay"].ToString());
                    row["SoFile"] = (file != "") ? file : tk;
                    var t_sohd = context.FileDebit_KoHoaDon_NCC.Where(p=>p.MaDieuXe==tk);
                    foreach (var item2 in t_sohd)
                    {
                        row["SoHoaDon"] = item2.SoHoaDon;
                    }
                    row["LoaiXe_NCC"] = _LoaiXe_NCC;
                    row["TuyenVC"] = dts.Rows[k]["TuyenVC"].ToString();
                    row["NoiDung"] = dts.Rows[k]["TuyenVC"].ToString();
                    row["SoTien"] = double.Parse(dts.Rows[k]["CuocMua"].ToString());
                    row["TienVAT"] = 0;
                    row["ThanhTien"] = double.Parse(dts.Rows[k]["CuocMua"].ToString());
                    row["BienSoXe"] = _BienSoXe;
                    row["SoCont"] = _SoCont;
                    row["PhiNang"] = 0;
                    row["PhiHa"] = 0;
                    row["PhiCSHT"] = 0;
                    row["PhiKhac"] = 0;
                    row["PhieuTamThu"] = 0;
                    dt.Rows.Add(row);

                }

                sql1 = @"select * from FileDebit_KoHoaDon_NCC  where MaDieuXe='" + tk.Trim() + "' and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "'  and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',NgayTao)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
                dts = cls.LoadTable(sql1);
                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    string _LoaiXe_NCC = "", _TuyenVC = "", _BienSoXe = "", _SoCont = "";

                    DataRow row = dt.NewRow();
                    row["Ngay"] = DateTime.Parse(dts.Rows[k]["NgayTao"].ToString());
                    row["SoFile"] = tk;
                    row["LoaiXe_NCC"] = _LoaiXe_NCC;
                    row["TuyenVC"] = dts.Rows[k]["TuyenVC"].ToString();
                    row["NoiDung"] = dts.Rows[k]["TuyenVC"].ToString();
                    row["SoTien"] = double.Parse(dts.Rows[k]["SoTien"].ToString());
                    row["TienVAT"] = (double.Parse(dts.Rows[k]["VAT"].ToString()) * double.Parse(dts.Rows[k]["SoTien"].ToString())) / 100;
                    row["ThanhTien"] = double.Parse(dts.Rows[k]["ThanhTien"].ToString());
                    row["BienSoXe"] = _BienSoXe;
                    row["SoCont"] = _SoCont;
                    row["PhiNang"] = 0;
                    row["PhiHa"] = 0;
                    row["PhiCSHT"] = 0;
                    row["PhiKhac"] = 0;
                    row["PhieuTamThu"] = 0;
                    var t_sohd = context.FileDebit_KoHoaDon_NCC.Where(p => p.MaDieuXe == tk);
                    foreach (var item2 in t_sohd)
                    {
                        row["SoHoaDon"] = item2.SoHoaDon;
                    }
                    dt.Rows.Add(row);
                }
                //
                sql1 = @"select * from FileDebit_KoHoaDon_KH  where MaDieuXe='" + row1["MaDieuXe"].ToString().Trim() + "' and  MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTao)<=0";
                dts = cls.LoadTable(sql1);
                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    string _LoaiXe_NCC = "", _TuyenVC = "", _BienSoXe = "", _SoCont = "";
                    DataRow row = dt.NewRow();
                    row["Ngay"] = DateTime.Parse(dts.Rows[k]["NgayTao"].ToString());
                    row["SoFile"] = tk;
                    row["LoaiXe_NCC"] = dts.Rows[k]["LoaiXe_KH"].ToString();
                    row["TuyenVC"] = dts.Rows[k]["TuyenVC"].ToString();
                    row["NoiDung"] = dts.Rows[k]["TenDichVu"].ToString() + "_Phí com";
                    row["SoTien"] = double.Parse(dts.Rows[k]["PhiCom"].ToString());
                    row["TienVAT"] = 0;
                    row["ThanhTien"] = double.Parse(dts.Rows[k]["PhiCom"].ToString());
                    row["BienSoXe"] = _BienSoXe;
                    row["SoCont"] = _SoCont;
                    row["PhiNang"] = 0;
                    row["PhiHa"] = 0;
                    row["PhiCSHT"] = 0;
                    row["PhiKhac"] = 0;
                    row["PhieuTamThu"] = 0;
                    dt.Rows.Add(row);
                }

                #endregion

            }

            DataView view = dt.DefaultView;
            DataView view1 = view.ToTable().Copy().DefaultView;
            view1.Sort = "SoFile asc";
            dt = view1.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public DataTable CongNoChiTietGiaoNhan(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("ChonTamThu_BangKe", typeof(bool));
            dt.Columns.Add("ChonTamThu_BangPhoi", typeof(bool));
            dt.Columns.Add("IDCP");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("PhiCuoc", typeof(double));
            dt.Columns.Add("PhiTamUng_BangKe", typeof(double));
            dt.Columns.Add("PhiTamUng_BangPhoi", typeof(double));
            dt.Columns.Add("DaThu_Cuoc", typeof(double));
            dt.Columns.Add("DaThu_TamUng_BangKe", typeof(double));
            dt.Columns.Add("DaThu_TamUng_BangPhoi", typeof(double));
            dt.Columns.Add("ConLai_Cuoc", typeof(double));
            dt.Columns.Add("ConLai_TamUng_BangKe", typeof(double));
            dt.Columns.Add("ConLai_TamUng_BangPhoi", typeof(double));
            dt.Columns.Add("SoThu_Cuoc", typeof(double));
            dt.Columns.Add("SoThu_TamUng_BangKe", typeof(double));
            dt.Columns.Add("SoThu_TamUng_BangPhoi", typeof(double));
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0;
            double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            double Tong_DauKi_DichVu = 0, Tong_DauKi_ChiHo = 0;

            string _SoFile = "", _MaDieuXe = "";
            //theo số file
            string sqlFile = "select distinct SoFile from BangLietKeCP where SoFile!='' and NguoiTaoBangKe =N'" + TaiKhoan + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayTaoBangKe)<=0";
            DataTable dtFile = cls.LoadTable(sqlFile);
            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                SoTien = 0;
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                row["ChonTamThu_BangKe"] = false;
                row["ChonTamThu_BangPhoi"] = false;
                string file= dtFile.Rows[i]["SoFile"].ToString();
                row["SoFile"] = file;
                row["TaiKhoan"] = TaiKhoan;
                DataTable dt1 = cls.LoadTable("select top 1 IDCP as ID1,* from BangLietKeCP where  SoFile='"+ row["SoFile"].ToString().Trim()+"' order by IDCP desc");
                if(dt1.Rows.Count>0)
                {

                    row["IDCP"] = dt1.Rows[0]["ID1"].ToString();
                    row["Ngay"] = Convert.ToDateTime(dt1.Rows[0]["NgayTaoBangKe"].ToString());
                    row["TenGiaoNhan"] = dt1.Rows[0]["NguoiTaoBangKe"].ToString();
                    dt1 = cls.LoadTable("select * from ThongTinFile A left join DanhSachKhachHang B on A.MaKhachHang=B.MaKhachHang where SoFile='" + row["SoFile"].ToString().Trim() + "'");
                    if(dt1.Rows.Count>0)
                        row["TenVietTat"] = dt1.Rows[0]["TenVietTat"].ToString();
                    var t4 = (from a in context.BangLietKeCP_ChiTiet
                              join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                              select new { a.SoTien_ChiHo, b.NgayTaoBangKe, b.NguoiTaoBangKe, a.MaChiHo,b.SoFile })
                        .Where(p =>  p.SoFile== file && DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0 && p.NguoiTaoBangKe == TaiKhoan);
                    double SoTien1 = 0, SoTien2 = 0;
                    foreach (var item in t4)
                    {
                        if(item.MaChiHo=="CH01")
                            SoTien1 += item.SoTien_ChiHo.Value;
                        if (item.MaChiHo == "CH151")
                            SoTien2 += item.SoTien_ChiHo.Value;
                    }
                    row["PhiCuoc"] = SoTien1;
                    row["PhiTamUng_BangKe"] = SoTien2;
                    SoTien = 0;
                    var t41 = (from a in context.BangPhoiNangHa_ChiTiet
                              join b in context.BangPhoiNangHas on a.IDLoHang equals b.IDLoHang
                              join c in context.ThongTinFiles on b.IDLoHang equals c.IDLoHang
                               select new { a.SoTien_ChiHo, b.NgayTaoBangKe, b.NguoiTaoBangKe, a.MaChiHo, c.SoFile })
                        .Where(p => ( p.MaChiHo == "CH15") && p.SoFile == file && DbFunctions.DiffDays(DenNgay, p.NgayTaoBangKe) <= 0);
                    foreach (var item in t41)
                    {
                        SoTien += item.SoTien_ChiHo.Value;
                    }
                    row["PhiTamUng_BangPhoi"] = SoTien;
                }
                string sql2 = @"select * from PhieuThu_GiaoNhan_CT A left
                             join PhieuThu_GiaoNhan B on A.SoChungTu = B.SoChungTu where (B.MaThu='005' or B.MaThu='006') and A.SoFile='"+row["SoFile"].ToString().Trim()+"' and  A.DoiTuong ='NV' and A.MaDoituong=N'" + TaiKhoan + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                double st1 = 0, st2 = 0, st3 = 0;
                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    if (dt2.Rows[k]["MaThu"].ToString().Trim() == "005")
                        st1 += double.Parse(dt2.Rows[k]["ThanhTien"].ToString().Trim());
                    else if (dt2.Rows[k]["MaThu"].ToString().Trim() == "006")
                    {
                        if (bool.Parse(dt2.Rows[k]["LaLKCP"].ToString().Trim()))
                            st2+= double.Parse(dt2.Rows[k]["ThanhTien"].ToString().Trim());
                        else
                            st3 += double.Parse(dt2.Rows[k]["ThanhTien"].ToString().Trim());
                    }    
                }
                row["DaThu_Cuoc"] = st1;
                row["DaThu_TamUng_BangKe"] = st2;
                row["DaThu_TamUng_BangPhoi"] = st3;

                row["ConLai_Cuoc"] = double.Parse(row["PhiCuoc"].ToString()) - double.Parse(row["DaThu_Cuoc"].ToString());
                row["ConLai_TamUng_BangKe"] = double.Parse(row["PhiTamUng_BangKe"].ToString()) - double.Parse(row["DaThu_TamUng_BangKe"].ToString());
                row["ConLai_TamUng_BangPhoi"] = double.Parse(row["PhiTamUng_BangPhoi"].ToString()) - double.Parse(row["DaThu_TamUng_BangPhoi"].ToString());

                dt.Rows.Add(row);
            }
           
            DataView view = dt.DefaultView;
            // view.RowFilter = "NoCuoiKi>0";
            DataView view1 = view.ToTable().Copy().DefaultView;
            view1.Sort = "Ngay asc";
            dt = view1.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao",typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc",typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("IDCP");
            if (TaiKhoan!="")
            {
                var t1 = (from a in context.BangLietKeCP_ChiTiet
                          join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new {
                              TienCuoc= a.SoTien_ChiHo,
                              NgayTao=b.NgayTaoBangKe,
                              MaKhachHang=d.MaKhachHang,
                              TenVietTat=c.TenVietTat,
                              b.SoFile,
                              MaNhanVien = b.MaNhanVien,
                              TenGiaoNhan=e.TenNhanVien,
                              b.IDCP,
                              a.MaChiHo
                          })
                       .Where(p => p.MaNhanVien == TaiKhoan&&(p.MaChiHo=="CH01") && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0&& DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                       foreach (var item in t1)
                {
                    var t_check = context.PhieuCuocs.Where(p=>p.SoFile==item.SoFile&&p.IDCP==item.IDCP);
                    if(t_check.Count()==0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCP;
                        dt.Rows.Add(row);
                    }    
                }
             
            }    
            else
            {
                var t1 = (from a in context.BangLietKeCP_ChiTiet
                          join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              b.SoFile,
                              MaNhanVien = b.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDCP,
                              a.MaChiHo
                          })
                      .Where(p => p.IDCP>0 && (p.MaChiHo == "CH01") && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t1)
                {
                    var t_check = context.PhieuCuocs.Where(p => p.SoFile == item.SoFile && p.IDCP == item.IDCP);
                    if (t_check.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCP;
                        dt.Rows.Add(row);
                    }
                }
            }    
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc_TheoIDCP( int IDCP)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("IDCP");
            
                var t1 = (from a in context.BangLietKeCP_ChiTiet
                          join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              b.SoFile,
                              MaNhanVien = b.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDCP,
                              a.MaChiHo
                          })
                       .Where(p => p.IDCP == IDCP && (p.MaChiHo == "CH01"));
                foreach (var item in t1)
                {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCP;
                        dt.Rows.Add(row);
                }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc_TheoIDCP2(int IDCPCT)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("IDCP");

            var t1 = (from a in context.BangLietKeCP_ChiTiet
                      join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                      join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                      join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                      join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                      select new
                      {
                          TienCuoc = a.SoTien_ChiHo,
                          NgayTao = b.NgayTaoBangKe,
                          MaKhachHang = d.MaKhachHang,
                          TenVietTat = c.TenVietTat,
                          b.SoFile,
                          MaNhanVien = b.MaNhanVien,
                          TenGiaoNhan = e.TenNhanVien,
                          b.IDCP,
                          a.IDCPCT,
                          a.MaChiHo
                      })
                   .Where(p => p.IDCPCT == IDCPCT && (p.MaChiHo == "CH01"));
            foreach (var item in t1)
            {
                DataRow row = dt.NewRow();
                row["SoFile"] = item.SoFile;
                row["NgayTao"] = item.NgayTao;
                row["MaKhachHang"] = item.MaKhachHang;
                row["TenVietTat"] = item.TenVietTat;
                row["TienCuoc"] = item.TienCuoc;
                row["MaNhanVien"] = item.MaNhanVien;
                row["TenGiaoNhan"] = item.TenGiaoNhan;
                row["IDCP"] = item.IDCP;
                row["IDCPCT"] = item.IDCPCT;
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc_DaTao(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan",typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDPhieuCuoc");
            dt.Columns.Add("Chon",typeof(bool));
            if (TaiKhoan != "")
            {
                var t = (from a in context.PhieuCuocs
                        join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                        join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                        select new {a.NguoiTao,a.IDCP,a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien =a.NguoiGiaoNhan,b.TenVietTat,a.SoFile,a.IDPhieuCuoc,a.NgayTao,a.MaKhachHang,a.GhiChu,a.TienCuoc,a.NguoiGiaoNhan, TenGiaoNhan =c.TenNhanVien})
                    .Where(p => p.NguoiGiaoNhan == TaiKhoan && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                  
                        DataRow row = dt.NewRow();
                    row["SoFile"] = item.SoFile;
                    row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                    row["DaXacNhan"] = item.DaXacNhan.Value;
                    if (item.DaXacNhan.Value==true)
                    {
                        row["NguoiXacNhan"] = item.NguoiXacNhan;
                        row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                    }
                      
                    row["GhiChu"] = item.GhiChu;
                    row["IDCP"] = item.IDCP;
                    row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                    row["NguoiTao"] = item.NguoiTao;
                    row["Chon"] = false;
                    dt.Rows.Add(row);
                   
                }
            }    
            else
            {
                var t = (from a in context.PhieuCuocs
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, a.IDPhieuCuoc, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc,a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                   .Where(p => p.IDPhieuCuoc>0 && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {

                    DataRow row = dt.NewRow();
                    row["SoFile"] = item.SoFile;
                    row["NgayTao"] = item.NgayTao;
                    row["MaKhachHang"] = item.MaKhachHang;
                    row["TenVietTat"] = item.TenVietTat;
                    row["TienCuoc"] = item.TienCuoc;
                    row["MaNhanVien"] = item.MaNhanVien;
                    row["TenGiaoNhan"] = item.TenGiaoNhan;
                    row["DaXacNhan"] = item.DaXacNhan.Value;
                    if (item.DaXacNhan.Value == true)
                    {
                        row["NguoiXacNhan"] = item.NguoiXacNhan;
                        row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                    }
                    row["GhiChu"] = item.GhiChu;
                    row["IDCP"] = item.IDCP;
                    row["Chon"] = false;
                    row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                    row["NguoiTao"] = item.NguoiTao;
                    dt.Rows.Add(row);

                }
            }    
                return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc_DaTao_Tren(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDCPCT");
            dt.Columns.Add("IDPhieuCuoc");
            dt.Columns.Add("Chon", typeof(bool));
            if (TaiKhoan != "")
            {
                var t = (from a in context.PhieuCuocs
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new { a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, a.IDPhieuCuoc, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien,a.IDCPCT })
                    .Where(p => p.NguoiGiaoNhan == TaiKhoan && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                  join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                  select new { a.SoFile, b.LaLKCP,b.MaThu }).Where(p => p.SoFile == item.SoFile && p.LaLKCP == true && p.MaThu == "005");
                    if (tcheck.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["IDCPCT"] = item.IDCPCT;
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["DaXacNhan"] = item.DaXacNhan.Value;
                        if (item.DaXacNhan.Value == true)
                        {
                            row["NguoiXacNhan"] = item.NguoiXacNhan;
                            row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                        }

                        row["GhiChu"] = item.GhiChu;
                        row["IDCP"] = item.IDCP;
                        row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                        row["NguoiTao"] = item.NguoiTao;
                        row["Chon"] = false;
                        dt.Rows.Add(row);
                    }

                }
            }
            else
            {
                var t = (from a in context.PhieuCuocs
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.IDCPCT, a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, a.IDPhieuCuoc, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                   .Where(p => p.IDPhieuCuoc > 0 && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                  join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                  select new { a.SoFile, b.LaLKCP,b.MaThu }).Where(p => p.SoFile == item.SoFile && p.LaLKCP == true&&p.MaThu=="005");
                    if (tcheck.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["IDCPCT"] = item.IDCPCT;
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["DaXacNhan"] = item.DaXacNhan.Value;
                        if (item.DaXacNhan.Value == true)
                        {
                            row["NguoiXacNhan"] = item.NguoiXacNhan;
                            row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                        }
                        row["GhiChu"] = item.GhiChu;
                        row["IDCP"] = item.IDCP;
                        row["Chon"] = false;
                        row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                        row["NguoiTao"] = item.NguoiTao;
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc_DaTao_Duoi(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDCPCT");
            dt.Columns.Add("IDPhieuCuoc");
            dt.Columns.Add("Chon", typeof(bool));
            if (TaiKhoan != "")
            {
                var t = (from a in context.PhieuCuocs
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.IDCPCT, a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, a.IDPhieuCuoc, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                    .Where(p => p.NguoiGiaoNhan == TaiKhoan && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                  join b in context.PhieuThu_GiaoNhan on a.IDPhieuThu equals b.IDPhieuThu
                                  select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile  && p.MaThu == "005");
                    if (tcheck.Count() > 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["IDCPCT"] = item.IDCPCT;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["DaXacNhan"] = item.DaXacNhan.Value;
                        if (item.DaXacNhan.Value == true)
                        {
                            row["NguoiXacNhan"] = item.NguoiXacNhan;
                            row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                        }

                        row["GhiChu"] = item.GhiChu;
                        row["IDCP"] = item.IDCP;
                        row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                        row["NguoiTao"] = item.NguoiTao;
                        row["Chon"] = false;
                        dt.Rows.Add(row);
                    }

                }
            }
            else
            {
                var t = (from a in context.PhieuCuocs
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.IDCPCT, a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, a.IDPhieuCuoc, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                   .Where(p => p.IDPhieuCuoc > 0 && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                  join b in context.PhieuThu_GiaoNhan on a.IDPhieuThu equals b.IDPhieuThu
                                  select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile  && p.MaThu == "005");
                    if (tcheck.Count() > 0)
                    {
                        DataRow row = dt.NewRow();
                        row["IDCPCT"] = item.IDCPCT;
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["DaXacNhan"] = item.DaXacNhan.Value;
                        if (item.DaXacNhan.Value == true)
                        {
                            row["NguoiXacNhan"] = item.NguoiXacNhan;
                            row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                        }
                        row["GhiChu"] = item.GhiChu;
                        row["IDCP"] = item.IDCP;
                        row["Chon"] = false;
                        row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                        row["NguoiTao"] = item.NguoiTao;
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachCuoc_DaTao_TheoIDPhieuCuoc(int IDPhieuCuoc)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDCPCT");
            var t = (from a in context.PhieuCuocs
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.IDCPCT,a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, a.IDPhieuCuoc, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                    .Where(p =>p.IDPhieuCuoc == IDPhieuCuoc);
                foreach (var item in t)
                {

                    DataRow row = dt.NewRow();
                row["SoFile"] = item.SoFile;
                row["IDCPCT"] = item.IDCPCT;
                    row["NgayTao"] = item.NgayTao;
                    row["MaKhachHang"] = item.MaKhachHang;
                    row["TenVietTat"] = item.TenVietTat;
                    row["TienCuoc"] = item.TienCuoc;
                    row["MaNhanVien"] = item.MaNhanVien;
                    row["TenGiaoNhan"] = item.TenGiaoNhan;
                
                row["DaXacNhan"] = item.DaXacNhan;
                if (item.DaXacNhan.Value == true)
                {
                    row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                    row["NguoiXacNhan"] = item.NguoiXacNhan;
                }
                    row["GhiChu"] = item.GhiChu;
                    row["IDCP"] = item.IDCP;
                    dt.Rows.Add(row);
                }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachTamThu(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("Bang");
            if (TaiKhoan != "")
            {
                var t1 = (from a in context.BangLietKeCP_ChiTiet
                          join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              b.SoFile,
                              MaNhanVien = b.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDCP,
                              a.MaChiHo
                          })
                       .Where(p => p.MaNhanVien == TaiKhoan && (p.MaChiHo == "CH15") && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t1)
                {
                    var t_check = context.PhieuTamThus.Where(p => p.SoFile == item.SoFile && p.IDCP == item.IDCP&&p.LaLKCP==true);
                    if (t_check.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCP;
                        row["Bang"] = "bangke";
                        dt.Rows.Add(row);
                    }
                }
           
                var t3 = (from a in context.BangPhoiNangHa_ChiTiet
                          join b in context.BangPhoiNangHas on a.IDLoHang equals b.IDLoHang
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join f in context.ThongTinFile_NguoiGiaoNhan on d.SoFile equals f.SoFile
                          join e in context.NhanViens on f.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              d.SoFile,
                              e.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDLoHang,
                              a.IDCPCT,
                              a.MaChiHo
                          })
                      .Where(p => p.MaNhanVien == TaiKhoan && (p.MaChiHo == "CH15") && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t3)
                {
                    var t_check = context.PhieuTamThus.Where(p => p.SoFile == item.SoFile && p.IDCP == item.IDCPCT && p.LaLKCP==false);
                    if (t_check.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCPCT;
                        row["Bang"] = "bangphoi";
                        dt.Rows.Add(row);
                    }
                }
            }
            else
            {
                var t1 = (from a in context.BangLietKeCP_ChiTiet
                          join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              b.SoFile,
                              MaNhanVien = b.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDCP,
                              a.MaChiHo
                          })
                      .Where(p => p.IDCP > 0 && ( p.MaChiHo == "CH15") && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t1)
                {
                    var t_check = context.PhieuTamThus.Where(p => p.SoFile == item.SoFile && p.IDCP == item.IDCP&&p.LaLKCP==true);
                    if (t_check.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCP;
                        row["Bang"] = "bangke";
                        dt.Rows.Add(row);
                    }
                }
                var t3 = (from a in context.BangPhoiNangHa_ChiTiet
                          join b in context.BangPhoiNangHas on a.IDLoHang equals b.IDLoHang
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join f in context.ThongTinFile_NguoiGiaoNhan on d.SoFile equals f.SoFile
                          join e in context.NhanViens on f.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              d.SoFile,
                              e.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDLoHang,
                              a.IDCPCT,
                              a.MaChiHo
                          })
                     .Where(p =>p.MaChiHo == "CH15" && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t3)
                {
                    var t_check = context.PhieuTamThus.Where(p => p.SoFile == item.SoFile && p.IDCP == item.IDCPCT && p.LaLKCP==false);
                    if (t_check.Count() == 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        row["TenGiaoNhan"] = item.TenGiaoNhan;
                        row["IDCP"] = item.IDCPCT;
                        row["Bang"] = "bangphoi";
                        dt.Rows.Add(row);
                    }
                }
            }
            DataView view = dt.Copy().DefaultView;
            view.Sort = "NgayTao asc";
            return view.ToTable();
        }
        [WebMethod]
        public DataTable DanhSachTamThu_TheoIDCP(int IDCP,string bang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("IDCP");
            if (bang == "bangke")
            {
                var t1 = (from a in context.BangLietKeCP_ChiTiet
                          join b in context.BangLietKeCPs on a.IDCP equals b.IDCP
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                          join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              b.SoFile,
                              MaNhanVien = b.MaNhanVien,
                              TenGiaoNhan = e.TenNhanVien,
                              b.IDCP,
                              a.MaChiHo
                          })
                       .Where(p => p.IDCP == IDCP &&  p.MaChiHo == "CH15");
                foreach (var item in t1)
                {
                    DataRow row = dt.NewRow();
                    row["SoFile"] = item.SoFile;
                    row["NgayTao"] = item.NgayTao;
                    row["MaKhachHang"] = item.MaKhachHang;
                    row["TenVietTat"] = item.TenVietTat;
                    row["TienCuoc"] = item.TienCuoc;
                    row["MaNhanVien"] = item.MaNhanVien;
                    row["TenGiaoNhan"] = item.TenGiaoNhan;
                    row["IDCP"] = item.IDCP;
                    dt.Rows.Add(row);
                }
            }
            else if (bang == "bangphoi")
            {
                var t1 = (from a in context.BangPhoiNangHa_ChiTiet
                          join b in context.BangPhoiNangHas on a.IDLoHang equals b.IDLoHang
                          join d in context.ThongTinFiles on b.IDLoHang equals d.IDLoHang
                          join c in context.DanhSachKhachHangs on d.MaKhachHang equals c.MaKhachHang
                         // join e in context.NhanViens on b.MaNhanVien equals e.MaNhanVien
                          select new
                          {
                              TienCuoc = a.SoTien_ChiHo,
                              NgayTao = b.NgayTaoBangKe,
                              MaKhachHang = d.MaKhachHang,
                              TenVietTat = c.TenVietTat,
                              d.SoFile,
                              //  MaNhanVien = b.MaNhanVien,
                              //  TenGiaoNhan = e.TenNhanVien,
                              IDCP= a.IDCPCT,
                              a.MaChiHo
                          })
                       .Where(p => p.IDCP == IDCP && p.MaChiHo == "CH15");
                foreach (var item in t1)
                {
                    DataRow row = dt.NewRow();
                    row["SoFile"] = item.SoFile;
                    row["NgayTao"] = item.NgayTao;
                    row["MaKhachHang"] = item.MaKhachHang;
                    row["TenVietTat"] = item.TenVietTat;
                    row["TienCuoc"] = item.TienCuoc;
                   // row["MaNhanVien"] = item.MaNhanVien;
                 //   row["TenGiaoNhan"] = item.TenGiaoNhan;
                    row["IDCP"] = item.IDCP;
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachTamThu_DaTao(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDPhieuCuoc");
            dt.Columns.Add("Chon", typeof(bool));
            if (TaiKhoan != "")
            {
                var t = (from a in context.PhieuTamThus
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new { a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                    .Where(p => p.NguoiGiaoNhan == TaiKhoan && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {

                    DataRow row = dt.NewRow();
                    row["SoFile"] = item.SoFile;
                    row["NgayTao"] = item.NgayTao;
                    row["MaKhachHang"] = item.MaKhachHang;
                    row["TenVietTat"] = item.TenVietTat;
                    row["TienCuoc"] = item.TienCuoc;
                    row["MaNhanVien"] = item.MaNhanVien;
                    row["TenGiaoNhan"] = item.TenGiaoNhan;
                    row["DaXacNhan"] = item.DaXacNhan.Value;
                    if (item.DaXacNhan.Value == true)
                    {
                        row["NguoiXacNhan"] = item.NguoiXacNhan;
                        row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                    }

                    row["GhiChu"] = item.GhiChu;
                    row["IDCP"] = item.IDCP;
                    row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                    row["NguoiTao"] = item.NguoiTao;
                    row["Chon"] = false;
                    dt.Rows.Add(row);

                }
            }
            else
            {
                var t = (from a in context.PhieuTamThus
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new { a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc, a.NguoiGiaoNhan, TenGiaoNhan = c.TenNhanVien })
                   .Where(p => p.IDPhieuCuoc > 0 && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {

                    DataRow row = dt.NewRow();
                    row["SoFile"] = item.SoFile;
                    row["NgayTao"] = item.NgayTao;
                    row["MaKhachHang"] = item.MaKhachHang;
                    row["TenVietTat"] = item.TenVietTat;
                    row["TienCuoc"] = item.TienCuoc;
                    row["MaNhanVien"] = item.MaNhanVien;
                    row["TenGiaoNhan"] = item.TenGiaoNhan;
                    row["DaXacNhan"] = item.DaXacNhan.Value;
                    if (item.DaXacNhan.Value == true)
                    {
                        row["NguoiXacNhan"] = item.NguoiXacNhan;
                        row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                    }
                    row["GhiChu"] = item.GhiChu;
                    row["IDCP"] = item.IDCP;
                    row["Chon"] = false;
                    row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                    row["NguoiTao"] = item.NguoiTao;
                    dt.Rows.Add(row);

                }
            }
            DataView view = dt.Copy().DefaultView;
            view.Sort = "NgayTao asc";
            return view.ToTable();
        }
        [WebMethod]
        public DataTable DanhSachTamThu_DaTao_Tren(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDPhieuCuoc");
            dt.Columns.Add("Bang");
            dt.Columns.Add("Chon", typeof(bool));
            if (TaiKhoan != "")
            {
                var t = (from a in context.PhieuTamThus
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                        // join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.LaLKCP, a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc })
                    .Where(p => p.MaNhanVien == TaiKhoan && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    if (item.LaLKCP.Value)
                    {
                        var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                      join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                      select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile && p.LaLKCP == true && p.MaThu == "006");
                        if (tcheck.Count() == 0)
                        {
                            DataRow row = dt.NewRow();
                            row["SoFile"] = item.SoFile;
                            row["NgayTao"] = item.NgayTao;
                            row["MaKhachHang"] = item.MaKhachHang;
                            row["TenVietTat"] = item.TenVietTat;
                            row["TienCuoc"] = item.TienCuoc;
                            var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                            foreach (var item11 in t11)
                            {
                                row["TenGiaoNhan"] = item11.TenNhanVien;
                            }
                            row["MaNhanVien"] = item.MaNhanVien;
                            row["DaXacNhan"] = item.DaXacNhan.Value;
                            if (item.DaXacNhan.Value == true)
                            {
                                row["NguoiXacNhan"] = item.NguoiXacNhan;
                                row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                            }

                            row["GhiChu"] = item.GhiChu;
                            row["IDCP"] = item.IDCP;
                            row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                            row["NguoiTao"] = item.NguoiTao;
                            row["Bang"] = "bangke";
                            row["Chon"] = false;
                            dt.Rows.Add(row);
                        }
                        
                    }
                    else
                    {
                        //
                        var tcheck1 = (from a in context.PhieuThu_GiaoNhan_CT
                                       join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                       select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile && p.LaLKCP == false && p.MaThu == "006");
                        if (tcheck1.Count() == 0)
                        {
                            DataRow row = dt.NewRow();
                            row["SoFile"] = item.SoFile;
                            row["NgayTao"] = item.NgayTao;
                            row["MaKhachHang"] = item.MaKhachHang;
                            row["TenVietTat"] = item.TenVietTat;
                            row["TienCuoc"] = item.TienCuoc;
                            row["MaNhanVien"] = item.MaNhanVien;
                            var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                            foreach (var item11 in t11)
                            {
                                row["TenGiaoNhan"] = item11.TenNhanVien;
                            }
                            row["DaXacNhan"] = item.DaXacNhan.Value;
                            if (item.DaXacNhan.Value == true)
                            {
                                row["NguoiXacNhan"] = item.NguoiXacNhan;
                                row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                            }

                            row["GhiChu"] = item.GhiChu;
                            row["IDCP"] = item.IDCP;
                            row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                            row["NguoiTao"] = item.NguoiTao;
                            row["Bang"] = "bangphoi";
                            row["Chon"] = false;
                            dt.Rows.Add(row);
                        }
                    }
                }
               
            }
            else
            {
                var t = (from a in context.PhieuTamThus
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                        // join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new {a.LaLKCP, a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc })
                   .Where(p => p.IDPhieuCuoc > 0 && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    if (item.LaLKCP.Value)
                    {
                        var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                      join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                      select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile && p.LaLKCP == true && p.MaThu == "006");
                        if (tcheck.Count() == 0)
                        {
                            DataRow row = dt.NewRow();
                            row["SoFile"] = item.SoFile;
                            row["NgayTao"] = item.NgayTao;
                            row["MaKhachHang"] = item.MaKhachHang;
                            row["TenVietTat"] = item.TenVietTat;
                            row["TienCuoc"] = item.TienCuoc;
                            row["MaNhanVien"] = item.MaNhanVien;
                            var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                            foreach (var item11 in t11)
                            {
                                row["TenGiaoNhan"] = item11.TenNhanVien;
                            }
                            row["DaXacNhan"] = item.DaXacNhan.Value;
                            if (item.DaXacNhan.Value == true)
                            {
                                row["NguoiXacNhan"] = item.NguoiXacNhan;
                                row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                            }
                            row["GhiChu"] = item.GhiChu;
                            row["IDCP"] = item.IDCP;
                            row["Chon"] = false;
                            row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                            row["NguoiTao"] = item.NguoiTao;
                            row["Bang"] = "bangke";
                            dt.Rows.Add(row);
                        }
                    }
                    else
                    {
                        var tcheck1 = (from a in context.PhieuThu_GiaoNhan_CT
                                       join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                       select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile && p.LaLKCP == false && p.MaThu == "006");
                        if (tcheck1.Count() == 0)
                        {
                            DataRow row = dt.NewRow();
                            row["SoFile"] = item.SoFile;
                            row["NgayTao"] = item.NgayTao;
                            row["MaKhachHang"] = item.MaKhachHang;
                            row["TenVietTat"] = item.TenVietTat;
                            row["TienCuoc"] = item.TienCuoc;
                            row["MaNhanVien"] = item.MaNhanVien;
                            var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                            foreach (var item11 in t11)
                            {
                                row["TenGiaoNhan"] = item11.TenNhanVien;
                            }
                            row["DaXacNhan"] = item.DaXacNhan.Value;
                            if (item.DaXacNhan.Value == true)
                            {
                                row["NguoiXacNhan"] = item.NguoiXacNhan;
                                row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                            }
                            row["GhiChu"] = item.GhiChu;
                            row["IDCP"] = item.IDCP;
                            row["Chon"] = false;
                            row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                            row["NguoiTao"] = item.NguoiTao;
                            row["Bang"] = "bangphoi";
                            dt.Rows.Add(row);
                        }
                    }
                }
                
            }
            DataView view = dt.Copy().DefaultView;
            view.Sort = "NgayTao asc";
            return view.ToTable();
           
        }

        [WebMethod]
        public DataTable DanhSachTamThu_DaTao_Duoi(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("NguoiTao");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            dt.Columns.Add("IDPhieuCuoc");
            dt.Columns.Add("Bang");
            dt.Columns.Add("Chon", typeof(bool));
            if (TaiKhoan != "")
            {
                var t = (from a in context.PhieuTamThus
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                        // join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new { a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc })
                    .Where(p => p.MaNhanVien == TaiKhoan && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                  join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                  select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile && p.MaThu == "006");
                    if (tcheck.Count() > 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                        foreach (var item11 in t11)
                        {
                            row["TenGiaoNhan"] = item11.TenNhanVien;
                        }
                        row["DaXacNhan"] = item.DaXacNhan.Value;
                        if (item.DaXacNhan.Value == true)
                        {
                            row["NguoiXacNhan"] = item.NguoiXacNhan;
                            row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                        }

                        row["GhiChu"] = item.GhiChu;
                        row["IDCP"] = item.IDCP;
                        row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                        row["NguoiTao"] = item.NguoiTao;
                        row["Chon"] = false;
                        row["Bang"] = "bangke";
                        dt.Rows.Add(row);
                    }

                }
            }
            else
            {
                var t = (from a in context.PhieuTamThus
                         join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                         //join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                         select new { a.NguoiTao, a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc })
                   .Where(p => p.IDPhieuCuoc > 0 && DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                foreach (var item in t)
                {
                    var tcheck = (from a in context.PhieuThu_GiaoNhan_CT
                                  join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                                  select new { a.SoFile, b.LaLKCP, b.MaThu }).Where(p => p.SoFile == item.SoFile && p.MaThu == "006");
                    if (tcheck.Count() > 0)
                    {
                        DataRow row = dt.NewRow();
                        row["SoFile"] = item.SoFile;
                        row["NgayTao"] = item.NgayTao;
                        row["MaKhachHang"] = item.MaKhachHang;
                        row["TenVietTat"] = item.TenVietTat;
                        row["TienCuoc"] = item.TienCuoc;
                        row["MaNhanVien"] = item.MaNhanVien;
                        var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                        foreach (var item11 in t11)
                        {
                            row["TenGiaoNhan"] = item11.TenNhanVien;
                        }
                        row["DaXacNhan"] = item.DaXacNhan.Value;
                        if (item.DaXacNhan.Value == true)
                        {
                            row["NguoiXacNhan"] = item.NguoiXacNhan;
                            row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                        }
                        row["GhiChu"] = item.GhiChu;
                        row["IDCP"] = item.IDCP;
                        row["Chon"] = false;
                        row["IDPhieuCuoc"] = item.IDPhieuCuoc;
                        row["NguoiTao"] = item.NguoiTao;
                        row["Bang"] = "bangphoi";
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }
        [WebMethod]
        public DataTable DanhSachTamthu_DaTao_TheoIDPhieuCuoc(int IDPhieuCuoc)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("DSCuoc");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("TienCuoc", typeof(float));
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenGiaoNhan");
            dt.Columns.Add("DaXacNhan", typeof(bool));
            dt.Columns.Add("ThoiGianXacNhan", typeof(DateTime));
            dt.Columns.Add("NguoiXacNhan");
            dt.Columns.Add("GhiChu");
            dt.Columns.Add("IDCP");
            var t = (from a in context.PhieuTamThus
                     join b in context.DanhSachKhachHangs on a.MaKhachHang equals b.MaKhachHang
                    // join c in context.NhanViens on a.NguoiGiaoNhan equals c.MaNhanVien
                     select new { a.IDCP, a.NguoiXacNhan, a.DaXacNhan, a.ThoiGianXacNhan, MaNhanVien = a.NguoiGiaoNhan, b.TenVietTat, a.SoFile, IDPhieuCuoc= a.IDTamThu, a.NgayTao, a.MaKhachHang, a.GhiChu, a.TienCuoc })
                .Where(p => p.IDPhieuCuoc == IDPhieuCuoc);
            foreach (var item in t)
            {

                DataRow row = dt.NewRow();
                row["SoFile"] = item.SoFile;
                row["NgayTao"] = item.NgayTao;
                row["MaKhachHang"] = item.MaKhachHang;
                row["TenVietTat"] = item.TenVietTat;
                row["TienCuoc"] = item.TienCuoc;
                row["MaNhanVien"] = item.MaNhanVien;
                var t11 = context.NhanViens.Where(p => p.MaNhanVien == item.MaNhanVien);
                foreach (var item11 in t11)
                {
                    row["TenGiaoNhan"] = item11.TenNhanVien;
                }

                row["DaXacNhan"] = item.DaXacNhan;
                if (item.DaXacNhan.Value == true)
                {
                    row["ThoiGianXacNhan"] = item.ThoiGianXacNhan;
                    row["NguoiXacNhan"] = item.NguoiXacNhan;
                }
                row["GhiChu"] = item.GhiChu;
                row["IDCP"] = item.IDCP;
                dt.Rows.Add(row);
            }
            return dt;
        }

        [WebMethod]
        public DataTable CongNoChiTietLaiXe(DateTime TuNgay, DateTime DenNgay, string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("CongNo");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("SoChungTu");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("TenLaiXe");
            dt.Columns.Add("PhatSinh_TamUng", typeof(double));
            dt.Columns.Add("PhatSinh_ThuCuoc", typeof(double));
            dt.Columns.Add("DaThu_TamUng", typeof(double));
            dt.Columns.Add("DaThu_ThuCuoc", typeof(double));
            dt.Columns.Add("ConLai_TamUng", typeof(double));
            dt.Columns.Add("ConLai_ThuCuoc", typeof(double));
           // dt.Columns.Add("ConLai_TongNo", typeof(double));
            dt.Columns.Add("SoThu_ThuCuoc", typeof(double));
            dt.Columns.Add("SoThu_TamUng", typeof(double));
            double SoTien = 0, KhongFile_CuocBan = 0, KhongFile_ThanhTien = 0, ThuTien = 0, BangPhoiNangHa_ChiHo = 0;
            double DauKi_DichVu = 0, DauKi_ChiHo = 0;
            double Tong_DauKi_DichVu = 0, Tong_DauKi_ChiHo = 0;

            string _SoFile = "", _MaDieuXe = "";
            //theo tam ung
            string sqlFile = "select distinct  PhieuChi_LaiXe_CT.SoChungTu,NgayHachToan from PhieuChi_LaiXe_CT left join PhieuChi_LaiXe on PhieuChi_LaiXe_CT.SoChungTu=PhieuChi_LaiXe.SoChungTu where MaDoiTuong=N'" + TaiKhoan+"' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',NgayHachToan)<=0";
            DataTable dtTamUng = cls.LoadTable(sqlFile);
            for (int i = 0; i < dtTamUng.Rows.Count; i++)
            {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                string SoChungTu = dtTamUng.Rows[i]["SoChungTu"].ToString();
                row["SoChungTu"] = SoChungTu;
                row["TaiKhoan"] = TaiKhoan;
                row["Ngay"] = Convert.ToDateTime(dtTamUng.Rows[i]["NgayHachToan"].ToString());
                DataTable dt1 = cls.LoadTable("select * from DanhSachTaiKhoan where TaiKhoan=N'" + TaiKhoan + "'");
                SoTien = 0;
                if (dt1.Rows.Count > 0)
                {
                    row["TenLaiXe"] = dt1.Rows[0]["HoVaTen"].ToString();
                    var t4 = (from a in context.PhieuChi_LaiXe_CT
                              join b in context.PhieuChi_LaiXe on a.IDPhieuChi equals b.IDPhieuChi
                              select new { a.SoTien, b.NgayHachToan,a.MaDoiTuong,a.SoChungTu })
                        .Where(p =>  p.MaDoiTuong == TaiKhoan&&p.SoChungTu==SoChungTu && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                    foreach (var item in t4)
                    {
                        SoTien += item.SoTien.Value;
                    }
                    row["PhatSinh_TamUng"] = SoTien;
                    row["PhatSinh_ThuCuoc"] = 0;
                }
                //lấy cột soFile lưu số chứng từ phiếu chi tạm ứng (27/11/2024)
                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_LaiXe_CT A left
                             join PhieuThu_LaiXe B on A.SoChungTu = B.SoChungTu where A.LaPhieuHoanUng=1 and A.Sofile='" + row["SoChungTu"].ToString().Trim() + "' and A.MaDoituong=N'" + TaiKhoan + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DaThu_TamUng"] = ThuTien;
                row["DaThu_ThuCuoc"] = 0;
                row["ConLai_TamUng"] = SoTien - ThuTien;
                row["ConLai_ThuCuoc"] = 0;
                dt.Rows.Add(row);
            }
            sqlFile = "select  * from BangDieuXe A where LaiXeThuCuoc>0 and  LaiXe=N'" + TaiKhoan + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0";
            DataTable dtThuCuoc = cls.LoadTable(sqlFile);
            for (int i = 0; i < dtThuCuoc.Rows.Count; i++)
            {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0;
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                string MaDieuXe = dtThuCuoc.Rows[i]["MaDieuXe"].ToString();
                row["MaDieuXe"] = MaDieuXe;
                row["TaiKhoan"] = TaiKhoan;
                row["Ngay"] = Convert.ToDateTime(dtThuCuoc.Rows[i]["Ngay"].ToString());
                DataTable dt1 = cls.LoadTable("select * from DanhSachTaiKhoan where TaiKhoan=N'" + TaiKhoan + "'");
                SoTien = 0;
                if (dt1.Rows.Count > 0)
                {
                    row["TenLaiXe"] = dt1.Rows[0]["HoVaTen"].ToString();
                    SoTien= double.Parse(dtThuCuoc.Rows[i]["LaiXeThuCuoc"].ToString());
                    row["PhatSinh_ThuCuoc"] = double.Parse(dtThuCuoc.Rows[i]["LaiXeThuCuoc"].ToString());
                    row["PhatSinh_TamUng"] = 0;
                }
                string sql2 = @"select isnull(sum(ThanhTien),0) from PhieuThu_LaiXe_CT A left
                             join PhieuThu_LaiXe B on A.SoChungTu = B.SoChungTu where A.LaPhieuHoanUng=0 and A.MaDieuXe='" + row["MaDieuXe"].ToString().Trim() + "' and A.MaDoituong=N'" + TaiKhoan + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',B.NgayHachToan)<=0";
                DataTable dt2 = cls.LoadTable(sql2);
                if (dt2.Rows.Count > 0)
                    ThuTien = double.Parse(dt2.Rows[0][0].ToString());
                else
                    ThuTien = 0;
                row["DaThu_TamUng"] = 0;
                row["DaThu_ThuCuoc"] = ThuTien;
                row["ConLai_ThuCuoc"] = SoTien - ThuTien;
                row["ConLai_TamUng"] = 0;
                dt.Rows.Add(row);
            }
            DataView view = dt.DefaultView;
            // view.RowFilter = "NoCuoiKi>0";
            DataView view1 = view.ToTable().Copy().DefaultView;
            view1.Sort = "Ngay asc";
            dt = view1.ToTable();
            dt.TableName = "CongNo";

            return dt;
        }
        [WebMethod]
        public void XoaDL(string ngay)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select * from ThongTinFile where datediff(day,'" + ngay + "',ThoiGianThucHien)<=0";
            DataTable dt = cls.LoadTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string SoFile = dt.Rows[i]["SoFile"].ToString().Trim();
                //xoa thong tin file
                cls.UpdateTable("delete from ThongTinFile where datediff(day,'" + ngay + "',ThoiGianThucHien)<=0");
                //tien ung giao nhan
                cls.UpdateTable("delete from ThongTinFile_NguoiGiaoNhan where SoFile='"+ SoFile+"'");
                //xoa bang ke chi phi
               cls.UpdateTable("delete from BangLietKeCP where IDLoHang=" + dt.Rows[i]["IDLoHang"].ToString().Trim());
                cls.UpdateTable("delete from BangLietKeCP_ChiTiet where IDLoHang=" + dt.Rows[i]["IDLoHang"].ToString().Trim());
                cls.UpdateTable("delete from BangLietKeCP_BoSung where IDLoHang=" + dt.Rows[i]["IDLoHang"].ToString().Trim());
                //bang dieu xe
                DataTable dtBangDieuXe = cls.LoadTable("select * from BangDieuXe where (Sofile='"+SoFile+ "') or (datediff(day,'" + ngay + "',Ngay)<=0)");
                for (int j = 0; j < dtBangDieuXe.Rows.Count; j++)
                {
                    cls.UpdateTable("delete from BangDieuXe_ChiTiet where IDBangPhi=" + dtBangDieuXe.Rows[j]["IDBangPhi"].ToString().Trim());
                }
                cls.UpdateTable("delete from BangDieuXe where datediff(day,'" + ngay + "',Ngay)<=0");
                //bang phi di duong
                DataTable dtBangPhiDiDuong = cls.LoadTable("select * from BangPhiDiDuong where (SoFile='" + SoFile+ "') or  (datediff(day,'" + ngay + "',Ngay)<=0)");
                for (int j = 0; j < dtBangPhiDiDuong.Rows.Count; j++)
                {
                    cls.UpdateTable("delete from BangPhiDiDuong_ChiKhac where IDBangPhi=" + dtBangPhiDiDuong.Rows[j]["IDBangPhi"].ToString().Trim());
                }
                cls.UpdateTable("delete from BangPhiDiDuong where datediff(day,'" + ngay + "',Ngay)<=0");
                //bang phoi nang ha
                cls.UpdateTable("delete from BangPhoiNangHa_ChiTiet where IDLoHang=" + dt.Rows[i]["IDLoHang"].ToString().Trim());
                cls.UpdateTable("delete from BangPhoiNangHa where IDLoHang=" + dt.Rows[i]["IDLoHang"].ToString().Trim());
                //thu
                DataTable dtBangThu = cls.LoadTable("select * from PhieuThu where   datediff(day,'" + ngay + "',NgayHachToan)<=0");
                for (int j = 0; j < dtBangThu.Rows.Count; j++)
                {
                    string _SoCT = dtBangThu.Rows[j]["SoChungTu"].ToString().Trim();
                    cls.UpdateTable("delete from PhieuThu_CT where SoChungTu='" + _SoCT+"'");
                    cls.UpdateTable("delete from PhieuThu where  SoChungTu='" + _SoCT + "'");
                }
                //thu giao nhan
                DataTable dtBangThuGN = cls.LoadTable("select * from PhieuThu_GiaoNhan where   datediff(day,'" + ngay + "',NgayHachToan)<=0");
                for (int j = 0; j < dtBangThuGN.Rows.Count; j++)
                {
                    string _SoCT = dtBangThuGN.Rows[j]["SoChungTu"].ToString().Trim();
                    cls.UpdateTable("delete from PhieuThu_GiaoNhan_CT where SoChungTu='" + _SoCT + "'");
                    cls.UpdateTable("delete from PhieuThu_GiaoNhan where  SoChungTu='" + _SoCT + "'");
                }
                //chi 
                DataTable dtBangChi = cls.LoadTable("select * from PhieuChi where   datediff(day,'" + ngay + "',NgayHachToan)<=0");
                for (int j = 0; j < dtBangChi.Rows.Count; j++)
                {
                    string _SoCT = dtBangChi.Rows[j]["SoChungTu"].ToString().Trim();
                    cls.UpdateTable("delete from PhieuChi_CT where SoChungTu='" + _SoCT + "'");
                    cls.UpdateTable("delete from PhieuChi where  SoChungTu='" + _SoCT + "'");
                }
                //chi ncc
                DataTable dtBangChiNCC = cls.LoadTable("select * from PhieuChi_NCC where   datediff(day,'" + ngay + "',NgayHachToan)<=0");
                for (int j = 0; j < dtBangChiNCC.Rows.Count; j++)
                {
                    string _SoCT = dtBangChiNCC.Rows[j]["SoChungTu"].ToString().Trim();
                    cls.UpdateTable("delete from PhieuChi_NCC_CT where SoChungTu='" + _SoCT + "'");
                    cls.UpdateTable("delete from PhieuChi_NCC where  SoChungTu='" + _SoCT + "'");
                }
                //file debit
                DataTable dtDebit = cls.LoadTable("select * from FileDebit where  IDLoHang="+ dt.Rows[i]["IDLoHang"].ToString().Trim());
                for (int j = 0; j < dtDebit.Rows.Count; j++)
                {
                    cls.UpdateTable("delete from FileDebitChiTiet where IDDeBit='" + dtDebit.Rows[j]["IDDeBit"].ToString().Trim() + "'");
                }
                cls.UpdateTable("delete from FileDebit where  IDLoHang='" + dt.Rows[i]["IDLoHang"].ToString().Trim() + "'");
                cls.UpdateTable("delete from FileDebit_KoHoaDon_KH where  datediff(day,'" + ngay + "',NgayTao)<=0");
                cls.UpdateTable("delete from FileDebit_KoHoaDon_NCC where  datediff(day,'" + ngay + "',NgayTao)<=0");
                //file gia
                DataTable dtFileGia = cls.LoadTable("select * from FileGia where  IDLoHang=" + dt.Rows[i]["IDLoHang"].ToString().Trim());
                for (int j = 0; j < dtFileGia.Rows.Count; j++)
                {
                    cls.UpdateTable("delete from FileGiaChiTiet where IDGia='" + dtFileGia.Rows[j]["IDGia"].ToString().Trim() + "'");
                }
                cls.UpdateTable("delete from FileGia where  IDLoHang='" + dt.Rows[i]["IDLoHang"].ToString().Trim() + "'");
            }
        }
        [WebMethod]
        public void PhieuCuoc_Luu(PhieuCuoc p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuCuocs.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void PhieuTamThu_Luu(PhieuTamThu p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuTamThus.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void PhieuCuoc_CapNhat(PhieuCuoc p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuCuocs.Single(a=>a.IDPhieuCuoc==p.IDPhieuCuoc);
            table.GhiChu = p.GhiChu;
            table.DaXacNhan = p.DaXacNhan;
            table.ThoiGianXacNhan = p.ThoiGianXacNhan;
            table.NguoiXacNhan = p.NguoiXacNhan;
            context.SaveChanges();
        }
        [WebMethod]
        public void PhieuTamThu_CapNhat(PhieuTamThu p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuTamThus.Single(a => a.IDTamThu == p.IDTamThu);
            table.GhiChu = p.GhiChu;
            table.DaXacNhan = p.DaXacNhan;
            table.ThoiGianXacNhan = p.ThoiGianXacNhan;
            table.NguoiXacNhan = p.NguoiXacNhan;
            context.SaveChanges();
        }
        [WebMethod]
        public void PhieuCuoc_Xoa(int IDPhieuCuoc)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuCuoc table = context.PhieuCuocs.Single(p=>p.IDPhieuCuoc==IDPhieuCuoc);
            context.PhieuCuocs.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public void PhieuTamThu_Xoa(int IDPhieuCuoc)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhieuTamThu table = context.PhieuTamThus.Single(p => p.IDTamThu == IDPhieuCuoc);
            context.PhieuTamThus.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable DauKy_Quy_Load()
        {
            clsKetNoi cls = new clsKetNoi();
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("quy");
            dt.Columns.Add("IDQuyCongNo");
            dt.Columns.Add("MaQuy");
            dt.Columns.Add("SoTK");
            dt.Columns.Add("TenNganHang");
            dt.Columns.Add("SDDK",typeof(double));
            dt.Columns.Add("NgayCapNhat");
            dt.Columns.Add("NguoiCapNhat");
            dt.Columns.Add("TenQuy");
            dt.Columns.Add("HinhThucTT");
            var table1 = (from a in context.DauKy_Quy
                        join b in context.DanhMucQuys on a.MaQuy equals b.MaQuy
                        select new 
                        {
                        a.IDQuyCongNo,
                        a.MaQuy,
                        b.TenQuy,
                        a.SDDK,
                        a.SoTK,
                        a.TenNganHang,
                        a.NgayCapNhat,
                        a.NguoiCapNhat,
                        a.HinhThucTT}).Where(p=>p.MaQuy!="");
            foreach (var item in table1)
            {
                DataRow row = dt.NewRow();
                row["IDQuyCongNo"] = item.IDQuyCongNo;
                row["MaQuy"] = item.MaQuy;
                row["SoTK"] = item.SoTK;
                row["TenNganHang"] = item.TenNganHang; 
                row["SDDK"] = item.SDDK;
                row["NgayCapNhat"] = item.NgayCapNhat;
                row["NguoiCapNhat"] = item.NguoiCapNhat;
                row["TenQuy"] = item.TenQuy;
                row["HinhThucTT"] = item.HinhThucTT;
                dt.Rows.Add(row);
            }
            //
            var table2 = (from a in context.DauKy_Quy
                          select new
                          {
                              a.IDQuyCongNo,
                              a.MaQuy,
                              TenQuy="",
                              a.SDDK,
                              a.SoTK,
                              a.TenNganHang,
                              a.NgayCapNhat,
                              a.NguoiCapNhat,
                              a.HinhThucTT
                          }).Where(p => p.MaQuy == "");
            foreach (var item in table2)
            {
                DataRow row = dt.NewRow();
                row["IDQuyCongNo"] = item.IDQuyCongNo;
                row["MaQuy"] = item.MaQuy;
                row["SoTK"] = item.SoTK;
                row["TenNganHang"] = item.TenNganHang;
                row["SDDK"] = item.SDDK;
                row["NgayCapNhat"] = item.NgayCapNhat;
                row["NguoiCapNhat"] = item.NguoiCapNhat;
                row["TenQuy"] = item.TenQuy;
                row["HinhThucTT"] = item.HinhThucTT;
                dt.Rows.Add(row);
            }
            return dt;
        }
        [WebMethod]
        public void DauKy_Quy_Luu(DauKy_Quy p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.DauKy_Quy.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void DauKy_Quy_CapNhat(DauKy_Quy p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table= context.DauKy_Quy.Single(a => a.IDQuyCongNo == p.IDQuyCongNo);
            table.MaQuy = p.MaQuy;
            table.SoTK = p.SoTK;
            table.TenNganHang = p.TenNganHang;
            table.NgayCapNhat = p.NgayCapNhat;
            table.NguoiCapNhat = p.NguoiCapNhat;
            table.HinhThucTT = p.HinhThucTT;
            table.SDDK = p.SDDK.Value;
            context.SaveChanges();
        }
        [WebMethod]
        public void DauKy_Quy_Xoa(int IDQuyCongNo)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DauKy_Quy table = context.DauKy_Quy.Single(a => a.IDQuyCongNo == IDQuyCongNo);
            context.DauKy_Quy.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable BaoCaoQuyTM(DateTime TuNgay,DateTime DenNgay)
        {
            DataTable dtTotal = new DataTable("total");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("tm");
            dt.Columns.Add("Ngay",typeof(DateTime));
            dt.Columns.Add("SoPhieu");
            dt.Columns.Add("DienGiai");
            dt.Columns.Add("Thu", typeof(double));
            dt.Columns.Add("Chi", typeof(double));
            dt.Columns.Add("DoiTuong");
            dt.Columns.Add("MaQuy");
            dt.Columns.Add("TenQuy");
            dt.Columns.Add("LyDo");
            dtTotal = dt.Copy();
            dtTotal.Rows.Clear();
            var t0 = context.DanhMucQuys;
            foreach (var item0 in t0)
            {
                dt.Rows.Clear();
                
                #region phieu thu
                //phieu thu hang hoa

                var t2 = (from a in context.PhieuThu_CT
                          join b in context.PhieuThus on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t2 =  context.PhieuThus
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t2)
                {
                    DataRow row1 = dt.NewRow();
                    row1["MaQuy"] = item0.MaQuy;
                    row1["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuThu_CT.Where(p=>p.SoChungTu==item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row1["Thu"] = SoTien;
                    row1["Chi"] = 0;
                    row1["Ngay"] = item2.NgayHachToan;
                    row1["DienGiai"] = item2.DienGiai;
                    row1["LyDo"] = item2.LyDoThu;
                    row1["SoPhieu"] = item2.SoChungTu;
                    if (DT.ToUpper().ToUpper()=="KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p=>p.MaKhachHang== MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                   else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row1);
                }
                //giao nhan

                var t3 = (from a in context.PhieuThu_GiaoNhan_CT
                          join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t3 = context.PhieuThu_GiaoNhan
                //        .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //        DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t3)
                {
                    DataRow row2 = dt.NewRow();
                    row2["MaQuy"] = item0.MaQuy;
                    row2["TenQuy"] = item0.TenQuy;
                 
                    var tx = context.PhieuThu_GiaoNhan_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row2["Thu"] = SoTien;
                    row2["Chi"] = 0;
                    row2["Ngay"] = item.NgayHachToan;
                    row2["DienGiai"] = item.DienGiai;
                    row2["LyDo"] = item.LyDoThu;
                    row2["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row2);
                }
                //lai xe

                var t4 = (from a in context.PhieuThu_LaiXe_CT
                          join b in context.PhieuThu_LaiXe on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t4 = context.PhieuThu_LaiXe 
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t4)
                {
                    DataRow row3 = dt.NewRow();
                    row3["MaQuy"] = item0.MaQuy;
                    row3["TenQuy"] = item0.TenQuy;
                  
                    var tx = context.PhieuThu_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row3["Thu"] = SoTien;
                    row3["Chi"] = 0;
                    row3["Ngay"] = item.NgayHachToan;
                    row3["DienGiai"] = item.DienGiai;
                    row3["LyDo"] = item.LyDoThu;
                    row3["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row3);
                }
                //thu noi bo

                var t5 = (from a in context.PhieuThu_NoiBo_CT
                          join b in context.PhieuThu_NoiBo on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t5 = context.PhieuThu_NoiBo
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t5)
                {
                    DataRow row4 = dt.NewRow();
                    row4["MaQuy"] = item0.MaQuy;
                    row4["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuThu_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row4["Thu"] = SoTien;
                    row4["Chi"] = 0;
                    row4["Ngay"] = item.NgayHachToan;
                    row4["DienGiai"] = item.DienGiai;
                    row4["LyDo"] = item.LyDoThu;
                    row4["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row4);
                }
                #endregion
                #region phieu chi
               // phieu chi hang hoa

                var t22 = (from a in context.PhieuChi_CT
                           join b in context.PhieuChis on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t22 = context.PhieuChis
                //          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t22)
                {
                    DataRow row11 = dt.NewRow();
                    row11["MaQuy"] = item0.MaQuy;
                    row11["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row11["Chi"] = SoTien;
                    row11["Thu"] = 0;
                    row11["Ngay"] = item2.NgayHachToan;
                    row11["DienGiai"] = item2.DienGiai;
                    row11["LyDo"] = item2.LyDoChi;
                    row11["SoPhieu"] = item2.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row11);
                }
                //chi lai xe

                var t33 = (from a in context.PhieuChi_LaiXe_CT
                           join b in context.PhieuChi_LaiXe on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan,  b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t33 = context.PhieuChi_LaiXe
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t33)
                {
                    DataRow row22 = dt.NewRow();
                    row22["MaQuy"] = item0.MaQuy;
                    row22["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row22["Chi"] = SoTien;
                    row22["Thu"] = 0;
                    row22["Ngay"] = item.NgayHachToan;
                    row22["DienGiai"] = item.DienGiai;
                    row22["LyDo"] = item.LyDoChi;
                    row22["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row22);
                }
                //chi nha cung cap

                var t44 = (from a in context.PhieuChi_NCC_CT
                           join b in context.PhieuChi_NCC on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t44 = context.PhieuChi_NCC
                //        .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //        DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t44)
                {
                    DataRow row33 = dt.NewRow();
                    row33["MaQuy"] = item0.MaQuy;
                    row33["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_NCC_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row33["Chi"] = SoTien;
                    row33["Thu"] = 0;
                    row33["Ngay"] = item.NgayHachToan;
                    row33["DienGiai"] = item.DienGiai;
                    row33["LyDo"] = item.LyDoChi;
                    row33["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row33);
                }
                //chi noi bo

                var t55 = (from a in context.PhieuChi_NoiBo_CT
                           join b in context.PhieuChi_NoiBo on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan,  b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t55 =  context.PhieuChi_NoiBo
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t55)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.MaQuy;
                    row44["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                var t66 = (from a in context.PhieuChi_Con_CT
                           join b in context.PhieuChi_Con on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t66)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.MaQuy;
                    row44["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_Con_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                #endregion
                //tinh toan cot Ton
                DataView view = dt.Copy().DefaultView;
                view.Sort = "Ngay asc";
                dt = view.ToTable();
                
                //return
                dtTotal.Merge(dt);
            }
            return dtTotal;
        }
        [WebMethod]
        public DataTable BaoCaoQuyTM_TheoQuy(DateTime TuNgay, DateTime DenNgay, string MaQuy)
        {
            DataTable dtTotal = new DataTable("total");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("tm");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("SoPhieu");
            dt.Columns.Add("DienGiai");
            dt.Columns.Add("Thu", typeof(double));
            dt.Columns.Add("Chi", typeof(double));
            dt.Columns.Add("DoiTuong");
            dt.Columns.Add("MaQuy");
            dt.Columns.Add("TenQuy");
            dt.Columns.Add("LyDo");
            dtTotal = dt.Copy();
            dtTotal.Rows.Clear();
            var t0 = context.DanhMucQuys.Where(p=>p.MaQuy==MaQuy);
            foreach (var item0 in t0)
            {
                dt.Rows.Clear();

                #region phieu thu
                //phieu thu hang hoa

                var t2 = (from a in context.PhieuThu_CT
                          join b in context.PhieuThus on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t2 =  context.PhieuThus
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t2)
                {
                    DataRow row1 = dt.NewRow();
                    row1["MaQuy"] = item0.MaQuy;
                    row1["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuThu_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row1["Thu"] = SoTien;
                    row1["Chi"] = 0;
                    row1["Ngay"] = item2.NgayHachToan;
                    row1["DienGiai"] = item2.DienGiai;
                    row1["LyDo"] = item2.LyDoThu;
                    row1["SoPhieu"] = item2.SoChungTu;
                    if (DT.ToUpper().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row1);
                }
                //giao nhan

                var t3 = (from a in context.PhieuThu_GiaoNhan_CT
                          join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t3 = context.PhieuThu_GiaoNhan
                //        .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //        DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t3)
                {
                    DataRow row2 = dt.NewRow();
                    row2["MaQuy"] = item0.MaQuy;
                    row2["TenQuy"] = item0.TenQuy;

                    var tx = context.PhieuThu_GiaoNhan_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row2["Thu"] = SoTien;
                    row2["Chi"] = 0;
                    row2["Ngay"] = item.NgayHachToan;
                    row2["DienGiai"] = item.DienGiai;
                    row2["LyDo"] = item.LyDoThu;
                    row2["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row2);
                }
                //lai xe

                var t4 = (from a in context.PhieuThu_LaiXe_CT
                          join b in context.PhieuThu_LaiXe on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t4 = context.PhieuThu_LaiXe 
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t4)
                {
                    DataRow row3 = dt.NewRow();
                    row3["MaQuy"] = item0.MaQuy;
                    row3["TenQuy"] = item0.TenQuy;

                    var tx = context.PhieuThu_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row3["Thu"] = SoTien;
                    row3["Chi"] = 0;
                    row3["Ngay"] = item.NgayHachToan;
                    row3["DienGiai"] = item.DienGiai;
                    row3["LyDo"] = item.LyDoThu;
                    row3["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row3);
                }
                //thu noi bo

                var t5 = (from a in context.PhieuThu_NoiBo_CT
                          join b in context.PhieuThu_NoiBo on a.SoChungTu equals b.SoChungTu
                          select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t5 = context.PhieuThu_NoiBo
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t5)
                {
                    DataRow row4 = dt.NewRow();
                    row4["MaQuy"] = item0.MaQuy;
                    row4["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuThu_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row4["Thu"] = SoTien;
                    row4["Chi"] = 0;
                    row4["Ngay"] = item.NgayHachToan;
                    row4["DienGiai"] = item.DienGiai;
                    row4["LyDo"] = item.LyDoThu;
                    row4["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row4);
                }
                #endregion
                #region phieu chi
                // phieu chi hang hoa

                var t22 = (from a in context.PhieuChi_CT
                           join b in context.PhieuChis on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t22 = context.PhieuChis
                //          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t22)
                {
                    DataRow row11 = dt.NewRow();
                    row11["MaQuy"] = item0.MaQuy;
                    row11["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row11["Chi"] = SoTien;
                    row11["Thu"] = 0;
                    row11["Ngay"] = item2.NgayHachToan;
                    row11["DienGiai"] = item2.DienGiai;
                    row11["LyDo"] = item2.LyDoChi;
                    row11["SoPhieu"] = item2.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row11);
                }
                //chi lai xe

                var t33 = (from a in context.PhieuChi_LaiXe_CT
                           join b in context.PhieuChi_LaiXe on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t33 = context.PhieuChi_LaiXe
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t33)
                {
                    DataRow row22 = dt.NewRow();
                    row22["MaQuy"] = item0.MaQuy;
                    row22["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row22["Chi"] = SoTien;
                    row22["Thu"] = 0;
                    row22["Ngay"] = item.NgayHachToan;
                    row22["DienGiai"] = item.DienGiai;
                    row22["LyDo"] = item.LyDoChi;
                    row22["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row22);
                }
                //chi nha cung cap

                var t44 = (from a in context.PhieuChi_NCC_CT
                           join b in context.PhieuChi_NCC on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t44 = context.PhieuChi_NCC
                //        .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //        DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t44)
                {
                    DataRow row33 = dt.NewRow();
                    row33["MaQuy"] = item0.MaQuy;
                    row33["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_NCC_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row33["Chi"] = SoTien;
                    row33["Thu"] = 0;
                    row33["Ngay"] = item.NgayHachToan;
                    row33["DienGiai"] = item.DienGiai;
                    row33["LyDo"] = item.LyDoChi;
                    row33["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row33);
                }
                //chi noi bo

                var t55 = (from a in context.PhieuChi_NoiBo_CT
                           join b in context.PhieuChi_NoiBo on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t55 =  context.PhieuChi_NoiBo
                //         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t55)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.MaQuy;
                    row44["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                var t66 = (from a in context.PhieuChi_Con_CT
                           join b in context.PhieuChi_Con on a.SoChungTu equals b.SoChungTu
                           select new { b.MaQuy, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                         .Where(p => p.MaQuy == item0.MaQuy && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t66)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.MaQuy;
                    row44["TenQuy"] = item0.TenQuy;
                    var tx = context.PhieuChi_Con_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                #endregion
                //tinh toan cot Ton
                DataView view = dt.Copy().DefaultView;
                view.Sort = "Ngay asc";
                dt = view.ToTable();

                //return
                dtTotal.Merge(dt);
            }
            return dtTotal;
        }
        [WebMethod]
        public double SDDK_Quy(DateTime TuNgay, string MaQuy)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double DauKy = 0;
            double Thu = 0, Chi = 0;
            DataTable dt=new DataTable();
            if (MaQuy == "")
            {
                var t0 = context.DanhMucQuys;
                foreach (var item in t0)
                {
                    var t1 = context.DauKy_Quy.Where(p => p.MaQuy == item.MaQuy);
                    foreach (var item1 in t1)
                    {
                        DauKy += item1.SDDK.Value;
                    }
                    dt = BaoCaoQuyTM_TheoQuy(new DateTime(1900, 1, 1), TuNgay.AddDays(-1), item.MaQuy);
                }
               
            }
            else
            {
                var t1 = context.DauKy_Quy.Where(p => p.MaQuy == MaQuy);
                foreach (var item1 in t1)
                {
                    DauKy += item1.SDDK.Value;
                }
                dt = BaoCaoQuyTM_TheoQuy(new DateTime(1900, 1, 1), TuNgay.AddDays(-1), MaQuy);
            }
           if(dt.Rows.Count>0)
            {
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Thu += double.Parse(dt.Rows[i]["Thu"].ToString());
                    Chi += double.Parse(dt.Rows[i]["Chi"].ToString());
                }
            }
            return DauKy+Thu-Chi;
        }
        [WebMethod]
        public double SDDK_TaiKhoan(DateTime TuNgay, string SoTK, string TenNganHang)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double DauKy = 0;
            double Thu = 0, Chi = 0;
            DataTable dt = new DataTable();
            if (SoTK=="")
            {
                var t0 = context.DanhMucNganHangs;
                foreach (var item in t0)
                {
                    var t1 = context.DauKy_Quy.Where(p => p.SoTK == item.SoTK && p.TenNganHang == item.TenNganHang);
                    foreach (var item1 in t1)
                    {
                        DauKy += item1.SDDK.Value;
                    }
                    dt = BaoCaoSoTK_TheoSoTK(new DateTime(1900, 1, 1), TuNgay.AddDays(-1), item.SoTK,item.TenNganHang);
                }
            }    
            else
            {
                var t1 = context.DauKy_Quy.Where(p => p.SoTK == SoTK && p.TenNganHang == TenNganHang);
                foreach (var item1 in t1)
                {
                    DauKy += item1.SDDK.Value;
                }
                dt = BaoCaoSoTK_TheoSoTK(new DateTime(1900, 1, 1), TuNgay.AddDays(-1), SoTK, TenNganHang);
            }
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Thu += double.Parse(dt.Rows[i]["Thu"].ToString());
                    Chi += double.Parse(dt.Rows[i]["Chi"].ToString());
                }
            }
            return DauKy + Thu - Chi;
        }
        [WebMethod]
        public DataTable BaoCaoSoTK(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dtTotal = new DataTable("total");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("tm");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("SoPhieu");
            dt.Columns.Add("DienGiai");
            dt.Columns.Add("Thu", typeof(double));
            dt.Columns.Add("Chi", typeof(double));
            dt.Columns.Add("DoiTuong");
            dt.Columns.Add("MaQuy");
            dt.Columns.Add("TenQuy");
            dt.Columns.Add("ChuTK");
            dt.Columns.Add("LyDo");
            dtTotal = dt.Copy();
            dtTotal.Rows.Clear();
            var t0 = context.DanhMucNganHangs;
            foreach (var item0 in t0)
            {
                dt.Rows.Clear();
               
                #region phieu thu
                //phieu thu hang hoa

                var t2 = (from a in context.PhieuThu_CT
                          join b in context.PhieuThus on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t2 = context.PhieuThus
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t2)
                {
                    DataRow row1 = dt.NewRow();
                    row1["MaQuy"] = item0.SoTK;
                    row1["TenQuy"] = item0.TenNganHang;
                    row1["ChuTK"] = item0.ChuTaiKhoan;
                    //row1["DauKy"] = 0;
                    var tx = context.PhieuThu_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row1["Thu"] = SoTien;
                    row1["Chi"] = 0;
                    row1["Ngay"] = item2.NgayHachToan;
                    row1["DienGiai"] = item2.DienGiai;
                    row1["LyDo"] = item2.LyDoThu;
                    row1["SoPhieu"] = item2.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row1);
                }
                //giao nhan

                var t3 = (from a in context.PhieuThu_GiaoNhan_CT
                          join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t3 = context.PhieuThu_GiaoNhan
                //          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t3)
                {
                    DataRow row2 = dt.NewRow();
                    row2["MaQuy"] = item0.SoTK;
                    row2["TenQuy"] = item0.TenNganHang;
                    row2["ChuTK"] = item0.ChuTaiKhoan;
                    var tx = context.PhieuThu_GiaoNhan_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row2["Thu"] = SoTien;
                    row2["Chi"] = 0;
                    row2["Ngay"] = item.NgayHachToan;
                    row2["DienGiai"] = item.DienGiai;
                    row2["LyDo"] = item.LyDoThu;
                    row2["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row2);
                }
                //lai xe

                var t4 = (from a in context.PhieuThu_LaiXe_CT
                          join b in context.PhieuThu_LaiXe on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t4 = context.PhieuThu_LaiXe
                //          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t4)
                {
                    DataRow row3 = dt.NewRow();
                    row3["MaQuy"] = item0.SoTK;
                    row3["TenQuy"] = item0.TenNganHang;
                    row3["ChuTK"] = item0.ChuTaiKhoan;
                  //  row3["DauKy"] = 0;
                    var tx = context.PhieuThu_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row3["Thu"] = SoTien;
                    row3["Chi"] = 0;
                    row3["Ngay"] = item.NgayHachToan;
                    row3["DienGiai"] = item.DienGiai;
                    row3["LyDo"] = item.LyDoThu;
                    row3["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row3);
                }
                //thu noi bo

                var t5 = (from a in context.PhieuThu_NoiBo_CT
                          join b in context.PhieuThu_NoiBo on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t5 = context.PhieuThu_NoiBo
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t5)
                {
                    DataRow row4 = dt.NewRow();
                    row4["MaQuy"] = item0.SoTK;
                    row4["TenQuy"] = item0.TenNganHang;
                    row4["ChuTK"] = item0.ChuTaiKhoan;
                   // row4["DauKy"] = 0;
                    var tx = context.PhieuThu_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row4["Thu"] = SoTien;
                    row4["Chi"] = 0;
                    row4["Ngay"] = item.NgayHachToan;
                    row4["DienGiai"] = item.DienGiai;
                    row4["LyDo"] = item.LyDoThu;
                    row4["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row4);
                }
                #endregion
                #region phieu chi
                //phieu chi hang hoa

                var t22 = (from a in context.PhieuChi_CT
                           join b in context.PhieuChis on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan,b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t22 = context.PhieuChis
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t22)
                {
                    DataRow row11 = dt.NewRow();
                    row11["MaQuy"] = item0.SoTK;
                    row11["TenQuy"] = item0.TenNganHang;
                    row11["ChuTK"] = item0.ChuTaiKhoan;
                  //  row11["DauKy"] = 0;
                    var tx = context.PhieuChi_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row11["Chi"] = SoTien;
                    row11["Thu"] = 0;
                    row11["Ngay"] = item2.NgayHachToan;
                    row11["DienGiai"] = item2.DienGiai;
                    row11["LyDo"] = item2.LyDoChi;
                    row11["SoPhieu"] = item2.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row11);
                }
                //chi lai xe

                var t33 = (from a in context.PhieuChi_LaiXe_CT
                           join b in context.PhieuChi_LaiXe on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan,  b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t33 = context.PhieuChi_LaiXe
                //          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t33)
                {
                    DataRow row22 = dt.NewRow();
                    row22["MaQuy"] = item0.SoTK;
                    row22["TenQuy"] = item0.TenNganHang;
                    row22["ChuTK"] = item0.ChuTaiKhoan;
                   // row22["DauKy"] = 0;
                    var tx = context.PhieuChi_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row22["Chi"] = SoTien;
                    row22["Thu"] = 0;
                    row22["Ngay"] = item.NgayHachToan;
                    row22["DienGiai"] = item.DienGiai;
                    row22["LyDo"] = item.LyDoChi;
                    row22["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row22);
                }
                //chi nha cung cap

                var t44 = (from a in context.PhieuChi_NCC_CT
                           join b in context.PhieuChi_NCC on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan,  b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t44 = context.PhieuChi_NCC
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t44)
                {
                    DataRow row33 = dt.NewRow();
                    row33["MaQuy"] = item0.SoTK;
                    row33["TenQuy"] = item0.TenNganHang;
                    row33["ChuTK"] = item0.ChuTaiKhoan;
                   // row33["DauKy"] = 0;
                    var tx = context.PhieuChi_NCC_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row33["Chi"] = SoTien;
                    row33["Thu"] = 0;
                    row33["Ngay"] = item.NgayHachToan;
                    row33["DienGiai"] = item.DienGiai;
                    row33["LyDo"] = item.LyDoChi;
                    row33["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row33);
                }
                //chi noi bo

                var t55 = (from a in context.PhieuChi_NoiBo_CT
                           join b in context.PhieuChi_NoiBo on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan,  b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu,b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t55 = context.PhieuChi_NoiBo
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t55)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.SoTK;
                    row44["TenQuy"] = item0.TenNganHang;
                    row44["ChuTK"] = item0.ChuTaiKhoan;
                   // row44["DauKy"] = 0;
                    var tx = context.PhieuChi_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                //phieu chi con
                var t66 = (from a in context.PhieuChi_Con_CT
                           join b in context.PhieuChi_Con on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t66)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.SoTK;
                    row44["TenQuy"] = item0.TenNganHang;
                    row44["ChuTK"] = item0.ChuTaiKhoan;
                  //  row44["DauKy"] = 0;
                    var tx = context.PhieuChi_Con_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                #endregion
                //tinh toan cot Ton
                DataView view = dt.Copy().DefaultView;
                view.Sort = "Ngay asc";
                dt = view.ToTable();
               
                //return
                dtTotal.Merge(dt);
            }
            return dtTotal;
        }
        [WebMethod]
        public DataTable BaoCaoSoTK_TheoSoTK(DateTime TuNgay, DateTime DenNgay, string SoTK, string TenNganHang)
        {
            DataTable dtTotal = new DataTable("total");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            clsKetNoi cls = new clsKetNoi();
            DataTable dt = new DataTable("tm");
            dt.Columns.Add("Ngay", typeof(DateTime));
            dt.Columns.Add("SoPhieu");
            dt.Columns.Add("DienGiai");
            dt.Columns.Add("Thu", typeof(double));
            dt.Columns.Add("Chi", typeof(double));
            dt.Columns.Add("DoiTuong");
            dt.Columns.Add("MaQuy");
            dt.Columns.Add("TenQuy");
            dt.Columns.Add("ChuTK");
            dt.Columns.Add("LyDo");
            dtTotal = dt.Copy();
            dtTotal.Rows.Clear();
            var t0 = context.DanhMucNganHangs.Where(p=>p.SoTK==SoTK&&p.TenNganHang==TenNganHang);
            foreach (var item0 in t0)
            {
                dt.Rows.Clear();
                #region phieu thu
                //phieu thu hang hoa

                var t2 = (from a in context.PhieuThu_CT
                          join b in context.PhieuThus on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t2 = context.PhieuThus
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t2)
                {
                    DataRow row1 = dt.NewRow();
                    row1["MaQuy"] = item0.SoTK;
                    row1["TenQuy"] = item0.TenNganHang;
                    row1["ChuTK"] = item0.ChuTaiKhoan;
                    //row1["DauKy"] = 0;
                    var tx = context.PhieuThu_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row1["Thu"] = SoTien;
                    row1["Chi"] = 0;
                    row1["Ngay"] = item2.NgayHachToan;
                    row1["DienGiai"] = item2.DienGiai;
                    row1["LyDo"] = item2.LyDoThu;
                    row1["SoPhieu"] = item2.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row1["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row1);
                }
                //giao nhan

                var t3 = (from a in context.PhieuThu_GiaoNhan_CT
                          join b in context.PhieuThu_GiaoNhan on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t3 = context.PhieuThu_GiaoNhan
                //          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t3)
                {
                    DataRow row2 = dt.NewRow();
                    row2["MaQuy"] = item0.SoTK;
                    row2["TenQuy"] = item0.TenNganHang;
                    row2["ChuTK"] = item0.ChuTaiKhoan;
                    // row2["DauKy"] = 0;
                    var tx = context.PhieuThu_GiaoNhan_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row2["Thu"] = SoTien;
                    row2["Chi"] = 0;
                    row2["Ngay"] = item.NgayHachToan;
                    row2["DienGiai"] = item.DienGiai;
                    row2["LyDo"] = item.LyDoThu;
                    row2["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row2["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row2);
                }
                //lai xe

                var t4 = (from a in context.PhieuThu_LaiXe_CT
                          join b in context.PhieuThu_LaiXe on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, b.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t4 = context.PhieuThu_LaiXe
                //          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t4)
                {
                    DataRow row3 = dt.NewRow();
                    row3["MaQuy"] = item0.SoTK;
                    row3["TenQuy"] = item0.TenNganHang;
                    row3["ChuTK"] = item0.ChuTaiKhoan;
                    //  row3["DauKy"] = 0;
                    var tx = context.PhieuThu_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row3["Thu"] = SoTien;
                    row3["Chi"] = 0;
                    row3["Ngay"] = item.NgayHachToan;
                    row3["DienGiai"] = item.DienGiai;
                    row3["LyDo"] = item.LyDoThu;
                    row3["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row3["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row3);
                }
                //thu noi bo

                var t5 = (from a in context.PhieuThu_NoiBo_CT
                          join b in context.PhieuThu_NoiBo on a.SoChungTu equals b.SoChungTu
                          select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoThu, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t5 = context.PhieuThu_NoiBo
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t5)
                {
                    DataRow row4 = dt.NewRow();
                    row4["MaQuy"] = item0.SoTK;
                    row4["TenQuy"] = item0.TenNganHang;
                    row4["ChuTK"] = item0.ChuTaiKhoan;
                    // row4["DauKy"] = 0;
                    var tx = context.PhieuThu_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row4["Thu"] = SoTien;
                    row4["Chi"] = 0;
                    row4["Ngay"] = item.NgayHachToan;
                    row4["DienGiai"] = item.DienGiai;
                    row4["LyDo"] = item.LyDoThu;
                    row4["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row4["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row4);
                }
                #endregion
                #region phieu chi
                //phieu chi hang hoa

                var t22 = (from a in context.PhieuChi_CT
                           join b in context.PhieuChis on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t22 = context.PhieuChis
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item2 in t22)
                {
                    DataRow row11 = dt.NewRow();
                    row11["MaQuy"] = item0.SoTK;
                    row11["TenQuy"] = item0.TenNganHang;
                    row11["ChuTK"] = item0.ChuTaiKhoan;
                    //  row11["DauKy"] = 0;
                    var tx = context.PhieuChi_CT.Where(p => p.SoChungTu == item2.SoChungTu);
                    double SoTien = item2.ThanhTien.Value;
                    string DT = item2.DoiTuong, MaDT = item2.MaDoiTuong;
                    row11["Chi"] = SoTien;
                    row11["Thu"] = 0;
                    row11["Ngay"] = item2.NgayHachToan;
                    row11["DienGiai"] = item2.DienGiai;
                    row11["LyDo"] = item2.LyDoChi;
                    row11["SoPhieu"] = item2.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item in t00)
                        {
                            row11["DoiTuong"] = item.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row11);
                }
                //chi lai xe

                var t33 = (from a in context.PhieuChi_LaiXe_CT
                           join b in context.PhieuChi_LaiXe on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t33 = context.PhieuChi_LaiXe
                //          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t33)
                {
                    DataRow row22 = dt.NewRow();
                    row22["MaQuy"] = item0.SoTK;
                    row22["TenQuy"] = item0.TenNganHang;
                    row22["ChuTK"] = item0.ChuTaiKhoan;
                    // row22["DauKy"] = 0;
                    var tx = context.PhieuChi_LaiXe_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row22["Chi"] = SoTien;
                    row22["Thu"] = 0;
                    row22["Ngay"] = item.NgayHachToan;
                    row22["DienGiai"] = item.DienGiai;
                    row22["LyDo"] = item.LyDoChi;
                    row22["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row22["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row22);
                }
                //chi nha cung cap

                var t44 = (from a in context.PhieuChi_NCC_CT
                           join b in context.PhieuChi_NCC on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t44 = context.PhieuChi_NCC
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t44)
                {
                    DataRow row33 = dt.NewRow();
                    row33["MaQuy"] = item0.SoTK;
                    row33["TenQuy"] = item0.TenNganHang;
                    row33["ChuTK"] = item0.ChuTaiKhoan;
                    // row33["DauKy"] = 0;
                    var tx = context.PhieuChi_NCC_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row33["Chi"] = SoTien;
                    row33["Thu"] = 0;
                    row33["Ngay"] = item.NgayHachToan;
                    row33["DienGiai"] = item.DienGiai;
                    row33["LyDo"] = item.LyDoChi;
                    row33["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row33["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row33);
                }
                //chi noi bo

                var t55 = (from a in context.PhieuChi_NoiBo_CT
                           join b in context.PhieuChi_NoiBo on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                //var t55 = context.PhieuChi_NoiBo
                //         .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                //         DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t55)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.SoTK;
                    row44["TenQuy"] = item0.TenNganHang;
                    row44["ChuTK"] = item0.ChuTaiKhoan;
                    // row44["DauKy"] = 0;
                    var tx = context.PhieuChi_NoiBo_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                //phieu chi con
                var t66 = (from a in context.PhieuChi_Con_CT
                           join b in context.PhieuChi_Con on a.SoChungTu equals b.SoChungTu
                           select new { b.SoTK, b.TenNganHang, a.ThanhTien, b.NgayHachToan, b.LyDoChi, a.MaDoiTuong, a.DoiTuong, a.SoChungTu, b.DienGiai })
                          .Where(p => p.SoTK == item0.SoTK && p.TenNganHang == item0.TenNganHang && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 &&
                          DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
                foreach (var item in t66)
                {
                    DataRow row44 = dt.NewRow();
                    row44["MaQuy"] = item0.SoTK;
                    row44["TenQuy"] = item0.TenNganHang;
                    row44["ChuTK"] = item0.ChuTaiKhoan;
                    //  row44["DauKy"] = 0;
                    var tx = context.PhieuChi_Con_CT.Where(p => p.SoChungTu == item.SoChungTu);
                    double SoTien = item.ThanhTien.Value;
                    string DT = item.DoiTuong, MaDT = item.MaDoiTuong;
                    row44["Chi"] = SoTien;
                    row44["Thu"] = 0;
                    row44["Ngay"] = item.NgayHachToan;
                    row44["DienGiai"] = item.DienGiai;
                    row44["LyDo"] = item.LyDoChi;
                    row44["SoPhieu"] = item.SoChungTu;
                    if (DT.Trim().ToUpper() == "KH")
                    {
                        var t00 = context.DanhSachKhachHangs.Where(p => p.MaKhachHang == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NCC")
                    {
                        var t00 = context.DanhSachNhaCungCaps.Where(p => p.MaNhaCungCap == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenVietTat;
                        }
                    }
                    else if (DT.Trim().ToUpper() == "NV")
                    {
                        var t00 = context.NhanViens.Where(p => p.MaNhanVien == MaDT);
                        foreach (var item00 in t00)
                        {
                            row44["DoiTuong"] = item00.TenNhanVien;
                        }
                    }
                    dt.Rows.Add(row44);
                }
                #endregion
                //tinh toan cot Ton
                DataView view = dt.Copy().DefaultView;
                view.Sort = "Ngay asc";
                dt = view.ToTable();

                //return
                dtTotal.Merge(dt);
            }
            return dtTotal;
        }
       
        [WebMethod]
        public DataTable BaoCaoKetQuaKinhDoanh(DateTime TuNgay,DateTime DenNgay)
        {
            DataTable dt = new DataTable("kinhdoanh");
            dt.Columns.Add("DoanhThu_File", typeof(double));
            dt.Columns.Add("DoanhThu_KoFile", typeof(double));
            dt.Columns.Add("ChiPhi_File", typeof(double));
            dt.Columns.Add("PhiVanChuyen_KoFile", typeof(double));
            dt.Columns.Add("PhiKinhDoanh", typeof(double));
            dt.Columns.Add("LoiNhuan_TruocThue", typeof(double));
            dt.Columns.Add("Thue_TNDN", typeof(double));
            dt.Columns.Add("LoiNhuan_SauThue", typeof(double));
            dt.Columns.Add("ThoiGian");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            double DoanhThu_File = 0, DoanhThu_KoFile = 0, ChiPhi_File = 0, PhiVanChuyen_KoFile = 0, PhiKinhDoanh = 0, LoiNhuan_TruocThue = 0, Thue_TNDN = 0, LoiNhuan_SauThue = 0;
            //DoanhThu_File
            var t2 =(from a in context.FileGiaChiTiets
                    join b in context.FileGias on a.IDGia equals b.IDGia select new { a.GiaBan,b.ThoiGianLap})
                    .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 && DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            foreach (var item in t2)
            {
                DoanhThu_File += item.GiaBan.Value;
            }
            //DoanhThu_KoFile
            var t3 = context.BangDieuXes.Where(p => p.SoFile.Trim().Length<5 && DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 && DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0); 
            foreach (var item in t3)
            {
                var t_check = context.FileDebit_KoHoaDon_KH.Where(p=>p.MaDieuXe==item.MaDieuXe);
                if(t_check.Count()==0)
                   DoanhThu_KoFile += item.CuocBan.Value+item.LaiXeThuCuoc.Value;
            }
            var t33 = context.FileDebit_KoHoaDon_KH.Where(p =>  DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
            foreach (var item in t33)
            {
                DoanhThu_KoFile += item.DoanhThuThuan.Value;
            }
            //ChiPhi_File
            var t4 = (from a in context.FileGiaChiTiets
                      join b in context.FileGias on a.IDGia equals b.IDGia
                      select new { a.GiaMua, b.ThoiGianLap })
                    .Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 && DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0);
            foreach (var item in t4)
            {
                ChiPhi_File += item.GiaMua.Value;
            }
            //PhiVanChuyen_KoFile
            var t5 = context.BangDieuXes.Where(p => p.SoFile.Trim().Length < 5 && DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 && DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
            foreach (var item in t5)
            {
                PhiVanChuyen_KoFile += item.CuocMua.Value;
            }
            //PhiKinhDoanh
            var t6=(from a in context.PhieuChi_CT
                   join b in context.PhieuChis on a.SoChungTu equals b.SoChungTu
                   select new {b.NgayHachToan,b.MaChi,a.ThanhTien})
                   .Where(p =>p.MaChi=="004"&& DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0);
            foreach (var item in t6)
            {
                PhiKinhDoanh += item.ThanhTien.Value;
            }
            //LoiNhuan_TruocThue
            LoiNhuan_TruocThue = DoanhThu_File + DoanhThu_KoFile - ChiPhi_File - PhiVanChuyen_KoFile - PhiKinhDoanh;
            Thue_TNDN = LoiNhuan_TruocThue / 5;
            LoiNhuan_SauThue = LoiNhuan_TruocThue - Thue_TNDN;
            DataRow row = dt.NewRow();
            row["DoanhThu_File"] = DoanhThu_File;
            row["DoanhThu_KoFile"] = DoanhThu_KoFile;
            row["ChiPhi_File"] = ChiPhi_File;
            row["PhiVanChuyen_KoFile"] = PhiVanChuyen_KoFile;
            row["PhiKinhDoanh"] = PhiKinhDoanh;
            row["Thue_TNDN"] = Thue_TNDN;
            row["LoiNhuan_TruocThue"] = LoiNhuan_TruocThue;
            row["LoiNhuan_SauThue"] = LoiNhuan_SauThue;
            row["ThoiGian"] = string.Format("Từ ngày {0} đến ngày {1}",TuNgay.ToString("dd/MM/yyyy"),DenNgay.ToString("dd/MM/yyyy"));
            dt.Rows.Add(row);

            return dt;
        }
        [WebMethod]
        public List<BangTheoDoiNghiPhepNam>BangTheoDoi(DateTime TuNgay,DateTime DenNgay,string tk)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            if (tk.ToLower() == "admin")
            {
                var table = context.BangTheoDoiNghiPhepNams.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 &&
                             DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0);
                return table.ToList();
            }
            else
            {
                var table = context.BangTheoDoiNghiPhepNams.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayTao) >= 0 &&
                             DbFunctions.DiffDays(DenNgay, p.NgayTao) <= 0&&p.NguoiTao==tk);
                return table.ToList();
            }
        }
        [WebMethod]
        public void BangTheoDoi_Them(BangTheoDoiNghiPhepNam p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.BangTheoDoiNghiPhepNams.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void BangTheoDoi_Sua(BangTheoDoiNghiPhepNam p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangTheoDoiNghiPhepNams.Single(a=>a.IDNghiPhep==p.IDNghiPhep);
            table.NgayTao = p.NgayTao;
            table.NguoiTao = p.NguoiTao;
            table.LyDo = p.LyDo;
            table.NgayBatDau = p.NgayBatDau;
            table.NgayKetThuc = p.NgayKetThuc;
            table.CaNgay = p.CaNgay;
            context.SaveChanges();
        }
        [WebMethod]
        public void BangTheoDoi_Xoa(int IDNghiPhep)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            BangTheoDoiNghiPhepNam table= context.BangTheoDoiNghiPhepNams.Single(a => a.IDNghiPhep == IDNghiPhep);
            context.BangTheoDoiNghiPhepNams.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public List<BangTheoDoiNghiPhepNam> BangTheoDoi_TheoIDNghiPhep(int IDNghiPhep)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.BangTheoDoiNghiPhepNams.Where(p=>p.IDNghiPhep==IDNghiPhep);
            return table.ToList();
        }
        [WebMethod]
        public List<PhongBan>dsPhongBan()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.PhongBans.ToList();
        }
        [WebMethod]
        public void ThemPhongBan(PhongBan p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhongBan table = new PhongBan();
            table.MaPhongBan = p.MaPhongBan;
            table.TenPhongBan = p.TenPhongBan;
            table.GhiChu = p.GhiChu;
            context.PhongBans.Add(table);
            context.SaveChanges();
        }
        [WebMethod]
        public void SuaPhongBan(PhongBan b)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhongBans.Single(p=>p.IDPhongBan==b.IDPhongBan);
            table.MaPhongBan = b.MaPhongBan;
            table.TenPhongBan =b.TenPhongBan;
            table.GhiChu = b.GhiChu;
            context.SaveChanges();
        }
        [WebMethod]
        public void XoaPhongBan(PhongBan b)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhongBan table = context.PhongBans.Single(p => p.IDPhongBan == b.IDPhongBan);
            context.PhongBans.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public DataTable BangPhepNam_TongHop(DateTime TuNgay,DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("PhepNam");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenNhanVien");
            dt.Columns.Add("TongNgayNghi",typeof(double));
           
            var table = context.NhanViens.OrderBy(p => p.TenNhanVien);
            foreach (var item in table)
            {
                DataRow row = dt.NewRow();
                row["MaNhanVien"] = item.MaNhanVien;
                row["TenNhanVien"] = item.TenNhanVien;
                var table1 = context.DanhSachTaiKhoans.Where(p=>p.MaNhanVien==item.MaNhanVien).Take(1);
                foreach (var item1 in table1)
                {
                    row["TaiKhoan"] = item1.TaiKhoan;
                    var table2 = context.BangTheoDoiNghiPhepNams.Where(p=>p.NguoiTao.Contains(item1.TaiKhoan) && p.NgayBatDau>=TuNgay&&p.NgayKetThuc<=DenNgay);
                    double tong = 0;
                    foreach (var item2 in table2)
                    {
                        DateTime Tu = item2.NgayBatDau.Value;
                        DateTime Den = item2.NgayKetThuc.Value;
                        int soNgay = (Den - Tu).Days;
                        if (item2.CaNgay.Value)
                            tong += soNgay+1;
                        else
                            tong += (soNgay / 2)+0.5;
                    }
                    row["TongNgayNghi"] = tong;
                    dt.Rows.Add(row);
                }
            }
            dt.TableName = "PhepNam";
            return dt;
        }
        [WebMethod]
        public DataTable BangPhepNam_ChiTiet(DateTime TuNgay, DateTime DenNgay,string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("PhepNam");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("MaNhanVien");
            dt.Columns.Add("TenNhanVien");
            dt.Columns.Add("SoNgay", typeof(double));
            dt.Columns.Add("ThoiGian");
            dt.Columns.Add("LyDo");

            var table = (from a in context.NhanViens
                         join b in context.DanhSachTaiKhoans on a.MaNhanVien equals b.MaNhanVien
                         select new { a.MaNhanVien, a.TenNhanVien,b.TaiKhoan }).Where(p=>p.TaiKhoan==TaiKhoan).Take(1);
            foreach (var item in table)
            {

                var table2 = context.BangTheoDoiNghiPhepNams.Where(p => p.NguoiTao.Contains(TaiKhoan) && p.NgayBatDau >= TuNgay && p.NgayKetThuc <= DenNgay);
                foreach (var item2 in table2)
                {
                    DataRow row = dt.NewRow();
                    row["MaNhanVien"] = item.MaNhanVien;
                    row["TenNhanVien"] = item.TenNhanVien;
                    row["TaiKhoan"] = TaiKhoan;
                    double tong = 0;
                    DateTime Tu = item2.NgayBatDau.Value;
                    DateTime Den = item2.NgayKetThuc.Value;
                    int soNgay = (Den - Tu).Days;
                    if (item2.CaNgay.Value)
                        tong += soNgay+1;
                    else
                        tong += (soNgay / 2)+0.5;
                    row["SoNgay"] = tong;
                    row["ThoiGian"] = string.Format("{0} đến {1}", item2.NgayBatDau.Value.ToString("dd/MM/yyyy"), item2.NgayKetThuc.Value.ToString("dd/MM/yyyy"));
                    row["LyDo"] = item2.LyDo;
                    dt.Rows.Add(row);
                }
            }
            dt.TableName = "PhepNam";
            return dt;
        }
        //mua hang
        [WebMethod]
        public List<PhieuMua>DanhSachMuaHang_TheoNgay(DateTime TuNgay,DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuMuas.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 &&
                            DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuMua> DanhSachMuaHang_TheoIDPhieuMua(int IDPhieuMua)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuMuas.Where(p => p.IDPhieuMua==IDPhieuMua);
            return table.ToList();
        }

        [WebMethod]
        public List<PhieuMuaCT> DanhSachMuaHang_CT_TheoIDPhieuMua(int IDPhieuMua)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuMuaCTs.Where(p => p.IDPhieuMua==IDPhieuMua);
            return table.ToList();
        }
       
        public static string TaoMaSoPhieuMoi_Mua(DateTime ngayMua)
        {
            using (var db = new vua45987_vudacoEntities())
            {
                // 1. Chuyển ngày thành chuỗi định dạng dd/MM/yyyy
                string ngayStr = ngayMua.ToString("dd/MM/yyyy");

                // 2. Tìm các SoPhieu bắt đầu bằng "BHdd/MM/yyyy"
                var danhSachCungNgay = db.PhieuMuas
                    .Where(pb => pb.SoPhieu.StartsWith("MH" + ngayStr))
                    .Select(pb => pb.SoPhieu)
                    .ToList();

                int soMax = 0;

                if (danhSachCungNgay.Any())
                {
                    // 3. Lấy phần 4 số cuối từ SoPhieu và chuyển thành số
                    soMax = danhSachCungNgay
                        .Select(sp =>
                        {
                            string soCuoi = sp.Substring(sp.Length - 4); // lấy 4 ký tự cuối
                            return int.TryParse(soCuoi, out int so) ? so : 0;
                        })
                        .Max();
                }

                // 4. Tăng lên 1
                int soMoi = soMax + 1;

                // 5. Gắn lại chuỗi mã phiếu mới
                string soPhieuMoi = "MH" + ngayStr + "_" + soMoi.ToString("D4");

                return soPhieuMoi;
            }
        }
        [WebMethod]
        public void ThemPhieuMua(PhieuMua phieuMua,List<PhieuMuaCT>phieuMuaCT)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuMuas.Add(phieuMua);
            context.SaveChanges();
            int IDPhieuMua = 0;
            var tCheck = context.PhieuMuas.OrderByDescending(p=>p.IDPhieuMua).Take(1);
            foreach (var item in tCheck)
            {
                IDPhieuMua = item.IDPhieuMua;
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    for (int i = 0; i < phieuMuaCT.Count; i++)
                    {
                        PhieuMuaCT p = phieuMuaCT[i];
                        p.IDPhieuMua = IDPhieuMua;
                        context1.PhieuMuaCTs.Add(p);
                        context1.SaveChanges();
                    }
                }
            }
        }
        [WebMethod]
        public void XoaPhieuMua(int IDPhieuMua)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuMuas.Single(p=>p.IDPhieuMua==IDPhieuMua);
            context.PhieuMuas.Remove(table);
            context.SaveChanges();
            var tCheck = context.PhieuMuaCTs.Where(p=>p.IDPhieuMua==IDPhieuMua);
            var tCheck2 = context.PhieuMuaCTs.Where(p => p.IDPhieuMua == IDPhieuMua);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item in tCheck2)
                {
                    var table2 = context1.PhieuMuaCTs.Single(p=>p.IDPhieuMuaCT==item.IDPhieuMuaCT);
                    context1.PhieuMuaCTs.Remove(table2);
                    context1.SaveChanges();
                }
            }
        }
        //ban hang
      
        public  string TaoMaSoPhieuMoi(DateTime ngayBan)
        {
            using (var db = new vua45987_vudacoEntities())
            {
                // 1. Chuyển ngày thành chuỗi định dạng dd/MM/yyyy
                string ngayStr = ngayBan.ToString("dd/MM/yyyy");

                // 2. Tìm các SoPhieu bắt đầu bằng "BHdd/MM/yyyy"
                var danhSachCungNgay = db.PhieuBans
                    .Where(pb => pb.SoPhieu.StartsWith("BH" + ngayStr))
                    .Select(pb => pb.SoPhieu)
                    .ToList();

                int soMax = 0;

                if (danhSachCungNgay.Any())
                {
                    // 3. Lấy phần 4 số cuối từ SoPhieu và chuyển thành số
                    soMax = danhSachCungNgay
                        .Select(sp =>
                        {
                            string soCuoi = sp.Substring(sp.Length - 4); // lấy 4 ký tự cuối
                    return int.TryParse(soCuoi, out int so) ? so : 0;
                        })
                        .Max();
                }

                // 4. Tăng lên 1
                int soMoi = soMax + 1;

                // 5. Gắn lại chuỗi mã phiếu mới
                string soPhieuMoi = "BH" + ngayStr + "_" + soMoi.ToString("D4");

                return soPhieuMoi;
            }
        }

        [WebMethod]
        public string Top1SoPhieu_BanHang(DateTime TuNgay)
        {
            return TaoMaSoPhieuMoi(TuNgay);

        }

        [WebMethod]
        public string Top1SoPhieu_MuaHang(DateTime TuNgay)
        {
            return TaoMaSoPhieuMoi_Mua(TuNgay);

        }
        [WebMethod]
        public List<PhieuBan> DanhSachBanHang_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuBans.Where(p => DbFunctions.DiffDays(TuNgay, p.NgayBan) >= 0 &&
                            DbFunctions.DiffDays(DenNgay, p.NgayBan) <= 0);
            return table.ToList();
        }
        [WebMethod]
        public List<PhieuBan> DanhSachBanHang_TheoIDPhieuBan(int IDPhieuBan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuBans.Where(p => p.IDPhieuBan == IDPhieuBan);
            return table.ToList();
        }

        [WebMethod]
        public List<PhieuBanCT> DanhSachBanHang_CT_TheoIDPhieuBan(int IDPhieuBan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuBanCTs.Where(p => p.IDPhieuBan == IDPhieuBan);
            return table.ToList();
        }
        [WebMethod]
        public void ThemPhieuBan(PhieuBan phieuBan, List<PhieuBanCT> phieuBanCT)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhieuBans.Add(phieuBan);
            context.SaveChanges();
            int IDPhieuBan = 0;
            var tCheck = context.PhieuBans.OrderByDescending(p => p.IDPhieuBan).Take(1);
            foreach (var item in tCheck)
            {
                IDPhieuBan = item.IDPhieuBan;
                using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
                {
                    for (int i = 0; i < phieuBanCT.Count; i++)
                    {
                        PhieuBanCT p = phieuBanCT[i];
                        p.IDPhieuBan = IDPhieuBan;
                        context1.PhieuBanCTs.Add(p);
                        context1.SaveChanges();
                    }
                }
            }
        }
        [WebMethod]
        public void XoaPhieuBan(int IDPhieuBan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhieuBans.Single(p => p.IDPhieuBan == IDPhieuBan);
            context.PhieuBans.Remove(table);
            context.SaveChanges();
          
            var tCheck2 = context.PhieuBanCTs.Where(p => p.IDPhieuBan == IDPhieuBan);
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                foreach (var item in tCheck2)
                {
                    var table2 = context1.PhieuBanCTs.Single(p => p.IDPhieuBanCT == item.IDPhieuBanCT);
                    context1.PhieuBanCTs.Remove(table2);
                    context1.SaveChanges();
                }
            }
        }
        [WebMethod]
        public DataTable ThongKeLoiNhuan_TheoXe(DateTime TuNgay,DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("total");
            dt.Columns.Add("BienSoXe");
            dt.Columns.Add("DoanhThu", typeof(double));
            dt.Columns.Add("PhiDau", typeof(double));
            dt.Columns.Add("PhiDuongBo", typeof(double));
            dt.Columns.Add("PhiSuaChua", typeof(double));
            dt.Columns.Add("PhiKhac", typeof(double));
            dt.Columns.Add("PhiLuongLaiXe", typeof(double));
            dt.Columns.Add("PhiPhanBo", typeof(double));
            dt.Columns.Add("LaiVay", typeof(double));
            dt.Columns.Add("LoiNhuan", typeof(double));
            dt.Columns.Add("TySuat", typeof(double));
            var t1 = context.DanhSachXes;
            foreach (var item in t1)
            {
                DataRow row = dt.NewRow();
                row["BienSoXe"] = item.BienSoXe;
                double DoanhThu = 0, PhiDau = 0, PhiDuongBo = 0, PhiSuaChua = 0, PhiKhac = 0, PhiLuongLaiXe = 0, PhiPhanBo = 0, LaiVay = 0;
                var t2 = context.BangDieuXes.Where(p=>p.BienSoXe==item.BienSoXe&& DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 && DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
                foreach (var item2 in t2)
                {
                    if (item2.CuocBan != null)
                        DoanhThu += item2.CuocBan.Value;
                    if (item2.LaiXeThuCuoc != null)
                        DoanhThu += item2.LaiXeThuCuoc.Value;
                }
                row["DoanhThu"] = DoanhThu;
                var t3 = (from a in context.PhieuChi_Con_CT
                         join b in context.PhieuChi_Con on a.IDPhieuChi equals b.IDPhieuChi 
                         select new { b.NgayHachToan,b.MaChi,a.TenCongTrinh,a.SoTien}).Where(p => p.TenCongTrinh == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0&&p.MaChi.Contains("010"));
                foreach (var item2 in t3)
                {
                    if (item2.SoTien != null)
                        PhiDau += item2.SoTien.Value;
                }
                var t33 = (from a in context.PhieuMuaCTs
                          join b in context.PhieuMuas on a.IDPhieuMua equals b.IDPhieuMua
                           select new { b.NgayMua, b.MaChi, a.BienSoXe, a.SoTien }).Where(p => p.BienSoXe == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0 && p.MaChi.Contains("010"));
                foreach (var item2 in t33)
                {
                    if (item2.SoTien != null)
                        PhiDau += item2.SoTien.Value;
                }
                row["PhiDau"] = PhiDau;
                var t4 = (from a in context.PhieuChi_Con_CT
                          join b in context.PhieuChi_Con on a.IDPhieuChi equals b.IDPhieuChi
                          select new { b.NgayHachToan, b.MaChi, a.TenCongTrinh, a.SoTien }).Where(p => p.TenCongTrinh == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0 && p.MaChi.Contains("011"));
                foreach (var item2 in t4)
                {
                    if (item2.SoTien != null)
                        PhiDuongBo += item2.SoTien.Value;
                }
                var t44 = (from a in context.PhieuMuaCTs
                           join b in context.PhieuMuas on a.IDPhieuMua equals b.IDPhieuMua
                           select new { b.NgayMua, b.MaChi, a.BienSoXe, a.SoTien }).Where(p => p.BienSoXe == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0 && p.MaChi.Contains("011"));
                foreach (var item2 in t44)
                {
                    if (item2.SoTien != null)
                        PhiDuongBo += item2.SoTien.Value;
                }
                row["PhiDuongBo"] = PhiDuongBo;
                var t5 = (from a in context.PhieuChi_Con_CT
                          join b in context.PhieuChi_Con on a.IDPhieuChi equals b.IDPhieuChi
                          select new { b.NgayHachToan, b.MaChi, a.TenCongTrinh, a.SoTien }).Where(p => p.TenCongTrinh == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0 && p.MaChi.Contains("009"));
                foreach (var item2 in t5)
                {
                    if (item2.SoTien != null)
                        PhiSuaChua += item2.SoTien.Value;
                }
                var t55 = (from a in context.PhieuMuaCTs
                           join b in context.PhieuMuas on a.IDPhieuMua equals b.IDPhieuMua
                           select new { b.NgayMua, b.MaChi, a.BienSoXe, a.SoTien }).Where(p => p.BienSoXe == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0 && p.MaChi.Contains("009"));
                foreach (var item2 in t55)
                {
                    if (item2.SoTien != null)
                        PhiSuaChua += item2.SoTien.Value;
                }
                row["PhiSuaChua"] = PhiSuaChua;
                var t6 = (from a in context.PhieuChi_Con_CT
                          join b in context.PhieuChi_Con on a.IDPhieuChi equals b.IDPhieuChi
                          select new { b.NgayHachToan, b.MaChi, a.TenCongTrinh, a.SoTien }).Where(p => p.TenCongTrinh == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0 && p.MaChi.Contains("012"));
                foreach (var item2 in t6)
                {
                    if (item2.SoTien != null)
                        PhiKhac += item2.SoTien.Value;
                }
                var t66 = (from a in context.PhieuMuaCTs
                           join b in context.PhieuMuas on a.IDPhieuMua equals b.IDPhieuMua
                           select new { b.NgayMua, b.MaChi, a.BienSoXe, a.SoTien }).Where(p => p.BienSoXe == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0 && p.MaChi.Contains("012"));
                foreach (var item2 in t66)
                {
                    if (item2.SoTien != null)
                        PhiKhac += item2.SoTien.Value;
                }
                row["PhiKhac"] = PhiKhac;
                var t7 = (from a in context.PhieuChi_Con_CT
                          join b in context.PhieuChi_Con on a.IDPhieuChi equals b.IDPhieuChi
                          select new { b.NgayHachToan, b.MaChi, a.TenCongTrinh, a.SoTien }).Where(p => p.TenCongTrinh == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0 && p.MaChi.Contains("015"));
                foreach (var item2 in t7)
                {
                    if (item2.SoTien != null)
                        PhiLuongLaiXe += item2.SoTien.Value;
                }
                var t77 = (from a in context.PhieuMuaCTs
                           join b in context.PhieuMuas on a.IDPhieuMua equals b.IDPhieuMua
                           select new { b.NgayMua, b.MaChi, a.BienSoXe, a.SoTien }).Where(p => p.BienSoXe == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0 && p.MaChi.Contains("015"));
                foreach (var item2 in t77)
                {
                    if (item2.SoTien != null)
                        PhiLuongLaiXe += item2.SoTien.Value;
                }
                row["PhiLuongLaiXe"] = PhiLuongLaiXe;
                row["PhiPhanBo"] = PhiPhanBo;
                var t8 = (from a in context.PhieuChi_Con_CT
                          join b in context.PhieuChi_Con on a.IDPhieuChi equals b.IDPhieuChi
                          select new { b.NgayHachToan, b.MaChi, a.TenCongTrinh, a.SoTien }).Where(p => p.TenCongTrinh == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayHachToan) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayHachToan) <= 0 && p.MaChi.Contains("013"));
                foreach (var item2 in t8)
                {
                    if (item2.SoTien != null)
                        LaiVay += item2.SoTien.Value;
                }
                var t88 = (from a in context.PhieuMuaCTs
                           join b in context.PhieuMuas on a.IDPhieuMua equals b.IDPhieuMua
                           select new { b.NgayMua, b.MaChi, a.BienSoXe, a.SoTien }).Where(p => p.BienSoXe == item.BienSoXe && DbFunctions.DiffDays(TuNgay, p.NgayMua) >= 0 && DbFunctions.DiffDays(DenNgay, p.NgayMua) <= 0 && p.MaChi.Contains("013"));
                foreach (var item2 in t88)
                {
                    if (item2.SoTien != null)
                        LaiVay += item2.SoTien.Value;
                }
                row["LaiVay"] = LaiVay;
                double LoiNhuan = DoanhThu- PhiDau- PhiDuongBo- PhiSuaChua- PhiKhac- PhiLuongLaiXe- PhiPhanBo- LaiVay;
                row["LoiNhuan"] = LoiNhuan;


                if (DoanhThu <= 0)
                {
                    DoanhThu = 1;
                    LoiNhuan = 0;
                }
                double TySuat = Math.Round((LoiNhuan / DoanhThu) * 100,2);
                row["TySuat"] = TySuat;
                dt.Rows.Add(row);
            }
            dt.TableName = "total";
            return dt;
        }
   

        [WebMethod]
        public DataTable ThongKeLoiNhuanTheoTungLinhVuc(DateTime TuNgay,DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            DataTable dt = new DataTable("total");
            dt.Columns.Add("Ten");
            dt.Columns.Add("DoanhThu", typeof(double));
            dt.Columns.Add("ChiPhi", typeof(double));
            dt.Columns.Add("LoiNhuan", typeof(double));
            dt.Columns.Add("TySuat", typeof(double));
            #region thu tuc hai quan
            DataRow row = dt.NewRow();
            row["Ten"] = "Thủ tục hải quan";
            double DoanhThu1 = 0, ChiPhi1=0, LoiNhuan1=0, TySuat1=0;
            var t3 = (from a in context.FileGiaChiTiets
                      join b in context.FileGias on a.IDGia equals b.IDGia
                      select new { b.ThoiGianLap, a.GiaBan,a.GiaMua,a.TenDichVu }).Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 && DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0&&p.TenDichVu.Contains("Chi phí hải quan"));
            foreach (var item2 in t3)
            {
                if (item2.GiaBan != null)
                    DoanhThu1 += item2.GiaBan.Value;
                if (item2.GiaMua != null)
                    ChiPhi1 += item2.GiaMua.Value;
            }
            row["DoanhThu"] = DoanhThu1;
            row["ChiPhi"] = ChiPhi1;
            LoiNhuan1= DoanhThu1 - ChiPhi1;
            row["LoiNhuan"] = LoiNhuan1;
            if (DoanhThu1 <= 0)
                DoanhThu1 = 1;
            TySuat1 =Math.Round( (LoiNhuan1 / DoanhThu1) * 100,2);
            row["TySuat"] = TySuat1;
            dt.Rows.Add(row);
            #endregion
            #region Vận chuyển mua ngoài
            DataRow row1 = dt.NewRow();
            row1["Ten"] = "Vận chuyển mua ngoài";
            DoanhThu1 = 0; ChiPhi1 = 0; LoiNhuan1 = 0; TySuat1 = 0;
            var t4 =  context.BangDieuXes.Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 && DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0&&p.BienSoXe.Contains("Xe ngoài"));
            foreach (var item2 in t4)
            {
                if (item2.CuocBan != null)
                    DoanhThu1 += item2.CuocBan.Value;
                if (item2.CuocMua != null)
                    ChiPhi1 += item2.CuocMua.Value;
                if (item2.LaiXeThuCuoc != null)
                {
                    DoanhThu1 += item2.LaiXeThuCuoc.Value;
                   
                }
            }
            row1["DoanhThu"] = DoanhThu1;
            row1["ChiPhi"] = ChiPhi1;
            LoiNhuan1 = DoanhThu1 - ChiPhi1;
            row1["LoiNhuan"] = LoiNhuan1;
            if (DoanhThu1 <= 0)
                DoanhThu1 = 1;
            TySuat1 = Math.Round((LoiNhuan1 / DoanhThu1) * 100, 2);
            row1["TySuat"] = TySuat1;
            dt.Rows.Add(row1);
            #endregion
            #region Vận chuyển xe nhà
            DataRow row2 = dt.NewRow();
            row2["Ten"] = "Vận chuyển xe nhà";
            DoanhThu1 = 0; ChiPhi1 = 0; LoiNhuan1 = 0; TySuat1 = 0;
            var t222 = context.BangDieuXes.Where(p =>DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 && DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0 && p.BienSoXe.Contains("Xe ngoài") == false);
            foreach (var item2 in t222)
            {
                if (item2.CuocBan != null)
                    DoanhThu1 += item2.CuocBan.Value;
                if (item2.LaiXeThuCuoc != null)
                    DoanhThu1 += item2.LaiXeThuCuoc.Value;
            }
            row2["DoanhThu"] = DoanhThu1;
            DataTable dtDoanhThuXe = ThongKeLoiNhuan_TheoXe(TuNgay, DenNgay);
            for (int i = 0; i < dtDoanhThuXe.Rows.Count; i++)
            {
                if (dtDoanhThuXe.Rows[i]["PhiDau"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["PhiDau"].ToString());
                if (dtDoanhThuXe.Rows[i]["PhiDuongBo"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["PhiDuongBo"].ToString());
                if (dtDoanhThuXe.Rows[i]["PhiSuaChua"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["PhiSuaChua"].ToString());
                if (dtDoanhThuXe.Rows[i]["PhiKhac"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["PhiKhac"].ToString());
                if (dtDoanhThuXe.Rows[i]["PhiLuongLaiXe"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["PhiLuongLaiXe"].ToString());
                if (dtDoanhThuXe.Rows[i]["PhiPhanBo"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["PhiPhanBo"].ToString());
                if (dtDoanhThuXe.Rows[i]["LaiVay"].ToString() != "")
                    ChiPhi1 += double.Parse(dtDoanhThuXe.Rows[i]["LaiVay"].ToString());
            }
            row2["ChiPhi"] = ChiPhi1;
            LoiNhuan1 = DoanhThu1 - ChiPhi1;
            row2["LoiNhuan"] = LoiNhuan1;
            if (DoanhThu1 <= 0)
                DoanhThu1 = 1;
            TySuat1 = Math.Round((LoiNhuan1 / DoanhThu1) * 100, 2);
            row2["TySuat"] = TySuat1;
            dt.Rows.Add(row2);
            #endregion
            #region Lĩnh vực khác
            DataRow row4 = dt.NewRow();
            row4["Ten"] = "Lĩnh vực khác";
            DoanhThu1 = 0; ChiPhi1 = 0; LoiNhuan1 = 0; TySuat1 = 0;
            var t5 = (from a in context.FileGiaChiTiets
                      join b in context.FileGias on a.IDGia equals b.IDGia
                      select new { b.ThoiGianLap, a.GiaBan, a.GiaMua, a.TenDichVu,a.LinhVucKhac }).Where(p => DbFunctions.DiffDays(TuNgay, p.ThoiGianLap) >= 0 && DbFunctions.DiffDays(DenNgay, p.ThoiGianLap) <= 0 && p.LinhVucKhac==true);
            foreach (var item2 in t5)
            {
                if (item2.GiaBan != null)
                    DoanhThu1 += item2.GiaBan.Value;
                if (item2.GiaMua != null)
                    ChiPhi1 += item2.GiaMua.Value;
            }
            row4["DoanhThu"] = DoanhThu1;
            row4["ChiPhi"] = ChiPhi1;
            LoiNhuan1 = DoanhThu1 - ChiPhi1;
            row4["LoiNhuan"] = LoiNhuan1;
            if (DoanhThu1 <= 0)
                DoanhThu1 = 1;
            TySuat1 = Math.Round((LoiNhuan1 / DoanhThu1) * 100, 2);
            row4["TySuat"] = TySuat1;
            dt.Rows.Add(row4);
            #endregion
            dt.TableName = "total";
            return dt;
        }
        [WebMethod]
        public void ThemChiKhac_Web_Temp(ChiKhac_Web_Temp p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            ChiKhac_Web_Temp table = new ChiKhac_Web_Temp();
            table.TaiKhoan = p.TaiKhoan;
            table.NoiDungChi = p.NoiDungChi;
            table.SoTienChi = p.SoTienChi;
            context.ChiKhac_Web_Temp.Add(table);
            context.SaveChanges();
        }
        [WebMethod]
        public List<ChiKhac_Web_Temp> DanhSach_ChiKhac_Web_Temp(string TaiKhoan)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            return context.ChiKhac_Web_Temp.Where(p=>p.TaiKhoan==TaiKhoan).ToList();
        }
        [WebMethod]
        public void XoaChiKhac_Web_Temp(int IDChiTemp)
        {
            using (vua45987_vudacoEntities context=new vua45987_vudacoEntities())
            {
                ChiKhac_Web_Temp table = context.ChiKhac_Web_Temp.Single(p=>p.IDChiTemp==IDChiTemp);
                context.ChiKhac_Web_Temp.Remove(table);
                context.SaveChanges();
            }
        }
        [WebMethod]
        public string LoadSoChungTu_TSCD()
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.KhaiBao_TSCD;
            if (table.Count() == 0)
                return "TSCD0001";
            else
            {
                var maxCode = context.KhaiBao_TSCD
                .Where(ts => ts.SoChungTu.StartsWith("TSCD") && ts.SoChungTu.Length >= 8)
                .ToList() // <== Lấy về RAM để xử lý bằng LINQ to Objects
                .Select(ts => new
                {
                    Original = ts.SoChungTu,
                    NumberPart = int.TryParse(ts.SoChungTu.Substring(4), out var num) ? num : 0
                })
                .OrderByDescending(x => x.NumberPart)
                .FirstOrDefault();
                int nextNumber = (maxCode?.NumberPart ?? 0) + 1;
                string newCode = "TSCD" + nextNumber.ToString("D4");
                return newCode;
            }
        }
        [WebMethod]
        public void Them_TSCD(KhaiBao_TSCD p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.KhaiBao_TSCD.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void Sua_TSCD(KhaiBao_TSCD p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.KhaiBao_TSCD.Single(b=>b.IDKhauHao==p.IDKhauHao);
            table.GiaTri = p.GiaTri;
            table.GiaTriPhanBo = p.GiaTriPhanBo;
            table.MaTaiSan = p.MaTaiSan;
            table.TenTaiSan = p.TenTaiSan;
            table.Ngay = p.Ngay;
            table.NguoiTao = p.NguoiTao;
            table.SoChungTu = p.SoChungTu;
            table.ThoiGianPhanBo = p.ThoiGianPhanBo;
            int SoNgayTrongThang = DateTime.DaysInMonth(p.Ngay.Value.Year, p.Ngay.Value.Month);
            int SoNgayConLai = SoNgayTrongThang - p.Ngay.Value.Day+1;
            double KhauHaoLuyKe = Math.Round(p.GiaTriPhanBo.Value /(SoNgayTrongThang* SoNgayConLai),2);
            double GiaTriConLai = p.GiaTri.Value - KhauHaoLuyKe;
            DateTime NgayKetThuc = p.Ngay.Value.AddMonths(int.Parse(p.ThoiGianPhanBo.Value.ToString()));
            table.KhauHaoLuyKe = KhauHaoLuyKe;
            table.GiaTriConLai = GiaTriConLai;
            table.NgayKetThuc = NgayKetThuc;
            context.SaveChanges();
        }
        [WebMethod]
        public void Xoa_TSCD(int IDKhauHao)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            KhaiBao_TSCD table = context.KhaiBao_TSCD.Single(b => b.IDKhauHao == IDKhauHao);
            context.KhaiBao_TSCD.Remove(table);
            context.SaveChanges();
        }
        [WebMethod]
        public List<KhaiBao_TSCD>DS_TSCD(int IDKhauHao)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.KhaiBao_TSCD.Where(p=>p.IDKhauHao==IDKhauHao);
            return table.ToList();
        }
        [WebMethod]
        public List<KhaiBao_TSCD> DS_TSCD_TheoNgay(DateTime TuNgay,DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.KhaiBao_TSCD.Where(p =>DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
            return table.ToList();
        }
        //phan bo khau hao
        [WebMethod]
        public DataTable TSCD_CanPhanBo_TheoThang(int thang, int nam)
        {
            DataTable dtPhanBo = new DataTable("phanbo");
            dtPhanBo.Columns.Add("MaTaiSan");
            dtPhanBo.Columns.Add("TenTaiSan");
            dtPhanBo.Columns.Add("GiaTri",typeof(float));
            dtPhanBo.Columns.Add("ThoiGianPhanBo", typeof(float));
            dtPhanBo.Columns.Add("GiaTriPhanBo", typeof(float));
            dtPhanBo.Columns.Add("BienSoXe");
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var t = context.KhaiBao_TSCD.Where(p=>p.Ngay.Value.Year<=nam&&p.Ngay.Value.Month<=thang);
            foreach (var item in t)
            {

            }
            dtPhanBo.TableName = "phanbo";
            return dtPhanBo;
        }
        [WebMethod]
        public List<clsPhanBo_KhauHao_Tong> DS_PhanBo_KhauHao_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            using (var context = new vua45987_vudacoEntities())
            {
                var table = context.PhanBo_KhauHao
                    .Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
                                DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0)
                    .GroupBy(p => p.SoChungTu)
                    .Select(g => new clsPhanBo_KhauHao_Tong
                    {
                        SoChungTu = g.Key,
                        Ngay = g.OrderBy(x => x.Ngay.Value).Select(x => x.Ngay.Value).FirstOrDefault(),
                        NoiDungPhanBo = "Khấu hao TSCĐ tháng " +
                                        g.OrderBy(x => x.Ngay).Select(x => x.Ngay.Value.Month).FirstOrDefault().ToString() +
                                        " năm " +
                                        g.OrderBy(x => x.Ngay).Select(x => x.Ngay.Value.Year).FirstOrDefault().ToString(),
                        SoTienPhanBo = g.Sum(x => x.SoTienPhanBo ?? 0),
                        NguoiTao = g.OrderBy(x => x.Ngay).Select(x => x.NguoiTao).FirstOrDefault()
                    })
                    .ToList();

                return table;
            }
        }
        [WebMethod]
        public List<PhanBo_KhauHao> DS_PhanBo_KhauHaoCT_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhanBo_KhauHao.Where(p => DbFunctions.DiffDays(TuNgay, p.Ngay) >= 0 &&
            DbFunctions.DiffDays(DenNgay, p.Ngay) <= 0);
            return table.ToList();
        }
        [WebMethod]
        public List<PhanBo_KhauHao> DS_PhanBo_KhauHao(int IDPhanBo)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhanBo_KhauHao.Where(p => p.IDPhanBo == IDPhanBo);
            return table.ToList();
        }
        [WebMethod]
        public void Xoa_PhanBo_KhauHao(int IDPhanBo)
        {
            using(vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                var table1 = context1.PhanBo_KhauHao_DSXe.Where(p=>p.IDPhanBo==IDPhanBo);
                foreach (var item in table1)
                {
                    PhanBo_KhauHao_DSXe table2 = context1.PhanBo_KhauHao_DSXe.Single(b => b.IDCT == item.IDCT);
                    context1.PhanBo_KhauHao_DSXe.Remove(table2);
                    context1.SaveChanges();
                }
               
            }    
           vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            PhanBo_KhauHao table = context.PhanBo_KhauHao.Single(b => b.IDPhanBo == IDPhanBo);
            context.PhanBo_KhauHao.Remove(table);
            context.SaveChanges();
            //
           
        }
        [WebMethod]
        public void Them_PhanBo_KhauHao(PhanBo_KhauHao p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhanBo_KhauHao.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void Sua_PhanBo_KhauHao(PhanBo_KhauHao p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhanBo_KhauHao.Single(b => b.IDPhanBo == p.IDPhanBo);
            table.MaTaiSan = p.MaTaiSan;
            table.TenTaiSan = p.TenTaiSan;
            table.Ngay = p.Ngay;
            table.NguoiTao = p.NguoiTao;
            table.SoChungTu = p.SoChungTu;
            table.NoiDungPhanBo = p.NoiDungPhanBo;
            table.SoTienPhanBo = p.SoTienPhanBo;
            context.SaveChanges();
        }
        [WebMethod]
        public List<PhanBo_KhauHao_DSXe> DS_PhanBo_KhauHao_Xe(int IDPhanBo)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            var table = context.PhanBo_KhauHao_DSXe.Where(p => p.IDPhanBo == IDPhanBo);
            return table.ToList();
        }
        [WebMethod]
        public void Them_PhanBo_KhauHao_Xe(PhanBo_KhauHao_DSXe p)
        {
            vua45987_vudacoEntities context = new vua45987_vudacoEntities();
            context.PhanBo_KhauHao_DSXe.Add(p);
            context.SaveChanges();
        }
        [WebMethod]
        public void Sua_PhanBo_KhauHao_Xe(PhanBo_KhauHao_DSXe p)
        {
            using (vua45987_vudacoEntities context1 = new vua45987_vudacoEntities())
            {
                var table1 = context1.PhanBo_KhauHao_DSXe.Where(b => b.IDPhanBo == p.IDPhanBo);
                foreach (var item in table1)
                {
                    PhanBo_KhauHao_DSXe table2 = context1.PhanBo_KhauHao_DSXe.Single(b => b.IDCT == item.IDCT);
                    context1.PhanBo_KhauHao_DSXe.Remove(table2);
                    context1.SaveChanges();
                }

            }
            Them_PhanBo_KhauHao_Xe(p);
        }
    }
}
