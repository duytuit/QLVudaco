
namespace Quản_lý_vudaco.Forms
{
    partial class frmChiNCC_V2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiNCC_V2));
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblChiNhanh = new DevExpress.XtraEditors.LabelControl();
            this.lblChuTK = new DevExpress.XtraEditors.LabelControl();
            this.lblSoTK = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboNganHang = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgay = new System.Windows.Forms.MaskedTextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDienGiai = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCungCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNhaCungCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(12, 540);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(135, 33);
            this.btnCapNhat.TabIndex = 10;
            this.btnCapNhat.Text = "Tạo phiếu thu";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 11);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(102, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Hình thức thanh toán";
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = "TM";
            this.radioGroup1.Location = new System.Drawing.Point(27, 30);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("TM", "Tiền mặt"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CK", "Chuyển khoản")});
            this.radioGroup1.Size = new System.Drawing.Size(296, 27);
            this.radioGroup1.TabIndex = 11;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblChiNhanh);
            this.panel2.Controls.Add(this.lblChuTK);
            this.panel2.Controls.Add(this.lblSoTK);
            this.panel2.Controls.Add(this.labelControl6);
            this.panel2.Controls.Add(this.labelControl5);
            this.panel2.Controls.Add(this.labelControl4);
            this.panel2.Controls.Add(this.cboNganHang);
            this.panel2.Controls.Add(this.labelControl3);
            this.panel2.Location = new System.Drawing.Point(415, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 150);
            this.panel2.TabIndex = 13;
            // 
            // lblChiNhanh
            // 
            this.lblChiNhanh.Location = new System.Drawing.Point(77, 101);
            this.lblChiNhanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblChiNhanh.Name = "lblChiNhanh";
            this.lblChiNhanh.Size = new System.Drawing.Size(12, 13);
            this.lblChiNhanh.TabIndex = 2;
            this.lblChiNhanh.Text = "...";
            // 
            // lblChuTK
            // 
            this.lblChuTK.Location = new System.Drawing.Point(77, 76);
            this.lblChuTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblChuTK.Name = "lblChuTK";
            this.lblChuTK.Size = new System.Drawing.Size(12, 13);
            this.lblChuTK.TabIndex = 2;
            this.lblChuTK.Text = "...";
            // 
            // lblSoTK
            // 
            this.lblSoTK.Location = new System.Drawing.Point(44, 53);
            this.lblSoTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoTK.Name = "lblSoTK";
            this.lblSoTK.Size = new System.Drawing.Size(12, 13);
            this.lblSoTK.TabIndex = 2;
            this.lblSoTK.Text = "...";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(5, 101);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Chi nhánh:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(5, 76);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Chủ tài khoản";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 53);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Số TK:";
            // 
            // cboNganHang
            // 
            this.cboNganHang.FormattingEnabled = true;
            this.cboNganHang.Location = new System.Drawing.Point(5, 24);
            this.cboNganHang.Name = "cboNganHang";
            this.cboNganHang.Size = new System.Drawing.Size(468, 21);
            this.cboNganHang.TabIndex = 3;
            this.cboNganHang.SelectedIndexChanged += new System.EventHandler(this.cboNganHang_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 7);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Chọn ngân hàng";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(27, 85);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(80, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Ngày hạch toán:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(113, 82);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgay.Mask = "00/00/0000";
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(112, 21);
            this.dtpNgay.TabIndex = 14;
            this.dtpNgay.ValidatingType = typeof(System.DateTime);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(27, 122);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(40, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Diễn giải";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(27, 149);
            this.txtDienGiai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(365, 20);
            this.txtDienGiai.TabIndex = 15;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 226);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(917, 309);
            this.gridControl1.TabIndex = 16;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colNhaCungCap,
            this.colSoFile,
            this.colSoTien,
            this.colType,
            this.colMaNhaCungCap,
            this.colID,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 57;
            // 
            // colNhaCungCap
            // 
            this.colNhaCungCap.Caption = "Tên Nhà Cung Cấp";
            this.colNhaCungCap.FieldName = "TenNhaCungCap";
            this.colNhaCungCap.Name = "colNhaCungCap";
            this.colNhaCungCap.Visible = true;
            this.colNhaCungCap.VisibleIndex = 1;
            this.colNhaCungCap.Width = 545;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            // 
            // colSoTien
            // 
            this.colSoTien.Caption = "Số Tiền";
            this.colSoTien.DisplayFormat.FormatString = "{0:#,##}";
            this.colSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTien.FieldName = "SoTien";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTien", "{0:#,##}")});
            this.colSoTien.Visible = true;
            this.colSoTien.VisibleIndex = 3;
            this.colSoTien.Width = 176;
            // 
            // colSoFile
            // 
            this.colSoFile.Caption = "So File";
            this.colSoFile.FieldName = "SoFile";
            this.colSoFile.Name = "colSoFile";
            this.colSoFile.Visible = true;
            this.colSoFile.VisibleIndex = 2;
            this.colSoFile.Width = 368;
            // 
            // colMaNhaCungCap
            // 
            this.colMaNhaCungCap.Caption = "MaNhaCungCap";
            this.colMaNhaCungCap.FieldName = "MaNhaCungCap";
            this.colMaNhaCungCap.Name = "colMaNhaCungCap";
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Type";
            this.gridColumn1.FieldName = "Type";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // frmChiNCC_V2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 580);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtDienGiai);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiNCC_V2";
            this.Text = "Phiếu chi nhà cung cấp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChiNCC_V2_FormClosing);
            this.Load += new System.EventHandler(this.frmDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblChiNhanh;
        private DevExpress.XtraEditors.LabelControl lblChuTK;
        private DevExpress.XtraEditors.LabelControl lblSoTK;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cboNganHang;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.MaskedTextBox dtpNgay;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtDienGiai;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCungCap;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colSoFile;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhaCungCap;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}