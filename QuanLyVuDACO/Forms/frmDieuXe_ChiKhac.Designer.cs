
namespace Quản_lý_vudaco.Forms
{
    partial class frmDieuXe_ChiKhac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiKhac));
            this.gridChiKhac = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDBangPhi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDungChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Quản_lý_vudaco.DataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiKhac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridChiKhac
            // 
            this.gridChiKhac.DataMember = "BangPhiDiDuong_ChiKhac";
            this.gridChiKhac.DataSource = this.dataSet1BindingSource;
            this.gridChiKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChiKhac.Location = new System.Drawing.Point(0, 0);
            this.gridChiKhac.MainView = this.gridView1;
            this.gridChiKhac.Name = "gridChiKhac";
            this.gridChiKhac.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemXoa});
            this.gridChiKhac.Size = new System.Drawing.Size(904, 519);
            this.gridChiKhac.TabIndex = 2;
            this.gridChiKhac.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDCT,
            this.colIDBangPhi,
            this.colSoTienChi,
            this.colNoiDungChi,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridChiKhac;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIDCT
            // 
            this.colIDCT.FieldName = "IDCT";
            this.colIDCT.MinWidth = 25;
            this.colIDCT.Name = "colIDCT";
            this.colIDCT.Width = 94;
            // 
            // colIDBangPhi
            // 
            this.colIDBangPhi.FieldName = "IDBangPhi";
            this.colIDBangPhi.MinWidth = 25;
            this.colIDBangPhi.Name = "colIDBangPhi";
            this.colIDBangPhi.Width = 94;
            // 
            // colSoTienChi
            // 
            this.colSoTienChi.Caption = "Số tiền chi";
            this.colSoTienChi.DisplayFormat.FormatString = "#,##";
            this.colSoTienChi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTienChi.FieldName = "SoTienChi";
            this.colSoTienChi.MinWidth = 25;
            this.colSoTienChi.Name = "colSoTienChi";
            this.colSoTienChi.Visible = true;
            this.colSoTienChi.VisibleIndex = 1;
            this.colSoTienChi.Width = 176;
            // 
            // colNoiDungChi
            // 
            this.colNoiDungChi.Caption = "Nội dung chi";
            this.colNoiDungChi.FieldName = "NoiDungChi";
            this.colNoiDungChi.MinWidth = 25;
            this.colNoiDungChi.Name = "colNoiDungChi";
            this.colNoiDungChi.Visible = true;
            this.colNoiDungChi.VisibleIndex = 0;
            this.colNoiDungChi.Width = 467;
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.repositoryItemXoa;
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 94;
            // 
            // repositoryItemXoa
            // 
            this.repositoryItemXoa.AutoHeight = false;
            this.repositoryItemXoa.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemXoa.Image")));
            this.repositoryItemXoa.Name = "repositoryItemXoa";
            this.repositoryItemXoa.NullText = "Xoá";
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
            // frmChiKhac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 519);
            this.Controls.Add(this.gridChiKhac);
            this.Name = "frmChiKhac";
            this.Text = "frmChiKhac";
            this.Load += new System.EventHandler(this.frmChiKhac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridChiKhac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridChiKhac;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCT;
        private DevExpress.XtraGrid.Columns.GridColumn colIDBangPhi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienChi;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDungChi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemXoa;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
    }
}