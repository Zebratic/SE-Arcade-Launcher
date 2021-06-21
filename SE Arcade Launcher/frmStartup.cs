using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Arcade_Launcher
{
    public partial class frmStartup : Form
    {
        public frmMainMenu frmMainMenu { get; set; }
        public frmStartup()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.TopMost = true;
        }

        void VideoPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                Cursor.Show();
                frmMainMenu.Opacity = 100;
                frmMainMenu.Visible = true;
                frmMainMenu.ShowingIntro = false;
                frmMainMenu.Intro = this;
                this.Hide();
            }
            else if (e.newState == 2)
            {
                VideoPlayer.Ctlcontrols.play();
            }
        }

        private void frmStartup_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void LoadTimer_Tick(object sender, EventArgs e)
        {
            LoadTimer.Stop();
            frmMainMenu.Show();
            frmMainMenu.Hide();
        }

        private void frmStartup_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);
        public void Reload(frmMainMenu oldForm = null)
        {
            try { SetForegroundWindow(this.ActiveControl.Handle); } catch { }
            this.Show();
            Cursor.Hide();
            if (oldForm != null)
            {
                frmMainMenu = oldForm;
                frmMainMenu.Hide();
                frmMainMenu.ShowingIntro = true;
            }
            else
                frmMainMenu = new frmMainMenu(false);

            VideoPlayer.URL = Environment.CurrentDirectory + @"\intro.mp4";
            VideoPlayer.uiMode = "None";
            VideoPlayer.PlayStateChange += VideoPlayer_PlayStateChange;
            VideoPlayer.Ctlcontrols.play();
            LoadTimer.Start();
        }
    }
}