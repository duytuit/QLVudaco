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
    public partial class ucChiPhiTraTruoc : DevExpress.XtraEditors.XtraUserControl
    {
        public ucChiPhiTraTruoc()
        {
            InitializeComponent();
            gridView3.OptionsView.ShowGroupPanel = true;
            gridView3.GroupPanelText = "Chi tiết phân bổ chi phí trả trước";
        }
        private void ucLuongLaiXe_Load(object sender, EventArgs e)
        {

          
        }
     
        private void repositoryItemCT_Click(object sender, EventArgs e)
        {
            int _idKhauHao = int.Parse( gridView1.GetFocusedRowCellValue("ID").ToString().Trim());
            frmCapNhatKhauHao frm = new frmCapNhatKhauHao(_idKhauHao);
            frm.ShowDialog();
            LoadKhauHao();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmTaoKhauHao frm = new frmTaoKhauHao(khauhao._khauhaochiphitratruoc);
            frm.ShowDialog();
            LoadKhauHao();
        }
        private void LoadKhauHao()
        {
            using (var kh = new khauhao())
            {
                gridControl1.DataSource = kh.GetKhauHao(khauhao._khauhaochiphitratruoc);
            }
        }

        private void LoadPhanBoKhauHao()
        {
            using (var pbkh = new phanbokhauhao())
            {
                gridControl2.DataSource = pbkh.GetPhanBoKhauHao(khauhao._khauhaochiphitratruoc);
            }
        }
        private void LoadChiTietPhanBoKhauHao(int phanbo)
        {
            using (var pbkh = new phanbokhauhao())
            {
                gridControl3.DataSource = pbkh.GetChiTietPhanBoKhauHao(phanbo);
            }
        }
        private void gridControl1_Load(object sender, EventArgs e)
        {
            LoadKhauHao();
            LoadPhanBoKhauHao();
        }

        private void repositoryItemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                using (var _db = new clsKetNoi())
                {
                    _db.DeleteById("KhauHao", _ID,"ID"); 
                }
                LoadKhauHao();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmPhanBoKhauHao frm = new frmPhanBoKhauHao(khauhao._khauhaochiphitratruoc);
            frm.ShowDialog();
            LoadPhanBoKhauHao();
        }

        private void repositoryItemHyperLinkXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _ID = int.Parse(gridView2.GetFocusedRowCellValue("ID").ToString());
                using (var _db = new clsKetNoi())
                {
                    _db.DeleteById("PhanBoKhauHao", _ID, "ID");
                    _db.DeleteById("PhanBoKhauHao_CT", _ID, "IDPhanBoKhauHao");
                }
                LoadPhanBoKhauHao();
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0) // đảm bảo click vào row hợp lệ
            {
                int _idPhanBo = int.Parse( gridView2.GetRowCellValue(e.RowHandle, "ID").ToString());
                LoadChiTietPhanBoKhauHao(_idPhanBo);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                int _idPhanBo = int.Parse(gridView2.GetRowCellValue(e.FocusedRowHandle, "ID").ToString());
                LoadChiTietPhanBoKhauHao(_idPhanBo);
            }
        }
    }
}
