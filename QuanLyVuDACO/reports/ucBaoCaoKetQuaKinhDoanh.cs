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

namespace Quản_lý_vudaco.reports
{
    public partial class ucBaoCaoKetQuaKinhDoanh : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoKetQuaKinhDoanh()
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
                 dt = client.BaoCaoKetQuaKinhDoanh(Ngay1, Ngay2);
                reports.rpt_BaoCaoKetQuaKinhDoanh rpt = new rpt_BaoCaoKetQuaKinhDoanh();
                rpt.DataSource = dt;
                rpt.DataMember = "kinhdoanh";
                documentViewer1.DocumentSource = rpt;
                documentViewer1.InitiateDocumentCreation();
            }
        }

        private void ucBaoCaoSoQuyTM_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnXem_Click(sender, e);
        }
    }
}
