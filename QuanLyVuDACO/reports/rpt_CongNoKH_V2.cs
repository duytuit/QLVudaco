using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_CongNoKH_V2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_CongNoKH_V2()
        {
            InitializeComponent();
        }
        public rpt_CongNoKH_V2(DataTable dt,string tg,string ten)
        {
            InitializeComponent();
            _dt = dt;
            _tg = tg;
            _ten = ten;
        }
        DataTable _dt = new DataTable();
        double _DauKy = 0, _ThanhToan = 0;
        string _tg = "", _ten = "";
        private void rpt_CongNoKH_V2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = _dt;
            lblNgay.Text = _tg;
            double tong = 0;
            double chiho = 0;
            xrTableCell44.Text = _DauKy.ToString("#,##");
            xrTableCell38.Text = _ThanhToan.ToString("#,##");
            lblHoTen.Text = _ten;
            //if (_dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < _dt.Rows.Count; i++)
            //    {
            //        tong += double.Parse("0"+_dt.Rows[i]["ThanhTien"].ToString());
            //        if(_dt.Rows[i]["ThanhTien_ChiHo"].ToString()!="")
            //            chiho += double.Parse("0"+_dt.Rows[i]["ThanhTien_ChiHo"].ToString());
            //    }
            //   
            //    xrTableCell37.Text = (tong + chiho).ToString("#,##");
            //}
            //xrTableCell42.Text = (_DauKy + tong + chiho - _ThanhToan).ToString("#,##");
        }

        private void xrTableCell37_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
        }
    }
}
