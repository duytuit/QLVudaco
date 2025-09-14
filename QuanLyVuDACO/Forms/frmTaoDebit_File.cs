using DevExpress.XtraEditors;
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
    public partial class frmTaoDebit_File : DevExpress.XtraEditors.XtraForm
    {
        public frmTaoDebit_File()
        {
            InitializeComponent();
        }
        public frmTaoDebit_File(DataTable _dt)
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
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                ServiceReference1.FileDebit_KoHoaDon_KH p = new ServiceReference1.FileDebit_KoHoaDon_KH();
                p.MaDieuXe = gridView2.GetRowCellValue(i,"MaDieuXe").ToString().Trim();
                p.MaKhachHang = gridView2.GetRowCellValue(i, "MaKhachHang").ToString().Trim();
                p.LoaiXe_KH =  gridView2.GetRowCellValue(i, "LoaiXe_KH").ToString().Trim();
                p.SoHoaDon = gridView2.GetRowCellValue(i, "SoHoaDon").ToString().Trim();
                p.TuyenVC = gridView2.GetRowCellValue(i, "TuyenVC").ToString().Trim();
                p.CuocMua = (gridView2.GetRowCellValue(i, "CuocMua").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "CuocMua").ToString().Trim());
                p.CuocBan = (gridView2.GetRowCellValue(i, "CuocBan").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "CuocBan").ToString().Trim());
                p.LaiXeThuCuoc = (gridView2.GetRowCellValue(i, "LaiXeThuCuoc").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "LaiXeThuCuoc").ToString().Trim());
                p.NguoiTao = frmMain._TK;
                string[] arr1 = dtpNgay.Text.Split('/');
                if (arr1.Length == 3)
                    p.NgayTao = (dtpNgay.Text == "") ? DateTime.Now : new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                p.TenDichVu = gridView2.GetRowCellValue(i, "TuyenVC").ToString().Trim();
                p.SoTien = (gridView2.GetRowCellValue(i, "SoTien").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "SoTien").ToString().Trim());
                p.VAT = (gridView2.GetRowCellValue(i, "VAT").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "VAT").ToString().Trim());
                //
                double _vat = float.Parse(p.VAT.ToString());
                double _SoTien = p.SoTien.Value;
                double _SoTienVAT = (_vat * _SoTien) / 100;
                //
                p.ThanhTien = _SoTien + _SoTienVAT;
                p.GhiChu = "";
                p.PhiCom = (gridView2.GetRowCellValue(i, "PhiCom").ToString().Trim() == "") ? 0 : double.Parse(gridView2.GetRowCellValue(i, "PhiCom").ToString().Trim());
                p.MaNhaCungCap = gridView2.GetRowCellValue(i, "MaNhaCungCap").ToString().Trim();
                p.DoanhThuThuan = p.SoTien - p.PhiCom;
                client.ThemFileDebit_KoHoaDon_KH(p);
              
            }
            MessageBox.Show("Thêm thành công!");
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
    }
}