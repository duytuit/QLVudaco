using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_LoiNhuanTheoTungLinhVuc : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_LoiNhuanTheoTungLinhVuc()
        {
            InitializeComponent();
        }
        public rpt_LoiNhuanTheoTungLinhVuc(DataTable dt,string tg)
        {
            InitializeComponent();
            _tg = tg;
            _dt = dt;
        }
        string _tg = "";
        DataTable _dt = new DataTable();

        private void rpt_BaoCaoSoQuyTM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = _dt;
            this.DataMember = "total";
            xrLabel2.Text = _tg;
           
        }
    }
}
