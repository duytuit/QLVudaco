
namespace Quản_lý_vudaco.Forms
{
    partial class frmTaoKhauHao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoKhauHao));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaKhauHao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhauHao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NguyenGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThoiGianSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaTriKhauHaoThang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTaoKhauHao = new DevExpress.XtraEditors.SimpleButton();
            this.NgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1051, 388);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1243, 653);
            this.panelControl1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1239, 649);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Load += new System.EventHandler(this.gridControl1_Load);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NgayTao,
            this.MaKhauHao,
            this.TenKhauHao,
            this.NguyenGia,
            this.ThoiGianSuDung,
            this.GiaTriKhauHaoThang,
            this.GhiChu});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // MaKhauHao
            // 
            this.MaKhauHao.Caption = "Mã khấu hao";
            this.MaKhauHao.FieldName = "MaKhauHao";
            this.MaKhauHao.Name = "MaKhauHao";
            this.MaKhauHao.Visible = true;
            this.MaKhauHao.VisibleIndex = 1;
            // 
            // TenKhauHao
            // 
            this.TenKhauHao.Caption = "Tên khấu hao";
            this.TenKhauHao.FieldName = "TenKhauHao";
            this.TenKhauHao.Name = "TenKhauHao";
            this.TenKhauHao.Visible = true;
            this.TenKhauHao.VisibleIndex = 2;
            // 
            // NguyenGia
            // 
            this.NguyenGia.Caption = "Nguyên Giá";
            this.NguyenGia.DisplayFormat.FormatString = "{0:#,##}";
            this.NguyenGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NguyenGia.FieldName = "NguyenGia";
            this.NguyenGia.Name = "NguyenGia";
            this.NguyenGia.Visible = true;
            this.NguyenGia.VisibleIndex = 3;
            // 
            // ThoiGianSuDung
            // 
            this.ThoiGianSuDung.Caption = "Thời gian sử dụng";
            this.ThoiGianSuDung.FieldName = "ThoiGianSuDung";
            this.ThoiGianSuDung.Name = "ThoiGianSuDung";
            this.ThoiGianSuDung.Visible = true;
            this.ThoiGianSuDung.VisibleIndex = 4;
            // 
            // GiaTriKhauHaoThang
            // 
            this.GiaTriKhauHaoThang.Caption = "Gia trị khấu hao tháng";
            this.GiaTriKhauHaoThang.DisplayFormat.FormatString = "{0:#,##}";
            this.GiaTriKhauHaoThang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GiaTriKhauHaoThang.FieldName = "GiaTriKhauHaoThang";
            this.GiaTriKhauHaoThang.Name = "GiaTriKhauHaoThang";
            this.GiaTriKhauHaoThang.OptionsColumn.AllowEdit = false;
            this.GiaTriKhauHaoThang.Visible = true;
            this.GiaTriKhauHaoThang.VisibleIndex = 5;
            // 
            // GhiChu
            // 
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 6;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Controls.Add(this.btnTaoKhauHao);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 601);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1243, 52);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(157, 17);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(121, 24);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "Huỷ";
            // 
            // btnTaoKhauHao
            // 
            this.btnTaoKhauHao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoKhauHao.ImageOptions.Image")));
            this.btnTaoKhauHao.Location = new System.Drawing.Point(30, 17);
            this.btnTaoKhauHao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaoKhauHao.Name = "btnTaoKhauHao";
            this.btnTaoKhauHao.Size = new System.Drawing.Size(121, 24);
            this.btnTaoKhauHao.TabIndex = 14;
            this.btnTaoKhauHao.Text = "Lưu";
            this.btnTaoKhauHao.Click += new System.EventHandler(this.btnTaoKhauHao_Click);
            // 
            // NgayTao
            // 
            this.NgayTao.Caption = "Ngày tạo";
            this.NgayTao.FieldName = "NgayTao";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Visible = true;
            this.NgayTao.VisibleIndex = 0;
            // 
            // frmTaoKhauHao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 653);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmTaoKhauHao";
            this.Text = "frmTaoKhauHao";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnTaoKhauHao;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaKhauHao;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhauHao;
        private DevExpress.XtraGrid.Columns.GridColumn NguyenGia;
        private DevExpress.XtraGrid.Columns.GridColumn ThoiGianSuDung;
        private DevExpress.XtraGrid.Columns.GridColumn GiaTriKhauHaoThang;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn NgayTao;
    }
}