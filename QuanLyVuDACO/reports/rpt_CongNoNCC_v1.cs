using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_CongNoNCC_v1 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_CongNoNCC_v1()
        {
            InitializeComponent();
        }
        public rpt_CongNoNCC_v1(string tg,double dauky,double thanhtoan,string ten)
        {
            InitializeComponent();
            _tg = tg;
            _DauKy = dauky;
            _ThanhToan = thanhtoan;
            _ten = ten;
        }
        DataTable _dt = new DataTable();
        double _DauKy = 0, _ThanhToan = 0;
        string _tg = "", _ten = "";
        private void rpt_CongNoKH_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.DataSource = _dt;
            lblNgay.Text = _tg;
            //double tong = 0;
            //double chiho = 0;
            lblDauKy.Text = _DauKy.ToString("#,##");
            //lblTongThanhToan.Text = _ThanhToan.ToString("#,##");
            lblHoTen.Text = _ten;
            //if (_dt.Rows.Count > 0)
            //{
            //   
            //   tong = double.Parse(_dt.Compute("Sum(ThanhTien)", "").ToString());// (lblTong.Value == null) ? 0 : double.Parse(lblTong.Value.ToString());
            //   double  phi_nang =0;
            //   double phi_ha =0;
            //    double phi_nangha = 0;
            //    double phi_csht = 0;
            //   double phi_khac = 0;
            //    double phi_tamthu = 0;
            //    for (int i = 0; i < _dt.Rows.Count; i++)
            //    {
            //         phi_nang += double.Parse("0"+_dt.Rows[i]["PhiNang"].ToString());
            //         phi_ha += double.Parse("0" + _dt.Rows[i]["PhiHa"].ToString());
            //         phi_nangha += double.Parse("0" + _dt.Rows[i]["PhiNangHa"].ToString());
            //         phi_csht += double.Parse("0" + _dt.Rows[i]["PhiCSHT"].ToString());
            //         phi_khac += double.Parse("0" + _dt.Rows[i]["PhiKhac"].ToString());
            //         phi_tamthu += double.Parse("0" + _dt.Rows[i]["PhieuTamThu"].ToString());
            //    }
            //    lblTongPhatSinh.Text = (tong + phi_nang+ phi_ha+ phi_nangha + phi_csht+ phi_khac+ phi_tamthu).ToString("#,##");
            //    lblCuoiKy.Text = (_DauKy + tong + phi_nang + phi_ha + phi_nangha + phi_csht + phi_khac + phi_tamthu - _ThanhToan).ToString("#,##");
            //}
           
        }

        private void xrTableCell37_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
        }
    }
}
