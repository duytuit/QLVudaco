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
    public partial class frmBangPhiDiDuong : DevExpress.XtraEditors.XtraForm
    {
        public frmBangPhiDiDuong()
        {
            InitializeComponent();
        }
        public frmBangPhiDiDuong(int _IDBangPhi)
        {
            InitializeComponent();
            IDLoHang = _IDBangPhi;
        }
        int IDLoHang = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            XoaText();
            NguoiTaoTextEdit.Text = frmMain._TK;
            NguoiTaoTextEdit.Enabled = false;
            if (IDLoHang==0)
            {
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }    
            else
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                //xem lai thong tin da nhap 
                var table = client.DSBangPhiDiDuong_TheoIDBangPhi(IDLoHang); 
                foreach (var item in table)
                {
                    NgayDateEdit.DateTime = item.Ngay.Value;
                    TuyenVCTextEdit.Text = item.TuyenVC;
                    LaiXeThuCuocTextEdit.Text = item.LaiXeThuCuoc.Value.ToString();
                    TienAnTextEdit.Text = item.TienAn.Value.ToString();
                    TienVeTextEdit.Text = item.TienVe.Value.ToString();
                    QuaDemTextEdit.Text = item.QuaDem.Value.ToString();
                    TienLuatTextEdit.Text = item.TienLuat.Value.ToString();
                    LuongHangVeTextEdit.Text = item.LuongHangVe.Value.ToString();
                    NguoiTaoTextEdit.Text = item.NguoiTao;
                    GhiChuTextEdit.Text = item.GhiChu;
                    DiemTraHangTextEdit.Text = item.DiemTraHang.Value.ToString();
                    int id = item.IDBangPhi;
                    var tablect = client.DSBangPhiDiDuong_ChiKhac_TheoIDBangPhi(id);
                    dataSet1.Tables["BangPhiDiDuong_ChiKhac"].Rows.Clear();
                    foreach (var item1 in tablect)
                    {
                        DataRow row = dataSet1.Tables["BangPhiDiDuong_ChiKhac"].NewRow();
                        row["IDBangPhi"] = item1.IDBangPhi;
                        row["NoiDungChi"] = item1.NoiDungChi;
                        row["SoTienChi"] = item1.SoTienChi;
                        dataSet1.Tables["BangPhiDiDuong_ChiKhac"].Rows.Add(row);
                    }
                    gridChiKhac.DataSource = dataSet1.Tables["BangPhiDiDuong_ChiKhac"];
                }
            }    
        }
      
        private void XoaText()
        {
            NgayDateEdit.DateTime = DateTime.Now;
            TuyenVCTextEdit.Text = "";
            LaiXeThuCuocTextEdit.Text = "";
            TienAnTextEdit.Text = "";
            TienVeTextEdit.Text = "";
            QuaDemTextEdit.Text = "";
            TienLuatTextEdit.Text = "";
            LuongHangVeTextEdit.Text = "";
            NguoiTaoTextEdit.Text = frmMain._TK;
            DiemTraHangTextEdit.Text = "";
            GhiChuTextEdit.Text = "";
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            IDLoHang = 0;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (NgayDateEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn ngày!");
            else if(TuyenVCTextEdit.Text=="")
                MessageBox.Show("Vui lòng nhập tuyến vận chuyển!");
            else
            {
               
               ServiceReference1. BangPhiDiDuong table1 = new ServiceReference1. BangPhiDiDuong();
                table1.Ngay = NgayDateEdit.DateTime;
                table1.TuyenVC = TuyenVCTextEdit.Text;
                table1.LaiXeThuCuoc = (LaiXeThuCuocTextEdit.Text == "") ? 0 : float.Parse(LaiXeThuCuocTextEdit.Text);
                table1.TienAn = (TienAnTextEdit.Text == "") ? 0 : float.Parse(TienAnTextEdit.Text);
                table1.TienVe = (TienVeTextEdit.Text == "") ? 0 : float.Parse(TienVeTextEdit.Text);
                table1.QuaDem = (QuaDemTextEdit.Text == "") ? 0 : float.Parse(QuaDemTextEdit.Text);
                table1.TienLuat = (TienLuatTextEdit.Text == "") ? 0 : float.Parse(TienLuatTextEdit.Text);
                table1.LuongHangVe = (LuongHangVeTextEdit.Text == "") ? 0 : float.Parse(LuongHangVeTextEdit.Text);
                table1.NguoiTao = NguoiTaoTextEdit.Text;
                table1.GhiChu = GhiChuTextEdit.Text;
                table1.DiemTraHang= (DiemTraHangTextEdit.Text == "") ? 0 : float.Parse(DiemTraHangTextEdit.Text);
                client.DsBangPhiDiDuong_Them(table1);
                //
                int id1 = 0;
                var t = client.DSBangPhiDiDuong_Top1(); 
                foreach (var item in t)
                {
                    id1 = item.IDBangPhi;
                }
                if(gridView1.RowCount>0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                       ServiceReference1. BangPhiDiDuong_ChiKhac table2 = new ServiceReference1. BangPhiDiDuong_ChiKhac();
                        table2.IDBangPhi = id1;
                        table2.NoiDungChi = gridView1.GetRowCellDisplayText(i, "NoiDungChi");
                        table2.SoTienChi = float.Parse(gridView1.GetRowCellDisplayText(i, "SoTienChi"));
                        table2.Ngay = NgayDateEdit.DateTime;
                        table2.TaiKhoan = frmMain._TK;
                        client.DsBangPhiDiDuong_ChiKhac_Them(table2);
                    }
                }    
                 btnThemMoi_Click(sender, e);
                  
            }    
        }

      

        private void btnSua_Click(object sender, EventArgs e)
        {
            xoaThongTin();
            btnLuu_Click(sender, e);
        }
        private void xoaThongTin()
        {
            client.BangDiDuong_xoa(IDLoHang);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (frmMain._TK != "admin")
            //    MessageBox.Show("Chỉ Admin mới có quyền này");
            //else
            //{
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                xoaThongTin();
                 btnThemMoi_Click(sender, e);
                }
          //  }
        }
        int dong_HQ = -1;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtNoiDungChi.Text == "")
                MessageBox.Show("Nhập nội dung chi khác!");
            else if (txtSoTienChi.Text == "")
                MessageBox.Show("Nhập số tiền chi khác!");
            else
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("SoTienChi", txtSoTienChi.Text);
                gridView1.SetFocusedRowCellValue("NoiDungChi", txtNoiDungChi.Text);
                gridView1.FocusedRowHandle = 0;
            }
        }

        private void btnXoaHQ_Click(object sender, EventArgs e)
        {
            if (dong_HQ >= 0)
            {
                gridView1.DeleteRow(dong_HQ);
                gridView1.RefreshData();
                dong_HQ = -1;
            }
        }
    }
}