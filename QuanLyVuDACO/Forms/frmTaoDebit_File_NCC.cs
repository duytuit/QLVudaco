using DevExpress.XtraEditors;
using Quản_lý_vudaco.services;
using Quản_lý_vudaco.services.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.Forms
{
    public partial class frmTaoDebit_File_NCC : DevExpress.XtraEditors.XtraForm
    {
        public frmTaoDebit_File_NCC()
        {
            InitializeComponent();
        }
        public frmTaoDebit_File_NCC(DataTable _dt)
        {
            InitializeComponent();
            dt = _dt;
        }
        DataTable dt = new DataTable();

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
        private void LoadVAT()
        {
            DataTable dt = new DataTable("VAT");
            dt.Columns.Add("VAT");
            dt.Columns.Add("Ten");
            DataRow row = dt.NewRow();
            row["VAT"] = 0;
            row["Ten"] = 0;
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["VAT"] = 5;
            row1["Ten"] = 5;
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["VAT"] = 8;
            row2["Ten"] = 8;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["VAT"] = 10;
            row3["Ten"] = 10;
            dt.Rows.Add(row3);

            DataRow row4 = dt.NewRow();
            row4["VAT"] = -1;
            row4["Ten"] = "Khác";
            dt.Rows.Add(row4);
            repositoryItemVAT.DataSource = dt;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmTaoDebit_File_Load(object sender, EventArgs e)
        {
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadVAT();
            repositoryItemNhaCungCap.DataSource = client.ds_NCC();
            gridControl2.DataSource = dt;
        }

        private void btntaoDebit_Click(object sender, EventArgs e)
        {
            using (var _appDB = new clsKetNoi())
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    FileDebit p1 = new FileDebit();
                    string[] arr = dtpNgay.Text.Split('/');
                    if (arr.Length == 3)
                        p1.ThoiGianLap = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                    p1.NguoiLap = frmMain._TK;
                    p1.Type = 1;
                    p1.MaDieuXe = gridView2.GetRowCellValue(i, "MaDieuXe").ToString().Trim();
                    int id_debit = _appDB.UpsertFromObject("FileDebitNcc", p1, "IDDeBit", true);
                    FileDebitChiTiet p2 = new FileDebitChiTiet();
                    p2.SoHoaDon = gridView2.GetRowCellValue(i, "SoHoaDon").ToString().Trim();
                    p2.TenDichVu = gridView2.GetRowCellValue(i, "TuyenVC").ToString().Trim();
                    p2.MaNhaCungCap = gridView2.GetRowCellValue(i, "MaNhaCungCap").ToString().Trim();
                    p2.SoTien = (gridView2.GetRowCellValue(i, "SoTien").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "SoTien").ToString().Trim());
                    p2.VAT = (gridView2.GetRowCellValue(i, "VAT").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "VAT").ToString().Trim());
                    double _vat = float.Parse(p2.VAT.ToString());
                    double _SoTien = p2.SoTien.Value;
                    double _SoTienVAT = (_vat * _SoTien) / 100;
                    p2.ThanhTien = _SoTien + _SoTienVAT;
                    p2.GhiChu = "";
                    p2.IDDeBit = id_debit;
                    p2.IDKey = int.Parse(gridView2.GetRowCellValue(i, "IDBangPhi").ToString());
                    p2.KeyName = "bangdieuxe";
                    _appDB.UpsertFromObject("FileDebitNccChiTiet", p2, "IDDeBitCT", true);
                }
            }
          
            MessageBox.Show("Thêm thành công!");
            this.Close();
        }

        private void copyDòngChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy dòng chọn
            Clipboard.SetText(_VAT.ToString());
        }

        private void copyVàPasteXuốngCácDòngBênDướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy dòng chọn và paste xuống bên dưới
            int rowIndex = gridView2.FocusedRowHandle;
            string _value = gridView2.GetRowCellValue(rowIndex, "VAT").ToString();
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (i != rowIndex)
                    gridView2.SetRowCellValue(i,"VAT",_value);
            }
        }
        int _VAT = 0;
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName=="VAT")
            {
                _VAT =(e.Value.ToString()=="")?0: int.Parse(e.Value.ToString());
            }    
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repositoryItemVAT_EditValueChanged(object sender, EventArgs e)
        {
            int _index = gridView2.FocusedRowHandle;
            try
            {
                LookUpEdit lookUpEdit = (LookUpEdit)sender;
                if (lookUpEdit.EditValue.ToString().Trim().ToLower() == "-1")
                {
                    gridView2.SetRowCellValue(_index, "VAT", -1);
                    gridView2.SetRowCellValue(_index, "ThanhTien", 0);
                }
                else
                {
                    gridView2.SetRowCellValue(_index, "VAT", lookUpEdit.EditValue.ToString());
                    float _vat = float.Parse(gridView2.GetRowCellDisplayText(_index, "VAT").Trim());
                    float _SoTien = float.Parse(gridView2.GetRowCellDisplayText(_index, "SoTien").Trim());
                    float _SoTienVAT = (_vat * _SoTien) / 100;
                    gridView2.SetRowCellValue(_index, "ThanhTien", _SoTien + _SoTienVAT);

                }

            }
            catch (Exception)
            {
            }
        }
    }
}