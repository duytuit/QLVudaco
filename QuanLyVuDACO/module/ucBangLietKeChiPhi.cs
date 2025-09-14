using DevExpress.XtraEditors;
using Quản_lý_vudaco.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Quản_lý_vudaco.module
{
    public partial class ucBangLietKeChiPhi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangLietKeChiPhi()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
        }
        
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }

        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {

            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (frmMain._TK.ToLower()=="admin")
            {
                cboNhanVien.Properties.DataSource = client.DsTaiKhoan();
                mn1.Visible = true;
                mn2.Visible = false;
            }    
            else
            {
                cboNhanVien.Properties.DataSource = client.DsTaiKhoan_TaiKhoan(frmMain._TK);
                cboNhanVien.EditValue = frmMain._TK;
                mn1.Visible = false;
                mn2.Visible = true;
            }
          //  btnXem_Click(sender, e);
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        DataTable dtBangKeFull = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (cboNhanVien.EditValue == null)
                MessageBox.Show("Vui lòng chọn 1 tài khoản để xem!");
            else
            {
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    DataTable dt = client.BangFileChuaTaoBangKeChiPhi_TheoTK(Ngay1, Ngay2, cboNhanVien.EditValue.ToString());
                    DataTable dtt = dt.Copy();

                    DataTable dt1 = client.BangKe(Ngay1, Ngay2);
                    DataTable dt2 = dt1.Copy();

                    string _ma = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString().Trim();
                    DataView view1 = dt.Copy().DefaultView;
                    if (frmMain._TK.ToLower().Trim() != "admin")
                    {
                        view1.RowFilter = "[TenGiaoNhan] like '%" + cboNhanVien.Text + "%'";
                        dt = view1.ToTable();

                        DataView view = dt1.Copy().DefaultView;
                        view.RowFilter = "NguoiTaoBangKe='" + _ma + "'";


                        dt1 = view.ToTable();
                    }
                    else
                    {
                        if (cboNhanVien.EditValue != null)
                        {
                            DataView view = dt1.Copy().DefaultView;
                            view.RowFilter = "NguoiTaoBangKe='" + _ma + "'";
                            dt1 = view.ToTable();
                            view1.RowFilter = "[TenGiaoNhan] like '%" + cboNhanVien.Text + "%'";
                            dt = view1.ToTable();
                        }
                        else
                        {
                            dt1 = dt2;
                            dt = dtt;
                        }

                    }


                    grid_ChuaTaoBangKe.DataSource = dt;

                    dtBangKeFull = dt1.Copy();
                    grid_DaTaoBangKe.DataSource = dt1;
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm =new Forms.frmBangTheoDoiSoFile();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _id = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
            bool _XacNhanHoanUng = (gridView1.GetFocusedRowCellValue("XacNhanHoanUng")==null)?false:bool.Parse(gridView1.GetFocusedRowCellValue("XacNhanHoanUng").ToString());
            if (_XacNhanHoanUng == true)
                MessageBox.Show("Admin đã xác nhận nên bạn không thể sửa được nữa!");
            else
            {
                Forms.frmBangKeChiPhi frm = new Forms.frmBangKeChiPhi(_id, 1);
                frm.ShowDialog();
                btnXem_Click(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (frmMain._TK != "admin")
                MessageBox.Show("Chỉ Admin mới có quyền này");
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  //  VudacoEntities context = new VudacoEntities();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string _check = gridView1.GetRowCellValue(i, "Chon").ToString();
                        if (_check == "True")
                        {
                            int _IDLoHang = int.Parse(gridView1.GetRowCellValue(i, "IDLoHang").ToString().Trim());
                            //ThongTinFile table = context.ThongTinFile.Single(p => p.IDLoHang == _IDLoHang);
                            //context.ThongTinFile.Remove(table);
                            //context.SaveChanges();
                            client.XoaThongTinFile(_IDLoHang);
                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            Form frm = new frmBangKeChiPhi(_IDLoHang);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
           // VudacoEntities context = new VudacoEntities();
            //xoa bang ke da tao
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _idLoHang=int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString());
                int _id = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
                bool check = client.BangKeChiPhi_KiemTraFileGia(_idLoHang);
                if (check)
                    MessageBox.Show("Bảng kê chi phí này có dữ liệu liên quan đến file giá, vui lòng xóa file giá trước để tiếp tục!");
                else
                {
                    try
                    {
                        client.XoaBangKe_IDCP(_id);
                        btnXem_Click(sender, e);
                    }
                    catch (Exception)
                    {

                        btnXem_Click(sender, e);
                    }
                   
                }
            }
        }
      
        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            //int _idLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString());
            int _id = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
            bool isCheck_ThuCN = client.KiemTraPhieuThuTheo_IDCP(_id);
            if (isCheck_ThuCN)
                MessageBox.Show("IDCP này đã tạo phiếu thu công nợ!");
            else
            {
                bool _XacNhanHoanUng = (gridView2.GetFocusedRowCellValue("XacNhanHoanUng") == null) ? false : bool.Parse(gridView2.GetFocusedRowCellValue("XacNhanHoanUng").ToString());
                if (_XacNhanHoanUng == true)
                    MessageBox.Show("Admin đã xác nhận nên bạn không thể sửa được nữa!");
                else
                {
                    Form frm = new frmBangKeChiPhi(_id, 1);
                    frm.ShowDialog();
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            int _IDCP = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
            int IDLo = client.IDLoHang_Theo_IDCP(_IDCP);
            int _idLoHang = IDLo;
            DataTable dt = client.DsThongTinFile_Full_TheoIDLoHang(_idLoHang);
            DataTable dt1 = new DataTable("chitiet");
            dt1.Columns.Add("MaChiPhi");
            dt1.Columns.Add("TenChiPhi");
            dt1.Columns.Add("SoTien", typeof(double));
            dt1.Columns.Add("ConLai", typeof(double));
            dt1.Columns.Add("GhiChu");
           // dt1.Columns.Add("IDLoHang", typeof(int));
            dt1.Columns.Add("TenNhom");
            dt1.Columns.Add("MaNhom",typeof(int));
            dt1.Columns.Add("LinkTaiHoaDon");
            dt1.Columns.Add("MaTraCuu");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if(dt.Columns[i].ColumnName== "DuyetUng")
                    dt1.Columns.Add(dt.Columns[i].ColumnName,typeof(double));
                else
                dt1.Columns.Add(dt.Columns[i].ColumnName);
            }
            //DataTable dt11 = client.BangKeCP_ChiTiet_HQ(_idLoHang);
            DataTable dt11 = client.BangKeCP_ChiTiet_HQ_IDCP(_IDCP);
            double _Tong = 0;
            for (int i = 0; i < dt11.Rows.Count; i++)
            {
                DataRow row = dt1.NewRow();
                row["MaChiPhi"] = dt11.Rows[i]["MaChiPhi"].ToString().Trim();
                row["TenChiPhi"] = dt11.Rows[i]["TenChiPhi"].ToString().Trim();
                row["SoTien"] = dt11.Rows[i]["SoTien"].ToString().Trim();
                _Tong += double.Parse(dt11.Rows[i]["SoTien"].ToString().Trim());
                row["GhiChu"] = dt11.Rows[i]["GhiChu"].ToString().Trim();
                row["TenNhom"] = "CHI PHÍ HẢI QUAN";
                row["MaNhom"] = 1;
                dt1.Rows.Add(row);
            }
            //
            var t12 = client.BangKe_TheoIDLoHang(_idLoHang);
            float _PhiDK = 0;
            foreach (var item in t12)
            {
                _PhiDK= item.PhiDangKy.Value;
            }
            _Tong += _PhiDK;
            DataRow row12 = dt1.NewRow();
            row12["MaChiPhi"] = "";
            row12["TenChiPhi"] = "Phí đăng ký kiểm tra chất lượng";
            row12["SoTien"] = _PhiDK;
            row12["GhiChu"] = "";
            row12["TenNhom"] = "PHÍ ĐĂNG KÝ KIỂM TRA CHẤT LƯỢNG";
            row12["MaNhom"] = 2;
            dt1.Rows.Add(row12);
            //
           // DataTable dt13 = client.BangKeCP_ChiTiet_ChiHo(_idLoHang);
            DataTable dt13 = client.BangKeCP_ChiTiet_ChiHo_IDCP(_IDCP);
            for (int i = 0; i < dt13.Rows.Count; i++)
            {
                DataRow row = dt1.NewRow();
                row["MaChiPhi"] = dt13.Rows[i]["MaChiHo"].ToString().Trim();
                row["TenChiPhi"] = dt13.Rows[i]["TenChiHo"].ToString().Trim();
                row["SoTien"] = dt13.Rows[i]["SoTien"].ToString().Trim();
                _Tong += double.Parse(dt13.Rows[i]["SoTien"].ToString().Trim());
                row["GhiChu"] = dt13.Rows[i]["GhiChu"].ToString().Trim();
                row["TenNhom"] = "PHÍ CHI HỘ";
                row["MaNhom"] = 3;
                row["LinkTaiHoaDon"] = dt13.Rows[i]["LinkTaiHoaDon"].ToString().Trim();
                row["MaTraCuu"] = dt13.Rows[i]["MaTraCuu"].ToString().Trim();
                dt1.Rows.Add(row);
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dt1.Rows[i][dt.Columns[j].ColumnName] = dt.Rows[0][dt.Columns[j].ColumnName].ToString().Trim();
                    }
                    dt1.Rows[i]["ConLai"] = _Tong - double.Parse(dt1.Rows[0]["DuyetUng"].ToString());
                }
            }
            reports.rpt_BangKe rpt = new reports.rpt_BangKe(dt1);
            rpt.ShowPreview();
        }

        private void btnHoanUng_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHuyHoanUng_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                int index = e.RowHandle;
                if(index>=0)
                {
                    string _Ngay = gridView2.GetRowCellValue(index, "NgayHoanUng").ToString().Trim();
                    if (_Ngay != "")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }    
            }
            catch (Exception)
            {

            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3)
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                DataTable dt = new DataTable();
                string keyword = "";
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                    if (isCheck)
                        keyword +=  gridView2.GetRowCellValue(i, "SoFile").ToString().Trim() + ",";
                }
                string _ma = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString().Trim();
                if (_ma == "")
                    dt = client.BangKe_PhieuHoanUng(Ngay1, Ngay2, keyword);
                else
                    dt = client.BangKe_PhieuHoanUng_NguoiTaoBangKe(Ngay1, Ngay2, _ma, keyword);
                
                if (keyword != "")
                {
                   

                    string _tg = string.Format("( Từ ngày {0} đến ngày {1} )", Ngay1.ToString("dd/MM/yyyy"), Ngay2.ToString("dd/MM/yyyy"));
                    reports.rpt_GiayHoanUng rpt = new reports.rpt_GiayHoanUng(_tg);
                    rpt.DataSource = dt;
                    rpt.DataMember = "xem";
                    rpt.ShowPreview();
                }
                else
                    MessageBox.Show("Vui lòng chọn Số file cần xuát!");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMain._TK.ToLower() != "admin")
                MessageBox.Show("Bạn không có quyền thao tác!");
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                    //bool _Duyet = bool.Parse(gridView2.GetRowCellValue(i, "Duyet").ToString());
                    //if (_Duyet)
                    //{
                        if (isCheck)
                        {
                            int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                            client.BangKeChiPhi_XacNhanHoanUng(_IDCP);
                        }
                    //}
                   // else
                     //   MessageBox.Show("Bảng kê này cần phải được duyệt trước!");
                }
                btnXem_Click(sender, e);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMain._TK.ToLower() != "admin")
                MessageBox.Show("Bạn không có quyền thao tác!");
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                    //bool _Duyet = bool.Parse(gridView2.GetRowCellValue(i, "Duyet").ToString());
                    //if (_Duyet)
                    //{
                        if (isCheck)
                        {
                            int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                            client.BangKeChiPhi_XacNhanHoanUng_Huy(_IDCP);
                        }
                    //}
                    //else
                    //    MessageBox.Show("Bảng kê này cần phải được duyệt trước!");
                }
                btnXem_Click(sender, e);
            }
        }
        //nhan vien
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                if (isCheck)
                {
                    int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                    client.BangKeChiPhi_XacNhanHoanUng_NhanVien(_IDCP);
                }
            }
            btnXem_Click(sender, e);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                if (isCheck)
                {
                    int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                    client.BangKeChiPhi_XacNhanHoanUng_Huy_NhanVien(_IDCP);
                }
            }
            btnXem_Click(sender, e);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //amdin da hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            view.RowFilter = "[XacNhanHoanUng]=1";
            grid_DaTaoBangKe.DataSource = view.ToTable();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //admin chua hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            view.RowFilter = "[XacNhanHoanUng]=0";
            grid_DaTaoBangKe.DataSource = view.ToTable();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //admin all hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            grid_DaTaoBangKe.DataSource = view.ToTable();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //nv đa hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            view.RowFilter = "[XacNhanHoangUngNhanVien]=1";
            grid_DaTaoBangKe.DataSource = view.ToTable();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //nv chua hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            view.RowFilter = "[XacNhanHoangUngNhanVien]=0";
            grid_DaTaoBangKe.DataSource = view.ToTable();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //nv all hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            grid_DaTaoBangKe.DataSource = view.ToTable();
        }

        private void btnThemBangKe_Click(object sender, EventArgs e)
        {
            Forms.frmBangKeChiPhi frm = new frmBangKeChiPhi();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if(btnChon.Text=="All")
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, "Chon", true);
                }
                btnChon.Text = "OFF";
            }    
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, "Chon", false);
                }
                btnChon.Text = "All";
            }    
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thu chi tieng mat
            string[] arr = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            string _SoChungTu_Chi = "", _SoChungTu_Thu = "";

            double Tong_Chi = 0, TongThu = 0;
            ServiceReference1.PhieuChi p1 = new ServiceReference1.PhieuChi();
            ServiceReference1.PhieuThu p2 = new ServiceReference1.PhieuThu();
            List<ServiceReference1.PhieuChi_CT> List_p1_CT = new List<ServiceReference1.PhieuChi_CT>();
            List<ServiceReference1.PhieuThu_CT> List_p2_CT = new List<ServiceReference1.PhieuThu_CT>();
            double Tong = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "XacNhanHoangUngNhanVien").ToString());
                bool _Chon = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                double _ConLai = double.Parse(gridView2.GetRowCellValue(i, "ConLai").ToString());
                string _SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
                if (_Chon)
                {
                    var table = client.BangLietKeCP_TheoIDCP(_IDCP);
                    foreach (var item in table)
                    {
                        if (item.Duyet != null)
                        {
                            if (item.Duyet.Value == true)
                            {
                                bool adminhoanung = (item.XacNhanHoanUng == null) ? false : item.XacNhanHoanUng.Value;
                                bool nhanvienHoangUng = (item.XacNhanHoangUngNhanVien == null) ? false : item.XacNhanHoangUngNhanVien.Value;
                                if (adminhoanung == false && nhanvienHoangUng == true)//chi lay nhung lo hang ma admin chua xac nhan hoan ung+nhan vien da xac nhan!
                                    Tong += _ConLai;
                            }
                        }
                    }
                }
            }
            if(Tong>0)//tao phieu thu
            {
                #region phieu thu
                frmQuy_ThuHoanUng frm1 = new frmQuy_ThuHoanUng(Tong);
                    frm1.ShowDialog();
                    ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
                    p.DienGiai = frmCongNoKH_CT._DienGiai;
                    p.LyDoThu = "Thu hoàn ứng giao nhận";
                    p.MaThu = "001";
                    p.MaQuy = frmCongNoKH_CT._MaQuy;
                    DateTime Ngay1 = frmCongNoKH_CT._Ngay;
                    p.NgayHachToan = Ngay1;
                    p.NguoiNhan = frmMain._HoTen;
                    p.NguoiTao = frmMain._TK;
                    arr = frmCongNoKH_CT._Ngay.ToString("dd/MM/yyyy").Split('/');
                    p.SoChungTu = client.TaoSoChungTu_Thu(arr);
                _SoChungTu_Thu = p.SoChungTu;
                    p.SoHoaDon = "";
                    p.ThoiGianTao = frmCongNoKH_CT._Ngay;
                    p.HinhThucTT = frmCongNoKH_CT._HinhThucTT;
                    p.SoTK = frmCongNoKH_CT._SotK;
                    p.TenNganHang = frmCongNoKH_CT._TenNganHang;
                    p.ChiNhanh = frmCongNoKH_CT._ChiNhanh;
                    p.ChuTaiKhoan = frmCongNoKH_CT._ChuTK;
                   client.DanhSachPhieuThu_Them(p);
                    //ct
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                    int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                    double _ConLai = double.Parse(gridView2.GetRowCellValue(i, "ConLai").ToString());
                    string _SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
                    if (isCheck)
                    {
                     
                        client.BangKeChiPhi_XacNhanHoanUng(_IDCP);
                        var table = client.BangLietKeCP_TheoIDCP(_IDCP);
                        foreach (var item in table)
                        {
                            bool adminhoanung = (item.XacNhanHoanUng == null) ? false : item.XacNhanHoanUng.Value;
                            bool nhanvienHoangUng = (item.XacNhanHoangUngNhanVien == null) ? false : item.XacNhanHoangUngNhanVien.Value;
                            if (adminhoanung == false && nhanvienHoangUng == true)//chi lay nhung lo hang ma admin chua xac nhan hoan ung+nhan vien da xac nhan!
                            {
                               
                                    TongThu += _ConLai;
                                    ServiceReference1.PhieuThu_CT p2_CT = new ServiceReference1.PhieuThu_CT();
                                    p2_CT.SoChungTu = p.SoChungTu;
                                    p2_CT.IDCP = _IDCP;
                                    p2_CT.SoFile = _SoFile;
                                    p2_CT.MaNhanVien = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
                                    p2_CT.SoTien = _ConLai;
                                    p2_CT.DoiTuong = "NV";
                                    p2_CT.MaDoiTuong = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
                                    p2_CT.TenDoiTuong = gridView2.GetRowCellValue(i, "TenGiaoNhan").ToString();
                                    var t1 = client.dsKH_MaKH(p2_CT.MaDoiTuong);
                                    foreach (var item1 in t1)
                                    {
                                        p2_CT.DiaChi = item1.DiaChi;
                                    }
                                    p2_CT.VAT = 0;
                                    p2_CT.ThanhTien = _ConLai;
                                    p2_CT.GhiChu = "";
                                  p2_CT.Tien_DuyetUng = (gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim());
                                  //  List_p2_CT.Add(p2_CT);
                               client.DanhSachPhieuThu_CT_Them(p2_CT);
                                client.BangKeChiPhi_XacNhanHoanUng(_IDCP);

                            }
                        }
                    }
                }
                //in phieu thu
                if (frmCongNoKH_CT._In == 1)
                {
                    string _soChungTu = _SoChungTu_Thu;
                    DateTime _NgayHachToan = Ngay1;
                    DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
                    reports.rpt_PhieuThuHoanUng rpt = new reports.rpt_PhieuThuHoanUng(dt, _NgayHachToan);
                    rpt.ShowPreview();
                }
                #endregion

            }
            else//tao phieu chi
            {
                #region phieu chi
                frmQuy_ChiHoanUng frm1 = new frmQuy_ChiHoanUng(Tong);
                frm1.ShowDialog();
                ServiceReference1.PhieuChi p = new ServiceReference1.PhieuChi();
                p.DienGiai = frmCongNoKH_CT._DienGiai;
                p.LyDoChi = "Chi hoàn ứng giao nhận";
                p.MaChi = "001";
                p.MaQuy = frmCongNoKH_CT._MaQuy;
                DateTime Ngay1 = frmCongNoKH_CT._Ngay;
                p.NgayHachToan = Ngay1;
                p.NguoiNhan = frmMain._HoTen;
                p.NguoiTao = frmMain._TK;
                arr = frmCongNoKH_CT._Ngay.ToString("dd/MM/yyyy").Split('/');
                p.SoChungTu = client.TaoSoChungTu(arr);
                _SoChungTu_Thu = p.SoChungTu;
                p.SoHoaDon = "";
                p.ThoiGianTao = frmCongNoKH_CT._Ngay;
                p.HinhThucTT = frmCongNoKH_CT._HinhThucTT;
                p.SoTK = frmCongNoKH_CT._SotK;
                p.TenNganHang = frmCongNoKH_CT._TenNganHang;
                p.ChiNhanh = frmCongNoKH_CT._ChiNhanh;
                p.ChuTaiKhoan = frmCongNoKH_CT._ChuTK;
                client.DanhSachPhieuChi_Them(p);
                //ct
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
                    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                    double _ConLai = double.Parse(gridView2.GetRowCellValue(i, "ConLai").ToString());
                    string _SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
                    if (isCheck)
                    {

                        client.BangKeChiPhi_XacNhanHoanUng(_IDCP);
                        var table = client.BangLietKeCP_TheoIDCP(_IDCP);
                        foreach (var item in table)
                        {
                            if (item.Duyet != null)
                            {
                                if (item.Duyet.Value == true)
                                {
                                    bool adminhoanung = (item.XacNhanHoanUng == null) ? false : item.XacNhanHoanUng.Value;
                                    bool nhanvienHoangUng = (item.XacNhanHoangUngNhanVien == null) ? false : item.XacNhanHoangUngNhanVien.Value;
                                    if (adminhoanung == false && nhanvienHoangUng == true)//chi lay nhung lo hang ma admin chua xac nhan hoan ung+nhan vien da xac nhan!
                                    {

                                        ServiceReference1.PhieuChi_CT p2_CT = new ServiceReference1.PhieuChi_CT();
                                        p2_CT.SoChungTu = p.SoChungTu;
                                        p2_CT.IDCP = _IDCP;
                                        p2_CT.SoFile = _SoFile;
                                        p2_CT.MaNhanVien = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
                                        p2_CT.SoTien = _ConLai;
                                        p2_CT.DoiTuong = "NV";
                                        p2_CT.MaDoiTuong = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
                                        p2_CT.TenDoiTuong = gridView2.GetRowCellValue(i, "TenGiaoNhan").ToString();
                                        var t1 = client.dsKH_MaKH(p2_CT.MaDoiTuong);
                                        foreach (var item1 in t1)
                                        {
                                            p2_CT.DiaChi = item1.DiaChi;
                                        }
                                        p2_CT.VAT = 0;
                                        p2_CT.ThanhTien = _ConLai;
                                        p2_CT.GhiChu = "";
                                        p2_CT.Tien_DuyetUng = (gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim());
                                        //  List_p2_CT.Add(p2_CT);
                                        client.DanhSachPhieuChi_CT_Them(p2_CT);
                                        client.BangKeChiPhi_XacNhanHoanUng(_IDCP);

                                    }
                                }
                            }
                        }
                    }
                }
                //in phieu chi
                if (frmCongNoKH_CT._In == 1)
                {
                    string _soChungTu = _SoChungTu_Thu;
                    DateTime _NgayHachToan = Ngay1;
                    DataTable dt = client.DanhSachPhieuChi_CT_TheoSoChungTu(_soChungTu);
                    reports.rpt_PhieuChiHoanUng rpt = new reports.rpt_PhieuChiHoanUng(dt, _NgayHachToan);
                    rpt.ShowPreview();
                }
                #endregion
            }
            btnXem_Click(sender, e);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thu tien bang tien ngan hang

        }

        private void gridView2_CustomUnboundColumnData_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
        }

        private void gridView1_CustomUnboundColumnData_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
        }
    }
}
