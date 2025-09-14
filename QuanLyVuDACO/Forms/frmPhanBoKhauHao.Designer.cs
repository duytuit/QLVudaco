
namespace Quản_lý_vudaco.Forms
{
    partial class frmPhanBoKhauHao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanBoKhauHao));
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbThang = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbDiengiaỉ = new DevExpress.XtraEditors.LabelControl();
            this.txtDiengiaỉ = new DevExpress.XtraEditors.TextEdit();
            this.dtpNgayKhaiBao = new System.Windows.Forms.MaskedTextBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemHyperLinkEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemSua = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemDsXe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.colSoChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTaiSan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTaiSan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguyenGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaTriKhauHaoThang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiengiaỉ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDsXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(206, 10);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(134, 33);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(27, 10);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(173, 33);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Lưu";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(1051, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Ngày khai báo";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cbNam);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cbThang);
            this.panelControl1.Controls.Add(this.lbDiengiaỉ);
            this.panelControl1.Controls.Add(this.txtDiengiaỉ);
            this.panelControl1.Controls.Add(this.dtpNgayKhaiBao);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1267, 70);
            this.panelControl1.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(173, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 19);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "Năm";
            // 
            // cbNam
            // 
            this.cbNam.Location = new System.Drawing.Point(225, 22);
            this.cbNam.Name = "cbNam";
            this.cbNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbNam.Properties.Appearance.Options.UseFont = true;
            this.cbNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbNam.Size = new System.Drawing.Size(100, 26);
            this.cbNam.TabIndex = 26;
            this.cbNam.EditValueChanged += new System.EventHandler(this.cbNam_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 19);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Tháng";
            // 
            // cbThang
            // 
            this.cbThang.Location = new System.Drawing.Point(62, 22);
            this.cbThang.Name = "cbThang";
            this.cbThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbThang.Properties.Appearance.Options.UseFont = true;
            this.cbThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbThang.Size = new System.Drawing.Size(100, 26);
            this.cbThang.TabIndex = 24;
            this.cbThang.EditValueChanged += new System.EventHandler(this.cbThang_EditValueChanged);
            // 
            // lbDiengiaỉ
            // 
            this.lbDiengiaỉ.Location = new System.Drawing.Point(354, 30);
            this.lbDiengiaỉ.Name = "lbDiengiaỉ";
            this.lbDiengiaỉ.Size = new System.Drawing.Size(40, 13);
            this.lbDiengiaỉ.TabIndex = 23;
            this.lbDiengiaỉ.Text = "Diễn giải";
            // 
            // txtDiengiaỉ
            // 
            this.txtDiengiaỉ.Location = new System.Drawing.Point(403, 27);
            this.txtDiengiaỉ.Name = "txtDiengiaỉ";
            this.txtDiengiaỉ.Size = new System.Drawing.Size(633, 20);
            this.txtDiengiaỉ.TabIndex = 22;
            // 
            // dtpNgayKhaiBao
            // 
            this.dtpNgayKhaiBao.Location = new System.Drawing.Point(1130, 25);
            this.dtpNgayKhaiBao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayKhaiBao.Mask = "00/00/0000";
            this.dtpNgayKhaiBao.Name = "dtpNgayKhaiBao";
            this.dtpNgayKhaiBao.Size = new System.Drawing.Size(112, 21);
            this.dtpNgayKhaiBao.TabIndex = 21;
            this.dtpNgayKhaiBao.ValidatingType = typeof(System.DateTime);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl2);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 70);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1267, 735);
            this.panelControl2.TabIndex = 15;
            // 
            // gridControl2
            // 
            this.gridControl2.DataMember = "NhanVien";
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl2.Location = new System.Drawing.Point(2, 2);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit4,
            this.repositoryItemHyperLinkEdit4,
            this.repositoryItemSua,
            this.repositoryItemXoa,
            this.repositoryItemDsXe});
            this.gridControl2.Size = new System.Drawing.Size(1263, 679);
            this.gridControl2.TabIndex = 9;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoChungTu,
            this.colNgayTao,
            this.colMaTaiSan,
            this.colTenTaiSan,
            this.colNguyenGia,
            this.colThoiGianSuDung,
            this.colGiaTriKhauHaoThang,
            this.colNguoiTao,
            this.colID});
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.DisplayMember = "TenPhongBan";
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            this.repositoryItemLookUpEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEdit4.ValueMember = "MaPhongBan";
            // 
            // repositoryItemHyperLinkEdit4
            // 
            this.repositoryItemHyperLinkEdit4.AutoHeight = false;
            this.repositoryItemHyperLinkEdit4.Name = "repositoryItemHyperLinkEdit4";
            // 
            // repositoryItemSua
            // 
            this.repositoryItemSua.AutoHeight = false;
            this.repositoryItemSua.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemSua.Image")));
            this.repositoryItemSua.Name = "repositoryItemSua";
            this.repositoryItemSua.NullText = "Sửa";
            // 
            // repositoryItemXoa
            // 
            this.repositoryItemXoa.AutoHeight = false;
            this.repositoryItemXoa.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemXoa.Image")));
            this.repositoryItemXoa.Name = "repositoryItemXoa";
            this.repositoryItemXoa.NullText = "Xoá";
            // 
            // repositoryItemDsXe
            // 
            this.repositoryItemDsXe.AutoHeight = false;
            this.repositoryItemDsXe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDsXe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BienSoXe", "Name1", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemDsXe.DisplayMember = "BienSoXe";
            this.repositoryItemDsXe.Name = "repositoryItemDsXe";
            this.repositoryItemDsXe.NullText = "Chọn biển số xe";
            this.repositoryItemDsXe.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemDsXe.ValueMember = "BienSoXe";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnHuy);
            this.panelControl3.Controls.Add(this.btnCapNhat);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 681);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1263, 52);
            this.panelControl3.TabIndex = 8;
            // 
            // colSoChungTu
            // 
            this.colSoChungTu.Caption = "Số chứng từ";
            this.colSoChungTu.FieldName = "SoChungTu";
            this.colSoChungTu.Name = "colSoChungTu";
            this.colSoChungTu.Visible = true;
            this.colSoChungTu.VisibleIndex = 0;
            // 
            // colNgayTao
            // 
            this.colNgayTao.Caption = "Ngày Tạo";
            this.colNgayTao.FieldName = "NgayTao";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.Visible = true;
            this.colNgayTao.VisibleIndex = 3;
            this.colNgayTao.Width = 79;
            // 
            // colMaTaiSan
            // 
            this.colMaTaiSan.Caption = "Mã Tài Sản";
            this.colMaTaiSan.FieldName = "MaKhauHao";
            this.colMaTaiSan.Name = "colMaTaiSan";
            this.colMaTaiSan.Visible = true;
            this.colMaTaiSan.VisibleIndex = 2;
            this.colMaTaiSan.Width = 79;
            // 
            // colTenTaiSan
            // 
            this.colTenTaiSan.Caption = "Tên Tài Sản";
            this.colTenTaiSan.FieldName = "TenKhauHao";
            this.colTenTaiSan.Name = "colTenTaiSan";
            this.colTenTaiSan.Visible = true;
            this.colTenTaiSan.VisibleIndex = 1;
            this.colTenTaiSan.Width = 125;
            // 
            // colNguyenGia
            // 
            this.colNguyenGia.Caption = "Nguyên Giá";
            this.colNguyenGia.DisplayFormat.FormatString = "{0:#,##}";
            this.colNguyenGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNguyenGia.FieldName = "NguyenGia";
            this.colNguyenGia.Name = "colNguyenGia";
            this.colNguyenGia.Visible = true;
            this.colNguyenGia.VisibleIndex = 4;
            this.colNguyenGia.Width = 79;
            // 
            // colThoiGianSuDung
            // 
            this.colThoiGianSuDung.Caption = "Thời gian sử dụng";
            this.colThoiGianSuDung.FieldName = "ThoiGianSuDung";
            this.colThoiGianSuDung.Name = "colThoiGianSuDung";
            this.colThoiGianSuDung.Visible = true;
            this.colThoiGianSuDung.VisibleIndex = 5;
            this.colThoiGianSuDung.Width = 79;
            // 
            // colGiaTriKhauHaoThang
            // 
            this.colGiaTriKhauHaoThang.Caption = "Giá trị khấu hao tháng";
            this.colGiaTriKhauHaoThang.DisplayFormat.FormatString = "{0:#,##}";
            this.colGiaTriKhauHaoThang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGiaTriKhauHaoThang.FieldName = "GiaTriKhauHaoThang";
            this.colGiaTriKhauHaoThang.Name = "colGiaTriKhauHaoThang";
            this.colGiaTriKhauHaoThang.Visible = true;
            this.colGiaTriKhauHaoThang.VisibleIndex = 6;
            this.colGiaTriKhauHaoThang.Width = 79;
            // 
            // colNguoiTao
            // 
            this.colNguoiTao.Caption = "Người tạo";
            this.colNguoiTao.FieldName = "NguoiTao";
            this.colNguoiTao.Name = "colNguoiTao";
            this.colNguoiTao.Visible = true;
            this.colNguoiTao.VisibleIndex = 7;
            this.colNguoiTao.Width = 87;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // frmPhanBoKhauHao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 805);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhanBoKhauHao";
            this.Text = "Phân bổ khấu hao";
            this.Load += new System.EventHandler(this.frmKhaiBaoTSCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiengiaỉ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDsXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemDsXe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemSua;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemXoa;
        private System.Windows.Forms.MaskedTextBox dtpNgayKhaiBao;
        private DevExpress.XtraEditors.LabelControl lbDiengiaỉ;
        private DevExpress.XtraEditors.TextEdit txtDiengiaỉ;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbNam;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbThang;
        private DevExpress.XtraGrid.Columns.GridColumn colSoChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTaiSan;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTaiSan;
        private DevExpress.XtraGrid.Columns.GridColumn colNguyenGia;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianSuDung;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaTriKhauHaoThang;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
    }
}