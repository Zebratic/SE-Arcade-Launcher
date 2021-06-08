using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace SE_Arcade_Launcher.Libraries
{
    public class VolumeControl
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public static void VolumeUp()
        {
            keybd_event((byte)Keys.VolumeUp, 0, 0, 0); // increase volume
        }

        public static void VolumeDown()
        {
            keybd_event((byte)Keys.VolumeDown, 0, 0, 0); // decrease volume
        }
    }
}