using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_vudaco.services
{
    public class khauhao:IDisposable
    {
        private clsKetNoi cls;

        public static int _khauhaotaisan = 1;

        public static int _khauhaochiphitratruoc = 2;

        public static int _khauhaochiphichung = 3;

        public khauhao()
        {
            cls = new clsKetNoi();
        }
        public DataTable GetKhauHao(int Loai = 0)
        {
            string sql = "SELECT * FROM KhauHao";
            if (Loai > 0)
            {
                sql += $@" WHERE Loai = '{Loai}'";
            }
            return cls.LoadTable(sql);
        }
        public DataTable GetKhauHaoByNgayTao(DateTime NgayTao,int Loai=0)
        {
            string sql = $@"SELECT * FROM KhauHao where NgayTao <= '{NgayTao:yyyy-MM-dd}'";
            if (Loai > 0)
            {
                sql += $@" AND Loai = '{Loai}'";
            }
            return cls.LoadTable(sql);
        }
        public void Dispose()
        {
            if (cls != null)
            {
                cls.Dispose();
                cls = null;
            }
        }
    }
}
