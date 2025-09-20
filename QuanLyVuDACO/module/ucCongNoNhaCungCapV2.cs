using ClosedXML.Excel;
using DevExpress.XtraEditors;
using Quản_lý_vudaco.services;
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
    public partial class ucCongNoNhaCungCapV2 : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCongNoNhaCungCapV2()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            cboNCC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            cboNCC.Properties.NullText = "";
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
            cboNCC.Properties.DataSource = client.ds_NCC();
            btnXem_Click(sender, e);
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var _ncc = new ncc())
                {
                    splashScreenManager1.ShowWaitForm();

                    string[] arr1 = dtpTuNgay.Text.Split('/');
                    string[] arr2 = dtpDenNgay.Text.Split('/');
                    if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                    {
                        DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                        DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                        string makh = "";
                        if (cboNCC.Text == "")
                            makh = "";
                        else
                            makh = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString();
                        // phí đầu kỳ
                        var ncc_dk = _ncc.CongNoChiTietNcc(Ngay1, null, makh, null, 1);
                        var ncc_dv_dk = ncc_dk.Where(x => x.Type == 0) // lọc trước
                                         .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                         .Select(g => new
                                         {
                                             MaNhaCungCap = g.Key,
                                             DichVuDk = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                         .ToList();
                        var ncc_nh_dk = ncc_dk.Where(x => x.Type == 3) // lọc trước
                                        .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                        .Select(g => new
                                        {
                                            MaNhaCungCap = g.Key,
                                            NangHaDk = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                         })
                                        .ToList();
                        // thanh toán đầu kỳ
                        var ncc_dv_tt_dk = ncc_dk.Where(x => x.Type == 2) // phí dịch vụ
                                          .Where(x => x.IDName > 0)
                                          .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                          .Select(g => new
                                          {
                                              MaNhaCungCap = g.Key,
                                              DichVuTTDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                          })
                                          .ToList();
                        var ncc_nh_tt_dk = ncc_dk.Where(x => x.Type == 1) // phí nâng hạ
                                         .Where(x => x.IDName > 0)
                                         .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                         .Select(g => new
                                         {
                                             MaNhaCungCap = g.Key,
                                             NangHaTTDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                         })
                                         .ToList();
                        // phí trong kỳ
                        var ncc_tk = _ncc.CongNoChiTietNcc(Ngay1, Ngay2, makh);
                        var ncc_dv = ncc_tk.Where(x => x.Type == 0) // lọc trước
                                            .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                            .Select(g => new
                                            {
                                                MaNhaCungCap = g.Key,
                                                DichVuTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                            .ToList();
                        var ncc_nh = ncc_tk.Where(x => x.Type == 3) // lọc trước
                                          .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                          .Select(g => new
                                          {
                                              MaNhaCungCap = g.Key,
                                              NangHaTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                          .ToList();
                        // thanh toán trong kỳ
                        var ncc_dv_tt = ncc_tk.Where(x => x.Type == 2) // phí dịch vụ
                                          .Where(x => x.IDName > 0)
                                          .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                          .Select(g => new
                                          {
                                              MaNhaCungCap = g.Key,
                                              DichVuTT = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                          .ToList();
                        var ncc_nh_tt = ncc_tk.Where(x => x.Type == 1) // phí nâng hạ
                                         .Where(x => x.IDName > 0)
                                         .GroupBy(x => x.MaNhaCungCap) // group theo MaNhaCungCap
                                         .Select(g => new
                                         {
                                             MaNhaCungCap = g.Key,
                                             NangHaTT = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                          })
                                         .ToList();
                        var ncc = _ncc.GetAllncc();
                        var result = ncc
                            .Select(k => new
                            {
                                MaNhaCungCap = k.MaNhaCungCap,
                                TenVietTat = k.TenVietTat, // nếu có cột này trong bảng NCC
                                DichVuDk = ncc_dv_dk.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.DichVuDk ?? 0,
                                NangHaDk = ncc_nh_dk.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.NangHaDk ?? 0,
                                DichVuTTDK = ncc_dv_tt_dk.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.DichVuTTDK ?? 0,
                                NangHaTTDK = ncc_nh_tt_dk.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.NangHaTTDK ?? 0,
                                DichVuTK = ncc_dv.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.DichVuTK ?? 0,
                                NangHaTK = ncc_nh.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.NangHaTK ?? 0,
                                DichVuTT = ncc_dv_tt.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.DichVuTT ?? 0,
                                NangHaTT = ncc_nh_tt.FirstOrDefault(x => x.MaNhaCungCap == k.MaNhaCungCap)?.NangHaTT ?? 0
                            })
                            .ToList();

                        // Convert sang DataTable
                        DataTable dt = new DataTable();
                        dt.Columns.Add("MaNhaCungCap", typeof(string));
                        dt.Columns.Add("TenVietTat", typeof(string));
                        dt.Columns.Add("DichVuDk", typeof(decimal));
                        dt.Columns.Add("DichVuTTDK", typeof(decimal));
                        dt.Columns.Add("NangHaDk", typeof(decimal));
                        dt.Columns.Add("NangHaTTDK", typeof(decimal));
                        dt.Columns.Add("DichVuTK", typeof(decimal));
                        dt.Columns.Add("NangHaTK", typeof(decimal));
                        dt.Columns.Add("DichVuTT", typeof(decimal));
                        dt.Columns.Add("NangHaTT", typeof(decimal));
                        dt.Columns.Add("DichVuCK", typeof(decimal));
                        dt.Columns.Add("NangHaCK", typeof(decimal));
                        dt.Columns.Add("ConLai", typeof(decimal));

                        foreach (var item in result)
                        {
                            double DichVuCK = (item.DichVuTK + item.DichVuDk) - (item.DichVuTT + item.DichVuTTDK);
                            double NangHaCK = (item.NangHaTK + item.NangHaDk) - (item.NangHaTT + item.NangHaTTDK);
                            double ConLai = DichVuCK + NangHaCK;

                            dt.Rows.Add(
                                item.MaNhaCungCap,
                                item.TenVietTat,
                                item.DichVuDk,
                                item.DichVuTTDK,
                                item.NangHaDk,
                                item.NangHaTTDK,
                                item.DichVuTK,
                                item.NangHaTK,
                                item.DichVuTT,
                                item.NangHaTT,
                                DichVuCK,
                                NangHaCK,
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
                    string makh = bandedGridView1.GetFocusedRowCellValue("MaNhaCungCap").ToString().Trim();
                    Forms.frmCongNoNCC_CT_V2 frm = new Forms.frmCongNoNCC_CT_V2(Ngay1, Ngay2, makh, null);
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
            using (var _ncc = new ncc())
            {
                string[] arr1 = dtpTuNgay.Text.Split('/');
                string[] arr2 = dtpDenNgay.Text.Split('/');
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    string makh = "";
                    if (cboNCC.Text == "")
                        makh = "";
                    else
                        makh = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString();
                        var ncc_ct = _ncc.CongNoChiTietNcc(Ngay1,Ngay2,makh, cboNCC.Text)
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
                                             x.Type
                                         }).ToList();
                                         dt = ToDataTable(ncc_ct);
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

        private void cboNCC_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                cboNCC.EditValue = null;
                e.Handled = true; // Ngăn không cho xử lý mặc định
            }
        }
    }
}
