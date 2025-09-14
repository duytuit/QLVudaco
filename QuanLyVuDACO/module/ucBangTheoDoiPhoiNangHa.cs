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
    public partial class ucBangTheoDoiPhoiNangHa : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTheoDoiPhoiNangHa()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
            colSTT3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView3.CustomUnboundColumnData += GridView3_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void GridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

                gridControl1.DataSource = client.BangFileChuaTaoPhiNangHa_Xem(Ngay1, Ngay2);

                gridControl2.DataSource = client.BangKeChiPhiNangHa_TheoNgay(Ngay1, Ngay2);

                gridControl3.DataSource = client.ChiPhiNangHa(Ngay1, Ngay2);
            }
        }

      

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _IDCP = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString().Trim());
            int _IDLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            Forms.frmBangKeChiPhiNangHa frm = new Forms.frmBangKeChiPhiNangHa(_IDCP, _IDLoHang, 1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            if (frmMain._TK != "admin")
                MessageBox.Show("Chỉ Admin mới có quyền này");
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //VudacoEntities context = new VudacoEntities();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string _check = gridView1.GetRowCellValue(i, "Chon").ToString();
                        if (_check == "True")
                        {
                            int _IDLoHang = int.Parse(gridView1.GetRowCellValue(i, "IDLoHang").ToString().Trim());
                            client.XoaThongTinFile(_IDLoHang);
                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            Form frm = new frmBangKeChiPhiNangHa(_IDLoHang);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            // VudacoEntities context = new VudacoEntities();
            //xoa bang ke da tao
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _idLoHang=int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
                bool check = client.BangPhoiNangHa_KiemTraFileGia(_idLoHang);
                if (check)
                    MessageBox.Show("Bảng phơi nâng hạ này có dữ liệu liên quan File Giá, vui lòng xóa ở File Giá trước để tiếp tục!");
                else
                {
                    client.dsBangPhoiNangHa_Xoa1(_idLoHang);
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            int _idLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString());
            Form frm = new frmBangKeChiPhiNangHa(_idLoHang, 1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            reports.rpt_BangKe_ChiHo rpt = new reports.rpt_BangKe_ChiHo();
            rpt.ShowPreview();
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                int _IDLoHang=int.Parse(gridView2.GetFocusedRowCellDisplayText("IDLoHang"));
                gridControl3.DataSource = client.ChiPhiNangHa_TheoIDLoHang(_IDLoHang);
            }
            catch (Exception)
            {
            }
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                gridView2.ExportToXlsx(dialog.SelectedPath+"/BangKeChiPhiNangHa.xlsx");
            }    
        }
    }
}
