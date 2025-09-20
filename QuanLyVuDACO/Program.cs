using Quản_lý_vudaco.Forms;
using Quản_lý_vudaco.services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var pipeline = new MiddlewarePipeline()
                  .Use(new LoggingMiddleware());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            pipeline.Execute(() =>
            {
                Application.Run(new frmMain());
            });
        }
    }
}
