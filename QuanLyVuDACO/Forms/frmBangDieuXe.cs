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
    public partial class frmBangDieuXe : DevExpress.XtraEditors.XtraForm
    {
        public frmBangDieuXe()
        {
            InitializeComponent();
        }
        public frmBangDieuXe(int _IDBangPhi)
        {
            InitializeComponent();
            IDLoHang = _IDBangPhi;
        }
        public frmBangDieuXe(string _SoFile)
        {
            InitializeComponent();
            SoFile = _SoFile;
        }
        string SoFile = "";
        int IDLoHang = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void LoadMaDieuXe()
        {
           txtMaDieuXe.Text= client.LoadMaDieuXe(NgayDateEdit.DateTime);
        }
        private void frmBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            NgayDateEdit.DateTime = DateTime.Now;
            LoadMaDieuXe();
            XoaText();
            NguoiTaoTextEdit.Text = frmMain._TK;
            NguoiTaoTextEdit.Enabled = false;
            DataTable dtKH = new DataTable("dt");
            dtKH.Columns.Add("MaKhachHang");
            dtKH.Columns.Add("TenKhachHang");
            dtKH.Columns.Add("TenVietTat");
            var tkh= client.dsKH();
            foreach (var item in tkh)
            {
                DataRow row = dtKH.NewRow();
                row["MaKhachHang"] = item.MaKhachHang;
                row["TenKhachHang"] = item.TenKhachHang;
                row["TenVietTat"] = item.TenVietTat;
                dtKH.Rows.Add(row);
            }
            cboKH.Properties.DataSource =dtKH;
            cboKH.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboKH.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSuggest;
            DataTable dtNCC = new DataTable("dt");
            dtNCC.Columns.Add("MaNhaCungCap");
            dtNCC.Columns.Add("TenNhaCungCap");
            dtNCC.Columns.Add("TenVietTat");
            var tncc = client.ds_NCC();
            foreach (var item in tncc)
            {
                DataRow row = dtNCC.NewRow();
                row["MaNhaCungCap"] = item.MaNhaCungCap;
                row["TenNhaCungCap"] = item.TenNhaCungCap;
                row["TenVietTat"] = item.TenVietTat;
                dtNCC.Rows.Add(row);
            }
            cboNCC.Properties.DataSource = dtNCC;
            cboNCC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboNCC.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSuggest;
            cboSoFile.Properties.DataSource = client.DsThongTinFile_Full();
            if (SoFile != "")
            {
                cboSoFile.EditValue = SoFile;
                var t1 = client.DsThongTinFile_Full_SoFile(SoFile);
                foreach (var item in t1)
                {
                    cboKH.EditValue = item.MaKhachHang;
                }
            }    
              
            cboLaiXe.Properties.DataSource = client.DsTaiKhoan_LXE();
            cboBienSoXe.Properties.DataSource = client.ds_Xe();
            if (IDLoHang==0)
            {
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }    
            else
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                //xem lai thong tin da nhap 
                var table = client.DSBangDieuXe_TheoIDBangPhi(IDLoHang);
                foreach (var item in table)
                {
                    NgayDateEdit.DateTime = item.Ngay.Value;
                    TuyenVCTextEdit.Text = item.TuyenVC;
                    cboSoFile.Text = item.SoFile.ToString();
                    cboBienSoXe.EditValue = item.BienSoXe;
                    var t1 = client.ds_Xe().Where(p=>p.BienSoXe==item.BienSoXe);
                    foreach (var item1 in t1)
                    {
                        chkLaXeNgoai.Checked = item1.LaXeNgoai.Value;
                    }
                    cboKH.EditValue = item.MaKhachHang;
                    cboNCC.EditValue = item.MaNhaCungCap;
                    txtLoaiXeNCC.Text = item.LoaiXe_NCC;
                    if (item.LaiXeThuCuoc!=null)
                    txtLaiXeThuCuoc.Text = item.LaiXeThuCuoc.Value.ToString();
                    txtLoaiXeNCC.Text = item.LoaiXe_NCC;
                    cboLaiXe.EditValue = item.LaiXe;
                    NguoiTaoTextEdit.Text = item.NguoiTao;
                    GhiChuTextEdit.Text = item.GhiChu;
                    if(item.LuongHangVe!=null)
                      txtLuongHangVe.Text = item.LuongHangVe.Value.ToString();
                    if(item.CuocBan!=null)
                       txtCuocBan.Text = item.CuocBan.Value.ToString();
                    if(item.CuocMua!=null)
                       txtCuocMua.Text = item.CuocMua.Value.ToString();
                    if(item.TTHQ!=null)
                       txtTTHQ.Text = item.TTHQ.Value.ToString();
                    txtMaDieuXe.Text = item.MaDieuXe;
                    txtTienAn.Text = item.TienAn.Value.ToString();
                    txtTienLuat.Text = item.TienLuat.Value.ToString();
                    txtTienQuaDem.Text = item.QuaDem.Value.ToString();
                }
            }    
        }
        private void XoaText()
        {
            NgayDateEdit.DateTime = DateTime.Now;
            TuyenVCTextEdit.Text = "";
            cboSoFile.Text = "";
            cboBienSoXe.EditValue = "";
            cboKH.EditValue = "";
            cboNCC.EditValue = "";
            txtLoaiXeNCC.Text = "";
            txtLaiXeThuCuoc.Text = "";
            txtLoaiXeNCC.Text = "";
            cboLaiXe.EditValue = "";
            NguoiTaoTextEdit.Text = frmMain._TK;
            GhiChuTextEdit.Text = "";
            cboKH.Text = "";
            txtCuocBan.Text = "";
            txtCuocMua.Text = "";
            txtTTHQ.Text = "";
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            IDLoHang = 0;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (NgayDateEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn ngày!");
            else if(TuyenVCTextEdit.Text=="")
                MessageBox.Show("Vui lòng nhập tuyến vận chuyển!");
            else
            {
               
              ServiceReference1.  BangDieuXe table1 = new ServiceReference1.BangDieuXe();
                table1.Ngay = NgayDateEdit.DateTime;
                table1.TuyenVC = TuyenVCTextEdit.Text;
                table1.SoFile = (cboSoFile.EditValue == null) ? "" : cboSoFile.EditValue.ToString();
                table1.MaKhachHang = (cboKH.EditValue == null) ? "" : cboKH.EditValue.ToString();
                table1.LoaiXe_KH = txtLoaiXeKH.Text;
                table1.LoaiXe_NCC = txtLoaiXeNCC.Text;
                table1.CuocBan = (txtCuocBan.Text == "") ? 0 : float.Parse(txtCuocBan.Text);
                table1.LaiXeThuCuoc = (txtLaiXeThuCuoc.Text == "") ? 0 : float.Parse(txtLaiXeThuCuoc.Text);
                table1.TTHQ = (txtTTHQ.Text == "") ? 0 : float.Parse(txtTTHQ.Text);
                table1.CuocMua=(txtCuocMua.Text=="")?0:float.Parse(txtCuocMua.Text);
                table1.MaNhaCungCap = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString();
                table1.BienSoXe = (cboBienSoXe.EditValue == null) ? "" : cboBienSoXe.EditValue.ToString();
                table1.LaiXe = (cboLaiXe.EditValue == null) ? "" : cboLaiXe.EditValue.ToString();
                table1.NguoiTao = frmMain._TK;
                table1.MaDieuXe = txtMaDieuXe.Text;
                table1.GhiChu = GhiChuTextEdit.Text;
                table1.LuongHangVe = (txtLuongHangVe.Text == "") ? 0 : float.Parse(txtLuongHangVe.Text);
                table1.TienAn = (txtTienAn.Text == "") ? 0 : float.Parse(txtTienAn.Text);
                table1.TienVe = (txtTienVe.Text == "") ? 0 : float.Parse(txtTienVe.Text);
                table1.QuaDem = (txtTienQuaDem.Text == "") ? 0 : float.Parse(txtTienQuaDem.Text);
                table1.TienLuat = (txtTienLuat.Text == "") ? 0 : float.Parse(txtTienLuat.Text);
                client.DsBangDieuXe_Them(table1);
                ThemBienSoXe_Auto(table1.BienSoXe);
                this.Close();
                  
            }    
        }
        private void ThemBienSoXe_Auto(string bienSo)
        {
            if (bienSo != "")
            {
                var table = client.ds_Xe().ToList().Where(p => p.BienSoXe == bienSo);
                if (table.Count() == 0)//neu trong he thong chua co thi them vao auto
                {
                    ServiceReference1.DanhSachXe tableXe = new ServiceReference1.DanhSachXe();
                    tableXe.BienSoXe = bienSo;
                    tableXe.LaXeNgoai = chkLaXeNgoai.Checked;
                    tableXe.GhiChu = "";
                    client.DanhSachXe_Them(tableXe);
                }
            }
        }
      

        private void btnSua_Click(object sender, EventArgs e)
        {
            //bool check = client.BangDieuXe_KiemTraFileGia(IDLoHang);
            //if (check)
            //    MessageBox.Show("Bảng nhật kí này có dữ liệu liên quan file giá, vui lòng xóa ở file giá trước để tiếp tục!");
            //else
            //{
                client.XoaBangDieuXe(IDLoHang);
                btnLuu_Click(sender, e);
            //}
        }
        private void xoaThongTin()
        {
           
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (frmMain._TK != "admin")
            //    MessageBox.Show("Chỉ Admin mới có quyền này");
            //else
            //{
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //BangDieuXe_KiemTraBangPhoiNangHa
                bool check = client.BangDieuXe_KiemTraFileGia(IDLoHang);
                if (check)
                    MessageBox.Show("Bảng nhật kí này có dữ liệu liên quan file giá, vui lòng xóa ở file giá trước để tiếp tục!");
                else
                {
                    client.XoaBangDieuXe(IDLoHang);
                    this.Close();
                }
            }
          //  }
        }
        int dong_HQ = -1;

        private void NgayDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadMaDieuXe();
        }
    }
}