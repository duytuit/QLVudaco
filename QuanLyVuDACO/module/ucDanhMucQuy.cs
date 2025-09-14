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
    public partial class ucDanhMucQuy : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhMucQuy()
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
            var table = client.DanhMucQuy_Load();
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
            txtMaQuy.Text = "";
            txtTenQuy.Text = "";
            txtMaQuy.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaQuy.Text == "")
                MessageBox.Show("Vui lòng nhập mã quỹ!");
            else if (txtTenQuy.Text == "")
                MessageBox.Show("Vui lòng nhập tên quỹ");
            else
            {
                ServiceReference1.DanhMucQuy p = new ServiceReference1.DanhMucQuy();
                p.MaQuy = txtMaQuy.Text;
                var table = client.DanhMucQuy_Load_ThéoMaQuy(p);
                if (table.Count() > 0)
                    MessageBox.Show("Mã quỹ này đã có, vui lòng nhập số khác!");
                else
                {

                    ServiceReference1.DanhMucQuy table1 = new ServiceReference1.DanhMucQuy();
                    table1.MaQuy = txtMaQuy.Text;
                    table1.TenQuy = txtTenQuy.Text;
                    client.DanhMucQuy_Them(table1);
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
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDQuy").ToString());
                    txtMaQuy.Text = gridView1.GetFocusedRowCellDisplayText("MqQuy").ToString().Trim();
                    txtTenQuy.Text = gridView1.GetFocusedRowCellDisplayText("TenQuy").ToString().Trim();
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMaQuy.Text == "")
                MessageBox.Show("Vui lòng nhập mã quỹ!");
            else if (txtTenQuy.Text == "")
                MessageBox.Show("Vui lòng nhập tên quỹ");
            else
            {
                ServiceReference1.DanhMucQuy p = new ServiceReference1.DanhMucQuy();
                p.IDQuy = _ID;
                p.MaQuy = txtMaQuy.Text;
                var table = client.DanhMucQuy_Load_ThéoMaQuyID(p);
                if (table.Count() > 0)
                    MessageBox.Show("Mã quỹ này đã có, vui lòng nhập số khác!");
                else
                {
                    ServiceReference1.DanhMucQuy table1 = new ServiceReference1.DanhMucQuy();
                    table1.IDQuy = _ID;
                    table1.MaQuy = txtMaQuy.Text;
                    table1.TenQuy = txtTenQuy.Text;
                    client.DanhMucQuy_Sua(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.DanhMucQuy table1 = new ServiceReference1.DanhMucQuy();
                table1.IDQuy = _ID;
                client.DanhMucQuy_Xoa(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
