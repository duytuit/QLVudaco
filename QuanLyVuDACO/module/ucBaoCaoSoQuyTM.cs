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
                    List<BaoCaoSoQuy> rs = sqtm.BaoCaoQuy(Ngay1, Ngay2, null, "TM");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("NgayHachToan", typeof(DateTime));
                    dt.Columns.Add("SoPhieu", typeof(string));
                    dt.Columns.Add("DienGiai", typeof(string));
                    dt.Columns.Add("Thu", typeof(double));
                    dt.Columns.Add("Chi", typeof(double));
                    dt.Columns.Add("Ton", typeof(double));
                    dt.Columns.Add("MaDoiTuong", typeof(string));
                    dt.Columns.Add("DoiTuong", typeof(string));
                    dt.Columns.Add("LoaiDoiTuong", typeof(string));
                    dt.Columns.Add("MaQuy", typeof(string));
                    dt.Columns.Add("TenQuy", typeof(string));
                    dt.Columns.Add("LyDo", typeof(string));
                    dt.Columns.Add("SoTK", typeof(string));
                    dt.Columns.Add("ChuTK", typeof(string));
                    dt.Columns.Add("NganHang", typeof(string));
                }
               
                //gridControl1.DataSource = dt;

            }
        }
    }
}
