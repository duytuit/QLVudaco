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
    public partial class frmHoanTraPhieuTamThu : DevExpress.XtraEditors.XtraForm
    {
        public frmHoanTraPhieuTamThu()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmDoiTuong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                    frmCongNoGiaoNhan_CT._MaQuy = "";
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmMain._Luu = 0;
            this.Close();
        }
    }
}