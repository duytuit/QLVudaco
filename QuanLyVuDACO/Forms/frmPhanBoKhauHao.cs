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
    public partial class frmPhanBoKhauHao : DevExpress.XtraEditors.XtraForm
    {
        private int  _type;
        public frmPhanBoKhauHao()
        {
            InitializeComponent();
        }
        public frmPhanBoKhauHao(int type)
        {
            _type = type;
            InitializeComponent();
        }
        private void frmKhaiBaoTSCD_Load(object sender, EventArgs e)
        {
            LoadThang();
            LoadNam();
            LoadDuLieuKhauHao();
            dtpNgayKhaiBao.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int thangChon = int.Parse(cbThang.SelectedItem.ToString());
            int namChon = int.Parse(cbNam.SelectedItem.ToString());
            DateTime ngayChon = new DateTime(namChon, thangChon, 1);
            string ngayChonFormat = ngayChon.ToString("MMyyyy");
            using (var db = new clsKetNoi())
            {
                string soChungTu = db.GenerateSoChungTu("PhanBoKhauHao", "SoChungTu", "KH_"+LoaiKhauHao(_type), 8);
                PhanBoKhauHao pbkh = new PhanBoKhauHao
                {
                    SoChungTu = soChungTu,
                    NguoiTao = frmMain._HoTen,
                    NgayTao = DateTime.ParseExact( dtpNgayKhaiBao.Text,"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Loai = _type,
                    DienGiai = txtDiengiaỉ.Text
                };
                int _idpb = db.UpsertFromObject("PhanBoKhauHao", pbkh, "ID",true);
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    DataRow row = gridView2.GetDataRow(i);
                    if (row == null) continue;
                    double _nguyengia = row.Field<double>("NguyenGia");
                    int _idkhauhao = Convert.ToInt32(row["ID"]);
                    double _TongGiaTriKhauHao = db.GetSumValue("PhanBoKhauHao_CT", "GiaTriKhauHaoThang", "IDKhauHao", _idkhauhao);

                   // DateTime ngayTao = row.Field<DateTime>("NgayTao");
                   // int thoiGianSuDung = row.Field<int>("ThoiGianSuDung"); // tính theo tháng
                    DateTime? ngayTinhCuoi = row.Field<DateTime?>("NgayTinhCuoi");

                    string NgayTinhCuoiFormat = ngayTinhCuoi.HasValue ? ngayTinhCuoi.Value.ToString("MMyyyy"): "";

                    // Ngày kết thúc = Ngày tạo + số tháng sử dụng - 1 ngày
                   // DateTime ngayKetThuc = ngayTao.AddMonths(thoiGianSuDung).AddDays(-1);

                 
                        if (ngayChonFormat == NgayTinhCuoiFormat)
                        {
                            continue; // đã lên phân bổ của tháng đó rồi không chạy nữa
                        }
                        if (_nguyengia == _TongGiaTriKhauHao)
                        {
                            continue; // đã khấu hao đủ
                        }
                        PhanBoKhauHaoCT pbkh_ct = new PhanBoKhauHaoCT
                        {
                            IDKhauHao = _idkhauhao,
                            IDPhanBoKhauHao = _idpb,
                            GiaTriKhauHaoThang = Convert.ToDouble(row["GiaTriKhauHaoThang"])
                        };

                        db.UpsertFromObject("PhanBoKhauHao_CT", pbkh_ct, "ID");

                        var p = new
                        {
                            ID = _idkhauhao,
                            NgayTinhCuoi = ngayChon
                        };

                        db.UpsertFromObject("KhauHao", p, "ID");
                }
            }
            MessageBox.Show("Đã lưu dữ liệu vào CSDL");
            this.Close();
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
        private string LoaiKhauHao(int type)
        {
            switch (type)
            {
                case 1:
                    return "TSCD";
                case 2:
                    return "CPTT";
                case 3:
                    return "CPC";
                default:
                    return "";
            }
        }


        private void cbThang_EditValueChanged(object sender, EventArgs e)
        {
            LoadDuLieuKhauHao();
        }

        private void cbNam_EditValueChanged(object sender, EventArgs e)
        {
            LoadDuLieuKhauHao();
        }
        private void LoadDuLieuKhauHao()
        {
            // Ghép mô tả
            txtDiengiaỉ.Text = $"Khấu hao {LoaiKhauHao(_type)} Tháng {cbThang.Text} Năm {cbNam.Text}";

            // Lấy giá trị tháng/năm từ combobox
            if (cbThang.SelectedItem != null && cbNam.SelectedItem != null)
            {
                if (int.TryParse(cbThang.SelectedItem.ToString(), out int thangChon) &&
                    int.TryParse(cbNam.SelectedItem.ToString(), out int namChon))
                {
                    // Lấy ngày cuối tháng
                    int ngayCuoi = DateTime.DaysInMonth(namChon, thangChon);
                    DateTime ngayCuoiThang = new DateTime(namChon, thangChon, ngayCuoi);
                    gridControl2.DataSource = LoadKhauHao(ngayCuoiThang,_type);
                }
            }
        }
        private DataTable LoadKhauHao(DateTime ngayChon,int Loai =0)
        {
            using (var kh = new khauhao())
            {
                return kh.GetKhauHaoByNgayTao(ngayChon, Loai);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}