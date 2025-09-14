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
    public partial class frmChiKhac_Temp : DevExpress.XtraEditors.XtraForm
    {
        public frmChiKhac_Temp()
        {
            InitializeComponent();
        }
        public frmChiKhac_Temp(int _id)
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.RowHandle>=0)
            {
                int i = e.RowHandle;
                    ServiceReference1.BangPhiDiDuong_ChiKhac_Temp table2 = new ServiceReference1.BangPhiDiDuong_ChiKhac_Temp();
                    table2.IDBangPhi = id;
                    table2.NoiDungChi = gridView1.GetRowCellDisplayText(i, "NoiDungChi");
                    table2.SoTienChi = float.Parse(gridView1.GetRowCellDisplayText(i, "SoTienChi"));
                    client.DsBangPhiDiDuong_ChiKhac_Temp_Them(table2);
                
            }    
        }
    }
}