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
    public partial class frmKhaiBaoTSCD : DevExpress.XtraEditors.XtraForm
    {
        public frmKhaiBaoTSCD()
        {
            InitializeComponent();
        }
        public frmKhaiBaoTSCD(int IDKhauHao)
        {
            InitializeComponent();
            _IDKhauHao = IDKhauHao;
        }
        int _IDKhauHao = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void XoaText()
        {
            txtMaTaiSan.Text = "";
            txtTenTaiSan.Text = "";
            txtGiaTriTaiSan.Text = "0";
            txtThoiGianPhanBo.Text = "0";
            txtGiaTriPhanBoTheoThang.Text = "0";
        }
        private void frmKhaiBaoTSCD_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dtpNgayKhaiBao.DateTime = DateTime.Now;
            txtSoChungTu.Text = client.LoadSoChungTu_TSCD();
            btnLuu.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            if(_IDKhauHao>0)
            {
                var table = client.DS_TSCD(_IDKhauHao);
                foreach (var item in table)
                {
                    txtSoChungTu.Text = item.SoChungTu;
                    dtpNgayKhaiBao.DateTime = item.Ngay.Value;
                    txtMaTaiSan.Text = item.MaTaiSan;
                    txtTenTaiSan.Text = item.TenTaiSan;
                    txtGiaTriTaiSan.Text = item.GiaTri.Value.ToString();
                    txtThoiGianPhanBo.Text = item.ThoiGianPhanBo.Value.ToString();
                    txtGiaTriPhanBoTheoThang.Text = item.GiaTriPhanBo.Value.ToString();
                    btnLuu.Enabled = false;
                    btnCapNhat.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }    
        }

        private void GiaTriPhanBoTheoThangTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTaiSan.Text == "")
                MessageBox.Show("Nhập mã tài sản!");
            else
            {
                ServiceReference1.KhaiBao_TSCD table = new ServiceReference1.KhaiBao_TSCD();
                table.SoChungTu = txtSoChungTu.Text.Trim();
                table.MaTaiSan = txtMaTaiSan.Text.Trim();
                table.TenTaiSan = txtTenTaiSan.Text.Trim();
                table.GiaTri = (txtGiaTriTaiSan.Text == "") ? 0 : double.Parse(txtGiaTriTaiSan.Text);
                table.ThoiGianPhanBo= (txtThoiGianPhanBo.Text == "") ? 0 : double.Parse(txtThoiGianPhanBo.Text);
                table.GiaTriPhanBo = (txtGiaTriPhanBoTheoThang.Text == "") ? 0 : double.Parse(txtGiaTriPhanBoTheoThang.Text);
                table.NguoiTao = frmMain._TK;
                table.Ngay = dtpNgayKhaiBao.DateTime;
                //
                int SoNgayTrongThang = DateTime.DaysInMonth(dtpNgayKhaiBao.DateTime.Year, dtpNgayKhaiBao.DateTime.Month);
                int SoNgayConLai = SoNgayTrongThang - dtpNgayKhaiBao.DateTime.Day+1;
                double KhauHaoLuyKe =Math.Round( table.GiaTriPhanBo.Value/ (SoNgayTrongThang * SoNgayConLai),2);
                double GiaTriConLai = table.GiaTri.Value - KhauHaoLuyKe;
                DateTime NgayKetThuc = table.Ngay.Value.AddMonths(int.Parse(table.ThoiGianPhanBo.Value.ToString()));
                table.KhauHaoLuyKe = KhauHaoLuyKe;
                table.GiaTriConLai = GiaTriConLai;
                table.NgayKetThuc = NgayKetThuc;
                //
                client.Them_TSCD(table);
                XoaText();
                this.Close();
            }    
        }

        private void txtGiaTriTaiSan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double GiaTri = (txtGiaTriTaiSan.Text == "") ? 0 : double.Parse(txtGiaTriTaiSan.Text);
                double ThoiGian = (txtThoiGianPhanBo.Text == "") ? 0 : double.Parse(txtThoiGianPhanBo.Text);
                double ThoiGianPB = Math.Round(GiaTri / ThoiGian,2);
                txtGiaTriPhanBoTheoThang.Text = ThoiGianPB.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaTaiSan.Text == "")
                MessageBox.Show("Nhập mã tài sản!");
            else
            {
                ServiceReference1.KhaiBao_TSCD table = new ServiceReference1.KhaiBao_TSCD();
                table.SoChungTu = txtSoChungTu.Text.Trim();
                table.MaTaiSan = txtMaTaiSan.Text.Trim();
                table.TenTaiSan = txtTenTaiSan.Text.Trim();
                table.GiaTri = (txtGiaTriTaiSan.Text == "") ? 0 : double.Parse(txtGiaTriTaiSan.Text);
                table.ThoiGianPhanBo = (txtThoiGianPhanBo.Text == "") ? 0 : double.Parse(txtThoiGianPhanBo.Text);
                table.GiaTriPhanBo = (txtGiaTriPhanBoTheoThang.Text == "") ? 0 : double.Parse(txtGiaTriPhanBoTheoThang.Text);
                table.NguoiTao = frmMain._TK;
                table.Ngay = dtpNgayKhaiBao.DateTime;
                table.IDKhauHao = _IDKhauHao;
                client.Sua_TSCD(table);
                XoaText();
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            client.Xoa_TSCD(_IDKhauHao);
            this.Close();
        }
    }
}