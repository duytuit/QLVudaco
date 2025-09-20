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
            gridControl1.DataSource = client.DsTaiKhoan();

            using (var _db = new clsKetNoi())
            {
                // Lấy danh sách Roles
                string sqlRole = @"SELECT * FROM Roles";
                DataTable dtRole = _db.LoadTable(sqlRole);

                // Xóa item cũ
                checkedComboBoxRole.Properties.Items.Clear();

                // Đổ roles vào CheckedComboBoxEdit
                foreach (DataRow row in dtRole.Rows)
                {
                    checkedComboBoxRole.Properties.Items.Add(
                        row["id"],                 // Value
                        row["name"].ToString(),    // Text hiển thị
                        CheckState.Unchecked,
                        true
                    );
                }

              
            }

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
                    using (var _db = new clsKetNoi())
                    {
                        // lấy tài khoản vừa mới tạo
                        DataRow user = _db.GetSingleRecord("DanhSachTaiKhoan", txtTK.Text, "TaiKhoan",true);
                        if (user != null)
                        {
                            _db.DeleteById("Role_TaiKhoan", int.Parse(user["IDTaiKhoan"].ToString()), "user_id");
                            // Duyệt danh sách role được chọn
                            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in checkedComboBoxRole.Properties.Items)
                            {
                                if (item.CheckState == CheckState.Checked)
                                {
                                    // Lấy RoleId
                                    var roleId = item.Value;

                                    var Role_TaiKhoan_New = new
                                    {
                                        role_id = roleId,
                                        user_id = user["IDTaiKhoan"],
                                        created_at = DateTime.Now,
                                        updated_at = DateTime.Now,
                                        updated_by = frmMain._TK
                                    };

                                    _db.UpsertFromObjectByColumn("Role_TaiKhoan", Role_TaiKhoan_New,new[] { "user_id", "role_id" });

                                }
                            }
                        }
                    }
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
                using (var _db = new clsKetNoi())
                {
                    // 👉 Giả sử đang chọn user đầu tiên trong grid (bạn có thể thay đổi theo logic)
                    foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in checkedComboBoxRole.Properties.Items)
                    {
                        item.CheckState = CheckState.Unchecked;
                    }
                    if (gridView1.GetFocusedRowCellValue("IDTaiKhoan") != null)
                    {
                        var userId = gridView1.GetFocusedRowCellValue("IDTaiKhoan");

                        // Lấy các role đã gán cho user này
                        string sqlUserRoles = $@"SELECT role_id FROM Role_TaiKhoan WHERE user_id = {userId}";
                        DataTable dtUserRoles = _db.LoadTable(sqlUserRoles);
                        // Xóa item cũ
                        // Duyệt danh sách role đã có và check vào combobox
                        foreach (DataRow roleRow in dtUserRoles.Rows)
                        {
                            var roleId = roleRow["role_id"].ToString();

                            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in checkedComboBoxRole.Properties.Items)
                            {
                                if (item.Value.ToString() == roleId)
                                {
                                    item.CheckState = CheckState.Checked;
                                }
                            }
                        }
                    }
                }
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
                    using (var _db = new clsKetNoi())
                    {
                        // lấy tài khoản vừa mới tạo
                        DataRow user = _db.GetSingleRecord("DanhSachTaiKhoan", _ID, "IDTaiKhoan", true);
                        if (user != null)
                        {
                          
                            _db.DeleteById("Role_TaiKhoan", int.Parse(user["IDTaiKhoan"].ToString()), "user_id");
                           
                            // Duyệt danh sách role được chọn
                            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in checkedComboBoxRole.Properties.Items)
                            {
                                if (item.CheckState == CheckState.Checked)
                                {
                                    // Lấy RoleId
                                    var roleId = item.Value;

                                    var Role_TaiKhoan_New = new
                                    {
                                        role_id = roleId,
                                        user_id = user["IDTaiKhoan"],
                                        created_at = DateTime.Now,
                                        updated_at = DateTime.Now,
                                        updated_by = frmMain._TK
                                    };

                                    _db.UpsertFromObjectByColumn("Role_TaiKhoan", Role_TaiKhoan_New, new[] { "user_id", "role_id" });

                                }
                            }
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
                //DanhSachTaiKhoan table = context.DanhSachTaiKhoan.Single(p => p.IDTaiKhoan == _ID);
                //context.DanhSachTaiKhoan.Remove(table);
                //context.SaveChanges();
                ServiceReference1.DanhSachTaiKhoan p = new ServiceReference1.DanhSachTaiKhoan();
                p.IDTaiKhoan = _ID;
                client.DsTaiKhoan_Xoa(p);
                using (var _db = new clsKetNoi())
                {
                    DataRow user = _db.GetSingleRecord("DanhSachTaiKhoan", _ID, "IDTaiKhoan", true);
                    if (user != null)
                    {
                        _db.DeleteById("Role_TaiKhoan", int.Parse(user["IDTaiKhoan"].ToString()), "user_id");
                    }
                }
                ucDanhSachTaiKhoan_Load(sender, e);
            }
        }

        private void checkedComboBoxRole_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
