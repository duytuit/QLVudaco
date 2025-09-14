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

namespace Quản_lý_vudaco.module
{
    public partial class ucDanhMucNganHang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhMucNganHang()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            AnButton(true, false, false);
        }
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            var table = client.DanhMucNganHang_Load();
            gridControl1.DataSource = table.ToList();
            btnThemMoi_Click(sender, e);
        }
        private void AnButton(bool luu, bool sua, bool xoa)
        {
            btnLuu.Enabled = luu;
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
        }
        private void XoaText()
        {
            txtSoTK.Text = "";
            txtTenNganHang.Text = "";
            txtChiNhanh.Text = "";
            txtChuTaiKhoan.Text = "";
            txtSoTK.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoTK.Text == "")
                MessageBox.Show("Vui lòng nhập số tài khoản!");
            else if (txtTenNganHang.Text == "")
                MessageBox.Show("Vui lòng nhập tên ngân hàng");
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = txtSoTK.Text;
                var table = client.DanhMucNganHang_Load_ThéoTK(p);
                if (table.Count() > 0)
                    MessageBox.Show("Số tài khoản này đã có, vui lòng nhập số khác!");
                else
                {

                    ServiceReference1.DanhMucNganHang table1 = new ServiceReference1.DanhMucNganHang();
                    table1.SoTK = txtSoTK.Text;
                    table1.TenNganHang = txtTenNganHang.Text;
                    table1.ChiNhanh = txtChiNhanh.Text;
                    table1.ChuTaiKhoan = txtChuTaiKhoan.Text;
                    client.DanhMucNganHang_Them(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }    
            }    
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDNganHang").ToString());
                    txtSoTK.Text = gridView1.GetFocusedRowCellDisplayText("SoTK").ToString().Trim();
                    txtTenNganHang.Text = gridView1.GetFocusedRowCellDisplayText("TenNganHang").ToString().Trim();
                    txtChiNhanh.Text = gridView1.GetFocusedRowCellDisplayText("ChiNhanh").ToString().Trim();
                    txtChuTaiKhoan.Text= gridView1.GetFocusedRowCellDisplayText("ChuTaiKhoan").ToString().Trim();
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtSoTK.Text == "")
                MessageBox.Show("Vui lòng nhập số tài khoản!");
            else if (txtTenNganHang.Text == "")
                MessageBox.Show("Vui lòng nhập tên ngân hàng");
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.IDNganHang = _ID;
                p.SoTK = txtSoTK.Text;
                var table = client.DanhMucNganHang_Load_ThéoTKID(p);
                if (table.Count() > 0)
                    MessageBox.Show("Số tài khoản này đã có, vui lòng nhập số khác!");
                else
                {
                    ServiceReference1.DanhMucNganHang table1 = new ServiceReference1.DanhMucNganHang();
                    table1.SoTK = txtSoTK.Text;
                    table1.TenNganHang = txtTenNganHang.Text;
                    table1.ChiNhanh = txtChiNhanh.Text;
                    table1.ChuTaiKhoan = txtChuTaiKhoan.Text;
                    table1.IDNganHang = _ID;
                    client.DanhMucNganHang_Sua(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.DanhMucNganHang table1 = new ServiceReference1.DanhMucNganHang();
                table1.IDNganHang = _ID;
                client.DanhMucNganHang_Xoa(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
