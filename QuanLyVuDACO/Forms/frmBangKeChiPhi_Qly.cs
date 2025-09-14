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
    public partial class frmBangKeChiPhi_Qly : DevExpress.XtraEditors.XtraForm
    {
        
        public frmBangKeChiPhi_Qly(int IDCP,int sua)
        {
            InitializeComponent();
            _IDCP = IDCP;
            _sua = sua;
        }
        int _IDCP = 0, _sua = 0, _IDLoHang = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //sua
            if (cboNguoiGiaoNhan.EditValue != null)
            {
                bool check = client.BangKeChiPhi_KiemTraFileGia(_IDCP);
                if (check)
                    MessageBox.Show("Bảng kê chi phí này có dữ liệu liên quan đến file giá, vui lòng xóa file giá trước để tiếp tục!");
                else
                {
                    int _idLoHang = client.IDLoHang_Theo_IDCP(_IDCP);
                    client.XoaBangKe_IDCP(_IDCP);
                    ThemBangKe(1);
                    //cập nhật file Gia theo bảng kê chi phí 23.08
                }
            }
            else
                MessageBox.Show("Lô hàng này chưa có người giao nhận. Vui lòng cập nhật thông tin file!");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //BangKeChiPhi_KiemTraBangDieuXe
                bool check = client.BangKeChiPhi_KiemTraFileGia(_IDLoHang);
                if (check)
                    MessageBox.Show("Bảng kê chi phí này có dữ liệu liên quan đến file giá, vui lòng xóa file giá trước để tiếp tục!");
                else
                {
                    int _idLoHang = client.IDLoHang_Theo_IDCP(_IDCP);
                    client.XoaBangKe_IDCP(_IDCP);
                    this.Close();
                }
            }
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }
        int _ID = 0;
        private void frmBangKeChiPhi_Load(object sender, EventArgs e)
        {
            cboSoFile.Properties.DataSource = client.DsThongTinFile_Full();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cboChiPhiHQ.Properties.DataSource = client.Ds_CPHQ();
            cboPhiChiHo.Properties.DataSource = client.Ds_CPChiHo();
            dtpNgayTao.DateTime = DateTime.Now;
            lblNguoiTao.Text = frmMain._TK;
            if (_IDLoHang!=0)//IDCP
            {
               //int IDLo= client.IDLoHang_Theo_IDCP(_IDLoHang);
             
                DataTable table = client.DsThongTinFile_Full_TheoIDLoHang(_IDLoHang);
                if (table.Rows.Count>0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        lblKh.Text = item["TenKhachHang"].ToString();
                        lblSoBill.Text = item["SoBill"].ToString();
                        lblSoFile.Text = item["SoFile"].ToString();
                        cboNguoiGiaoNhan.Properties.DataSource = client.DsThongTinFile_NguoiGiaoNhan_Full(lblSoFile.Text);
                        cboNguoiGiaoNhan.Text= item["TenGiaoNhan"].ToString();
                        cboNguoiGiaoNhan_EditValueChanged(sender, e);
                        lblSoCont.Text = item["SoCont"].ToString();
                        lblSoLuong.Text = item["SoLuong"].ToString();
                        lblSoToKhai.Text = item["SoToKhai"].ToString();
                        //lblDuyetUng.Text = float.Parse(item["DuyetUng"].ToString()).ToString("#,##");
                        cboSoFile.Enabled = false;

                    }
                }    
            }    
            if(_sua==1)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
               
                int IDLo = client.IDLoHang_Theo_IDCP(_IDCP);
                _IDLoHang = IDLo;
            
                //
                DataTable table = client.DsThongTinFile_Full_TheoIDLoHang(_IDLoHang);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        lblKh.Text = item["TenKhachHang"].ToString();
                        lblSoBill.Text = item["SoBill"].ToString();
                        lblSoFile.Text = item["SoFile"].ToString();
                        cboNguoiGiaoNhan.Properties.DataSource = client.DsThongTinFile_NguoiGiaoNhan_Full(lblSoFile.Text);
                        var t2 = client.BangLietKeCP_TheoIDCP(_IDCP);
                        foreach (var item2 in t2)
                        {
                            cboNguoiGiaoNhan.EditValue = item2.MaNhanVien;
                        }
                        // cboNguoiGiaoNhan.Text = item["TenGiaoNhan"].ToString();
                        //  cboNguoiGiaoNhan_EditValueChanged(sender, e);
                        lblSoCont.Text = item["SoCont"].ToString();
                        lblSoLuong.Text = item["SoLuong"].ToString();
                        lblSoToKhai.Text = item["SoToKhai"].ToString();
                      //  lblDuyetUng.Text = float.Parse(item["DuyetUng"].ToString()).ToString("#,##");
                        cboSoFile.Enabled = false;

                    }
                }
                //

                var t3 = client.BangKe_TheoIDLoHang(_IDLoHang);
                foreach (var item in t3)
                {
                    //  cboSoFile.EditValue = _IDLoHang.ToString();
                  //  cboSoFile.Text = lblSoFile.Text;
                  //  cboSoFile_EditValueChanged(sender, e);
                  //  cboNguoiGiaoNhan.Properties.DataSource = client.DsThongTinFile_NguoiGiaoNhan_Full(lblSoFile.Text);
                   // cboNguoiGiaoNhan.EditValue = item.MaNhanVien;
                  //  cboNguoiGiaoNhan_EditValueChanged(sender, e);
                  
                    dtpNgayTao.DateTime = item.NgayTaoBangKe.Value;
                    lblNguoiTao.Text = item.NguoiTaoBangKe;
                 //   txtPhiDangKy.Text = item.PhiDangKy.Value.ToString("#,##");
                }
                //var t4 = (from a in context.BangLietKeCP_ChiTiet
                //         join b in context.DanhMuc_CPHQ on a.MaChiPhi_HQ equals b.MaChiPhi
                //         select new {a.MaChiPhi_HQ,b.TenChiPhi,SoTien=a.SoTien_HQ,GhiChu=a.GhiChu_HQ,a.IDLoHang,a.IDCPCT})
                //         .Where(p => p.IDLoHang == _IDLoHang&&p.MaChiPhi_HQ!=null);
                dataSet1.Tables["HQ"].Rows.Clear();
                //dataSet1.Tables["HQ"].Columns.Clear();
                DataTable dtCH = client.BangKeCP_ChiTiet_HQ_IDCP(_IDCP);
                for (int i = 0; i < dtCH.Rows.Count; i++)
                {
                    DataRow row = dataSet1.Tables["HQ"].NewRow();
                    row["MaChiPhi"] = dtCH.Rows[i]["MaChiPhi"].ToString();
                    row["TenChiPhi"] = dtCH.Rows[i]["TenChiPhi"].ToString();
                    row["SoTien"] = dtCH.Rows[i]["SoTien"].ToString();
                    row["GhiChu"] = dtCH.Rows[i]["GhiChu"].ToString();
                    dataSet1.Tables["HQ"].Rows.Add(row);

                }
                gridControl1.DataSource = dataSet1.Tables["HQ"];
                gridView1.FocusedRowHandle = 0;
                //
                //var t5 = (from a in context.BangLietKeCP_ChiTiet
                //          join b in context.DanhMuc_PhiChiHo on a.MaChiHo equals b.MaChiHo
                //          select new { a.MaChiHo, b.TenChiHo, SoTien = a.SoTien_ChiHo, GhiChu = a.GhiChu_ChiHo, a.IDLoHang, a.IDCPCT,a.SoHoaDon })
                //        .Where(p => p.IDLoHang == _IDLoHang && p.MaChiHo != null);
                dataSet1.Tables["ChiHo"].Rows.Clear();
                DataTable dt1 = client.BangKeCP_ChiTiet_ChiHo_IDCP(_IDCP);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DataRow row = dataSet1.Tables["ChiHo"].NewRow();
                    row["MaChiHo"] = dt1.Rows[i]["MaChiHo"].ToString();
                    row["TenChiHo"] = dt1.Rows[i]["TenChiHo"].ToString();
                    row["SoTien"] = dt1.Rows[i]["SoTien"].ToString();
                    row["GhiChu"] = dt1.Rows[i]["GhiChu"].ToString();
                    dataSet1.Tables["ChiHo"].Rows.Add(row);
                }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cboChiPhiHQ.EditValue == null)
                MessageBox.Show("Vui lòng chọn phí hải quan!");
            else if(txtChiPhiHQ.Text=="")
                MessageBox.Show("Vui lòng nhập số tiền hải quan!");
            else
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("MaChiPhi", cboChiPhiHQ.EditValue.ToString());
                gridView1.SetFocusedRowCellValue("TenChiPhi", cboChiPhiHQ.Text);
                gridView1.SetFocusedRowCellValue("SoTien", txtChiPhiHQ.Text);
                gridView1.SetFocusedRowCellValue("GhiChu", txtGhiChu_HQ.Text);
                gridView1.FocusedRowHandle = 0;
                TongTienLoHang();
            }    
        }
        private void TongTienLoHang()
        {
            double tienUng = (lblDuyetUng.Text == "") ? 0 : double.Parse(lblDuyetUng.Text);
            double phiDangKy = 0;
            double TongHQ = 0, tongChiHo = 0;
            if (gridView1.RowCount == 0)
                TongHQ = 0;
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                   TongHQ += double.Parse(gridView1.GetRowCellDisplayText(i,"SoTien"));
                }
            }
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
                gridView2.SetFocusedRowCellValue("GhiChu", txtGhiChuChi.Text);
                gridView2.SetFocusedRowCellValue("SoHoaDon", txtSoHD.Text);
                gridView2.FocusedRowHandle = 0;
                TongTienLoHang();
            }
        }

        private void txtPhiDangKy_EditValueChanged(object sender, EventArgs e)
        {
            TongTienLoHang();
        }

        private void btnXoaHQ_Click(object sender, EventArgs e)
        {
            if(dong_HQ>=0)
            {
                gridView1.DeleteRow(dong_HQ);
                gridView1.RefreshData();
                dong_HQ = -1;
            }    
        }
        int dong_HQ = -1, dong_ChiHo = 0;

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                dong_HQ = gridView1.FocusedRowHandle;
            }
            catch (Exception)
            {
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                dong_HQ = gridView1.FocusedRowHandle;
            }
            catch (Exception)
            {
            }
        }

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

        private void cboSoFile_EditValueChanged(object sender, EventArgs e)
        {
           
            if (cboSoFile.EditValue != null)
            {
                
                DataTable dt1= client.DsThongTinFile_NguoiGiaoNhan_Full(cboSoFile.EditValue.ToString().Trim());
                cboNguoiGiaoNhan.Properties.DataSource = dt1;
                if (dt1.Rows.Count == 0)
                    MessageBox.Show("Số file này chưa thiết lập người giao nhận!");
                if (_sua==0)
                _IDLoHang = int.Parse(cboSoFile.EditValue.ToString());
                if (_IDLoHang != 0)
                {
                    DataTable table = client.DsThongTinFile_Full_TheoIDLoHang(_IDLoHang);
                    if (table.Rows.Count > 0)
                    {
                        cboNguoiGiaoNhan.Properties.DataSource = client.DsThongTinFile_NguoiGiaoNhan_Full(cboSoFile.Text);
                        lblSoFile.Text = cboSoFile.Text;
                        foreach (DataRow item in table.Rows)
                        {
                            lblKh.Text = item["TenKhachHang"].ToString();
                            lblSoBill.Text = item["SoBill"].ToString();
                            lblSoFile.Text = item["SoFile"].ToString();
                            lblSoCont.Text = item["SoCont"].ToString();
                            lblSoLuong.Text = item["SoLuong"].ToString();
                            lblSoToKhai.Text = item["SoToKhai"].ToString();
                            cboNguoiGiaoNhan.Text = item["TenGiaoNhan"].ToString();
                            cboNguoiGiaoNhan_EditValueChanged(sender, e);
                           // lblDuyetUng.Text = float.Parse(item["DuyetUng"].ToString()).ToString("#,##");
                        }
                    }
                }
            }
            else
            {
                lblDuyetUng.Text = "0";
                cboNguoiGiaoNhan.EditValue = null;
                dataSet1.Tables["HQ"].Rows.Clear();
                _IDLoHang = 0;
                lblKh.Text = "";
                lblSoBill.Text = "";
                lblSoFile.Text = "";
                lblSoCont.Text = "";
                lblSoLuong.Text = "";
                lblSoToKhai.Text = "";
                lblDuyetUng.Text = "";
                gridControl1.DataSource = dataSet1.Tables["HQ"];
                gridView1.FocusedRowHandle = 0;
                gridControl2.DataSource = dataSet1.Tables["ChiHo"];
                gridView2.FocusedRowHandle = 0;
                TongTienLoHang();
            }
        }

        private void cboSoFile_TextChanged(object sender, EventArgs e)
        {
            cboSoFile_EditValueChanged(sender, e);
        }

        private void cboNguoiGiaoNhan_EditValueChanged(object sender, EventArgs e)
        {
            if (cboNguoiGiaoNhan.EditValue != null)
                lblDuyetUng.Text = client.TongDuyetUng(lblSoFile.Text, cboNguoiGiaoNhan.EditValue.ToString(), _IDCP).ToString("#,##");
            else
                lblDuyetUng.Text = "0";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           
            client.BangKe_Duyet(_IDCP, txtLyDo.Text, frmMain._TK, DateTime.Now);
            this.Close();
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
        private void ThemBangKe(int ThemMoi)
        {
            //if (gridView1.RowCount == 0 && gridView2.RowCount == 0)
            //    MessageBox.Show("Vui lòng nhập số liệu!");
            //else
            //{
                ServiceReference1.BangLietKeCP table1 = new ServiceReference1.BangLietKeCP();
                table1.IDLoHang = _IDLoHang;
                table1.PhiDangKy = 0;
                table1.NgayTaoBangKe = dtpNgayTao.DateTime;
                table1.NguoiTaoBangKe = lblNguoiTao.Text;
                table1.MaNhanVien =(cboNguoiGiaoNhan.EditValue==null)?"": cboNguoiGiaoNhan.EditValue.ToString().Trim();
                table1.SoFile = lblSoFile.Text;
                client.BangKeCP_Them(table1);
                int id = client.Top1_IDCP();
                //bang chi phi HQ
                if (gridView1.RowCount > 0)
                    gridView1.AddNewRow();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "MaChiPhi") != null)
                    {
                        ServiceReference1.BangLietKeCP_ChiTiet table2 = new ServiceReference1.BangLietKeCP_ChiTiet();
                        table2.IDLoHang = _IDLoHang;
                        table2.MaChiPhi_HQ = gridView1.GetRowCellValue(i, "MaChiPhi").ToString();
                        table2.SoTien_HQ = float.Parse(gridView1.GetRowCellValue(i, "SoTien").ToString());
                        table2.GhiChu_HQ = gridView1.GetRowCellValue(i, "GhiChu").ToString();
                        table2.IDCP = id;
                        client.BangKeCPCT_Them(table2);
                    }
                }
                //bang chi phi chi ho
                if (gridView2.RowCount > 0)
                    gridView2.AddNewRow();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "MaChiHo") != null)
                    {
                        ServiceReference1.BangLietKeCP_ChiTiet table2 = new ServiceReference1.BangLietKeCP_ChiTiet();
                        table2.IDLoHang = _IDLoHang;
                        table2.MaChiHo = gridView2.GetRowCellValue(i, "MaChiHo").ToString();
                        table2.SoTien_ChiHo = float.Parse(gridView2.GetRowCellValue(i, "SoTien").ToString());
                        table2.GhiChu_ChiHo = gridView2.GetRowCellValue(i, "GhiChu").ToString();
                        table2.SoHoaDon = gridView2.GetRowCellValue(i, "SoHoaDon").ToString();
                        table2.IDCP = id;
                        client.BangKeCPCT_Them(table2);
                    }
                }
                if(ThemMoi==1)
                {
                    ServiceReference1.BangLietKeCP_BoSung p = new ServiceReference1.BangLietKeCP_BoSung();
                    p.IDLoHang = _IDLoHang;
                    p.IDCP = id;
                    p.ThoiGianTao = table1.NgayTaoBangKe;
                    p.NguoiTao = table1.NguoiTaoBangKe;
                   
                    client.BangKeCP_BoSUNG_Them(p);
                }    
                this.Close();
           // }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboNguoiGiaoNhan.EditValue != null)
                ThemBangKe(1);
            else
                MessageBox.Show("Lô hàng này chưa có người giao nhận. Vui lòng cập nhật thông tin file!");

        }
    }
}