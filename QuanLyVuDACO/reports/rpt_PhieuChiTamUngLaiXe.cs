using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Quản_lý_vudaco.reports
{
    public partial class rpt_PhieuChiTamUngLaiXe : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_PhieuChiTamUngLaiXe()
        {
            InitializeComponent();
        }
        public rpt_PhieuChiTamUngLaiXe(DataTable _dt,DateTime _Ngay)
        {
            InitializeComponent();
            Ngay = _Ngay;
            dt = _dt;
        }
        DataTable dt = new DataTable();
        DateTime Ngay = new DateTime();

        private void rpt_PhieuThu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = dt;
            this.DataMember = "xem";
            xrLabel30.Text = string.Format("Hải Phòng ngày {0} tháng {1} năm {2}",Ngay.Day.ToString("0#"), Ngay.Month.ToString("0#"), Ngay.Year.ToString());
        }

        private void xrLabel34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double tong = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tong += double.Parse(dt.Rows[i]["ThanhTien"].ToString());
            }
            //lblTong.Text = Math.Abs(tong).ToString("#,##");
        }
    }
}
