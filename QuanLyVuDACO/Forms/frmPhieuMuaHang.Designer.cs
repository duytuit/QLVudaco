
namespace Quản_lý_vudaco.Forms
{
    partial class frmPhieuMuaHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuMuaHang));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtpNgayMua = new System.Windows.Forms.MaskedTextBox();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.cboDanhSachChiCon = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDanhSachChi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDienGiai = new DevExpress.XtraEditors.TextEdit();
            this.txtNguoiMua = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboNhaCC = new DevExpress.XtraEditors.LookUpEdit();
            this.cboNhanVien = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Quản_lý_vudaco.DataSet1();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemVAT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemXe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDanhSachChiCon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDanhSachChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiMua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtpNgayMua);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.cboDanhSachChiCon);
            this.groupControl1.Controls.Add(this.cboDanhSachChi);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtDienGiai);
            this.groupControl1.Controls.Add(this.txtNguoiMua);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboNhaCC);
            this.groupControl1.Controls.Add(this.cboNhanVien);
            this.groupControl1.Location = new System.Drawing.Point(4, 1);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1001, 240);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin chung";
            // 
            // dtpNgayMua
            // 
            this.dtpNgayMua.Location = new System.Drawing.Point(99, 35);
            this.dtpNgayMua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayMua.Mask = "00/00/0000";
            this.dtpNgayMua.Name = "dtpNgayMua";
            this.dtpNgayMua.Size = new System.Drawing.Size(137, 21);
            this.dtpNgayMua.TabIndex = 0;
            this.dtpNgayMua.ValidatingType = typeof(System.DateTime);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(10, 38);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(48, 13);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Ngày mua";
            // 
            // cboDanhSachChiCon
            // 
            this.cboDanhSachChiCon.Location = new System.Drawing.Point(336, 172);
            this.cboDanhSachChiCon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDanhSachChiCon.Name = "cboDanhSachChiCon";
            this.cboDanhSachChiCon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDanhSachChiCon.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaChi", "Mã chi"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChi", "Tên chi")});
            this.cboDanhSachChiCon.Properties.DisplayMember = "TenChi";
            this.cboDanhSachChiCon.Properties.NullText = "Lý do chi con";
            this.cboDanhSachChiCon.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDanhSachChiCon.Properties.ValueMember = "MaChi";
            this.cboDanhSachChiCon.Size = new System.Drawing.Size(222, 20);
            this.cboDanhSachChiCon.TabIndex = 5;
            this.cboDanhSachChiCon.EditValueChanged += new System.EventHandler(this.cboDanhSachChi_EditValueChanged);
            // 
            // cboDanhSachChi
            // 
            this.cboDanhSachChi.Location = new System.Drawing.Point(99, 172);
            this.cboDanhSachChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDanhSachChi.Name = "cboDanhSachChi";
            this.cboDanhSachChi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDanhSachChi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaChi", "Mã chi"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChi", "Tên chi")});
            this.cboDanhSachChi.Properties.DisplayMember = "TenChi";
            this.cboDanhSachChi.Properties.NullText = "Lý do chi";
            this.cboDanhSachChi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDanhSachChi.Properties.ValueMember = "MaChi";
            this.cboDanhSachChi.Size = new System.Drawing.Size(231, 20);
            this.cboDanhSachChi.TabIndex = 4;
            this.cboDanhSachChi.EditValueChanged += new System.EventHandler(this.cboDanhSachChi_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(31, 173);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Lý do chi";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(99, 200);
            this.txtDienGiai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(459, 20);
            this.txtDienGiai.TabIndex = 6;
            // 
            // txtNguoiMua
            // 
            this.txtNguoiMua.Location = new System.Drawing.Point(99, 145);
            this.txtNguoiMua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNguoiMua.Name = "txtNguoiMua";
            this.txtNguoiMua.Size = new System.Drawing.Size(459, 20);
            this.txtNguoiMua.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 206);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Diễn giải";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 97);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nhà cung cấp:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(10, 148);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(82, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Người mua hàng:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(11, 122);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Nhân viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 76);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Đối tượng-----------";
            // 
            // cboNhaCC
            // 
            this.cboNhaCC.EditValue = "Tất cả khách";
            this.cboNhaCC.Location = new System.Drawing.Point(99, 94);
            this.cboNhaCC.Name = "cboNhaCC";
            this.cboNhaCC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboNhaCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhaCC.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNhaCungCap", "Name9", 200, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhaCungCap", "Nhà cung cấp", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cboNhaCC.Properties.DisplayMember = "TenNhaCungCap";
            this.cboNhaCC.Properties.NullText = "Chọn nhà cung cấp";
            this.cboNhaCC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboNhaCC.Properties.ValueMember = "MaNhaCungCap";
            this.cboNhaCC.Size = new System.Drawing.Size(327, 20);
            this.cboNhaCC.TabIndex = 1;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.EditValue = "Tất cả khách";
            this.cboNhanVien.Location = new System.Drawing.Point(99, 119);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhanVien.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNhanVien", "Name11", 150, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhanVien", "Nhân viên", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cboNhanVien.Properties.DisplayMember = "TenNhanVien";
            this.cboNhanVien.Properties.NullText = "Chọn nhân viên";
            this.cboNhanVien.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboNhanVien.Properties.ValueMember = "MaNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(327, 20);
            this.cboNhanVien.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(4, 504);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(81, 24);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(178, 505);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(81, 24);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Location = new System.Drawing.Point(91, 505);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(81, 24);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "PhieuMuaCT";
            this.gridControl1.DataSource = this.dataSet1BindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(4, 259);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemXoa,
            this.repositoryItemVAT,
            this.repositoryItemXe});
            this.gridControl1.Size = new System.Drawing.Size(1014, 241);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
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
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn1,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn9});
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IDCT";
            this.gridColumn5.FieldName = "IDCT";
            this.gridColumn5.MinWidth = 21;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 81;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Diễn giải";
            this.gridColumn6.FieldName = "NoiDung";
            this.gridColumn6.MinWidth = 21;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 205;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.Caption = "Số tiền";
            this.gridColumn7.DisplayFormat.FormatString = "#,##";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "SoTien";
            this.gridColumn7.MinWidth = 21;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTien", "{0:0.##}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 106;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.Caption = "%VAT";
            this.gridColumn8.ColumnEdit = this.repositoryItemVAT;
            this.gridColumn8.DisplayFormat.FormatString = "{0} %";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "VAT";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 59;
            // 
            // repositoryItemVAT
            // 
            this.repositoryItemVAT.AutoHeight = false;
            this.repositoryItemVAT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemVAT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VAT", "VAT", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tên", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemVAT.DisplayMember = "Ten";
            this.repositoryItemVAT.Name = "repositoryItemVAT";
            this.repositoryItemVAT.NullText = "";
            this.repositoryItemVAT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemVAT.ValueMember = "VAT";
            this.repositoryItemVAT.EditValueChanged += new System.EventHandler(this.repositoryItemVAT_EditValueChanged);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Thuế GTGT";
            this.gridColumn13.DisplayFormat.FormatString = "#,##";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "ThueVAT";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienVAT", "{0:#,##}")});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 89;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Thành tiền";
            this.gridColumn14.DisplayFormat.FormatString = "#,##";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "ThanhTienVAT";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", "{0:#,##}")});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 130;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số hoá đơn";
            this.gridColumn1.FieldName = "SoHoaDon";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.ColumnEdit = this.repositoryItemXoa;
            this.gridColumn10.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn10.MinWidth = 21;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 80;
            // 
            // repositoryItemXoa
            // 
            this.repositoryItemXoa.AutoHeight = false;
            this.repositoryItemXoa.Caption = "Xoá";
            this.repositoryItemXoa.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemXoa.Image")));
            this.repositoryItemXoa.Name = "repositoryItemXoa";
            this.repositoryItemXoa.NullText = "Xoá";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn7";
            this.gridColumn11.FieldName = "IDCP";
            this.gridColumn11.MinWidth = 21;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 81;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Tên xe - Công trình";
            this.gridColumn15.ColumnEdit = this.repositoryItemXe;
            this.gridColumn15.FieldName = "BienSoXe";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            this.gridColumn15.Width = 136;
            // 
            // repositoryItemXe
            // 
            this.repositoryItemXe.AutoHeight = false;
            this.repositoryItemXe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemXe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BienSoXe", "Danh sách xe", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemXe.DisplayMember = "BienSoXe";
            this.repositoryItemXe.Name = "repositoryItemXe";
            this.repositoryItemXe.NullText = "";
            this.repositoryItemXe.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemXe.ValueMember = "BienSoXe";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Là chi phí cần phân bổ";
            this.gridColumn16.FieldName = "LaChiPhiPhanBo";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            this.gridColumn16.Width = 120;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Là CP quản lý";
            this.gridColumn9.FieldName = "LaChiPhiQuanLy";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // frmPhieuMuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 537);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPhieuMuaHang";
            this.Text = "Phiếu mua hàng";
            this.Load += new System.EventHandler(this.frmPhieuChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDanhSachChiCon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDanhSachChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiMua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboDanhSachChi;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private System.Windows.Forms.MaskedTextBox dtpNgayMua;
        private DevExpress.XtraEditors.LookUpEdit cboDanhSachChiCon;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemXoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemVAT;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemXe;
        private DevExpress.XtraEditors.TextEdit txtDienGiai;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtNguoiMua;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LookUpEdit cboNhaCC;
        private DevExpress.XtraEditors.LookUpEdit cboNhanVien;
    }
}