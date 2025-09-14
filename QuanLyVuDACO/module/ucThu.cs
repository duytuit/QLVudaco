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
    public partial class ucThu : DevExpress.XtraEditors.XtraUserControl
    {
        public ucThu()
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
            var table = client.DanhsachThu();
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
            txtMaThu.Text = "";
            txtTenThu.Text = "";
            txtMaThu.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaThu.Text == "")
                MessageBox.Show("Vui lòng nhập mã danh mục thu!");
            else if (txtTenThu.Text == "")
                MessageBox.Show("Vui lòng nhập tên khoản thu");
            else
            {
                var table = client.DanhsachThu_TheoMa(txtMaThu.Text);
                if (table.Count() > 0)
                    MessageBox.Show("Mã danh mục thu này đã có, vui lòng nhập mã khác!");
                else
                {

                    ServiceReference1.DanhMucThu table1 = new ServiceReference1.DanhMucThu();
                    table1.MaThu = txtMaThu.Text;
                    table1.TenThu = txtTenThu.Text;
                    client.DanhSachThu_Them(table1);
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
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDThu").ToString());
                    txtMaThu.Text = gridView1.GetFocusedRowCellDisplayText("MaThu").ToString().Trim();
                    txtTenThu.Text = gridView1.GetFocusedRowCellDisplayText("TenThu").ToString().Trim();
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMaThu.Text == "")
                MessageBox.Show("Vui lòng nhập mã danh mục thu!");
            else if (txtTenThu.Text == "")
                MessageBox.Show("Vui lòng nhập tên khoản thu");
            else
            {
                var table = client.DanhsachThu_TheoMaID(txtMaThu.Text, _ID);
                if (table.Count() > 0)
                    MessageBox.Show("Mã danh mục thu này đã có, vui lòng nhập mã khác!");
                else
                {
                    ServiceReference1.DanhMucThu table1 = new ServiceReference1.DanhMucThu();
                    table1.IDThu = _ID;
                    table1.MaThu = txtMaThu.Text;
                    table1.TenThu = txtTenThu.Text;
                    client.DanhSachThu_Sua(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.DanhMucThu table1 = new ServiceReference1.DanhMucThu();
                table1.IDThu = _ID;
                client.DanhSachThu_Xoa(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
