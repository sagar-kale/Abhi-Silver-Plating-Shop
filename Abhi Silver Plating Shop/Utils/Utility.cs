using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        /// <summary>
        /// Returns true if string is numeric and not empty or null or whitespace.
        /// Determines if string is numeric by parsing as Double
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style">Optional style - defaults to NumberStyles.Number (leading and trailing whitespace, leading and trailing sign, decimal point and thousands separator) </param>
        /// <param name="culture">Optional CultureInfo - defaults to InvariantCulture</param>
        /// <returns></returns>
        public static bool IsNumeric(string str, NumberStyles style = NumberStyles.Number,
        CultureInfo culture = null)
        {
            double num;
            if (culture == null) culture = CultureInfo.InvariantCulture;
            return Double.TryParse(str, style, culture, out num) && !String.IsNullOrWhiteSpace(str);
        }

        public static void FilterGrid(DataGridView gridView, string filterColumn, string filterCriteria, string filterText)
        {
            (gridView.DataSource as DataTable).DefaultView.RowFilter
                = string.Format("{0} LIKE '{1}%' OR username LIKE '% {1}%'", filterColumn.Trim(), filterText);
        }
    }
}
