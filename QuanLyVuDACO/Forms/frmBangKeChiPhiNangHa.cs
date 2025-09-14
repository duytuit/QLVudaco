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
    public partial class frmBangKeChiPhiNangHa : DevExpress.XtraEditors.XtraForm
    {
        public frmBangKeChiPhiNangHa()
        {
            InitializeComponent();
        }
        public frmBangKeChiPhiNangHa(int IDLoHang)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
        }
        public frmBangKeChiPhiNangHa(int IDLoHang,int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _sua = sua;
        }
        public frmBangKeChiPhiNangHa(int IDCP,int IDLoHang, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _IDCP = IDCP;
            _sua = sua;
        }
        int _IDLoHang = 0, _sua = 0, _IDCP = 0;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //sua
            bool check = client.BangPhoiNangHa_KiemTraFileGia(_IDCP);
            if (check)
                MessageBox.Show("Bảng phơi nâng hạ này có dữ liệu liên quan File Giá, vui lòng xóa ở File Giá trước để tiếp tục!");
            else
            {
                int _idLoHang = _IDLoHang;
                client.dsBangPhoiNangHa_Xoa1(_IDCP);
                btnLuu_Click(sender, e);
            }
           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //BangPhoiNangHa_KiemTraFileGia
                bool check = client.BangPhoiNangHa_KiemTraFileGia(_IDCP);
                if (check)
                    MessageBox.Show("Bảng phơi nâng hạ này có dữ liệu liên quan File Giá, vui lòng xóa ở File Giá trước để tiếp tục!");
                else
                {
                    int _idLoHang = _IDLoHang;
                    client.dsBangPhoiNangHa_Xoa1(_IDCP);
                    this.Close();
                }
            }
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmBangKeChiPhi_Load(object sender, EventArgs e)
        {
            
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            var tablNCC= client.ds_NCC();
            cboNCC.Properties.DataSource = tablNCC.ToList();
            repositoryItemNCC.DataSource= tablNCC.ToList();
            var t2= client.Ds_CPChiHo().Where(p=>p.MaChiHo=="CH06"||p.MaChiHo=="CH07"||p.MaChiHo=="CH08"||p.MaChiHo=="CH12"||p.MaChiHo=="CH15");
            cboPhiChiHo.Properties.DataSource = t2.ToList();
            if (t2.Count() > 0)
                cboPhiChiHo.EditValue = "CH08";
            dtpNgayTao.DateTime = DateTime.Now;
            lblNguoiTao.Text = frmMain._TK;
            if(_IDLoHang!=0)
            {
                DataTable table = client.DsThongTinFile_Full_TheoIDLoHang(_IDLoHang);
                if(table.Rows.Count>0)
                {
                    for (int i=0;i<table.Rows.Count;i++)
                    {
                        DataRow row = table.Rows[i];
                        lblKh.Text = row["TenKhachHang"].ToString();
                        lblSoBill.Text = row["SoBill"].ToString();
                        lblSoFile.Text = row["SoFile"].ToString();
                        lblSoCont.Text = row["SoCont"].ToString();
                        lblSoLuong.Text = row["SoLuong"].ToString();
                        lblSoToKhai.Text = row["SoToKhai"].ToString();
                        lblDuyetUng.Text = float.Parse(row["DuyetUng"].ToString()).ToString("#,##");
                    }
                }    
            }    
            if(_sua==1)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                var t3 = client.Ds_BangPhoiNangHa(_IDLoHang);
                foreach (var item in t3)
                {
                    dtpNgayTao.DateTime = item.NgayTaoBangKe.Value;
                    lblNguoiTao.Text = item.NguoiTaoBangKe;
                    txtPhiDangKy.Text = item.PhiDangKy.Value.ToString("#,##");
                  //  cboNCC.EditValue = item.MaNhaCungCap;
                }
              
                ////
                //var t5 = (from a in context.BangPhoiNangHa_ChiTiet
                //          join b in context.DanhMuc_PhiChiHo on a.MaChiHo equals b.MaChiHo
                //          select new { a.MaChiHo, b.TenChiHo, SoTien = a.SoTien_ChiHo, GhiChu = a.GhiChu_ChiHo, a.IDLoHang, a.IDCPCT,a.SoHoaDon })
                //        .Where(p => p.IDLoHang == _IDLoHang && p.MaChiHo != null);
                dataSet1.Tables["ChiHo"].Rows.Clear();
                dataSet1.Tables["ChiHo"].Columns.Clear();
                dataSet1.Tables["ChiHo"].Merge(client.BangKeChiPhiNangHa_ChiTiet(_IDLoHang));
                //foreach (var item in t5)
                //{


                //    DataRow row = dataSet1.Tables["ChiHo"].NewRow();
                //    row["MaChiHo"] = item.MaChiHo;
                //    row["TenChiHo"] = item.TenChiHo;
                //    row["SoTien"] = item.SoTien;
                //    row["SoHoaDon"] = item.SoHoaDon;
                //    row["GhiChu"] = item.GhiChu;
                //    dataSet1.Tables["ChiHo"].Rows.Add(row);
                //}
                gridControl2.DataSource = dataSet1.Tables["ChiHo"];
                gridView2.FocusedRowHandle = 0;
                
                TongTienLoHang();
            }    
        }

       
        private void TongTienLoHang()
        {
            double tienUng = (lblDuyetUng.Text == "") ? 0 : double.Parse(lblDuyetUng.Text);
            double phiDangKy = (txtPhiDangKy.Text == "") ? 0 : double.Parse(txtPhiDangKy.Text);
            double TongHQ = 0, tongChiHo = 0;
           
            if (gridView2.RowCount == 0)
                tongChiHo = 0;
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    tongChiHo += double.Parse(gridView2.GetRowCellDisplayText(i, "SoTien"));
                }
            }
            lblTongChiPhi.Text = (phiDangKy + TongHQ + tongChiHo).ToString("#,##");
            lblPhaiThanhToan.Text = (phiDangKy + TongHQ + tongChiHo - tienUng).ToString("#,##");
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (cboPhiChiHo.EditValue == null)
                MessageBox.Show("Vui lòng chọn phí chi hộ!");
            else if (txtPhiChiHo.Text == "")
                MessageBox.Show("Vui lòng nhập số tiền chi hộ!");
            else
            {
                gridView2.AddNewRow();
                gridView2.SetFocusedRowCellValue("MaChiHo", cboPhiChiHo.EditValue.ToString());
                gridView2.SetFocusedRowCellValue("TenChiHo", cboPhiChiHo.Text);
                gridView2.SetFocusedRowCellValue("SoTien", txtPhiChiHo.Text);
                gridView2.SetFocusedRowCellValue("SoHoaDon", txtSoHoaDon.Text);
                gridView2.SetFocusedRowCellValue("GhiChu", txtGhiChuChi.Text);
                gridView2.SetFocusedRowCellValue("MaNhaCungCap",(cboNCC.EditValue==null)?"": cboNCC.EditValue.ToString());
                gridView2.FocusedRowHandle = 0;
                TongTienLoHang();
            }
        }

        private void txtPhiDangKy_EditValueChanged(object sender, EventArgs e)
        {
            TongTienLoHang();
        }

       
        int dong_HQ = -1, dong_ChiHo = 0;

       
       

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                dong_ChiHo = gridView2.FocusedRowHandle;
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                dong_ChiHo = gridView2.FocusedRowHandle;
            }
            catch (Exception)
            {
            }
        }

        private void btnXoaChiHo_Click(object sender, EventArgs e)
        {
            if (dong_ChiHo >= 0)
            {
                gridView2.DeleteRow(dong_ChiHo);
                gridView2.RefreshData();
                dong_ChiHo = -1;
            }
        }
        private void CapNhatFileDebit()
        {
            ServiceReference1.BangPhoiNangHa table1 = new ServiceReference1.BangPhoiNangHa();
            table1.IDLoHang = _IDLoHang;
            table1.PhiDangKy = (txtPhiDangKy.Text == "") ? 0 : float.Parse(txtPhiDangKy.Text);
            table1.NgayTaoBangKe = dtpNgayTao.DateTime;
            table1.NguoiTaoBangKe = lblNguoiTao.Text;
           // table1.MaNhaCungCap = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString().Trim();
            client.Ds_BangPhoiNangHa_Them(table1);

            //bang chi phi chi ho
            if (gridView2.RowCount > 0)
                gridView2.AddNewRow();
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (gridView2.GetRowCellValue(i, "MaChiHo") != null)
                {
                    ServiceReference1.BangPhoiNangHa_ChiTiet table2 = new ServiceReference1.BangPhoiNangHa_ChiTiet();
                    table2.IDLoHang = _IDLoHang;
                    table2.MaChiHo = gridView2.GetRowCellDisplayText(i, "MaChiHo").ToString();
                    table2.SoTien_ChiHo = float.Parse(gridView2.GetRowCellDisplayText(i, "SoTien").ToString());
                    table2.SoHoaDon = gridView2.GetRowCellDisplayText(i, "SoHoaDon").ToString();
                    table2.GhiChu_ChiHo = gridView2.GetRowCellDisplayText(i, "GhiChu").ToString();
                    table2.MaNhaCungCap = gridView2.GetRowCellValue(i, "MaNhaCungCap").ToString();
                    client.Ds_BangPhoiNangHaCT_Them(table2);
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtPhiDangKy.Text != "" &&  gridView2.RowCount == 0)
                MessageBox.Show("Vui lòng nhập số liệu!");
            else if(chkDaThanhToan.Checked)
            {
                ServiceReference1.BangPhoiNangHa table1 = new ServiceReference1.BangPhoiNangHa();
                table1.IDLoHang = _IDLoHang;
                table1.PhiDangKy = (txtPhiDangKy.Text == "") ? 0 : float.Parse(txtPhiDangKy.Text);
                table1.NgayTaoBangKe = dtpNgayTao.DateTime;
                table1.NguoiTaoBangKe = lblNguoiTao.Text;
              //  table1.MaNhaCungCap = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString().Trim();
                client.Ds_BangPhoiNangHa_Them(table1);
            }    
            else
            {
               
                   ServiceReference1. BangPhoiNangHa table1 = new ServiceReference1. BangPhoiNangHa();
                    table1.IDLoHang = _IDLoHang;
                    table1.PhiDangKy = (txtPhiDangKy.Text == "") ? 0 : float.Parse(txtPhiDangKy.Text);
                    table1.NgayTaoBangKe = dtpNgayTao.DateTime;
                    table1.NguoiTaoBangKe = lblNguoiTao.Text;
                   // table1.MaNhaCungCap = (cboNCC.EditValue == null) ? "" : cboNCC.EditValue.ToString().Trim();
                    client.Ds_BangPhoiNangHa_Them(table1);
               
                //bang chi phi chi ho
                if (gridView2.RowCount > 0)
                    gridView2.AddNewRow();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "MaChiHo") != null)
                    {
                       ServiceReference1. BangPhoiNangHa_ChiTiet table2 = new ServiceReference1. BangPhoiNangHa_ChiTiet();
                        table2.IDLoHang = _IDLoHang;
                        table2.MaChiHo = gridView2.GetRowCellDisplayText(i, "MaChiHo").ToString();
                        table2.SoTien_ChiHo = float.Parse(gridView2.GetRowCellDisplayText(i, "SoTien").ToString());
                        table2.SoHoaDon = gridView2.GetRowCellDisplayText(i, "SoHoaDon").ToString();
                        table2.GhiChu_ChiHo = gridView2.GetRowCellDisplayText(i, "GhiChu").ToString();
                        table2.MaNhaCungCap = gridView2.GetRowCellValue(i, "MaNhaCungCap").ToString();
                        client.Ds_BangPhoiNangHaCT_Them(table2);
                    }
                }
                this.Close();
            }    
        }
    }
}