
namespace Quản_lý_vudaco.Forms
{
    partial class frmKhaiBaoTSCD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhaiBaoTSCD));
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoChungTu = new DevExpress.XtraEditors.TextEdit();
            this.txtTenTaiSan = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaTriTaiSan = new DevExpress.XtraEditors.TextEdit();
            this.txtThoiGianPhanBo = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaTriPhanBoTheoThang = new DevExpress.XtraEditors.TextEdit();
            this.dtpNgayKhaiBao = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaTaiSan = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoChungTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTaiSan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTriTaiSan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianPhanBo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTriPhanBoTheoThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKhaiBao.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKhaiBao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTaiSan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(298, 213);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(93, 33);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(199, 213);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(93, 33);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(100, 213);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(93, 33);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Ngày khai báo";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Sổ chứng từ";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Tên tài sản";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(26, 130);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Giá trị tài sản";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(26, 153);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(141, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Thời gian phân bổ theo tháng";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(28, 183);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(126, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Giá trị phân bổ theo tháng";
            // 
            // txtSoChungTu
            // 
            this.txtSoChungTu.Location = new System.Drawing.Point(105, 25);
            this.txtSoChungTu.Name = "txtSoChungTu";
            this.txtSoChungTu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSoChungTu.Properties.Appearance.Options.UseFont = true;
            this.txtSoChungTu.Properties.ReadOnly = true;
            this.txtSoChungTu.Size = new System.Drawing.Size(217, 20);
            this.txtSoChungTu.TabIndex = 13;
            // 
            // txtTenTaiSan
            // 
            this.txtTenTaiSan.Location = new System.Drawing.Point(105, 100);
            this.txtTenTaiSan.Name = "txtTenTaiSan";
            this.txtTenTaiSan.Size = new System.Drawing.Size(341, 20);
            this.txtTenTaiSan.TabIndex = 2;
            // 
            // txtGiaTriTaiSan
            // 
            this.txtGiaTriTaiSan.Location = new System.Drawing.Point(105, 127);
            this.txtGiaTriTaiSan.Name = "txtGiaTriTaiSan";
            this.txtGiaTriTaiSan.Properties.Mask.EditMask = "n";
            this.txtGiaTriTaiSan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaTriTaiSan.Properties.NullText = "0";
            this.txtGiaTriTaiSan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGiaTriTaiSan.Size = new System.Drawing.Size(278, 20);
            this.txtGiaTriTaiSan.TabIndex = 3;
            this.txtGiaTriTaiSan.TextChanged += new System.EventHandler(this.txtGiaTriTaiSan_TextChanged);
            // 
            // txtThoiGianPhanBo
            // 
            this.txtThoiGianPhanBo.Location = new System.Drawing.Point(173, 153);
            this.txtThoiGianPhanBo.Name = "txtThoiGianPhanBo";
            this.txtThoiGianPhanBo.Properties.Mask.EditMask = "n";
            this.txtThoiGianPhanBo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtThoiGianPhanBo.Properties.NullText = "0";
            this.txtThoiGianPhanBo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtThoiGianPhanBo.Size = new System.Drawing.Size(210, 20);
            this.txtThoiGianPhanBo.TabIndex = 4;
            this.txtThoiGianPhanBo.TextChanged += new System.EventHandler(this.txtGiaTriTaiSan_TextChanged);
            // 
            // txtGiaTriPhanBoTheoThang
            // 
            this.txtGiaTriPhanBoTheoThang.EditValue = "0";
            this.txtGiaTriPhanBoTheoThang.Location = new System.Drawing.Point(173, 179);
            this.txtGiaTriPhanBoTheoThang.Name = "txtGiaTriPhanBoTheoThang";
            this.txtGiaTriPhanBoTheoThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaTriPhanBoTheoThang.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtGiaTriPhanBoTheoThang.Properties.Appearance.Options.UseFont = true;
            this.txtGiaTriPhanBoTheoThang.Properties.Appearance.Options.UseForeColor = true;
            this.txtGiaTriPhanBoTheoThang.Properties.ReadOnly = true;
            this.txtGiaTriPhanBoTheoThang.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGiaTriPhanBoTheoThang.Size = new System.Drawing.Size(210, 20);
            this.txtGiaTriPhanBoTheoThang.TabIndex = 13;
            this.txtGiaTriPhanBoTheoThang.EditValueChanged += new System.EventHandler(this.GiaTriPhanBoTheoThangTextEdit_EditValueChanged);
            // 
            // dtpNgayKhaiBao
            // 
            this.dtpNgayKhaiBao.EditValue = null;
            this.dtpNgayKhaiBao.Location = new System.Drawing.Point(105, 50);
            this.dtpNgayKhaiBao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayKhaiBao.Name = "dtpNgayKhaiBao";
            this.dtpNgayKhaiBao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgayKhaiBao.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgayKhaiBao.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayKhaiBao.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayKhaiBao.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayKhaiBao.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayKhaiBao.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpNgayKhaiBao.Size = new System.Drawing.Size(174, 20);
            this.dtpNgayKhaiBao.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(26, 78);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Mã tài sản";
            // 
            // txtMaTaiSan
            // 
            this.txtMaTaiSan.Location = new System.Drawing.Point(105, 75);
            this.txtMaTaiSan.Name = "txtMaTaiSan";
            this.txtMaTaiSan.Size = new System.Drawing.Size(174, 20);
            this.txtMaTaiSan.TabIndex = 1;
            // 
            // frmKhaiBaoTSCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 348);
            this.Controls.Add(this.dtpNgayKhaiBao);
            this.Controls.Add(this.txtMaTaiSan);
            this.Controls.Add(this.txtTenTaiSan);
            this.Controls.Add(this.txtGiaTriPhanBoTheoThang);
            this.Controls.Add(this.txtThoiGianPhanBo);
            this.Controls.Add(this.txtGiaTriTaiSan);
            this.Controls.Add(this.txtSoChungTu);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnLuu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhaiBaoTSCD";
            this.Text = "Khai báo tài sản cố định";
            this.Load += new System.EventHandler(this.frmKhaiBaoTSCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoChungTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTaiSan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTriTaiSan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGianPhanBo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTriPhanBoTheoThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKhaiBao.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKhaiBao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTaiSan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtSoChungTu;
        private DevExpress.XtraEditors.TextEdit txtTenTaiSan;
        private DevExpress.XtraEditors.TextEdit txtGiaTriTaiSan;
        private DevExpress.XtraEditors.TextEdit txtThoiGianPhanBo;
        private DevExpress.XtraEditors.TextEdit txtGiaTriPhanBoTheoThang;
        private DevExpress.XtraEditors.DateEdit dtpNgayKhaiBao;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtMaTaiSan;
    }
}