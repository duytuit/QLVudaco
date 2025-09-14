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

namespace Quản_lý_vudaco.Forms
{
    public partial class frmCapNhatKhauHao : DevExpress.XtraEditors.XtraForm
    {
        private int _idKhauHao;
        public frmCapNhatKhauHao(int idKhauHao)
        {
            InitializeComponent();
            // Mask nhập ngày dd/MM/yyyy
            txtNgayTao.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            txtNgayTao.Properties.Mask.EditMask = "00/00/0000";
            txtNgayTao.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtNgayTao.Properties.Mask.SaveLiteral = true;
            txtNgayTao.Properties.Mask.IgnoreMaskBlank = false;

            txtNgayTinhCuoi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            txtNgayTinhCuoi.Properties.Mask.EditMask = "00/00/0000";
            txtNgayTinhCuoi.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtNgayTinhCuoi.Properties.Mask.SaveLiteral = true;
            txtNgayTinhCuoi.Properties.Mask.IgnoreMaskBlank = false;
            _idKhauHao = idKhauHao;
            using ( var _db = new clsKetNoi())
            {
                DataRow detail = _db.GetSingleRecord("KhauHao", idKhauHao, "ID");
                if (detail != null)
                {
                    txtMaKhauHao.Text = detail["MaKhauHao"].ToString();
                    txtTenKhauHao.Text = detail["TenKhauHao"].ToString();
                    txtNguyenGia.Text = detail["NguyenGia"] != DBNull.Value ?
                                             Convert.ToDecimal(detail["NguyenGia"]).ToString("N0") : "0";
                    txtThoiGianSuDung.Text = detail["ThoiGianSuDung"]?.ToString();
                    txtGhiChu.Text = detail["GhiChu"]?.ToString();

                    if (detail["NgayTao"] != DBNull.Value)
                        txtNgayTao.DateTime = Convert.ToDateTime(detail["NgayTao"]);

                    if (detail["NgayTinhCuoi"] != DBNull.Value)
                        txtNgayTinhCuoi.DateTime = Convert.ToDateTime(detail["NgayTinhCuoi"]);
                }
            }
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

       private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate cơ bản
            if (string.IsNullOrWhiteSpace(txtMaKhauHao.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Mã khấu hao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhauHao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKhauHao.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Tên khấu hao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhauHao.Focus();
                return;
            }

            try
            {
                using (var _db = new clsKetNoi())
                {
                    var p = new
                    {
                        ID = _idKhauHao,
                        MaKhauHao = txtMaKhauHao.Text.Trim(),
                        TenKhauHao = txtTenKhauHao.Text.Trim(),
                        NguyenGia = string.IsNullOrWhiteSpace(txtNguyenGia.Text) ? 0 : Convert.ToDouble(txtNguyenGia.Text.Replace(",", "")),
                        ThoiGianSuDung = string.IsNullOrWhiteSpace(txtThoiGianSuDung.Text) ? 0 : Convert.ToInt32(txtThoiGianSuDung.Text),
                        GiaTriKhauHaoThang = Convert.ToDouble(txtNguyenGia.Text.Replace(",", ""))/ Convert.ToInt32(txtThoiGianSuDung.Text),
                        NgayTao = txtNgayTao.EditValue == null ? (DateTime?)null : txtNgayTao.DateTime,
                        NgayTinhCuoi = txtNgayTinhCuoi.EditValue == null ? (DateTime?)null : txtNgayTinhCuoi.DateTime,
                        GhiChu = txtGhiChu.Text.Trim()
                    };

                    _db.UpsertFromObject("KhauHao", p, "ID");

                    XtraMessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // đóng form nếu cần
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}