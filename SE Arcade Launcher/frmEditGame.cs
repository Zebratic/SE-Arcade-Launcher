using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using SE_Arcade_Launcher.Libraries;
using System.IO;

namespace SE_Arcade_Launcher
{
    public partial class frmEditGame : Form
    {
        public GameData SelectedGameData = new GameData();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
         );


        public frmEditGame()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load Selected Game Data
            if (SelectedGameData.GameImagePath != null)
            {
                try
                {
                    panel2.BackgroundImage = Image.FromFile(SelectedGameData.GameImagePath);
                }
                catch
                {
                    try
                    {
                        panel2.BackgroundImage = Icon.ExtractAssociatedIcon(SelectedGameData.GamePath).ToBitmap();
                    }
                    catch { panel2.BackgroundImage = SystemIcons.Error.ToBitmap(); }
                }
            }
            else
            {
                try
                {
                    panel2.BackgroundImage = Icon.ExtractAssociatedIcon(SelectedGameData.GamePath).ToBitmap();
                }
                catch { panel2.BackgroundImage = SystemIcons.Error.ToBitmap(); }
                panel2.BackgroundImageLayout = ImageLayout.Zoom;
            }
            label1.Text = "Edit " + SelectedGameData.Name;
            GAMENAMEBox.Text = SelectedGameData.Name;
            GAMEPATHBox.Text = SelectedGameData.GamePath;
            GAMESTARTUPPARAMETERSBox.Text = SelectedGameData.StartupParameters; 
        }

        bool changedImage = false;
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    panel2.BackgroundImage = Image.FromFile(ofd.FileName);
                    SelectedGameData.GameImagePath = ofd.FileName;
                    changedImage = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedGameData.Name = GAMENAMEBox.Text;
            SelectedGameData.GamePath = GAMEPATHBox.Text;
            SelectedGameData.StartupParameters = GAMESTARTUPPARAMETERSBox.Text;
            if (changedImage)
                SelectedGameData.GameImagePath = SelectedGameData.GameImagePath;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}