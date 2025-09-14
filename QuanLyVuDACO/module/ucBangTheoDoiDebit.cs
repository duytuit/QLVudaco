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
    public partial class ucBangTheoDoiDebit : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangTheoDoiDebit()
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
                gridControl1.DataSource = client.BangFileGiaChuaTaoDebit_Xem(Ngay1, Ngay2);

                gridControl2.DataSource = client.dt_BangFileDebitDaTao(Ngay1, Ngay2);
            }
           
           
        }

      

        private void repositoryItemSua_Click(object sender, EventArgs e)
        {
            int _IDLoHang = int.Parse(gridView2.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            int _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString().Trim());
            Forms.frmFileDebit frm = new Forms.frmFileDebit(_IDDeBit, _IDLoHang,0, 1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
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
                            int _IDGia = int.Parse(gridView1.GetRowCellValue(i, "IDGia").ToString().Trim());
                            client.XoaFileDebit(_IDGia);
                        }

                    }
                    btnXem_Click(sender, e);
                }
            }
        }

        private void repositoryItemThem_Click(object sender, EventArgs e)
        {
            //them bang chi phi
            int _IDGia = int.Parse(gridView1.GetFocusedRowCellValue("IDGia").ToString().Trim());
            int _IDLoHang = int.Parse(gridView1.GetFocusedRowCellValue("IDLoHang").ToString().Trim());
            Form frm = new frmFileDebit(_IDLoHang,_IDGia,0);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

       

        private void repositoryItemSua_Click_1(object sender, EventArgs e)
        {
            int _IDGia = int.Parse(gridView2.GetFocusedRowCellValue("IDGia").ToString());
            Form frm = new frmFileDebit(_IDGia, 1);
            frm.ShowDialog();
            btnXem_Click(sender, e);
        }

        private void repositoryItemIn_Click(object sender, EventArgs e)
        {
            //reports.rpt_BangKe_ChiHo rpt = new reports.rpt_BangKe_ChiHo();
            //rpt.ShowPreview();
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString());
            DataTable dt = client.DsFileDebit_IDDEDIT_In(_IDDeBit);
            reports.rpt_FileDebit rpt = new reports.rpt_FileDebit();
            rpt.DataSource = dt;
            rpt.ShowPreview();

        }
        int _IDDeBit = 0;
        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridView2.FocusedRowHandle>=0)
                {
                    ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                    _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString());
                    gridControl3.DataSource = client.BangFileDebitDaTao_ChiTiet(_IDDeBit);
                }
               
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if(e.RowHandle>=0)
            {
                ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString());
                gridControl3.DataSource = client.BangFileDebitDaTao_ChiTiet(_IDDeBit);
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
                _IDDeBit = int.Parse(gridView2.GetFocusedRowCellValue("IDDeBit").ToString());
                client.XoaFileDebit(_IDDeBit);
                ucBangTheoDoiSoFile_Load(sender, e);
            }
        }
    }
}
