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
    public partial class frmThemPhieuTamThu : DevExpress.XtraEditors.XtraForm
    {
        public frmThemPhieuTamThu()
        {
            InitializeComponent();
        }
        public frmThemPhieuTamThu(int _IDCP,int _sua,string bang)
        {
            InitializeComponent();
            IDCP = _IDCP;
            sua = _sua;
            txtBang.Text = bang;
        }
        public frmThemPhieuTamThu(int _IDCP, int _sua, string bang,string _tk)
        {
            InitializeComponent();
            IDCP = _IDCP;
            sua = _sua;
            txtBang.Text = bang;
            tk = _tk;
        }
        int IDCP = 0, sua = 0;
        string tk = "";
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmThemPhieuCuoc_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (sua == 0)
            {
                
                DataTable dt = client.DanhSachTamThu_TheoIDCP(IDCP, txtBang.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    txtSoFile.Text = row["SoFile"].ToString();
                    txtKH.Text = row["TenVietTat"].ToString();
                    btnCapNhat.Enabled = false;
                    btnXoa.Enabled = false;
                    this.Text = string.Format("Thêm phiếu tạm thu IDCP={0}-Khách hàng:{1}", IDCP, txtKH.Text);
                }
            }
            else
            {
                btnLuu.Enabled = false;
                int IDPhieuCuoc = IDCP;
                DataTable dt = client.DanhSachTamthu_DaTao_TheoIDPhieuCuoc(IDPhieuCuoc);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    txtSoFile.Text = row["SoFile"].ToString();
                    txtKH.Text = row["TenVietTat"].ToString();
                    txtGhiChu.Text= row["GhiChu"].ToString();
                    this.Text = string.Format("Cập nhật phiếu tạm thu IDTamThu={0}-Khách hàng:{1}", IDPhieuCuoc, txtKH.Text);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                int IDPhieuCuoc = IDCP;
                client.PhieuTamThu_Xoa(IDPhieuCuoc);
                this.Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(sua>0)
            {
                int IDPhieuCuoc = IDCP;
                ServiceReference1.PhieuTamThu table = new ServiceReference1.PhieuTamThu();
                DataTable dt = client.DanhSachTamthu_DaTao_TheoIDPhieuCuoc(IDPhieuCuoc);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    table.SoFile = row["SoFile"].ToString();
                    table.MaKhachHang = row["MaKhachHang"].ToString().Trim();
                    table.NgayTao = DateTime.Now;
                    table.TienCuoc = double.Parse(row["TienCuoc"].ToString());
                    table.NguoiGiaoNhan = row["MaNhanVien"].ToString().Trim();
                    table.GhiChu = txtGhiChu.Text.Trim();
                    table.NguoiTao = frmMain._TK;
                    table.DaXacNhan = bool.Parse(row["DaXacNhan"].ToString().Trim());
                    table.IDTamThu = IDPhieuCuoc;
                    table.LaLKCP = (txtBang.Text == "bangke") ? true : false;
                    client.PhieuTamThu_CapNhat(table);
                    this.Close();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ServiceReference1.PhieuTamThu table = new ServiceReference1.PhieuTamThu();
            DataTable dt = client.DanhSachTamThu_TheoIDCP(IDCP,txtBang.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[0];
                table.SoFile = row["SoFile"].ToString();
                table.MaKhachHang = row["MaKhachHang"].ToString().Trim();
                table.NgayTao = DateTime.Now;
                table.TienCuoc = double.Parse(row["TienCuoc"].ToString());
                table.NguoiGiaoNhan =tk;
                table.GhiChu = txtGhiChu.Text.Trim();
                table.NguoiTao = frmMain._TK;
                table.DaXacNhan =false;
                table.NguoiXacNhan = "";
                table.LaLKCP = (txtBang.Text == "bangke") ? true : false;
                table.IDCP = int.Parse(row["IDCP"].ToString());
                client.PhieuTamThu_Luu(table);
                this.Close();
            }
            
        }
    }
}