
namespace Quản_lý_vudaco.Forms
{
    partial class frmXuatHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatHoaDon));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtSoHoaDon = new DevExpress.XtraEditors.TextEdit();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHoaDon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ngày xuất hoá đơn";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(40, 91);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Số hoá đơn";
            // 
            // dtpNgay
            // 
            this.dtpNgay.EditValue = null;
            this.dtpNgay.Location = new System.Drawing.Point(40, 49);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpNgay.Size = new System.Drawing.Size(119, 20);
            this.dtpNgay.TabIndex = 0;
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(40, 110);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(248, 20);
            this.txtSoHoaDon.TabIndex = 1;
            // 
            // btnXem
            // 
            this.btnXem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.Image")));
            this.btnXem.Location = new System.Drawing.Point(40, 155);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(104, 24);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Chấp nhận";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(166, 155);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(122, 24);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Huỷ xuất hoá đơn";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmXuatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 268);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuatHoaDon";
            this.Text = "Xuất hoá đơn";
            this.Load += new System.EventHandler(this.frmXuatHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHoaDon.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtpNgay;
        private DevExpress.XtraEditors.TextEdit txtSoHoaDon;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}