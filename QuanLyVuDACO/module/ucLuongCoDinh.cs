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

namespace Quản_lý_vudaco.module
{
    public partial class ucLuongCoDinh : DevExpress.XtraEditors.XtraUserControl
    {
        public ucLuongCoDinh()
        {
            InitializeComponent();
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
       
      
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            var table = client.dsNhanVien();
            var tablePB = client.dsPhongBan();
            repositoryItemLookUpEdit1.DataSource = tablePB.ToList();
            gridControl1.DataSource = table.ToList();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                ServiceReference1.NhanVien table = new ServiceReference1.NhanVien();
                table.ID=int.Parse(gridView1.GetRowCellValue(i,"ID").ToString());
                table.LuongCoDinh = (gridView1.GetRowCellValue(i, "LuongCoDinh") == null) ? 0 : double.Parse(gridView1.GetRowCellValue(i, "LuongCoDinh").ToString());
                table.MaPhongBan= (gridView1.GetRowCellValue(i, "MaPhongBan") == null) ? "" : gridView1.GetRowCellValue(i, "MaPhongBan").ToString();
                client.NhanVien_LuongCDinh(table);
            }
            ucDanhSachTaiKhoan_Load(sender, e);
        }
    }
}
