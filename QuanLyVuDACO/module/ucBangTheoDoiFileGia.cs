using DevExpress.XtraEditors;
using Quản_lý_vudaco.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using Quản_lý_vudaco.services;

namespace Quản_lý_vudaco.module
{
    public partial class ucBangTheoDoiFileGia : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTheoDoiFileGia()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
            colSTT3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView3.CustomUnboundColumnData += GridView3_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void GridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.IsGetData)
            {
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                if (rowHandle >= 0)
                    e.Value = rowHandle + 1;
            }
        }
        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnXem_Click(sender, e);
        }
      
        private void btnXem_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                gridControl1.DataSource = client.BangFileChuaTaoFileGia_Xem(Ngay1, Ngay2);

                gridControl2.DataSource = client.dt_BangFileGiaDaTao(Ngay1, Ngay2);
            }
            else
                MessageBox.Show("Vui lòng chọn ngày đúng định dạng!");
            //gridControl3.DataSource = client.ChiPhiNangHa(dtpTuNgay.DateTime, dtpDenNgay.DateTime);
        }

      

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            int _IDLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            int _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString().Trim());
          var table=  client.FileGia_TheoIDGia(_IDGia);
            foreach (var item in table)
            {
                if (item.Duyet.Value == true)
                    MessageBox.Show("File này đã được duyệt vui lòng liên hệ quản lý!");
                else
                {
                    Forms.frmFileGia frm = new Forms.frmFileGia(_IDLoHang, "", _IDGia, 1);
                    frm.ShowDialog();
                    btnXem_Click(sender, e);
                }
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            if (frmMain._TK != "admin")
                MessageBox.Show("Chỉ Admin mới có quyền này");
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //VudacoEntities context = new VudacoEntities();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string _check = gridView1.GetRowCellValue(i, "Chon").ToString();
                        if (_check == "True")
                        {
                            int _IDLoHang = int.Parse(gridView1.GetRowCellValue(i, "IDLoHang").ToString().Trim());
                            client.XoaThongTinFile(_IDLoHang);
                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            string _SoFile = gridView1.GetFocusedRowCellValue("SoFile").ToString().Trim();
            int _idcp = int.Parse(gridView1.GetFocusedRowCellValue("IDCP").ToString().Trim());
            Form frm = new frmFileGia(_IDLoHang, _SoFile,0, _idcp, 0);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
                bool _duyet = (gridView2.GetFocusedRowCellValue("Duyet") != null) ? bool.Parse(gridView2.GetFocusedRowCellValue("Duyet").ToString()) : false;
                if (_duyet)
                    MessageBox.Show("Lô này đã được duyệt, vui lòng liên hệ quản lý!");
                else
                {
                    bool check = client.FileGia_KiemTraFileDebit(_IDGia);
                    if (check)
                        MessageBox.Show("File giá này có dữ liệu liên quan File Debit, vui lòng xóa ở File Debit trước để tiếp tục!");
                    else
                    {
                        client.XoaFileGia_TheoIDGia(_IDGia);
                        btnXem_Click(sender, e);
                    }
                }
            }
        }

        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            int _idLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString());
            _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
            string _SoFile = gridView2.GetFocusedRowCellValue("SoFile").ToString();
            // Form frm = new frmBangKeChiPhiNangHa(_idLoHang, 1);
            bool _duyet = (gridView2.GetFocusedRowCellValue("Duyet") != null) ? bool.Parse(gridView2.GetFocusedRowCellValue("Duyet").ToString()) : false;
            if (_duyet)
                MessageBox.Show("Lô này đã được duyệt, vui lòng liên hệ quản lý!");
            else
            {
                Form frm = new frmFileGia(_idLoHang, _SoFile, _IDGia, 1);
                frm.ShowDialog();
                btnXem_Click(sender, e);
            }
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            int _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
            DataTable dt = new DataTable("xem");
            dt.Columns.Add("TenDichVu");
            dt.Columns.Add("GiaBan",typeof(float));
            dt.Columns.Add("GiaMua", typeof(float));
            dt.Columns.Add("GhiChu");
          var t = client.BangFileGiaDaTao_ChiTiet(_IDGia);
            foreach (var item in t)
            {
                DataRow row = dt.NewRow();
                row["TenDichVu"] = item.TenDichVu;
                row["GiaBan"] = item.GiaBan;
                row["GiaMua"] = item.GiaMua;
                row["GhiChu"] = item.GhiChu;
                dt.Rows.Add(row);
            }
            DataTable dt1 = client.DsThongTinFile_Full_TheoIDLoHang_TheoIDGia(_IDGia);
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                dt.Columns.Add(dt1.Columns[i].ColumnName);
            }
            dt.Columns.Add("LoiNhuan",typeof(double));
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double _Mua = 0, _Ban = 0;
                _Mua = (dt.Rows[i]["GiaMua"].ToString() == "") ? 0 : double.Parse(dt.Rows[i]["GiaMua"].ToString());
                _Ban = (dt.Rows[i]["GiaBan"].ToString() == "") ? 0 : double.Parse(dt.Rows[i]["GiaBan"].ToString());
                for (int j=0;j<dt1.Columns.Count;j++)
                {
                    dt.Rows[i][dt1.Columns[j].ColumnName] = dt1.Rows[0][dt1.Columns[j].ColumnName].ToString();
                }
                dt.Rows[i]["LoiNhuan"] = _Ban - _Mua;
            }
            reports.rpt_FileGia rpt = new reports.rpt_FileGia();
            rpt.DataSource = dt;
            rpt.DataMember = "xem";
            rpt.ShowPreview();
        }
        int _IDGia = 0;
        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.FocusedRowHandle >= 0)
                {
                    ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                    _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
                    using ( var _khachhang = new khachhang())
                    {
                        gridControl3.DataSource = _khachhang.BangFileGiaDaTao_ChiTiet(_IDGia);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (gridView2.FocusedRowHandle >= 0)
                {
                    ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                    _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
                    gridControl3.DataSource = client.BangFileGiaDaTao_ChiTiet(_IDGia);
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gridView2.ExportToXlsx(dialog.SelectedPath + "/BangTheoDoiFileGia.xlsx");
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
