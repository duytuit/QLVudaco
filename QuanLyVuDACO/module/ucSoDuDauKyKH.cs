using DevExpress.XtraEditors;
using Quản_lý_vudaco.services;
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
    public partial class ucSoDuDauKyKH : DevExpress.XtraEditors.XtraUserControl
    {
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private int _id = 0;
        public ucSoDuDauKyKH()
        {
            InitializeComponent();
        }
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            cboKH.Properties.DataSource = client.dsKH();
            txtNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void LoadData()
        {
            using (var sd = new sodudauky())
            {
                gridControl1.DataSource = sd.GetDataKH();
            }
        }
        private void repositoryItemHyperLinkSua_Click(object sender, EventArgs e)
        {
            _id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            using (var _db = new clsKetNoi())
            {
                DataRow _row = _db.GetSingleRecord("SoDuDauKy", _id, "ID");
                if (_row != null)
                {
                    // Gán dữ liệu lên control
                    cboKH.EditValue = _row["MaDoiTuong"].ToString();   // hoặc "MaNhaCungCap" tùy tên cột
                    txtSoHoaDon.Text = _row["SoHoaDon"].ToString();
                    txtSDDK.Text = _row["SoTien"].ToString();

                    if (_row["NgayHachToan"] != DBNull.Value)
                        txtNgayHachToan.Text = Convert.ToDateTime(_row["NgayHachToan"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void repositoryItemHyperLinkXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                using (var _db = new clsKetNoi())
                {
                    _db.DeleteById("SoDuDauKy", _ID, "ID");
                }
                LoadData();
            }
        }
        private void ClearForm()
        {
            txtSDDK.Text = string.Empty;
            cboKH.EditValue = null;   // clear chọn trong GridLookUpEdit
            txtSoHoaDon.Text = string.Empty;
            txtNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate cơ bản
            if (cboKH.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoHoaDon.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Số hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHoaDon.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNgayHachToan.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Ngày hạch toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayHachToan.Focus();
                return;
            }

            // Kiểm tra ngày hợp lệ
            DateTime ngayHachToan;
            if (!DateTime.TryParse(txtNgayHachToan.Text, out ngayHachToan))
            {
                XtraMessageBox.Show("Ngày hạch toán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayHachToan.Focus();
                return;
            }

            try
            {
                using (var _db = new clsKetNoi())
                {
                    // Số dư đầu kỳ
                    double soDuDauKy = 0;
                    if (!string.IsNullOrWhiteSpace(txtSDDK.Text))
                        double.TryParse(txtSDDK.Text.Replace(",", "").Replace(".", ""), out soDuDauKy);

                    var p = new
                    {
                        ID = _id > 0 ? _id : 0, // nếu >0 thì update, còn 0 thì insert
                        MaDoiTuong = cboKH.EditValue?.ToString(),
                        SoHoaDon = txtSoHoaDon.Text.Trim(),
                        NgayHachToan = ngayHachToan,
                        SoTien = soDuDauKy,
                        Loai = 2,
                        NgayTao = DateTime.Now
                    };

                    _db.UpsertFromObject("SoDuDauKy", p, "ID");
                    LoadData();
                    ClearForm();
                    _id = 0;
                    XtraMessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSoHoaDon_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "STT") // hoặc kiểm tra theo gridColumn nếu cần
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
            }
        }
    }
}
