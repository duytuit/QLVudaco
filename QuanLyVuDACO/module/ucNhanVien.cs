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
    public partial class ucNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            BienSoXeTextEdit.Properties.DataSource = client.ds_Xe();
            XoaText();
            LoadMa();
            AnButton(true, false, false);
        }
        private void LoadMa()
        {
            var table = client.dsNhanVien().OrderByDescending(p=>p.ID).Take(1);
            if(table.Count()==0)
                MaNhanVienTextEdit.Text = "NV001";
            else
            {
                string s = "";
                foreach (var item in table)
                {
                    s = item.MaNhanVien.Substring(2,item.MaNhanVien.Trim().Length-1);
                    MaNhanVienTextEdit.Text = "NV" + (int.Parse(s)+1).ToString("00#");
                }
            }
        }
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            var table = client.dsNhanVien();
            var tablePB = client.dsPhongBan();
            MaPhongBanTextEdit.Properties.DataSource = tablePB.ToList();
            repositoryItemLookUpEdit1.DataSource = tablePB.ToList();
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
            MaNhanVienTextEdit.Text = "";
            TenNhanVienTextEdit.Text = "";
            DiaChiTextEdit.Text = "";
            DienThoaiTextEdit.Text = "";
            DiaChiTextEdit.Text = "";
            CCCDTextEdit.Text = "";
            GPLXTextEdit.Text = "";
            TenNhanVienTextEdit.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (TenNhanVienTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
            else
            {
               
                
                    ServiceReference1.NhanVien table1 = new ServiceReference1.NhanVien();
                    table1.MaNhanVien = MaNhanVienTextEdit.Text;
                    table1.TenNhanVien = TenNhanVienTextEdit.Text;
                    table1.DienThoai = DienThoaiTextEdit.Text;
                    table1.DiaChi = DiaChiTextEdit.Text;
                    table1.CCCD = CCCDTextEdit.Text;
                    table1.GPLX = GPLXTextEdit.Text;
                table1.NCCNgoai = NCCNgoaiCheckEdit.Checked;
                table1.BienSoXe = (BienSoXeTextEdit.EditValue == null) ? "" : BienSoXeTextEdit.EditValue.ToString();
                table1.MaPhongBan = (MaPhongBanTextEdit.EditValue == null) ? "" : MaPhongBanTextEdit.EditValue.ToString();
                    client.NhanVien_Them(table1);
                ucDanhSachTaiKhoan_Load(sender, e);
                   
            }    
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    MaNhanVienTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("MaNhanVien").ToString().Trim();
                    TenNhanVienTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("TenNhanVien").ToString().Trim();
                    DiaChiTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("DiaChi").ToString().Trim();
                    DienThoaiTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("DienThoai").ToString().Trim();
                    CCCDTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("CCCD").ToString().Trim();
                    GPLXTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("GPLX").ToString().Trim();
                    MaPhongBanTextEdit.EditValue =(gridView1.GetFocusedRowCellValue("MaPhongBan")==null)?"": gridView1.GetFocusedRowCellValue("MaPhongBan").ToString();
                    BienSoXeTextEdit.EditValue = (gridView1.GetFocusedRowCellValue("BienSoXe") == null) ? "" : gridView1.GetFocusedRowCellValue("BienSoXe").ToString();
                    NCCNgoaiCheckEdit.Checked = bool.Parse(gridView1.GetFocusedRowCellValue("NCCNgoai").ToString());
                    AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (TenNhanVienTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
            else
            {
                ServiceReference1.NhanVien table1 = new ServiceReference1.NhanVien();
                table1.ID = _ID;
                table1.MaNhanVien = MaNhanVienTextEdit.Text;
                table1.TenNhanVien = TenNhanVienTextEdit.Text;
                table1.DienThoai = DienThoaiTextEdit.Text;
                table1.DiaChi = DiaChiTextEdit.Text;
                table1.CCCD = CCCDTextEdit.Text;
                table1.GPLX = GPLXTextEdit.Text;
                table1.NCCNgoai = NCCNgoaiCheckEdit.Checked;
                table1.MaPhongBan = (MaPhongBanTextEdit.EditValue == null) ? "" : MaPhongBanTextEdit.EditValue.ToString();
                table1.BienSoXe = (BienSoXeTextEdit.EditValue == null) ? "" : BienSoXeTextEdit.EditValue.ToString();
                bool ischeck = client.NhanVien_KTra_sua(table1);
                if (!ischeck)
                {
                  
                    client.NhanVien_Sua(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
                else
                    MessageBox.Show("Mã nhân viên này đang được sử dụng, không được đổi mã!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool ischeck = false;
                var table = client.dsNhanVien();
                foreach (var item in table)
                {
                    if (item.ID == _ID)
                    {
                        ischeck = client.KiemTraTonTaiMaNhanVien(MaNhanVienTextEdit.Text);
                        break;
                    }
                }
                if (!ischeck)
                {
                    ServiceReference1.NhanVien table1 = new ServiceReference1.NhanVien();
                    table1.ID = _ID;
                    client.NhanVien_Xo(table1);
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
                else
                    MessageBox.Show("Mã nhân viên này đang được sử dụng, không được xoá!");
            }
        }
    }
}
