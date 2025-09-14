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
    public partial class frmDuyet_BangKe : DevExpress.XtraEditors.XtraForm
    {
        public frmDuyet_BangKe()
        {
            InitializeComponent();
        }
        public frmDuyet_BangKe(int IDCP)
        {
            InitializeComponent();
            _IDCP = IDCP;
        }
        int _IDCP = 0;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmDuyet_BangKe_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtNguoiDuyet.Text = frmMain._TK;
            txtNguoiDuyet.ReadOnly = true;
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string[] arr1 = dtpNgay.Text.Split('/');
            if (arr1.Length >= 3 && arr1[0].Trim() != "")
            {
                DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                client.BangKe_Duyet(_IDCP, txtLyDo.Text, txtNguoiDuyet.Text, Ngay1);
                this.Close();
            }
        }
    }
}