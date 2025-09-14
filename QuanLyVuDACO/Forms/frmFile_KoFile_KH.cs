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
    public partial class frmFile_KoFile_KH : DevExpress.XtraEditors.XtraForm
    {
        public frmFile_KoFile_KH()
        {
            InitializeComponent();
        }
        public frmFile_KoFile_KH(string MaDieuXe,int IDDeBit,int sua)
        {
            InitializeComponent();
            _IDDeBit = IDDeBit;
            _MaDieuXe = MaDieuXe;
            _sua = sua;
        }
        int _IDDeBit = 0, _sua = 0;
        string _MaDieuXe = "";
        
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

        DataTable dtFull = new DataTable("table");
        private void LoadVAT()
        {
            DataTable dt = new DataTable("VAT");
            dt.Columns.Add("VAT");
            dt.Columns.Add("Ten");
            DataRow row = dt.NewRow();
            row["VAT"] = 0;
            row["Ten"] = 0;
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["VAT"] = 5;
            row1["Ten"] = 5;
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["VAT"] = 8;
            row2["Ten"] = 8;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["VAT"] = 10;
            row3["Ten"] = 10;
            dt.Rows.Add(row3);

            DataRow row4 = dt.NewRow();
            row4["VAT"] = -1;
            row4["Ten"] = "Khác";
            dt.Rows.Add(row4);
            cboVAT.Properties.DataSource = dt;
        }
        string _MaKH = "";
        private void frmBangKeChiPhi_Load(object sender, EventArgs e)
        {
            cboNCC.Properties.DataSource = client.ds_NCC();
            LoadVAT();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            var table = client.BangDieuXe_CanTaoHoaDon_KH(_MaDieuXe);
            foreach(var item in table)
            {
                _MaKH = item.MaKH;
                lblKh.Text = item.TenVietTat;
                lblMaDieuXe.Text = item.MaDieuXe;
                lblLoaiXe.Text = item.LoaiXe_KH;
                lblTuyenVC.Text = item.TuyenVC;
                txtTenDichVu.Text = item.TuyenVC;
                lblCuocMua.Text = item.CuocMua.ToString("#,##");
                //txtSoTien.Text = lblCuocMua.Text;
                lblCuocBan.Text = item.CuocBan.ToString("#,##");
                lblLaiXeThuCuoc.Text = item.LaiXeThuCuoc.ToString("#,##");
                txtSoTien.Text =  (item.CuocBan + item.LaiXeThuCuoc).ToString("#,##");
                dtpNgay.Text = item.Ngay.ToString("dd/MM/yyyy");
            }    
            if(_sua==1)
            {
                var table1 = client.FileDebit_KoHoaDon_KH_Xem(_IDDeBit);
                foreach (var item in table1)
                {
                    _MaKH = item.MaKhachHang;
                    var t = client.dsKH_MaKH(_MaKH);
                    foreach (var item2 in t)
                    {
                        lblKh.Text = item2.TenVietTat;
                    }
                    txtSoHoaDon.Text = item.SoHoaDon;
                    lblMaDieuXe.Text = item.MaDieuXe;
                    lblLoaiXe.Text = item.LoaiXe_KH;
                    lblTuyenVC.Text = item.TuyenVC;
                    txtTenDichVu.Text = item.TuyenVC;
                    lblCuocMua.Text = item.CuocMua.Value.ToString("#,##");
                    txtSoTien.Text = lblCuocMua.Text;
                    lblCuocBan.Text = item.CuocBan.Value.ToString("#,##");
                    lblLaiXeThuCuoc.Text = item.LaiXeThuCuoc.Value.ToString("#,##");
                    txtTenDichVu.Text = item.TenDichVu;
                    txtSoTien.Text = item.SoTien.Value.ToString("#,##");
                    cboVAT.EditValue = item.VAT.Value.ToString();
                    txtThanhTien.Text = item.ThanhTien.Value.ToString("#,##");
                    txtGhiChu.Text = item.GhiChu;
                    dtpNgay.Text = item.NgayTao.Value.ToString("dd/MM/yyyy");
                    txtPhiCom.Text = item.PhiCom.Value.ToString("#,##");
                    txtPhiCom_EditValueChanged(sender, e);
                    if(item.MaNhaCungCap!=null)
                       cboNCC.EditValue = item.MaNhaCungCap;
                }
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                
            }    
           
        }
       


        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            if (txtTenDichVu.Text == "")
                MessageBox.Show("Vui lòng nhập dịch vụ!");
           else
            {
                ServiceReference1.FileDebit_KoHoaDon_KH p = new ServiceReference1.FileDebit_KoHoaDon_KH();
                p.MaDieuXe = lblMaDieuXe.Text;
                p.MaKhachHang = _MaKH;
                p.LoaiXe_KH = lblLoaiXe.Text;
                p.SoHoaDon = txtSoHoaDon.Text.Trim();
                p.TuyenVC = lblTuyenVC.Text;
                p.CuocMua = (lblCuocMua.Text=="")?0:double.Parse(lblCuocMua.Text);
                p.CuocBan = (lblCuocBan.Text == "") ? 0 : double.Parse(lblCuocBan.Text);
                p.LaiXeThuCuoc= (lblLaiXeThuCuoc.Text == "") ? 0 : double.Parse(lblLaiXeThuCuoc.Text);
                p.NguoiTao = frmMain._TK;
                string[] arr1 = dtpNgay.Text.Split('/');
                if(arr1.Length==3)
                p.NgayTao =(dtpNgay.Text=="")?DateTime.Now: new DateTime(int.Parse(arr1[2]),int.Parse(arr1[1]), int.Parse(arr1[0]));
                p.TenDichVu = txtTenDichVu.Text;
                p.SoTien = (txtSoTien.Text == "") ? 0 : double.Parse(txtSoTien.Text);
                p.VAT =(cboVAT.EditValue==null)?0: float.Parse((cboVAT.EditValue.ToString()));
                p.ThanhTien= (txtThanhTien.Text == "") ? 0 : double.Parse(txtThanhTien.Text);
                p.GhiChu = txtGhiChu.Text;
                p.PhiCom = (txtPhiCom.Text == "") ? 0 : double.Parse(txtPhiCom.Text);
                p.MaNhaCungCap = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString().Trim();
                p.DoanhThuThuan= (txtDoanhThuThuan.Text == "") ? 0 : double.Parse(txtDoanhThuThuan.Text);
                client.ThemFileDebit_KoHoaDon_KH(p);
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }    
        }
        double _giaMua = 0;
       

       
        private void btnSua_Click(object sender, EventArgs e)
        {
            client.Xoa_FileDebit_KoHoaDon_KH(_IDDeBit);
            btnLuu_Click_1(sender, e);
        }

        private void cboVAT_EditValueChanged(object sender, EventArgs e)
        {
           
            try
            {
                LookUpEdit lookUpEdit = (LookUpEdit)sender;
                if (lookUpEdit.EditValue.ToString().Trim().ToLower() == "-1")
                {
                    txtThanhTien.Text = "0";
                    txtTienVAT.Text = "0";
                    txtTienVAT.Enabled = true;
                }
                else
                {
                    txtTienVAT.Enabled = false;
                    float _vat = float.Parse(cboVAT.EditValue.ToString());
                    float _SoTien = (txtSoTien.Text == "") ? 0 : float.Parse(txtSoTien.Text);
                    float _SoTienVAT = (_vat * _SoTien) / 100;
                    txtTienVAT.Text = _SoTienVAT.ToString("#,##");
                    txtThanhTien.Text = (_SoTien + _SoTienVAT).ToString("#,##");
                }

            }
            catch (Exception)
            {
            }
        }

        private void txtSoTien_EditValueChanged(object sender, EventArgs e)
        {
            cboVAT_EditValueChanged(sender, e);
        }

        private void txtTienVAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                float _SoTien = (txtSoTien.Text == "") ? 0 : float.Parse(txtSoTien.Text);
                float _SoTienVAT = float.Parse(txtTienVAT.Text);
                txtThanhTien.Text = (_SoTien + _SoTienVAT).ToString("#,##");
            }
            catch (Exception)
            {
            }
        }

       

        private void txtPhiCom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                double SoTien = (txtSoTien.Text == "") ? 0 : double.Parse(txtSoTien.Text);
                double PhiCom = (txtPhiCom.Text == "") ? 0 : double.Parse(txtPhiCom.Text);
                txtDoanhThuThuan.Text = (SoTien - PhiCom).ToString("#,##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                client.Xoa_FileDebit_KoHoaDon_KH(_IDDeBit);
                frmBangKeChiPhi_Load(sender, e);
            }    
        }

    }
}