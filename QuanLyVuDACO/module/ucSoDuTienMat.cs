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
    public partial class ucSoDuTienMat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSoDuTienMat()
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
            gridControl1.DataSource = client.DauKy_Quy_Load();
            cboNganHang.Properties.DataSource = client.DanhMucNganHang_Load();
            cboQuy.Properties.DataSource = client.DanhMucQuy_Load();
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
            cboNganHang.EditValue = null;
            cboQuy.EditValue = null;
            txtSDDK.Text = "";
            txtSDDK.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboQuy.EditValue == null && cboNganHang.EditValue == null)
                MessageBox.Show("Vui lòng chọn quỹ hoặc tài khoản ngân hàng!");
            else if (cboQuy.Text.Trim() != "" && cboNganHang.Text.Trim() != "")
                MessageBox.Show("Vui lòng chỉ được chọn quỹ tiền mặt hoặc tài khoản ngân hàng!");
            else if (txtSDDK.Text == "")
                MessageBox.Show("Vui lòng nhập số dư đầu kỳ");
            else
            {


                ServiceReference1.DauKy_Quy table1 = new ServiceReference1.DauKy_Quy();
                    table1.MaQuy = (cboQuy.EditValue==null)?"":cboQuy.EditValue.ToString();
                    table1.SDDK = double.Parse(txtSDDK.Text);
                     table1.SoTK =(cboNganHang.EditValue==null)?"": cboNganHang.EditValue.ToString().Trim();
                    table1.TenNganHang = cboNganHang.Text;
                    table1.NguoiCapNhat = frmMain._TK;
                    table1.NgayCapNhat = DateTime.Now;
                    if (cboQuy.EditValue == null)
                        table1.HinhThucTT = "CK";
                    else
                        table1.HinhThucTT = "TM";
                client.DauKy_Quy_Luu(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                  
            }    
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDQuyCongNo").ToString());
                    cboQuy.EditValue = gridView1.GetFocusedRowCellValue("MaQuy").ToString();
                    cboNganHang.EditValue= gridView1.GetFocusedRowCellValue("SoTK").ToString();
                    txtSDDK.Text = gridView1.GetFocusedRowCellDisplayText("SDDK").ToString().Trim();
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (cboQuy.EditValue == null && cboNganHang.EditValue == null)
                MessageBox.Show("Vui lòng chọn quỹ hoặc tài khoản ngân hàng!");
            else if (cboQuy.Text.Trim() != "" && cboNganHang.Text.Trim() != "")
                MessageBox.Show("Vui lòng chỉ được chọn quỹ tiền mặt hoặc tài khoản ngân hàng!");
            else if (txtSDDK.Text == "")
                MessageBox.Show("Vui lòng nhập số dư đầu kỳ");
            else
            {


                ServiceReference1.DauKy_Quy table1 = new ServiceReference1.DauKy_Quy();
                table1.IDQuyCongNo = _ID;
                table1.MaQuy = (cboQuy.EditValue == null) ? "" : cboQuy.EditValue.ToString();
                table1.SDDK = double.Parse(txtSDDK.Text);
                table1.SoTK = (cboNganHang.EditValue == null) ? "" : cboNganHang.EditValue.ToString().Trim();
                table1.TenNganHang = cboNganHang.Text;
                table1.NguoiCapNhat = frmMain._TK;
                table1.NgayCapNhat = DateTime.Now;
                if (cboQuy.EditValue == null)
                    table1.HinhThucTT = "CK";
                else
                    table1.HinhThucTT = "TM";
                client.DauKy_Quy_CapNhat(table1);
                ucDanhSachTaiKhoan_Load(sender, e);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.DauKy_Quy table1 = new ServiceReference1.DauKy_Quy();
                client.DauKy_Quy_Xoa(_ID);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
