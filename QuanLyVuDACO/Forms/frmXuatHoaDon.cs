using DevExpress.XtraEditors;
using Quản_lý_vudaco.module;
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
    public partial class frmXuatHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public frmXuatHoaDon()
        {
            InitializeComponent();
        }

        private void frmXuatHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgay.DateTime = DateTime.Now;
            this.CenterToScreen();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ucBangTheoDoiDebit_File._SoHoaDon = "";
            ucBangTheoDoiDebit_File._NgayXuatHD = new DateTime(1900, 1, 1);
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpNgay.EditValue == null)
                MessageBox.Show("Vui lòng chọn ngày xuất hoá đơn!");
            else if (txtSoHoaDon.Text == "")
                MessageBox.Show("Vui lòng nhập số hoá đơn cần xuất!");
            else
            {
                ucBangTheoDoiDebit_File._SoHoaDon = txtSoHoaDon.Text.Trim();
                ucBangTheoDoiDebit_File._NgayXuatHD = dtpNgay.DateTime;
                this.Close();
            }    
        }
    }
}