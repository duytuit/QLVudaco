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
    public partial class frmCongNoDoiTru : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNoDoiTru()
        {
            InitializeComponent();
        }
        public frmCongNoDoiTru(string MaKH,DateTime tuNgay,DateTime denNgay)
        {
            InitializeComponent();
            _MaKH = MaKH;
            _tuNgay = tuNgay;
            _denNgay = denNgay;
        }
        string _MaKH = "";
        DateTime _tuNgay = new DateTime(), _denNgay = new DateTime();
        private void frmCongNoDoiTru_Load(object sender, EventArgs e)
        {

        }
    }
}