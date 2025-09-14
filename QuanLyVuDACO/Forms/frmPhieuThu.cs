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
    public partial class frmPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuThu()
        {
            InitializeComponent();
        }
        public frmPhieuThu(int IDPhieuThu)
        {
            InitializeComponent();
            _IDPhieuThu = IDPhieuThu;
        }
        public frmPhieuThu(string MaKH)
        {
            InitializeComponent();
            _MaKH = MaKH;
        }
        int _IDPhieuThu = 0;
        string _MaKH = "";
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            if(_MaKH!="")
                cboLoaiDoiTuong.EditValue = "KH";
            cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
            cboSoFile.Properties.DataSource = client.DsThongTinFile_Full();
            btnThemMoi_Click(sender, e);
            cboSoFile_EditValueChanged(sender, e);
            cboDanhSachThu.Properties.DataSource = client.DanhsachThu_001();
            cboDanhSachChi_EditValueChanged(sender, e);
            radioGroup1_SelectedIndexChanged(sender, e);
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            txtTenNguoiNhan.Text = frmMain._HoTen;
            if (_IDPhieuThu != 0)
            {
                var table = client.DanhSachPhieuThu_TheoIdPhieuThu(_IDPhieuThu);
                foreach (var item in table)
                {
                    _MaThu = item.MaThu.Trim();
                    dtpNgayHachToan.Text = item.NgayHachToan.Value.ToString("dd/MM/yyyy");
                    txtSoChungTu.Text = item.SoChungTu;
                    cboLoaiQuy.EditValue = item.MaQuy;
                    txtTenNguoiNhan.Text = item.NguoiNhan;
                    cboDanhSachThu.EditValue = item.MaThu;
                    cboDanhSachChi_EditValueChanged(sender, e);
                    txtTenThu.Text = item.LyDoThu;
                    txtSoHoaDon.Text = item.SoHoaDon;
                    txtGhiChu.Text = item.DienGiai;
                    if (item.HinhThucTT.Trim() == "TM")
                    {
                        radioGroup1.SelectedIndex = 0;
                        cboNganHang.Text = "";
                    }

                    else
                    {
                        radioGroup1.SelectedIndex = 1;
                        radioGroup1_SelectedIndexChanged(sender, e);
                        cboNganHang.SelectedValue = item.SoTK;
                        cboNganHang_SelectedIndexChanged_1(sender, e);
                       
                    }
                    var table1 = client.DanhSachPhieuThu_CT_TheoIDPhieuThu(_IDPhieuThu);
                    foreach (var item1 in table1)
                    {
                        cboLoaiDoiTuong.EditValue = item1.DoiTuong;
                        cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
                        cboDoiTuong.EditValue = item1.MaDoiTuong;
                        cboSoFile.EditValue = item1.SoFile;
                        cboSoFile_EditValueChanged(sender, e);
                        cboNguoiGiaoNhan.EditValue = item1.MaNhanVien;
                        txtDiaChi.Text = item1.DiaChi;
                        txtSoTien.Text = item1.SoTien.Value.ToString("#,##");
                        txtVAT.Text = item1.VAT.Value.ToString();
                        txtVAT_SelectedIndexChanged(sender, e);
                        txtThanhTien.Text = item1.ThanhTien.Value.ToString("#,##");
                       // txtGhiChu.Text = item1.GhiChu;
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
                    row["TenDoiTuong"] = item.TenVietTat;
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
                    row["TenDoiTuong"] = item.TenVietTat;
                    dt.Rows.Add(row);
                }
            }
            else if (cboLoaiDoiTuong.Text.Trim() == "NV")
            {
                var t = client.dsNhanVien();
                foreach (var item in t)
                {
                    DataRow row = dt.NewRow();
                    row["MaDoiTuong"] = item.MaNhanVien;
                    row["TenDoiTuong"] = item.TenNhanVien;
                    dt.Rows.Add(row);
                }
            }
            cboDoiTuong.Properties.DataSource = dt;
            if (_MaKH != "")
                cboDoiTuong.EditValue = _MaKH;

        }

        private void cboDanhSachChi_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDanhSachThu.EditValue != null)
                txtTenThu.Text = cboDanhSachThu.Text;
            else
                txtTenThu.Text = "";
        }
      
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtSoChungTu.Text = "";
            cboLoaiQuy.EditValue = null;
            cboLoaiDoiTuong.EditValue = null;
            cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
            cboSoFile.EditValue = null;
            txtTenNguoiNhan.Text = "";
            txtDiaChi.Text = "";
            cboDanhSachThu.EditValue = null;
            cboDanhSachChi_EditValueChanged(sender, e);
            dtpNgayHachToan_TextChanged(sender, e);
            AnButton(true, false,false);
        }
        string _MaThu = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoChungTu.Text=="")
                    MessageBox.Show("Vui lòng chọn ngày hạch toán!");
                else if (txtSoTien.Text == "")
                    MessageBox.Show("Vui lòng nhập số tiền!");
                else if (cboDanhSachThu.EditValue == null)
                    MessageBox.Show("Vui lòng chọn danh mục chi!");
                else if (cboSoFile.EditValue == null)
                    MessageBox.Show("Vui lòng chọn số file!");
                else if (cboNguoiGiaoNhan.EditValue == null&&_MaThu=="001")
                    MessageBox.Show("Vui lòng chọn người giao nhận!");
                else
                {
                    ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
                    p.DienGiai = txtGhiChu.Text;
                    p.LyDoThu = txtTenThu.Text;
                    p.MaThu = cboDanhSachThu.EditValue.ToString();
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
                    client.DanhSachPhieuThu_Them(p);
                    //phieuchiCT
                    ServiceReference1.PhieuThu_CT p1 = new ServiceReference1.PhieuThu_CT();
                    p1.SoChungTu = p.SoChungTu;
                    p1.DiaChi = txtDiaChi.Text;
                    p1.DoiTuong = (cboLoaiDoiTuong.EditValue == null) ? "" : cboLoaiDoiTuong.EditValue.ToString();
                    p1.GhiChu = txtGhiChu.Text;
                    p1.MaDoiTuong = (cboDoiTuong.EditValue == null) ? "" : cboDoiTuong.EditValue.ToString();
                    p1.SoFile = cboSoFile.EditValue.ToString();
                    p1.SoTien = double.Parse(txtSoTien.Text);
                    p1.VAT = int.Parse(txtVAT.Text);
                    p1.ThanhTien = double.Parse(txtThanhTien.Text);
                    p1.TenDoiTuong = cboDoiTuong.Text;
                    p1.IDCP = 0;
                    p1.LaPhieuChiHo = true;
                    p1.MaDieuXe = "";
                    p1.MaNhanVien =(cboNguoiGiaoNhan.EditValue==null)?"": cboNguoiGiaoNhan.EditValue.ToString();
                    client.DanhSachPhieuThu_CT_Them(p1);
                    MessageBox.Show("Tạo phiếu thu xong!");
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
                    txtSoChungTu.Text = client.TaoSoChungTu_Thu(arr);

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
            if (cboDanhSachThu.EditValue != null && cboSoFile.EditValue != null&&cboNguoiGiaoNhan.EditValue!=null)
            {
                bool isCheck = client.KiemTraPhieuChi_XacNhanHoanUng_Admin_TheoSoFile(cboSoFile.EditValue.ToString());
                if (isCheck)
                    MessageBox.Show("Lô hàng này đã xác nhận hoàn ứng- không được sửa xoá!");
                else
                {
                    ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
                    p.IDPhieuThu = _IDPhieuThu;
                    client.DanhSachPhieuThu_Xoa(p);
                    client.PhieuThu_CT_Xoa(txtSoChungTu.Text.Trim());
                   //  client.CapNhatDuyetUng_TheoSoFile(cboSoFile.EditValue.ToString(),cboNguoiGiaoNhan.EditValue.ToString());
                   
                    this.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboDanhSachThu.EditValue != null && cboSoFile.EditValue != null)
            {
                if (_MaThu == "001" && cboNguoiGiaoNhan.EditValue != null)
                    MessageBox.Show("Vui lòng chọn người giao nhận");
                else
                {
                    if (cboSoFile.EditValue != null && cboNguoiGiaoNhan.EditValue != null)
                    {
                        bool isCheck = client.KiemTraPhieuChi_XacNhanHoanUng_Admin_TheoSoFile(cboSoFile.EditValue.ToString());
                        if (isCheck)
                            MessageBox.Show("Lô hàng này đã xác nhận hoàn ứng- không được sửa xoá!");
                        else
                        {
                            ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
                            p.IDPhieuThu = _IDPhieuThu;
                            client.DanhSachPhieuThu_Xoa(p);
                            client.PhieuThu_CT_Xoa(txtSoChungTu.Text.Trim());
                           // client.CapNhatDuyetUng_TheoSoFile(cboSoFile.EditValue.ToString(),(cboNguoiGiaoNhan.EditValue==null)?"": cboNguoiGiaoNhan.EditValue.ToString());
                            btnLuu_Click(sender, e);
                        }
                    }
                    else
                    {
                       
                            ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
                            p.IDPhieuThu = _IDPhieuThu;
                            client.DanhSachPhieuThu_Xoa(p);
                            client.PhieuThu_CT_Xoa(txtSoChungTu.Text.Trim());
                            btnLuu_Click(sender, e);
                       
                    }
                    this.Close();
                }
            }
            else
                MessageBox.Show("Vui lòng chọn số file");
        }

        private void cboSoFile_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSoFile.EditValue != null)
            {
                cboNguoiGiaoNhan.Properties.DataSource = client.DsThongTinFile_NguoiGiaoNhan_Full(cboSoFile.EditValue.ToString());
            }
            else
                cboNguoiGiaoNhan.EditValue = null;
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

            cboNganHang_SelectedIndexChanged_1(sender, e);
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
    }
}