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
    public partial class frmPhieuChiNoiBo : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuChiNoiBo()
        {
            InitializeComponent();
        }
        public frmPhieuChiNoiBo(int IDPhieuChi)
        {
            InitializeComponent();
            _IDPhieuChi = IDPhieuChi;
        }
        int _IDPhieuChi = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            cboLoaiQuy2.Properties.DataSource = client.DanhMucQuy_Load();
            btnThemMoi_Click(sender, e);
            radioGroup1_SelectedIndexChanged(sender, e);
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            //
            cboNganHang2.DataSource = client.DanhMucNganHang_Load();
            cboNganHang2.DisplayMember = "TenNganHang";
            cboNganHang2.ValueMember = "SoTK";
            if (_IDPhieuChi!=0)
            {
                var table = client.DanhSachPhieuChi_TheoIdPhieuChi(_IDPhieuChi);
                foreach (var item in table)
                {
                    dtpNgayHachToan.Text = item.NgayHachToan.Value.ToString("dd/MM/yyyy");
                    txtSoChungTu.Text = item.SoChungTu;
                    cboLoaiQuy.EditValue = item.MaQuy;
                    if (item.HinhThucTT == "TM")
                    {
                        radioGroup1.SelectedIndex = 0;
                    }

                    else
                    {
                        radioGroup1.SelectedIndex = 1;
                        radioGroup1_SelectedIndexChanged(sender, e);
                        cboNganHang.SelectedValue = item.SoTK;
                        cboNganHang_SelectedIndexChanged(sender, e);

                    }
                    var table1 = client.DanhSachPhieuChi_NoiBo_CT_TheoIDPhieuChi(_IDPhieuChi);
                    foreach (var item1 in table1)
                    {
                      
                        txtSoTien.Text = item1.SoTien.Value.ToString("#,##");
                        txtGhiChu.Text = item1.GhiChu;
                    }
                    AnButton(false, true, true);
                }
            }    
        }
        private void AnButton(bool luu, bool sua, bool xoa)
        {
            btnLuu.Enabled = luu;
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
        }
      

      
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtSoChungTu.Text = "";
            cboLoaiQuy.EditValue = null;
            dtpNgayHachToan_TextChanged(sender, e);
            AnButton(true, false,false);
        }
        private void Chi()
        {
            ServiceReference1.PhieuChi_NoiBo p = new ServiceReference1.PhieuChi_NoiBo();
            p.DienGiai = txtGhiChu.Text;
            p.LyDoChi = "Chuyển tiền nội bộ(đi)";
            p.MaChi = "";
            p.MaQuy = (cboLoaiQuy.EditValue == null) ? "" : cboLoaiQuy.EditValue.ToString();
            string[] arr = dtpNgayHachToan.Text.Trim().Split('/');
            DateTime Ngay1 = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
            p.NgayHachToan = Ngay1;
            p.NguoiNhan = "";
            p.NguoiTao = frmMain._TK;
            p.SoChungTu = txtSoChungTu.Text;
            p.SoHoaDon = "";
            p.ThoiGianTao = DateTime.Now;
            p.HinhThucTT = (radioGroup1.SelectedIndex == 0) ? "TM" : "CK";
            if (lblSoTK.Text == "")
                p.TenNganHang = "";
            else
                p.TenNganHang = cboNganHang.Text;
            p.SoTK = lblSoTK.Text;
            p.ChiNhanh = lblChiNhanh.Text;
            p.ChuTaiKhoan = lblChuTK.Text;
            client.DanhSachPhieuChiNoiBo_Them(p);
            //phieuchiCT
            ServiceReference1.PhieuChi_NoiBo_CT p1 = new ServiceReference1.PhieuChi_NoiBo_CT();
            p1.SoChungTu = p.SoChungTu;
            p1.DiaChi = "";
            p1.DoiTuong = "NV";
            p1.GhiChu = txtGhiChu.Text;
            p1.MaDoiTuong = "";
            p1.SoFile = "";
            p1.SoTien = double.Parse(txtSoTien.Text);
            p1.VAT = 0;
            p1.ThanhTien = p1.SoTien;
            p1.TenDoiTuong = "";
            p1.IDCP = 0;
            p1.MaNhanVien = "";
            client.DanhSachPhieuChi_NoiBo_CT_Them(p1);
        }
        private void Thu()
        {
            ServiceReference1.PhieuThu_NoiBo p = new ServiceReference1.PhieuThu_NoiBo();
            p.DienGiai = txtGhiChu.Text;
            p.LyDoThu = "Chuyển tiền nội bộ(đến)";
            p.MaThu = "";
            p.MaQuy = (cboLoaiQuy2.EditValue == null) ? "" : cboLoaiQuy2.EditValue.ToString();
            string[] arr = dtpNgayHachToan.Text.Trim().Split('/');
            DateTime Ngay1 = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
            p.NgayHachToan = Ngay1;
            p.NguoiNhan = "";
            p.NguoiTao = frmMain._TK;
            p.SoChungTu = txtSoChungTu.Text;
            p.SoHoaDon = "";
            p.ThoiGianTao = DateTime.Now;
            p.HinhThucTT = (radioGroup2.SelectedIndex == 0) ? "TM" : "CK";
            if (lblSoTK2.Text == "")
                p.TenNganHang = "";
            else
                p.TenNganHang = cboNganHang2.Text;
            p.SoTK = lblSoTK2.Text;
            p.ChiNhanh = lblChiNhanh2.Text;
            p.ChuTaiKhoan = lblChuTK2.Text;
            client.DanhSachPhieuThu_NoiBo_Them(p);
            //phieuthuCT
            ServiceReference1.PhieuThu_NoiBo_CT p1 = new ServiceReference1.PhieuThu_NoiBo_CT();
            p1.SoChungTu = p.SoChungTu;
            p1.DiaChi = "";
            p1.DoiTuong = "NV";
            p1.GhiChu = txtGhiChu.Text;
            p1.MaDoiTuong = "";
            p1.SoFile = "";
            p1.SoTien = double.Parse(txtSoTien.Text);
            p1.VAT = 0;
            p1.ThanhTien = p1.SoTien;
            p1.TenDoiTuong = "";
            p1.IDCP = 0;
            p1.MaNhanVien = "";
            client.DanhSachPhieuThu_NoiBo_CT_Them(p1);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoChungTu.Text=="")
                    MessageBox.Show("Vui lòng chọn ngày hạch toán!");
                else if (txtSoTien.Text == "")
                    MessageBox.Show("Vui lòng nhập số tiền!");
                else
                {
                    Chi();
                    Thu();
                    MessageBox.Show("Tạo phiếu chi xong!");
                    this.Close();
                }

            }
            catch (Exception)
            {

            }
        }
     
        private void dtpNgayHachToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arr = dtpNgayHachToan.Text.Trim().Split('/');
                if (arr.Length == 3)
                {
                    txtSoChungTu.Text = client.TaoSoChungTu(arr);

                }
                else
                    MessageBox.Show("Vui lòng chọn ngày hạch toán đúng định dạng!");
            }
            catch (Exception)
            {

            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
           
                    
                    client.DanhSachPhieuChi_NoiBo_Xoa2(txtSoChungTu.Text);
                    this.Close();
                
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
                    if (txtSoChungTu.Text == "")
                        MessageBox.Show("Vui lòng chọn ngày hạch toán!");
                    else if (txtSoTien.Text == "")
                MessageBox.Show("Vui lòng nhập số tiền!");
            else
                    {
                        ServiceReference1.PhieuChi_NoiBo p = new ServiceReference1.PhieuChi_NoiBo();
                        p.IDPhieuChi = _IDPhieuChi;
                        client.DanhSachPhieuChi_NoiBo_Xoa(p);
                        client.PhieuChi_NoiBo_CT_Xoa(txtSoChungTu.Text);
                        btnLuu_Click(sender, e);
                    }
        }


        private void dtpNgayHachToan_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
              
                cboNganHang.SelectedText = "";
                panel2.Enabled = false;
                cboLoaiQuy.Enabled = true;
            }
            else
            {
                panel2.Enabled = true;
                cboLoaiQuy.EditValue = null;
                cboLoaiQuy.Enabled = false;
            }
            cboNganHang_SelectedIndexChanged(sender, e);
        }
        private void cboNganHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNganHang.SelectedValue == null)
            {
                cboNganHang.Text = "";
                lblChuTK.Text = "";
                lblSoTK.Text = "";
                lblChiNhanh.Text = "";
            }
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = cboNganHang.SelectedValue.ToString();
                var table = client.DanhMucNganHang_Load_ThéoTK(p);
                foreach (var item in table)
                {
                    lblChuTK.Text = item.ChuTaiKhoan;
                    lblSoTK.Text = item.SoTK;
                    lblChiNhanh.Text = item.ChiNhanh;
                }
            }
        }

        private void cboNganHang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboNganHang.SelectedValue == null)
            {
                cboNganHang.Text = "";
                lblChuTK.Text = "";
                lblSoTK.Text = "";
                lblChiNhanh.Text = "";
            }
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = cboNganHang.SelectedValue.ToString();
                var table = client.DanhMucNganHang_Load_ThéoTK(p);
                foreach (var item in table)
                {
                    lblChuTK.Text = item.ChuTaiKhoan;
                    lblSoTK.Text = item.SoTK;
                    lblChiNhanh.Text = item.ChiNhanh;
                }
            }
        }

        private void cboNganHang2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNganHang2.SelectedValue == null)
            {
                cboNganHang2.Text = "";
                lblChuTK2.Text = "";
                lblSoTK2.Text = "";
                lblChiNhanh2.Text = "";
            }
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = cboNganHang2.SelectedValue.ToString();
                var table = client.DanhMucNganHang_Load_ThéoTK(p);
                foreach (var item in table)
                {
                    lblChuTK2.Text = item.ChuTaiKhoan;
                    lblSoTK2.Text = item.SoTK;
                    lblChiNhanh2.Text = item.ChiNhanh;
                }
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {

                cboNganHang2.SelectedText = "";
                panel1.Enabled = false;
                cboLoaiQuy2.Enabled = true;
            }
            else
            {
                panel1.Enabled = true;
                cboLoaiQuy2.EditValue = null;
                cboLoaiQuy2.Enabled = false;
            }
            cboNganHang2_SelectedIndexChanged(sender, e);
        }
    }
}