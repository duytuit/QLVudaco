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
    public partial class ucDanhSachTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            AnButton(true, false, false);
        }
        // VudacoEntities context = new VudacoEntities();
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            cboNhanVien.Properties.DataSource = client.dsNhanVien();
           // repositoryItemNhanVien.DataSource = client.dsNhanVien();
            gridControl1.DataSource = client.DsTaiKhoan();
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
            txtTK.Text = "";
            txtMK.Text = "";
            chkSuDung.Checked = false;
            cboNhanVien.EditValue = null;
            txtTK.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
                MessageBox.Show("Vui lòng nhập tài khoản!");
            else if (txtMK.Text == "")
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            else
            {
                //var table = context.DanhSachTaiKhoan.Where(p=>p.TaiKhoan==txtTK.Text);
                var table = client.DsTaiKhoan_TaiKhoan(txtTK.Text);
                if (table.Count() > 0)
                    MessageBox.Show("Tài khoản này đã có, vui lòng nhập tài khoản khác!");
                else
                {
                    ServiceReference1.DanhSachTaiKhoan table1 = new ServiceReference1.DanhSachTaiKhoan();
                    table1.TaiKhoan = txtTK.Text;
                    table1.MatKhau = txtMK.Text;
                    table1.TrangThai = chkSuDung.Checked;
                    table1.MaNhanVien = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString();
                    table1.HoVaTen = cboNhanVien.Text;
                    //context.DanhSachTaiKhoan.Add(table1);
                    //context.SaveChanges();
                    client.DsTaiKhoan_Them(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }    
            }    
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDTaiKhoan").ToString());
                txtTK.Text = gridView1.GetFocusedRowCellValue("TaiKhoan").ToString().Trim();
                txtMK.Text = gridView1.GetFocusedRowCellValue("MatKhau").ToString().Trim();
                cboNhanVien.EditValue=(gridView1.GetFocusedRowCellValue("MaNhanVien")==null)?"": gridView1.GetFocusedRowCellValue("MaNhanVien").ToString();
                chkSuDung.Checked = bool.Parse(gridView1.GetFocusedRowCellValue("TrangThai").ToString().Trim());
                AnButton(false, true, true);
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
                MessageBox.Show("Vui lòng nhập tài khoản!");
            else if (txtMK.Text == "")
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            else
            {
                //var table = context.DanhSachTaiKhoan.Where(p => p.TaiKhoan == txtTK.Text&&p.IDTaiKhoan!=_ID);
                var table = client.DsTaiKhoan_TaiKhoan_ID(txtTK.Text, _ID);
                if (table.Count() > 0)
                    MessageBox.Show("Tài khoản này đã có, vui lòng nhập tài khoản khác!");
                else
                {
                    //var table1 = context.DanhSachTaiKhoan.Single(p=>p.IDTaiKhoan==_ID);
                    //table1.TaiKhoan = txtTK.Text;
                    //table1.MatKhau = txtMK.Text;
                    //table1.TrangThai = chkSuDung.Checked;
                    //context.SaveChanges();
                    ServiceReference1.DanhSachTaiKhoan p = new ServiceReference1.DanhSachTaiKhoan();
                    p.TaiKhoan = txtTK.Text;
                    p.MatKhau = txtMK.Text;
                    p.TrangThai = chkSuDung.Checked;
                    p.HoVaTen = cboNhanVien.Text;
                    p.IDTaiKhoan = _ID;
                    p.MaNhanVien = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString();
                    client.DsTaiKhoan_Sua(p);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //DanhSachTaiKhoan table = context.DanhSachTaiKhoan.Single(p => p.IDTaiKhoan == _ID);
                //context.DanhSachTaiKhoan.Remove(table);
                //context.SaveChanges();
                ServiceReference1.DanhSachTaiKhoan p = new ServiceReference1.DanhSachTaiKhoan();
                p.IDTaiKhoan = _ID;
                client.DsTaiKhoan_Xoa(p);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
