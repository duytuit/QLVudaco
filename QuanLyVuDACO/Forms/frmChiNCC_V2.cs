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
    public partial class frmChiNCC_V2 : DevExpress.XtraEditors.XtraForm
    {
        public frmChiNCC_V2(DataTable dt)
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridControl1.DataSource = dt;
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmDoiTuong_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboNganHang.DataSource = client.DanhMucNganHang_Load();
            cboNganHang.DisplayMember = "TenNganHang";
            cboNganHang.ValueMember = "SoTK";
            radioGroup1_SelectedIndexChanged(sender, e);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex==0)
            {
                panel2.Enabled = false;
            }    
            else
            {
                panel2.Enabled = true;
            }
            cboNganHang_SelectedIndexChanged(sender, e);
        }

        private void cboNganHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboNganHang.Text=="")
            {
                lblChuTK.Text = "";
                lblSoTK.Text = "";
                lblChiNhanh.Text = "";
            }    
            else
            {
                ServiceReference1.DanhMucNganHang p = new ServiceReference1.DanhMucNganHang();
                p.SoTK = cboNganHang.SelectedValue.ToString();
              var table=  client.DanhMucNganHang_Load_ThéoTK(p);
                foreach (var item in table)
                {
                    lblChuTK.Text = item.ChuTaiKhoan;
                    lblSoTK.Text = item.SoTK;
                    lblChiNhanh.Text = item.ChiNhanh;
                }
               
            }    
        }


        private void frmChiNCC_V2_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (var _db = new clsKetNoi())
            {
                string[] arr = dtpNgay.Text.Trim().Split('/');
                var p = new
                {
                    IDPhieuChiNCC = 0,
                    SoChungTu = client.TaoSoChungTu_Chi_NCC(arr),
                    NgayHachToan = Convert.ToDateTime(dtpNgay.Text),
                    MaChi = "006",
                    LyDoChi = "Chi trả tiền nhà cung cấp",
                    DienGiai = txtDienGiai.Text,
                    NguoiTao = frmMain._TK,
                    ThoiGianTao = DateTime.Now,
                    NguoiNhan = frmMain._HoTen,
                    HinhThucTT = (radioGroup1.SelectedIndex == 0) ? "TM" : "CK",
                    SoTK = lblSoTK.Text,
                    TenNganHang = (radioGroup1.SelectedIndex == 0) ? "" : cboNganHang.Text,
                    ChiNhanh = (radioGroup1.SelectedIndex == 0) ? "" : lblChiNhanh.Text,
                    ChuTaiKhoan = (radioGroup1.SelectedIndex == 0) ? "" : lblChuTK.Text,
                };
                int _id_pchi = _db.UpsertFromObject("PhieuChi_NCC", p, "IDPhieuChiNCC", true);
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var phieuchitiet = new
                    {
                        IDCTNCC = 0,
                        IDCP = 0,
                        SoChungTu = p.SoChungTu,
                        SoFile = gridView1.GetRowCellValue(i, "SoFile").ToString(),
                        MaNhanVien = "",
                        SoTien = gridView1.GetRowCellValue(i, "SoTien").ToString(),
                        DoiTuong = "NCC",
                        MaDoiTuong = gridView1.GetRowCellValue(i, "MaNhaCungCap").ToString(),
                        TenDoiTuong = gridView1.GetRowCellValue(i, "TenNhaCungCap").ToString(),
                        DiaChi = "",
                        VAT = 0,
                        ThanhTien = gridView1.GetRowCellValue(i, "SoTien").ToString(),
                        GhiChu = "",
                        IDPhieuChi = _id_pchi,
                        LaVanChuyen = Convert.ToInt32(gridView1.GetRowCellValue(i, "Type").ToString()) == 3 ? 0 : 1,
                        KeyName = gridView1.GetRowCellValue(i, "Key").ToString(),
                        IDName = gridView1.GetRowCellValue(i, "ID").ToString()
                    };
                    _db.UpsertFromObject("PhieuChi_NCC_CT", phieuchitiet, "IDCTNCC", true);
                }
                MessageBox.Show("Tạo phiếu chi xong!");
                this.Close();
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }
    }
}