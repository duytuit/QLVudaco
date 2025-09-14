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
    public partial class ucDanhSachXe : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhSachXe()
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
            var table = client.ds_Xe();
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
            BienSoXeTextEdit.Text = "";
            BienSoXeTextEdit.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (BienSoXeTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập biển số xe!");
            else
            {
               

                    ServiceReference1.DanhSachXe table1 = new ServiceReference1.DanhSachXe();
                    table1.BienSoXe = BienSoXeTextEdit.Text;
                table1.GhiChu = txtGhiChu.Text;
                table1.LaXeNgoai = chkLaXeNgoai.Checked;
                    client.DanhSachXe_Them(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
                   
            }    
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("IDXe").ToString());
                    BienSoXeTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("BienSoXe").ToString().Trim();
                    chkLaXeNgoai.Checked = bool.Parse(gridView1.GetFocusedRowCellValue("LaXeNgoai").ToString());
                    txtGhiChu.Text= gridView1.GetFocusedRowCellDisplayText("GhiChu").ToString().Trim();
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

           
           if (BienSoXeTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập biển số xe!");
            else
            {
                ServiceReference1.DanhSachXe table1 = new ServiceReference1.DanhSachXe();
                table1.IDXe = _ID;
                table1.BienSoXe = BienSoXeTextEdit.Text;
                table1.GhiChu = txtGhiChu.Text;
                table1.LaXeNgoai = chkLaXeNgoai.Checked;
                client.DanhSachXe_Sua(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.DanhSachXe table1 = new ServiceReference1.DanhSachXe();
                table1.IDXe = _ID;
                client.DanhSachXe_Xoa(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
