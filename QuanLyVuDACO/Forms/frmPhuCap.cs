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
    public partial class frmPhuCap : DevExpress.XtraEditors.XtraForm
    {
        public frmPhuCap()
        {
            InitializeComponent();
        }
        public frmPhuCap(string _MaNhanVien,string _TenNhanVien,int _Thang,int _Nam)
        {
            InitializeComponent();
            MaNhanVien = _MaNhanVien;
            TenNhanVien = _TenNhanVien;
            Thang = _Thang;
            Nam = _Nam;
        }
        string MaNhanVien = "", TenNhanVien = "";
        int Thang = 0;
        int Nam = 0;
        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = MaNhanVien;
            txtTenNhanVien.Text = TenNhanVien;
            this.CenterToScreen();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnThemPhuCap_Click(object sender, EventArgs e)
        {
            if (txtTenPhuCap.Text == "")
                MessageBox.Show("Nhập tên khoản phụ cấp!");
            else if(txtSoTien.Text=="")
                MessageBox.Show("Nhập số tiền phụ cấp!");
            else
            {
                ServiceReference1.NhanVien_PhuCap table = new ServiceReference1.NhanVien_PhuCap();
                table.MaNhanVien = txtMaNhanVien.Text.Trim();
                table.TenNhanVien = txtTenNhanVien.Text.Trim();
                table.Nam = Nam;
                table.Thang = Thang;
                table.TenPhuCap = txtTenPhuCap.Text;
                table.TienPhuCap = double.Parse(txtSoTien.Text);
                client.ThemPhuCap_Nhanvien(table);
                this.Close();
            }    
        }
    }
}