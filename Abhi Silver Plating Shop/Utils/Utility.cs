using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop.Utils
{
    class Utility
    {
        public static string UniqueId()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
        public static string CellValueByIndex(int index, DataGridView gridView)
        {
            string value = gridView.SelectedRows[0].Cells[index].Value.ToString();
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return value;
        }
    }
}
