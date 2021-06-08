using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Arcade_Launcher.Libraries
{
    public class GamePanel
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
    }

    public class GameLabel
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string Text { get; set; }
    }
}
