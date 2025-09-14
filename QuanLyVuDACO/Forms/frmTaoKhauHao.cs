using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class frmTaoKhauHao : DevExpress.XtraEditors.XtraForm
    {

       private int _loai = 0;
        public frmTaoKhauHao(int loai)
        {
            InitializeComponent();
            _loai = loai;
        }

        private void btnTaoKhauHao_Click(object sender, EventArgs e)
        {
            // Đảm bảo commit dữ liệu đang chỉnh sửa xuống DataSource
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            using (var db = new clsKetNoi())
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsNewItemRow(i)) continue;

                    // Lấy giá trị từ GridView
                    string maKh = gridView1.GetRowCellValue(i, "MaKhauHao")?.ToString()?.Trim();
                    string tenKh = gridView1.GetRowCellValue(i, "TenKhauHao")?.ToString()?.Trim();
                    object nguyenGiaObj = gridView1.GetRowCellValue(i, "NguyenGia");
                    object thoiGianObj = gridView1.GetRowCellValue(i, "ThoiGianSuDung");

                    // Kiểm tra dữ liệu trống hoặc null
                    if (string.IsNullOrEmpty(maKh) ||
                        string.IsNullOrEmpty(tenKh) ||
                        nguyenGiaObj == null || nguyenGiaObj == DBNull.Value ||
                        thoiGianObj == null || thoiGianObj == DBNull.Value)
                    {
                        continue; // Bỏ qua dòng này, không lưu
                    }

                    string soChungTu = db.GenerateSoChungTu("KhauHao", "SoChungTu", LoaiKhauHao(_loai), 8);
                   // string[] arr = dtpNgay.Text.Split('/');
                   // if (arr.Length == 3)
                   //     p1.ThoiGianLap = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                    var _khauhao = new KhauHao()
                    {
                        SoChungTu = soChungTu,
                        NguoiTao = frmMain._HoTen,
                        NgayTao = gridView1.GetRowCellValue(i, "NgayTao") == DBNull.Value ? DateTime.Now : Convert.ToDateTime(gridView1.GetRowCellValue(i, "NgayTao")),
                        MaKhauHao = maKh,
                        TenKhauHao = tenKh,
                        NguyenGia = float.Parse(nguyenGiaObj.ToString()),
                        ThoiGianSuDung = Convert.ToInt32(thoiGianObj),
                        GiaTriKhauHaoThang = Convert.ToDouble(gridView1.GetRowCellValue(i, "GiaTriKhauHaoThang").ToString()),
                        GhiChu = gridView1.GetRowCellValue(i, "GhiChu")?.ToString(),
                        Loai = _loai
                    };

                    db.UpsertFromObject("KhauHao", _khauhao, "ID");
                }
            }

            MessageBox.Show("Đã lưu dữ liệu vào CSDL");
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

           if (e.Column.FieldName == "NguyenGia" || e.Column.FieldName == "ThoiGianSuDung")
           {
               int nguyenGia = 0;
               float thoiGian = 0;
                // Parse trực tiếp từ object
               int.TryParse(gridView1.GetRowCellValue(e.RowHandle, "NguyenGia")?.ToString(), out nguyenGia);
               float.TryParse(gridView1.GetRowCellValue(e.RowHandle, "ThoiGianSuDung")?.ToString(), out thoiGian);
                // Tính giá trị khấu hao tháng
               double giaTriThang = nguyenGia / thoiGian;
               gridView1.SetRowCellValue(e.RowHandle, "GiaTriKhauHaoThang", giaTriThang);
           }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgayTao", typeof(DateTime));
            dt.Columns.Add("MaKhauHao", typeof(string));
            dt.Columns.Add("TenKhauHao", typeof(string));
            dt.Columns.Add("NguyenGia", typeof(int));
            dt.Columns.Add("ThoiGianSuDung", typeof(int));
            dt.Columns.Add("GiaTriKhauHaoThang", typeof(float));
            dt.Columns.Add("GhiChu", typeof(string));
            gridControl1.DataSource = dt;

            RepositoryItemButtonEdit maskedDateEdit = new RepositoryItemButtonEdit();

            // Mask nhập ngày dd/MM/yyyy
            maskedDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            maskedDateEdit.Mask.EditMask = "00/00/0000";
            maskedDateEdit.Mask.UseMaskAsDisplayFormat = true;
            maskedDateEdit.Mask.SaveLiteral = true;
            maskedDateEdit.Mask.IgnoreMaskBlank = false;

            // Gán vào cột NgayTao
            gridControl1.RepositoryItems.Add(maskedDateEdit);
            gridView1.Columns["NgayTao"].ColumnEdit = maskedDateEdit;
        }
        private string LoaiKhauHao(int type)
        {
            switch (type)
            {
                case 1:
                    return "TSCD";
                case 2:
                    return "CPTT";
                case 3:
                    return "CPC";
                default:
                    return "";
            }
        }
    }
}