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
    public partial class ucBaoCaoSoQuyTM : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoSoQuyTM()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucBaoCaoSoQuyTM_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                    List<BaoCaoSoQuy> rs_ton = sqtm.BaoCaoQuy(Ngay1, null, null, "TM",1);
                    double ton = rs_ton.Sum(y => y.Thu) - rs_ton.Sum(y => y.Chi);
                    List<BaoCaoSoQuy> rs = sqtm.BaoCaoQuy(Ngay1, Ngay2, null, "TM");
                    var rs_baocao_tienmat = rs.OrderBy(x=>x.NgayHachToan).ToList();
                    foreach (var item in rs_baocao_tienmat)
                    {
                        ton += item.Thu;
                        ton -= item.Chi;
                        item.Ton = ton;    // <-- gán trực tiếp
                    }
                    var kq_bao_cao_tienmat = rs_baocao_tienmat.OrderByDescending(x => x.NgayHachToan).ToList();
                    gridControl1.DataSource = ToDataTable(kq_bao_cao_tienmat);
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
    }
}
