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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Quản_lý_vudaco.module
{
    public partial class ucBangTheoDoiDebit_CoFile_NCC : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTheoDoiDebit_CoFile_NCC()
        {
            InitializeComponent();
           // colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            //colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
           // gridView1.OptionsBehavior.AutoPopulateColumns = true;


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
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            var table = client.ds_NCC();
            repositoryItemKH.DataSource = table.ToList();
            btnXem_Click(sender, e);
        }
      
        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
               // gridControl1.DataSource = client.DSBangPhiDiDuong_DuyetChi_CoFile_NCC(Ngay1, Ngay2);
                //
                using (var _ncc = new ncc())
                {
                    gridControl1.DataSource = _ncc.dt_BangFileGiaDaTao(Ngay1, Ngay2) ;
                    gridControl2.DataSource = _ncc.BangFileDebitChiTiets(Ngay1, Ngay2);
                }
            }
        }

      

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString().Trim());
            int _IDLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            frmFileDebitNcc frm = new frmFileDebitNcc(_IDDeBit, _IDLoHang, 0, 1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }
        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDDeBit = 0;
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            int _FileGia = int.Parse(gridView1.GetFocusedRowCellValue("IDGia").ToString().Trim());

            frmFileDebitNcc frm = new frmFileDebitNcc(_IDLoHang,_FileGia,0,1,0); 
            frm.ShowDialog();
            btnXem_Click(sender, e);
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                //
                using (var _ncc = new ncc())
                {
                    gridControl2.DataSource = _ncc.BangFileDebitChiTiets(Ngay1, Ngay2);
                }

            }
        }

        int _IDDeBit = 0;
        private void gridView2_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
           
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString());
                using (var _appDB = new clsKetNoi())
                {
                    _appDB.DeleteById("FileDebitNcc", _IDDeBit, "IDDeBit");
                    _appDB.DeleteById("FileDebitNccChiTiet", _IDDeBit, "IDDeBit");
                }
                ucBangTheoDoiSoFile_Load(sender, e);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "STT") // hoặc kiểm tra theo gridColumn nếu cần
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
            }
        }


        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string key = "";

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (bool.Parse(gridView2.GetRowCellValue(i, "Chon").ToString()))
                {
                    key += gridView2.GetRowCellValue(i, "IDDeBit").ToString().Trim() + "-";
                }
            }
            if (key.Length > 0)
            {
                frmXuatHoaDonKhongLapFile frm = new Forms.frmXuatHoaDonKhongLapFile();
                frm.ShowDialog();
                key = key.Substring(0, key.Length - 1);
                using (var _ncc = new ncc())
                {
                    _ncc.FileDeBit_KoLapFile_XuatHoaDon_NCC(true, key, frm._SoHoaDon, frm._NgayXuatHD);
                }

            }
            btnXem_Click(sender, e);
        }
        bool headerCheckBoxState = false;
        Rectangle headerCheckBoxRect;
        private void gridView2_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Chon")
            {
                e.Info.InnerElements.Clear(); // xóa nội dung mặc định
                e.Info.Appearance.DrawString(e.Cache, e.Info.Caption, e.Bounds);

                // Vị trí checkbox trong header
                headerCheckBoxRect = new Rectangle(e.Bounds.X + e.Bounds.Width / 2 + 14, e.Bounds.Y + 4, 16, 16);
                ControlPaint.DrawCheckBox(e.Graphics, headerCheckBoxRect,
                headerCheckBoxState ? ButtonState.Checked : ButtonState.Normal);

                e.Handled = true;
            }
        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gridView2.CalcHitInfo(e.Location);

            if (hitInfo.InColumn && hitInfo.Column != null && hitInfo.Column.FieldName == "Chon")
            {
                if (headerCheckBoxRect.Contains(e.Location))
                {
                    // Toggle trạng thái checkbox header
                    headerCheckBoxState = !headerCheckBoxState;

                    // Cập nhật toàn bộ dòng
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        gridView2.SetRowCellValue(i, "Chon", headerCheckBoxState);
                    }

                    // Vẽ lại header
                    gridView2.InvalidateColumnHeader(gridView2.Columns["Chon"]);
                }
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Chon")
            {
                e.Info.InnerElements.Clear(); // xóa nội dung mặc định
                e.Info.Appearance.DrawString(e.Cache, e.Info.Caption, e.Bounds);

                // Vị trí checkbox trong header
                headerCheckBoxRect = new Rectangle(e.Bounds.X + e.Bounds.Width / 2 + 14, e.Bounds.Y + 4, 16, 16);
                ControlPaint.DrawCheckBox(e.Graphics, headerCheckBoxRect,
                headerCheckBoxState ? ButtonState.Checked : ButtonState.Normal);

                e.Handled = true;
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Location);

            if (hitInfo.InColumn && hitInfo.Column != null && hitInfo.Column.FieldName == "Chon")
            {
                if (headerCheckBoxRect.Contains(e.Location))
                {
                    // Toggle trạng thái checkbox header
                    headerCheckBoxState = !headerCheckBoxState;

                    // Cập nhật toàn bộ dòng
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, "Chon", headerCheckBoxState);
                    }

                    // Vẽ lại header
                    gridView1.InvalidateColumnHeader(gridView1.Columns["Chon"]);
                }
            }
        }
    }
}
