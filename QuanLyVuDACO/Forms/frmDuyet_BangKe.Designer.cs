
namespace Quản_lý_vudaco.Forms
{
    partial class frmDuyet_BangKe
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
            this.txtNguoiDuyet = new DevExpress.XtraEditors.TextEdit();
            this.txtLyDo = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgay = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiDuyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNguoiDuyet
            // 
            this.txtNguoiDuyet.Location = new System.Drawing.Point(23, 70);
            this.txtNguoiDuyet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNguoiDuyet.Name = "txtNguoiDuyet";
            this.txtNguoiDuyet.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNguoiDuyet.Properties.Appearance.Options.UseFont = true;
            this.txtNguoiDuyet.Size = new System.Drawing.Size(301, 26);
            this.txtNguoiDuyet.TabIndex = 1;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(23, 127);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLyDo.Properties.Appearance.Options.UseFont = true;
            this.txtLyDo.Size = new System.Drawing.Size(600, 26);
            this.txtLyDo.TabIndex = 2;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(110, 164);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(81, 24);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Thoát";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 109);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Lý do duyệt";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Người duyệt";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(23, 165);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(81, 24);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Duyệt";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 3);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Ngày duyệt";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpNgay.Location = new System.Drawing.Point(23, 22);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgay.Mask = "00/00/0000";
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(112, 27);
            this.dtpNgay.TabIndex = 0;
            this.dtpNgay.ValidatingType = typeof(System.DateTime);
            // 
            // frmDuyet_BangKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 239);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtNguoiDuyet);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyet_BangKe";
            this.Text = "frmDuyet_BangKe";
            this.Load += new System.EventHandler(this.frmDuyet_BangKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiDuyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNguoiDuyet;
        private DevExpress.XtraEditors.TextEdit txtLyDo;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.MaskedTextBox dtpNgay;
    }
}