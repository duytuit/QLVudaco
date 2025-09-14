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

namespace Quản_lý_vudaco.module
{
    public partial class ucCongNoLaiXe : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCongNoLaiXe()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
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
            cboNhanVienGiaoNhan.Properties.DataSource = client.DsTaiKhoan();
          
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();

                string[] arr1 = dtpTuNgay.Text.Split('/');
                string[] arr2 = dtpDenNgay.Text.Split('/');
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    string tk = "";
                    if (cboNhanVienGiaoNhan.Text == "")
                        tk = "";
                    else
                        tk = (cboNhanVienGiaoNhan.EditValue == null) ? "" : cboNhanVienGiaoNhan.EditValue.ToString();
                    gridControl1.DataSource = client.CongNoTongHopLaiXe(Ngay1, Ngay2, tk);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                    string tk = bandedGridView1.GetFocusedRowCellValue("TaiKhoan").ToString().Trim();
                    string ten = bandedGridView1.GetFocusedRowCellValue("TenLaiXe").ToString().Trim();
                    Forms.frmCongNoLaiXe_CT frm = new Forms.frmCongNoLaiXe_CT(Ngay1, Ngay2, tk, ten);
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
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                bandedGridView1.ExportToXlsx(dialog.SelectedPath+"/"+dtpTuNgay.Text.Replace('/','_')+","+dtpDenNgay.Text.Replace('/','_')+".xlsx");
        }
    }
}
