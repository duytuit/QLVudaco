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
    public partial class frmThemPhieuCuoc : DevExpress.XtraEditors.XtraForm
    {
        public frmThemPhieuCuoc()
        {
            InitializeComponent();
        }
        public frmThemPhieuCuoc(int _IDCP,int _sua)
        {
            InitializeComponent();
            IDCP = _IDCP;
            sua = _sua;
        }
        public frmThemPhieuCuoc(int _IDCP, int _sua,string _tk)
        {
            InitializeComponent();
            IDCP = _IDCP;
            sua = _sua;
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
                
                DataTable dt = client.DanhSachCuoc_TheoIDCP(IDCP);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    txtSoFile.Text = row["SoFile"].ToString();
                    txtKH.Text = row["TenVietTat"].ToString();
                    btnCapNhat.Enabled = false;
                    btnXoa.Enabled = false;
                    this.Text = string.Format("Thêm phiếu cược IDCP={0}-Khách hàng:{1}", IDCP, txtKH.Text);
                }
            }
            else
            {
                btnLuu.Enabled = false;
                int IDPhieuCuoc = IDCP;
                DataTable dt = client.DanhSachCuoc_DaTao_TheoIDPhieuCuoc(IDPhieuCuoc);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    txtSoFile.Text = row["SoFile"].ToString();
                    txtKH.Text = row["TenVietTat"].ToString();
                    txtGhiChu.Text= row["GhiChu"].ToString();
                    this.Text = string.Format("Cập nhật phiếu cược IDPhieuCuoc={0}-Khách hàng:{1}", IDPhieuCuoc, txtKH.Text);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                int IDPhieuCuoc = IDCP;
                client.PhieuCuoc_Xoa(IDPhieuCuoc);
                this.Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(sua>0)
            {
                int IDPhieuCuoc = IDCP;
                ServiceReference1.PhieuCuoc table = new ServiceReference1.PhieuCuoc();
                DataTable dt = client.DanhSachCuoc_DaTao_TheoIDPhieuCuoc(IDPhieuCuoc);
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
                    table.IDPhieuCuoc = IDPhieuCuoc;
                    client.PhieuCuoc_CapNhat(table);
                    this.Close();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ServiceReference1.PhieuCuoc table = new ServiceReference1.PhieuCuoc();
            DataTable dt = client.DanhSachCuoc_TheoIDCP(IDCP);
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
                table.IDCP = int.Parse(row["IDCP"].ToString());
                table.IDCPCT = 0; //int.Parse(row["IDCPCT"].ToString());
                client.PhieuCuoc_Luu(table);
                this.Close();
            }
            
        }
    }
}