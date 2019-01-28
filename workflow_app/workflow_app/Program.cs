using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using workflow_app.Configuration;

namespace workflow_app
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppConfig.Init(ConfigurationManager.AppSettings["folder_to_files"]);
            Application.Run(new LoginForm());
        }
    }
}
