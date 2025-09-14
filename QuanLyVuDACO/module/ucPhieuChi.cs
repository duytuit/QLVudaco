using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Quản_lý_vudaco.services;
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
    public partial class ucPhieuChi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPhieuChi()
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
                    using (var _ncc = new ncc())
                    {
                        gridControl2.DataSource = _ncc.DanhSachPhieuChi_TheoNgay(Ngay1, Ngay2);
                    }
                      //gridControl2.DataSource = client.DanhSachPhieuChi_TheoNgay(Ngay1, Ngay2);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm = new Forms.frmPhieuChi();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
          
            string _maChi = gridView2.GetFocusedRowCellDisplayText("MaChi").Trim();
            if (_maChi != "001")
            {
                int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuChi"));
                Form frm = new Forms.frmPhieuChi(_IDPhieuChi);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Phiếu chi hoàn ứng chỉ có thể xoá và tạo lại ở Bảng liệt kê chi phí!");

            }
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
           // string _soFile = gridView2.GetFocusedRowCellDisplayText("SoFile");
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu");
          
            int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellDisplayText("IDPhieuChi"));
          //  bool isCheck = client.KiemTraPhieuChi_XacNhanHoanUng_Admin_TheoSoFile(_soFile);
            string _MaChi = gridView2.GetFocusedRowCellDisplayText("MaChi");
            //if (isCheck)
            //    MessageBox.Show("Lô hàng này đã xác nhận hoàn ứng- không được sửa xoá!");
            //else
            //{
                ServiceReference1.PhieuChi p = new ServiceReference1.PhieuChi();
                p.IDPhieuChi = _IDPhieuChi;
            DataTable dt = client.DanhSachPhieuChi_CT_TheoSoChungTu(_soChungTu);
            client.DanhSachPhieuChi_Xoa(p);
                client.PhieuChi_CT_Xoa(_soChungTu);
            string _maChi = gridView2.GetFocusedRowCellDisplayText("MaChi").Trim();
            if (_maChi == "001")
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int _IDCP = int.Parse(dt.Rows[i]["IDCP"].ToString());
                    client.BangKeChiPhi_XacNhanHoanUng_Huy(_IDCP);
                }
            }
            else if (_maChi == "007")
            {
                var table1 = client.DanhSachPhieuChi_CT_TheoIDPhieuChi(_IDPhieuChi);
                foreach (var item in table1)
                {
                    client.CapNhatDuyetUng_TheoSoFile(item.SoFile, item.MaNhanVien);
                }
              
            }


                btnXem_Click(sender, e);
            //}
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if(e.RowHandle>=0)
                {
                    string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
                    gridControl1.DataSource = client.DanhSachPhieuChi_CT_TheoSoChungTu(_soChungTu);
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
                    gridControl1.DataSource = client.DanhSachPhieuChi_CT_TheoSoChungTu(_soChungTu);
                
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = client.DanhSachPhieuChi_TheoSoFile(txtSoFile.Text);
            gridControl1.DataSource = client.DanhSachPhieuChi_CT_TheoSoFile(txtSoFile.Text);
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            string _soChungTu = gridView2.GetFocusedRowCellDisplayText("SoChungTu").Trim();
            string _maChi = gridView2.GetFocusedRowCellDisplayText("MaChi").Trim();
            DateTime _NgayHachToan = DateTime.Parse(gridView2.GetFocusedRowCellValue("NgayHachToan").ToString().Trim());
            if (_maChi.Trim() != "001")
            {
                //DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
                //reports.rpt_PhieuChi rpt = new reports.rpt_PhieuChi(dt, _NgayHachToan);
                //rpt.ShowPreview();
            }
            else
            {
                DataTable dt = client.DanhSachPhieuChi_CT_TheoSoChungTu(_soChungTu);
                reports.rpt_PhieuChiHoanUng rpt = new reports.rpt_PhieuChiHoanUng(dt, _NgayHachToan);
                rpt.ShowPreview();
            }
        }
    }
}
