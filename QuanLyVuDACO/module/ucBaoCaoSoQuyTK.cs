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
    public partial class ucBaoCaoSoQuyTK : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoSoQuyTK()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucBaoCaoSoQuyTK_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "SoTK";
            cboNganHang.ValueMember = "SoTK";
            cboKH.Properties.DataSource = client.dsKH();
            btnXem_Click(sender, e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));

                using (var sqtm = new baocaosoquy())
                {
                    string makh = "";
                    if (cboKH.Text == "")
                        makh = "";
                    else
                        makh = (cboKH.EditValue == null) ? "" : cboKH.EditValue.ToString();
                    string stk = "";
                    if (cboNganHang.Text == "")
                        stk = "";
                    else
                        stk = (cboNganHang.Text == null) ? "" : cboNganHang.Text.ToString();
                    List<BaoCaoSoQuy> rs_ton = sqtm.BaoCaoQuy(Ngay1, null, makh, "CK",1, stk);
                    double ton_thu = rs_ton.Sum(y => y.Thu);
                    double ton_chi =  rs_ton.Sum(y => y.Chi);
                    double ton = ton_thu - ton_chi;
                    lbSoDuDK.Text = ton.ToString("#,##");
                    List<BaoCaoSoQuy> rs = sqtm.BaoCaoQuy(Ngay1, Ngay2, makh, "CK",0, stk);
                    var rs_baocao_tienmat = rs
                     .GroupBy(x => new { x.SoPhieu, x.NgayHachToan }) // group theo SoChungTu (và có thể thêm NgayHachToan nếu cần)
                     .Select(g => new BaoCaoSoQuy
                     {
                         SoPhieu = g.Key.SoPhieu,
                         NgayHachToan = g.Key.NgayHachToan,
                         Thu = g.Sum(x => x.Thu),
                         Chi = g.Sum(x => x.Chi),
                         DienGiai = g.First().DienGiai,      // nếu cần lấy mô tả hoặc trường khác
                         Ton = g.First().Ton,              // ví dụ
                         DoiTuong = g.First().DoiTuong,              // ví dụ
                         MaDoiTuong = g.First().MaDoiTuong,              // ví dụ
                         LoaiDoiTuong = g.First().LoaiDoiTuong,              // ví dụ
                         MaQuy = g.First().MaQuy,              // ví dụ
                         TenQuy = g.First().TenQuy,              // ví dụ
                         LyDo = g.First().LyDo,              // ví dụ
                         SoTK = g.First().SoTK,              // ví dụ
                         ChuTK = g.First().ChuTK,              // ví dụ
                         NganHang = g.First().NganHang,              // ví dụ
                                                            // ... các thuộc tính khác nếu có
                    })
                     .OrderBy(x => x.NgayHachToan)
                     .ToList();
                    foreach (var item in rs_baocao_tienmat)
                    {
                        ton += item.Thu;
                        ton -= item.Chi;
                        item.Ton = ton;    // <-- gán trực tiếp
                    }
                    gridControl1.DataSource = ToDataTable(rs_baocao_tienmat);
                }
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
    }
}
