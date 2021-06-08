using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SE_Arcade_Launcher.Libraries
{
    public class SmartInstaller
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        public string InstallationFolder { get; set; }
        public bool Pin { get; set; }
        public bool Startup { get; set; }
        public string NewExeLocation { get; set; }
        public bool InstallProgram()
        {
            if (InstallationFolder == null) // Check if InstallationFolder is set
                throw new Exception("InstallationFolder is empty!");

            if (Assembly.GetExecutingAssembly().Location.Contains(InstallationFolder)) // Skip Installation as its already installed!
                return false; 

            AllocConsole(); // Alloc the console for debug output

            try
            {
                if (!Directory.Exists(InstallationFolder))
                    Directory.CreateDirectory(InstallationFolder); // Create missing directories
                else
                {
                    string[] oldFiles = Directory.GetFiles(InstallationFolder); // Get all files in installation directory directory

                    // Delete old files from installation directory
                    foreach (string x in oldFiles)
                    {
                        File.Delete(x); // Delete file
                    }
                    // Delete old files from installation directory
                }
            }
            catch
            {
                throw new Exception("InstallationFolder is invalid!"); // Catch an exception
            }

            string currentExecutingName = typeof(Program).Assembly.GetName().Name + ".exe"; // Get current assembly executable name

            string[] files = Directory.GetFiles(Environment.CurrentDirectory); // Get all files in runtime directory

            // Copy all files from runtime directory to installation path
            foreach (string x in files)
            {
                File.Copy(x, InstallationFolder + @"\" + x.Split( '\\')[x.Count(f => (f == '\\'))]);
            }
            // Copy all files from runtime directory to installation path

            SmartPinner.PinUnpinTaskbar(InstallationFolder + @"\" + currentExecutingName, Pin); // Pin exe to taskbar

            // Set as startup
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            key.SetValue(typeof(Program).Assembly.GetName().Name, InstallationFolder + @"\" + currentExecutingName);
            key.Close();

            File.WriteAllText(InstallationFolder + @"\Installation.Log", "Installation was successful!"); // Write a test file

            NewExeLocation = InstallationFolder + @"\" + currentExecutingName; // Save new exe to launch

            return true;
        }

        private class SmartPinner
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr LoadLibrary(string lpLibFileName);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern int LoadString(IntPtr hInstance, uint wID, StringBuilder lpBuffer, int nBufferMax);

            public static bool PinUnpinTaskbar(string filePath, bool PinExe)
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
                int MAX_PATH = 255;
                var actionIndex = PinExe ? 5386 : 5387;

                StringBuilder szPinToStartLocalized = new StringBuilder(MAX_PATH);
                IntPtr hShell32 = LoadLibrary("Shell32.dll");
                LoadString(hShell32, (uint)actionIndex, szPinToStartLocalized, MAX_PATH);
                string localizedVerb = szPinToStartLocalized.ToString();

                string path = Path.GetDirectoryName(filePath); // Get folder path
                string fileName = Path.GetFileName(filePath); // Get file name to pin

                // create the shell application object
                dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
                dynamic directory = shellApplication.NameSpace(path);
                dynamic link = directory.ParseName(fileName);

                dynamic verbs = link.Verbs();
                for (int i = 0; i < verbs.Count(); i++) // Run through all items
                {
                    dynamic verb = verbs.Item(i);
                    if (verb.Name.Equals(localizedVerb))
                    {
                        verb.DoIt(); // Run Script
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
