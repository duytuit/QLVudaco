using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_FileDebit : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_FileDebit()
        {
            InitializeComponent();
        }
       
       

        private void rpt_FileGia_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblIn.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
           
        }
    }
}
