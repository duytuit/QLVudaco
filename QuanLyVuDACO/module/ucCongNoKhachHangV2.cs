using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using Quản_lý_vudaco.services;
using Quản_lý_vudaco.services.common;
using Quản_lý_vudaco.services.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.module
{
    public partial class ucCongNoKhachHangV2 : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCongNoKhachHangV2()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            cboKH.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            cboKH.Properties.NullText = "";
            string className = this.GetType().Name;
            bool hasPermission = frmMain.Permission.Rows.Cast<DataRow>().Any(r => r["Quyen"].ToString() == className && bool.Parse(r["Xem"].ToString()) == true);
            if (hasPermission == true || frmMain._TK.ToLower() == "admin" || frmMain._TK.ToLower() == "phanhuyen")
            {
                bandedGridColumn1.Visible = true;
            }
            else
            {
                bandedGridColumn1.Visible = false;
            }
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void ucCongNoKhachHang_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboKH.Properties.DataSource = client.dsKH();
            btnXem_Click(sender, e);
         
        }
        private string NormalizeKey(string key)
        {
            return key?
                .Trim()                      // bỏ khoảng trắng 2 đầu
                .Replace("\u00A0", " ")      // thay non-breaking space thành space thường
                .Normalize(NormalizationForm.FormC); // chuẩn Unicode
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var _khachhang = new khachhang())
                {
                    splashScreenManager1.ShowWaitForm();

                    string[] arr1 = dtpTuNgay.Text.Split('/');
                    string[] arr2 = dtpDenNgay.Text.Split('/');
                    if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                    {
                        DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                        DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                        string makh = "";
                        if (cboKH.Text == "")
                            makh = "";
                        else
                            makh = (cboKH.EditValue == null) ? "" : cboKH.EditValue.ToString();
                        // phí đầu kỳ
                        var kh_dk = _khachhang.CongNoChiTietKH(Ngay1, null, makh, 1);
                        var kh_dv_dk = kh_dk.Where(x => x.Type == 0 && x.LaPhiChiHo ==0) //
                                         .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                         .Select(g => new
                                         {
                                             MaKhachHang = g.Key,
                                             KHDVDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                         .ToList();
                        var kh_ch_dk = kh_dk.Where(x => x.Type ==0 && x.LaPhiChiHo == 1) //
                                       .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                       .Select(g => new
                                       {
                                           MaKhachHang = g.Key,
                                           KHCHDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                         })
                                       .ToList();
                        // thanh toán đầu kỳ
                        var kh_tt_dv_dk = kh_dk.Where(x => x.Type == 5 && x.LaPhiChiHo == 0) //
                                     .Where(x => x.IDKey > 0)
                                     .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                     .Select(g => new
                                     {
                                         MaKhachHang = g.Key,
                                         KHTTDVDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                       })
                                     .ToList();
                        // thanh toán đầu kỳ
                        var kh_tt_ch_dk = kh_dk.Where(x => x.Type == 5 && x.LaPhiChiHo == 1) //
                                     .Where(x => x.IDKey > 0)
                                     .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                     .Select(g => new
                                     {
                                         MaKhachHang = g.Key,
                                         KHTTCHDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                     })
                                     .ToList();
                        // phí trong kỳ
                        var kh_tk = _khachhang.CongNoChiTietKH(Ngay1, Ngay2, makh);
                        var kh_dv_tk = kh_tk.Where(x => x.Type ==0 && x.LaPhiChiHo == 0) //
                                            .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                            .Select(g => new
                                            {
                                                MaKhachHang = g.Key,
                                                KHDVTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                            .ToList();
                        var kh_ch_tk = kh_tk.Where(x => x.Type ==0 && x.LaPhiChiHo == 1) //
                                          .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                          .Select(g => new
                                          {
                                              MaKhachHang = g.Key,
                                              KHCHTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                          .ToList();

                        // thanh toán trong kỳ
                        var kh_tt_dv_tk = kh_tk.Where(x => x.Type == 5 && x.LaPhiChiHo == 0) //
                                          .Where(x => x.IDKey > 0)
                                          .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                          .Select(g => new
                                          {
                                              MaKhachHang = g.Key,
                                              KHTTDVTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                          .ToList();
                        var kh_tt_ch_tk = kh_tk.Where(x => x.Type == 5 && x.LaPhiChiHo == 1) //
                                         .Where(x => x.IDKey > 0)
                                         .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                         .Select(g => new
                                         {
                                             MaKhachHang = g.Key,
                                             KHTTCHTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                          })
                                         .ToList();
                        var allKeys = kh_dv_dk.Select(x => x.MaKhachHang)
                                .Union(kh_ch_dk.Select(x => x.MaKhachHang))
                                .Union(kh_tt_dv_dk.Select(x => x.MaKhachHang))
                                .Union(kh_tt_ch_dk.Select(x => x.MaKhachHang))
                                .Union(kh_dv_tk.Select(x => x.MaKhachHang))
                                .Union(kh_ch_tk.Select(x => x.MaKhachHang))
                                .Union(kh_tt_dv_tk.Select(x => x.MaKhachHang))
                                .Union(kh_tt_ch_tk.Select(x => x.MaKhachHang))
                                .Distinct(StringComparer.OrdinalIgnoreCase);
                        var kh = _khachhang.GetAllkh();

                        var result = kh
                            .Select(k => new
                            {
                                MaKhachHang = k.MaKhachHang,
                                TenVietTat = k.TenVietTat,
                                KHDVDK = kh_dv_dk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHDVDK ?? 0,
                                KHCHDK = kh_ch_dk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHCHDK ?? 0,
                                KHTTDVDK = kh_tt_dv_dk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHTTDVDK ?? 0,
                                KHTTCHDK = kh_tt_ch_dk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHTTCHDK ?? 0,
                                KHDVTK = kh_dv_tk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHDVTK ?? 0,
                                KHCHTK = kh_ch_tk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHCHTK ?? 0,
                                KHTTDVTK = kh_tt_dv_tk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHTTDVTK ?? 0,
                                KHTTCHTK = kh_tt_ch_tk.FirstOrDefault(x => x.MaKhachHang == k.MaKhachHang)?.KHTTCHTK ?? 0,
                            })
                            .ToList();


                        // Convert sang DataTable
                        DataTable dt = new DataTable();
                        dt.Columns.Add("MaKhachHang", typeof(string));
                        dt.Columns.Add("TenVietTat", typeof(string));
                        dt.Columns.Add("KHDVDK", typeof(decimal));
                        dt.Columns.Add("KHCHDK", typeof(decimal));
                        dt.Columns.Add("KHDVTK", typeof(decimal));
                        dt.Columns.Add("KHCHTK", typeof(decimal));
                        dt.Columns.Add("KHTTDVTK", typeof(decimal));
                        dt.Columns.Add("KHTTCHTK", typeof(decimal));
                        dt.Columns.Add("DVCK", typeof(decimal));
                        dt.Columns.Add("CHCK", typeof(decimal));
                        dt.Columns.Add("ConLai", typeof(decimal));

                        foreach (var item in result)
                        {
                            double DVCK = (item.KHDVDK + item.KHDVTK) - (item.KHTTDVDK + item.KHTTDVTK);
                            double CHCK = (item.KHCHDK + item.KHCHTK) - (item.KHTTCHDK + item.KHTTCHTK);
                            double ConLai = (item.KHDVDK + item.KHCHDK) - (item.KHTTDVDK + item.KHTTCHDK)
                                          + (item.KHDVTK + item.KHCHTK) - (item.KHTTDVTK + item.KHTTCHTK);

                            dt.Rows.Add(
                                item.MaKhachHang,
                                item.TenVietTat,
                                item.KHDVDK,
                                item.KHCHDK,
                                item.KHDVTK,
                                item.KHCHTK,
                                item.KHTTDVTK,
                                item.KHTTCHTK,
                                DVCK,
                                CHCK,
                                ConLai
                            );
                        }

                        gridControl1.DataSource = dt;
                        splashScreenManager1.CloseWaitForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private double DaoSo(double value)
        {
            if (value < 0)
                return Math.Abs(value);  // nếu âm → trả về dương
            else
                return -value;           // nếu dương → đổi thành âm
        }
        private void repositoryItemCT_Click(object sender, EventArgs e)
        {
            try
            {
                string[] arr1 = dtpTuNgay.Text.Split('/');
                string[] arr2 = dtpDenNgay.Text.Split('/');
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    string makh = bandedGridView1.GetFocusedRowCellValue("MaKhachHang").ToString().Trim();

                    Forms.frmCongNoKH_CT_V2 frm = new Forms.frmCongNoKH_CT_V2(Ngay1, Ngay2, makh);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có DataTable từ GridView hoặc từ nguồn dữ liệu
            DataTable dt = new DataTable();
            using (var _khachhang = new khachhang())
            {
                string[] arr1 = dtpTuNgay.Text.Split('/');
                string[] arr2 = dtpDenNgay.Text.Split('/');
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    string makh = "";
                    if (cboKH.Text == "")
                        makh = "";
                    else
                        makh = (cboKH.EditValue == null) ? "" : cboKH.EditValue.ToString();
                        var kh_ct = _khachhang.CongNoChiTietKH(Ngay1,Ngay2,makh)
                                         .Select(x => new
                                         {
                                             x.NgayHachToan,
                                             x.LoaiXe_NCC,
                                             x.MaDieuXe,
                                             x.SoToKhai,
                                             x.SoBill,
                                             x.SoTien,
                                             x.NoiDung,
                                             x.VAT,
                                             x.ThanhTien,
                                             x.MaNhaCungCap,
                                             x.BienSoXe,
                                             x.LaPhiChiHo,
                                             x.TongTien,
                                             x.PhiCom,
                                             x.Type,
                                             x.MaKhachHang
                                         }).ToList();
                                         dt = ToDataTable(kh_ct);
                }
              
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dt, sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!");
                }
            }
        }
        public void ExportToExcel(DataTable dt, string filePath)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sheet1");
                wb.SaveAs(filePath);
            }
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Lấy các property của class
            var Props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in Props)
            {
                // Thiết lập kiểu dữ liệu Nullable nếu có
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            ? Nullable.GetUnderlyingType(prop.PropertyType)
                            : prop.PropertyType;

                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (var item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private void cboKH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                cboKH.EditValue = null;
                e.Handled = true; // Ngăn không cho xử lý mặc định
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemCT_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] arr1 = dtpTuNgay.Text.Split('/');
                string[] arr2 = dtpDenNgay.Text.Split('/');
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    string makh = bandedGridView1.GetFocusedRowCellValue("MaKhachHang").ToString().Trim();

                    Forms.frmCongNoKH_CT_V2 frm = new Forms.frmCongNoKH_CT_V2(Ngay1, Ngay2, makh);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
