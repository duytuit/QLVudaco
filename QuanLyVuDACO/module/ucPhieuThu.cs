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
    public partial class ucPhieuThu : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPhieuThu()
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
                gridControl2.DataSource = client.DanhSachPhieuThu_TheoNgay(Ngay1, Ngay2);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm = new Forms.frmPhieuThu();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            
            string _maThu = gridView2.GetFocusedRowCellDisplayText("MaThu").Trim();
            if (_maThu != "001")
            {
                int _IDPhieuThu = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuThu"));
                Form frm = new Forms.frmPhieuThu(_IDPhieuThu);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Phiếu thu hoàn ứng chỉ có thể xoá và tạo lại ở Bảng liệt kê chi phí!");

            }
            btnXem_Click(sender, e);
           
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
           // string _soFile = gridView2.GetFocusedRowCellDisplayText("SoFile");
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu");
            // string _MaNhanVien = gridView2.GetFocusedRowCellDisplayText("MaNhanVien");
            //  int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuThu"));
            //  bool isCheck = client.KiemTraPhieuChi_XacNhanHoanUng_Admin_TheoSoFile(_soFile);
            //  string _MaChi = gridView2.GetFocusedRowCellDisplayText("MaChi");
            //if (isCheck)
            //    MessageBox.Show("Lô hàng này đã xác nhận hoàn ứng- không được sửa xoá!");
            //else
            //{
            ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
            p.IDPhieuThu= int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuThu"));
            DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
            client.DanhSachPhieuThu_Xoa(p);
                client.PhieuThu_CT_Xoa(_soChungTu);
            string _maThu = gridView2.GetFocusedRowCellDisplayText("MaThu").Trim();
            if (_maThu == "001")
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int _IDCP = int.Parse(dt.Rows[i]["IDCP"].ToString());
                    client.BangKeChiPhi_XacNhanHoanUng_Huy(_IDCP);
                }
            }
            btnXem_Click(sender, e);
           // }
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if(e.RowHandle>=0)
                {
                    string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
                    gridControl1.DataSource = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
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
                    gridControl1.DataSource = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
                
            }
            catch (Exception)
            {
            }
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            //in phieu thu
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
            string _maThu = gridView2.GetFocusedRowCellDisplayText("MaThu").Trim();
            DateTime _NgayHachToan = DateTime.Parse(gridView2.GetFocusedRowCellValue("NgayHachToan").ToString().Trim());
            if (_maThu.Trim() != "001")
            {
                DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
                reports.rpt_PhieuThu rpt = new reports.rpt_PhieuThu(dt, _NgayHachToan);
                rpt.ShowPreview();
            }
            else
            {
                DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
                reports.rpt_PhieuThuHoanUng rpt = new reports.rpt_PhieuThuHoanUng(dt, _NgayHachToan);
                rpt.ShowPreview();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = client.DanhSachPhieuThu_TheoSoFile(txtSoFile.Text);
            gridControl1.DataSource = client.DanhSachPhieuThu_CT_TheoSoFile(txtSoFile.Text);
        }

        private void txtSoFile_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
