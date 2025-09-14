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

namespace Quản_lý_vudaco
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
       // VudacoEntities context = new VudacoEntities();
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTK.Text = "";
            txtMK.Text = "";
            txtTK.Focus();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
                MessageBox.Show("Vui lòng nhập tài khoản!");
            else if (txtMK.Text == "")
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            else
            {
                // var table = context.DanhSachTaiKhoan.Where(p=>p.TaiKhoan==txtTK.Text);
               var table = client.DanhSachTaiKhoan(txtTK.Text);
                if (table.Count()==0)
                    MessageBox.Show("Không có tài khoản nào tồn tại!");
                else
                {
                    foreach (var item in table)
                    {
                        if(item.MatKhau!=txtMK.Text)
                            MessageBox.Show("Sai mật khẩu. Vui lòng thử lại!");
                        else
                        {
                            if(item.TrangThai.Value==false)
                                MessageBox.Show("Tài khoản đang bị khóa. Vui lòng liên hệ quản trị!");
                            else
                            {
                                frmMain._TK = txtTK.Text;
                                frmMain._HoTen = item.HoVaTen;
                                this.Hide();
                            }    
                        }    
                    }
                }    
            }    
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }

        private void txtTK_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMK_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}