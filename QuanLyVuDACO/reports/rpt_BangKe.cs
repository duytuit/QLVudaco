using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_BangKe : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BangKe()
        {
            InitializeComponent();
        }
        public rpt_BangKe(DataTable dt2)
        {
            InitializeComponent();
           
            _dt2 = dt2;
        }
        DataTable _dt = new DataTable();
        DataTable _dt2 = new DataTable();
        private void rpt_BangKe_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = _dt2;
            this.DataMember = "chitiet";
            if(_dt.Rows.Count>0)
            {

            }
        }
    }
}
