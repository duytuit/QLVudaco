using DevExpress.XtraEditors;
using Quản_lý_vudaco.services;
using Quản_lý_vudaco.services.common;
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
    public partial class frmDoiTruCongNo : DevExpress.XtraEditors.XtraForm
    {

        private static double _TongTienThu = 0;
        public frmDoiTruCongNo()
        {
            InitializeComponent();
            ColSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            clSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.Columns["SoThu_DichVu"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns["SoThu_ChiHo"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns["SoTien_BuTru"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns["TongThu"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView2.Columns["SoThu_DichVu"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView2.Columns["SoThu_ChiHo"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView2.Columns["SoTien_BuTru"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView2.Columns["TongThu"].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns["SoTien_BuTru"].OptionsColumn.AllowEdit = false;
            gridView2.Columns["SoTien_BuTru"].OptionsColumn.AllowEdit = false;
        }

        private void frmDoiTruCongNo_Load(object sender, EventArgs e)
        {
            dtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            using (var kh = new khachhang())
            {
                cboKH.Properties.DataSource = kh.GetAllkh().Where(x=>x.LaNhaCungCap);
            }
            lbTienHachToan.Text = _TongTienThu.ToString("#,##");

        }
        private void LoadData()
        {
            string makh = "";
            if (cboKH.Text == "")
                makh = "";
            else
                makh = (cboKH.EditValue == null) ? "" : cboKH.EditValue.ToString();
            using (var kh = new khachhang())
            {
                var _khachhang_ct = kh.CongNoChiTietKH(DateTime.MinValue, null, makh);
                var kh_dv_ch = _khachhang_ct.Where(x => new[] { 0 }.Contains(x.Type)).Select(x => new
                {
                    NgayHachToan = x.NgayHachToan,
                    LoaiXe_NCC = x.LoaiXe_NCC,
                    LoaiXe_KH = x.LoaiXe_KH,
                    MaDieuXe = x.MaDieuXe,
                    SoHoaDon = x.SoHoaDon,
                    TenSales = x.TenSales,
                    TenDichVu = x.TenDichVu,
                    DienGiai = x.DienGiai,
                    SoToKhai = x.SoToKhai,
                    SoBill = x.SoBill,
                    TuyenVC = x.TuyenVC,
                    NoiDung = x.NoiDung + x.TuyenVC,
                    MaKhachHang = x.MaKhachHang,
                    BienSoXe = x.BienSoXe,
                    GhiChu = x.GhiChu,
                    SoTien = (x.LaPhiChiHo == 0) ? x.SoTien : 0,
                    ThanhTienDV = (x.LaPhiChiHo == 0) ? x.ThanhTien : 0,
                    ThanhTienCH = (x.LaPhiChiHo == 1) ? x.ThanhTien : 0,
                    VAT = (x.LaPhiChiHo == 0) ? (x.VAT * x.SoTien) / 100 : 0,
                    LaPhiChiHo = x.LaPhiChiHo,
                    TongTien = x.TongTien,
                    SoLuong = x.SoLuong,
                    PhiCom = x.PhiCom,
                    Type = x.Type,
                    SoCont = x.SoCont,
                    ID = x.ID,
                    Key = x.Key,
                    SoFile = x.SoFile,
                    ThanhToanDV = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 0).Sum(y => y.ThanhTien),
                    ThanhToanCH = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 1).Sum(y => y.ThanhTien),
                    SoTien_BuTru = 0,
                    Chon = false
                })
                  .ToList() // chuyển sang bộ nhớ để có thể so sánh giá trị đã tính
                  .Where(x => (x.ThanhTienDV + x.ThanhTienCH) > (x.ThanhToanDV + x.ThanhToanCH))
                  .OrderBy(x => x.NgayHachToan)
                  .ToList();
                gridControl1.DataSource = Utility.ToDataTable(kh_dv_ch);
            }
            using (var ncc = new ncc())
            {
                var ncc_ct = ncc.CongNoChiTietNcc(DateTime.MinValue, null, makh);
                var ncc_dv_nh = ncc_ct.Where(x => new[] { 0, 3 }.Contains(x.Type)).Select(x => new
                {
                    NgayHachToan = x.NgayHachToan,
                    LoaiXe_NCC = x.LoaiXe_NCC,
                    MaDieuXe = x.MaDieuXe ?? x.SoFile,
                    SoToKhai = x.SoToKhai,
                    SoBill = x.SoBill,
                    NoiDung = x.NoiDung,
                    MaNhaCungCap = x.MaNhaCungCap,
                    BienSoXe = x.BienSoXe,
                    SoTien = (x.Type == 0) ? x.SoTien : 0,
                    VAT = (x.Type == 0) ? x.VAT : 0,
                    LaPhiChiHo = x.LaPhiChiHo,
                    TongTien = x.TongTien,
                    PhiCom = x.PhiCom,
                    Type = x.Type,
                    SoCont = x.SoCont,
                    Chon = x.Chon,
                    ID = x.ID,
                    Key = x.Key,
                    SoFile = x.SoFile,
                    ThanhTienDV = (x.Type == 0) ? x.ThanhTien : 0,
                    ThanhTienNH = (x.Type == 3) ? x.ThanhTien : 0,
                    ThanhToanDV = ncc_ct.Where(y => y.IDName == x.ID && y.KeyName == x.Key && y.Type == 2).Sum(y => y.ThanhTien),
                    ThanhToanNH = ncc_ct.Where(y => y.IDName == x.ID && y.KeyName == x.Key && y.Type == 1).Sum(y => y.ThanhTien),
                    SoTien_BuTru = 0,
                })
                  .ToList() // chuyển sang bộ nhớ để có thể so sánh giá trị đã tính
                  .Where(x => (x.ThanhTienDV + x.ThanhTienNH) > (x.ThanhToanDV + x.ThanhToanNH))
                  .OrderBy(x => x.NgayHachToan)
                  .ToList();
                gridControl2.DataSource = Utility.ToDataTable(ncc_dv_nh);
            }
        }
        private void btnLayData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
      
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
            if (e.Column.FieldName == "SoThu_DichVu")
            {
                double ThanhTienDV = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienDV"));
                double ThanhToanDV = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanDV"));
                e.Value = ThanhTienDV - ThanhToanDV;
            }
            if (e.Column.FieldName == "SoThu_ChiHo")
            {
                double ThanhTienCH = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienCH"));
                double ThanhToanCH = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanCH"));
                e.Value = ThanhTienCH - ThanhToanCH;
            }
            if (e.Column.FieldName == "TongThu")
            {
                double ThanhTienDV = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienDV"));
                double ThanhToanDV = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanDV"));
                double ThanhTienCH = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienCH"));
                double ThanhToanCH = Convert.ToDouble(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanCH"));
                e.Value = (ThanhTienDV - ThanhToanDV) + (ThanhTienCH - ThanhToanCH);
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Chon")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        double TongThu = Convert.ToDouble(gridView1.GetFocusedRowCellValue("TongThu").ToString());
                        if (isCheck)
                        {
                            _TongTienThu += TongThu;
                            gridView1.SetFocusedRowCellValue("SoTien_BuTru", TongThu);
                        }
                        else
                        {
                            _TongTienThu -= TongThu;
                            if (_TongTienThu < 0)
                            {
                                XtraMessageBox.Show("Có lỗi xảy ra. Hãy làm lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _TongTienThu = 0;
                                LoadData();
                            }
                            gridView1.SetFocusedRowCellValue("SoTien_BuTru", 0);
                        }
                        lbTienHachToan.Text = _TongTienThu.ToString("#,##");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Chon")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        double TongThu = Convert.ToDouble(gridView2.GetFocusedRowCellValue("TongThu").ToString());
                        if (isCheck)
                        {
                            if (_TongTienThu >= TongThu)
                            {
                                _TongTienThu -= TongThu;
                                gridView2.SetFocusedRowCellValue("SoTien_BuTru", TongThu);
                            }
                            else
                            {
                                gridView2.SetFocusedRowCellValue("SoTien_BuTru", _TongTienThu);
                                _TongTienThu -= _TongTienThu;
                            }
                         
                        }
                        else
                        {
                            double  SoTien_BuTru = Convert.ToDouble(gridView2.GetFocusedRowCellValue("SoTien_BuTru").ToString());
                            _TongTienThu += SoTien_BuTru;
                            gridView2.SetFocusedRowCellValue("SoTien_BuTru", 0);
                        }
                        lbTienHachToan.Text = _TongTienThu.ToString("#,##");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
            if (e.Column.FieldName == "SoThu_DichVu")
            {
                double ThanhTienDV = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienDV"));
                double ThanhToanDV = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanDV"));
                e.Value = ThanhTienDV - ThanhToanDV;
            }
            if (e.Column.FieldName == "SoThu_ChiHo")
            {
                double ThanhTienCH = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienNH"));
                double ThanhToanCH = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanNH"));
                e.Value = ThanhTienCH - ThanhToanCH;
            }
            if (e.Column.FieldName == "TongThu")
            {
                double ThanhTienDV = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienDV"));
                double ThanhToanDV = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanDV"));
                double ThanhTienCH = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhTienNH"));
                double ThanhToanCH = Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, "ThanhToanNH"));
                e.Value = (ThanhTienDV - ThanhToanDV) + (ThanhTienCH - ThanhToanCH);
            }
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnBuTru_Click(object sender, EventArgs e)
        {
            // điều kiện số tiền phải được hạch toán hết
            // phải có chọn khách hàng
            decimal tong_SoTien_BuTru = Convert.ToDecimal(gridView2.Columns["SoTien_BuTru"].SummaryItem.SummaryValue);
            if (string.IsNullOrWhiteSpace(dtNgay.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Ngày bù trừ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(cboKH.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tong_SoTien_BuTru == 0)
            {
                XtraMessageBox.Show("Chưa có công nợ nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_TongTienThu != 0)
            {
                XtraMessageBox.Show("Số tiền chưa được hạch toán hết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var _appDB = new clsKetNoi())
            {
                try
                {
                    _appDB.BeginTransaction();
                    DataRow nhacungcap = _appDB.GetSingleRecord("DanhSachNhaCungCap", cboKH.EditValue.ToString(), "MaNhaCungCap");
                    DataRow kh = _appDB.GetSingleRecord("DanhSachKhachHang", cboKH.EditValue.ToString(), "MaKhachHang");
                    // tạo đối trừ 
                    var p_doitru = new
                    {
                        ID = 0,
                        NgayHachToan = Convert.ToDateTime(dtNgay.Text),
                        NoiDung = "Bù trừ công nợ phải thu, phải trả " + kh["TenKhachHang"].ToString(),
                        NguoiTao = frmMain._TK,
                        NgayCapNhat = DateTime.Now,
                        SoTien = tong_SoTien_BuTru
                    };
                    int _id_doitru = _appDB.UpsertFromObject("DoiTruCongNo", p_doitru, "ID", true);
                    // tạo công nợ nhà cung cấp
                    string[] arr = dtNgay.Text.Trim().Split('/');
                    var p = new
                    {
                        IDPhieuChiNCC = 0,
                        SoChungTu = client.TaoSoChungTu_Chi_NCC(arr),
                        NgayHachToan = Convert.ToDateTime(dtNgay.Text),
                        MaChi = "006",
                        LyDoChi = "Chi trả tiền nhà cung cấp",
                        DienGiai = "Dối trừ công nợ",
                        NguoiTao = frmMain._TK,
                        ThoiGianTao = DateTime.Now,
                        NguoiNhan = frmMain._HoTen,
                        HinhThucTT = "TM",
                        IDDoiTru = _id_doitru
                    };
                    int _id_pchi = _appDB.UpsertFromObject("PhieuChi_NCC", p, "IDPhieuChiNCC", true);
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        double SoTien_BuTru =Convert.ToDouble(gridView2.GetRowCellValue(i, "SoTien_BuTru").ToString());
                        if (SoTien_BuTru > 0)
                        {
                            var phieuchitiet = new
                            {
                                IDCTNCC = 0,
                                IDCP = 0,
                                SoChungTu = p.SoChungTu,
                                SoFile = gridView2.GetRowCellValue(i, "SoFile").ToString(),
                                MaNhanVien = "",
                                SoTien = SoTien_BuTru,
                                DoiTuong = "NCC",
                                MaDoiTuong = nhacungcap["MaNhaCungCap"].ToString(),
                                TenDoiTuong = nhacungcap["TenVietTat"].ToString(),
                                DiaChi = "",
                                VAT = 0,
                                ThanhTien = SoTien_BuTru,
                                GhiChu = "",
                                IDPhieuChi = _id_pchi,
                                LaVanChuyen = Convert.ToInt32(gridView2.GetRowCellValue(i, "Type").ToString()) == 3 ? 0 : 1,
                                KeyName = gridView2.GetRowCellValue(i, "Key").ToString(),
                                IDName = gridView2.GetRowCellValue(i, "ID").ToString(),
                                NgayHachToan = Convert.ToDateTime(gridView2.GetRowCellValue(i, "NgayHachToan").ToString())
                            };
                            _appDB.UpsertFromObject("PhieuChi_NCC_CT", phieuchitiet, "IDCTNCC", true);
                        }
                    }
                    // tạo công nợ khách hàng
                    var p_kh = new
                    {
                        IDPhieuThu = 0,
                        DienGiai = "Dối trừ công nợ",
                        LyDoThu = "Thu công nợ khách hàng",
                        MaThu = "004",
                        NgayHachToan = Convert.ToDateTime(dtNgay.Text),
                        NguoiNhan = frmMain._HoTen,
                        NguoiTao = frmMain._TK,
                        SoChungTu = client.TaoSoChungTu_Thu(arr),
                        SoHoaDon = "",
                        ThoiGianTao = DateTime.Now,
                        HinhThucTT = "TM",
                        IDDoiTru = _id_doitru
                    };
                    int _id_pthu = _appDB.UpsertFromObject("PhieuThu", p_kh, "IDPhieuThu", true);
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        double SoTien_BuTru = Convert.ToDouble(gridView1.GetRowCellValue(i, "SoTien_BuTru").ToString());
                        if (SoTien_BuTru > 0)
                        {
                            int LaPhiChiHo = int.Parse(gridView1.GetRowCellValue(i, "LaPhiChiHo").ToString());
                            var phieuchitiet = new
                            {
                                IDCT = 0,
                                SoChungTu = p_kh.SoChungTu,
                                DiaChi = kh["DiaChi"].ToString(),
                                DoiTuong = "KH",
                                GhiChu = "",
                                MaDoiTuong = kh["MaKhachHang"].ToString(),
                                SoFile = gridView1.GetRowCellValue(i, "SoFile").ToString(),
                                SoTien = SoTien_BuTru,
                                VAT = 0,
                                ThanhTien = SoTien_BuTru,
                                TenDoiTuong = kh["TenVietTat"].ToString(),
                                IDCP = 0,
                                MaNhanVien = "",
                                LaPhieuChiHo = LaPhiChiHo,
                                MaDieuXe = gridView1.GetRowCellValue(i, "MaDieuXe").ToString(),
                                IDKey = int.Parse(gridView1.GetRowCellValue(i, "ID").ToString()),
                                KeyName = gridView1.GetRowCellValue(i, "Key").ToString(),
                                IDPhieuThu = _id_pthu,
                                NgayHachToan = Convert.ToDateTime(gridView1.GetRowCellValue(i, "NgayHachToan").ToString()),
                            };
                            _appDB.UpsertFromObject("PhieuThu_CT", phieuchitiet, "IDCT", true);
                        }
                    }
                    var p_doitru_update = new
                    {
                        ID = _id_doitru,
                        PhieuThuNCC_ID = _id_pchi,
                        PhieuThuKH_ID = _id_pthu
                    };
                    _appDB.UpsertFromObject("DoiTruCongNo", p_doitru_update, "ID", true);
                    _appDB.CommitTransaction();
                    XtraMessageBox.Show("Tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    _appDB.RollbackTransaction();
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
    }
}