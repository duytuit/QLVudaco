using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.module
{
    public partial class ucLuongLaiXe : DevExpress.XtraEditors.XtraUserControl
    {
        public ucLuongLaiXe()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
            colSTT3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView3.CustomUnboundColumnData += GridView3_CustomUnboundColumnData;

            colSTT4.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            bandedGridView1.CustomUnboundColumnData += GridView4_CustomUnboundColumnData;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void GridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void GridView4_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void ucLuongLaiXe_Load(object sender, EventArgs e)
        {
            cboThang.SelectedText = DateTime.Now.Month.ToString();
            for (int i = 2024; i <= 2040; i++)
            {
                cboNam.Properties.Items.Add(i.ToString());
            }
            cboNam.SelectedText = DateTime.Now.Year.ToString();
            btnXem_Click(sender, e);
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            int thang = (cboThang.Text == "") ? 0 : int.Parse(cboThang.Text);
            int nam = (cboNam.Text == "") ? 0 : int.Parse(cboNam.Text);
            gridControl1.DataSource = client.Luong_LaiXe_TongHop(thang, nam);
            splashScreenManager1.CloseWaitForm();
            splashScreenManager1.Dispose();
        }

        private void repositoryItemChiTiet_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            int thang = (cboThang.Text == "") ? 0 : int.Parse(cboThang.Text);
            int nam = (cboNam.Text == "") ? 0 : int.Parse(cboNam.Text);
            string _TaiKhoan = gridView1.GetFocusedRowCellValue("TaiKhoan").ToString().Trim();
            string _TenNhanVien = gridView1.GetFocusedRowCellValue("TenNhanVien").ToString().Trim();
            string _MaNhanVien = gridView1.GetFocusedRowCellValue("MaNhanVien").ToString().Trim();
            groupControl1.Text = "Chi tiết bảng lương [ " + _TenNhanVien + " ]";
            gridControl2.DataSource = client.LuongLaiXe_Chitiet(_TaiKhoan,thang, nam);
            gridControl3.DataSource = client.LuongLaiXe_CacKhoanTinhLuong(_TaiKhoan, _MaNhanVien, thang, nam);
            //cac khoan tam ung
            int Ngay2 = DateTime.DaysInMonth(nam, thang);
            int Ngay1 = 1;
            gridControl4.DataSource = client.CongNoChiTietLaiXe(new DateTime(nam, thang, Ngay1), new DateTime(nam, thang, Ngay2), _TaiKhoan);
            splashScreenManager1.CloseWaitForm();
            splashScreenManager1.Dispose();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                    repositoryItemChiTiet_Click(sender, e);
            }
            catch (Exception)
            {

            }
        }
    }
}
