using DevExpress.XtraEditors;
using Quản_lý_vudaco.services;
using Quản_lý_vudaco.services.Entity;
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
    public partial class frmKyKhauHao : DevExpress.XtraEditors.XtraForm
    {
        private int _type;
        public frmKyKhauHao(int type)
        {
            _type = type;
            InitializeComponent();
        }
        private void LoadThang()
        {
            cbThang.Properties.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cbThang.Properties.Items.Add(month.ToString("D2")); // 01, 02, ... 12
            }
            cbThang.SelectedItem = DateTime.Now.Month.ToString("D2"); // Chọn tháng hiện tại
        }

        private void LoadNam()
        {
            int currentYear = DateTime.Now.Year;
            cbNam.Properties.Items.Clear();

            cbNam.Properties.Items.Add((currentYear - 1).ToString("D4")); // Năm trước
            cbNam.Properties.Items.Add(currentYear.ToString("D4"));       // Năm hiện tại
            cbNam.Properties.Items.Add((currentYear + 1).ToString("D4")); // Năm tới

            cbNam.SelectedItem = currentYear.ToString("D4"); // Chọn mặc định năm hiện tại
        }

        private void frmKyKhauHao_Load(object sender, EventArgs e)
        {
            LoadThang();
            LoadNam();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            // Lấy tháng/năm người dùng chọn
            int thangChon = int.Parse(cbThang.SelectedItem.ToString());
            int namChon = int.Parse(cbNam.SelectedItem.ToString());
            //frmPhanBoKhauHao frm = new frmPhanBoKhauHao(thangChon, namChon, _type);
            //frm.ShowDialog();
           // this.Close();
            // using (var db = new clsKetNoi())
            // {
            //     using (var kh = new khauhao())
            //     {
            //         DataTable dt = kh.GetKhauHao();
            //         // Kiểm tra null hoặc không có dữ liệu
            //         if (dt == null || dt.Rows.Count == 0)
            //         {
            //             MessageBox.Show("Không có dữ liệu khấu hao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //             return; // Thoát không xử lý tiếp
            //         }
            //      
            //
            //         // Tạo DateTime từ tháng/năm đã chọn (lấy ngày 1)
            //         DateTime ngayChon = new DateTime(namChon, thangChon, 1);
            //         string ngayChonFormat = ngayChon.ToString("MMyyyy");
            //         foreach (DataRow row in dt.Rows)
            //         {
            //             string soChungTu = db.GenerateSoChungTu("PhanBoKhauHao", "SoChungTu", "PBKH", 8);
            //             DateTime ngayTao = row.Field<DateTime>("NgayTao");
            //             int thoiGianSuDung = row.Field<int>("ThoiGianSuDung"); // tính theo tháng
            //             DateTime? ngayTinhCuoi = row.Field<DateTime?>("NgayTinhCuoi");
            //             string NgayTinhCuoiFormat = "";
            //             if (ngayTinhCuoi.HasValue)
            //             {
            //                 NgayTinhCuoiFormat = ngayTinhCuoi.Value.ToString("MMyyyy");
            //             }
            //             else
            //             {
            //                 // Nếu null thì gán mặc định (ví dụ rỗng)
            //                 NgayTinhCuoiFormat = "";
            //             }
            //             // Ngày kết thúc = Ngày tạo + số tháng sử dụng - 1 ngày
            //             DateTime ngayKetThuc = ngayTao.AddMonths(thoiGianSuDung).AddDays(-1);
            //             if (ngayChon <= ngayKetThuc)
            //             {
            //                 if (ngayChonFormat == NgayTinhCuoiFormat)
            //                 {
            //                     continue; // đã lên phân bổ của tháng đó rồi không chạy nữa
            //                 }
            //                 PhanBoKhauHao pbkh = new PhanBoKhauHao
            //                 {
            //                     IDKhauHao = int.Parse(row["ID"].ToString()),
            //                     SoChungTu = soChungTu,
            //                     NguoiTao = frmMain._HoTen,
            //                     NgayTao = DateTime.Now,
            //                     GiaTriKhauHaoThang = double.Parse(row["GiaTriKhauHaoThang"].ToString()),
            //                     Loai = khauhao._khauhaotaisan
            //                 };
            //                 db.UpsertFromObject("PhanBoKhauHao", pbkh, "ID");
            //                 var p = new
            //                 {
            //                     ID = int.Parse(row["ID"].ToString()),
            //                     NgayTinhCuoi = ngayChon
            //                 };
            //                 db.UpsertFromObject("KhauHao", p, "ID");
            //             }
            //            
            //
            //         }
            //     }
            // }

        }
    }
}