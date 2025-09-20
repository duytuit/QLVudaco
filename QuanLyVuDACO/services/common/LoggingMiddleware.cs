using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services.common
{
    public class LoggingMiddleware : IMiddleware
    {
        public void Invoke(Action next)
        {
           // frmMain.
            next();
        }
    }
}
