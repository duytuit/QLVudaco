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
    public partial class frmPhieuChiTamUngLaiXe : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuChiTamUngLaiXe()
        {
            InitializeComponent();
        }
        public frmPhieuChiTamUngLaiXe(int IDPhieuChi)
        {
            InitializeComponent();
            _IDPhieuChi = IDPhieuChi;
        }
        int _IDPhieuChi = 0;
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            btnThemMoi_Click(sender, e);
            cboLoaiDoiTuong.EditValue = "NV";
            cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
          

            //cboDanhSachChi.Properties.DataSource = client.DanhsachChi_001();
            //cboDanhSachChi.EditValue = "002";
            //cboDanhSachChi_EditValueChanged(sender, e);
            radioGroup1_SelectedIndexChanged(sender, e);
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            if (_IDPhieuChi!=0)
            {
                var table = client.DanhSachPhieuChiTamUngLaiXe_TheoIdPhieuChi(_IDPhieuChi);
                foreach (var item in table)
                {
                    dtpNgayHachToan.Text = item.NgayHachToan.Value.ToString("dd/MM/yyyy");
                    txtSoChungTu.Text = item.SoChungTu;
                    cboLoaiQuy.EditValue = item.MaQuy;
                    txtTenNguoiNhan.Text = item.NguoiNhan;
                    txtSoHoaDon.Text = item.SoHoaDon;
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
                    var table1 = client.DanhSachPhieuChiTamUngLaiXe_CT_TheoIDPhieuChi(_IDPhieuChi);
                    foreach (var item1 in table1)
                    {
                        cboLoaiDoiTuong.EditValue = item1.DoiTuong;
                        cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
                        cboDoiTuong.EditValue = item1.MaDoiTuong;
                        txtDiaChi.Text = item1.DiaChi;
                        txtSoTien.Text = item1.SoTien.Value.ToString("#,##");
                        txtVAT.Text = item1.VAT.Value.ToString();
                        txtVAT_SelectedIndexChanged(sender, e);
                        txtThanhTien.Text = item1.ThanhTien.Value.ToString("#,##");
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
        private void cboLoaiDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("doituong");
            dt.Columns.Add("MaDoiTuong");
            dt.Columns.Add("TenDoiTuong");
            if (cboLoaiDoiTuong.Text.Trim()=="KH")
            {
                var t = client.dsKH();
                foreach (var item in t)
                {
                    DataRow row = dt.NewRow();
                    row["MaDoiTuong"] = item.MaKhachHang;
                    row["TenDoiTuong"] = item.TenKhachHang;
                    dt.Rows.Add(row);
                }
            }
           else if (cboLoaiDoiTuong.Text.Trim() == "NCC")
            {
                var t = client.ds_NCC();
                foreach (var item in t)
                {
                    DataRow row = dt.NewRow();
                    row["MaDoiTuong"] = item.MaNhaCungCap;
                    row["TenDoiTuong"] = item.TenNhaCungCap;
                    dt.Rows.Add(row);
                }
            }
            else if (cboLoaiDoiTuong.Text.Trim() == "NV")
            {
                var t = client.DsTaiKhoan();
                foreach (var item in t)
                {
                    DataRow row = dt.NewRow();
                    row["MaDoiTuong"] = item.TaiKhoan;
                    row["TenDoiTuong"] = item.HoVaTen;
                    dt.Rows.Add(row);
                }
            }
            cboDoiTuong.Properties.DataSource = dt;

        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtSoChungTu.Text = "";
            cboLoaiQuy.EditValue = null;
            cboLoaiDoiTuong.EditValue = null;
            cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
            txtTenNguoiNhan.Text = "";
            txtDiaChi.Text = "";
            dtpNgayHachToan_TextChanged(sender, e);
            AnButton(true, false,false);
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
                    ServiceReference1.PhieuChi_LaiXe p = new ServiceReference1.PhieuChi_LaiXe();
                    p.DienGiai = txtGhiChu.Text;
                    p.LyDoChi = txtTenChi.Text;
                    p.MaChi = "002";
                    p.MaQuy = (cboLoaiQuy.EditValue == null) ? "" : cboLoaiQuy.EditValue.ToString();
                    string[] arr = dtpNgayHachToan.Text.Trim().Split('/');
                    DateTime Ngay1 = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                    p.NgayHachToan = Ngay1;
                    p.NguoiNhan = txtTenNguoiNhan.Text;
                    p.NguoiTao = frmMain._TK;
                    p.SoChungTu = txtSoChungTu.Text;
                    p.SoHoaDon = txtSoHoaDon.Text;
                    p.ThoiGianTao = DateTime.Now;
                    p.HinhThucTT = (radioGroup1.SelectedIndex == 0) ? "TM" : "CK";
                    p.TenNganHang = cboNganHang.Text;
                    p.SoTK = lblSoTK.Text;
                    p.ChiNhanh = lblChiNhanh.Text;
                    p.ChuTaiKhoan = lblChuTK.Text;
                    client.DanhSachPhieuChiTamUngLaiXe_Them(p);
                    //phieuchiCT
                    ServiceReference1.PhieuChi_LaiXe_CT p1 = new ServiceReference1.PhieuChi_LaiXe_CT();
                    p1.SoChungTu = p.SoChungTu;
                    p1.DiaChi = txtDiaChi.Text;
                    p1.DoiTuong = (cboLoaiDoiTuong.EditValue == null) ? "" : cboLoaiDoiTuong.EditValue.ToString();
                    p1.GhiChu = txtGhiChu.Text;
                    p1.MaDoiTuong = (cboDoiTuong.EditValue == null) ? "" : cboDoiTuong.EditValue.ToString();
                    p1.SoFile ="";
                    p1.SoTien = double.Parse(txtSoTien.Text);
                    p1.VAT = int.Parse(txtVAT.Text);
                    p1.ThanhTien = double.Parse(txtThanhTien.Text);
                    p1.TenDoiTuong = cboDoiTuong.Text;
                    p1.IDCP = 0;
                    p1.MaNhanVien ="";
                      client.DanhSachPhieuChiTamUngLaiXe_CT_Them(p1);
                   
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
                    txtSoChungTu.Text = client.TaoSoChungTu_LaiXe(arr);

                }
                else
                    MessageBox.Show("Vui lòng chọn ngày hạch toán đúng định dạng!");
            }
            catch (Exception)
            {

            }
        }

        private void txtVAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtVAT.Text == ""||txtVAT.Text=="0")
                txtThanhTien.Text = txtSoTien.Text;
            else
            {
                try
                {
                    double soTien = double.Parse(txtSoTien.Text);
                    txtThanhTien.Text = ((soTien + soTien * double.Parse(txtVAT.Text)) / 100).ToString();
                }
                catch (Exception)
                {

                }
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
                
                    ServiceReference1.PhieuChi_LaiXe p = new ServiceReference1.PhieuChi_LaiXe();
                    p.IDPhieuChi = _IDPhieuChi;
                    client.DanhSachPhieuChiTamUngLaiXe_Xoa(p);
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
                        ServiceReference1.PhieuChi_LaiXe p = new ServiceReference1.PhieuChi_LaiXe();
                        p.IDPhieuChi = _IDPhieuChi;
                        client.DanhSachPhieuChiTamUngLaiXe_Xoa(p);
                        client.PhieuChiTamUngLaiXe_CT_Xoa(txtSoChungTu.Text);
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
    }
}