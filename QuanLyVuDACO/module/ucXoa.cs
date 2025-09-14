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
    public partial class ucXoa : DevExpress.XtraEditors.XtraUserControl
    {
        public ucXoa()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
           
        }
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void ucXoa_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            dtpTuNgay.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            if (txtPass.Text == "123123")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pictureBox1.Visible = true;
                    string[] arr1 = dtpTuNgay.Text.Split('/');
                    if (arr1.Length >= 3 && arr1[0].Trim() != "")
                    {
                        DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                        client.XoaDL(Ngay1.ToString("yyyy-MM-dd"));
                    }
                  
                }
            }
            else
                MessageBox.Show("Sai mật khẩu xoá. Vui lòng thử lại!");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            MessageBox.Show("Xoá dữ liệu thành công!");
        }
    }
}
