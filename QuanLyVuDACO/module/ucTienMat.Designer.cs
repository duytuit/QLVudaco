
namespace Quản_lý_vudaco.module
{
    partial class ucTienMat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTienMat));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.ucPhieuThu = new DevExpress.XtraNavBar.NavBarItem();
            this.ucPhieuThuHoanCuoc = new DevExpress.XtraNavBar.NavBarItem();
            this.ucPhieuThuHoanUngLaiXe = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.ucPhieuTamThuBangPhoi = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.ucPhieuChi = new DevExpress.XtraNavBar.NavBarItem();
            this.ucPhieuChiNCC = new DevExpress.XtraNavBar.NavBarItem();
            this.ucPhieuChiTamUngLaiXe = new DevExpress.XtraNavBar.NavBarItem();
            this.ucChiNoiBo = new DevExpress.XtraNavBar.NavBarItem();
            this.ucPhieuChiCon = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.panelCha = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCha)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelCha);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1104, 615);
            this.splitContainerControl1.SplitterPosition = 237;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup2;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.ucPhieuThu,
            this.ucPhieuThuHoanCuoc,
            this.ucPhieuChi,
            this.ucPhieuChiNCC,
            this.navBarItem2,
            this.ucPhieuChiTamUngLaiXe,
            this.ucPhieuThuHoanUngLaiXe,
            this.ucChiNoiBo,
            this.navBarItem3,
            this.ucPhieuChiCon,
            this.ucPhieuTamThuBangPhoi});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 237;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(237, 615);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator();
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Danh mục thu";
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.ImageOptions.LargeImage")));
            this.navBarGroup1.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.ImageOptions.SmallImage")));
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuThu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuThuHoanCuoc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuThuHoanUngLaiXe),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuTamThuBangPhoi)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // ucPhieuThu
            // 
            this.ucPhieuThu.Caption = "Phiếu thu";
            this.ucPhieuThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuThu.ImageOptions.SvgImage")));
            this.ucPhieuThu.Name = "ucPhieuThu";
            this.ucPhieuThu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuThu_LinkClicked);
            // 
            // ucPhieuThuHoanCuoc
            // 
            this.ucPhieuThuHoanCuoc.Caption = "Thu tiền hoàn cước giao nhận";
            this.ucPhieuThuHoanCuoc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuThuHoanCuoc.ImageOptions.SvgImage")));
            this.ucPhieuThuHoanCuoc.Name = "ucPhieuThuHoanCuoc";
            this.ucPhieuThuHoanCuoc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuThuHoanCuoc_LinkClicked);
            // 
            // ucPhieuThuHoanUngLaiXe
            // 
            this.ucPhieuThuHoanUngLaiXe.Caption = "Thu hoàn ứng lái xe";
            this.ucPhieuThuHoanUngLaiXe.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuThuHoanUngLaiXe.ImageOptions.SvgImage")));
            this.ucPhieuThuHoanUngLaiXe.Name = "ucPhieuThuHoanUngLaiXe";
            this.ucPhieuThuHoanUngLaiXe.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuThuHoanUngLaiXe_LinkClicked);
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Thu nội bộ";
            this.navBarItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItem3.ImageOptions.LargeImage")));
            this.navBarItem3.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem3.ImageOptions.SmallImage")));
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem3_LinkClicked);
            // 
            // ucPhieuTamThuBangPhoi
            // 
            this.ucPhieuTamThuBangPhoi.Caption = "Phiếu tạm thu bảng phơi";
            this.ucPhieuTamThuBangPhoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ucPhieuTamThuBangPhoi.ImageOptions.LargeImage")));
            this.ucPhieuTamThuBangPhoi.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("ucPhieuTamThuBangPhoi.ImageOptions.SmallImage")));
            this.ucPhieuTamThuBangPhoi.Name = "ucPhieuTamThuBangPhoi";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Danh mục chi";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.ImageOptions.LargeImage")));
            this.navBarGroup2.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.ImageOptions.SmallImage")));
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuChi),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuChiNCC),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuChiTamUngLaiXe),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucChiNoiBo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ucPhieuChiCon)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // ucPhieuChi
            // 
            this.ucPhieuChi.Caption = "Phiếu chi";
            this.ucPhieuChi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuChi.ImageOptions.SvgImage")));
            this.ucPhieuChi.Name = "ucPhieuChi";
            this.ucPhieuChi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuChi_LinkClicked);
            // 
            // ucPhieuChiNCC
            // 
            this.ucPhieuChiNCC.Caption = "Trả tiền nhà cung cấp";
            this.ucPhieuChiNCC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuChiNCC.ImageOptions.SvgImage")));
            this.ucPhieuChiNCC.Name = "ucPhieuChiNCC";
            this.ucPhieuChiNCC.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuChiNCC_LinkClicked);
            // 
            // ucPhieuChiTamUngLaiXe
            // 
            this.ucPhieuChiTamUngLaiXe.Caption = "Chi tạm ứng lái xe";
            this.ucPhieuChiTamUngLaiXe.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuChiTamUngLaiXe.ImageOptions.SvgImage")));
            this.ucPhieuChiTamUngLaiXe.Name = "ucPhieuChiTamUngLaiXe";
            this.ucPhieuChiTamUngLaiXe.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuChiTamUngLaiXe_LinkClicked);
            // 
            // ucChiNoiBo
            // 
            this.ucChiNoiBo.Caption = "Chi nội bộ";
            this.ucChiNoiBo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucChiNoiBo.ImageOptions.SvgImage")));
            this.ucChiNoiBo.Name = "ucChiNoiBo";
            this.ucChiNoiBo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucChiNoiBo_LinkClicked);
            // 
            // ucPhieuChiCon
            // 
            this.ucPhieuChiCon.Caption = "Phiếu chi chi tiết";
            this.ucPhieuChiCon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ucPhieuChiCon.ImageOptions.SvgImage")));
            this.ucPhieuChiCon.Name = "ucPhieuChiCon";
            this.ucPhieuChiCon.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ucPhieuChiCon_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Khác";
            this.navBarGroup3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.ImageOptions.LargeImage")));
            this.navBarGroup3.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.ImageOptions.SmallImage")));
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Chuyển tiền nội bộ";
            this.navBarItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItem2.ImageOptions.SvgImage")));
            this.navBarItem2.Name = "navBarItem2";
            // 
            // panelCha
            // 
            this.panelCha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCha.Location = new System.Drawing.Point(0, 0);
            this.panelCha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCha.Name = "panelCha";
            this.panelCha.Size = new System.Drawing.Size(857, 615);
            this.panelCha.TabIndex = 0;
            // 
            // ucTienMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucTienMat";
            this.Size = new System.Drawing.Size(1104, 615);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuThu;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuThuHoanCuoc;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuChi;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuChiNCC;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraEditors.PanelControl panelCha;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuChiTamUngLaiXe;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuThuHoanUngLaiXe;
        private DevExpress.XtraNavBar.NavBarItem ucChiNoiBo;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuChiCon;
        private DevExpress.XtraNavBar.NavBarItem ucPhieuTamThuBangPhoi;
    }
}
