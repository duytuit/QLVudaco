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
    public partial class ProgressForm : DevExpress.XtraEditors.XtraForm
    {
        public ProgressBarControl ProgressBar { get; private set; }
        private LabelControl lblStatus;

        public ProgressForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đang upload...";
            this.ClientSize = new Size(400, 100);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false; // ẩn nút close

            lblStatus = new LabelControl()
            {
                Text = "Đang xử lý...",
                Dock = DockStyle.Top,
                Appearance = { TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Center } },
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Height = 25
            };

            ProgressBar = new ProgressBarControl()
            {
                Dock = DockStyle.Fill,
                Properties = { ShowTitle = true }
            };

            this.Controls.Add(ProgressBar);
            this.Controls.Add(lblStatus);
        }

        public void UpdateStatus(string message, int percent = -1)
        {
            this.Invoke((Action)(() =>
            {
                lblStatus.Text = message;
                if (percent >= 0)
                {
                    ProgressBar.EditValue = percent;
                    ProgressBar.Properties.PercentView = true;
                }
            }));
        }
    }
}