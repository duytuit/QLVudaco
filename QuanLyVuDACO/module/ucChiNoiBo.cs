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
    public partial class ucChiNoiBo : DevExpress.XtraEditors.XtraUserControl
    {
        public ucChiNoiBo()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucPhieuChi_Load(object sender, EventArgs e)
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
                if (Ngay1.Year == 1 || Ngay2.Year == 1)
                    MessageBox.Show("Ngày chọn không tồn tại!");
                else
                  gridControl2.DataSource = client.DanhSachPhieuChi_NoiBo_TheoNgay(Ngay1, Ngay2);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm = new Forms.frmPhieuChiNoiBo();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
          
           
                int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuChi"));
                Form frm = new Forms.frmPhieuChiNoiBo(_IDPhieuChi);
                frm.ShowDialog();
           
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
           
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu");
            client.DanhSachPhieuChi_NoiBo_Xoa2(_soChungTu);
                btnXem_Click(sender, e);
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if(e.RowHandle>=0)
                {
                    string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
                    gridControl1.DataSource = client.DanhSachPhieuChi_NoiBo_CT_TheoSoChungTu(_soChungTu);
                }    
            }
            catch (Exception)
            {
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                
                    string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
                    gridControl1.DataSource = client.DanhSachPhieuChi_NoiBo_CT_TheoSoChungTu(_soChungTu);
                
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
