using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // we need to get the current process name
            string strProcessName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(strProcessName);
            if (processes.Length == 1)
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                bool isFirstTimeOpened = Convert.ToBoolean(ConfigurationManager.AppSettings["isFirstTimeOpened"]);
                if (isFirstTimeOpened)
                    Application.Run(new StartupSetupForm());
                //Application.Run(new MainForm());
                else
                    Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("The application is already running.");
            }
        }

    }
}
