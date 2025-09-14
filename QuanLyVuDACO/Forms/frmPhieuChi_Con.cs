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
    public partial class frmPhieuChi_Con : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuChi_Con()
        {
            InitializeComponent();
        }
        public frmPhieuChi_Con(int IDPhieuChi)
        {
            InitializeComponent();
            _IDPhieuChi = IDPhieuChi;
        }
        int _IDPhieuChi = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        DataTable dtFul = new DataTable();
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
            repositoryItemVAT.DataSource = dt;
        }
        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            LoadVAT();
            repositoryItemXe.DataSource = client.ds_Xe();
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboLoaiQuy.Properties.DataSource = client.DanhMucQuy_Load();
            cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
            cboSoFile.Properties.DataSource = client.DsThongTinFile_Full();
           
            cboSoFile_EditValueChanged(sender, e);

            cboDanhSachChi.Properties.DataSource = client.DanhsachChi_004();
          //  cboDanhSachChi.Properties.DataSource = client.DanhsachChi();
            cboDanhSachChi_EditValueChanged(sender, e);
            radioGroup1_SelectedIndexChanged(sender, e);
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            DataTable dtx = new DataTable();
            dtx.Columns.Add("IDCT");
            dtx.Columns.Add("GhiChu");
            dtx.Columns.Add("SoTien", typeof(double));
            dtx.Columns.Add("VAT");
            dtx.Columns.Add("TienVAT", typeof(double));
            dtx.Columns.Add("ThanhTien", typeof(double));
            dtx.Columns.Add("TenCongTrinh");
            dtx.Columns.Add("LaChiPhiPhanBo",typeof(bool));
            dtx.Columns.Add("LaChiPhiQuanLy", typeof(bool));
            dtFul = dtx;
            if (_IDPhieuChi!=0)
            {
                var table = client.DanhSachPhieuChi_Con_TheoIdPhieuChi(_IDPhieuChi);
                foreach (var item in table)
                {
                    dtpNgayHachToan.Text = item.NgayHachToan.Value.ToString("dd/MM/yyyy");
                    txtSoChungTu.Text = item.SoChungTu;
                    cboLoaiQuy.EditValue = item.MaQuy;
                    txtTenNguoiNhan.Text = item.NguoiNhan;
                    txtDienGiai.Text = item.DienGiai;
                   var t_cha= client.DanhsachChi().Where(p=>p.MaChi==item.MaChi);
                    foreach (var item1 in t_cha)
                    {
                        cboDanhSachChi.EditValue = item1.MaCha;
                    }
                    cboDanhSachChi_EditValueChanged(sender, e);
                    cboDanhSachChiCon.EditValue = item.MaChi;
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
                    DataTable table1 = client.DanhSachPhieuChi_Con_CT_TheoSoChungTu(txtSoChungTu.Text);
                    for (int i=0;i<table1.Rows.Count;i++)
                    {

                        DataRow row = dtx.NewRow();
                        row["IDCT"] = table1.Rows[i]["IDCT"].ToString();
                        row["GhiChu"] = table1.Rows[i]["GhiChu"].ToString();
                        row["SoTien"] = table1.Rows[i]["SoTien"].ToString();
                        row["VAT"] = table1.Rows[i]["VAT"].ToString();
                        double tienVAT =double.Parse(row["SoTien"].ToString()) * double.Parse(row["VAT"].ToString());
                        row["TienVAT"] = Math.Round(tienVAT / 100,2);
                        row["ThanhTien"] = double.Parse(row["SoTien"].ToString()) + double.Parse(row["TienVAT"].ToString());
                        row["TenCongTrinh"] = table1.Rows[i]["TenCongTrinh"].ToString();
                        row["LaChiPhiPhanBo"] = bool.Parse(table1.Rows[i]["LaChiPhiPhanBo"].ToString());
                        row["LaChiPhiQuanLy"] = bool.Parse(table1.Rows[i]["LaChiPhiQuanLy"].ToString());
                        dtx.Rows.Add(row);
                        
                    }
                    dtFul = dtx;
                    gridControl1.DataSource = dtFul;
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

        }

        private void cboDanhSachChi_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDanhSachChi.EditValue != null)
                cboDanhSachChiCon.Properties.DataSource = client.DanhsachChi_001_Con(cboDanhSachChi.EditValue.ToString());
            else
                cboDanhSachChiCon.Properties.DataSource = null;
        }
      private void Xoa()
        {
            dtpNgayHachToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtSoChungTu.Text = "";
            cboLoaiQuy.EditValue = null;
            cboLoaiDoiTuong.EditValue = null;
           // cboLoaiDoiTuong_SelectedIndexChanged(sender, e);
            cboSoFile.EditValue = null;
            txtTenNguoiNhan.Text = "";
            txtDiaChi.Text = "";
            cboDanhSachChi.EditValue = null;
          //  cboDanhSachChi_EditValueChanged(sender, e);
          //  dtpNgayHachToan_TextChanged(sender, e);
            AnButton(true, false, false);
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
           
            //if (cboDanhSachChiCon.EditValue == null)
            //    MessageBox.Show("Vui lòng chọn lý do chi chi tiết!");
            //  else if(txtSoTien.Text=="")
            //    MessageBox.Show("Vui lòng nhập số tiền!");
            //else if (txtVAT.Text == "")
            //    MessageBox.Show("Vui lòng chọn VAT!");
            //else if (txtThanhTien.Text == "")
            //    MessageBox.Show("Vui lòng nhập thành tiền!");
            //else
            //{
            //    try
            //    {
            //        DataRow row = dtFul.NewRow();
            //        row["IDCT"] = 0;
            //        row["GhiChu"] = cboDanhSachChiCon.EditValue.ToString();
            //        row["SoTien"] = double.Parse(txtSoTien.Text);
            //        row["VAT"] = int.Parse(txtVAT.Text);
            //        row["TienVAT"] = Math.Round((double.Parse(row["SoTien"].ToString()) * double.Parse(txtVAT.Text))/100,2);
            //        row["ThanhTien"] = double.Parse(txtSoTien.Text) + double.Parse(row["TienVAT"].ToString());
            //        row["TenCongTrinh"] = txtTenXeCongTrinh.Text.Trim();
            //        row["LaChiPhiPhanBo"] = chkChiPhiCanPhanBo.Checked;
            //        dtFul.Rows.Add(row);
            //        gridControl1.DataSource = dtFul;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoChungTu.Text=="")
                    MessageBox.Show("Vui lòng chọn ngày hạch toán!");
                else if (gridView2.RowCount==0)
                    MessageBox.Show("Vui lòng nhập nội dung chi!");
                else if (cboDanhSachChi.EditValue == null)
                    MessageBox.Show("Vui lòng chọn danh mục chi!");
                else if (cboDanhSachChiCon.EditValue == null)
                    MessageBox.Show("Vui lòng chọn lý do chi chi tiết!");
                else
                {
                    ServiceReference1.PhieuChi_Con p = new ServiceReference1.PhieuChi_Con();
                    p.DienGiai = txtDienGiai.Text;
                    p.LyDoChi = cboDanhSachChi.Text;
                    p.MaChi = cboDanhSachChiCon.EditValue.ToString();
                    p.MaQuy = (cboLoaiQuy.EditValue == null) ? "" : cboLoaiQuy.EditValue.ToString();
                    string[] arr = dtpNgayHachToan.Text.Trim().Split('/');
                    DateTime Ngay1 = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                    p.NgayHachToan = Ngay1;
                    p.NguoiNhan = txtTenNguoiNhan.Text;
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
                    client.DanhSachPhieuChi_Con_Them(p);
                    //phieuchi_ConCT
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, "GhiChu")!=null)
                        {
                            ServiceReference1.PhieuChi_Con_CT p1 = new ServiceReference1.PhieuChi_Con_CT();
                            p1.SoChungTu = p.SoChungTu;
                            p1.DiaChi = txtDiaChi.Text;
                            p1.DoiTuong = (cboLoaiDoiTuong.EditValue == null) ? "" : cboLoaiDoiTuong.EditValue.ToString();
                            p1.GhiChu = gridView2.GetRowCellValue(i, "GhiChu").ToString().Trim();
                            p1.MaDoiTuong = (cboDoiTuong.EditValue == null) ? "" : cboDoiTuong.EditValue.ToString();
                            p1.SoFile = (cboSoFile.EditValue == null) ? "" : cboSoFile.EditValue.ToString();
                            p1.SoTien = double.Parse(gridView2.GetRowCellValue(i, "SoTien").ToString());
                            if (gridView2.GetRowCellValue(i, "VAT") != null)
                                p1.VAT = int.Parse(gridView2.GetRowCellValue(i, "VAT").ToString());
                            else
                                p1.VAT = 0;
                           p1.ThanhTien = double.Parse(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
                            p1.TenDoiTuong = cboDoiTuong.Text;
                            p1.TenCongTrinh = gridView2.GetRowCellValue(i, "TenCongTrinh").ToString().Trim();
                            p1.IDCP = 0;
                            p1.LaChiPhiPhanBo =(gridView2.GetRowCellValue(i, "LaChiPhiPhanBo").ToString().Trim()=="")?false: bool.Parse(gridView2.GetRowCellValue(i, "LaChiPhiPhanBo").ToString());
                            p1.LaChiPhiQuanLy = (gridView2.GetRowCellValue(i, "LaChiPhiQuanLy").ToString().Trim() == "") ? false : bool.Parse(gridView2.GetRowCellValue(i, "LaChiPhiQuanLy").ToString());
                            p1.MaNhanVien = (cboNguoiGiaoNhan.EditValue == null) ? "" : cboNguoiGiaoNhan.EditValue.ToString();
                            client.DanhSachPhieuChi_Con_CT_Them(p1);
                        }
                    }
                  
                  //  MessageBox.Show("Tạo phiếu chi xong!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private void dtpNgayHachToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arr = dtpNgayHachToan.Text.Trim().Split('/');
                if (arr.Length == 3)
                {
                    txtSoChungTu.Text = client.TaoSoChungTu_Con(arr);

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
            
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.PhieuChi_Con p = new ServiceReference1.PhieuChi_Con();
                p.IDPhieuChi = _IDPhieuChi;
                client.DanhSachPhieuChi_Con_Xoa(p);
                this.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboDanhSachChi.EditValue != null)
            {
               
                    if (txtSoChungTu.Text == "")
                        MessageBox.Show("Vui lòng chọn ngày hạch toán!");
                   
                    else if (cboDanhSachChi.EditValue == null)
                        MessageBox.Show("Vui lòng chọn danh mục chi!");
                    else if (cboDanhSachChi.EditValue == null)
                        MessageBox.Show("Vui lòng chọn lý do chi!");
                    else
                    {
                        ServiceReference1.PhieuChi_Con p = new ServiceReference1.PhieuChi_Con();
                        p.IDPhieuChi = _IDPhieuChi;
                        client.DanhSachPhieuChi_Con_Xoa(p);
                        btnLuu_Click(sender, e);
                    }
            }
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

       
        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
          //if(gridView2.IsNewItemRow(e.RowHandle))
          //  {
               
          //  }    
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "VAT"|| e.Column.FieldName == "SoTien")
            {
                double _SoTien = (gridView2.GetFocusedRowCellValue("SoTien").ToString() == "") ? 0 : double.Parse(gridView2.GetFocusedRowCellValue("SoTien").ToString());
                double _VAT = (gridView2.GetFocusedRowCellValue("VAT").ToString() == "") ? 0 : double.Parse(gridView2.GetFocusedRowCellValue("VAT").ToString());
                double _TienVAT = 0;
                if (_VAT != -1)
                {
                    _TienVAT = (_SoTien * _VAT) / 100;
                    gridView2.SetFocusedRowCellValue("TienVAT", _TienVAT);
                    gridView2.SetFocusedRowCellValue("ThanhTien", _SoTien + _TienVAT);
                }
                else
                {
                    _TienVAT = 0;
                    gridView2.SetFocusedRowCellValue("TienVAT", 0);
                    gridView2.SetFocusedRowCellValue("ThanhTien", 0);
                }
            }
            
        }

        private void repositoryItemVAT_EditValueChanged(object sender, EventArgs e)
        {
           
          //  if(repositoryItemVAT.ed)
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _ID = int.Parse(gridView2.GetFocusedRowCellValue("IDCT").ToString());
                int _IDPhieuChi = int.Parse(gridView2.GetFocusedRowCellValue("IDPhieuChi").ToString());
                using (var _db = new clsKetNoi())
                {
                    _db.DeleteById("PhieuChi_Con_CT", _ID, "IDCT");
                    DataRow item = _db.GetSingleRecord("PhieuChi_Con_CT", _ID, "IDCT");
                    if (item == null)
                    {
                        _db.DeleteById("PhieuChi_Con", _IDPhieuChi, "IDPhieuChi");
                    }
                }
                frmPhieuChi_Load(sender, e);
            }
           
        }
    }
}