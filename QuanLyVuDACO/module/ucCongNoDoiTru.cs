using DevExpress.XtraEditors;
using Quản_lý_vudaco.Forms;
using Quản_lý_vudaco.services;
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
    public partial class ucCongNoDoiTru : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCongNoDoiTru()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
        private void ucCongNoDoiTru_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            dtpDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
           // cboKH.Properties.DataSource = client.dsKH();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                LoadDataDoiTru();
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDataDoiTru()
        {
            using (var dt = new doitru())
            {
                string[] arr1 = dtpTuNgay.Text.Split('/');
                string[] arr2 = dtpDenNgay.Text.Split('/');
                if (arr1.Length >= 3 && arr2.Length >= 3 && arr1[0].Trim() != "" && arr2[0].Trim() != "")
                {
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    DateTime Ngay2 = new DateTime(int.Parse(arr2[2]), int.Parse(arr2[1]), int.Parse(arr2[0]));
                    gridControl1.DataSource = dt.GetData(Ngay1, Ngay2);
                }
            }
        }

        private void btnTaoDoiTru_Click(object sender, EventArgs e)
        {
            frmDoiTruCongNo frm = new frmDoiTruCongNo();
            frm.ShowDialog();
            LoadDataDoiTru();
        }

        private void repositoryItemHyperLinkXoa_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    int _ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            //    using (var _db = new clsKetNoi())
            //    {
            //        _db.DeleteById("DoiTruCongNo", _ID, "ID");
            //        DataRow PhieuChi_NCC = _db.GetSingleRecord("PhieuChi_NCC", _ID, "IDDoiTru", true);
            //        if (PhieuChi_NCC != null)
            //        {
            //            _db.DeleteById("PhieuChi_NCC", int.Parse(PhieuChi_NCC["IDPhieuChiNCC"].ToString()), "IDPhieuChiNCC");
            //            _db.DeleteById("PhieuChi_NCC_CT", int.Parse(PhieuChi_NCC["IDPhieuChiNCC"].ToString()), "IDPhieuChi");
            //        }
            //        DataRow PhieuThu = _db.GetSingleRecord("PhieuThu", _ID, "IDDoiTru", true);
            //        if (PhieuThu != null)
            //        {
            //            _db.DeleteById("PhieuThu", int.Parse(PhieuThu["IDPhieuThu"].ToString()), "IDPhieuThu");
            //            _db.DeleteById("PhieuThu_CT", int.Parse(PhieuThu["IDPhieuThu"].ToString()), "IDPhieuThu");
            //        }
            //    }
            //    LoadDataDoiTru();
            //}
        }
    }
}
