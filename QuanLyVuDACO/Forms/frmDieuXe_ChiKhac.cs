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
    public partial class frmDieuXe_ChiKhac : DevExpress.XtraEditors.XtraForm
    {
        public frmDieuXe_ChiKhac()
        {
            InitializeComponent();
        }
        public frmDieuXe_ChiKhac(int _id)
        {
            InitializeComponent();
            id = _id;
        }
        int id = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmChiKhac_Load(object sender, EventArgs e)
        {
            gridChiKhac.DataSource = client.BangDieuXe_CT_TheoID(id);
        }
    }
}