using DevExpress.XtraEditors;
using Quản_lý_vudaco.services;
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

namespace Quản_lý_vudaco.module
{
    public partial class ucBangTheoDoiSoFile : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTheoDoiSoFile()
        {
            InitializeComponent();
        }

        private void ucBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (frmMain._TK.ToLower()!="admin"&&frmMain._TK.ToLower()!="phanhuyen")
            {
                btnXoa.Enabled = false;
                btnThemMoi.Enabled = false;
                gridColumn1.Visible = false;
            }


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

                gridControl1.DataSource = client.DsThongTinFile(Ngay1, Ngay2);
                //using (var _ncc = new ncc())
                //{
                //    gridControl1.DataSource = _ncc.DsThongTinFile(Ngay1, Ngay2);
                //}
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
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            //int check = client.KiemTra_File_CoLapBangKeCP(_IDLoHang);
            //if (check == 0)
            //{
                Forms.frmBangTheoDoiSoFile frm = new Forms.frmBangTheoDoiSoFile(_IDLoHang);
                frm.ShowDialog();
                btnXem_Click(sender, e);
           // }   
            //else
             //   MessageBox.Show("Lô hàng: " + _IDLoHang.ToString() + " - Số file: " + gridView1.GetFocusedRowCellValue("SoFile").ToString().Trim() + " đã tạo bảng kê chi phí nên không thể xoá,sửa!");
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (frmMain._TK != "admin")
                MessageBox.Show("Chỉ Admin mới có quyền này");
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string _check = gridView1.GetRowCellValue(i, "Chon").ToString();
                        if (_check == "True")
                        {
                            int _IDLoHang = int.Parse(gridView1.GetRowCellValue(i, "IDLoHang").ToString().Trim());
                            int check = client.KiemTra_File_CoLapBangKeCP(_IDLoHang);
                            if (check == 0)
                            {
                                client.XoaThongTinFile(_IDLoHang);
                                ServiceReference1.ThongTinFile_NguoiGiaoNhan p11 = new ServiceReference1.ThongTinFile_NguoiGiaoNhan();
                                p11.SoFile = gridView1.GetRowCellValue(i, "SoFile").ToString().Trim();
                                client.XoaDanhSachNguoiGiaoNhan(p11);
                            }    
                               
                            else
                                MessageBox.Show("Lô hàng: "+ _IDLoHang.ToString()+" - Số file: "+ gridView1.GetRowCellDisplayText(i, "SoFile").ToString().Trim()+" đã tạo bảng kê chi phí nên không thể xoá,sửa!");


                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                string path = dialog.SelectedPath + "/ThongTinFile.xlsx";
                gridView1.ExportToXlsx(path);
            }    
        }
    }
}
