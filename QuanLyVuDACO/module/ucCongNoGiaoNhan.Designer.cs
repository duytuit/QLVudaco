
namespace Quản_lý_vudaco.module
{
    partial class ucCongNoGiaoNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCongNoGiaoNhan));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboNhanVienGiaoNhan = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXuatExcel = new DevExpress.XtraEditors.SimpleButton();
            this.dtpDenNgay = new System.Windows.Forms.MaskedTextBox();
            this.dtpTuNgay = new System.Windows.Forms.MaskedTextBox();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCT = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Quản_lý_vudaco.frmWait), true, true, typeof(System.Windows.Forms.UserControl), true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhanVienGiaoNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCT)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cboNhanVienGiaoNhan);
            this.panelControl1.Controls.Add(this.btnXuatExcel);
            this.panelControl1.Controls.Add(this.dtpDenNgay);
            this.panelControl1.Controls.Add(this.dtpTuNgay);
            this.panelControl1.Controls.Add(this.btnXem);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1312, 41);
            this.panelControl1.TabIndex = 0;
            // 
            // cboNhanVienGiaoNhan
            // 
            this.cboNhanVienGiaoNhan.EditValue = "Tất cả nhân viên";
            this.cboNhanVienGiaoNhan.Location = new System.Drawing.Point(432, 12);
            this.cboNhanVienGiaoNhan.Name = "cboNhanVienGiaoNhan";
            this.cboNhanVienGiaoNhan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboNhanVienGiaoNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhanVienGiaoNhan.Properties.DisplayMember = "HoVaTen";
            this.cboNhanVienGiaoNhan.Properties.NullText = "Tất cả nhân viên";
            this.cboNhanVienGiaoNhan.Properties.PopupView = this.gridLookUpEdit1View;
            this.cboNhanVienGiaoNhan.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSuggest;
            this.cboNhanVienGiaoNhan.Properties.ValueMember = "TaiKhoan";
            this.cboNhanVienGiaoNhan.Size = new System.Drawing.Size(310, 20);
            this.cboNhanVienGiaoNhan.TabIndex = 13;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tài khoản";
            this.gridColumn1.FieldName = "TaiKhoan";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Họ và tên";
            this.gridColumn2.FieldName = "HoVaTen";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 257;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.ImageOptions.Image")));
            this.btnXuatExcel.Location = new System.Drawing.Point(835, 11);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(81, 24);
            this.btnXuatExcel.TabIndex = 12;
            this.btnXuatExcel.Text = "Xuất Exel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(252, 12);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDenNgay.Mask = "00/00/0000";
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(111, 21);
            this.dtpDenNgay.TabIndex = 11;
            this.dtpDenNgay.ValidatingType = typeof(System.DateTime);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(71, 12);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTuNgay.Mask = "00/00/0000";
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(112, 21);
            this.dtpTuNgay.TabIndex = 10;
            this.dtpTuNgay.ValidatingType = typeof(System.DateTime);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(748, 10);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(81, 24);
            this.btnXem.TabIndex = 9;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(369, 17);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Nhân viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(196, 16);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 14);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Từ ngày";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 41);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1312, 700);
            this.panelControl2.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "BangPhiDiDuong";
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCT});
            this.gridControl1.Size = new System.Drawing.Size(1308, 696);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand5});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSTT,
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7});
            this.bandedGridView1.DetailHeight = 284;
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "THÔNG TIN CHUNG";
            this.gridBand1.Columns.Add(this.colSTT);
            this.gridBand1.Columns.Add(this.bandedGridColumn7);
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 435;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.Width = 57;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "TaiKhoan";
            this.bandedGridColumn7.FieldName = "TaiKhoan";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Tên giao nhận";
            this.bandedGridColumn1.FieldName = "TenGiaoNhan";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 296;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Chi tiết";
            this.bandedGridColumn2.ColumnEdit = this.repositoryItemCT;
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 82;
            // 
            // repositoryItemCT
            // 
            this.repositoryItemCT.AutoHeight = false;
            this.repositoryItemCT.Caption = "Chi tiết";
            this.repositoryItemCT.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemCT.Image")));
            this.repositoryItemCT.Name = "repositoryItemCT";
            this.repositoryItemCT.NullText = "Chi tiết";
            this.repositoryItemCT.Click += new System.EventHandler(this.repositoryItemCT_Click);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "ĐẦU KỲ";
            this.gridBand2.Columns.Add(this.bandedGridColumn3);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 201;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Phí cược";
            this.bandedGridColumn3.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn3.FieldName = "DauKy_PhiCuoc";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DauKy_PhiCuoc", "{0:#,##}")});
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 201;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "PHÁT SINH TRONG KỲ";
            this.gridBand3.Columns.Add(this.bandedGridColumn4);
            this.gridBand3.Columns.Add(this.bandedGridColumn5);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 446;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Phí cược";
            this.bandedGridColumn4.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn4.FieldName = "PhatSinh_PhiCuoc";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhatSinh_PhiCuoc", "{0:#,##}")});
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 167;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Đã hoàn cước";
            this.bandedGridColumn5.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn5.FieldName = "DaHoan_PhiCuoc";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DaHoan_PhiCuoc", "{0:#,##}")});
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 279;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "NỢ CUỐI KỲ";
            this.gridBand5.Columns.Add(this.bandedGridColumn6);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 3;
            this.gridBand5.Width = 171;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "Phí cược";
            this.bandedGridColumn6.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn6.FieldName = "CuoiKy_PhiCuoc";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CuoiKy_PhiCuoc", "{0:#,##}")});
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 171;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // ucCongNoGiaoNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucCongNoGiaoNhan";
            this.Size = new System.Drawing.Size(1312, 741);
            this.Load += new System.EventHandler(this.ucCongNoKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhanVienGiaoNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.MaskedTextBox dtpDenNgay;
        private System.Windows.Forms.MaskedTextBox dtpTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnXuatExcel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTT;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.GridLookUpEdit cboNhanVienGiaoNhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemCT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
    }
}
