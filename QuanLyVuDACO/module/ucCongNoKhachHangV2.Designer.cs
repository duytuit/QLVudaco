
namespace Quản_lý_vudaco.module
{
    partial class ucCongNoKhachHangV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCongNoKhachHangV2));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboKH = new DevExpress.XtraEditors.GridLookUpEdit();
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
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCT = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Quản_lý_vudaco.frmWait), true, true, typeof(System.Windows.Forms.UserControl), true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKH.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.cboKH);
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
            this.panelControl1.Size = new System.Drawing.Size(1800, 41);
            this.panelControl1.TabIndex = 0;
            // 
            // cboKH
            // 
            this.cboKH.EditValue = "Tất cả khách";
            this.cboKH.Location = new System.Drawing.Point(436, 12);
            this.cboKH.Name = "cboKH";
            this.cboKH.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKH.Properties.DisplayMember = "TenVietTat";
            this.cboKH.Properties.NullText = "Tất cả khách";
            this.cboKH.Properties.PopupView = this.gridLookUpEdit1View;
            this.cboKH.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSuggest;
            this.cboKH.Properties.ValueMember = "MaKhachHang";
            this.cboKH.Size = new System.Drawing.Size(310, 20);
            this.cboKH.TabIndex = 14;
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
            this.gridColumn1.Caption = "Mã khách hàng";
            this.gridColumn1.FieldName = "MaKhachHang";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên viết tắt";
            this.gridColumn2.FieldName = "TenVietTat";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 257;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.ImageOptions.Image")));
            this.btnXuatExcel.Location = new System.Drawing.Point(843, 11);
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
            this.btnXem.Location = new System.Drawing.Point(756, 10);
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
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Khách hàng";
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
            this.panelControl2.Size = new System.Drawing.Size(1800, 700);
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
            this.gridControl1.Size = new System.Drawing.Size(1796, 696);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSTT,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn9,
            this.bandedGridColumn10,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn1,
            this.bandedGridColumn8,
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
            this.gridBand1.Columns.Add(this.bandedGridColumn10);
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 541;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.Width = 56;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.Caption = "Khách hàng";
            this.bandedGridColumn10.FieldName = "TenVietTat";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TenVietTat", "TỔNG CỘNG")});
            this.bandedGridColumn10.Visible = true;
            this.bandedGridColumn10.Width = 355;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.ColumnEdit = this.repositoryItemCT;
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 130;
            // 
            // repositoryItemCT
            // 
            this.repositoryItemCT.AutoHeight = false;
            this.repositoryItemCT.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemCT.Image")));
            this.repositoryItemCT.Name = "repositoryItemCT";
            this.repositoryItemCT.NullText = "Chi tiết";
            this.repositoryItemCT.Click += new System.EventHandler(this.repositoryItemCT_Click_1);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "ĐẦU KÌ";
            this.gridBand2.Columns.Add(this.bandedGridColumn11);
            this.gridBand2.Columns.Add(this.bandedGridColumn12);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 288;
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.Caption = "Phí dịch vụ DK";
            this.bandedGridColumn11.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn11.FieldName = "KHDVDK";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KHDVDK", "{0:#,##}")});
            this.bandedGridColumn11.Visible = true;
            this.bandedGridColumn11.Width = 143;
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.Caption = "Phí chi hộ DK";
            this.bandedGridColumn12.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn12.FieldName = "KHCHDK";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KHCHDK", "{0:#,##}")});
            this.bandedGridColumn12.Visible = true;
            this.bandedGridColumn12.Width = 145;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "PHÁT SINH TRONG KÌ";
            this.gridBand3.Columns.Add(this.bandedGridColumn2);
            this.gridBand3.Columns.Add(this.bandedGridColumn3);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 281;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Phí dịch vụ TK";
            this.bandedGridColumn2.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn2.FieldName = "KHDVTK";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KHDVTK", "{0:#,##}")});
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 140;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Phí chi hộ TK";
            this.bandedGridColumn3.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn3.FieldName = "KHCHTK";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KHCHTK", "{0:#,##}")});
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 141;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "THANH TOÁN TRONG KÌ";
            this.gridBand4.Columns.Add(this.bandedGridColumn6);
            this.gridBand4.Columns.Add(this.bandedGridColumn4);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 278;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "Phí dịch vụ TTTK";
            this.bandedGridColumn6.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn6.FieldName = "KHTTDVTK";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KHTTDVTK", "{0:#,##}")});
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 137;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Phí chi hộ TTTK";
            this.bandedGridColumn4.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn4.FieldName = "KHTTCHTK";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KHTTCHTK", "{0:#,##}")});
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 141;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "NỢ CUỐI KỲ";
            this.gridBand5.Columns.Add(this.bandedGridColumn9);
            this.gridBand5.Columns.Add(this.bandedGridColumn5);
            this.gridBand5.Columns.Add(this.bandedGridColumn7);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 308;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "Phí dịch vụ DK";
            this.bandedGridColumn9.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn9.FieldName = "DVCK";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DVCK", "{0:#,##}")});
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.Width = 122;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Phí chi hộ CK";
            this.bandedGridColumn5.DisplayFormat.FormatString = "#,##";
            this.bandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn5.FieldName = "CHCK";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CHCK", "{0:#,##}")});
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 111;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "Còn Lại";
            this.bandedGridColumn7.DisplayFormat.FormatString = "{0:#,##}";
            this.bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn7.FieldName = "ConLai";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ConLai", "{0:#,##}")});
            this.bandedGridColumn7.Visible = true;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "bandedGridColumn8";
            this.bandedGridColumn8.ColumnEdit = this.repositoryItemCT;
            this.bandedGridColumn8.FieldName = "MaKhachHang";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // ucCongNoKhachHangV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucCongNoKhachHangV2";
            this.Size = new System.Drawing.Size(1800, 741);
            this.Load += new System.EventHandler(this.ucCongNoKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKH.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.GridLookUpEdit cboKH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemCT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
    }
}
