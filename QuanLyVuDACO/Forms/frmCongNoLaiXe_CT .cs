using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class frmCongNoLaiXe_CT : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoLaiXe_CT()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        public frmCongNoLaiXe_CT(DateTime TuNgay,DateTime DenNgay,string TaiKhoan,string tenGiaoNhan)
        {
            InitializeComponent();
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _TaiKhoan = TaiKhoan;
            _TenGiaoNhan = tenGiaoNhan;
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        DateTime _TuNgay = new DateTime();
        DateTime _DenNgay = new DateTime();
        string _TaiKhoan = "", _TenGiaoNhan = "";
        private void bandedGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                int dong = e.RowHandle;
                if(dong>=0)
                {
                    //if(bandedGridView1.GetRowCellDisplayText(dong,"Loai").ToString().Trim().ToLower()=="x")
                    //{
                    //    e.Appearance.BackColor = Color.Red;
                    //    e.Appearance.ForeColor = Color.White;
                    //}    
                }    

            }
            catch (Exception)
            {

            }
        }
        public static string _MaQuy = "";
        public static string _SotK = "", _ChiNhanh = "", _ChuTK = "", _TenNganHang = "", _HinhThucTT = "";
        public static double _SoTien = 0;
        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
        }

        private void bandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Chon")
                    {
                        bool isCheck = bool.Parse(e.Value.ToString());
                        if (isCheck)
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng", bandedGridView1.GetFocusedRowCellValue("ConLai_TamUng").ToString());
                            bandedGridView1.SetFocusedRowCellValue("SoThu_ThuCuoc", bandedGridView1.GetFocusedRowCellValue("ConLai_ThuCuoc").ToString());
                        }
                        else
                        {
                            bandedGridView1.SetFocusedRowCellValue("SoThu_TamUng", 0);
                            bandedGridView1.SetFocusedRowCellValue("SoThu_ThuCuoc", 0);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static DateTime _Ngay = new DateTime();
        public static int _In = 0;
        public static string _DienGiai = "";
        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            frmMain._Luu = 0;

            _Ngay = DateTime.Now;
            _In = 0;
            _MaQuy = ""; _SotK = ""; _ChiNhanh = ""; _ChuTK = ""; _TenNganHang = ""; _HinhThucTT = ""; _DienGiai = "";

            bool isCheck = false, isCheck_TamUng = false, isCheck_ThuCuoc = false;
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                if (_Chon)
                {
                    isCheck = true;
                }
                if (bandedGridView1.GetRowCellValue(i, "SoThu_TamUng").ToString() != "")
                    isCheck_TamUng = true;
            }
            if (!isCheck)
                MessageBox.Show("Vui lòng chọn dòng cần thu tiền!");
            else
            {
                //phieu thu
                frmQuyLaiXe frm1 = new frmQuyLaiXe();
                frm1.ShowDialog();
                if (frmMain._Luu == 1)
                {
                    ServiceReference1.PhieuThu_LaiXe p = new ServiceReference1.PhieuThu_LaiXe();
                    string[] arr = _Ngay.ToString("dd/MM/yyyy").Split('/');
                    p.DienGiai = _DienGiai;
                    p.LyDoThu = _DienGiai;
                    p.MaThu = "002";
                    p.MaQuy = _MaQuy;
                    DateTime Ngay1 = _Ngay;
                    p.NgayHachToan = Ngay1;
                    p.NguoiNhan = frmMain._HoTen;
                    p.NguoiTao = frmMain._TK;
                    p.SoChungTu = client.TaoSoChungTu_ThuLaiXe(arr);
                    p.SoHoaDon = "";
                    p.ThoiGianTao = _Ngay;
                    p.HinhThucTT = _HinhThucTT;
                    p.SoTK = _SotK;
                    p.TenNganHang = _TenNganHang;
                    p.ChiNhanh = _ChiNhanh;
                    p.ChuTaiKhoan = _ChuTK;
                    client.DanhSachPhieuThuLaiXe_Them(p);

                    for (int i = 0; i < bandedGridView1.RowCount; i++)
                    {
                        bool _Chon = bool.Parse(bandedGridView1.GetRowCellValue(i, "Chon").ToString());
                        if (_Chon)
                        {

                            if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_TamUng").ToString() != "")
                            {
                                object[] value = new object[12];
                                value[0] = p.SoChungTu;// bandedGridView1.GetRowCellDisplayText(i, "SoChungTu").ToString();
                                value[1] = _TaiKhoan;
                                value[2] = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_TamUng").ToString());
                                value[3] = "NV";
                                value[4] = _TaiKhoan;
                                value[5] = _TenGiaoNhan;
                                value[6] = 0;
                                value[7] = value[2];
                                value[8] = true;
                                value[9] = 0;
                                value[10] = "";
                                value[11] = bandedGridView1.GetRowCellDisplayText(i, "SoChungTu").ToString();
                                client.DanhSachPhieuThuLaiXe_CT_Them(value, value[0].ToString());
                            }
                            if (bandedGridView1.GetRowCellDisplayText(i, "SoThu_ThuCuoc").ToString() != "")
                            {
                                object[] value = new object[12];
                                value[0] = p.SoChungTu;// bandedGridView1.GetRowCellDisplayText(i, "SoChungTu").ToString();
                                value[1] = _TaiKhoan;
                                value[2] = double.Parse(bandedGridView1.GetRowCellValue(i, "SoThu_ThuCuoc").ToString());
                                value[3] = "NV";
                                value[4] = _TaiKhoan;
                                value[5] = _TenGiaoNhan;
                                value[6] = 0;
                                value[7] = value[2];
                                value[8] = false;
                                value[9] = 0;
                                value[10] = bandedGridView1.GetRowCellDisplayText(i, "MaDieuXe").ToString();
                                value[11] = bandedGridView1.GetRowCellDisplayText(i, "MaDieuXe").ToString();
                                client.DanhSachPhieuThuLaiXe_CT_Them(value, value[0].ToString());
                            }
                        }

                    }
                    if (_In == 1)
                    {
                        string _soChungTu = p.SoChungTu;
                        DateTime _NgayHachToan = Ngay1;
                        DataTable dt = client.DanhSachPhieuThuLaiXe_CT_TheoSoChungTu(_soChungTu);
                        reports.rpt_PhieuThuLaiXe rpt = new reports.rpt_PhieuThuLaiXe(dt, _NgayHachToan);
                        rpt.ShowPreview();
                    }
                    frmCongNoKH_CT_Load(sender, e);
                }
            }
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmCongNoKH_CT_Load(object sender, EventArgs e)
        {
            try
            {
                this.CenterToScreen();
                this.Text = "Công nợ chi tiết: " + _TenGiaoNhan + " đến ngày " + _DenNgay.ToString("dd/MM/yyyy"); ;
               
                splashScreenManager1.ShowWaitForm();
                gridControl1.DataSource = client.CongNoChiTietLaiXe(_TuNgay, _DenNgay, _TaiKhoan);
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}