
namespace Quản_lý_vudaco.module
{
    partial class ucCongNoNhaCungCapV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCongNoNhaCungCapV2));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboNCC = new DevExpress.XtraEditors.GridLookUpEdit();
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
            this.colMaNhaCungCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colChiTiet = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCT = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.DVdauky = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colThanhToanDVDK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NHdauky = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colThanhToanNangHaDK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.DVtrongky = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NHtrongky = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TTdichvu = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TTnangha = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.CuoikyDV = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CuoikyNH = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TongNoConLai = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Quản_lý_vudaco.frmWait), true, true, typeof(System.Windows.Forms.UserControl), true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNCC.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.cboNCC);
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
            // cboNCC
            // 
            this.cboNCC.EditValue = "Tất cả khách";
            this.cboNCC.Location = new System.Drawing.Point(438, 12);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboNCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNCC.Properties.DisplayMember = "TenVietTat";
            this.cboNCC.Properties.NullText = "Tất cả nhà cung cấp";
            this.cboNCC.Properties.PopupView = this.gridLookUpEdit1View;
            this.cboNCC.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSuggest;
            this.cboNCC.Properties.ValueMember = "MaNhaCungCap";
            this.cboNCC.Size = new System.Drawing.Size(310, 20);
            this.cboNCC.TabIndex = 13;
            this.cboNCC.EditValueChanged += new System.EventHandler(this.cboNCC_EditValueChanged);
            this.cboNCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboNCC_KeyDown);
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
            this.gridColumn1.Caption = "Mã nhà cung cấp";
            this.gridColumn1.FieldName = "MaNhaCungCap";
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
            this.labelControl3.Size = new System.Drawing.Size(65, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Nhà cung cấp";
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
            this.gridBand4,
            this.gridBand5});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSTT,
            this.colMaNhaCungCap,
            this.colChiTiet,
            this.DVdauky,
            this.NHdauky,
            this.DVtrongky,
            this.NHtrongky,
            this.TTdichvu,
            this.TTnangha,
            this.CuoikyDV,
            this.CuoikyNH,
            this.TongNoConLai,
            this.colThanhToanDVDK,
            this.colThanhToanNangHaDK});
            this.bandedGridView1.DetailHeight = 284;
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "THÔNG TIN CHUNG";
            this.gridBand1.Columns.Add(this.colSTT);
            this.gridBand1.Columns.Add(this.colMaNhaCungCap);
            this.gridBand1.Columns.Add(this.colChiTiet);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 317;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "colSTT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            // 
            // colMaNhaCungCap
            // 
            this.colMaNhaCungCap.Caption = "Nhà Cung Cấp";
            this.colMaNhaCungCap.FieldName = "MaNhaCungCap";
            this.colMaNhaCungCap.Name = "colMaNhaCungCap";
            this.colMaNhaCungCap.Visible = true;
            this.colMaNhaCungCap.Width = 167;
            // 
            // colChiTiet
            // 
            this.colChiTiet.Caption = "Chi Tiết";
            this.colChiTiet.ColumnEdit = this.repositoryItemCT;
            this.colChiTiet.Name = "colChiTiet";
            this.colChiTiet.Visible = true;
            // 
            // repositoryItemCT
            // 
            this.repositoryItemCT.AutoHeight = false;
            this.repositoryItemCT.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemCT.Image")));
            this.repositoryItemCT.Name = "repositoryItemCT";
            this.repositoryItemCT.NullText = "Chi tiết";
            this.repositoryItemCT.Click += new System.EventHandler(this.repositoryItemCT_Click);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "ĐẦU KÌ";
            this.gridBand2.Columns.Add(this.DVdauky);
            this.gridBand2.Columns.Add(this.colThanhToanDVDK);
            this.gridBand2.Columns.Add(this.NHdauky);
            this.gridBand2.Columns.Add(this.colThanhToanNangHaDK);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 300;
            // 
            // DVdauky
            // 
            this.DVdauky.Caption = "Dịch Vụ DK";
            this.DVdauky.DisplayFormat.FormatString = "{0:#,##}";
            this.DVdauky.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DVdauky.FieldName = "DichVuDk";
            this.DVdauky.Name = "DVdauky";
            this.DVdauky.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DichVuDk", "{0:#,##}")});
            this.DVdauky.Visible = true;
            // 
            // colThanhToanDVDK
            // 
            this.colThanhToanDVDK.Caption = "TT Dich Vu DK";
            this.colThanhToanDVDK.DisplayFormat.FormatString = "{0:#,##}";
            this.colThanhToanDVDK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThanhToanDVDK.FieldName = "DichVuTTDK";
            this.colThanhToanDVDK.Name = "colThanhToanDVDK";
            this.colThanhToanDVDK.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DichVuTTDK", "{0:#,##}")});
            this.colThanhToanDVDK.Visible = true;
            // 
            // NHdauky
            // 
            this.NHdauky.Caption = "Nâng Hạ DK";
            this.NHdauky.DisplayFormat.FormatString = "{0:#,##}";
            this.NHdauky.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NHdauky.FieldName = "NangHaDk";
            this.NHdauky.Name = "NHdauky";
            this.NHdauky.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NangHaDk", "{0:#,##}")});
            this.NHdauky.Visible = true;
            // 
            // colThanhToanNangHaDK
            // 
            this.colThanhToanNangHaDK.Caption = "TT Nang Ha DK";
            this.colThanhToanNangHaDK.DisplayFormat.FormatString = "{0:#,##}";
            this.colThanhToanNangHaDK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThanhToanNangHaDK.FieldName = "NangHaTTDK";
            this.colThanhToanNangHaDK.Name = "colThanhToanNangHaDK";
            this.colThanhToanNangHaDK.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NangHaTTDK", "{0:#,##}")});
            this.colThanhToanNangHaDK.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "PHÁT SINH TRONG KÌ";
            this.gridBand3.Columns.Add(this.DVtrongky);
            this.gridBand3.Columns.Add(this.NHtrongky);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 150;
            // 
            // DVtrongky
            // 
            this.DVtrongky.Caption = "Dịch Vụ TK";
            this.DVtrongky.DisplayFormat.FormatString = "{0:#,##}";
            this.DVtrongky.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DVtrongky.FieldName = "DichVuTK";
            this.DVtrongky.Name = "DVtrongky";
            this.DVtrongky.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DichVuTK", "{0:#,##}")});
            this.DVtrongky.Visible = true;
            // 
            // NHtrongky
            // 
            this.NHtrongky.Caption = "Nâng Hạ TK";
            this.NHtrongky.DisplayFormat.FormatString = "{0:#,##}";
            this.NHtrongky.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NHtrongky.FieldName = "NangHaTK";
            this.NHtrongky.Name = "NHtrongky";
            this.NHtrongky.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NangHaTK", "{0:#,##}")});
            this.NHtrongky.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "THANH TOÁN TRONG KÌ";
            this.gridBand4.Columns.Add(this.TTdichvu);
            this.gridBand4.Columns.Add(this.TTnangha);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 150;
            // 
            // TTdichvu
            // 
            this.TTdichvu.Caption = "Dịch Vụ TT";
            this.TTdichvu.DisplayFormat.FormatString = "{0:#,##}";
            this.TTdichvu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TTdichvu.FieldName = "DichVuTT";
            this.TTdichvu.Name = "TTdichvu";
            this.TTdichvu.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DichVuTT", "{0:#,##}")});
            this.TTdichvu.Visible = true;
            // 
            // TTnangha
            // 
            this.TTnangha.Caption = "Nâng Hạ TT";
            this.TTnangha.DisplayFormat.FormatString = "{0:#,##}";
            this.TTnangha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TTnangha.FieldName = "NangHaTT";
            this.TTnangha.Name = "TTnangha";
            this.TTnangha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NangHaTT", "{0:#,##}")});
            this.TTnangha.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "NỢ CUỐI KỲ";
            this.gridBand5.Columns.Add(this.CuoikyDV);
            this.gridBand5.Columns.Add(this.CuoikyNH);
            this.gridBand5.Columns.Add(this.TongNoConLai);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 225;
            // 
            // CuoikyDV
            // 
            this.CuoikyDV.Caption = "Dịch Vụ CK";
            this.CuoikyDV.DisplayFormat.FormatString = "{0:#,##}";
            this.CuoikyDV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CuoikyDV.FieldName = "DichVuCK";
            this.CuoikyDV.Name = "CuoikyDV";
            this.CuoikyDV.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DichVuCK", "{0:#,##}")});
            this.CuoikyDV.Visible = true;
            // 
            // CuoikyNH
            // 
            this.CuoikyNH.Caption = "Nâng Hạ CK";
            this.CuoikyNH.DisplayFormat.FormatString = "{0:#,##}";
            this.CuoikyNH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CuoikyNH.FieldName = "NangHaCK";
            this.CuoikyNH.Name = "CuoikyNH";
            this.CuoikyNH.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NangHaCK", "{0:#,##}")});
            this.CuoikyNH.Visible = true;
            // 
            // TongNoConLai
            // 
            this.TongNoConLai.Caption = "Tổng Nợ Còn Lại";
            this.TongNoConLai.DisplayFormat.FormatString = "{0:#,##}";
            this.TongNoConLai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TongNoConLai.FieldName = "ConLai";
            this.TongNoConLai.Name = "TongNoConLai";
            this.TongNoConLai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ConLai", "{0:#,##}")});
            this.TongNoConLai.Visible = true;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // ucCongNoNhaCungCapV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucCongNoNhaCungCapV2";
            this.Size = new System.Drawing.Size(1800, 741);
            this.Load += new System.EventHandler(this.ucCongNoKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNCC.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemCT;
        private DevExpress.XtraEditors.GridLookUpEdit cboNCC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMaNhaCungCap;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colChiTiet;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DVdauky;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NHdauky;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DVtrongky;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NHtrongky;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TTdichvu;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TTnangha;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CuoikyDV;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CuoikyNH;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TongNoConLai;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colThanhToanDVDK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colThanhToanNangHaDK;
    }
}
