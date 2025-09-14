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

namespace Quản_lý_vudaco.Forms
{
    public partial class frmQuyHoanCuocNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmQuyHoanCuocNhanVien()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmDoiTuong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            radioGroup1_SelectedIndexChanged(sender, e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLoaiQuy.EditValue != null)
                    frmCongNoGiaoNhan_CT._MaQuy = cboLoaiQuy.EditValue.ToString().Trim();
                else
                    frmCongNoGiaoNhan_CT._MaQuy = "";
                if (radioGroup1.SelectedIndex == 1)
                {
                    frmCongNoGiaoNhan_CT._SotK = lblSoTK.Text;
                    frmCongNoGiaoNhan_CT._ChuTK = lblChuTK.Text;
                    frmCongNoGiaoNhan_CT._TenNganHang = cboNganHang.Text;
                    frmCongNoGiaoNhan_CT._ChiNhanh = lblChiNhanh.Text;
                    frmCongNoGiaoNhan_CT._HinhThucTT = "CK";

                }
                else
                    frmCongNoGiaoNhan_CT._HinhThucTT = "TM";
                string[] arr1 = dtpNgay.Text.Split('/');
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                frmCongNoGiaoNhan_CT._Ngay = Ngay1;
                frmCongNoGiaoNhan_CT._DienGiai = txtDienGiai.Text;
                this.Close();
            }
            catch (Exception)
            {

               
            }
           
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex==0)
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
            }    
            else
            {
                panel1.Enabled = false;
                panel2.Enabled = true;

            }
            cboNganHang_SelectedIndexChanged(sender, e);
        }

        private void cboNganHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboNganHang.Text=="")
            {
                lblChuTK.Text = "";
                lblSoTK.Text = "";
                lblChiNhanh.Text = "";
            }    
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = cboNganHang.SelectedValue.ToString();
              var table=  client.DanhMucNganHang_Load_ThéoTK(p);
                foreach (var item in table)
                {
                    lblChuTK.Text = item.ChuTaiKhoan;
                    lblSoTK.Text = item.SoTK;
                    lblChiNhanh.Text = item.ChiNhanh;
                }
               
            }    
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLoaiQuy.EditValue != null)
                    frmCongNoGiaoNhan_CT._MaQuy = cboLoaiQuy.EditValue.ToString().Trim();
                else
                    frmCongNoGiaoNhan_CT._MaQuy = "";
                if (radioGroup1.SelectedIndex == 1)
                {
                    frmCongNoGiaoNhan_CT._SotK = lblSoTK.Text;
                    frmCongNoGiaoNhan_CT._ChuTK = lblChuTK.Text;
                    frmCongNoGiaoNhan_CT._TenNganHang = cboNganHang.Text;
                    frmCongNoGiaoNhan_CT._ChiNhanh = lblChiNhanh.Text;
                    frmCongNoGiaoNhan_CT._HinhThucTT = "CK";
                }
                else
                    frmCongNoGiaoNhan_CT._HinhThucTT = "TM";
                string[] arr1 = dtpNgay.Text.Split('/');
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                frmCongNoGiaoNhan_CT._Ngay = Ngay1;
                frmCongNoGiaoNhan_CT._In = 1;
                this.Close();
            }
            catch (Exception)
            {


            }
        }

        private void frmQuyHoanCuocNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Người dùng nhấn nút X hoặc gọi Close() từ code
                DialogResult result = MessageBox.Show("Bạn có chắc muốn lưu không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    frmMain._Luu = 0;
                }
                else
                    frmMain._Luu = 1;
            }
        }
    }
}