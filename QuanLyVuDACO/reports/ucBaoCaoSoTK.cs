using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Quản_lý_vudaco.reports
{
    public partial class ucBaoCaoSoTK : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoSoTK()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                DataTable dt = new DataTable();
                if (cboNganHang.Text == ""||cboNganHang.Text=="Tất cả")
                    dt = client.BaoCaoSoTK(Ngay1, Ngay2);
                else
                    dt = client.BaoCaoSoTK_TheoSoTK(Ngay1, Ngay2, cboNganHang.SelectedValue.ToString().Trim(),cboNganHang.Text.Trim());
                gridControl1.DataSource = dt;
                //format
             
                gridView1.Columns["Thu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Chi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

              
                gridView1.Columns["Thu"].DisplayFormat.FormatString = "#,##";
                gridView1.Columns["Chi"].DisplayFormat.FormatString = "#,##";

            }
        }

        private void ucBaoCaoSoQuyTM_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "SoTK";
            cboNganHang.ValueMember = "TenNganHang";
            cboNganHang.Text = "";
            btnXem_Click(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            DataView dv = (DataView)gridView1.DataSource;
          
            dv.RowFilter=DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(gridView1.ActiveFilterCriteria);
            DataTable dt = dv.ToTable();
            double DauKy = 0;
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));

                if (cboNganHang.Text == "")
                {
                  
                    DauKy = client.SDDK_TaiKhoan(Ngay1, "", "");
                }
                else
                {
                  
                    DauKy = client.SDDK_TaiKhoan(Ngay1, cboNganHang.SelectedValue.ToString().Trim(), cboNganHang.Text.Trim());
                }
            }
            reports.rpt_BaoCaoSoTK rpt = new rpt_BaoCaoSoTK(dt, string.Format("Từ ngày {0} đến ngày {1}", dtpTuNgay.Text, dtpDenNgay.Text), DauKy);
            rpt.ShowPreview();
        }
    }
}
