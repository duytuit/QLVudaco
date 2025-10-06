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
        }

        private void frmDoiTruCongNo_Load(object sender, EventArgs e)
        {
            dtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            using (var kh = new khachhang())
            {
                cboKH.Properties.DataSource = kh.GetAllkh().Where(x=>x.LaNhaCungCap);
            }
               
        }

        private void btnLayData_Click(object sender, EventArgs e)
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
                    SoFile = x.SoFile +"/"+ x.MaDieuXe,
                    ThanhToanDV = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 0).Sum(y => y.ThanhTien),
                    ThanhToanCH = _khachhang_ct.Where(y => y.IDKey == x.ID && y.KeyName == x.Key && y.Type == 5 && y.LaPhiChiHo == 1).Sum(y => y.ThanhTien),
                    SoTien_BuTru=0,
                    Chon=false
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
                    MaDieuXe = x.MaDieuXe??x.SoFile,
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
                    SoFile = x.SoFile +"/" + x.MaDieuXe,
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
                            gridView1.SetFocusedRowCellValue("SoTien_BuTru", 0);
                        }
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
                                _TongTienThu -= _TongTienThu;
                                gridView2.SetFocusedRowCellValue("SoTien_BuTru", _TongTienThu);
                            }
                           
                        }
                        else
                        {
                            double  SoTien_BuTru = Convert.ToDouble(gridView2.GetFocusedRowCellValue("SoTien_BuTru").ToString());
                            _TongTienThu += SoTien_BuTru;
                            gridView2.SetFocusedRowCellValue("SoTien_BuTru", 0);
                        }
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
    }
}