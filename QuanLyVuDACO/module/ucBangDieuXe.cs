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

namespace Quản_lý_vudaco.module
{
    public partial class ucBangDieuXe : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangDieuXe()
        {
            InitializeComponent();
            colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            colSTT2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
        }
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
        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnXem_Click(sender, e);
        }
        private void LoadBangFile()
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                gridControl3.DataSource = client.ThongTinFileChuaLapBangKe(Ngay1, Ngay2);
            }
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            LoadBangFile();
            string[] arr1 = dtpTuNgay.Text.Split('/');
            string[] arr2 = dtpDenNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr2.Length >= 3&&arr1[0].Trim()!=""&&arr2[0].Trim()!="")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                var table = client.DSBangPhiDiDuong_DuyetChi(Ngay1, Ngay2);
                gridControl1.DataSource = table.ToList();
                var table1 = client.BangDieuXe_Xem(Ngay1, Ngay2);
                gridControl2.DataSource = table1.ToList();
            }
          
           
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form frm =new Forms.frmBangTheoDoiSoFile();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDBangPhi").ToString().Trim());
            Forms.frmBangTheoDoiSoFile frm = new Forms.frmBangTheoDoiSoFile(_IDLoHang);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }
       
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (frmMain._TK != "admin")
                MessageBox.Show("Chỉ Admin mới có quyền này");
            else
            {
               
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                   // VudacoEntities context = new VudacoEntities();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string _check = gridView1.GetRowCellValue(i, "Chon").ToString();
                        if (_check == "True")
                        {
                            int _IDLoHang = int.Parse(gridView1.GetRowCellValue(i, "IDLoHang").ToString().Trim());
                            //ThongTinFile table = context.ThongTinFile.Single(p => p.IDLoHang == _IDLoHang);
                            //context.ThongTinFile.Remove(table);
                            //context.SaveChanges();
                          string _MaDieuXe=  gridView1.GetRowCellValue(i, "MaDieuXe").ToString().Trim();
                            if(!client.FileDebit_KoHoaDon_KH_TheoMaDieuXe(_MaDieuXe))
                            client.XoaThongTinFile(_IDLoHang);
                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //Duyet chi lai xe
            if (_MaDieuXe == "")
                MessageBox.Show("Vui lòng Click chọn 1 mã điều xe trước khi duyệt chi!");
            else
            {
                int _IDBangPhi = int.Parse(gridView1.GetFocusedRowCellValue("IDBangPhi").ToString().Trim());
                frmDuyetChi frm = new frmDuyetChi(_IDBangPhi, _MaDieuXe);
                frm.ShowDialog();
                _MaDieuXe = "";
                btnXem_Click(sender, e);
            }
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
           // VudacoEntities context = new VudacoEntities();
            //xoa bang ke da tao
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
                bool check = client.BangDieuXe_KiemTraFileGia(_IDBangPhi);
                if (check)
                    MessageBox.Show("Bảng nhật kí này có dữ liệu liên quan file giá, vui lòng xóa ở file giá trước để tiếp tục!");
                else
                {
                    string _MaDieuXe = gridView2.GetFocusedRowCellValue( "MaDieuXe").ToString().Trim();
                    if (!client.FileDebit_KoHoaDon_KH_TheoMaDieuXe(_MaDieuXe))
                    {
                        client.XoaBangDieuXe(_IDBangPhi);
                        btnXem_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Bạn ko được phép sửa/xoá do đã tạo debit!");
                }
            }
        }

        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            //string _MaDieuXe = gridView2.GetFocusedRowCellValue("MaDieuXe").ToString().Trim();
            //if (!client.FileDebit_KoHoaDon_KH_TheoMaDieuXe(_MaDieuXe))
            //{
                int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
                Form frm = new frmBangDieuXe(_IDBangPhi);
                frm.ShowDialog();
                btnXem_Click(sender, e);
            //}
           // else
             //   MessageBox.Show("Bạn ko được phép sửa/xoá do đã tạo debit!");
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            reports.rpt_BangKe rpt = new reports.rpt_BangKe();
            rpt.ShowPreview();
        }

        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            //them khong file
            Form frm = new frmBangDieuXe();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemFile_Click(object sender, EventArgs e)
        {
            string _file = gridView3.GetFocusedRowCellDisplayText("SoFile");
            Form frm = new frmBangDieuXe(_file);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemChiKhac_Click(object sender, EventArgs e)
        {
            int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
            Form frm = new frmDieuXe_ChiKhac(_IDBangPhi);
            frm.ShowDialog();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                gridView2.ExportToXlsx(dialog.SelectedPath+"/BangNhatKyHangNgay.xlsx");
        }
        string _MaDieuXe = "";
        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                _MaDieuXe = gridView2.GetFocusedRowCellDisplayText("MaDieuXe").ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                _MaDieuXe = gridView2.GetFocusedRowCellDisplayText("MaDieuXe").ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
