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
using System.Globalization;
using System.Text;

namespace Quản_lý_vudaco.module
{
    public partial class ucNhomQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNhomQuyen()
        {
            InitializeComponent();
        }

        private void btnQuyen_Click(object sender, EventArgs e)
        {
            using (var _db = new clsKetNoi())
            {

                var danhsach_quyen = new[]
                {
                    new { TenQuyen = "Hệ thống" , Quyen="hethong" },
                    new { TenQuyen = "Danh sách tài khoản" ,Quyen="danhsachtaikhoan"}
                }.ToList();

                foreach (var item in danhsach_quyen)
                {
                    _db.UpsertFromObjectByColumn("Permissions", new { TenQuyen = item.TenQuyen, Quyen = item.Quyen, Menu = false, Xem = false, Luu = false, Xoa = false }, new[] { "Quyen" });
                }
            }
        }
        public static string ChuyenDoiChuoiKhongDau(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Chuẩn hóa và bỏ dấu tiếng Việt
            string normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Xóa khoảng trắng + chuyển lowercase
            return sb.ToString().Normalize(NormalizationForm.FormC)
                     .Replace(" ", "")
                     .ToLower();
        }
    }
}
