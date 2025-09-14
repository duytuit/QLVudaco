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
    public partial class ucBangTamThu : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTamThu()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
        }
        
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {

            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboNhanVien.Properties.DataSource = client.dsNhanVien();
            btnXem_Click(sender, e);
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        DataTable dtBangKeFull = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            string _Tk = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString().Trim();
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    DataTable dt = client.DanhSachTamThu(Ngay1, Ngay2, _Tk);
                    gridChuaTaoTamThu.DataSource = dt;
                    //
                    DataTable dt1 = client.DanhSachTamThu_DaTao_Tren(Ngay1, Ngay2, _Tk);
                    gridControl2.DataSource = dt1;
                    //
                    DataTable dt2 = client.DanhSachTamThu_DaTao_Duoi(Ngay1, Ngay2, _Tk);
                    gridControl3.DataSource = dt2;
            }
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //Form frm = new Forms.frmThemPhieuCuoc();
            //frm.ShowDialog();
            //btnXem_Click(sender, e);
        }
        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            //int _id = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
            //bool _XacNhanHoanUng = (gridView1.GetFocusedRowCellValue("XacNhanHoanUng") == null) ? false : bool.Parse(gridView1.GetFocusedRowCellValue("XacNhanHoanUng").ToString());
            //if (_XacNhanHoanUng == true)
            //    MessageBox.Show("Admin đã xác nhận nên bạn không thể sửa được nữa!");
            //else
            //{
            //    Forms.frmBangKeChiPhi frm = new Forms.frmBangKeChiPhi(_id, 1);
            //    frm.ShowDialog();
            //    btnXem_Click(sender, e);
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    bool _check = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                    if (_check)
                    {
                        int _IDPhieuCuoc = int.Parse(gridView2.GetRowCellValue(i, "IDPhieuCuoc").ToString().Trim());
                        client.PhieuTamThu_Xoa(_IDPhieuCuoc);
                    }

                }
                btnXem_Click(sender, e);

            }
        }
        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDCP = int.Parse(gridView1.GetFocusedRowCellValue("IDCP").ToString().Trim());
            string _Bang = gridView1.GetFocusedRowCellValue("Bang").ToString().Trim().Trim();
            string _Tk = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString().Trim();
            Form frm = new frmThemPhieuTamThu(_IDCP,0, _Bang, _Tk);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

       

        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            int _IDPhieuCuoc = int.Parse(gridView2.GetFocusedRowCellValue("IDPhieuCuoc").ToString().Trim());
            string _Bang = gridView2.GetFocusedRowCellValue("Bang").ToString().Trim().Trim();
            Form frm = new frmThemPhieuTamThu(_IDPhieuCuoc, 1, _Bang);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                int index = e.RowHandle;
                if (index >= 0)
                {
                    bool _chk =bool.Parse( gridView2.GetRowCellValue(index, "DaXacNhan").ToString().Trim());
                    if (_chk)
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
            //string[] arr1 = dtpTuNgay.Text.Split('/');
            //string[] arr2 = dtpDenNgay.Text.Split('/');
            //if (arr1.Length >= 3 && arr2.Length >= 3)
            //{
            //    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
            //    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
            //    DataTable dt = new DataTable();
            //    string keyword = "";
            //    for (int i = 0; i < gridView2.RowCount; i++)
            //    {
            //        bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
            //        if (isCheck)
            //            keyword +=  gridView2.GetRowCellValue(i, "SoFile").ToString().Trim() + ",";
            //    }
            //    string _ma = (cboNhanVien.EditValue == null) ? "" : cboNhanVien.EditValue.ToString().Trim();
            //    if (_ma == "")
            //        dt = client.BangKe_PhieuHoanUng(Ngay1, Ngay2, keyword);
            //    else
            //        dt = client.BangKe_PhieuHoanUng_NguoiTaoBangKe(Ngay1, Ngay2, _ma, keyword);
                
            //    if (keyword != "")
            //    {
                   

            //        string _tg = string.Format("( Từ ngày {0} đến ngày {1} )", Ngay1.ToString("dd/MM/yyyy"), Ngay2.ToString("dd/MM/yyyy"));
            //        reports.rpt_GiayHoanUng rpt = new reports.rpt_GiayHoanUng(_tg);
            //        rpt.DataSource = dt;
            //        rpt.DataMember = "xem";
            //        rpt.ShowPreview();
            //    }
            //    else
            //        MessageBox.Show("Vui lòng chọn Số file cần xuát!");
            //}
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (frmMain._TK.ToLower() != "admin")
            //    MessageBox.Show("Bạn không có quyền thao tác!");
            //else
            //{
            //    for (int i = 0; i < gridView2.RowCount; i++)
            //    {
            //        bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
            //        if (isCheck)
            //        {
            //            int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
            //           client.BangKeChiPhi_XacNhanHoanUng(_IDCP);
            //        }
            //    }
            //    btnXem_Click(sender, e);
            //}
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //for (int i = 0; i < gridView2.RowCount; i++)
            //{
            //    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
            //    if (isCheck)
            //    {
            //        int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
            //        client.BangKeChiPhi_XacNhanHoanUng_Huy_NhanVien(_IDCP);
            //    }
            //}
            //btnXem_Click(sender, e);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //amdin da hoan ung
            DataView view = dtBangKeFull.Copy().DefaultView;
            view.RowFilter = "[XacNhanHoanUng]=1";
            gridControl2.DataSource = view.ToTable();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////admin chua hoan ung
            //DataView view = dtBangKeFull.Copy().DefaultView;
            //view.RowFilter = "[XacNhanHoanUng]=0";
            //gridControl2.DataSource = view.ToTable();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void btnThemBangKe_Click(object sender, EventArgs e)
        {
            Forms.frmBangKeChiPhi frm = new frmBangKeChiPhi();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

       

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thu chi tieng mat
            //string[] arr = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            //string _SoChungTu_Chi = "", _SoChungTu_Thu = "";
           
          
            //double Tong_Chi = 0, TongThu = 0;
            //ServiceReference1.PhieuChi p1 = new ServiceReference1.PhieuChi();
            //ServiceReference1.PhieuThu p2 = new ServiceReference1.PhieuThu();
            //List<ServiceReference1.PhieuChi_CT> List_p1_CT = new List<ServiceReference1.PhieuChi_CT>();
            //List<ServiceReference1.PhieuThu_CT> List_p2_CT = new List<ServiceReference1.PhieuThu_CT>();
            //double Tong = 0;
            //for (int i = 0; i < gridView2.RowCount; i++)
            //{
            //    int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
            //    bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "XacNhanHoangUngNhanVien").ToString());
            //    bool _Chon = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
            //    double _ConLai = double.Parse(gridView2.GetRowCellValue(i, "ConLai").ToString());
            //    string _SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
            //    if (_Chon)
            //    {
            //        var table = client.BangLietKeCP_TheoIDCP(_IDCP);
            //        foreach (var item in table)
            //        {
            //            bool adminhoanung = (item.XacNhanHoanUng == null) ? false : item.XacNhanHoanUng.Value;
            //            bool nhanvienHoangUng = (item.XacNhanHoangUngNhanVien == null) ? false : item.XacNhanHoangUngNhanVien.Value;
            //            if (adminhoanung == false && nhanvienHoangUng == true)//chi lay nhung lo hang ma admin chua xac nhan hoan ung+nhan vien da xac nhan!
            //                    Tong += _ConLai;
            //        }
            //    }
            //}
            //if(Tong>0)//tao phieu thu
            //{
            //    #region phieu thu
            //    frmQuy_ThuHoanUng frm1 = new frmQuy_ThuHoanUng(Tong);
            //        frm1.ShowDialog();
            //        ServiceReference1.PhieuThu p = new ServiceReference1.PhieuThu();
            //        p.DienGiai = frmCongNoKH_CT._DienGiai;
            //        p.LyDoThu = "Thu hoàn ứng giao nhận";
            //        p.MaThu = "001";
            //        p.MaQuy = frmCongNoKH_CT._MaQuy;
            //        DateTime Ngay1 = frmCongNoKH_CT._Ngay;
            //        p.NgayHachToan = Ngay1;
            //        p.NguoiNhan = frmMain._HoTen;
            //        p.NguoiTao = frmMain._TK;
            //        arr = frmCongNoKH_CT._Ngay.ToString("dd/MM/yyyy").Split('/');
            //        p.SoChungTu = client.TaoSoChungTu_Thu(arr);
            //    _SoChungTu_Thu = p.SoChungTu;
            //        p.SoHoaDon = "";
            //        p.ThoiGianTao = frmCongNoKH_CT._Ngay;
            //        p.HinhThucTT = frmCongNoKH_CT._HinhThucTT;
            //        p.SoTK = frmCongNoKH_CT._SotK;
            //        p.TenNganHang = frmCongNoKH_CT._TenNganHang;
            //        p.ChiNhanh = frmCongNoKH_CT._ChiNhanh;
            //        p.ChuTaiKhoan = frmCongNoKH_CT._ChuTK;
            //       client.DanhSachPhieuThu_Them(p);
            //        //ct
            //        for (int i = 0; i < gridView2.RowCount; i++)
            //        {
            //        int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
            //        bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
            //        double _ConLai = double.Parse(gridView2.GetRowCellValue(i, "ConLai").ToString());
            //        string _SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
            //        if (isCheck)
            //        {
            //            var table = client.BangLietKeCP_TheoIDCP(_IDCP);
            //            foreach (var item in table)
            //            {
            //                bool adminhoanung = (item.XacNhanHoanUng == null) ? false : item.XacNhanHoanUng.Value;
            //                bool nhanvienHoangUng = (item.XacNhanHoangUngNhanVien == null) ? false : item.XacNhanHoangUngNhanVien.Value;
            //                if (adminhoanung == false && nhanvienHoangUng == true)//chi lay nhung lo hang ma admin chua xac nhan hoan ung+nhan vien da xac nhan!
            //                {
                               
            //                        TongThu += _ConLai;
            //                        ServiceReference1.PhieuThu_CT p2_CT = new ServiceReference1.PhieuThu_CT();
            //                        p2_CT.SoChungTu = p.SoChungTu;
            //                        p2_CT.IDCP = _IDCP;
            //                        p2_CT.SoFile = _SoFile;
            //                        p2_CT.MaNhanVien = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
            //                        p2_CT.SoTien = _ConLai;
            //                        p2_CT.DoiTuong = "NV";
            //                        p2_CT.MaDoiTuong = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
            //                        p2_CT.TenDoiTuong = gridView2.GetRowCellValue(i, "TenGiaoNhan").ToString();
            //                        var t1 = client.dsKH_MaKH(p2_CT.MaDoiTuong);
            //                        foreach (var item1 in t1)
            //                        {
            //                            p2_CT.DiaChi = item1.DiaChi;
            //                        }
            //                        p2_CT.VAT = 0;
            //                        p2_CT.ThanhTien = _ConLai;
            //                        p2_CT.GhiChu = "";
            //                      p2_CT.Tien_DuyetUng = (gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim());
            //                      //  List_p2_CT.Add(p2_CT);
            //                   client.DanhSachPhieuThu_CT_Them(p2_CT);
            //                    client.BangKeChiPhi_XacNhanHoanUng(_IDCP);

            //                }
            //            }
            //        }
            //    }
            //    //in phieu thu
            //    if (frmCongNoKH_CT._In == 1)
            //    {
            //        string _soChungTu = _SoChungTu_Thu;
            //        DateTime _NgayHachToan = Ngay1;
            //        DataTable dt = client.DanhSachPhieuThu_CT_TheoSoChungTu(_soChungTu);
            //        reports.rpt_PhieuThuHoanUng rpt = new reports.rpt_PhieuThuHoanUng(dt, _NgayHachToan);
            //        rpt.ShowPreview();
            //    }
            //    #endregion

            //}
            //else//tao phieu chi
            //{
            //    #region phieu chi
            //    frmQuy_ChiHoanUng frm1 = new frmQuy_ChiHoanUng(Tong);
            //    frm1.ShowDialog();
            //    ServiceReference1.PhieuChi p = new ServiceReference1.PhieuChi();
            //    p.DienGiai = frmCongNoKH_CT._DienGiai;
            //    p.LyDoChi = "Chi hoàn ứng giao nhận";
            //    p.MaChi = "001";
            //    p.MaQuy = frmCongNoKH_CT._MaQuy;
            //    DateTime Ngay1 = frmCongNoKH_CT._Ngay;
            //    p.NgayHachToan = Ngay1;
            //    p.NguoiNhan = frmMain._HoTen;
            //    p.NguoiTao = frmMain._TK;
            //    arr = frmCongNoKH_CT._Ngay.ToString("dd/MM/yyyy").Split('/');
            //    p.SoChungTu = client.TaoSoChungTu(arr);
            //    _SoChungTu_Thu = p.SoChungTu;
            //    p.SoHoaDon = "";
            //    p.ThoiGianTao = frmCongNoKH_CT._Ngay;
            //    p.HinhThucTT = frmCongNoKH_CT._HinhThucTT;
            //    p.SoTK = frmCongNoKH_CT._SotK;
            //    p.TenNganHang = frmCongNoKH_CT._TenNganHang;
            //    p.ChiNhanh = frmCongNoKH_CT._ChiNhanh;
            //    p.ChuTaiKhoan = frmCongNoKH_CT._ChuTK;
            //    client.DanhSachPhieuChi_Them(p);
            //    //ct
            //    for (int i = 0; i < gridView2.RowCount; i++)
            //    {
            //        int _IDCP = int.Parse(gridView2.GetRowCellValue(i, "IDCP").ToString());
            //        bool isCheck = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
            //        double _ConLai = double.Parse(gridView2.GetRowCellValue(i, "ConLai").ToString());
            //        string _SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
            //        if (isCheck)
            //        {
            //            var table = client.BangLietKeCP_TheoIDCP(_IDCP);
            //            foreach (var item in table)
            //            {
            //                bool adminhoanung = (item.XacNhanHoanUng == null) ? false : item.XacNhanHoanUng.Value;
            //                bool nhanvienHoangUng = (item.XacNhanHoangUngNhanVien == null) ? false : item.XacNhanHoangUngNhanVien.Value;
            //                if (adminhoanung == false && nhanvienHoangUng == true)//chi lay nhung lo hang ma admin chua xac nhan hoan ung+nhan vien da xac nhan!
            //                {

            //                    ServiceReference1.PhieuChi_CT p2_CT = new ServiceReference1.PhieuChi_CT();
            //                    p2_CT.SoChungTu = p.SoChungTu;
            //                    p2_CT.IDCP = _IDCP;
            //                    p2_CT.SoFile = _SoFile;
            //                    p2_CT.MaNhanVien = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
            //                    p2_CT.SoTien = _ConLai;
            //                    p2_CT.DoiTuong = "NV";
            //                    p2_CT.MaDoiTuong = gridView2.GetRowCellValue(i, "MaNhanVien").ToString();
            //                    p2_CT.TenDoiTuong = gridView2.GetRowCellValue(i, "TenGiaoNhan").ToString();
            //                    var t1 = client.dsKH_MaKH(p2_CT.MaDoiTuong);
            //                    foreach (var item1 in t1)
            //                    {
            //                        p2_CT.DiaChi = item1.DiaChi;
            //                    }
            //                    p2_CT.VAT = 0;
            //                    p2_CT.ThanhTien = _ConLai;
            //                    p2_CT.GhiChu = "";
            //                    p2_CT.Tien_DuyetUng = (gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "DuyetUng").ToString().Trim());
            //                    //  List_p2_CT.Add(p2_CT);
            //                    client.DanhSachPhieuChi_CT_Them(p2_CT);
            //                    client.BangKeChiPhi_XacNhanHoanUng(_IDCP);

            //                }
            //            }
            //        }
            //    }
            //    //in phieu chi
            //    if (frmCongNoKH_CT._In == 1)
            //    {
            //        string _soChungTu = _SoChungTu_Thu;
            //        DateTime _NgayHachToan = Ngay1;
            //        DataTable dt = client.DanhSachPhieuChi_CT_TheoSoChungTu(_soChungTu);
            //        reports.rpt_PhieuChiHoanUng rpt = new reports.rpt_PhieuChiHoanUng(dt, _NgayHachToan);
            //        rpt.ShowPreview();
            //    }
            //    #endregion
            //}
           
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thu tien bang tien ngan hang

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //da nhan phieu cuoc
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                bool _Check = bool.Parse(gridView2.GetRowCellValue(i,"Chon").ToString());
                if (_Check)
                {
                    int _IDPhieuCuoc = int.Parse(gridView2.GetRowCellValue(i, "IDPhieuCuoc").ToString());
                    ServiceReference1.PhieuCuoc table = new ServiceReference1.PhieuCuoc();
                    table.IDPhieuCuoc = _IDPhieuCuoc;
                    table.SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
                    table.MaKhachHang = gridView2.GetRowCellValue(i, "MaKhachHang").ToString();
                    table.NgayTao = DateTime.Parse(gridView2.GetRowCellValue(i, "NgayTao").ToString());
                    table.TienCuoc = double.Parse(gridView2.GetRowCellValue(i, "TienCuoc").ToString());
                    table.NguoiGiaoNhan = gridView2.GetRowCellValue(i, "MaNhanVien").ToString().Trim();
                    table.GhiChu = gridView2.GetRowCellValue(i, "GhiChu").ToString().Trim();
                    table.DaXacNhan = true;
                    table.ThoiGianXacNhan = DateTime.Now;
                    table.NguoiXacNhan = frmMain._TK;
                    client.PhieuCuoc_CapNhat(table);
                   
                }
            }
            btnXem_Click(sender, e);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //chua nhan phieu cuoc
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                bool _Check = bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString());
                if (_Check)
                {
                    int _IDPhieuCuoc = int.Parse(gridView2.GetRowCellValue(i, "IDPhieuCuoc").ToString());
                    ServiceReference1.PhieuCuoc table = new ServiceReference1.PhieuCuoc();
                    table.IDPhieuCuoc = _IDPhieuCuoc;
                    table.SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString();
                    table.MaKhachHang = gridView2.GetRowCellValue(i, "MaKhachHang").ToString();
                    table.NgayTao = DateTime.Parse(gridView2.GetRowCellValue(i, "NgayTao").ToString());
                    table.TienCuoc = double.Parse(gridView2.GetRowCellValue(i, "TienCuoc").ToString());
                    table.NguoiGiaoNhan = gridView2.GetRowCellValue(i, "MaNhanVien").ToString().Trim();
                    table.GhiChu = gridView2.GetRowCellValue(i, "GhiChu").ToString().Trim();
                    table.DaXacNhan = false;
                    table.ThoiGianXacNhan = null;
                    table.NguoiXacNhan = "";
                    client.PhieuCuoc_CapNhat(table);
                  
                }
            }
            btnXem_Click(sender, e);
        }
    }
}
