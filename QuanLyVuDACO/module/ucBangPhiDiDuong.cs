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
    public partial class ucBangPhiDiDuong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangPhiDiDuong()
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
                DataTable dt = client.BangPhiDiDuong_Xem(Ngay1, Ngay2);
                gridControl2.DataSource = dt;
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
            int IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString().Trim());
            Forms.frmBangPhiDiDuong frm = new Forms.frmBangPhiDiDuong(IDBangPhi);
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
                    //VudacoEntities context = new VudacoEntities();
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        string _check = gridView2.GetRowCellValue(i, "Chon").ToString();
                        if (_check == "True")
                        {
                            int _IDBangPhi = int.Parse(gridView2.GetRowCellValue(i, "IDBangPhi").ToString().Trim());
                            //BangPhiDiDuong table = context.BangPhiDiDuong.Single(p => p.IDBangPhi == _IDBangPhi);
                            //context.BangPhiDiDuong.Remove(table);
                            //context.SaveChanges();
                            ////
                            //var t = context.BangPhiDiDuong_ChiKhac.Where(p => p.IDBangPhi == _IDBangPhi);
                            //foreach (var item in t)
                            //{
                            //    int idct = item.IDCT;
                            //    using (VudacoEntities context1 = new VudacoEntities())
                            //    {
                            //        BangPhiDiDuong_ChiKhac table2 = context1.BangPhiDiDuong_ChiKhac.Single(p => p.IDCT == idct);
                            //        context1.BangPhiDiDuong_ChiKhac.Remove(table2);
                            //        context1.SaveChanges();
                            //    }

                            //}
                            client.BangDiDuong_xoa(_IDBangPhi);
                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }


        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
           
            //xoa bang ke da tao
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
                
                client.BangDiDuong_xoa(_IDBangPhi);
                btnXem_Click(sender, e);
            }
        }

        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
            Form frm = new frmBangPhiDiDuong(_IDBangPhi);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }


        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            Form frm = new frmBangPhiDiDuong();
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemChiKhac_Click(object sender, EventArgs e)
        {
            int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
            Form frm = new frmChiKhac(_IDBangPhi);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath + "/BangPhiDiDuong_LaiXe.xlsx";
                gridView2.ExportToXlsx(path);
            }
        }

        private void repositoryItemHyperKhacChi_Click(object sender, EventArgs e)
        {
            int _IDBangPhi = int.Parse(gridView1.GetFocusedRowCellValue("IDBangPhi").ToString());
            Form frm = new frmChiKhac_Temp(_IDBangPhi);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.FocusedRowHandle >= 0)
                {
                    int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
                    var table1 = client.DSBangPhiDiDuong_Temp_TheoIDBangPhi(_IDBangPhi);
                    gridControl1.DataSource = table1.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (gridView2.FocusedRowHandle >= 0)
                {
                    int _IDBangPhi = int.Parse(gridView2.GetFocusedRowCellValue("IDBangPhi").ToString());
                    var table1 = client.DSBangPhiDiDuong_Temp_TheoIDBangPhi(_IDBangPhi);
                    gridControl1.DataSource = table1.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
    }
}
