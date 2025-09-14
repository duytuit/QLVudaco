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
    public partial class frmPhieuMuaHang : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuMuaHang()
        {
            InitializeComponent();
        }
        public frmPhieuMuaHang(int IDPhieuChi)
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
            cboNhaCC.Properties.DataSource = client.ds_NCC();
            cboNhanVien.Properties.DataSource = client.dsNhanVien();
            cboDanhSachChi.Properties.DataSource = client.DanhsachChi_004();
            cboDanhSachChi_EditValueChanged(sender, e);
            repositoryItemXe.DataSource = client.ds_Xe();
            dtpNgayMua.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            DataTable dtx = new DataTable();
            dtx.Columns.Add("IDPhieuMuaCT");
            dtx.Columns.Add("NoiDung");
            dtx.Columns.Add("SoTien", typeof(double));
            dtx.Columns.Add("VAT");
            dtx.Columns.Add("ThueVAT", typeof(double));
            dtx.Columns.Add("ThanhTienVAT", typeof(double));
            dtx.Columns.Add("SoHoaDon");
            dtx.Columns.Add("BienSoXe");
            dtx.Columns.Add("LaChiPhiPhanBo",typeof(bool));
            dtx.Columns.Add("LaChiPhiQuanLy", typeof(bool));
            dtFul = dtx;
            if (_IDPhieuChi!=0)
            {
                var table = client.DanhSachMuaHang_TheoIDPhieuMua(_IDPhieuChi);
                foreach (var item in table)
                {
                    dtpNgayMua.Text = item.NgayMua.Value.ToString("dd/MM/yyyy");
                    txtDienGiai.Text = item.DienGiai;
                    cboDanhSachChi.EditValue = item.MaChi;
                    cboDanhSachChi_EditValueChanged(sender, e);
                    cboDanhSachChiCon.EditValue = item.MaChiCon;
                    cboNhaCC.EditValue = item.MaNhaCC;
                    cboNhanVien.EditValue = item.MaNhanVien;
                    var table1 = client.DanhSachMuaHang_CT_TheoIDPhieuMua(_IDPhieuChi);
                    foreach (var item1 in table1)
                    {

                        DataRow row = dtx.NewRow();
                        row["IDPhieuMuaCT"] = item1.IDPhieuMuaCT;
                        row["NoiDung"] = item1.NoiDung;
                        row["SoTien"] = item1.SoTien.Value;
                        row["VAT"] = item1.VAT.Value;
                        row["ThueVAT"] = item1.ThueVAT.Value;
                        row["ThanhTienVAT"] = item1.SoTien.Value + item1.ThueVAT.Value;
                     
                        row["SoHoaDon"] = item1.SoHoaDon;
                        row["BienSoXe"] = item1.BienSoXe;
                        row["LaChiPhiPhanBo"] = item1.LaChiPhiPhanBo;
                        row["LaChiPhiQuanLy"] = item1.LaChiPhiQuanLy;
                        dtx.Rows.Add(row);
                        
                    }
                    dtFul = dtx;
                    gridControl1.DataSource = dtFul;
                    AnButton(false, true, true);
                }
            }    
            else
                gridControl1.DataSource = dtx;
        }
        private void AnButton(bool luu, bool sua, bool xoa)
        {
            btnLuu.Enabled = luu;
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
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
            dtpNgayMua.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDienGiai.Text = "";
            cboNhaCC.EditValue = null;
            cboNhanVien.EditValue = null;
           
            cboDanhSachChi.EditValue = null;
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
               
                 if (gridView2.RowCount==0)
                    MessageBox.Show("Vui lòng nhập nội dung mua!");
                else if (cboDanhSachChi.EditValue == null)
                    MessageBox.Show("Vui lòng chọn danh mục chi!");
                else if (cboDanhSachChiCon.EditValue == null)
                    MessageBox.Show("Vui lòng chọn lý do chi chi tiết!");
                else
                {
                    ServiceReference1.PhieuMua p = new ServiceReference1.PhieuMua();
                    p.DienGiai = txtDienGiai.Text;
                    p.MaChi = cboDanhSachChi.EditValue.ToString();
                    p.MaChiCon = cboDanhSachChiCon.EditValue.ToString();
                    p.MaNhanVien = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString();
                    p.NguoiMuaHang = txtNguoiMua.Text;
                    p.MaNhaCC=(cboNhaCC.EditValue == null) ? "" : cboNhaCC.EditValue.ToString();
                    string[] arr = dtpNgayMua.Text.Trim().Split('/');
                    DateTime Ngay1 = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                    p.SoPhieu = client.Top1SoPhieu_MuaHang(Ngay1);
                    p.NgayMua = Ngay1;
                    p.NguoiTao = frmMain._TK;
                    //phieuchi_ConCT
                    int dong = 0;
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (!gridView2.IsNewItemRow(dong))
                            dong++;
                    }
                    List<ServiceReference1.PhieuMuaCT> pCT = new List<ServiceReference1.PhieuMuaCT>();
                    for (int i = 0; i < gridView2.RowCount-1; i++)
                    {

                        ServiceReference1.PhieuMuaCT p1 = new ServiceReference1.PhieuMuaCT();
                        p1.NoiDung = gridView2.GetRowCellValue(i, "NoiDung").ToString();
                        p1.SoTien = double.Parse(gridView2.GetRowCellValue(i, "SoTien").ToString());
                        p1.VAT = int.Parse(gridView2.GetRowCellValue(i, "VAT").ToString());
                        p1.ThueVAT = double.Parse(gridView2.GetRowCellValue(i, "ThueVAT").ToString());
                        p1.ThanhTienVAT = double.Parse(gridView2.GetRowCellValue(i, "ThanhTienVAT").ToString());
                        p1.SoHoaDon = gridView2.GetRowCellValue(i, "SoHoaDon").ToString().Trim();
                        p1.BienSoXe = gridView2.GetRowCellValue(i, "BienSoXe").ToString().Trim();
                        p1.LaChiPhiPhanBo = (gridView2.GetRowCellValue(i, "LaChiPhiPhanBo").ToString().Trim() == "") ? false : bool.Parse(gridView2.GetRowCellValue(i, "LaChiPhiPhanBo").ToString());
                        p1.LaChiPhiQuanLy = (gridView2.GetRowCellValue(i, "LaChiPhiQuanLy").ToString().Trim() == "") ? false : bool.Parse(gridView2.GetRowCellValue(i, "LaChiPhiQuanLy").ToString());
                        pCT.Add(p1);
                        
                    }
                    client.ThemPhieuMua(p, pCT.ToArray());

                    //  MessageBox.Show("Tạo phiếu chi xong!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        

      

        private void btnXoa_Click(object sender, EventArgs e)
        {
            client.XoaPhieuMua(_IDPhieuChi);
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            client.XoaPhieuMua(_IDPhieuChi);
            btnLuu_Click(sender, e);
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
                    gridView2.SetFocusedRowCellValue("ThueVAT", _TienVAT);
                    gridView2.SetFocusedRowCellValue("ThanhTienVAT", _SoTien + _TienVAT);
                }
                else
                {
                    _TienVAT = 0;
                    gridView2.SetFocusedRowCellValue("ThueVAT", 0);
                    gridView2.SetFocusedRowCellValue("ThanhTienVAT", 0);
                }
            }
            
        }

        private void repositoryItemVAT_EditValueChanged(object sender, EventArgs e)
        {
           
          //  if(repositoryItemVAT.ed)
        }
    }
}