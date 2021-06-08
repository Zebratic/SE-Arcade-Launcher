using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE_Arcade_Launcher.Libraries;

namespace SE_Arcade_Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Updater.Update();

            if (false)
            {
                SmartInstaller smartInstaller = new SmartInstaller();
                smartInstaller.InstallationFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\SEArcade";
                smartInstaller.Pin = true;
                if (smartInstaller.InstallProgram())
                {
                    Process.Start(smartInstaller.NewExeLocation);
                    Environment.Exit(200);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainMenu());
        }
    }
}
