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
    public partial class ucTSCD_TSCD : UserControl
    {
        public ucTSCD_TSCD()
        {
            InitializeComponent();
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
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
                if (Ngay1.Year == 1 || Ngay2.Year == 1)
                    MessageBox.Show("Ngày chọn không tồn tại!");
                else
                    gridControl2.DataSource = client.DS_TSCD_TheoNgay(Ngay1, Ngay2);
            }
           
        }

        private void ucTSCD_TSCD_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnXem_Click(sender, e);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm = new Forms.frmKhaiBaoTSCD();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _IDKhauHao = int.Parse(gridView2.GetFocusedRowCellValue("IDKhauHao").ToString().Trim());
            Form frm = new Forms.frmKhaiBaoTSCD(_IDKhauHao);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {

            int _IDKhauHao = int.Parse(gridView2.GetFocusedRowCellValue("IDKhauHao").ToString().Trim());
            client.Xoa_TSCD(_IDKhauHao);
            btnXem_Click(sender, e);
        }
    }
}
