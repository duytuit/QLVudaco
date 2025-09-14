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
    public partial class frmChiKhac : DevExpress.XtraEditors.XtraForm
    {
        public frmChiKhac()
        {
            InitializeComponent();
        }
        public frmChiKhac(int _id)
        {
            InitializeComponent();
            id = _id;
        }
        int id = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmChiKhac_Load(object sender, EventArgs e)
        {
            gridChiKhac.DataSource = client.DSBangPhiDiDuong_ChiKhac_TheoIDBangPhi(id);
        }
    }
}