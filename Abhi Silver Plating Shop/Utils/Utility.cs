using Abhi_Silver_Plating_Shop.Enum;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop.Utils
{
    public static class Utility
    {
        public static readonly string connectionString = Decrypt(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        public static readonly string appName = GetEnvironmentProperty("AppName").ToUpper();
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

        public static string GetCellValueFromColumnHeader(this DataGridViewCellCollection CellCollection, string HeaderText)
        {
            return CellCollection.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == HeaderText).Value.ToString();
        }
        public static DataGridViewCellCollection GetCells(DataGridView gridView)
        {
            return gridView.SelectedRows[0].Cells;
        }
        public static string ZeroIfEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s) ? "0" : s;
        }
        public static string FormatConnectionString(string database, string user, string password, string server = "localhost")
        {
            return String.Format("server={0};database={1};userid={2};password={3};", server.Trim(), database.Trim(), user.Trim(), password.Trim());
        }

        public static string GetEnvironmentProperty(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static bool ShowWarningIfNotValid(this ValidationResult result)
        {
            bool showWarn = false;
            if (result.IsValid == false)
            {
                List<ValidationFailure> errors = result.Errors;
                showWarn = true;
                errors.ForEach(err => MessageBox.Show($"{err.ErrorMessage}", "Validation Failed !!", MessageBoxButtons.OK, MessageBoxIcon.Warning));
            }
            return showWarn;
        }

        public static string Encrypt(this string encryptString)
        {
            string developer = GetEnvironmentProperty("developer");
            string encryptedCipher = Encryption.Encrypt(encryptString, developer);
            return encryptedCipher;
        }

        public static string Decrypt(this string cipher)
        {
            string developer = GetEnvironmentProperty("developer");
            string decryptedString = Encryption.Decrypt(cipher, developer);
            return decryptedString;
        }

        public static void ConvertToPounds(double weight, WeightType type)
        {
            switch (type)
            {
                case WeightType.GRAM:
                    {
                        double pounds = weight * 2.20462d;
                        double ounces = pounds - Math.Floor(pounds);
                        pounds -= ounces;
                        ounces *= 16;
                        Console.WriteLine("{0} lbs and {1} oz.", pounds, ounces);
                        break;
                    }
                default:
                    throw new Exception("Weight type not supported");
            }
        }

        public static double ConvertElseZero(this string input)
        {
            return Double.TryParse(input, out _) == true ? Double.Parse(input) : 0;
        }

        public static string GetOrderStatus(double outWeight)
        {
            return outWeight != 0 ? "Completed" : "In Progress";
        }

        public static string FormatDate(this string input)
        {
            if (DateTime.TryParse(input, out _))
            {
                return DateTime.ParseExact(input, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy hh:mm tt");
            }
            return input;
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
        public static string Capitalize(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
    }
}
