
namespace Quản_lý_vudaco.Forms
{
    partial class frmFileDebitBoSung
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileDebitBoSung));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtpNgay = new System.Windows.Forms.MaskedTextBox();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblTenSales = new DevExpress.XtraEditors.LabelControl();
            this.lblSoCont = new DevExpress.XtraEditors.LabelControl();
            this.lblSoBill = new DevExpress.XtraEditors.LabelControl();
            this.lblSoToKhai = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.lblSoFile = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblKh = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Quản_lý_vudaco.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemVAT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtpNgay);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.lblTenSales);
            this.groupControl1.Controls.Add(this.lblSoCont);
            this.groupControl1.Controls.Add(this.lblSoBill);
            this.groupControl1.Controls.Add(this.lblSoToKhai);
            this.groupControl1.Controls.Add(this.lblSoLuong);
            this.groupControl1.Controls.Add(this.lblSoFile);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.lblKh);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1262, 232);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin file cần tạo bảng kê";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(682, 46);
            this.dtpNgay.Mask = "00/00/0000";
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(130, 23);
            this.dtpNgay.TabIndex = 2;
            this.dtpNgay.ValidatingType = typeof(System.DateTime);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(623, 47);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(28, 16);
            this.labelControl13.TabIndex = 3;
            this.labelControl13.Text = "Ngày";
            // 
            // lblTenSales
            // 
            this.lblTenSales.Location = new System.Drawing.Point(714, 160);
            this.lblTenSales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTenSales.Name = "lblTenSales";
            this.lblTenSales.Size = new System.Drawing.Size(12, 16);
            this.lblTenSales.TabIndex = 1;
            this.lblTenSales.Text = "...";
            // 
            // lblSoCont
            // 
            this.lblSoCont.Location = new System.Drawing.Point(714, 120);
            this.lblSoCont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoCont.Name = "lblSoCont";
            this.lblSoCont.Size = new System.Drawing.Size(12, 16);
            this.lblSoCont.TabIndex = 1;
            this.lblSoCont.Text = "...";
            // 
            // lblSoBill
            // 
            this.lblSoBill.Location = new System.Drawing.Point(112, 130);
            this.lblSoBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoBill.Name = "lblSoBill";
            this.lblSoBill.Size = new System.Drawing.Size(12, 16);
            this.lblSoBill.TabIndex = 1;
            this.lblSoBill.Text = "...";
            // 
            // lblSoToKhai
            // 
            this.lblSoToKhai.Location = new System.Drawing.Point(111, 97);
            this.lblSoToKhai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoToKhai.Name = "lblSoToKhai";
            this.lblSoToKhai.Size = new System.Drawing.Size(12, 16);
            this.lblSoToKhai.TabIndex = 1;
            this.lblSoToKhai.Text = "...";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(714, 80);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(12, 16);
            this.lblSoLuong.TabIndex = 1;
            this.lblSoLuong.Text = "...";
            // 
            // lblSoFile
            // 
            this.lblSoFile.Location = new System.Drawing.Point(111, 68);
            this.lblSoFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoFile.Name = "lblSoFile";
            this.lblSoFile.Size = new System.Drawing.Size(12, 16);
            this.lblSoFile.TabIndex = 1;
            this.lblSoFile.Text = "...";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(625, 158);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(57, 16);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Tên Sales";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(625, 119);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(48, 17);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Số cont";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(22, 129);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(34, 17);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Số bill";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(22, 96);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 17);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Số tờ khai";
            // 
            // lblKh
            // 
            this.lblKh.Location = new System.Drawing.Point(111, 43);
            this.lblKh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblKh.Name = "lblKh";
            this.lblKh.Size = new System.Drawing.Size(8, 16);
            this.lblKh.TabIndex = 1;
            this.lblKh.Text = "..";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(625, 78);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(55, 17);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Số lượng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 66);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 17);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Số file";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 46);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Khách hàng:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 232);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 513);
            this.panel1.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(14, 383);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(94, 44);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "HQ";
            this.gridControl1.DataSource = this.dataSet1BindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(14, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemXoa,
            this.repositoryItemVAT});
            this.gridControl1.Size = new System.Drawing.Size(1222, 353);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn8});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IDGiaCT";
            this.gridColumn1.FieldName = "IDGiaCT";
            this.gridColumn1.MinWidth = 24;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nội dung";
            this.gridColumn2.FieldName = "TenDichVu";
            this.gridColumn2.MinWidth = 24;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 239;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.Caption = "Số tiền";
            this.gridColumn5.DisplayFormat.FormatString = "#,##";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "SoTien";
            this.gridColumn5.MinWidth = 24;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTien", "{0:0.##}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 164;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn3.Caption = "VAT";
            this.gridColumn3.ColumnEdit = this.repositoryItemVAT;
            this.gridColumn3.DisplayFormat.FormatString = "#,##";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "VAT";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaBan", "{0:#,##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 64;
            // 
            // repositoryItemVAT
            // 
            this.repositoryItemVAT.AutoHeight = false;
            this.repositoryItemVAT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemVAT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tên", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VAT", "VAT", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemVAT.DisplayMember = "Ten";
            this.repositoryItemVAT.Name = "repositoryItemVAT";
            this.repositoryItemVAT.NullText = "";
            this.repositoryItemVAT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemVAT.ValueMember = "VAT";
            this.repositoryItemVAT.EditValueChanged += new System.EventHandler(this.repositoryItemVAT_EditValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "GhiChu";
            this.gridColumn6.MinWidth = 24;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 261;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.Caption = "Tiền VAT";
            this.gridColumn7.DisplayFormat.FormatString = "#,##";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "ThanhTienVAT";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTienVAT", "{0:#,##}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 151;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.Caption = "Thành tiền";
            this.gridColumn4.DisplayFormat.FormatString = "#,##";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "ThanhTien";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", "{0:#,##}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 185;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Là phí chi hộ";
            this.gridColumn8.FieldName = "LaPhiChiHo";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 94;
            // 
            // repositoryItemXoa
            // 
            this.repositoryItemXoa.AutoHeight = false;
            this.repositoryItemXoa.Caption = "Xoá";
            this.repositoryItemXoa.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemXoa.Image")));
            this.repositoryItemXoa.Name = "repositoryItemXoa";
            this.repositoryItemXoa.NullText = "Xoá";
            // 
            // frmFileDebitBoSung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 745);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileDebitBoSung";
            this.Text = "Lập file Debit bổ sung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFileDebitBoSung_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFileDebitBoSung_FormClosed);
            this.Load += new System.EventHandler(this.frmBangKeChiPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblSoFile;
        private DevExpress.XtraEditors.LabelControl lblKh;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblSoCont;
        private DevExpress.XtraEditors.LabelControl lblSoBill;
        private DevExpress.XtraEditors.LabelControl lblSoToKhai;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private DevExpress.XtraEditors.LabelControl lblTenSales;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.MaskedTextBox dtpNgay;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemVAT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemXoa;
    }
}