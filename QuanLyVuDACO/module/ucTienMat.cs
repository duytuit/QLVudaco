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

namespace Quản_lý_vudaco.module
{
    public partial class ucTienMat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTienMat()
        {
            InitializeComponent();
        }

        private void ucPhieuChi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuChi p = new ucPhieuChi();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucPhieuThu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuThu p = new ucPhieuThu();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucPhieuChiNCC_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuChiNCC p = new ucPhieuChiNCC();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucPhieuThuHoanCuoc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuThuHoanCuoc p = new ucPhieuThuHoanCuoc();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucPhieuChiTamUngLaiXe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuChiTamUngLaiXe p = new ucPhieuChiTamUngLaiXe();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucPhieuThuHoanUngLaiXe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuThuHoanUngLaiXe p = new ucPhieuThuHoanUngLaiXe();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucChiNoiBo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucChiNoiBo p = new ucChiNoiBo();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuThuNoiBo p = new ucPhieuThuNoiBo();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }

        private void ucPhieuChiCon_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelCha.Controls.Clear();
            ucPhieuChiCon p = new ucPhieuChiCon();
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(p);
        }
    }
}
