using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class frmBangTheoDoiSoFile : DevExpress.XtraEditors.XtraForm
    {
        public frmBangTheoDoiSoFile()
        {
            InitializeComponent();
        }
        public frmBangTheoDoiSoFile(int _IDLoHang)
        {
            InitializeComponent();
            IDLoHang = _IDLoHang;
        }
        int IDLoHang = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmBangTheoDoiSoFile_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            LoaiHang();
            TinhChat();
            KhachHang();
            TenGiaoNhan();
            XoaText();
            NghiepVuTextEdit.SelectedIndex = 0;
            if (IDLoHang==0)
            {
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }    
            else
            {
                TenGiaoNhan();
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                //xem lai thong tin da nhap 
                var table = client.ThongTinFile_TheoIDLoHang(IDLoHang);
                foreach (var item in table)
                {
                    ThoiGianThucHienDateEdit.DateTime = item.ThoiGianThucHien.Value;
                    TinhChatTextEdit.EditValue = item.TinhChat.Trim();
                    MaKhachHangTextEdit.EditValue = item.MaKhachHang;
                    SoFileTextEdit.Text = item.SoFile;
                    SoToKhaiTextEdit.Text = item.SoToKhai;
                    SoBillTextEdit.Text = item.SoBill;
                    SoContTextEdit.Text = item.SoCont;
                    TenSalesTextEdit.Text = item.TenSales;
                  
                  var t_GN=  client.DanhSachNguoiGiaoNhan_TheoSoFile(item.SoFile);
                    foreach (var item_GN in t_GN)
                    {
                        TenGiaoNhanTextEdit.SetEditValue(item_GN.MaNhanVien);
                    }
                    LoaiHangTextEdit.EditValue = item.LoaiHang.Trim();
                  
                    SoLuongTextEdit.Text = item.SoLuong;
                    LoaiToKhaiTextEdit.SelectedIndex = int.Parse(item.LoaiToKhai);
                    NghiepVuTextEdit.SelectedIndex = int.Parse(item.NghiepVu);
                    PhatSinhTextEdit.SelectedIndex = int.Parse(item.PhatSinh);
                  //  DuyetUngTextEdit.Text = item.DuyetUng.ToString();
                    GhiChuTextEdit.Text = item.GhiChu;
                }
            }    
        }
        private void KhachHang()
        {
            MaKhachHangTextEdit.Properties.DataSource = client.dsKH();
        }
        private void TenGiaoNhan()
        {
            var table = client.dsNhanVien();
            TenGiaoNhanTextEdit.Properties.DataSource = table.ToList();
        }
        private void LoaiHang()
        {
            DataTable dtLoaiHang = new DataTable("LoaiHang");
            dtLoaiHang.Columns.Add("MaHang");
            dtLoaiHang.Columns.Add("TenHang");
            DataRow row = dtLoaiHang.NewRow();
            row["MaHang"] = "HangLe";
            row["TenHang"] = "Hàng lẻ";
            dtLoaiHang.Rows.Add(row);
            //
            DataRow row1 = dtLoaiHang.NewRow();
            row1["MaHang"] = "HangCont";
            row1["TenHang"] = "Hàng cont";
            dtLoaiHang.Rows.Add(row1);
            LoaiHangTextEdit.Properties.DataSource = dtLoaiHang;
        }
        private void TinhChat()
        {
            DataTable dtLoaiHang = new DataTable("TinhChat");
            dtLoaiHang.Columns.Add("MaTinhChat");
            dtLoaiHang.Columns.Add("TenTinhChat");
            DataRow row = dtLoaiHang.NewRow();
            row["MaTinhChat"] = "HangNhap";
            row["TenTinhChat"] = "Hàng nhập";
            dtLoaiHang.Rows.Add(row);
            //
            DataRow row1 = dtLoaiHang.NewRow();
            row1["MaTinhChat"] = "HangXuat";
            row1["TenTinhChat"] = "Hàng xuất";
            dtLoaiHang.Rows.Add(row1);
            TinhChatTextEdit.Properties.DataSource = dtLoaiHang;
        }
      
        private void XoaText()
        {
            ThoiGianThucHienDateEdit.DateTime = DateTime.Now;
            MaKhachHangTextEdit.EditValue = null;
            SoFileTextEdit.Text = "";
            SoToKhaiTextEdit.Text = "";
            SoBillTextEdit.Text = "";
            SoContTextEdit.Text = "";
            TenSalesTextEdit.Text = "";
            TenGiaoNhanTextEdit.Text = "";
            LoaiHangTextEdit.EditValue = null;
            TinhChatTextEdit.EditValue = null;
            SoLuongTextEdit.Text = "";
            LoaiToKhaiTextEdit.EditValue = null;
            NghiepVuTextEdit.EditValue = "";
            PhatSinhTextEdit.EditValue = null;
          //  DuyetUngTextEdit.Text = "";
            GhiChuTextEdit.Text = "";
            ThoiGianThucHienDateEdit.Focus();
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            IDLoHang = 0;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void ThemBangDieuXe()
        {
            ServiceReference1.BangDieuXe table1 = new ServiceReference1.BangDieuXe();
            table1.Ngay = ThoiGianThucHienDateEdit.DateTime;
            table1.TuyenVC = "Không có trucking";
            table1.SoFile = SoFileTextEdit.Text;
            table1.MaKhachHang = MaKhachHangTextEdit.EditValue.ToString();
            table1.LoaiXe_KH = "";
            table1.LoaiXe_NCC = "";
            table1.CuocBan = 0;
            table1.LaiXeThuCuoc = 0;
            table1.TTHQ = 0;
            table1.CuocMua = 0;
            table1.MaNhaCungCap = "";
            table1.BienSoXe = "";
            table1.LaiXe = "";
            table1.NguoiTao = frmMain._TK;
            table1.MaDieuXe = client.LoadMaDieuXe(ThoiGianThucHienDateEdit.DateTime); ;
            table1.LuongHangVe = 0;
            client.DsBangDieuXe_Them(table1);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ThoiGianThucHienDateEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn thời gian!");
            else if(MaKhachHangTextEdit.EditValue==null)
                MessageBox.Show("Vui lòng chọn khách hàng!");
            else if (TinhChatTextEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn hàng nhập hoặc hàng xuất!");
            else
            {
                bool isTrung = false;
                // if(SoToKhaiTextEdit.Text!=""&&SoBillTextEdit.Text!="")
                // {
                var table = client.DsThongTinFile_Full_SoToKhai(SoToKhaiTextEdit.Text);
                    if(table.Count()>0)
                    {
                        isTrung = true;
                        MessageBox.Show("Trùng số tờ khai!");
                    }
                var table11 = client.DsThongTinFile_Full_SoBill(SoBillTextEdit.Text);
                    if (table11.Count() > 0)
                    {
                        isTrung = true;
                        MessageBox.Show("Trùng số Bill!");
                    }
                var table2 = client.DsThongTinFile_Full_SoFile(SoFileTextEdit.Text).Where(p=>p.SoFile!="");
                    if (table2.Count() > 0)
                    {
                        isTrung = true;
                        MessageBox.Show("Trùng số File!");
                    }
              //  }   
                if(!isTrung)
                {
                   ServiceReference1. ThongTinFile table1 = new ServiceReference1. ThongTinFile();
                    table1.ThoiGianThucHien = ThoiGianThucHienDateEdit.DateTime;
                    table1.MaKhachHang = MaKhachHangTextEdit.EditValue.ToString();
                    table1.SoFile = SoFileTextEdit.Text;
                    table1.SoToKhai = SoToKhaiTextEdit.Text;
                    table1.SoBill = SoBillTextEdit.Text;
                    table1.SoLuong = SoLuongTextEdit.Text;
                    table1.SoCont = SoContTextEdit.Text;
                    table1.TenSales = TenSalesTextEdit.Text;
                  // table1.TenGiaoNhan =(TenGiaoNhanTextEdit.EditValue==null)?"": TenGiaoNhanTextEdit.EditValue.ToString();
                    table1.LoaiHang = (LoaiHangTextEdit.EditValue == null) ? "" : LoaiHangTextEdit.EditValue.ToString();
                    table1.TinhChat = (TinhChatTextEdit.EditValue == null) ? "" : TinhChatTextEdit.EditValue.ToString();
                    table1.LoaiToKhai = LoaiToKhaiTextEdit.SelectedIndex.ToString();
                    table1.NghiepVu = NghiepVuTextEdit.SelectedIndex.ToString();
                    table1.PhatSinh = PhatSinhTextEdit.SelectedIndex.ToString();
                   // table1.DuyetUng = (DuyetUngTextEdit.Text == "") ? 0 : float.Parse(DuyetUngTextEdit.Text);
                    table1.GhiChu = GhiChuTextEdit.Text;
                    table1.TaiKhoanThucHien = frmMain._TK;
                    client.DsThongTinFile_Them(table1);
                   
                  
                        ServiceReference1.ThongTinFile_NguoiGiaoNhan p11 = new ServiceReference1.ThongTinFile_NguoiGiaoNhan();
                        p11.SoFile = table1.SoFile;
                        client.XoaDanhSachNguoiGiaoNhan(p11);
                        //nguoi giao nhan
                        List<object> x = TenGiaoNhanTextEdit.Properties.GetItems().GetCheckedValues();
                        for (int k = 0; k < x.Count; k++)
                        {
                            object m = x[k];
                            ServiceReference1.ThongTinFile_NguoiGiaoNhan p1 = new ServiceReference1.ThongTinFile_NguoiGiaoNhan();
                            p1.SoFile = table1.SoFile;
                            p1.MaNhanVien = x[k].ToString();
                            p1.DuyetUng = 0;
                            client.ThemDanhSachNguoiGiaoNhan(p1);
                        }
                    
                    //
                    if (NghiepVuTextEdit.SelectedIndex==4)
                        ThemBangDieuXe();
                    btnThemMoi_Click(sender, e);
                }    
            }    
        }

        private void TinhChatTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TinhChatTextEdit.EditValue != null)
                {
                    string _TC = TinhChatTextEdit.EditValue.ToString();
                    if (_TC.ToLower() == "hangnhap")
                    {
                        var table = client.DsThongTinFile_TinhChat(ThoiGianThucHienDateEdit.DateTime);
                        if (table.Count() == 0)//neu chua co file nao
                            SoFileTextEdit.Text = "IS" + ThoiGianThucHienDateEdit.DateTime.Year.ToString().Substring(2, 2) + ThoiGianThucHienDateEdit.DateTime.Month.ToString("0#") + "001";
                        else
                        {
                            foreach (var item in table)
                            {
                                string txt = item.SoFile.Substring(item.SoFile.Length - 3, 3);
                                int stt = int.Parse(txt) + 1;
                                SoFileTextEdit.Text = "IS" + ThoiGianThucHienDateEdit.DateTime.Year.ToString().Substring(2, 2) + ThoiGianThucHienDateEdit.DateTime.Month.ToString("0#") + stt.ToString("00#");
                            }
                        }
                    }
                    else if (_TC.ToLower() == "hangxuat")
                    {
                        var table = client.DsThongTinFile_TinhChat2(ThoiGianThucHienDateEdit.DateTime);
                        if (table.Count() == 0)//neu chua co file nao
                            SoFileTextEdit.Text = "ES" + ThoiGianThucHienDateEdit.DateTime.Year.ToString().Substring(2, 2) + ThoiGianThucHienDateEdit.DateTime.Month.ToString("0#") + "001";
                        else
                        {
                            foreach (var item in table)
                            {
                                string txt = item.SoFile.Substring(item.SoFile.Length - 3, 3);
                                int stt = int.Parse(txt) + 1;
                                SoFileTextEdit.Text = "ES" + ThoiGianThucHienDateEdit.DateTime.Year.ToString().Substring(2, 2) + ThoiGianThucHienDateEdit.DateTime.Month.ToString("0#") + stt.ToString("00#");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ThoiGianThucHienDateEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn thời gian!");
            else if (MaKhachHangTextEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn khách hàng!");
            else if (TinhChatTextEdit.EditValue == null)
                MessageBox.Show("Vui lòng chọn hàng nhập hoặc hàng xuất!");
            else
            {
                bool isTrung = false;
                //  if (SoToKhaiTextEdit.Text != "" && SoBillTextEdit.Text != "")
                //  {
                //trung khi sua
                var table = client.DsThongTinFile_Full_SoToKhai_Trung(SoToKhaiTextEdit.Text, IDLoHang); 
                if (table.Count() > 0)
                {
                    isTrung = true;
                    MessageBox.Show("Trùng số tờ khai!");
                }
                var table11 = client.DsThongTinFile_Full_SoToKhai_Trung1(SoBillTextEdit.Text, IDLoHang); 
                if (table11.Count() > 0)
                {
                    isTrung = true;
                    MessageBox.Show("Trùng số Bill!");
                }
                var table2 = client.DsThongTinFile_Full_SoToKhai_Trung2(SoFileTextEdit.Text, IDLoHang); 
                if (table2.Count() > 0)
                {
                    isTrung = true;
                    MessageBox.Show("Trùng số File!");
                }
                //}
                if (!isTrung)
                {
                    ServiceReference1.ThongTinFile table1 = new ServiceReference1.ThongTinFile();
                    table1.IDLoHang = IDLoHang;
                    table1.ThoiGianThucHien = ThoiGianThucHienDateEdit.DateTime;
                    table1.MaKhachHang = MaKhachHangTextEdit.EditValue.ToString();
                    table1.SoFile = SoFileTextEdit.Text;
                    table1.SoToKhai = SoToKhaiTextEdit.Text;
                    table1.SoBill = SoBillTextEdit.Text;
                    table1.SoLuong = SoLuongTextEdit.Text;
                    table1.SoCont = SoContTextEdit.Text;
                    table1.TenSales = TenSalesTextEdit.Text;
                   // table1.TenGiaoNhan = (TenGiaoNhanTextEdit.EditValue == null) ? "" : TenGiaoNhanTextEdit.EditValue.ToString();
                    table1.LoaiHang = (LoaiHangTextEdit.EditValue == null) ? "" : LoaiHangTextEdit.EditValue.ToString();
                    table1.TinhChat = (TinhChatTextEdit.EditValue == null) ? "" : TinhChatTextEdit.EditValue.ToString();
                    table1.LoaiToKhai = LoaiToKhaiTextEdit.SelectedIndex.ToString();
                    table1.NghiepVu = NghiepVuTextEdit.SelectedIndex.ToString();
                    table1.PhatSinh = PhatSinhTextEdit.SelectedIndex.ToString();
                   // table1.DuyetUng = (DuyetUngTextEdit.Text == "") ? 0 : float.Parse(DuyetUngTextEdit.Text);
                    table1.GhiChu = GhiChuTextEdit.Text;
                    table1.TaiKhoanThucHien = frmMain._TK;

                    client.DsThongTinFile_Sua(table1);
                    //neu chua tao phieu chi duyet ung thi cho phep sua nguoi giao nhan
                    bool isCheck = client.KiemTraPhieuChi_DuyetUngDaTao(table1.SoFile);
                    if (!isCheck)
                    {
                        ServiceReference1.ThongTinFile_NguoiGiaoNhan p11 = new ServiceReference1.ThongTinFile_NguoiGiaoNhan();
                        p11.SoFile = table1.SoFile;
                        client.XoaDanhSachNguoiGiaoNhan(p11);
                        //nguoi giao nhan
                        List<object> x = TenGiaoNhanTextEdit.Properties.GetItems().GetCheckedValues();
                        for (int k = 0; k < x.Count; k++)
                        {
                            object m = x[k];
                            ServiceReference1.ThongTinFile_NguoiGiaoNhan p1 = new ServiceReference1.ThongTinFile_NguoiGiaoNhan();
                            p1.SoFile = table1.SoFile;
                            p1.MaNhanVien = x[k].ToString();
                            p1.DuyetUng = 0;
                            client.ThemDanhSachNguoiGiaoNhan(p1);
                        }
                        if (NghiepVuTextEdit.SelectedIndex == 4)
                            ThemBangDieuXe();
                        // btnThemMoi_Click(sender, e);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Số file này đã thêm phiếu chi tạm ứng. Nên không thể thay đổi");
                  
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (frmMain._TK != "admin")
                MessageBox.Show("Chỉ Admin mới có quyền này");
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không(Y/N)?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    client.XoaThongTinFile(IDLoHang);
                    ServiceReference1.ThongTinFile_NguoiGiaoNhan p11 = new ServiceReference1.ThongTinFile_NguoiGiaoNhan();
                    p11.SoFile =SoFileTextEdit.Text;
                    client.XoaDanhSachNguoiGiaoNhan(p11);
                    btnThemMoi_Click(sender, e);
                }
            }
        }
    }
}