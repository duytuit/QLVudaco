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

namespace Quản_lý_vudaco.Forms
{
    public partial class frmDuyetChi : DevExpress.XtraEditors.XtraForm
    {
        public frmDuyetChi()
        {
            InitializeComponent();
        }
        public frmDuyetChi(int IDBangPhi)
        {
            InitializeComponent();
            _IDBangPhi = IDBangPhi;
        }
        public frmDuyetChi(int IDBangPhi,string MaDieuXe)
        {
            InitializeComponent();
            _IDBangPhi = IDBangPhi;
            _MaDieuXe = MaDieuXe;
        }
        int _IDBangPhi = 0;
        string _MaDieuXe = "";
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var table5 = client.BangDiDuong_MaDieuXe(txtMaDieuXe.Text);
                if (table5.Count() > 1)
                    MessageBox.Show("Mã điều xe này đã xác nhận ở một đơn hàng khác!");
                else
                {
                    ServiceReference1.BangPhiDiDuong table = new ServiceReference1.BangPhiDiDuong();
                    table.NguoiDuyet = frmMain._TK;
                    table.IDBangPhi = _IDBangPhi;
                    table.MaDieuXe = txtMaDieuXe.Text;
                    table.DuyetChi = true;
                    table.NguoiDuyet = frmMain._TK;
                    table.ThoiGianDuyet = DateTime.Now;
                    table.PhanHoi = txtNoiDungPhanHoi.Text;
                    client.BangDiDuong_DuyetChi(table);
                    //Đẩy dữ liệu vào Bảng phí đi đường Temp( phần Người duyệt chi nhập số tiền cho phep)
                    #region temp
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        ServiceReference1.BangPhiDiDuong_Temp table1 = new ServiceReference1.BangPhiDiDuong_Temp();
                        table1.Ngay = DateTime.Now;
                        table.NguoiDuyet = frmMain._TK;
                        table.MaDieuXe = txtMaDieuXe.Text;
                        table.DuyetChi = true;
                        table.NguoiDuyet = frmMain._TK;
                        table.NguoiDuyet = frmMain._TK;
                        table.ThoiGianDuyet = DateTime.Now;
                        table.PhanHoi = txtNoiDungPhanHoi.Text;
                        table1.TuyenVC = gridView2.GetRowCellValue(i,"TuyenVC").ToString();
                        table1.LaiXeThuCuoc = (gridView2.GetRowCellValue(i, "LaiXeThuCuoc").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "LaiXeThuCuoc").ToString());
                        table1.TienAn = (gridView2.GetRowCellValue(i, "TienAn").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "TienAn").ToString());
                        table1.TienVe = (gridView2.GetRowCellValue(i, "TienVe").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "TienVe").ToString());
                        table1.QuaDem = (gridView2.GetRowCellValue(i, "QuaDem").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "QuaDem").ToString());
                        table1.TienLuat = (gridView2.GetRowCellValue(i, "TienLuat").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "TienLuat").ToString());
                        table1.LuongHangVe = (gridView2.GetRowCellValue(i, "LuongHangVe").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "LuongHangVe").ToString());
                        table1.NguoiTao = frmMain._TK;
                        table1.GhiChu = gridView2.GetRowCellValue(i, "GhiChu").ToString();
                        table1.DiemTraHang = (gridView2.GetRowCellValue(i, "DiemTraHang").ToString() == "") ? 0 : float.Parse(gridView2.GetRowCellValue(i, "DiemTraHang").ToString());
                        table1.IDBangPhi = int.Parse(gridView2.GetRowCellValue(i, "IDBangPhi").ToString());
                        client.BangDieuXe_Sua2(table.MaDieuXe, table1);
                       
                    }
                   

                    #endregion

                    //update thong tin lai xe qua bangdieuxe
                   
                    simpleButton2_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void frmDuyetChi_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtMaDieuXe.Text = _MaDieuXe;
            var table2 = client.DSBangPhiDiDuong_TheoIDBangPhi(_IDBangPhi);
            gridControl2.DataSource = table2.ToList();
            foreach (var item in table2)
            {
                txtNoiDungPhanHoi.Text = item.PhanHoi;
            }
           
          
        }

        private void repositoryItemChiKhac_Click(object sender, EventArgs e)
        {
            Form frm = new frmChiKhac_Temp(_IDBangPhi);
            frm.ShowDialog();
        }

        private void txtMaDieuXe_EditValueChanged(object sender, EventArgs e)
        {
            //
            gridControl1.DataSource = client.BangDieuXe_TheoMaDieuXe(txtMaDieuXe.Text);
        }
    }
}