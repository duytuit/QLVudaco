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
    public partial class ucLuongVanPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucLuongVanPhong()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
           
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
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
            gridControl1.DataSource = client.Luong_VP_TongHop(thang, nam);
            splashScreenManager1.CloseWaitForm();
        }
        string _TenNhanVien = "";
        string _MaNhanVien = "";
        string _TaiKhoan = "";
        private void repositoryItemChiTiet_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            _TaiKhoan = gridView1.GetFocusedRowCellValue("TaiKhoan").ToString().Trim();
            _TenNhanVien = gridView1.GetFocusedRowCellValue("TenNhanVien").ToString().Trim();
            _MaNhanVien = gridView1.GetFocusedRowCellValue("MaNhanVien").ToString().Trim();
            NewMethod(_TaiKhoan, _TenNhanVien, _MaNhanVien);
            btnThemPhuCap.Enabled = true;

            splashScreenManager1.CloseWaitForm();
        }

        private void NewMethod(string tk,string ten,string ma)
        {
            int thang = (cboThang.Text == "") ? 0 : int.Parse(cboThang.Text);
            int nam = (cboNam.Text == "") ? 0 : int.Parse(cboNam.Text);
            string _TaiKhoan = gridView1.GetFocusedRowCellValue("TaiKhoan").ToString().Trim();
            _TenNhanVien = gridView1.GetFocusedRowCellValue("TenNhanVien").ToString().Trim();
            _MaNhanVien = gridView1.GetFocusedRowCellValue("MaNhanVien").ToString().Trim();
            var table2 = client.NhanVien_PhuCap_TheoMaNhanVien(_MaNhanVien, thang, nam);
            gridControl2.DataSource = table2.ToList();
            DataTable dt = client.ChiTietLuong_VP(_TaiKhoan, _MaNhanVien, thang, nam);
            double LuongTT = 0, TongPhuCap = 0;
            foreach (var item in table2)
            {
                TongPhuCap += item.TienPhuCap.Value;
            }
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblHoTen.Text = row["TenNhanVien"].ToString();
                lblLuongCung.Text = double.Parse(row["LuongCoDinh"].ToString()).ToString("#,##");
                lblSoNgayNghi.Text = row["SoNgayNghi"].ToString();
                LuongTT = double.Parse(row["LuongThucTe"].ToString());
                lblLuongThucTe.Text = LuongTT.ToString("#,##");
            }
            lblTongLuong.Text = (LuongTT + TongPhuCap).ToString("#,##");
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

        private void btnThemPhuCap_Click(object sender, EventArgs e)
        {
            if(_TenNhanVien!="")
            {
                Form frm = new Forms.frmPhuCap(_MaNhanVien, _TenNhanVien, int.Parse(cboThang.Text), int.Parse(cboNam.Text));
                frm.ShowDialog();
                btnXoaPhuCap.Enabled = false;
            }    
        }
        int _ID = 0;
        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if(gridView2.FocusedRowHandle>=0)
            {
                _ID = int.Parse(gridView2.GetFocusedRowCellValue("IDLuong").ToString());
                btnXoaPhuCap.Enabled = true;
            }    
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
            {
                _ID = int.Parse(gridView2.GetFocusedRowCellValue("IDLuong").ToString());
                btnXoaPhuCap.Enabled = true;
            }
        }

        private void btnXoaPhuCap_Click(object sender, EventArgs e)
        {
            ServiceReference1.NhanVien_PhuCap table = new ServiceReference1.NhanVien_PhuCap();
            table.IDLuong = _ID;
            client.XoaPhuCap_NhanVien(table);
            NewMethod(_TaiKhoan, _TenNhanVien, _MaNhanVien);
        }
    }
}
