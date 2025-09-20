using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.services.common
{
    public static class ControlHelper
    {
        /// <summary>
        /// Lấy tất cả Button / SimpleButton trong control và các control con
        /// </summary>
        public static List<Control> GetAllButtons(Control parent)
        {
            List<Control> result = new List<Control>();

            foreach (Control ctl in parent.Controls)
            {
                if (ctl is Button || ctl is SimpleButton)
                {
                    result.Add(ctl);
                }

                // Nếu control có control con → đệ quy
                if (ctl.HasChildren)
                {
                    result.AddRange(GetAllButtons(ctl));
                }
            }

            return result;
        }
        /// <summary>
        /// Enable/Disable RepositoryItem theo row bằng event ShowingEditor
        /// </summary>
        /// <param name="view">GridView</param>
        /// <param name="columnFieldName">Tên cột</param>
        /// <param name="condition">Hàm kiểm tra giá trị row => true = enable, false = disable</param>
        public static void EnableRepositoryItemPerRow(GridView view, string columnFieldName, Func<object, bool> condition)
        {
            view.ShowingEditor -= View_ShowingEditor; // tránh đăng ký trùng
            view.ShowingEditor += View_ShowingEditor;

            void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
            {
                var gv = sender as GridView;
                if (gv.FocusedColumn.FieldName == columnFieldName)
                {
                    var value = gv.GetRowCellValue(gv.FocusedRowHandle, columnFieldName);
                    e.Cancel = !condition(value); // true = enable, false = disable
                }
            }
        }
    }
}
