
namespace Quản_lý_vudaco.Forms
{
    partial class frmCongNoNCC_CT_V3
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongNoNCC_CT_V3));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColSoFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoToKhai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColSoNill = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCont = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChiNangha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUngTruocNcc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPhieuThu = new DevExpress.XtraEditors.SimpleButton();
            this.lbducodauky = new DevExpress.XtraEditors.LabelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Quản_lý_vudaco.frmWait), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1870, 685);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 39);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1866, 644);
            this.panelControl3.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "BangPhiDiDuong";
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1862, 640);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.ColSoFile,
            this.colSoToKhai,
            this.ColSoNill,
            this.colSoCont,
            this.colTongCong,
            this.colChiNangha,
            this.colUngTruocNcc,
            this.gridColumn1,
            this.colChon,
            this.colType,
            this.gridColumn2});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData_1);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "STT";
            this.gridColumn3.FieldName = "STT";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 37;
            // 
            // ColSoFile
            // 
            this.ColSoFile.Caption = "Số File";
            this.ColSoFile.FieldName = "SoFile";
            this.ColSoFile.Name = "ColSoFile";
            this.ColSoFile.Visible = true;
            this.ColSoFile.VisibleIndex = 1;
            this.ColSoFile.Width = 108;
            // 
            // colSoToKhai
            // 
            this.colSoToKhai.Caption = "Số tờ Khai";
            this.colSoToKhai.FieldName = "SoToKhai";
            this.colSoToKhai.Name = "colSoToKhai";
            this.colSoToKhai.Visible = true;
            this.colSoToKhai.VisibleIndex = 2;
            this.colSoToKhai.Width = 108;
            // 
            // ColSoNill
            // 
            this.ColSoNill.Caption = "Số Bill";
            this.ColSoNill.FieldName = "SoBill";
            this.ColSoNill.Name = "ColSoNill";
            this.ColSoNill.Visible = true;
            this.ColSoNill.VisibleIndex = 3;
            this.ColSoNill.Width = 108;
            // 
            // colSoCont
            // 
            this.colSoCont.Caption = "Số Cont";
            this.colSoCont.FieldName = "SoCont";
            this.colSoCont.Name = "colSoCont";
            this.colSoCont.Visible = true;
            this.colSoCont.VisibleIndex = 4;
            this.colSoCont.Width = 108;
            // 
            // colTongCong
            // 
            this.colTongCong.Caption = "Phí Dịch Vụ";
            this.colTongCong.DisplayFormat.FormatString = "{0:#,##}";
            this.colTongCong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongCong.FieldName = "ThanhTien";
            this.colTongCong.Name = "colTongCong";
            this.colTongCong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", "{0:#,##}")});
            this.colTongCong.Visible = true;
            this.colTongCong.VisibleIndex = 5;
            this.colTongCong.Width = 108;
            // 
            // colChiNangha
            // 
            this.colChiNangha.Caption = "Phí nâng hạ";
            this.colChiNangha.DisplayFormat.FormatString = "{0:#,##}";
            this.colChiNangha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colChiNangha.FieldName = "ChiNangHa";
            this.colChiNangha.Name = "colChiNangha";
            this.colChiNangha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ChiNangHa", "{0:#,##}")});
            this.colChiNangha.Visible = true;
            this.colChiNangha.VisibleIndex = 6;
            this.colChiNangha.Width = 108;
            // 
            // colUngTruocNcc
            // 
            this.colUngTruocNcc.Caption = "Thanh toán - Ứng trước";
            this.colUngTruocNcc.DisplayFormat.FormatString = "{0:#,##}";
            this.colUngTruocNcc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUngTruocNcc.FieldName = "UngTruocNCC";
            this.colUngTruocNcc.Name = "colUngTruocNcc";
            this.colUngTruocNcc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UngTruocNCC", "{0:#,##}")});
            this.colUngTruocNcc.Visible = true;
            this.colUngTruocNcc.VisibleIndex = 7;
            this.colUngTruocNcc.Width = 209;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tổng nợ còn lại";
            this.gridColumn1.DisplayFormat.FormatString = "{0:#,##}";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "ConLai";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ConLai", "{0:#,##}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 76;
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 9;
            this.colChon.Width = 76;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Số trả";
            this.gridColumn2.DisplayFormat.FormatString = "{0:#,##}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "SoTra";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTra", "{0:#,##}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            this.gridColumn2.Width = 100;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPhieuThu);
            this.panelControl1.Controls.Add(this.lbducodauky);
            this.panelControl1.Controls.Add(this.btnIn);
            this.panelControl1.Controls.Add(this.btnExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1866, 37);
            this.panelControl1.TabIndex = 2;
            // 
            // btnPhieuThu
            // 
            this.btnPhieuThu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPhieuThu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieuThu.ImageOptions.Image")));
            this.btnPhieuThu.Location = new System.Drawing.Point(1492, 2);
            this.btnPhieuThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuThu.Name = "btnPhieuThu";
            this.btnPhieuThu.Size = new System.Drawing.Size(143, 33);
            this.btnPhieuThu.TabIndex = 14;
            this.btnPhieuThu.Text = "Tạo phiếu chi";
            this.btnPhieuThu.Click += new System.EventHandler(this.btnPhieuThu_Click);
            // 
            // lbducodauky
            // 
            this.lbducodauky.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lbducodauky.Appearance.Options.UseFont = true;
            this.lbducodauky.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbducodauky.Location = new System.Drawing.Point(2, 2);
            this.lbducodauky.Name = "lbducodauky";
            this.lbducodauky.Size = new System.Drawing.Size(112, 23);
            this.lbducodauky.TabIndex = 13;
            this.lbducodauky.Text = "Dư có đầu kỳ";
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.ImageOptions.Image")));
            this.btnIn.Location = new System.Drawing.Point(1635, 2);
            this.btnIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(86, 33);
            this.btnIn.TabIndex = 12;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.Image")));
            this.btnExcel.Location = new System.Drawing.Point(1721, 2);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(143, 33);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // frmCongNoNCC_CT_V3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1870, 685);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmCongNoNCC_CT_V3";
            this.Text = "Chi tiết công nợ nhà cung cấp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCongNoKH_CT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ColSoFile;
        private DevExpress.XtraGrid.Columns.GridColumn colSoToKhai;
        private DevExpress.XtraGrid.Columns.GridColumn ColSoNill;
        private DevExpress.XtraGrid.Columns.GridColumn colTongCong;
        private DevExpress.XtraGrid.Columns.GridColumn colChiNangha;
        private DevExpress.XtraGrid.Columns.GridColumn colUngTruocNcc;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCont;
        private DevExpress.XtraEditors.LabelControl lbducodauky;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnPhieuThu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}