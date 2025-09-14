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
    public partial class ucTSCD_PhanBo : UserControl
    {
        public ucTSCD_PhanBo()
        {
            InitializeComponent();
            colSTT3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView3.CustomUnboundColumnData += GridView3_CustomUnboundColumnData;
        }
        private void GridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucTSCD_PhanBo_Load(object sender, EventArgs e)
        {
            cboThang.SelectedText = DateTime.Now.Month.ToString();
            for (int i = 2024; i <= 2040; i++)
            {
                cboNam.Properties.Items.Add(i.ToString());
            }
            cboNam.SelectedText = DateTime.Now.Year.ToString();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            int Thang = int.Parse(cboThang.Text);
            int Nam = int.Parse(cboNam.Text);
            int SoNgayOfThang = DateTime.DaysInMonth(Nam, Thang);
            DateTime Ngay1 = new DateTime(Nam,Thang,1);
            DateTime Ngay2 = new DateTime(Nam, Thang, SoNgayOfThang);
            gridCha.DataSource = client.DS_PhanBo_KhauHao_TheoNgay(Ngay1, Ngay2);

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm = new Forms.frmPhanBoKhauHao();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }
    }
}
