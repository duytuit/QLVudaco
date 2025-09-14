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
    public partial class frmChiKhac_Temp1 : DevExpress.XtraEditors.XtraForm
    {
        public frmChiKhac_Temp1()
        {
            InitializeComponent();
        }
        public frmChiKhac_Temp1(int _id)
        {
            InitializeComponent();
            id = _id;
        }
        int id = 0;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void frmChiKhac_Load(object sender, EventArgs e)
        {
            gridChiKhac.DataSource = client.DsBangPhiDiDuong_ChiKhac_Temp_TheoIDBangPhi(id);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }
    }
}