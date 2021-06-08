using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Arcade_Launcher.Libraries
{
    public class GameScanner
    {
        public static List<string> FindGames()
        {
            List<string> FoundFiles = new List<string>();
            //FoundFiles.AddRange(FindFiles(@"D:\Apps\Steam\steamapps\common", "*.exe"));
            //FoundFiles.AddRange(FindFiles(@"C:\Program Files\Steam\steamapps\common", "*.exe"));
            foreach (string x in SearchSteam())
            {
                FoundFiles.AddRange(FindFiles(x, "*.exe"));
            }
            return FoundFiles;
        }

        public static List<string> FindFiles(string folder, string pattern)
        {
            List<string> files = new List<string>();

            if (!Directory.Exists(folder))
                return new List<string>();

            foreach (string newFolder in Directory.GetDirectories(folder))
            {
                try
                {
                    foreach (string exefile in FindFiles(newFolder, pattern))
                    {
                        if (!files.Contains(exefile))
                            files.Add(exefile);
                    }
                }
                catch { }
            }
            foreach (string exefile in Directory.GetFiles(folder, pattern))
            {
                try
                {
                    if (!files.Contains(exefile))
                        files.Add(exefile);
                }
                catch { }
            }
            return files;
        }



        public static List<string> SearchSteam()
        {
            List<string> steamGameDirs = new List<string>();
            steamGameDirs.Clear();
            string steam32 = "SOFTWARE\\VALVE\\";
            string steam64 = "SOFTWARE\\WOW6432Node\\Valve\\";
            string steam32path;
            string steam64path;
            string config32path;
            string config64path;
            RegistryKey key32 = Registry.LocalMachine.OpenSubKey(steam32);
            RegistryKey key64 = Registry.LocalMachine.OpenSubKey(steam64);
            if (key64.ToString() == null || key64.ToString() == "")
            {
                foreach (string k32subKey in key32.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key32.OpenSubKey(k32subKey))
                    {
                        steam32path = subKey.GetValue("InstallPath").ToString();
                        config32path = steam32path + "/steamapps/libraryfolders.vdf";
                        string driveRegex = @"[A-Z]:\\";
                        if (File.Exists(config32path))
                        {
                            string[] configLines = File.ReadAllLines(config32path);
                            foreach (var item in configLines)
                            {
                                Console.WriteLine("32:  " + item);
                                Match match = Regex.Match(item, driveRegex);
                                if (item != string.Empty && match.Success)
                                {
                                    string matched = match.ToString();
                                    string item2 = item.Substring(item.IndexOf(matched));
                                    item2 = item2.Replace("\\\\", "\\");
                                    item2 = item2.Replace("\"", "\\steamapps\\common\\");
                                    steamGameDirs.Add(item2);
                                }
                            }
                            steamGameDirs.Add(steam32path + "\\steamapps\\common\\");
                        }
                    }
                }
            }
            foreach (string k64subKey in key64.GetSubKeyNames())
            {
                using (RegistryKey subKey = key64.OpenSubKey(k64subKey))
                {
                    steam64path = subKey.GetValue("InstallPath").ToString();
                    config64path = steam64path + "/steamapps/libraryfolders.vdf";
                    string driveRegex = @"[A-Z]:\\";
                    if (File.Exists(config64path))
                    {
                        string[] configLines = File.ReadAllLines(config64path);
                        foreach (var item in configLines)
                        {
                            Console.WriteLine("64:  " + item);
                            Match match = Regex.Match(item, driveRegex);
                            if (item != string.Empty && match.Success)
                            {
                                string matched = match.ToString();
                                string item2 = item.Substring(item.IndexOf(matched));
                                item2 = item2.Replace("\\\\", "\\");
                                item2 = item2.Replace("\"", "\\steamapps\\common\\");
                                steamGameDirs.Add(item2);
                            }
                        }
                        steamGameDirs.Add(steam64path + "\\steamapps\\common\\");
                    }
                }
                return steamGameDirs;
            }
            return new List<string>();
        }
    }
}
