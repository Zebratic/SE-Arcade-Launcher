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
using System.IO;
using SE_Arcade_Launcher.Libraries;

namespace SE_Arcade_Launcher
{
    public partial class frmLogin : Form
    {
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

        public frmLogin()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = UsernameBox;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            LoginSystem.Response response = LoginSystem.Login(UsernameBox.Text, PasswordBox.Text);
            switch (response)
            {
                case LoginSystem.Response.Logged_In:
                    DialogResult = DialogResult.Yes;
                    this.Close();
                    return;
                case LoginSystem.Response.Wrong_Username:
                    Notification.Alert("Wrong Username!", Notification.enmType.Warning);
                    break;
                case LoginSystem.Response.Wrong_Password:
                    Notification.Alert("Wrong Password!", Notification.enmType.Warning);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnProceed.PerformClick();
        }

        private void UsernameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnProceed.PerformClick();
        }
    }
}