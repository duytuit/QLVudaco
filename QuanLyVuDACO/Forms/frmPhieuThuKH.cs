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
    public partial class frmPhieuThuKH : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuThuKH(DataTable dt)
        {
            InitializeComponent();
            gridControl1.DataSource = dt;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmDoiTuong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            radioGroup1_SelectedIndexChanged(sender, e);
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
            }
            else
            {
                panel1.Enabled = false;
                panel2.Enabled = true;

            }
            cboNganHang_SelectedIndexChanged(sender, e);
        }

        private void cboNganHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboNganHang.Text=="")
            {
                lblChuTK.Text = "";
                lblSoTK.Text = "";
                lblChiNhanh.Text = "";
            }    
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = cboNganHang.SelectedValue.ToString();
              var table=  client.DanhMucNganHang_Load_ThéoTK(p);
                foreach (var item in table)
                {
                    lblChuTK.Text = item.ChuTaiKhoan;
                    lblSoTK.Text = item.SoTK;
                    lblChiNhanh.Text = item.ChiNhanh;
                }
               
            }    
        }

        private void frmPhieuThuKH_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (var _appDB = new clsKetNoi())
            {
                try
                {
                    _appDB.BeginTransaction();
                    string[] arr = dtpNgay.Text.Trim().Split('/');
                    var p = new
                    {
                        IDPhieuThu = 0,
                        DienGiai = txtDienGiai.Text,
                        LyDoThu = "Thu công nợ khách hàng",
                        MaThu = "004",
                        MaQuy = cboLoaiQuy.EditValue == null ? string.Empty : cboLoaiQuy.EditValue.ToString().Trim(),
                        NgayHachToan = Convert.ToDateTime(dtpNgay.Text),
                        NguoiNhan = frmMain._HoTen,
                        NguoiTao = frmMain._TK,
                        SoChungTu = client.TaoSoChungTu_Thu(arr),
                        SoHoaDon = "",
                        ThoiGianTao = DateTime.Now,
                        HinhThucTT = radioGroup1.SelectedIndex == 1 ? "CK" : "TM",
                        SoTK = lblSoTK.Text,
                        TenNganHang = cboNganHang.Text,
                        ChiNhanh = lblChiNhanh.Text,
                        ChuTaiKhoan = lblChuTK.Text
                    };
                    int _id_pthu = _appDB.UpsertFromObject("PhieuThu", p, "IDPhieuThu", true);
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        int LaPhiChiHo = int.Parse(gridView1.GetRowCellValue(i, "LaPhiChiHo").ToString());
                        var phieuchitiet = new
                        {
                            IDCT = 0,
                            SoChungTu = p.SoChungTu,
                            DiaChi = gridView1.GetRowCellValue(i, "DiaChi").ToString(),
                            DoiTuong = "KH",
                            GhiChu = "",
                            MaDoiTuong = gridView1.GetRowCellValue(i, "MaKhachHang").ToString(),
                            SoFile = gridView1.GetRowCellValue(i, "SoFile").ToString(),
                            SoTien = LaPhiChiHo == 0 ? double.Parse(gridView1.GetRowCellValue(i, "ThuDichVu").ToString()) : double.Parse(gridView1.GetRowCellValue(i, "ThuChiHo").ToString()),
                            VAT = 0,
                            ThanhTien = LaPhiChiHo == 0 ? double.Parse(gridView1.GetRowCellValue(i, "ThuDichVu").ToString()) : double.Parse(gridView1.GetRowCellValue(i, "ThuChiHo").ToString()),
                            TenDoiTuong = gridView1.GetRowCellValue(i, "TenKhachHang").ToString(),
                            IDCP = 0,
                            MaNhanVien = "",
                            LaPhieuChiHo = LaPhiChiHo,
                            MaDieuXe = gridView1.GetRowCellValue(i, "MaDieuXe").ToString(),
                            IDKey = int.Parse(gridView1.GetRowCellValue(i, "ID").ToString()),
                            KeyName = gridView1.GetRowCellValue(i, "Key").ToString()
                        };
                        _appDB.UpsertFromObject("PhieuThu_CT", phieuchitiet, "IDCT", true);
                    }
                    _appDB.CommitTransaction();
                    MessageBox.Show("Tạo phiếu thu xong!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    _appDB.RollbackTransaction();
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
    }
}