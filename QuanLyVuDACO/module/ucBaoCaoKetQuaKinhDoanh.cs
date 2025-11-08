using DevExpress.XtraEditors;
using Quản_lý_vudaco.reports;
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
    public partial class ucBaoCaoKetQuaKinhDoanh : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoKetQuaKinhDoanh()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucBaoCaoKetQuaKinhDoanh_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboKH.Properties.DataSource = client.dsKH();
            btnXem_Click(sender, e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy các lô hàng có lập file : 
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
                        // phí đầu kỳ
                        var kh_dk = _khachhang.CongNoTongHopKH(Ngay1, null, makh, 1);
                        var kh_dv_dk = kh_dk.Where(x => x.Type == 0 && x.LaPhiChiHo == 0) //
                                         .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                         .Select(g => new
                                         {
                                             MaKhachHang = g.Key,
                                             KHDVDK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                         })
                                         .ToList();
                        var kh_ch_dk = kh_dk.Where(x => x.Type == 0 && x.LaPhiChiHo == 1) //
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
                        var kh_tk = _khachhang.CongNoTongHopKH(Ngay1, Ngay2, makh);
                        var kh_dv_tk = kh_tk.Where(x => x.Type == 0 && x.LaPhiChiHo == 0) //
                                            .GroupBy(x => x.MaKhachHang) // group theo Ma Khach Hang
                                            .Select(g => new
                                            {
                                                MaKhachHang = g.Key,
                                                KHDVTK = g.Sum(x => x.ThanhTien), // ví dụ tính tổng
                                            })
                                            .ToList();
                        var kh_ch_tk = kh_tk.Where(x => x.Type == 0 && x.LaPhiChiHo == 1) //
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
