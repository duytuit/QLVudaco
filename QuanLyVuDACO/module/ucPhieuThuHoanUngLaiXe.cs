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

namespace Quản_lý_vudaco.module
{
    public partial class ucPhieuThuHoanUngLaiXe : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPhieuThuHoanUngLaiXe()
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
                gridControl2.DataSource = client.DanhSachPhieuThuHoanUngLaiXe_TheoNgay(Ngay1, Ngay2);
            }
        }


        private void repositoryItemSua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

       
        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu");
            ServiceReference1.PhieuThu_LaiXe p = new ServiceReference1.PhieuThu_LaiXe();
            p.IDPhieuThu= int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuThu"));
            client.DanhSachPhieuThuLaiXe_Xoa(p);
            client.PhieuThuLaiXe_CT_Xoa(_soChungTu);
            btnXem_Click(sender, e);
          
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if(e.RowHandle>=0)
                {
                    string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
                    gridControl1.DataSource = client.DanhSachPhieuThuLaiXe_CT_TheoSoChungTu(_soChungTu);
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
                
                    string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
                    gridControl1.DataSource = client.DanhSachPhieuThuLaiXe_CT_TheoSoChungTu(_soChungTu);
                
            }
            catch (Exception)
            {
            }
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            //in phieu thu
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
            DateTime _NgayHachToan = DateTime.Parse(gridView2.GetFocusedRowCellValue("NgayHachToan").ToString().Trim());
           
                DataTable dt = client.DanhSachPhieuThuLaiXe_CT_TheoSoChungTu(_soChungTu);
                reports.rpt_PhieuThuLaiXe rpt = new reports.rpt_PhieuThuLaiXe(dt, _NgayHachToan);
                rpt.ShowPreview();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = client.DanhSachPhieuThuLaiXe_TheoSoFile(txtSoFile.Text);
            gridControl1.DataSource = client.DanhSachPhieuThu_LaiXe_CT_TheoSoFile(txtSoFile.Text);
        }

        private void txtSoFile_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
