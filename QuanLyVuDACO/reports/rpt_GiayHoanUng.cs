using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_GiayHoanUng : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_GiayHoanUng()
        {
            InitializeComponent();
        }

        public rpt_GiayHoanUng(string _tgian)
        {
            InitializeComponent();
            lblKhoangTgian.Text = _tgian;
        }

        private void rpt_GiayHoanUng_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblHoTen.Text = frmMain._HoTen;
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
