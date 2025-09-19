using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static string _TK = "",_HoTen="";
        public static int _Luu = 0;
        public static dynamic Permission;
        private void ucBangTheoDoiSoFile_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(_TK=="")
            {
                Form frm = new frmDangNhap();
                frm.ShowDialog();
            }
            if (_TK != "")
                lblTK.Text = _TK;
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy hh:ss:mm");
            if (_TK.ToLower() != "admin" && _TK.ToLower() != "phanhuyen")
            {
                mnHeThong.Visible = false;
                //   danhMụcToolStripMenuItem.Visible = false;
                ucBangTheoDoiPhoiNangHa.Visible = false;
                ucBangTheoDoiFileGia.Visible = false;
                //ucBangTheoDoiDebit.Visible = false;
            }
            if (_TK == "")
                Application.Exit();

        }
        private void GetPermission()
        {

        }
        private bool KiemTraTrungTab(string name)
        {
            bool isCheck = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if(xtraTabControl1.TabPages[i].Name==name)
                {
                    isCheck = true;
                    xtraTabControl1.SelectedTabPageIndex = i;
                    break;
                }
            }
            return isCheck;
        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem trang = (ToolStripMenuItem)sender;
            if (!KiemTraTrungTab(trang.Name))
            {
                XtraTabPage tab = new XtraTabPage();
                tab.Name = trang.Name;
                tab.Text = trang.Text;
                xtraTabControl1.TabPages.Add(tab);
                xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
            }
          
        }

        private void ucKhachHang_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucNhaCungCap_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangLietKeChiPhi_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangPhiDiDuong_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void nhậtKýHàngNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiPhoiNangHa_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiFileGia_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void coToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void debitCácLôHàngĐãLậpFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void debitCácLôHàngKhôngLậpFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panelCha.Controls.Clear();
            //module.ucBangTheoDoiDebit_KhongFile control = new module.ucBangTheoDoiDebit_KhongFile();
            //control.Dock = System.Windows.Forms.DockStyle.Fill;
            //panelCha.Controls.Add(control);
        }

        private void debitKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage tabPage = xtraTabControl1.SelectedTabPage;
            switch (tabPage.Name)
            {
                case "ucDanhSachTaiKhoan":
                    {
                        module.ucDanhSachTaiKhoan frm = new module.ucDanhSachTaiKhoan(tabPage.Name);
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucKhachHang":
                    {
                        module.ucKhachHang frm = new module.ucKhachHang(tabPage.Name);
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucNhaCungCap":
                    {
                        module.ucNhaCungCap frm = new module.ucNhaCungCap(tabPage.Name);
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiDebit_CoFile_NCC":
                    {
                        module.ucBangTheoDoiDebit_CoFile_NCC frm = new module.ucBangTheoDoiDebit_CoFile_NCC();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiDebit_KoFile_NCC":
                    {
                        module.ucBangTheoDoiDebit_KoFile_NCC frm = new module.ucBangTheoDoiDebit_KoFile_NCC();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiSoFile":
                    {
                        module.ucBangTheoDoiSoFile frm = new module.ucBangTheoDoiSoFile();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiPhoiNangHa":
                    {
                        module.ucBangTheoDoiPhoiNangHa frm = new module.ucBangTheoDoiPhoiNangHa();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiFileGia":
                    {
                        module.ucBangTheoDoiFileGia frm = new module.ucBangTheoDoiFileGia();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiDebit":
                    {
                        module.ucBangTheoDoiDebit frm = new module.ucBangTheoDoiDebit();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangLietKeChiPhi":
                    {
                        module.ucBangLietKeChiPhi frm = new module.ucBangLietKeChiPhi();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangDieuXe":
                    {
                        module.ucBangDieuXe frm = new module.ucBangDieuXe();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangDanhSachCuoc":
                    {
                        module.ucBangDanhSachCuoc frm = new module.ucBangDanhSachCuoc();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangPhiDiDuong":
                    {
                        module.ucBangPhiDiDuong frm = new module.ucBangPhiDiDuong();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiDebit_File":
                    {
                        module.ucBangTheoDoiDebit_File frm = new module.ucBangTheoDoiDebit_File();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTheoDoiDebit_KoFile_KH":
                    {
                        module.ucBangTheoDoiDebit_KoFile_KH frm = new module.ucBangTheoDoiDebit_KoFile_KH();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucDebitCanBoSung":
                    {
                        module.ucBangLietKeChiPhiBoSung frm = new module.ucBangLietKeChiPhiBoSung();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucThu":
                    {
                        module.ucThu frm = new module.ucThu();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucChi":
                    {
                        module.ucChi frm = new module.ucChi();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucTienMat":
                    {
                        module.ucTienMat frm = new module.ucTienMat();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucNhanVien":
                    {
                        module.ucNhanVien frm = new module.ucNhanVien();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucDanhMucNganHang":
                    {
                        module.ucDanhMucNganHang frm = new module.ucDanhMucNganHang();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucDanhMucQuy":
                    {
                        module.ucDanhMucQuy frm = new module.ucDanhMucQuy();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucCongNoKhachHang":
                    {
                        module.ucCongNoKhachHang frm = new module.ucCongNoKhachHang();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucCongNoKhachHangV2":
                    {
                        module.ucCongNoKhachHangV2 frm = new module.ucCongNoKhachHangV2();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucCongNoNhaCungCap":
                    {
                        module.ucCongNoNhaCungCap frm = new module.ucCongNoNhaCungCap();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucCongNoNhaCungCapV2":
                    {
                        module.ucCongNoNhaCungCapV2 frm = new module.ucCongNoNhaCungCapV2();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                     }
                case "ucCongNoGiaoNhan":
                    {
                        module.ucCongNoGiaoNhan frm = new module.ucCongNoGiaoNhan();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucCongNoLaiXe":
                    {
                        module.ucCongNoLaiXe frm = new module.ucCongNoLaiXe();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucXoa":
                    {
                        module.ucXoa frm = new module.ucXoa();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucSoDuTienMat":
                    {
                        module.ucSoDuTienMat frm = new module.ucSoDuTienMat();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBaoCaoSoQuyTM":
                    {
                        reports.ucBaoCaoSoQuyTM frm = new reports.ucBaoCaoSoQuyTM();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBaoCaoSoTK":
                    {
                        reports.ucBaoCaoSoTK frm = new reports.ucBaoCaoSoTK();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBaoCaoKetQuaKinhDoanh":
                    {
                        reports.ucBaoCaoKetQuaKinhDoanh frm = new reports.ucBaoCaoKetQuaKinhDoanh();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucDuyetBangKechiPhi":
                    {
                        module.ucDuyetBangKechiPhi frm= new module.ucDuyetBangKechiPhi();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucDuyetBangTheoDoiFileGia":
                    {
                        module.ucDuyetBangTheoDoiFileGia frm = new module.ucDuyetBangTheoDoiFileGia();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucPhongBan":
                    {
                        module.ucPhongBan frm = new module.ucPhongBan();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucLuongCoDinh":
                    {
                        module.ucLuongCoDinh frm = new module.ucLuongCoDinh();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangPhepNam":
                    {
                        module.ucBangPhepNam frm = new module.ucBangPhepNam();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucDanhSachXe":
                    {
                        module.ucDanhSachXe frm = new module.ucDanhSachXe();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBangTamThu":
                    {
                        module.ucBangTamThu frm = new module.ucBangTamThu();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucCongNoDoiTru":
                    {
                        module.ucCongNoDoiTru frm = new module.ucCongNoDoiTru();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucLuongLaiXe":
                    {
                        module.ucLuongLaiXe frm = new module.ucLuongLaiXe();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucLuongVanPhong":
                    {
                        module.ucLuongVanPhong frm = new module.ucLuongVanPhong();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucTaiSanCoDinh":
                    {
                        module.ucTaiSanCoDinh frm = new module.ucTaiSanCoDinh();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucMuaHang":
                    {
                        module.ucMuaHang frm = new module.ucMuaHang();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucBanHang":
                    {
                        module.ucBanHang frm = new module.ucBanHang();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucLoiNhuanTheoXe":
                    {
                        reports.ucLoiNhuanTheoXe frm = new reports.ucLoiNhuanTheoXe();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucLoiNhuanTheoTungLinhVuc":
                    {
                        reports.ucLoiNhuanTheoTungLinhVuc frm = new reports.ucLoiNhuanTheoTungLinhVuc();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucSoDuDauKyNCC":
                    {
                        module.ucSoDuDauKyNCC frm = new module.ucSoDuDauKyNCC();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucSoDuDauKyKH":
                    {
                        module.ucSoDuDauKyKH frm = new module.ucSoDuDauKyKH();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucChiPhiChung":
                    {
                        module.ucChiPhiChung frm = new module.ucChiPhiChung();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucChiPhiTraTruoc":
                    {
                        module.ucChiPhiTraTruoc frm = new module.ucChiPhiTraTruoc();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                case "ucNhomQuyen":
                    {
                        module.ucNhomQuyen frm = new module.ucNhomQuyen();
                        frm.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPage.Controls.Add(frm);
                        break;
                    }
                default:
                    break;
            }
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {

             xtraTabControl1.TabPages.RemoveAt(xtraTabControl1.SelectedTabPageIndex);
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;


        }

        private void ucDebitCanBoSung_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiDebit_KoFile_NCC_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucThu_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucChi_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucTienMat_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void tiềnGửiNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucNhanVien_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void danhSáchNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void danhMụcQuỹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiDebit_File_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void debitCácLôHàngKhôngLậpFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiDebit_KoFile_NCC_Click_1(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thoátPhiênĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TK = "";
            for (int i = xtraTabControl1.TabPages.Count-1; i >=1; i--)
            {
                xtraTabControl1.TabPages.RemoveAt(i);
            }
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
            frmMain_Load(sender, e);
        }

        private void ucCongNoKhachHang_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucCongNoGiaoNhan_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucXoa_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucCongNoLaiXe_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangDanhSachCuoc_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucSoDuTienMat_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBaoCaoSoQuyTM_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBaoCaoSoTK_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBaoCaoKetQuaKinhDoanh_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ucDuyetBangKechiPhi_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void duyệtFileGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucPhongBan_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucLuongcoDinh_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangPhepNam_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucDanhSachXe_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void debitNhàCungCấpCóSốFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ucBangTamThu_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucCongNoDoiTru_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucLuongLaiXe_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucLuongVanPhong_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucTaiSanCoDinh_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void lợiNhuậnTheoTừngLĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucMuaHang_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBanHang_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucLoiNhuanTheoXe_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void chiPhíCầnPhânBổToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void chiPhíQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void debitNhàCungCấpCácLôHàngKhôngLậpFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiDebit_CoFile_NCC_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucCongNoNhaCungCapV2_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void muaHàngBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ucSoDuDauKyKH_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucSoDuDauKyNCC_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucChiPhiChung_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void côngNợKháchHàngMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucNhomQuyen_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }

        private void ucBangTheoDoiDebit_Click(object sender, EventArgs e)
        {
            danhSáchTàiKhoảnToolStripMenuItem_Click(sender, e);
        }
    }
}
