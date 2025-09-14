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
    public partial class ucBangLietKeChiPhiBoSung : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangLietKeChiPhiBoSung()
        {
            InitializeComponent();
        }

        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                DataTable dt = client.BangKe_BoSUNG(Ngay1, Ngay2);
                gridControl2.DataSource = dt;
            }

        }


        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle>=0)
            {
               // bool isCheck=bool
            }    
        }

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //tạo file giá tự động
            #region file gia
            int _IDCP = int.Parse(gridView2.GetFocusedRowCellValue("IDCP").ToString());
            int _IDLOHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString());
           
            var table = client.ThongTinFile_TheoIDLoHang(_IDLOHang);
            foreach (var item in table)
            {
                ServiceReference1.FileGia p1 = new ServiceReference1.FileGia();
                p1.IDLoHang = _IDLOHang;
                p1.SoFile = item.SoFile;
                p1.ThoiGianLap = DateTime.Now;
                p1.NguoiLap = frmMain._TK;
                p1.MaDieuXe = "";
                client.LuuFileGia(p1);
                //
                DataTable dtChiTiet = client.DsChiPhiHQ_TheoSoFile_BoSung(p1.SoFile, p1.IDLoHang.Value);
                DataView view = dtChiTiet.Copy().DefaultView;
                view.RowFilter = "IDCP='"+ _IDCP+"'";
                dtChiTiet = view.ToTable();
                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    ServiceReference1.FileGiaChiTiet p2 = new ServiceReference1.FileGiaChiTiet();
                    p2.IDCP = _IDCP;
                    p2.TenDichVu = dtChiTiet.Rows[i]["TenDichVu"].ToString().Trim();
                    if (dtChiTiet.Rows[i]["GiaMua"].ToString().Trim() == "")
                        p2.GiaMua = 0;
                    else
                        p2.GiaMua = double.Parse(dtChiTiet.Rows[i]["GiaMua"].ToString().Trim());

                    if (dtChiTiet.Rows[i]["GiaBan"].ToString().Trim() == "")
                        p2.GiaBan = 0;
                    else
                        p2.GiaBan = double.Parse(dtChiTiet.Rows[i]["GiaBan"].ToString().Trim());
                    p2.GhiChu = dtChiTiet.Rows[i]["GhiChu"].ToString().Trim();
                    if (p2.TenDichVu != "")
                        client.LuuFileGiaChiTiet(p2);
                }
            }

            #endregion
            #region file debit
            var table2 = client.LoadTop1FileGia();
            foreach (var item in table2)
            {
                int _IdGia= item.IDGia;
                Forms.frmFileDebitBoSung frm = new frmFileDebitBoSung(_IDCP, _IDLOHang, _IdGia,0);
                frm.ShowDialog();
               
            }
            #endregion
            btnXem_Click(sender, e);
        }
    }
}
