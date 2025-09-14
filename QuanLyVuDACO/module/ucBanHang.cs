using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class ucBanHang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBanHang()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucPhieuChi_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            repositoryItemKH.DataSource = client.dsKH();
            repositoryItemNhanVien.DataSource = client.dsNhanVien();
            var tThu = client.DanhsachThu().Where(p=>p.MaThu.Contains("007")) ;
            repositoryItemDSThu.DataSource = tThu.ToList();


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
                gridControl2.DataSource = client.DanhSachBanHang_TheoNgay(Ngay1, Ngay2);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm = new Forms.frmPhieuBanHang();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
          
            
                int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuBan"));
                Form frm = new Forms.frmPhieuBanHang(_IDPhieuChi);
                frm.ShowDialog();
          
           
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {

            int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuBan"));
            client.XoaPhieuBan(_IDPhieuChi);
            btnXem_Click(sender, e);
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if(e.RowHandle>=0)
                {
                    int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuBan"));
                    gridControl1.DataSource = client.DanhSachBanHang_CT_TheoIDPhieuBan(_IDPhieuChi);
                }    
            }
            catch (Exception ex)
            {
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {

                int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuBan"));
                gridControl1.DataSource = client.DanhSachBanHang_CT_TheoIDPhieuBan(_IDPhieuChi);

            }
            catch (Exception)
            {
            }
        }

      

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
          
        }
    }
}
