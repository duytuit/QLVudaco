
namespace Quản_lý_vudaco.Forms
{
    partial class frmHoanTraPhieuTamThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoanTraPhieuTamThu));
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgay = new System.Windows.Forms.MaskedTextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDienGiai = new DevExpress.XtraEditors.MemoEdit();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.Image")));
            this.btnXem.Location = new System.Drawing.Point(25, 214);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(135, 33);
            this.btnXem.TabIndex = 10;
            this.btnXem.Text = "Lưu";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(25, 24);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(29, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Ngày:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(25, 42);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgay.Mask = "00/00/0000";
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(112, 21);
            this.dtpNgay.TabIndex = 14;
            this.dtpNgay.ValidatingType = typeof(System.DateTime);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(25, 67);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(42, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Nội dung";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(25, 84);
            this.txtDienGiai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(662, 126);
            this.txtDienGiai.TabIndex = 15;
            // 
            // btnHuy
            // 
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(193, 214);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(135, 33);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmHoanTraPhieuTamThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 425);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtDienGiai);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHoanTraPhieuTamThu";
            this.Text = "Hoàn trả phiếu tạm thu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuyHoanCuocNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.frmDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.MaskedTextBox dtpNgay;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.MemoEdit txtDienGiai;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
    }
}