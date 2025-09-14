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
    public partial class ucBangTheoDoiDebit_KoFile_KH : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTheoDoiDebit_KoFile_KH()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;

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
            repositoryItemNhaCungCap.DataSource = client.ds_NCC();
            btnXem_Click(sender, e);
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnXem_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
            
                gridControl1.DataSource = client.DSBangPhiDiDuong_DuyetChi_KhongCoFile(Ngay1, Ngay2);
                using (var _khachhang = new khachhang())
                {
                    gridControl2.DataSource = _khachhang.dt_BangFileDebitDaTao_KH(Ngay1, Ngay2);
                }
                var table = client.dsKH();
                repositoryItemKH.DataSource = table.ToList();
            }
        }

      

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString().Trim());
            Forms.frmFile_KoFile_KH frm = new Forms.frmFile_KoFile_KH("", _IDDeBit,1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

      

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDDeBit = 0;
            string _MaDieuXe = gridView1.GetFocusedRowCellValue("MaDieuXe").ToString().Trim();
            Form frm = new frmFile_KoFile_KH(_MaDieuXe, _IDDeBit, 0); 
            frm.ShowDialog();
            btnXem_Click(sender, e);
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
                client.Xoa_FileDebit_KoHoaDon_KH(_IDDeBit);
                btnXem_Click(sender, e);
            }
        }
        public static DateTime _NgayXuatHD = new DateTime(1900,1,1);
        public static string _SoHoaDon = "";
        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            bool isCheck = false;
            int dem = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                var cellValue = gridView2.GetRowCellValue(i, "Chon");

                if (cellValue != null && cellValue != DBNull.Value && Convert.ToBoolean(cellValue))
                {
                    isCheck = true;
                    break;
                }
            }
            if (isCheck)
            {
                _NgayXuatHD = new DateTime(1900, 1, 1);
                _SoHoaDon = "";
                Form frm = new Forms.frmXuatHoaDonKhongLapFile();
                frm.ShowDialog();
                if (_SoHoaDon != "")
                {
                    string key = "";
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        var cellValue = gridView2.GetRowCellValue(i, "Chon");

                        if (cellValue != null && cellValue != DBNull.Value && Convert.ToBoolean(cellValue))
                        {
                            key += gridView2.GetRowCellValue(i, "IDDeBit").ToString().Trim() + "-";
                        }
                    }
                    if (key.Length > 0)
                    {
                        key = key.Substring(0, key.Length - 1);
                        client.FileDeBit_KoLapFile_XuatHoaDon(true, key, _SoHoaDon, _NgayXuatHD);
                    }
                }
                else
                {
                    string key = "";
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        var cellValue = gridView2.GetRowCellValue(i, "Chon");

                        if (cellValue != null && cellValue != DBNull.Value && Convert.ToBoolean(cellValue))
                        {
                            key += gridView2.GetRowCellValue(i, "IDDeBit").ToString().Trim() + "-";
                        }
                    }
                    if (key.Length > 0)
                    {
                        key = key.Substring(0, key.Length - 1);
                        client.FileDeBit_KoLapFile_XuatHoaDon(true, key, _SoHoaDon, _NgayXuatHD);
                    }
                }
            }
            btnXem_Click(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gridView2.ExportToXlsx(dialog.SelectedPath + "/CacLoHangKhongLapFile.xlsx");
            }
        }

        private void btntaoDebit_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var cellValue = gridView2.GetRowCellValue(i, "Chon");

                if (cellValue != null && cellValue != DBNull.Value && Convert.ToBoolean(cellValue))
                {
                    string _MaDieuXe = gridView1.GetRowCellValue(i,"MaDieuXe").ToString().Trim();
                    str += _MaDieuXe + "-";
                }
            }
            if (str.Length > 0)
                str = str.Substring(0, str.Length - 1);
            if (str.Length == 0)
                MessageBox.Show("Bạn chưa chọn dòng nào!");
            else
            {
                DataTable dt = client.BangDieuXe_TaoDeBitHangLoat(str);
                Form frm = new frmTaoDebit_File(dt);
                frm.ShowDialog();
            }  
            btnXem_Click(sender, e);
        }
    }
}
