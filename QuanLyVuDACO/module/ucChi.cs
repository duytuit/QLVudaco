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
    public partial class ucChi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucChi()
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
            var table =client.DanhsachChi();
            repositoryItemCha.DataSource = table.ToList();
            cboCha.Properties.DataSource = table.ToList();
            gridControl1.DataSource = table.ToList();
            gridView1.ExpandAllGroups();
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
            txtMaChi.Text = "";
            txtTenChi.Text = "";
            txtMaChi.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaChi.Text == "")
                MessageBox.Show("Vui lòng nhập mã danh mục chi!");
            else if (txtTenChi.Text == "")
                MessageBox.Show("Vui lòng nhập tên khoản chi");
            else
            {
                var table = client.DanhsachChi_TheoMa(txtMaChi.Text);
                if (table.Count() > 0)
                    MessageBox.Show("Mã danh mục chi này đã có, vui lòng nhập mã khác!");
                else
                {

                    ServiceReference1.DanhSachChi table1 = new ServiceReference1.DanhSachChi();
                    table1.MaChi = txtMaChi.Text.Trim();
                    table1.TenChi = txtTenChi.Text;
                    table1.MaCha = (cboCha.EditValue == null) ? "" : cboCha.EditValue.ToString().Trim();
                    client.DanhSachChi_Them(table1);
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
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDChi").ToString());
                    txtMaChi.Text = gridView1.GetFocusedRowCellDisplayText("MaChi").ToString().Trim();
                    txtTenChi.Text = gridView1.GetFocusedRowCellDisplayText("TenChi").ToString().Trim();
                    if (gridView1.GetFocusedRowCellValue("MaCha") != null)
                        cboCha.EditValue = gridView1.GetFocusedRowCellValue("MaCha");
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMaChi.Text == "")
                MessageBox.Show("Vui lòng nhập mã danh mục chi!");
            else if (txtTenChi.Text == "")
                MessageBox.Show("Vui lòng nhập tên khoản chi");
            else
            {
                var table = client.DanhsachChi_TheoMaID(txtMaChi.Text, _ID);
                if (table.Count() > 0)
                    MessageBox.Show("Mã danh mục chi này đã có, vui lòng nhập mã khác!");
                else
                {
                    ServiceReference1.DanhSachChi table1 = new ServiceReference1.DanhSachChi();
                    table1.IDChi = _ID;
                    table1.MaChi = txtMaChi.Text.Trim();
                    table1.TenChi = txtTenChi.Text;
                    table1.MaCha = (cboCha.EditValue == null) ? "" : cboCha.EditValue.ToString().Trim();
                    client.DanhSachChi_Sua(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.DanhSachChi table1 = new ServiceReference1.DanhSachChi();
                table1.IDChi = _ID;
                client.DanhSachChi_Xoa(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
