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
    public partial class frmFileDebit : DevExpress.XtraEditors.XtraForm
    {
        public int _Id_debit { get; private set; } = 0;
        public frmFileDebit()
        {
            InitializeComponent();
        }
        public frmFileDebit(int IDGia)
        {
            InitializeComponent();
            _IDGia = IDGia;
        }
        public frmFileDebit(int IDGia,int sua)
        {
            InitializeComponent();
            _IDGia = IDGia;
            _sua = sua;
        }
        public frmFileDebit(int IDLoHang,int IDGia, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _IDGia = IDGia;
            _sua = sua;
        }
        public frmFileDebit(int IDLoHang, int IDGia, int sua, int ncc, int kh ,string madieuxe = null)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _IDGia = IDGia;
            _sua = sua;
            _NCC = ncc;
            _Madieuxe = madieuxe;
        }
        public frmFileDebit(int IDDeBit,int IDLoHang, int IDGia, int sua)
        {
            InitializeComponent();
            _IDDeBit = IDDeBit;
            _IDLoHang = IDLoHang;
            _IDGia = IDGia;
            _sua = sua;
        }
        int _IDGia = 0, _sua = 0, _IDLoHang = 0, _IDDeBit = 0, _NCC = 0;
        string  _Madieuxe = null;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

        DataTable dtFull = new DataTable("table");
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
        private void frmBangKeChiPhi_Load(object sender, EventArgs e)
        {

            LoadVAT();
            if (_Madieuxe != null && _Madieuxe != "")
            {
                using (var _ncc = new ncc())
                {
                    DataTable bang_phi = _ncc.LayBangphiTheoMaDieuXe(_Madieuxe);
                    if (bang_phi.Rows.Count > 0)
                    {
                        DataRow row = bang_phi.Rows[0];
                        lblKh.Text = row["TenKhachHang"].ToString();
                        lblSoFile.Text = row["MaDieuXe"].ToString();
                        lblSoToKhai.Text = "...";
                        lblSoBill.Text = "...";
                        lblSoLuong.Text = "...";
                        lblSoCont.Text = "...";
                        lblTenSales.Text = row["NguoiTao"].ToString();
                        dtpNgay.Text = DateTime.Parse(row["Ngay"].ToString()).ToString("dd/MM/yyyy");
                        gridControl1.DataSource = bang_phi;
                    }
                }

            }
            else
            {
                dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable dt = client.DsThongTinFile_Full_TheoIDLoHang_FileGia(_IDLoHang);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblKh.Text = row["TenKhachHang"].ToString();
                    lblSoFile.Text = row["SoFile"].ToString();
                    lblSoToKhai.Text = row["SoToKhai"].ToString();
                    lblSoBill.Text = row["SoBill"].ToString();
                    lblSoLuong.Text = row["SoLuong"].ToString();
                    lblSoCont.Text = row["SoCont"].ToString();
                    lblTenSales.Text = row["TenSales"].ToString();
                    _IDLoHang = int.Parse(row["IDLoHang"].ToString());
                    if (row["ThoiGianLap"].ToString() != "")
                        dtpNgay.Text = DateTime.Parse(row["ThoiGianLap"].ToString()).ToString("dd/MM/yyyy");
                    //chi tiet
                    using (var _ncc = new ncc())
                    {
                        DataTable dtCT = _ncc.ChiTietNoiDungTaoDebit(int.Parse(row["IDGia"].ToString()), _NCC);

                        for (int i = 0; i < dtCT.Rows.Count; i++)
                        {
                            
                            if (_NCC == 1)
                            {
                                dtCT.Rows[i]["SoTien"] = dtCT.Rows[i]["GiaMua"].ToString() != "" ? double.Parse(dtCT.Rows[i]["GiaMua"].ToString()) : 0;
                            }
                            if (bool.Parse(dtCT.Rows[i]["LaPhiChiHo"].ToString()))
                            {
                                dtCT.Rows[i]["VAT"] = 0;
                                dtCT.Rows[i]["ThanhTienVAT"] = 0;
                                dtCT.Rows[i]["ThanhTien"] = double.Parse(dtCT.Rows[i]["SoTien"].ToString());
                            }

                        }
                        gridControl1.DataSource = dtCT;
                        dtFull = dtCT;
                        gridColumn2.OptionsColumn.ReadOnly = false;
                        gridColumn5.OptionsColumn.ReadOnly = false;
                    }

                }
                if (_sua == 1)
                {
                    using (var _ncc = new ncc())
                    {
                        DataTable dtCT = _ncc.ChiTietNoiDungTaoDebit_Sua(_IDDeBit);
                        gridControl1.DataSource = dtCT;
                        dtFull = dtCT;
                    }
                    btnLuu.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    gridColumn2.OptionsColumn.ReadOnly = true;
                    gridColumn5.OptionsColumn.ReadOnly = true;
                }
                else
                {
                    btnLuu.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
           
        }
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            using (var _appDB = new clsKetNoi())
            {
                if (_Madieuxe != null && _Madieuxe != "")
                {
                    if (gridView1.RowCount == 0)
                        MessageBox.Show("Không có thông tin cần truy vấn!");
                    else
                    {
                            FileDebit p1 = new FileDebit();
                            string[] arr = dtpNgay.Text.Split('/');
                            if (arr.Length == 3)
                                p1.ThoiGianLap = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                            p1.NguoiLap = frmMain._TK;
                            p1.MaDieuXe = _Madieuxe;
                            p1.Type = _NCC;
                            int id_debit = _appDB.UpsertFromObject("FileDebit", p1, "IDDeBit", true);
                            //
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                if (!gridView1.IsNewItemRow(i))
                                {
                                    FileDebitChiTiet p2 = new FileDebitChiTiet();
                                    p2.SoHoaDon = gridView1.GetRowCellDisplayText(i, "SoHoaDon").Trim();
                                    p2.TenDichVu = gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim();
                                    p2.MaNhaCungCap = (gridView1.GetRowCellDisplayText(i, "MaNhaCungCap") != null) ? gridView1.GetRowCellDisplayText(i, "MaNhaCungCap").ToString().Trim() : "";
                                    if (gridView1.GetRowCellDisplayText(i, "SoTien").Trim() == "")
                                        p2.SoTien = 0;
                                    if (gridView1.GetRowCellDisplayText(i, "ThanhTien") != "")
                                        p2.ThanhTien = float.Parse(gridView1.GetRowCellDisplayText(i, "ThanhTien").ToLower().Trim());
                                    else
                                        p2.ThanhTien = 0;
                                    // }    
                                    if (gridView1.GetRowCellDisplayText(i, "SoTien") != "")
                                        p2.SoTien = float.Parse(gridView1.GetRowCellDisplayText(i, "SoTien").ToLower().Trim());
                                    else
                                        p2.SoTien = 0;
                                    if (gridView1.GetRowCellDisplayText(i, "VAT").ToLower() != "khác")
                                    {
                                        if (gridView1.GetRowCellDisplayText(i, "VAT").ToLower() != "")
                                            p2.VAT = float.Parse(gridView1.GetRowCellDisplayText(i, "VAT").ToLower().Trim());
                                        else
                                            p2.VAT = 0;
                                    }
                                    else
                                    {
                                        p2.VAT = -1;
                                        p2.SoTien = 0;
                                    }
                                    p2.IDDeBit = id_debit;
                                    _Id_debit = p2.IDDeBit ?? 0;
                                    p2.GhiChu = gridView1.GetRowCellDisplayText(i, "GhiChu").Trim();
                                    p2.LaPhiChiHo = bool.Parse(gridView1.GetRowCellValue(i, "LaPhiChiHo").ToString().Trim());
                                    if (p2.TenDichVu != "")
                                    {
                                         _appDB.UpsertFromObject("FileDebitChiTiet", p2, "IDDeBitCT", true);
                                    }

                                }
                            }
                   
                        MessageBox.Show("Thao tác thành công!");
                        _IDDeBit = 0;
                        this.Close();
                    }
                }
                else
                {
                    if (gridView1.RowCount == 0)
                        MessageBox.Show("Không có thông tin cần truy vấn!");
                    else
                    {
                        FileDebit p1 = new FileDebit();
                        p1.IDGia = _IDGia;
                        p1.SoFile = lblSoFile.Text;
                        string[] arr = dtpNgay.Text.Split('/');
                        if (arr.Length == 3)
                            p1.ThoiGianLap = new DateTime(int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
                        p1.NguoiLap = frmMain._TK;
                        p1.IDLoHang = _IDLoHang;
                        p1.Type = _NCC;
                        int id_debit = _appDB.UpsertFromObject("FileDebit", p1, "IDDeBit", true);
                        //
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (!gridView1.IsNewItemRow(i))
                            {
                                FileDebitChiTiet p2 = new FileDebitChiTiet();
                                p2.SoHoaDon = gridView1.GetRowCellDisplayText(i, "SoHoaDon").Trim();
                                p2.TenDichVu = gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim();
                                p2.MaNhaCungCap = (gridView1.GetRowCellDisplayText(i, "MaNhaCungCap") != null) ? gridView1.GetRowCellDisplayText(i, "MaNhaCungCap").ToString().Trim() : "";
                                if (gridView1.GetRowCellDisplayText(i, "SoTien").Trim() == "")
                                    p2.SoTien = 0;
                                if (gridView1.GetRowCellDisplayText(i, "ThanhTien") != "")
                                    p2.ThanhTien = float.Parse(gridView1.GetRowCellDisplayText(i, "ThanhTien").ToLower().Trim());
                                else
                                    p2.ThanhTien = 0;
                                // }    
                                if (gridView1.GetRowCellDisplayText(i, "SoTien") != "")
                                    p2.SoTien = float.Parse(gridView1.GetRowCellDisplayText(i, "SoTien").ToLower().Trim());
                                else
                                    p2.SoTien = 0;
                                if (gridView1.GetRowCellDisplayText(i, "VAT").ToLower() != "khác")
                                {
                                    if (gridView1.GetRowCellDisplayText(i, "VAT").ToLower() != "")
                                        p2.VAT = float.Parse(gridView1.GetRowCellDisplayText(i, "VAT").ToLower().Trim());
                                    else
                                        p2.VAT = 0;
                                }
                                else
                                {
                                    p2.VAT = -1;
                                    p2.SoTien = 0;
                                }
                                p2.IDDeBit = client.Top1FileDebit();
                                _Id_debit = p2.IDDeBit ?? 0;
                                p2.GhiChu = gridView1.GetRowCellDisplayText(i, "GhiChu").Trim();
                                p2.LaPhiChiHo = bool.Parse(gridView1.GetRowCellValue(i, "LaPhiChiHo").ToString().Trim());
                                if (p2.TenDichVu != "")
                                {
                                    int a = _appDB.UpsertFromObject("FileDebitChiTiet", p2, "IDDeBitCT", true);
                                }

                            }
                        }
                        MessageBox.Show("Thao tác thành công!");
                        _IDDeBit = 0;
                        this.Close();
                    }
                }
            }
        }
        double _giaMua = 0;
       
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_IDDeBit > 0)
            {
                client.XoaFileDebit(_IDDeBit);
                btnLuu_Click_1(sender, e);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "ThanhTienVAT")
            {
              
                float _SoTien = (gridView1.GetFocusedRowCellDisplayText("SoTien").Trim()=="")?0:float.Parse(gridView1.GetFocusedRowCellDisplayText( "SoTien").Trim());
                float _SoTienVAT = (gridView1.GetFocusedRowCellDisplayText("ThanhTienVAT").Trim()=="")?0:float.Parse(gridView1.GetFocusedRowCellDisplayText("ThanhTienVAT").Trim());
                gridView1.SetFocusedRowCellValue("ThanhTien", _SoTien + _SoTienVAT);
            }    
        }

        private void repositoryItemVAT_EditValueChanged(object sender, EventArgs e)
        {
            int _index = gridView1.FocusedRowHandle;
            try
            {
                LookUpEdit lookUpEdit = (LookUpEdit)sender;
                if (lookUpEdit.EditValue.ToString().Trim().ToLower() == "-1")
                {
                       gridView1.SetRowCellValue(_index, "VAT", -1);
                        gridView1.SetRowCellValue(_index, "ThanhTien", 0);
                }
                else
                {
                    gridView1.SetRowCellValue(_index, "VAT", lookUpEdit.EditValue.ToString());
                    float _vat = float.Parse(gridView1.GetRowCellDisplayText(_index, "VAT").Trim());
                    float _SoTien = float.Parse(gridView1.GetRowCellDisplayText(_index, "SoTien").Trim());
                    float _SoTienVAT = (_vat * _SoTien) / 100;
                    gridView1.SetRowCellValue(_index, "ThanhTienVAT", _SoTienVAT);
                    gridView1.SetRowCellValue(_index, "ThanhTien", _SoTien + _SoTienVAT);

                }
               
            }
            catch (Exception)
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                client.XoaFileDebit(_IDDeBit);
                frmBangKeChiPhi_Load(sender, e);
            }    
        }

    }
}