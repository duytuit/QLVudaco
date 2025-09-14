
namespace Quản_lý_vudaco.Forms
{
    partial class frmPhuCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhuCap));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNhanVien = new DevExpress.XtraEditors.TextEdit();
            this.txtTenNhanVien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenPhuCap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoTien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnThemPhuCap = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhuCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên nhân viên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Enabled = false;
            this.txtMaNhanVien.Location = new System.Drawing.Point(32, 33);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtMaNhanVien.Properties.Appearance.Options.UseForeColor = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(239, 20);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Enabled = false;
            this.txtTenNhanVien.Location = new System.Drawing.Point(31, 78);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtTenNhanVien.Properties.Appearance.Options.UseForeColor = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(511, 20);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Khoản phụ cấp";
            // 
            // txtTenPhuCap
            // 
            this.txtTenPhuCap.Location = new System.Drawing.Point(31, 129);
            this.txtTenPhuCap.Name = "txtTenPhuCap";
            this.txtTenPhuCap.Size = new System.Drawing.Size(511, 20);
            this.txtTenPhuCap.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(31, 154);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Số tiền phụ cấp";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(31, 173);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.Mask.EditMask = "n";
            this.txtSoTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoTien.Size = new System.Drawing.Size(240, 20);
            this.txtSoTien.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(277, 177);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(21, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "VNĐ";
            // 
            // btnThemPhuCap
            // 
            this.btnThemPhuCap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPhuCap.ImageOptions.Image")));
            this.btnThemPhuCap.Location = new System.Drawing.Point(31, 210);
            this.btnThemPhuCap.Name = "btnThemPhuCap";
            this.btnThemPhuCap.Size = new System.Drawing.Size(132, 30);
            this.btnThemPhuCap.TabIndex = 3;
            this.btnThemPhuCap.Text = "Cập nhật";
            this.btnThemPhuCap.Click += new System.EventHandler(this.btnThemPhuCap_Click);
            // 
            // frmPhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 353);
            this.Controls.Add(this.btnThemPhuCap);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtTenPhuCap);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhuCap";
            this.Text = "frmPhuCap";
            this.Load += new System.EventHandler(this.frmPhuCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhuCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtMaNhanVien;
        private DevExpress.XtraEditors.TextEdit txtTenNhanVien;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTenPhuCap;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSoTien;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnThemPhuCap;
    }
}