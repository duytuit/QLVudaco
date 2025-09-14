using DevExpress.XtraEditors;
using Quản_lý_vudaco.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Quản_lý_vudaco.module
{
    public partial class ucDuyetBangTheoDoiFileGia : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDuyetBangTheoDoiFileGia()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
        }
        
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {

            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
           btnXem_Click(sender, e);
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        DataTable dtBangKeFull = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');

            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                gridChuaDuyet.DataSource = client.dt_BangFileGiaDaTao_ChuaDuyet(Ngay1, Ngay2);
                gridDaDuyet.DataSource = client.dt_BangFileGiaDaTao_DaDuyet(Ngay1, Ngay2);
            }
        }



        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            
           
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
               
               
                    bool isCheck = client.FileGia_KiemTraFileDebit(_IDGia);
                    if (isCheck)
                        MessageBox.Show("Lô này đã tạo debit, vui lòng xóa debit đã tạo");
                    else
                    {
                        client.BangFileGia_Duyet_Xoa(_IDGia);
                        btnXem_Click(sender, e);
                    }
               
            }
        }
      
        

        private void repositoryItemXem_Click(object sender, EventArgs e)
        {
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            int _IDGia = int.Parse(gridView1.GetFocusedRowCellValue("IDGia").ToString().Trim());
            int _IDCP = int.Parse(gridView1.GetFocusedRowCellValue("IDCP").ToString().Trim());
            Forms.frmFileGia_Qly frm = new Forms.frmFileGia_Qly(_IDLoHang, "", _IDGia, _IDCP, 1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }
    }
}
