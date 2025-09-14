using Quản_lý_vudaco.services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class ncc : IDisposable
    {
        private clsKetNoi cls;
        public ncc()
        {
            cls = new clsKetNoi();
        }
        public DataTable CongNoChiTietNhaCungCap(DateTime TuNgay, DateTime DenNgay, string MaNhaCungCap)
        {
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

            string _MaDieuXe = "";
            //theo so file
            DataTable dtF = cls.LoadTable(
                  "select distinct IDLoHang, SoFile from FileGia A " +
                  "left join FileGiaChiTiet B on A.IdGia = B.IDGia " +
                  "where B.MaNhaCungCap = N'" + MaNhaCungCap.Trim() + "' " +
                  "and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "', ThoiGianLap) <= 0"
              );
            string sqlFile =
                  "select distinct IDLoHang, " +
                  "(select top 1 SoFile from ThongTinFile where IDLoHang = BangPhoiNangHa.IDLoHang) as SoFile " +
                  "from BangPhoiNangHa " +
                  "where IDLoHang in ( " +
                      "select IDLoHang from BangPhoiNangHa_ChiTiet " +
                      "where MaNhaCungCap = N'" + MaNhaCungCap.Trim() + "' " +
                  ") and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "', NgayTaoBangKe) <= 0";

            DataTable dtFile = cls.LoadTable(sqlFile);
            dtFile.Merge(dtF);
            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                SoTien = 0; KhongFile_CuocBan = 0; KhongFile_ThanhTien = 0; ThuTien = 0; BangPhoiNangHa_ChiHo = 0; KhongFile_CuocMua = 0;
                TraTien = 0;
                DataRow row1 = dtFile.Rows[i];
                DataRow row = dt.NewRow();
                row["Chon"] = false;
                string tk = row1["SoFile"].ToString();
                row["SoFile"] = tk;
                // row["Ngay"] = Convert.ToDateTime(row1["NgayTaoBangKe"].ToString());
                //ngay lay theo file debit (27/11/2024)
                DataTable t_ngay = cls.LoadTable("SELECT ThoiGianLap FROM FileDebit WHERE SoFile = '" + tk + "'");

                foreach (DataRow item_t_ngay in t_ngay.Rows)
                {
                    row["Ngay"] = item_t_ngay["ThoiGianLap"]; // hoặc item.Field<DateTime>("ThoiGianLap")
                }

                row["SoHoaDon"] = "";//để code sau
                KhongFile_CuocMua = 0;
                KhongFile_ThanhTien = 0;
                double CuocMua = 0;
                string s = "select isnull(sum(GiaMua),0) from FileGiaChiTiet A left join FileGia B on A.IDGia=B.IDGia  where B.MaNhaCungCap=N'" + MaNhaCungCap.Trim() + "' and  SoFile ='" + tk + "' and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dts = cls.LoadTable(s);
                if (dts.Rows.Count > 0)
                    CuocMua = double.Parse(dts.Rows[0][0].ToString());
                else
                    CuocMua = 0;
                row["No_VanChuyen"] = KhongFile_CuocBan + KhongFile_ThanhTien + CuocMua;
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
                row["NoCuoiKi"] = double.Parse(row["No_Tong"].ToString()) - double.Parse(row["Thu_Tong"].ToString());
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
                DataTable t_sohd = cls.LoadTable("SELECT SoHoaDon FROM FileDebit_KoHoaDon_NCC WHERE MaDieuXe = '" + dtFile2.Rows[i]["MaDieuXe"].ToString() + "'");
                foreach (DataRow item_t_sohd in t_sohd.Rows)
                {
                    row["SoHoaDon"] = item_t_sohd["SoHoaDon"];//để code sau
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
                row["No_VanChuyen"] = KhongFile_CuocMua + KhongFile_ThanhTien + PhiCom;
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
                row["NoCuoiKi"] = double.Parse(row["No_Tong"].ToString()) - double.Parse(row["Thu_Tong"].ToString());
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
        public DataTable CongNoChiTietNhaCungCap_In(DateTime TuNgay, DateTime DenNgay, string MaNhaCungCap)
        {
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
            DataTable dtF = cls.LoadTable("select distinct IDLoHang,SoFile from FileGia A left join FileGiaChiTiet B on A.IdGia=B.IDGia where B.MaNhaCungCap =N'" + MaNhaCungCap.Trim() + "'  and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0");
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
                string s = "select * from FileGiaChiTiet A,FileGia B where B.SoFile='" + tk + "' and A.IDGia=B.IDGia and A.MaNhaCungCap=N'" + MaNhaCungCap.Trim() + "' and DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',ThoiGianLap)<=0";
                DataTable dts = cls.LoadTable(s);
                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    DataTable t = cls.LoadTable(
                         "SELECT TOP 1 LoaiXe_NCC, TuyenVC, BienSoXe FROM BangDieuXe WHERE SoFile = @sofile",
                         new[] { "@sofile" },
                         new object[] { tk },
                         1
                     );

                    if (t.Rows.Count > 0)
                    {
                        DataRow row_t = t.Rows[0];
                        _LoaiXe_NCC = row_t["LoaiXe_NCC"].ToString();
                        _TuyenVC = row_t["TuyenVC"].ToString();
                        _BienSoXe = row_t["BienSoXe"].ToString();
                    }
                    DataTable t1 = cls.LoadTable(
                         "SELECT SoCont FROM ThongTinFile WHERE SoFile = @sofile",
                         new[] { "@sofile" },
                         new object[] { tk },
                         1
                     );

                    foreach (DataRow row_t1 in t1.Rows)
                    {
                        _SoCont = row_t1["SoCont"].ToString();
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
                    // 1. Kiểm tra tồn tại dữ liệu BangPhoiNangHa_ChiTiet
                    DataTable tCheck = cls.LoadTable(
                        "SELECT TOP 1 * FROM BangPhoiNangHa_ChiTiet WHERE IDLoHang = @idLoHang AND MaNhaCungCap = @maNCC",
                        new[] { "@idLoHang", "@maNCC" },
                        new object[] { _IDLoHang, MaNhaCungCap },
                        2
                    );

                    if (tCheck.Rows.Count > 0)
                    {
                        // 2. Lấy dữ liệu từ BangDieuXe
                        DataTable t = cls.LoadTable(
                            "SELECT TOP 1 LoaiXe_NCC, TuyenVC, BienSoXe FROM BangDieuXe WHERE SoFile = @sofile",
                            new[] { "@sofile" },
                            new object[] { tk },
                            1
                        );

                        if (t.Rows.Count > 0)
                        {
                            _LoaiXe_NCC = t.Rows[0]["LoaiXe_NCC"].ToString();
                            _TuyenVC = t.Rows[0]["TuyenVC"].ToString();
                            _BienSoXe = t.Rows[0]["BienSoXe"].ToString();
                        }

                        // 3. Lấy dữ liệu từ ThongTinFile
                        DataTable t1 = cls.LoadTable(
                            "SELECT TOP 1 SoCont FROM ThongTinFile WHERE SoFile = @sofile",
                            new[] { "@sofile" },
                            new object[] { tk },
                            1
                        );

                        if (t1.Rows.Count > 0)
                        {
                            _SoCont = t1.Rows[0]["SoCont"].ToString();
                        }

                        // 4. Tạo dòng mới trong DataTable dt
                        DataRow row = dt.NewRow();
                        row["Ngay"] = DateTime.Parse(dts.Rows[k]["NgayTaoBangKe"].ToString());
                        row["SoFile"] = tk;
                        row["LoaiXe_NCC"] = _LoaiXe_NCC;
                        row["TuyenVC"] = _TuyenVC;
                        row["NoiDung"] = _TuyenVC;
                        row["SoTien"] = 0;
                        row["TienVAT"] = 0;
                        row["ThanhTien"] = 0;
                        row["BienSoXe"] = _BienSoXe;
                        row["SoCont"] = _SoCont;

                        string idLoHangStr = dts.Rows[k]["IDLoHang"].ToString().Trim();

                        // 5. Các phí liên quan
                        row["PhiNang"] = cls.LoadTable("SELECT ISNULL(SUM(SoTien_ChiHo), 0) FROM BangPhoiNangHa_ChiTiet WHERE MaChiHo='CH06' AND IDLoHang=@id AND MaNhaCungCap=@ncc",
                            new[] { "@id", "@ncc" }, new object[] { idLoHangStr, MaNhaCungCap }, 2).Rows[0][0].ToString();

                        row["PhiHa"] = cls.LoadTable("SELECT ISNULL(SUM(SoTien_ChiHo), 0) FROM BangPhoiNangHa_ChiTiet WHERE MaChiHo='CH07' AND IDLoHang=@id AND MaNhaCungCap=@ncc",
                            new[] { "@id", "@ncc" }, new object[] { idLoHangStr, MaNhaCungCap }, 2).Rows[0][0].ToString();

                        row["PhiNangHa"] = cls.LoadTable("SELECT ISNULL(SUM(SoTien_ChiHo), 0) FROM BangPhoiNangHa_ChiTiet WHERE MaChiHo='CH08' AND IDLoHang=@id AND MaNhaCungCap=@ncc",
                            new[] { "@id", "@ncc" }, new object[] { idLoHangStr, MaNhaCungCap }, 2).Rows[0][0].ToString();

                        row["PhiCSHT"] = cls.LoadTable("SELECT ISNULL(SUM(SoTien_ChiHo), 0) FROM BangPhoiNangHa_ChiTiet WHERE MaChiHo='CH09' AND IDLoHang=@id AND MaNhaCungCap=@ncc",
                            new[] { "@id", "@ncc" }, new object[] { idLoHangStr, MaNhaCungCap }, 2).Rows[0][0].ToString();

                        row["PhiKhac"] = cls.LoadTable("SELECT ISNULL(SUM(SoTien_ChiHo), 0) FROM BangPhoiNangHa_ChiTiet WHERE MaChiHo='CH12' AND IDLoHang=@id AND MaNhaCungCap=@ncc",
                            new[] { "@id", "@ncc" }, new object[] { idLoHangStr, MaNhaCungCap }, 2).Rows[0][0].ToString();

                        row["PhieuTamThu"] = cls.LoadTable("SELECT ISNULL(SUM(SoTien_ChiHo), 0) FROM BangPhoiNangHa_ChiTiet WHERE MaChiHo='CH15' AND IDLoHang=@id AND MaNhaCungCap=@ncc",
                            new[] { "@id", "@ncc" }, new object[] { idLoHangStr, MaNhaCungCap }, 2).Rows[0][0].ToString();

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
                string sql1 = @"SELECT * 
                FROM BangDieuXe 
                WHERE MaDieuXe NOT IN (
                    SELECT MaDieuXe FROM FileDebit_KoHoaDon_NCC WHERE MaNhaCungCap = N'" + MaNhaCungCap.Trim() + @"'
                ) 
                AND MaDieuXe = '" + tk.Trim() + @"' 
                AND MaNhaCungCap = N'" + MaNhaCungCap.Trim() + @"' 
                AND DATEDIFF(day, '" + TuNgay.ToString("yyyy-MM-dd") + @"', Ngay) >= 0 
                AND DATEDIFF(day, '" + DenNgay.ToString("yyyy-MM-dd") + @"', Ngay) <= 0";

                DataTable dts = cls.LoadTable(sql1);

                for (int k = 0; k < dts.Rows.Count; k++)
                {
                    string _f = dts.Rows[k]["SoFile"].ToString().Trim();
                    string file = _f;
                    string _LoaiXe_NCC = "", _TuyenVC = "", _BienSoXe = "", _SoCont = "", _SoHoaDon = "";

                    if (!string.IsNullOrEmpty(_f))
                    {
                        // Lấy thông tin từ BangDieuXe
                        string sql_dieuxe = "SELECT TOP 1 LoaiXe_NCC, TuyenVC, BienSoXe FROM BangDieuXe WHERE SoFile = '" + _f + "'";
                        DataTable t = cls.LoadTable(sql_dieuxe);
                        if (t.Rows.Count > 0)
                        {
                            _LoaiXe_NCC = t.Rows[0]["LoaiXe_NCC"].ToString();
                            _TuyenVC = t.Rows[0]["TuyenVC"].ToString();
                            _BienSoXe = t.Rows[0]["BienSoXe"].ToString();
                        }

                        // Lấy SoCont từ ThongTinFile
                        string sql_ttfile = "SELECT TOP 1 SoCont FROM ThongTinFile WHERE SoFile = '" + _f + "'";
                        DataTable t1 = cls.LoadTable(sql_ttfile);
                        if (t1.Rows.Count > 0)
                        {
                            _SoCont = t1.Rows[0]["SoCont"].ToString();
                        }
                    }

                    // Lấy SoHoaDon từ FileDebit_KoHoaDon_NCC
                    string sql_sohd = "SELECT TOP 1 SoHoaDon FROM FileDebit_KoHoaDon_NCC WHERE MaDieuXe = '" + tk + "'";
                    DataTable t_sohd = cls.LoadTable(sql_sohd);
                    if (t_sohd.Rows.Count > 0)
                    {
                        _SoHoaDon = t_sohd.Rows[0]["SoHoaDon"].ToString();
                    }

                    // Thêm vào datatable
                    DataRow row = dt.NewRow();
                    row["Ngay"] = DateTime.Parse(dts.Rows[k]["Ngay"].ToString());
                    row["SoFile"] = (!string.IsNullOrEmpty(file)) ? file : tk;
                    row["SoHoaDon"] = _SoHoaDon;
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
                    DataTable dtSoHoaDon = cls.LoadTable("SELECT TOP 1 SoHoaDon FROM FileDebit_KoHoaDon_NCC WHERE MaDieuXe = '" + tk + "'");
                    if (dtSoHoaDon.Rows.Count > 0)
                    {
                        row["SoHoaDon"] = dtSoHoaDon.Rows[0]["SoHoaDon"].ToString();
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
        public double DauKy_NCC(string MaNhaCungCap, DateTime TuNgay, DateTime DenNgay)
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
        public double ThanhToan_NCC(string MaNhaCungCap, DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            double TraTien = 0, ThanhToan_VanChuyen = 0, ThanhToan_NangHa = 0;
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
        public DataTable DsThongTinFile(DateTime TuNgay, DateTime DenNgay)
        {
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
            string sql = string.Format(@"
                SELECT
                    f.IDLoHang,
                    kh.TenKhachHang,
                    kh.TenVietTat,
                    f.SoFile,
                    f.SoToKhai,
                    f.SoBill,
                    f.SoLuong,
                    f.SoCont,
                    f.TenSales,
                    ISNULL(ngn.TenGiaoNhan, '') AS TenGiaoNhan,
                    f.LoaiHang,
                    f.TinhChat,
                    f.SoLuongToKhai,
                    f.LoaiToKhai,
                    f.NghiepVu,
                    f.PhatSinh,
                    ISNULL(du.TongDuyetUng,0) AS DuyetUng,
                    f.TaiKhoanThucHien,
                    f.ThoiGianThucHien,
                    f.GhiChu
                FROM ThongTinFile f
                LEFT JOIN DanhSachKhachHang kh ON kh.MaKhachHang = f.MaKhachHang
                LEFT JOIN (
                    SELECT a.SoFile,
                           STRING_AGG(b.TenNhanVien, ',') AS TenGiaoNhan
                    FROM ThongTinFile_NguoiGiaoNhan a
                    INNER JOIN NhanVien b ON a.MaNhanVien = b.MaNhanVien
                    GROUP BY a.SoFile
                ) ngn ON ngn.SoFile = f.SoFile
                LEFT JOIN (
                    SELECT SoFile, SUM(ISNULL(DuyetUng,0)) AS TongDuyetUng
                    FROM ThongTinFile_NguoiGiaoNhan
                    GROUP BY SoFile
                ) du ON du.SoFile = f.SoFile
                WHERE f.ThoiGianThucHien >= '{0}' AND f.ThoiGianThucHien <= '{1}'",
                TuNgay.ToString("yyyy-MM-dd"), DenNgay.ToString("yyyy-MM-dd"));

            DataTable table = cls.LoadTable(sql);

            foreach (DataRow item in table.Rows)
            {
                stt++;
                DataRow row = dt.NewRow();

                row["STT"] = stt;
                row["IDLoHang"] = item["IDLoHang"];
                row["MaKhachHang"] = item["TenKhachHang"];
                row["TenVietTat"] = item["TenVietTat"];
                row["SoFile"] = item["SoFile"];
                row["SoToKhai"] = item["SoToKhai"];
                row["SoBill"] = item["SoBill"];
                row["SoLuong"] = item["SoLuong"];
                row["SoCont"] = item["SoCont"];
                row["TenSales"] = item["TenSales"];
                row["TenGiaoNhan"] = item["TenGiaoNhan"];

                // LoaiHang
                string loaiHang = item["LoaiHang"].ToString().Trim();
                if (loaiHang == "HangLe")
                    row["LoaiHang"] = "Hàng Lẻ";
                else if (loaiHang == "HangCont")
                    row["LoaiHang"] = "Hàng Cont";
                else
                    row["LoaiHang"] = "";

                // TinhChat
                string tinhChat = item["TinhChat"].ToString().Trim();
                if (tinhChat == "HangNhap")
                    row["TinhChat"] = "Hàng nhập";
                else if (tinhChat == "HangXuat")
                    row["TinhChat"] = "Hàng xuất";
                else
                    row["TinhChat"] = "";

                row["SoLuongToKhai"] = item["SoLuongToKhai"];
                
                // LoaiToKhai
                string loaiToKhai = "";
                switch (item["LoaiToKhai"].ToString().Trim())
                {
                    case "0": loaiToKhai = "Luồng xanh"; break;
                    case "1": loaiToKhai = "Luồng vàng"; break;
                    case "2": loaiToKhai = "Luồng đỏ"; break;
                    default: loaiToKhai = ""; break;
                }
                row["LoaiToKhai"] = loaiToKhai;

                // NghiepVu
                string nghiepVu = "";
                switch (item["NghiepVu"].ToString().Trim())
                {
                    case "0": nghiepVu = "Thông quan"; break;
                    case "1": nghiepVu = "Đổi lệnh dưới kho"; break;
                    case "2": nghiepVu = "Rút ruột"; break;
                    case "3": nghiepVu = "Thông quan kèm kiểm dịch/KTC"; break;
                    case "4": nghiepVu = "Không có trucking"; break;
                    default: nghiepVu = ""; break;
                }
                row["NghiepVu"] = nghiepVu;

                // PhatSinh
                string phatSinh = "";
                switch (item["PhatSinh"].ToString().Trim())
                {
                    case "0": phatSinh = "Nhiều tờ khai"; break;
                    case "1": phatSinh = "Không"; break;
                    default: phatSinh = ""; break;
                }
                row["PhatSinh"] = phatSinh;

                row["DuyetUng"] = item["DuyetUng"];
                row["TaiKhoanThucHien"] = item["TaiKhoanThucHien"];
                row["ThoiGianThucHien"] = item["ThoiGianThucHien"];
                row["GhiChu"] = item["GhiChu"];
                row["Chon"] = false;

                dt.Rows.Add(row);
            }


            dt.TableName = "xem";
            return dt;
        }
        public DataTable LayBangphiTheoMaDieuXe(string MaDieuXe)
        {
            string sql = $@"
                        SELECT TOP 1
                        a.MaDieuXe,
                        a.TuyenVC AS TenDichVu,
                        CAST(0 AS bit) AS LaPhiChiHo,   
                        '' AS SoHoaDon,
                        a.CuocMua AS SoTien,
                        c.MaNhaCungCap,
                        b.TenKhachHang,
                        a.NguoiTao,
                        a.Ngay,
                        a.IDBangPhi,
                        a.IDBangPhi AS IDGiaCT,
                        CAST(0 AS int) AS VAT,
                        CAST(0 AS int) AS ThanhTienVAT,
                        CAST(0 AS int) AS ThanhTien
                        FROM BangDieuXe a
                        LEFT JOIN DanhSachKhachHang b ON a.MaKhachHang = b.MaKhachHang
                        LEFT JOIN DanhSachNhaCungCap c ON a.MaNhaCungCap = c.MaNhaCungCap
                        WHERE a.MaDieuXe = '{MaDieuXe}'";

            return cls.LoadTable(sql);
        }
        public DataTable DieuXeKhongCoFile_NCC(DateTime TuNgay, DateTime DenNgay)
        {
            string sql = $@"
                SELECT 
                    a.IDBangPhi,
                    a.LaiXeThuCuoc,
                    a.LoaiXe_KH,
                    a.LoaiXe_NCC,
                    a.LuongHangVe,
                    a.MaDieuXe,
                    b.MaKhachHang,
                    b.TenKhachHang,
                    c.MaNhaCungCap,
                    c.TenNhaCungCap,
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
                    ISNULL(b.TenVietTat, '') AS TenVietTat,
                    a.GhiChu,
                    CAST(0 AS bit) AS Chon,
                    'DieuXe' AS Bang
                FROM BangDieuXe a
                LEFT JOIN DanhSachKhachHang b ON a.MaKhachHang = b.MaKhachHang
                LEFT JOIN DanhSachNhaCungCap c ON a.MaNhaCungCap = c.MaNhaCungCap
                LEFT JOIN FileDebitNcc fd ON fd.MaDieuXe = a.MaDieuXe   -- kiểm tra không trùng MaDieuXe
                WHERE a.Ngay BETWEEN '{TuNgay:yyyy-MM-dd}' AND '{DenNgay:yyyy-MM-dd}'
                   AND (
                        a.SoFile IS NULL 
                        OR TRY_CAST(a.SoFile AS NVARCHAR) = '' 
                        OR TRY_CAST(a.SoFile AS INT) = 0
                      )
                  AND ISNULL(a.CuocMua, 0) > 0
                  AND fd.MaDieuXe IS NULL";
               return cls.LoadTable(sql);
           
        }
        public DataTable dt_BangFileGiaDaTao(DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable("xem");

            dt.Columns.Add("ThoiGianThucHien", typeof(DateTime));
            dt.Columns.Add("IDLoHang");
            dt.Columns.Add("SoFile");
            dt.Columns.Add("IDGia");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("TenVietTat");
            dt.Columns.Add("SoToKhai");
            dt.Columns.Add("SoBill");
            dt.Columns.Add("SoLuong");      // hoặc double, tuỳ
            dt.Columns.Add("SoCont");
            dt.Columns.Add("TenSales");
            dt.Columns.Add("Chon", typeof(bool));

            string sql = $@"
             SELECT 
				ttf.ThoiGianThucHien, 
				fg.SoFile, 
				ttf.MaKhachHang,
				ttf.SoToKhai, 
				ttf.SoBill, 
				ttf.SoLuong, 
				ttf.SoCont, 
				ttf.TenSales,
				fg.IDGia, 
				fg.IDLoHang, 
				dskh.TenVietTat,
                CAST(0 AS bit) AS Chon
				FROM FileGia fg
				LEFT JOIN FileDebitNcc fd ON fd.SoFile = fg.SoFile   -- kiểm tra không trùng SoFile
				INNER JOIN ThongTinFile ttf ON ttf.IDLoHang = fg.IDLoHang
				INNER JOIN DanhSachKhachHang dskh ON dskh.MaKhachHang = ttf.MaKhachHang
				WHERE EXISTS (
					SELECT 1 
					FROM FileGiaChiTiet fgct
					WHERE fgct.IDGia = fg.IDGia
					  AND fgct.MaNhaCungCap IS NOT NULL
					  AND LTRIM(RTRIM(fgct.MaNhaCungCap)) <> ''
				)
				AND fd.SoFile IS NULL
				AND fg.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}'
                AND fg.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'";

            DataTable table = cls.LoadTable(sql);

            foreach (DataRow item in table.Rows)
            {
                DataRow row = dt.NewRow();
                row["ThoiGianThucHien"] = item["ThoiGianThucHien"];
                row["IDGia"] = item["IDGia"];
                row["IDLoHang"] = item["IDLoHang"];
                row["SoFile"] = item["SoFile"];
                row["MaKhachHang"] = item["MaKhachHang"];
                row["TenVietTat"] = item["TenVietTat"];
                row["SoToKhai"] = item["SoToKhai"];
                row["SoBill"] = item["SoBill"];
                row["SoLuong"] = item["SoLuong"];
                row["SoCont"] = item["SoCont"];
                row["TenSales"] = item["TenSales"];
                row["Chon"] = item["Chon"];
                dt.Rows.Add(row);
            }
            return dt;
        }
        public DataTable ChiTietNoiDungTaoDebit(int IDGia, int type = 0)// 0: là khách,1: ncc
        {
            DataTable dt1 = new DataTable("xem");
            dt1.Columns.Add("IDGiaCT", typeof(int));
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("MaNhaCungCap");
            dt1.Columns.Add("SoTien", typeof(double));
            dt1.Columns.Add("GiaMua", typeof(double));
            dt1.Columns.Add("VAT", typeof(double));
            dt1.Columns.Add("ThanhTienVAT", typeof(double));
            dt1.Columns.Add("ThanhTien", typeof(double));
            dt1.Columns.Add("LaPhiChiHo", typeof(bool));
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("SoHoaDon");

            // Lấy dữ liệu từ bảng FileGiaChiTiet theo IDGia
            string sql1 = $@"
            SELECT 
              IDGiaCT,
              TenDichVu,
              GiaBan AS SoTien,
              GiaMua AS GiaMua,
              CAST(0 AS bit) AS LaPhiChiHo,
              '' AS SoHoaDon,
              MaNhaCungCap
            FROM FileGiaChiTiet 
            WHERE IDGia={IDGia}";
            if (type == 1)
            {
                sql1 += " AND MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(MaNhaCungCap)) <> ''";
            }

            DataTable dtFileGia = cls.LoadTable(sql1);

            // Tạo kết quả đưa vào dt1
            foreach (DataRow dr in dtFileGia.Rows)
            {
                DataRow row1 = dt1.NewRow();
                row1["MaNhaCungCap"] = dr["MaNhaCungCap"];
                row1["TenDichVu"] = dr["TenDichVu"];
                row1["SoTien"] = dr["SoTien"];
                row1["GiaMua"] = dr["GiaMua"];
                row1["LaPhiChiHo"] = dr["LaPhiChiHo"];
                row1["SoHoaDon"] = dr["SoHoaDon"];
                row1["IDGiaCT"] = dr["IDGiaCT"];
                dt1.Rows.Add(row1);
            }
            if (type == 0) // là khách hàng thì thêm phí  BangLietKeCP_ChiTiet, chi phi nang ha
            {
                string sqlChiHo1 = $@"
                    SELECT 
                        b.IDGia,
                        c.TenChiHo,
                        a.SoTien_ChiHo,
                        a.MaChiHo
                    FROM BangLietKeCP_ChiTiet a
                    INNER JOIN FileGia b ON a.IDLoHang = b.IDLoHang
                    INNER JOIN DanhMuc_PhiChiHo c ON a.MaChiHo = c.MaChiHo
                    WHERE b.IDGia = {IDGia} AND a.MaChiHo IS NOT NULL
                ";
                DataTable dtChiHo1 = cls.LoadTable(sqlChiHo1);
                foreach (DataRow item in dtChiHo1.Rows)
                {
                    string tenChiHo = item["TenChiHo"].ToString();

                    if (!tenChiHo.ToLower().Contains("cược"))
                    {
                        DataRow row1 = dt1.NewRow();
                        row1["SoHoaDon"] = "";
                        row1["LaPhiChiHo"] = true;
                        row1["TenDichVu"] = tenChiHo;
                        row1["SoTien"] = Convert.ToDecimal(item["SoTien_ChiHo"]);
                        dt1.Rows.Add(row1);
                    }
                }
                string sqlChiHo2 = $@"
                    SELECT 
                        b.IDGia,
                        c.TenChiHo,
                        a.SoTien_ChiHo,
                        a.MaChiHo
                    FROM BangPhoiNangHa_ChiTiet a
                    INNER JOIN FileGia b ON a.IDLoHang = b.IDLoHang
                    INNER JOIN DanhMuc_PhiChiHo c ON a.MaChiHo = c.MaChiHo
                    WHERE b.IDGia = {IDGia} AND a.MaChiHo IS NOT NULL
                ";
                DataTable dtChiHo2 = cls.LoadTable(sqlChiHo2);
                foreach (DataRow item in dtChiHo2.Rows)
                {
                    string tenChiHo = item["TenChiHo"].ToString();

                    if (!tenChiHo.ToLower().Contains("cược"))
                    {
                        DataRow row1 = dt1.NewRow();
                        row1["SoHoaDon"] = "";
                        row1["LaPhiChiHo"] = true;
                        row1["TenDichVu"] = tenChiHo;
                        row1["SoTien"] = Convert.ToDecimal(item["SoTien_ChiHo"]);
                        dt1.Rows.Add(row1);
                    }
                }
            }
            return dt1;
        }
        public DataTable ChiTietNoiDungTaoDebit_Sua(int IDDebit)
        {
            string sql = $@"
            SELECT 
                TenDichVu,
                ISNULL(SoTien, 0) AS SoTien,
                ISNULL(VAT, 0) AS VAT,
                CASE 
                    WHEN VAT = -1 THEN 0 
                    ELSE ISNULL(SoTien, 0) * VAT / 100 
                END AS ThanhTienVAT,
                ISNULL(ThanhTien, 0) AS ThanhTien,
                ISNULL(LaPhiChiHo, 0) AS LaPhiChiHo,
                ISNULL(SoHoaDon, '') AS SoHoaDon,
                ISNULL(GhiChu, '') AS GhiChu,
                MaNhaCungCap
            FROM FileDebitNccChiTiet
            WHERE IDDeBit = {IDDebit}";

            DataTable dt = cls.LoadTable(sql);
            dt.TableName = "xem";
            return dt;
        }
        public DataTable BangFileDebitChiTiets(DateTime TuNgay, DateTime DenNgay)
        {
            //var DenNgayFix = DenNgay.AddDays(1); // Để lấy đủ dữ liệu trong ngày DenNgay

            string sql = $@"
            SELECT 
                fd.IDDeBit,
                fd.IDGia,
                fd.IDLoHang,
                ttf.SoFile,
                fd.ThoiGianLap,
                fd.NguoiLap,
                dskh.TenKhachHang,
                dskh.TenVietTat,
                ttf.SoBill,
                ttf.SoToKhai,
                ttf.TenSales,
                CAST(0 AS bit) AS Chon,
                fd.SoHoaDon,
                fd.NgayHoaDon,
                fdct.MaNhaCungCap,
                -- Tổng cộng theo từng IDDeBit
                ISNULL(SUM(fdct.SoTien), 0) AS SoTien,
                ISNULL(SUM(fdct.ThanhTien), 0) AS ThanhTien,
                ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 0 THEN fdct.SoTien ELSE 0 END), 0) AS TongPhi,
                ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 0 THEN (fdct.VAT * fdct.SoTien)/100 ELSE 0 END), 0) + ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 0 THEN fdct.SoTien ELSE 0 END), 0) AS TongPhi_VAT,
                ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 1 THEN fdct.ThanhTien ELSE 0 END), 0) AS TongPhiChiHo,
                ISNULL(SUM(fdct.ThanhTien), 0) AS TongChiPhiLoHang,
                ISNULL(SUM((fdct.VAT * fdct.SoTien)/100), 0) AS VAT
            FROM FileDebitNcc fd
            INNER JOIN ThongTinFile ttf ON fd.IDLoHang = ttf.IDLoHang
            INNER JOIN DanhSachKhachHang dskh ON ttf.MaKhachHang = dskh.MaKhachHang
            LEFT JOIN FileDebitNccChiTiet fdct ON fd.IDDeBit = fdct.IDDeBit
            WHERE fd.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}' AND fd.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'
            AND fdct.MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(fdct.MaNhaCungCap)) <> ''
            GROUP BY 
                fd.IDDeBit,
                fd.IDGia,
                fd.IDLoHang,
                ttf.SoFile,
                fd.ThoiGianLap,
                fd.NguoiLap,
                dskh.TenKhachHang,
                dskh.TenVietTat,
                ttf.SoBill,
                ttf.SoToKhai,
                ttf.TenSales,
                fd.SoHoaDon,
                fd.NgayHoaDon,
                fdct.MaNhaCungCap

            ORDER BY fd.IDDeBit DESC";

            return cls.LoadTable(sql);
        }
        public DataTable BangFileDebitNCCKhongLapFile(DateTime TuNgay, DateTime DenNgay)
        {
            //var DenNgayFix = DenNgay.AddDays(1); // Để lấy đủ dữ liệu trong ngày DenNgay

            string sql = $@"
            SELECT 
                fd.IDDeBit,
                fd.IDGia,
                fd.IDLoHang,
                fd.ThoiGianLap,
                fd.NguoiLap,
                CAST(0 AS bit) AS ChonXuatHoaDon,
                fd.SoHoaDon,
                fd.NgayHoaDon,
                fdct.MaNhaCungCap,
                fd.MaDieuXe,
                -- Tổng cộng theo từng IDDeBit
                ISNULL(SUM(fdct.ThanhTien), 0) AS ThanhTien,
                ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 0 THEN fdct.SoTien ELSE 0 END), 0) AS TongPhi,
                ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 0 THEN (fdct.VAT * fdct.SoTien)/100 ELSE 0 END), 0) 
                    + ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 0 THEN fdct.SoTien ELSE 0 END), 0) AS TongPhi_VAT,
                ISNULL(SUM(CASE WHEN ISNULL(fdct.LaPhiChiHo, 0) = 1 THEN fdct.ThanhTien ELSE 0 END), 0) AS TongPhiChiHo,
                ISNULL(SUM(fdct.ThanhTien), 0) AS TongChiPhiLoHang,
                ISNULL(SUM((fdct.VAT * fdct.SoTien)/100), 0) AS VAT

            FROM FileDebitNcc fd
            LEFT JOIN FileDebitNccChiTiet fdct ON fd.IDDeBit = fdct.IDDeBit
            WHERE fd.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}' AND fd.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'
            AND fdct.MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(fdct.MaNhaCungCap)) <> '' AND fd.MaDieuXe IS NOT NULL AND LTRIM(RTRIM(fd.MaDieuXe)) <> ''
            GROUP BY 
                fd.IDDeBit,
                fd.IDGia,
                fd.IDLoHang,
                fd.ThoiGianLap,
                fd.NguoiLap,
                fd.SoHoaDon,
                fd.NgayHoaDon,
                fd.MaDieuXe,
                fdct.MaNhaCungCap

            ORDER BY fd.IDDeBit DESC";

            return cls.LoadTable(sql);
        }
        public DataTable DsChiPhiHQ_TheoSoFile2(string SoFile, int IDLoHang, int IDCP)
        {
            DataTable dt1 = new DataTable("xem");
            dt1.Columns.Add("TenDichVu");
            dt1.Columns.Add("GiaMua", typeof(double));
            dt1.Columns.Add("GiaBan", typeof(double));
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("MaNhaCungCap");
            dt1.Columns.Add("TenNhaCungCap");
            dt1.Columns.Add("IDCP");

            // 1. Chi phí hải quan + chi hộ + phí đăng ký KTCL
            string sql1 = $@"
        SELECT 
            cp.IDCP,
            ISNULL(SUM(CASE WHEN ct.MaChiPhi_HQ IS NOT NULL THEN ct.SoTien_HQ ELSE 0 END), 0) AS TongHQ,
            ISNULL(SUM(CASE WHEN ct.MaChiHo IS NOT NULL THEN ct.SoTien_ChiHo ELSE 0 END), 0) AS TongCH,
            ISNULL(cp.PhiDangKy, 0) AS PhiDangKy
        FROM BangLietKeCP cp
        LEFT JOIN BangLietKeCP_ChiTiet ct ON cp.IDCP = ct.IDCP
        WHERE cp.IDLoHang = {IDLoHang} AND cp.IDCP = {IDCP}
        GROUP BY cp.IDCP, cp.PhiDangKy";

            var dtCP = cls.LoadTable(sql1);

            foreach (DataRow row in dtCP.Rows)
            {
                double tongHQ = Convert.ToDouble(row["TongHQ"]);
                double tongCH = Convert.ToDouble(row["TongCH"]);
                int idcp = Convert.ToInt32(row["IDCP"]);

                DataRow row1 = dt1.NewRow();
                row1["TenDichVu"] = "Chi phí hải quan";
                row1["GiaMua"] = tongHQ;
                row1["GiaBan"] = 0;
                row1["IDCP"] = idcp;
                dt1.Rows.Add(row1);

                // Nếu cần tính phí đăng ký KTCL, bật đoạn này
                //DataRow row2 = dt1.NewRow();
                //row2["TenDichVu"] = "Phí đăng ký kiểm tra chất lượng";
                //row2["GiaMua"] = Convert.ToDouble(row["PhiDangKy"]);
                //row2["GiaBan"] = 0;
                //row2["IDCP"] = idcp;
                //dt1.Rows.Add(row2);
            }

            // 2. Tuyến vận chuyển
            string sql2 = $@"
            SELECT 
                ISNULL(a.CuocMua, 0) AS CuocMua,
                ISNULL(a.CuocBan, 0) + ISNULL(a.LaiXeThuCuoc, 0) AS CuocBan,
                ISNULL(a.TuyenVC, '') AS TuyenVC,a.MaNhaCungCap
            FROM BangDieuXe a
            LEFT JOIN ThongTinFile b ON a.SoFile = b.SoFile
            WHERE a.SoFile = N'{SoFile}'";

            var dtVC = cls.LoadTable(sql2);

            foreach (DataRow item in dtVC.Rows)
            {
                double mua = Convert.ToDouble(item["CuocMua"]);
                double ban = Convert.ToDouble(item["CuocBan"]);
                string tuyen = item["TuyenVC"].ToString();

               

                DataRow row3 = dt1.NewRow();
                row3["TenDichVu"] = (string.IsNullOrEmpty(tuyen)) ? "Vui lòng nhập tuyến vận chuyển" : tuyen;
                row3["GiaMua"] = mua;
                row3["GiaBan"] = ban;
                row3["MaNhaCungCap"] = item["MaNhaCungCap"].ToString();
                dt1.Rows.Add(row3);
            }

            // 3. Chi từ phiếu chi có mã chi '004'
            string sql3 = $@"
            SELECT a.SoTien, a.GhiChu
            FROM PhieuChi_Con_CT a
            INNER JOIN PhieuChi_Con b ON a.SoChungTu = b.SoChungTu
            WHERE a.SoFile = N'{SoFile}' AND b.MaChi = '004'";

            var dtPhieuChi = cls.LoadTable(sql3);

            foreach (DataRow item in dtPhieuChi.Rows)
            {
                DataRow row4 = dt1.NewRow();
                row4["TenDichVu"] = item["GhiChu"];
                row4["GiaMua"] = item["SoTien"];
                row4["GiaBan"] = 0;
                dt1.Rows.Add(row4);
            }

            return dt1;
        }

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
                row["DauKi_VanChuyen"] = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom - TraTien;
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

                row["DauKi_NangHa"] = SoTien - TraTien;
                #endregion
                #region phat sinh
                sql1 = @"select isnull(sum(CuocMua),0) from BangDieuXe  where MaDieuXe not in(select MaDieuXe from FileDebit_KoHoaDon_NCC where MaNhaCungCap=N'" + row["MaNhaCungCap"].ToString() + "') and  MaNhaCungCap =N'" + row["MaNhaCungCap"].ToString().Trim() + "'  and (DATEDIFF(day,'" + TuNgay.ToString("yyyy-MM-dd") + "',Ngay)>=0 and DATEDIFF(day,'" + DenNgay.ToString("yyyy-MM-dd") + "',Ngay)<=0)";
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
                row["PhatSinh_VanChuyen"] = KhongFile_CuocMua + KhongFile_ThanhTien + CuocMua + PhiCom;

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
        public DataTable BangDieuXe_TaoDeBitHangLoat(string strMaDieuXe)
        {
            DataTable dt = new DataTable("DieuXe");
            dt.Columns.Add("TuyenVC");
            dt.Columns.Add("MaDieuXe");
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("VAT", typeof(int));
            dt.Columns.Add("IDBangPhi", typeof(int));
            dt.Columns.Add("PhiCom");
            dt.Columns.Add("MaNhaCungCap");
            dt.Columns.Add("MaKhachHang");
            dt.Columns.Add("LoaiXe_KH");
            dt.Columns.Add("SoHoaDon");
            dt.Columns.Add("CuocMua");
            dt.Columns.Add("CuocBan");
            dt.Columns.Add("LaiXeThuCuoc");
            dt.Columns.Add("ThanhTien", typeof(double));
            dt.Columns.Add("TenDichVu");
            if (strMaDieuXe.Trim().Length > 0)
            {
                string[] arr = strMaDieuXe.Split('-');
                for (int i = 0; i < arr.Length; i++)
                {
                    DataTable table = BangDieuXe_CanTaoHoaDon_KH(arr[i]); // DataTable
                    foreach (DataRow item in table.Rows)
                    {
                        DataRow row = dt.NewRow();
                        row["TuyenVC"] = item["TuyenVC"] == DBNull.Value ? "" : item["TuyenVC"].ToString();
                        row["MaDieuXe"] = item["MaDieuXe"] == DBNull.Value ? "" : item["MaDieuXe"].ToString();
                        decimal cuocBan = item["CuocBan"] == DBNull.Value ? 0M : Convert.ToDecimal(item["CuocBan"]);
                        decimal laiXeThu = item["LaiXeThuCuoc"] == DBNull.Value ? 0M : Convert.ToDecimal(item["LaiXeThuCuoc"]);
                        row["SoTien"] = cuocBan + laiXeThu;
                        row["VAT"] = 0;
                        row["PhiCom"] = 0;
                        row["MaNhaCungCap"] = item["MaNhaCungCap"] == DBNull.Value ? "" : item["MaNhaCungCap"].ToString();
                        row["MaKhachHang"] = item["MaKH"] == DBNull.Value ? "" : item["MaKH"].ToString();
                        row["LoaiXe_KH"] = item["LoaiXe_KH"] == DBNull.Value ? "" : item["LoaiXe_KH"].ToString();
                        row["SoHoaDon"] = "";
                        row["CuocMua"] = item["CuocMua"] == DBNull.Value ? 0M : Convert.ToDecimal(item["CuocMua"]);
                        row["CuocBan"] = cuocBan;
                        row["LaiXeThuCuoc"] = laiXeThu;
                        row["IDBangPhi"] = int.Parse(item["IDBangPhi"].ToString()) ;
                        row["TenDichVu"] = item["TuyenVC"] == DBNull.Value ? "" : item["TuyenVC"].ToString();
                        dt.Rows.Add(row);
                    }
                }
            }
            dt.TableName = "DieuXe";
            return dt;
        }
        public DataTable BangDieuXe_CanTaoHoaDon_KH(string MaDieuXe)
        {
            string maDieuXeEscaped = MaDieuXe.Replace("'", "''"); // tối thiểu escape
            string sql = $@"
                SELECT 
                    a.IDBangPhi,
                    a.LaiXeThuCuoc,
                    a.LoaiXe_KH,
                    a.LoaiXe_NCC,
                    a.LuongHangVe,
                    a.MaDieuXe,
                    sub1.MaKhachHang AS MaKH,
                    sub1.TenKhachHang AS MaKhachHang,
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
                    0 AS Chon,
                    sub1.TenVietTat,
                    a.GhiChu
                FROM BangDieuXe a
                LEFT JOIN DanhSachKhachHang sub1 ON a.MaKhachHang = sub1.MaKhachHang
                LEFT JOIN DanhSachNhaCungCap sub2 ON a.MaNhaCungCap = sub2.MaNhaCungCap
                WHERE a.MaDieuXe = N'{maDieuXeEscaped}'
            ";

            return cls.LoadTable(sql);
        }
        public void FileDeBit_KoLapFile_XuatHoaDon_NCC(bool XuatHD, string arr, string SoHoaDon, DateTime Ngay)
        {
            if (string.IsNullOrWhiteSpace(arr)) return;

            string[] arr1 = arr.Split('-');
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!int.TryParse(arr1[i], out int key)) continue;

                var p = new
                {
                    IDDeBit = key,
                    SoHoaDon = !XuatHD ? string.Empty : (SoHoaDon ?? string.Empty),
                    NgayHoaDon = !XuatHD ? (DateTime?)null : Ngay
                };
                using (var _appDB = new clsKetNoi())
                {
                    _appDB.UpsertFromObject("FileDebitNcc", p, "IDDeBit", true);
                }
            }
        }
        public DataTable DanhSachPhieuChi_NCC_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
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
        public DataTable DanhSachPhieuChi_TheoNgay(DateTime TuNgay, DateTime DenNgay)
        {
            clsKetNoi cls = new clsKetNoi();
            string sql = "select *,";
            sql += "(select top 1 DoiTuong from  PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as DoiTuong,";
            sql += "(select top 1 DiaChi from  PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as DiaChi,";
            sql += "(select top 1 TenDoiTuong from  PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as TenDoiTuong,";
            sql += "(select top 1 TenQuy from DanhMucQuy where MaQuy=PhieuChi.MaQuy)as TenQuy,(select sum(SoTien) from PhieuChi_CT where SoChungTu=PhieuChi.SoChungTu)as TongTien from PhieuChi where DATEDIFF(day,@TuNgay,NgayHachToan)>=0 and DATEDIFF(day,@DenNgay,NgayHachToan)<=0";
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
        public DataRow GetDetailNCC(string mancc)
        {
            using (var _db = new clsKetNoi())
            {
               return _db.GetSingleRecord("DanhSachNhaCungCap", mancc, "MaNhaCungCap");
            }
        }
        public List<CongNoChiTietNcc> CongNoChiTietNcc( DateTime TuNgay,  DateTime? DenNgay = null, string mancc = null, string tenncc = null, int dauky = 0)
        {

            // type 0 : phí dịch vụ
            // type 3 : nâng hạ
            // type 1 : chi nâng hạ
            // type 2 : chi dịch vụ
            // type 4 : chi tạm ứng
            List<CongNoChiTietNcc> list = new List<CongNoChiTietNcc>();

            string sql = $@"select nhct.IDCPCT,nhct.IDLoHang,nhct.GhiChu_ChiHo,nhct.MaNhaCungCap,nh.NgayTaoBangKe,ttf.SoFile,ttf.SoBill,ttf.SoToKhai,nhct.SoTien_ChiHo as ThanhTien,ttf.SoCont,pch.TenChiHo from BangPhoiNangHa_ChiTiet nhct left join BangPhoiNangHa nh on nh.IDLoHang = nhct.IDLoHang
            left join ThongTinFile ttf on ttf.IDLoHang = nhct.IDLoHang left join DanhMuc_PhiChiHo pch on pch.MaChiHo = nhct.MaChiHo
            where nhct.MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(nhct.MaNhaCungCap)) <> ''";

            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@"and nh.NgayTaoBangKe >= '{TuNgay:yyyy-MM-dd}' and nh.NgayTaoBangKe <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@"and nh.NgayTaoBangKe < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@"and nhct.MaNhaCungCap = N'{mancc}'";
            }

            DataTable table = cls.LoadTable(sql);

            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    DienGiai = item["GhiChu_ChiHo"].ToString(),
                    IDLoHang = item["IDLoHang"] != DBNull.Value ? Convert.ToInt32(item["IDLoHang"]) : 0,
                    MaDieuXe = item["SoFile"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    NgayHachToan = item["NgayTaoBangKe"] != DBNull.Value ? Convert.ToDateTime(item["NgayTaoBangKe"]) : DateTime.MinValue,
                    //SoHoaDon = item["SoHoaDon"].ToString(),
                   // NgayHoaDon = item["NgayHoaDon"] != DBNull.Value ? Convert.ToDateTime(item["NgayHoaDon"]) : DateTime.MinValue,
                    TenDichVu = "Nâng hạ",
                    SoTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    VAT = 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                   // PhiDichVu_DoiTru = item["PhiDichVu_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiDichVu_DoiTru"]) : 0,
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    NoiDung = item["TenChiHo"].ToString(),
                    Type =3, // nâng hạ
                    Key = "nanghachitiet",
                    ID = int.Parse(item["IDCPCT"].ToString()),
                };

                list.Add(obj);
            }


            sql = $@"select fd.*,fdct.*,ttf.SoToKhai,ttf.SoBill,ttf.SoCont from FileDebitNccChiTiet fdct left join FileDebitNcc fd on fd.IDDeBit = fdct.IDDeBit
            left join ThongTinFile ttf on ttf.IDLoHang = fd.IDLoHang 
            where fd.SoFile is not null
             AND fdct.MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(fdct.MaNhaCungCap)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and fd.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}' and fd.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and fd.ThoiGianLap < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and fdct.MaNhaCungCap = N'{mancc}'";
            }
            table = cls.LoadTable(sql);

            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    IDDeBit = item["IDDeBit"] != DBNull.Value ? Convert.ToInt32(item["IDDeBit"]) : 0,
                    IDGia = item["IDGia"] != DBNull.Value ? Convert.ToInt32(item["IDGia"]) : 0,
                    IDLoHang = item["IDLoHang"] != DBNull.Value ? Convert.ToInt32(item["IDLoHang"]) : 0,
                    SoFile = item["SoFile"].ToString(),
                    ThoiGianLap = item["ThoiGianLap"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianLap"]) : DateTime.MinValue,
                    NgayHachToan = item["ThoiGianLap"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianLap"]) : DateTime.MinValue,
                    NguoiLap = item["NguoiLap"].ToString(),
                    SoHoaDon = item["SoHoaDon"].ToString(),
                    NgayHoaDon = item["NgayHoaDon"] != DBNull.Value ? Convert.ToDateTime(item["NgayHoaDon"]) : DateTime.MinValue,
                    MaDieuXe = item["SoFile"].ToString(),
                    IDDeBitCT = item["IDDeBitCT"] != DBNull.Value ? Convert.ToInt32(item["IDDeBitCT"]) : 0,
                    TenDichVu = item["TenDichVu"].ToString(),
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    LaPhiChiHo = item["LaPhiChiHo"] != DBNull.Value ? Convert.ToInt32(item["LaPhiChiHo"]) : 0,
                    DoiTru = item["DoiTru"].ToString(),
                    PhiDichVu_DoiTru = item["PhiDichVu_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiDichVu_DoiTru"]) : 0,
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    NoiDung = item["TenDichVu"].ToString(),
                    Key = "debitchitiet",
                    ID = int.Parse(item["IDDeBitCT"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"SELECT fgct.IDGiaCT, fgct.GiaBan,fgct.GiaMua,fg.SoFile,fgct.MaNhaCungCap,fgct.TenDichVu,ttf.SoBill,ttf.SoToKhai,fg.ThoiGianLap as NgayHachToan,ttf.SoCont
                        FROM FileGiaChiTiet fgct
                        LEFT JOIN FileGia fg 
                            ON fg.IDGia = fgct.IDGia
                        LEFT JOIN FileDebitNcc fd 
                            ON fd.SoFile = fg.SoFile
                        LEFT JOIN ThongTinFile ttf 
                            ON ttf.IDLoHang = fg.IDLoHang
                        WHERE fg.SoFile IS NOT NULL
                          AND fgct.MaNhaCungCap IS NOT NULL
                          AND LTRIM(RTRIM(fgct.MaNhaCungCap)) <> '' AND fd.SoFile IS NULL";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and fg.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}' and fg.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and fg.ThoiGianLap < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and fgct.MaNhaCungCap = N'{mancc}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    SoFile = item.Table.Columns.Contains("SoFile") && item["SoFile"] != DBNull.Value ? item["SoFile"].ToString() : "",
                    ThoiGianLap = item["NgayHachToan"] != DBNull.Value ? Convert.ToDateTime(item["NgayHachToan"]) : DateTime.MinValue,
                    NgayHachToan = item["NgayHachToan"] != DBNull.Value ? Convert.ToDateTime(item["NgayHachToan"]) : DateTime.MinValue,
                    SoHoaDon = item.Table.Columns.Contains("SoHoaDon") ? item["SoHoaDon"].ToString() :"",
                    MaDieuXe = item.Table.Columns.Contains("SoFile") && item["SoFile"] != DBNull.Value ? item["SoFile"].ToString() : "",
                    TenDichVu = item["TenDichVu"].ToString(),
                    GiaMua = item["GiaMua"] != DBNull.Value ? Convert.ToDouble(item["GiaMua"]) : 0,
                    SoTien = item["GiaMua"] != DBNull.Value ? Convert.ToDouble(item["GiaMua"]) : 0,
                    VAT = 0,
                    ThanhTien = item["GiaMua"] != DBNull.Value ? Convert.ToDouble(item["GiaMua"]) : 0,
                    GiaBan = item["GiaBan"] != DBNull.Value ? Convert.ToDouble(item["GiaBan"]) : 0,
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    NoiDung = item["TenDichVu"].ToString(),
                    Key = "filegiachitiet",
                    ID = int.Parse(item["IDGiaCT"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"SELECT 
	                 ttf.SoToKhai,
	                 ttf.SoBill,
	                 ttf.SoCont,
                     a.IDBangPhi,
                     a.LaiXeThuCuoc,
                     a.LoaiXe_KH,
                     a.LoaiXe_NCC,
                     a.LuongHangVe,
                     a.MaDieuXe,
                     b.MaKhachHang,
                     b.TenKhachHang,
                     c.MaNhaCungCap,
                     c.TenNhaCungCap,
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
                     ISNULL(b.TenVietTat, '')  AS TenVietTat,
                     a.GhiChu,
                     CAST(0 AS bit) AS Chon,
                     'DieuXe' AS Bang
                     FROM BangDieuXe a
                     LEFT JOIN DanhSachKhachHang b ON a.MaKhachHang = b.MaKhachHang
                     LEFT JOIN DanhSachNhaCungCap c ON a.MaNhaCungCap = c.MaNhaCungCap
                     LEFT JOIN FileDebitNcc fd ON fd.MaDieuXe = a.MaDieuXe 
	                 LEFT JOIN ThongTinFile ttf ON ttf.IDLoHang = fd.IDLoHang 
                     WHERE
                     (
                     a.SoFile IS NULL 
                     OR TRY_CAST(a.SoFile AS NVARCHAR) = '' 
                     OR TRY_CAST(a.SoFile AS INT) = 0
                     )
                     AND ISNULL(a.CuocMua, 0) > 0
                     AND fd.MaDieuXe IS NULL and a.MaNhaCungCap IS NOT NULL
                          AND LTRIM(RTRIM(a.MaNhaCungCap)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and a.Ngay >= '{TuNgay:yyyy-MM-dd}' and a.Ngay <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and a.Ngay < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and a.MaNhaCungCap = N'{mancc}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    SoToKhai = item["SoToKhai"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    IDBangPhi = item["IDBangPhi"] != DBNull.Value ? Convert.ToInt32(item["IDBangPhi"]) : 0,
                    LaiXeThuCuoc = item["LaiXeThuCuoc"] != DBNull.Value ? Convert.ToDouble(item["LaiXeThuCuoc"]) : 0,
                    LoaiXe_KH = item["LoaiXe_KH"].ToString(),
                    LoaiXe_NCC = item["LoaiXe_NCC"].ToString(),
                    LuongHangVe = item["LuongHangVe"] != DBNull.Value ? Convert.ToInt32(item["LuongHangVe"]) : 0,
                    MaDieuXe = item["MaDieuXe"].ToString() + "/" + item["SoFile"].ToString(),
                    MaKhachHang = item["MaKhachHang"].ToString(),
                    TenKhachHang = item["TenKhachHang"].ToString(),
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    TenNhaCungCap = item["TenNhaCungCap"].ToString(),
                    Ngay = item["Ngay"] != DBNull.Value ? Convert.ToDateTime(item["Ngay"]) : DateTime.MinValue,
                    NgayHachToan = item["Ngay"] != DBNull.Value ? Convert.ToDateTime(item["Ngay"]) : DateTime.MinValue,
                    NguoiDuyet = item["NguoiDuyet"].ToString(),
                    NguoiTao = item["NguoiTao"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    ThoiGianDuyet = item["ThoiGianDuyet"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianDuyet"]) : DateTime.MinValue,
                    TienAn = item["TienAn"] != DBNull.Value ? Convert.ToDouble(item["TienAn"]) : 0,
                    QuaDem = item["QuaDem"] != DBNull.Value ? Convert.ToDouble(item["QuaDem"]) : 0,
                    TienLuat = item["TienLuat"] != DBNull.Value ? Convert.ToDouble(item["TienLuat"]) : 0,
                    TienVe = item["TienVe"] != DBNull.Value ? Convert.ToDouble(item["TienVe"]) : 0,
                    TTHQ = item["TTHQ"] != DBNull.Value ? Convert.ToDouble(item["TTHQ"]) : 0,
                    TuyenVC = item["TuyenVC"].ToString(),
                    TenDichVu = item["TuyenVC"].ToString(), // Nếu thực tế khác, map đúng cột TenDichVu
                    BienSoXe = item["BienSoXe"].ToString(),
                    CuocBan = item["CuocBan"] != DBNull.Value ? Convert.ToDouble(item["CuocBan"]) : 0,
                    CuocMua = item["CuocMua"] != DBNull.Value ? Convert.ToDouble(item["CuocMua"]) : 0,
                    SoTien = item["CuocMua"] != DBNull.Value ? Convert.ToDouble(item["CuocMua"]) : 0,
                    VAT = 0,
                    ThanhTien = item["CuocMua"] != DBNull.Value ? Convert.ToDouble(item["CuocMua"]) : 0,
                    DiemTraHang = item["DiemTraHang"].ToString(),
                    DuyetChi = item["DuyetChi"].ToString(),
                    LaiXe = item["LaiXe"].ToString(),
                    TenVietTat = item["TenVietTat"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    GhiChu = item["GhiChu"].ToString(),
                    Key = "bangdieuxe",
                    ID = int.Parse(item["IDBangPhi"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"SELECT 
	                ttf.SoBill,
	                ttf.SoToKhai,
	                ttf.SoCont,
                     fd.IDDeBit,
                     fd.IDGia,
                     fd.SoFile,
                     fd.IDLoHang,
                     fd.ThoiGianLap,
                     fd.NguoiLap,
                     fd.SoHoaDon,
                     fd.NgayHoaDon,
                     fdct.MaNhaCungCap,
                     fd.MaDieuXe,
                     fdct.LaPhiChiHo,
                     dx.LoaiXe_NCC,dx.BienSoXe,dx.TuyenVC,
                     ISNULL(SUM(fdct.ThanhTien), 0) AS ThanhTien,
                     ISNULL(SUM(fdct.SoTien), 0) AS SoTien,
                     ISNULL(SUM((fdct.VAT * fdct.SoTien)/100), 0) AS VAT
                     FROM FileDebitNcc fd
                     LEFT JOIN FileDebitNccChiTiet fdct ON fd.IDDeBit = fdct.IDDeBit
	                 LEFT JOIN ThongTinFile ttf ON ttf.IDLoHang = fd.IDLoHang
                     LEFT JOIN BangDieuXe dx ON dx.MaDieuXe = fd.MaDieuXe
                     WHERE fdct.MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(fdct.MaNhaCungCap)) <> '' AND fd.MaDieuXe IS NOT NULL AND LTRIM(RTRIM(fd.MaDieuXe)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@"and fd.ThoiGianLap >= '{TuNgay:yyyy-MM-dd}' and fd.ThoiGianLap <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@"and fd.ThoiGianLap < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@"and fdct.MaNhaCungCap = N'{mancc}'";
            }
            sql += $@"GROUP BY 
                     fd.IDDeBit,
                     fd.IDGia,
                     fd.IDLoHang,
                     fd.ThoiGianLap,
                     fd.NguoiLap,
                     fd.SoHoaDon,
                     fd.NgayHoaDon,
                     fd.SoFile,
                     fd.MaDieuXe,
                     fdct.MaNhaCungCap,
	                 ttf.SoToKhai,
	                 ttf.SoBill,
	                 ttf.SoCont,
                     dx.LoaiXe_NCC,
				     dx.BienSoXe,
				     dx.TuyenVC,fdct.LaPhiChiHo";
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    SoFile = item["SoFile"].ToString(),
                    SoBill = item["SoBill"].ToString(),
                    SoToKhai = item["SoToKhai"].ToString(),
                    IDDeBit = item["IDDeBit"] != DBNull.Value ? Convert.ToInt32(item["IDDeBit"]) : 0,
                    IDGia = item["IDGia"] != DBNull.Value ? Convert.ToInt32(item["IDGia"]) : 0,
                    IDLoHang = item["IDLoHang"] != DBNull.Value ? Convert.ToInt32(item["IDLoHang"]) : 0,
                    ThoiGianLap = item["ThoiGianLap"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianLap"]) : DateTime.MinValue,
                    NgayHachToan = item["ThoiGianLap"] != DBNull.Value ? Convert.ToDateTime(item["ThoiGianLap"]) : DateTime.MinValue,
                    NguoiLap = item["NguoiLap"].ToString(),
                    SoHoaDon = item["SoHoaDon"].ToString(),
                    NgayHoaDon = item["NgayHoaDon"] != DBNull.Value ? Convert.ToDateTime(item["NgayHoaDon"]) : DateTime.MinValue,
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    MaDieuXe = item["MaDieuXe"].ToString(),
                    LaPhiChiHo = item["LaPhiChiHo"] != DBNull.Value ? Convert.ToInt32(item["LaPhiChiHo"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    TuyenVC = item["TuyenVC"].ToString(),
                    SoCont = item["SoCont"].ToString(),
                    TenDichVu = item["TuyenVC"].ToString(), // Nếu thực tế khác, map đúng cột TenDichVu
                    BienSoXe = item["BienSoXe"].ToString(),
                    Key = "filedebit",
                    ID = int.Parse(item["IDDeBit"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"select pm.NgayMua,
                    pm.IDPhieuMua,
                    pm.DienGiai,
                    pm.SoPhieu,
                    pm.MaNhaCC,
                    ISNULL(SUM(pmct.ThanhTienVAT), 0) AS ThanhTien,
                    ISNULL(SUM(pmct.VAT), 0) AS VAT,
                    ISNULL(SUM(pmct.SoTien), 0) AS SoTien,
                    pmct.BienSoXe,
                    pmct.NoiDung
                    from PhieuMua pm
                    LEFT JOIN PhieuMuaCT pmct ON pmct.IDPhieuMua = pm.IDPhieuMua
                    where pm.MaNhaCC IS NOT NULL AND LTRIM(RTRIM(pm.MaNhaCC)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and pm.NgayMua >= '{TuNgay:yyyy-MM-dd}' and pm.NgayMua <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and pm.NgayMua < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and pm.MaNhaCC = N'{mancc}'";
            }
            sql += $@"GROUP BY 
                    pmct.BienSoXe,
                    pmct.NoiDung,
                    pm.NgayMua,
                    pm.SoPhieu,
                    pm.IDPhieuMua,
                    pm.DienGiai,pm.MaNhaCC";
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    DienGiai = item["DienGiai"].ToString(),
                    MaNhaCungCap = item["MaNhaCC"].ToString(),
                   // SoPhieu = item["SoPhieu"].ToString(),
                    NgayMua = item["NgayMua"] != DBNull.Value ? Convert.ToDateTime(item["NgayMua"]) : DateTime.MinValue,
                    NgayHachToan = item["NgayMua"] != DBNull.Value ? Convert.ToDateTime(item["NgayMua"]) : DateTime.MinValue,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                   // MaNhanVien = item["MaNhanVien"].ToString(),
                   // NguoiMuaHang = item["NguoiMuaHang"].ToString(),
                   // MaChi = item["MaChi"].ToString(),
                   // MaChiCon = item["MaChiCon"].ToString(),
                    NoiDung = item["SoPhieu"].ToString(),
                   // NguoiTao = item["NguoiTao"].ToString(),
                    BienSoXe = item["BienSoXe"].ToString(),
                    MaDieuXe = item["SoPhieu"].ToString(),
                    Key = "phieumua",
                    ID = int.Parse(item["IDPhieuMua"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"select * from FileDebit_KoHoaDon_KH where MaNhaCungCap IS NOT NULL AND LTRIM(RTRIM(MaNhaCungCap)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and NgayTao >= '{TuNgay:yyyy-MM-dd}' and NgayTao <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and NgayTao < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and MaNhaCungCap = N'{mancc}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    IDDeBit = item["IDDeBit"] != DBNull.Value ? Convert.ToInt32(item["IDDeBit"]) : 0,
                    MaDieuXe = item["MaDieuXe"].ToString(),
                    MaKhachHang = item["MaKhachHang"].ToString(),
                    LoaiXe_KH = item["LoaiXe_KH"].ToString(),
                    TuyenVC = item["TuyenVC"].ToString(),
                    CuocMua = item["CuocMua"] != DBNull.Value ? Convert.ToDouble(item["CuocMua"]) : 0,
                    CuocBan = item["CuocBan"] != DBNull.Value ? Convert.ToDouble(item["CuocBan"]) : 0,
                    LaiXeThuCuoc = item["LaiXeThuCuoc"] != DBNull.Value ? Convert.ToDouble(item["LaiXeThuCuoc"]) : 0,
                    NguoiTao = item["NguoiTao"].ToString(),
                    NgayTao = item["NgayTao"] != DBNull.Value ? Convert.ToDateTime(item["NgayTao"]) : DateTime.MinValue,
                    NgayHachToan = item["NgayTao"] != DBNull.Value ? Convert.ToDateTime(item["NgayTao"]) : DateTime.MinValue,
                    TenDichVu = item["TenDichVu"].ToString(),
                    SoTien = item["PhiCom"] != DBNull.Value ? Convert.ToDouble(item["PhiCom"]) : 0,
                    VAT = 0,
                    ThanhTien = item["PhiCom"] != DBNull.Value ? Convert.ToDouble(item["PhiCom"]) : 0,
                    GhiChu = item["GhiChu"].ToString(),
                    PhiCom = item["PhiCom"] != DBNull.Value ? Convert.ToDouble(item["PhiCom"]) : 0,
                    DoanhThuThuan = item["DoanhThuThuan"] != DBNull.Value ? Convert.ToDouble(item["DoanhThuThuan"]) : 0,
                    MaNhaCungCap = item["MaNhaCungCap"].ToString(),
                    SoHoaDon = item["SoHoaDon"].ToString(),
                    DoiTru = item["DoiTru"].ToString(),
                    PhiDichVu_DoiTru = item["PhiDichVu_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiDichVu_DoiTru"]) : 0,
                   // PhiChiHo_DoiTru = item["PhiChiHo_DoiTru"] != DBNull.Value ? Convert.ToDouble(item["PhiChiHo_DoiTru"]) : 0,
                    NgayHoaDon = item["NgayHoaDon"] != DBNull.Value ? Convert.ToDateTime(item["NgayHoaDon"]) : DateTime.MinValue,
                    NoiDung = "Phí com",
                    Key = "FileDebit_KoHoaDon_KH",
                    ID = int.Parse(item["IDDeBit"].ToString()),
                };

                list.Add(obj);
            }
            sql = $@"select pct.IDCTNCC,pct.IDName,pct.KeyName,pc.MaChi,pc.SoChungTu,pct.SoFile,pct.MaDieuXe,pct.SoTien,pct.ThanhTien,pct.VAT,pct.LaVanChuyen,pct.MaDoiTuong,pct.TenDoiTuong,pc.NgayHachToan,pc.DienGiai,pc.HinhThucTT,pc.ChuTaiKhoan from PhieuChi_NCC_CT pct left join PhieuChi_NCC pc on pct.SoChungTu = pc.SoChungTu where pc.MaChi = N'006' and pc.LyDoChi = N'Chi trả tiền nhà cung cấp' and pct.MaDoiTuong IS NOT NULL
                          AND LTRIM(RTRIM(pct.MaDoiTuong)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and pc.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and pc.NgayHachToan <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and pc.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and pct.MaDoiTuong = N'{mancc}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    SoChungTu = item["SoChungTu"].ToString(),
                    NgayHachToan = item["NgayHachToan"] != DBNull.Value ? Convert.ToDateTime(item["NgayHachToan"]) : DateTime.MinValue,
                    MaChi = item["MaChi"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    NoiDung = item["DienGiai"].ToString(),
                    MaDieuXe = item["SoFile"].ToString(),
                    DienGiai = item["DienGiai"].ToString(),
                    HinhThucTT = item["HinhThucTT"].ToString(),
                    ChuTaiKhoan = item["ChuTaiKhoan"].ToString(),
                    TenNhaCungCap = item["TenDoiTuong"].ToString(),
                    MaNhaCungCap = item["MaDoiTuong"].ToString(),
                    TongTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    Type = Convert.ToDouble(item["LaVanChuyen"]) == 0 ? 1 : 2, //1: chi nâng hạ 2: là chi dịch vụ
                    ID = int.Parse(item["IDCTNCC"].ToString()),
                    Key = "phieuchitietncc",
                    KeyName = item["KeyName"].ToString(),
                    IDName = item["IDName"] == DBNull.Value ? 0 : Convert.ToInt32(item["IDName"])
            };

                list.Add(obj);
            }
            sql = $@"select pct.IDCT,pc.MaChi,pc.SoChungTu,pct.SoFile,pct.MaDieuXe,pct.SoTien,pct.ThanhTien,pct.VAT,pct.MaDoiTuong,pct.TenDoiTuong,pc.NgayHachToan,pc.DienGiai,pc.HinhThucTT,pc.ChuTaiKhoan,pc.LyDoChi from PhieuChi_CT pct left join PhieuChi pc on pct.SoChungTu = pc.SoChungTu where pc.MaChi = N'006' and pc.LyDoChi = N'Chi tạm ứng tiền cho nhà cung cấp' and pct.MaDoiTuong IS NOT NULL
                          AND LTRIM(RTRIM(pct.MaDoiTuong)) <> ''";
            if (TuNgay != DateTime.MinValue && DenNgay.HasValue)
            {
                sql += $@" and pc.NgayHachToan >= '{TuNgay:yyyy-MM-dd}' and pc.NgayHachToan <= '{DenNgay:yyyy-MM-dd}'";
            }
            if (dauky == 1 && TuNgay != DateTime.MinValue) // đầu kỳ
            {
                sql += $@" and pc.NgayHachToan < '{TuNgay:yyyy-MM-dd}'";
            }
            if (!string.IsNullOrEmpty(mancc))
            {
                sql += $@" and pct.MaDoiTuong = N'{mancc}'";
            }
            table = cls.LoadTable(sql);
            foreach (DataRow item in table.Rows)
            {
                var obj = new CongNoChiTietNcc
                {
                    SoChungTu = item["SoChungTu"].ToString(),
                    NgayHachToan = item["NgayHachToan"] != DBNull.Value ? Convert.ToDateTime(item["NgayHachToan"]) : DateTime.MinValue,
                    MaChi = item["MaChi"].ToString(),
                    SoFile = item["SoFile"].ToString(),
                    NoiDung = item["DienGiai"].ToString(),
                    MaDieuXe = item["SoFile"].ToString(),
                    DienGiai = item["DienGiai"].ToString(),
                    HinhThucTT = item["HinhThucTT"].ToString(),
                    ChuTaiKhoan = item["ChuTaiKhoan"].ToString(),
                    TenNhaCungCap = item["TenDoiTuong"].ToString(),
                    MaNhaCungCap = item["MaDoiTuong"].ToString(),
                    TongTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    SoTien = item["SoTien"] != DBNull.Value ? Convert.ToDouble(item["SoTien"]) : 0,
                    ThanhTien = item["ThanhTien"] != DBNull.Value ? Convert.ToDouble(item["ThanhTien"]) : 0,
                    VAT = item["VAT"] != DBNull.Value ? Convert.ToDouble(item["VAT"]) : 0,
                    Type = 4, // 4: Chi tạm ứng tiền cho nhà cung cấp
                    ID = int.Parse(item["IDCT"].ToString()),
                    Key ="phieuchi"
                };

                list.Add(obj);
            }
            return list;
        }
        public void Dispose()
        {
            if (cls != null)
            {
                cls.Dispose();
                cls = null;
            }
        }
    }
}
