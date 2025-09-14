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
    public partial class ucBaoCaoSoQuyTM : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoSoQuyTM()
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
                if(cboLoaiQuy.EditValue==null)
                 dt = client.BaoCaoQuyTM(Ngay1, Ngay2);
                else
                    dt = client.BaoCaoQuyTM_TheoQuy(Ngay1, Ngay2,cboLoaiQuy.EditValue.ToString().Trim());
                gridControl1.DataSource = dt;

               
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
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            btnXem_Click(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            DataView dv = (DataView)gridView1.DataSource;

            dv.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(gridView1.ActiveFilterCriteria);
            DataTable dt = dv.ToTable();
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            double DauKy = 0;
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));

                if (cboLoaiQuy.EditValue == null)
                {
                  
                    DauKy = client.SDDK_Quy(Ngay1, "");
                }
                else
                {
                   
                    DauKy = client.SDDK_Quy(Ngay1, cboLoaiQuy.EditValue.ToString().Trim());
                }
            }
            reports.rpt_BaoCaoSoQuyTM rpt = new rpt_BaoCaoSoQuyTM(dt, string.Format("Từ ngày {0} đến ngày {1}", dtpTuNgay.Text, dtpDenNgay.Text), DauKy);
            rpt.ShowPreview();
        }
    }
}
