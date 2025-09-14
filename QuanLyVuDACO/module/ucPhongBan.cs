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
    public partial class ucPhongBan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPhongBan()
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
            var table = client.dsPhongBan();
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
            MaPhongBanTextEdit.Text = "";
            TenPhongBanTextEdit.Text = "";
            GhiChuTextEdit.Text = "";
            MaPhongBanTextEdit.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MaPhongBanTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập mã phòng ban!");
            else if (TenPhongBanTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập tên phòng ban!");
            else
            {
               

                    ServiceReference1.PhongBan table1 = new ServiceReference1.PhongBan();
                    table1.MaPhongBan = MaPhongBanTextEdit.Text;
                    table1.TenPhongBan = TenPhongBanTextEdit.Text;
                    table1.GhiChu = GhiChuTextEdit.Text;
                    client.ThemPhongBan(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
                   
            }    
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDPhongBan").ToString());
                    MaPhongBanTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("MaPhongBan").ToString().Trim();
                    TenPhongBanTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("TenPhongBan").ToString().Trim();
                    GhiChuTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("GhiChu").ToString().Trim();
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (MaPhongBanTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập mã phòng ban!");
            else if (TenPhongBanTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập tên phòng ban!");
            else
            {
                ServiceReference1.PhongBan table1 = new ServiceReference1.PhongBan();
                table1.IDPhongBan = _ID;
                table1.MaPhongBan = MaPhongBanTextEdit.Text;
                table1.TenPhongBan = TenPhongBanTextEdit.Text;
                table1.GhiChu = GhiChuTextEdit.Text;
                client.SuaPhongBan(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.PhongBan table1 = new ServiceReference1.PhongBan();
                table1.IDPhongBan = _ID;
                client.XoaPhongBan(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
