using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Arcade_Launcher.Libraries
{
    public class GameData
    {
        public int XRow { get; set; }
        public int YRow { get; set; }
        public string Name { get; set; }
        public string GamePath { get; set; }
        public string StartupParameters { get; set; }
        public string GameImagePath { get; set; }
        public GamePanel GamePanel { get; set; }
        public GameLabel GameLabel { get; set; }
    }
}
