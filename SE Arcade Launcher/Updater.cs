using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Arcade_Launcher
{
    public class Updater
    {
        public static void Update()
        {
            try
            {
                WebClient wc = new WebClient();
                string currentversion = wc.DownloadString("https://raw.githubusercontent.com/Zebratic/SE-Arcade-Launcher/main/version").Replace("\n", "");
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                if (fvi.FileVersion != currentversion)
                {
                    string currentpath = Assembly.GetExecutingAssembly().Location;
                    File.Move(currentpath, currentpath.Substring(0, currentpath.Length - 4) + ".old.exe");
                    wc.DownloadFile("https://github.com/Zebratic/SE-Arcade-Launcher/main/SE-Arcade-Launcher", "SE Arcade Launcher.exe");
                }
            }
            catch
            {
                MessageBox.Show("Failed to obtain version info!", "SE Arcade Launcher");
            }
        }
    }
}