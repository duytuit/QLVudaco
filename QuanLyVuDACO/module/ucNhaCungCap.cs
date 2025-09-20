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
    public partial class ucNhaCungCap : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNhaCungCap()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            AnButton(true, false, false);
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = client.ds_NCC();
            btnThemMoi_Click(sender, e);
        }
        private void AnButton(bool luu, bool sua, bool xoa)
        {
            btnLuu.Enabled = luu;
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
            if (btnSua.Enabled)
            {
                if (frmMain._TK.ToLower() != "admin")
                    MaNhaCungCapTextEdit.Enabled = false;
            }
            else
                MaNhaCungCapTextEdit.Enabled = true;
        }
        private void XoaText()
        {
            MaNhaCungCapTextEdit.Text = "";
            TenNhaCungCapTextEdit.Text = "";
            DiaChiTextEdit.Text = "";
            EmailTextEdit.Text = "";
            STKTextEdit.Text = "";
            LaKhachHangpCheckEdit.Checked = false;
            GhiChuTextEdit.Text = "";
            SoDienThoaiTextEdit.Text = "";
            NoToiDaTextEdit.Text = "0";
            SoNgayDuocNoTextEdit.Text = "";
            TenVietTatTextEdit.Text = "";
            MaNhaCungCapTextEdit.Focus();
        }
        int _ID = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MaNhaCungCapTextEdit.Text == "")
                MessageBox.Show("Vui lòng mã nhà cung cấp!");
            else if (TenNhaCungCapTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
            else if (MaNhaCungCapTextEdit.Text.Trim().Length > 20)
                MessageBox.Show("Độ dài mã nhà cung cấp không được lớn hơn 20 kí tự!");
            else
            {
                var table = client.dsNCC_MaNCC(MaNhaCungCapTextEdit.Text);
                if (table.Count() > 0)
                    MessageBox.Show("Mã nhà cung cấp này đã có, vui lòng nhập mã khác!");
                else
                {
                    ServiceReference1.DanhSachNhaCungCap table1 = new ServiceReference1.DanhSachNhaCungCap();
                    table1.MaNhaCungCap = MaNhaCungCapTextEdit.Text;
                    table1.TenVietTat = TenVietTatTextEdit.Text;
                    table1.TenNhaCungCap = TenNhaCungCapTextEdit.Text;
                    table1.DiaChi = DiaChiTextEdit.Text;
                    table1.MaSoThue = MaSoThueTextEdit.Text;
                    table1.SoDienThoai = SoDienThoaiTextEdit.Text;
                    table1.Email = EmailTextEdit.Text;
                    table1.STK = STKTextEdit.Text;
                    table1.SoNgayDuocNo = (SoNgayDuocNoTextEdit.Text == "" ? 0 : int.Parse(SoNgayDuocNoTextEdit.Text));
                    table1.NoToiDa = (NoToiDaTextEdit.Text == "") ? 0 : float.Parse(NoToiDaTextEdit.Text);
                    table1.LaKhachHang = LaKhachHangpCheckEdit.Checked;
                    table1.GhiChu = GhiChuTextEdit.Text;
                    client.ds_NCC_Them(table1);
                    //
                    if(LaKhachHangpCheckEdit.Checked)
                    {
                        ServiceReference1.DanhSachKhachHang table2 = new ServiceReference1.DanhSachKhachHang();
                        table2.MaKhachHang = MaNhaCungCapTextEdit.Text;
                        table2.TenVietTat = TenVietTatTextEdit.Text;
                        table2.TenKhachHang = TenNhaCungCapTextEdit.Text;
                        table2.DiaChi = DiaChiTextEdit.Text;
                        table2.MaSoThue = MaSoThueTextEdit.Text;
                        table2.SoDienThoai = SoDienThoaiTextEdit.Text;
                        table2.Email = EmailTextEdit.Text;
                        table2.STK = STKTextEdit.Text;
                        table2.SoNgayDuocNo = (SoNgayDuocNoTextEdit.Text == "" ? 0 : int.Parse(SoNgayDuocNoTextEdit.Text));
                        table2.NoToiDa = (NoToiDaTextEdit.Text == "") ? 0 : float.Parse(NoToiDaTextEdit.Text);
                        table2.LaNhaCungCap = LaKhachHangpCheckEdit.Checked;
                        table2.GhiChu = GhiChuTextEdit.Text;
                        client.dsKH_Them(table2);
                    }    
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
                    _ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    MaNhaCungCapTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("MaNhaCungCap").ToString().Trim();
                    TenNhaCungCapTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("TenNhaCungCap").ToString().Trim();
                    DiaChiTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("DiaChi").ToString().Trim();
                    MaSoThueTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("MaSoThue").ToString().Trim();
                    SoDienThoaiTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("SoDienThoai").ToString().Trim();
                    EmailTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("Email").ToString().Trim();
                    STKTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("STK").ToString().Trim();
                    SoNgayDuocNoTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("SoNgayDuocNo").ToString().Trim();
                    NoToiDaTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("NoToiDa").ToString().Trim();
                    LaKhachHangpCheckEdit.Checked = bool.Parse(gridView1.GetFocusedRowCellValue("LaKhachHang").ToString().Trim());
                    GhiChuTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("GhiChu").ToString().Trim();
                    TenVietTatTextEdit.Text = gridView1.GetFocusedRowCellDisplayText("TenVietTat").ToString().Trim();
                    if (frmMain._TK == "admin")
                    {
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                    }
                    else
                      AnButton(false, true, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (MaNhaCungCapTextEdit.Text == "")
                MessageBox.Show("Vui lòng mã nhà cung cấp!");
            else if (TenNhaCungCapTextEdit.Text == "")
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
            else if (MaNhaCungCapTextEdit.Text.Trim().Length > 20)
                MessageBox.Show("Độ dài mã nhà cung cấp không được lớn hơn 20 kí tự!");
            else
            {
                var table = client.dsNCC_MaNCC_ID(MaNhaCungCapTextEdit.Text, _ID);
                if (table.Count() > 0)
                    MessageBox.Show("Mã nhà cung cấp này đã có, vui lòng nhập mã khác!");
                else
                {
                    ServiceReference1.DanhSachNhaCungCap table1 = new ServiceReference1.DanhSachNhaCungCap();
                    table1.ID = _ID;
                    table1.MaNhaCungCap = MaNhaCungCapTextEdit.Text;
                    table1.TenVietTat = TenVietTatTextEdit.Text;
                    table1.TenNhaCungCap = TenNhaCungCapTextEdit.Text;
                    table1.DiaChi = DiaChiTextEdit.Text;
                    table1.MaSoThue = MaSoThueTextEdit.Text;
                    table1.SoDienThoai = SoDienThoaiTextEdit.Text;
                    table1.Email = EmailTextEdit.Text;
                    table1.STK = STKTextEdit.Text;
                    table1.SoNgayDuocNo = (SoNgayDuocNoTextEdit.Text == "" ? 0 : int.Parse(SoNgayDuocNoTextEdit.Text));
                    table1.NoToiDa = (NoToiDaTextEdit.Text == "") ? 0 : float.Parse(NoToiDaTextEdit.Text);
                    table1.LaKhachHang = LaKhachHangpCheckEdit.Checked;
                    table1.GhiChu = GhiChuTextEdit.Text;
                    client.ds_NCC_Sua(table1);
                //
                if (LaKhachHangpCheckEdit.Checked)
                {
                        // var tCheck = context.DanhSachKhachHang.Where(p => p.MaKhachHang == table1.MaNhaCungCap);
                        var tCheck = client.dsKH_MaKH(table1.MaNhaCungCap);
                    if (tCheck.Count() == 0)
                    {
                        ServiceReference1.DanhSachKhachHang table2 = new ServiceReference1.DanhSachKhachHang();
                        table2.MaKhachHang = MaNhaCungCapTextEdit.Text;
                        table2.TenVietTat = TenVietTatTextEdit.Text;
                        table2.TenKhachHang = TenNhaCungCapTextEdit.Text;
                        table2.DiaChi = DiaChiTextEdit.Text;
                        table2.MaSoThue = MaSoThueTextEdit.Text;
                        table2.SoDienThoai = SoDienThoaiTextEdit.Text;
                        table2.Email = EmailTextEdit.Text;
                        table2.STK = STKTextEdit.Text;
                        table2.SoNgayDuocNo = (SoNgayDuocNoTextEdit.Text == "" ? 0 : int.Parse(SoNgayDuocNoTextEdit.Text));
                        table2.NoToiDa = (NoToiDaTextEdit.Text == "") ? 0 : float.Parse(NoToiDaTextEdit.Text);
                        table2.LaNhaCungCap = LaKhachHangpCheckEdit.Checked;
                        table2.GhiChu = GhiChuTextEdit.Text;
                         client.dsKH_Them(table2);
                    }
                    else
                    {
                       ServiceReference1.DanhSachKhachHang table2 = new ServiceReference1.DanhSachKhachHang();
                        table2.TenVietTat = TenVietTatTextEdit.Text;
                        table2.MaKhachHang = MaNhaCungCapTextEdit.Text;
                        table2.TenKhachHang = TenNhaCungCapTextEdit.Text;
                        table2.DiaChi = DiaChiTextEdit.Text;
                        table2.MaSoThue = MaSoThueTextEdit.Text;
                        table2.SoDienThoai = SoDienThoaiTextEdit.Text;
                        table2.Email = EmailTextEdit.Text;
                        table2.STK = STKTextEdit.Text;
                        table2.SoNgayDuocNo = (SoNgayDuocNoTextEdit.Text == "" ? 0 : int.Parse(SoNgayDuocNoTextEdit.Text));
                        table2.NoToiDa = (NoToiDaTextEdit.Text == "") ? 0 : float.Parse(NoToiDaTextEdit.Text);
                        table2.LaNhaCungCap = LaKhachHangpCheckEdit.Checked;
                        table2.GhiChu = GhiChuTextEdit.Text;
                        client.ds_KH_Sua_TheoMa(table2);
                    }
                }
                    ucDanhSachTaiKhoan_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                client.ds_NCC_Xoa(_ID);
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }
    }
}
