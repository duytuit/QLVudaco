using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_BaoCaoSoTK : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BaoCaoSoTK()
        {
            InitializeComponent();
        }
        public rpt_BaoCaoSoTK(DataTable dt,string tg,double dauky)
        {
            InitializeComponent();
            _tg = tg;
            _dt = dt;
            _dauky = dauky;
        }
        string _tg = "";
        double _dauky = 0;
        DataTable _dt = new DataTable();

        private void rpt_BaoCaoSoQuyTM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = _dt;
            this.DataMember = "total";
            xrLabel2.Text = _tg;
            //show 
            double thu = 0;
            double chi = 0;
            xrLabel9.Text = _dauky.ToString("#,##");
            if (_dt.Rows.Count > 0)
            {

                thu = double.Parse(_dt.Compute("Sum(Thu)", "").ToString());
                chi = double.Parse(_dt.Compute("Sum(Chi)", "").ToString());
            }
            xrLabel19.Text = (_dauky + thu - chi).ToString("#,##");
        }
    }
}
