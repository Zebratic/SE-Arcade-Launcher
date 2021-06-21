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
                    File.Delete(currentpath.Substring(0, currentpath.Length - 4) + ".old.exe");
                    Thread.Sleep(1000);
                    File.Move(currentpath, currentpath.Substring(0, currentpath.Length - 4) + ".old.exe");
                    Thread.Sleep(1000);
                    wc.DownloadFile("https://github.com/Zebratic/SE-Arcade-Launcher/releases/download/Updates/SE.Arcade.Launcher.exe", "SE Arcade Launcher.exe");
                    Thread.Sleep(1000);
                    Notification.Alert("Updated", Notification.enmType.Success);
                    Process.Start(currentpath.Substring(0, currentpath.Length - 4) + ".old.exe");
                    Environment.Exit(0);
                    Application.Exit();
                }
            }
            catch
            {
                Notification.Alert("Failed to obtain online version info", Notification.enmType.Warning);
            }
        }
    }
}