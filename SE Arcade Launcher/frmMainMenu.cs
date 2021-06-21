using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SE_Arcade_Launcher.Libraries;
using SuperfastBlur;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SE_Arcade_Launcher.Libraries.DX;
using System.Media;

namespace SE_Arcade_Launcher
{
    public partial class frmMainMenu : Form
    {
        #region params
        public PictureBox BlurPanel = new PictureBox();
        public PictureBox LoadingAnimation = new PictureBox();
        public Button btnCancelLoad = new Button();
        public List<GameData> gameSaveData = new List<GameData>(); 
        public List<Panel> Games = new List<Panel>(); 
        public List<Label> GameLabels = new List<Label>();
        public GameData SelectedGameData = new GameData(); 
        public Panel SelectedGamePanel = new Panel();
        public Label SelectedGameLabel = new Label();
        public Panel LJoystickPos = new Panel();
        public Panel RJoystickPos = new Panel();
        public PerformanceCounter pCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        public PerformanceCounter pRAM = new PerformanceCounter("Memory", "Available MBytes");

        private SmartJoystick joystick;
        private bool[] joystickButtons;
        private string IconFilterString;
        private bool JoystickTesting = false;
        private bool FinishedScanning = false;
        private bool GameRunning = false;
        private int QuitValue = 0;
        private int CurrentPage = 0;
        private int CurrentGameNum = 1;
        private int KeepScrollSpeed = 1;

        private bool RuneMode { get; set; }
        private int EasterEggRuneCounter = 0;

        private int EasterEggSusCounter = 0;
        public frmStartup Intro { get; set; }

        public bool ShowingIntro = true;

        private XBoxController Controller = new XBoxController();
        #endregion params

        #region Startup
        public frmMainMenu(bool skipped = true)
        {
            InitializeComponent();
            if (!skipped)
            {
                this.Visible = false;
                this.Opacity = 0;
                this.Hide();
            }

            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            //Taskbar.Hide();

            BlurPanel.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            BlurPanel.Location = new Point(0, 0);
            BlurPanel.Visible = false;
            this.Controls.Add(BlurPanel);

            LoadingAnimation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BlurPanel.Controls.Add(LoadingAnimation);

            btnCancelLoad.FlatAppearance.BorderSize = 1;
            btnCancelLoad.FlatStyle = FlatStyle.Flat;
            btnCancelLoad.Font = new Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnCancelLoad.ForeColor = Color.FromArgb(0, 126, 249);
            btnCancelLoad.Size = new Size(186, 42);
            btnCancelLoad.Location = new Point((BlurPanel.Size.Width / 2) - (btnCancelLoad.Size.Width / 2), BlurPanel.Size.Height - 200);
            btnCancelLoad.Name = "btnCancelLoad";
            btnCancelLoad.Text = "Cancel";
            btnCancelLoad.Click += new EventHandler(this.btnCancelLoad_Click);
            btnCancelLoad.Leave += new EventHandler(this.btnCancelLoad_Leave);
            btnCancelLoad.Visible = false;
            BlurPanel.Controls.Add(btnCancelLoad);

            /*
            LJoystickPos.Size = new Size(4, 4);
            LJoystickPos.BackColor = Color.Red;
            LJoystickPos.Location = new Point(50 - (LJoystickPos.Size.Width / 2), 50 - (LJoystickPos.Size.Width / 2)); // get correct pos
            LJoystickArea.Controls.Add(LJoystickPos);
            LJoystickPos.BringToFront();

            
            RJoystickPos.Size = new Size(4, 4);
            RJoystickPos.BackColor = Color.Red;
            RJoystickPos.Location = new Point(50 - (RJoystickPos.Size.Width / 2), 50 - (RJoystickPos.Size.Width / 2)); // get correct pos
            this.Controls.Add(RJoystickPos);
            RJoystickPos.BringToFront();
            */

            pnlNav.Height = btnControls.Height;
            pnlNav.Top = btnControls.Top;
            pnlNav.Left = btnControls.Left;
            pnlNav.BringToFront();

            CurrentPage = 1;
            GamesPanel.Visible = false;
            ControlsPanel.Visible = true;
            CreditsPanel.Visible = false;
            PerformancePanel.Visible = false;
            SettingsPanel.Visible = false;

            //joystick = new SmartJoystick(this.Handle);
            //new Thread(() => connectToJoystick(joystick)).Start();
            new Thread(WaitforController).Start();

            IconFilterString = File.ReadAllText(Environment.CurrentDirectory + "\\Filters\\IconFilter.txt");


            PerformanceTimer.Start();

            LoginSystem.CreateFiles();

            SelectGame(-1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { LoadGameData(); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        #endregion Startup

        #region Joystick Controls
        private void WaitforController()
        {
            while (true)
            {
                if (Controller.Connection.Value)
                {
                    enableTimer();
                    break;
                }
            }
        }

        private void connectToJoystick(SmartJoystick joystick)
        {
            while (true)
            {
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    string info = "Name: " + joystick.GetControllerName() + "\n" +
                        "Guid: " + joystick.GetControllerGuid() + "\n" +
                        "Type: " + joystick.GetControllerType();


                    try { ControllerInfo.Invoke((MethodInvoker)delegate { ControllerInfo.Text = info; }); } catch { }
                    if (joystick.AcquireJoystick(sticks))
                    {
                        enableTimer();
                        break;
                    }
                }
                else
                {
                    try { ControllerInfo.Invoke((MethodInvoker)delegate { ControllerInfo.Text = "NONE"; }); } catch { }
                    Thread.Sleep(2000);
                }
            }
        }

        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate ()
                {
                    joystickTimer.Enabled = true;
                }));
            }
            else
                joystickTimer.Enabled = true;
        }

        private void joystickTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!GameRunning)
                {
                    // Volume Controls
                    if (Controller.Back.Value)
                        VolumeControl.VolumeDown();

                    if (Controller.Start.Value)
                        VolumeControl.VolumeUp();
                }
                else
                {
                    if (QuitValue > 15)
                    {
                        SendKeys.SendWait("(%{F4})");
                        GameRunning = false;
                        ShowLoadingScreen(false);
                        QuitValue = 0;
                    }
                    else if (Controller.Back.Value && Controller.Start.Value)
                        QuitValue++;
                    else if (!Controller.Back.Value && QuitValue != 0 || !Controller.Start.Value && QuitValue != 0)
                    {
                        QuitValue = 0;
                    }
                }

                #region Easter Egg
                if (!GameRunning)
                {
                    if (Controller.B.Value || Controller.A.Value || Controller.RightShoulder.Value || Controller.Y.Value)
                    {
                        if (SusEasterEgg(Controller))
                        {
                            new Thread(PlaySus).Start();
                            foreach (Panel pnl in Games)
                                pnl.BackgroundImage = Properties.Resources.sus1;
                            foreach (Label lbl in GameLabels)
                            {
                                int x = rnd.Next(0, 4);
                                if (x == 0)
                                    lbl.Text = "Sus.exe";
                                else if (x == 1)
                                    lbl.Text = "Drip.exe";
                                else if (x == 2)
                                    lbl.Text = "Amogus.exe";
                                else if (x == 3)
                                    lbl.Text = "Sussy Balls.exe";
                            }
                        }
                    }
                    if (Controller.Up.Value || Controller.Down.Value || Controller.Left.Value || Controller.Right.Value || Controller.B.Value || Controller.A.Value)
                    {
                        if (RuneEasterEgg(Controller))
                        {
                            RuneMode = true;
                            if (RuneMode)
                            {
                                
                                foreach (Control c in GetAll(this))
                                {
                                    try
                                    {
                                        if (c is PictureBox)
                                        {
                                            ((PictureBox)c).Image = Properties.Resources.Rune;
                                            ((PictureBox)c).BackgroundImageLayout = ImageLayout.Stretch;
                                        }
                                        else
                                        {
                                            c.BackgroundImage = Properties.Resources.Rune;
                                            c.BackgroundImageLayout = ImageLayout.Stretch;
                                        }
                                    }
                                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                                }
                            }
                            ReloadLauncher();
                            return;
                        }
                    }

                }
                #endregion

                if (JoystickTesting)
                {
                    // Min: 0
                    // Max: 65535

                    LeftStickValueLabel.Text = "X: " + Controller.LeftThumbstick.Value.X + "\nY: " + Controller.LeftThumbstick.Value.Y;
                    RightStickValueLabel.Text = "X: " + Controller.RightThumbstick.Value.X + "\nY: " + Controller.RightThumbstick.Value.X;
                    
                    /*
                    lblControllerDebug.Text =
                        "ARx: " + joystick.state.ARx + "\n" +
                        "ARy: " + joystick.state.ARy + "\n" +
                        "ARz: " + joystick.state.ARz + "\n" +
                        "AX: " + joystick.state.AX + "\n" +
                        "AY " + joystick.state.AY + "\n" +
                        "AZ: " + joystick.state.AZ + "\n" +
                        "FRx: " + joystick.state.FRx + "\n" +
                        "FRy: " + joystick.state.FRy + "\n" +
                        "FRz: " + joystick.state.FRz + "\n" +
                        "FX: " + joystick.state.FX + "\n" +
                        "FY: " + joystick.state.FY + "\n" +
                        "FZ: " + joystick.state.FZ + "\n" +
                        "Rx: " + joystick.state.Rx + "\n" +
                        "Ry: " + joystick.state.Ry + "\n" +
                        "Rz: " + joystick.state.Rz + "\n" +
                        "VRx: " + joystick.state.VRx + "\n" +
                        "VRy: " + joystick.state.VRy + "\n" +
                        "VRz: " + joystick.state.VRz + "\n" +
                        "VX: " + joystick.state.VX + "\n" +
                        "VY: " + joystick.state.VY + "\n" +
                        "VZ: " + joystick.state.VZ + "\n" +
                        "X: " + joystick.state.X + "\n" +
                        "Y: " + joystick.state.Y + "\n" +
                        "Z: " + joystick.state.Z;
                    */

                    lblControllerDebug.Text = "A: " + Controller.A.Value + "\n" +
                                              "B: " + Controller.B.Value + "\n" +
                                              "Back: " + Controller.Back.Value + "\n" +
                                              "Battery: " + Controller.Battery.Value + "\n" +
                                              "Connection: " + Controller.Connection.Value + "\n" +
                                              "Down: " + Controller.Down.Value + "\n" +
                                              "Left: " + Controller.Left.Value + "\n" +
                                              "LeftRumble: " + Controller.LeftRumble.Value + "\n" +
                                              "LeftShoulder: " + Controller.LeftShoulder.Value + "\n" +
                                              "LeftThumbclick: " + Controller.LeftThumbclick.Value + "\n" +
                                              "LeftThumbstick: " + Controller.LeftThumbstick.Value + "\n" +
                                              "LeftTrigger: " + Controller.LeftTrigger.Value + "\n" +
                                              "Right: " + Controller.Right.Value + "\n" +
                                              "RightRumble: " + Controller.RightRumble.Value + "\n" +
                                              "RightShoulder: " + Controller.RightShoulder.Value + "\n" +
                                              "RightThumbclick: " + Controller.RightThumbclick.Value + "\n" +
                                              "RightThumbstick: " + Controller.RightThumbstick.Value + "\n" +
                                              "RightTrigger: " + Controller.RightTrigger.Value + "\n" +
                                              "Start: " + Controller.Start.Value + "\n" +
                                              "Up: " + Controller.Up.Value + "\n" +
                                              "X: " + Controller.X.Value + "\n" +
                                              "Y: " + Controller.Y.Value;


                    LTriggerValueLabel.Text = Controller.LeftTrigger.Value.ToString();
                    LTriggerTrackbar.Value = Convert.ToInt32(Controller.LeftTrigger.Value);
                    RTriggerValueLabel.Text = Controller.RightTrigger.Value.ToString();
                    RTriggerTrackbar.Value = Convert.ToInt32(Controller.RightTrigger.Value);

                    MaxValueLabels.Text = "X: " + MaxXValue.Value + "      Y: " + MaxYValue.Value;
                    
                    // Right Thumbstick
                    if (Controller.RightThumbstick.Value.X < 65535 - MaxXValue.Value + 1 && !Controller.RightThumbstick.Value.X.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nRight Thumbstick Left";
                        ScrollToBottom();
                    }

                    if (Controller.RightThumbstick.Value.X > MaxXValue.Value - 1 && !Controller.RightThumbstick.Value.X.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nRight Thumbstick Right";
                        ScrollToBottom();
                    }

                    if (Controller.RightThumbstick.Value.Y < 65535 - MaxYValue.Value + 1 && !Controller.RightThumbstick.Value.Y.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nRight Thumbstick Up";
                        ScrollToBottom();
                    }

                    if (Controller.RightThumbstick.Value.Y > MaxYValue.Value - 1 && !Controller.RightThumbstick.Value.Y.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nRight Thumbstick Down";
                        ScrollToBottom();
                    }

                    // Left Thumbstick
                    if (Controller.LeftThumbstick.Value.X < 65535 - MaxXValue.Value + 1 && !Controller.LeftThumbstick.Value.X.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nLeft Thumbstick Left";
                        ScrollToBottom();
                    }

                    if (Controller.LeftThumbstick.Value.X > MaxXValue.Value - 1 && !Controller.LeftThumbstick.Value.X.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nLeft Thumbstick Right";
                        ScrollToBottom();
                    }

                    if (Controller.LeftThumbstick.Value.Y < 65535 - MaxYValue.Value + 1 && !Controller.LeftThumbstick.Value.Y.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nLeft Thumbstick Up";
                        ScrollToBottom();
                    }

                    if (Controller.LeftThumbstick.Value.Y > MaxYValue.Value - 1 && !Controller.LeftThumbstick.Value.Y.ToString().Contains("E"))
                    {
                        JoystickOutput.Text += "\nLeft Thumbstick Down";
                        ScrollToBottom();
                    }

                    // PS4 Triggers
                    /*
                    if (Convert.ToInt32(Controller.LeftTrigger.Value) == 1)
                        ControllerButton_L2.Invoke((MethodInvoker)delegate { ControllerButton_L2.Visible = true; });
                    else
                        ControllerButton_L2.Invoke((MethodInvoker)delegate { ControllerButton_L2.Visible = false; });

                    if (Convert.ToInt32(Controller.RightTrigger.Value) == 1)
                        ControllerButton_R2.Invoke((MethodInvoker)delegate { ControllerButton_R2.Visible = true; });
                    else
                        ControllerButton_R2.Invoke((MethodInvoker)delegate { ControllerButton_R2.Visible = false; });
                    */

                    #region Hori Joystick Buttons + DPad
                    if (Controller.Left.Value)
                    {
                        JoystickOutput.Text += "\nDPad Left";
                        ScrollToBottom();
                    }
                    if (Controller.Right.Value)
                    {
                        JoystickOutput.Text += "\nDPad Right";
                        ScrollToBottom();
                    }
                    if (Controller.Up.Value)
                    {
                        JoystickOutput.Text += "\nDPad Up";
                        ScrollToBottom();
                    }
                    if (Controller.Down.Value)
                    {
                        JoystickOutput.Text += "\nDPad Down";
                        ScrollToBottom();
                    }
                    if (Controller.A.Value)
                    {
                        JoystickOutput.Text += "\nA Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.B.Value)
                    {
                        JoystickOutput.Text += "\nB Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.X.Value)
                    {
                        JoystickOutput.Text += "\nX Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.Y.Value)
                    {
                        JoystickOutput.Text += "\nY Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.LeftShoulder.Value)
                    {
                        JoystickOutput.Text += "\nL Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.RightShoulder.Value)
                    {
                        JoystickOutput.Text += "\nR Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.Start.Value)
                    {
                        JoystickOutput.Text += "\n+ Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.Back.Value)
                    {
                        JoystickOutput.Text += "\n- Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.LeftTrigger.Value == 1)
                    {
                        JoystickOutput.Text += "\nZL Pressed";
                        ScrollToBottom();
                    }
                    if (Controller.RightTrigger.Value == 1)
                    {
                        JoystickOutput.Text += "\nZR Pressed";
                        ScrollToBottom();
                    }
                    #endregion



                    /*
                    for (int i = 0; i < Controller.Length; i++)
                    {
                        if (joystickButtons[i] == true)
                        {
                            JoystickOutput.Invoke((MethodInvoker)delegate { JoystickOutput.Text += "\nButton " + i + " Pressed"; });
                            new Thread(() => HighlightButton(i)).Start();
                            ScrollToBottom();
                        }
                    }
                    */
                }
                else
                {
                    #region Menu Movement
                    if (GamesPanel.Visible && !GameRunning)
                    {
                        // Right Left
                        /*
                        if (joystick.LXaxis < 65535 - MaxXValue.Value + 1)
                        {
                            ScrollToBottom();
                            SelectGame(-1);
                        }

                        if (joystick.LXaxis > MaxXValue.Value - 1)
                        {
                            ScrollToBottom();
                            SelectGame(1);
                        }

                        if (joystick.LYaxis < 65535 - MaxYValue.Value + 1)
                        {
                            ScrollToBottom();
                            SelectGame(-9);
                        }

                        if (joystick.LYaxis > MaxYValue.Value - 1)
                        {
                            ScrollToBottom();
                            SelectGame(9);
                        }
                        */

                        if (Controller.Left.Value)
                        {
                            SelectGame(-1);
                            JoystickOutput.Text += "\nDPad Left";
                            ScrollToBottom();
                            EditGameMenu.Hide();
                        }

                        if (Controller.Right.Value)
                        {
                            SelectGame(1);
                            JoystickOutput.Text += "\nDPad Right";
                            ScrollToBottom();
                            EditGameMenu.Hide();
                        }

                        if (Controller.Up.Value)
                        {
                            SelectGame(-9);
                            JoystickOutput.Text += "\nDPad Up";
                            ScrollToBottom();
                            EditGameMenu.Hide();
                        }

                        if (Controller.Down.Value)
                        {
                            SelectGame(9);
                            JoystickOutput.Text += "\nDPad Down";
                            ScrollToBottom();
                            EditGameMenu.Hide();
                        }

                        // Right Joystick
                        /*
                        if (joystick.RYaxis < 65535 - MaxYValue.Value + 1)
                        {
                            int count = 5 * KeepScrollSpeed;
                            GamesPanel.VerticalScroll.Value -= count;
                            Thread.Sleep(5);
                            GamesPanel.VerticalScroll.Value -= count;
                            Thread.Sleep(5);
                            GamesPanel.VerticalScroll.Value -= count;
                            Thread.Sleep(5);
                            GamesPanel.VerticalScroll.Value -= count;
                            if (KeepScrollSpeed < 25)
                                KeepScrollSpeed++;
                        }
                        else if (joystick.RYaxis > MaxYValue.Value - 1)
                        {
                            int count = 5 * KeepScrollSpeed;
                            GamesPanel.VerticalScroll.Value += count;
                            Thread.Sleep(5);
                            GamesPanel.VerticalScroll.Value += count;
                            Thread.Sleep(5);
                            GamesPanel.VerticalScroll.Value += count;
                            Thread.Sleep(5);
                            GamesPanel.VerticalScroll.Value += count;
                            if (KeepScrollSpeed < 25)
                                KeepScrollSpeed++;
                        }
                        else if (KeepScrollSpeed > 1)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (KeepScrollSpeed > 1)
                                    KeepScrollSpeed--;
                            }
                        }
                        */
                    }

                    if (!GameRunning)
                    {
                        if (Controller.LeftShoulder.Value) // menu up
                        {
                            EditGameMenu.Hide();

                            btnGames.BackColor = Color.FromArgb(24, 30, 54);
                            btnControls.BackColor = Color.FromArgb(24, 30, 54);
                            btnCredits.BackColor = Color.FromArgb(24, 30, 54);
                            btnPerformance.BackColor = Color.FromArgb(24, 30, 54);
                            btnSettings.BackColor = Color.FromArgb(24, 30, 54);

                            if (CurrentPage == 0)
                                btnSettings.PerformClick();
                            else if (CurrentPage == 1)
                                btnGames.PerformClick();
                            else if (CurrentPage == 2)
                                btnControls.PerformClick();
                            else if (CurrentPage == 3)
                                btnCredits.PerformClick();
                            else if (CurrentPage == 4)
                                btnPerformance.PerformClick();
                        }

                        if (Convert.ToInt32(Controller.LeftTrigger.Value) == 1) // menu down
                        {
                            EditGameMenu.Hide();

                            btnGames.BackColor = Color.FromArgb(24, 30, 54);
                            btnControls.BackColor = Color.FromArgb(24, 30, 54);
                            btnCredits.BackColor = Color.FromArgb(24, 30, 54);
                            btnPerformance.BackColor = Color.FromArgb(24, 30, 54);
                            btnSettings.BackColor = Color.FromArgb(24, 30, 54);

                            if (CurrentPage == 0)
                                btnControls.PerformClick();
                            else if (CurrentPage == 1)
                                btnCredits.PerformClick();
                            else if (CurrentPage == 2)
                                btnPerformance.PerformClick();
                            else if (CurrentPage == 3)
                                btnSettings.PerformClick();
                            else if (CurrentPage == 4)
                                btnGames.PerformClick();
                        }

                        if (Controller.A.Value && GamesPanel.Visible) // start game
                        {
                            EditGameMenu.Hide();
                            Panel FoundPanel = Games.Find(x => x.BackColor == Color.FromArgb(87, 92, 104));
                            List<GameData> PossibleGames = gameSaveData.FindAll(x => x.GamePanel.LocationX == FoundPanel.Location.X);
                            GameData SelectedGame = PossibleGames.Find(x => x.GamePanel.LocationY == FoundPanel.Location.Y);
                            StartGame(null, null, SelectedGame);
                        }
                        
                        if (Controller.X.Value && GamesPanel.Visible && LoginSystem.LoggedInAccount.Admin)
                        {
                            Panel FoundPanel = Games.Find(x => x.BackColor == Color.FromArgb(87, 92, 104));
                            List<GameData> PossibleGames = gameSaveData.FindAll(x => x.GamePanel.LocationX == FoundPanel.Location.X);
                            GameData SelectedGame = PossibleGames.Find(x => x.GamePanel.LocationY == FoundPanel.Location.Y);

                            Point pPanel = new Point(SelectedGame.GamePanel.LocationX, SelectedGame.GamePanel.LocationY);
                            Panel gamePanel = Games.Find(x => x.Location == pPanel);

                            Point pLabel = new Point(SelectedGame.GameLabel.LocationX, SelectedGame.GameLabel.LocationY);
                            Label gameLabel = GameLabels.Find(x => x.Location == pLabel);

                            SelectedGameData = SelectedGame;
                            SelectedGamePanel = gamePanel;
                            SelectedGameLabel = gameLabel;
                            EditGameMenu.Show(gameLabel.Location.X + 186, gameLabel.Location.Y + 74);
                        }
                    }
                    #endregion
                }
            }
            catch
            {
                joystickTimer.Enabled = false;
                //new Thread(() => connectToJoystick(joystick)).Start();
                new Thread(WaitforController).Start();
            }
        }

        public void SelectGame(int num = 0, Panel selectedPanel = null)
        {
            if (selectedPanel != null)
            {
                foreach (Panel pnl in Games)
                {
                    if (pnl.Location == selectedPanel.Location)
                        pnl.BackColor = Color.FromArgb(67, 72, 84);
                    else
                        pnl.BackColor = Color.FromArgb(37, 42, 64);
                }

                return;
            }
            int savednum = num;
            int maxnum = Games.Count;
            try
            {
                num += CurrentGameNum;
                int row = 0;
                if (num <= -1)
                {
                    num = 0;
                    return;
                }
                else if (num >= maxnum)
                {
                    num = maxnum;
                    return;
                }

                int checksum = num;
                redo:
                if (checksum >= 9)
                {
                    row++;
                    num -= 9;
                    checksum -= 9;
                    goto redo;
                }

                try
                {
                    List<GameData> possibleGames = gameSaveData.FindAll(x => x.YRow == row);
                    GameData SelectedGame = possibleGames.Find(x => x.XRow == num);

                    // Panel
                    foreach (Panel pnl in Games)
                        pnl.BackColor = Color.FromArgb(37, 42, 64);

                    Point pPanel = new Point(SelectedGame.GamePanel.LocationX, SelectedGame.GamePanel.LocationY - Math.Abs(GamesPanel.VerticalScroll.Value));
                    Panel GamePanel = Games.Find(x => x.Location == pPanel);
                    GamePanel.BackColor = Color.FromArgb(87, 92, 104);

                    // Label
                    foreach (Label lbl in GameLabels)
                        lbl.ForeColor = Color.FromArgb(0, 126, 249);

                    Point pLabel = new Point(SelectedGame.GameLabel.LocationX, SelectedGame.GameLabel.LocationY - Math.Abs(GamesPanel.VerticalScroll.Value));
                    Label GameLabel = GameLabels.Find(x => x.Location == pLabel);
                    GameLabel.ForeColor = Color.FromArgb(255, 255, 255);

                    // auto scrolling
                    if (GameLabel.Location.Y > (GamesPanel.Location.Y + GamesPanel.Size.Height - 250))
                    {
                        GamesPanel.VerticalScroll.Value += 243;
                    }
                    else if (GameLabel.Location.Y < (GamesPanel.Location.Y - GamesPanel.Size.Height + 250))
                    {
                        GamesPanel.VerticalScroll.Value -= 243;
                    }

                    CurrentGameNum += savednum;
                }
                catch
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void ScrollToBottom()
        {
            JoystickOutput.Invoke((MethodInvoker)delegate { JoystickOutput.Select(JoystickOutput.Text.Length, 0); });
            JoystickOutput.Invoke((MethodInvoker)delegate { JoystickOutput.ScrollToCaret(); });
        }

        public void HighlightButton(int i)
        {
            switch (i)
            {
                case 0:
                    ControllerButton_Square.Invoke((MethodInvoker)delegate { ControllerButton_Square.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_Square.Invoke((MethodInvoker)delegate { ControllerButton_Square.Visible = false; });
                    break;

                case 1:

                    ControllerButton_X.Invoke((MethodInvoker)delegate { ControllerButton_X.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_X.Invoke((MethodInvoker)delegate { ControllerButton_X.Visible = false; });
                    break;

                case 2:

                    ControllerButton_Circle.Invoke((MethodInvoker)delegate { ControllerButton_Circle.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_Circle.Invoke((MethodInvoker)delegate { ControllerButton_Circle.Visible = false; });
                    break;

                case 3:

                    ControllerButton_Triangle.Invoke((MethodInvoker)delegate { ControllerButton_Triangle.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_Triangle.Invoke((MethodInvoker)delegate { ControllerButton_Triangle.Visible = false; });
                    break;

                case 4:

                    ControllerButton_L1.Invoke((MethodInvoker)delegate { ControllerButton_L1.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_L1.Invoke((MethodInvoker)delegate { ControllerButton_L1.Visible = false; });
                    break;

                case 5:

                    ControllerButton_R1.Invoke((MethodInvoker)delegate { ControllerButton_R1.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_R1.Invoke((MethodInvoker)delegate { ControllerButton_R1.Visible = false; });
                    break;

                // 6 + 7 is using TriggerValue

                case 8:

                    ControllerButton_Share.Invoke((MethodInvoker)delegate { ControllerButton_Share.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_Share.Invoke((MethodInvoker)delegate { ControllerButton_Share.Visible = false; });
                    break;

                case 9:

                    ControllerButton_Options.Invoke((MethodInvoker)delegate { ControllerButton_Options.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_Options.Invoke((MethodInvoker)delegate { ControllerButton_Options.Visible = false; });
                    break;

                case 10:

                    ControllerButton_LStick.Invoke((MethodInvoker)delegate { ControllerButton_LStick.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_LStick.Invoke((MethodInvoker)delegate { ControllerButton_LStick.Visible = false; });
                    break;

                case 11:

                    ControllerButton_RStick.Invoke((MethodInvoker)delegate { ControllerButton_RStick.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_RStick.Invoke((MethodInvoker)delegate { ControllerButton_RStick.Visible = false; });
                    break;

                case 12:

                    ControllerButton_PS.Invoke((MethodInvoker)delegate { ControllerButton_PS.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_PS.Invoke((MethodInvoker)delegate { ControllerButton_PS.Visible = false; });
                    break;

                case 13:

                    ControllerButton_TouchPad.Invoke((MethodInvoker)delegate { ControllerButton_TouchPad.Visible = true; });
                    Thread.Sleep(200);
                    ControllerButton_TouchPad.Invoke((MethodInvoker)delegate { ControllerButton_TouchPad.Visible = false; });
                    break;
            }
        }

        #endregion Joystick Controls

        #region Menu buttons
        private void btnCancelLoad_Click(object sender, EventArgs e)
        {
            ShowLoadingScreen(false);
            GameRunning = false;
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnGames.Height;
            pnlNav.Top = btnGames.Top;
            btnGames.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "All Games";
            GamesPanel.Visible = true;
            ControlsPanel.Visible = false;
            CreditsPanel.Visible = false;
            PerformancePanel.Visible = false;
            SettingsPanel.Visible = false;
            CurrentPage = 0;
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnControls.Height;
            pnlNav.Top = btnControls.Top;
            btnControls.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Controls";
            GamesPanel.Visible = false;
            ControlsPanel.Visible = true;
            CreditsPanel.Visible = false;
            PerformancePanel.Visible = false;
            SettingsPanel.Visible = false;
            CurrentPage = 1;
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCredits.Height;
            pnlNav.Top = btnCredits.Top;
            btnCredits.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Credits";
            GamesPanel.Visible = false;
            ControlsPanel.Visible = false;
            CreditsPanel.Visible = true;
            PerformancePanel.Visible = false;
            SettingsPanel.Visible = false;
            CurrentPage = 2;
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPerformance.Height;
            pnlNav.Top = btnPerformance.Top;
            btnPerformance.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Performance";
            GamesPanel.Visible = false;
            ControlsPanel.Visible = false;
            CreditsPanel.Visible = false;
            PerformancePanel.Visible = true;
            SettingsPanel.Visible = false;
            CurrentPage = 3;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Settings";
            GamesPanel.Visible = false;
            ControlsPanel.Visible = false;
            CreditsPanel.Visible = false;
            PerformancePanel.Visible = false;
            SettingsPanel.Visible = true;
            CurrentPage = 4;
        }

        private void btnCancelLoad_Leave(object sender, EventArgs e)
        {
            btnCancelLoad.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnGames.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnHighscores_Leave(object sender, EventArgs e)
        {
            btnControls.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCredits_Leave(object sender, EventArgs e)
        {
            btnCredits.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPerformance_Leave(object sender, EventArgs e)
        {
            btnPerformance.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion Menu buttons

        #region Game Handler
        private int XRow = 0;
        private int YRow = 0;

        public void AddGame(GameData data, bool save)
        {
            Image iconForFile = SystemIcons.Error.ToBitmap();
            try
            {
                iconForFile = Image.FromFile(data.GameImagePath);
            }
            catch
            {
                try
                {
                    iconForFile = Icon.ExtractAssociatedIcon(data.GamePath).ToBitmap();
                }
                catch { }
            }
            

            if (XRow == 9)
            {
                YRow++;
                XRow = 0;
            }

            int panelSizeX = 170;
            int panelSizeY = 237;
            int panelLocationX = XRow * 176;
            int panelLocationY = YRow * 243;

            Panel GamePanel = new Panel();
            GamePanel.Size = new Size(panelSizeX, panelSizeY);
            GamePanel.Location = new Point(12 + panelLocationX, 42 + panelLocationY);
            GamePanel.BackgroundImage = iconForFile;
            GamePanel.BackgroundImageLayout = ImageLayout.Zoom;
            GamePanel.BackColor = Color.FromArgb(37, 42, 64);

            Label GameLabel = new Label();
            GameLabel.AutoSize = false;
            GameLabel.Size = new Size(panelSizeX, 16);
            GameLabel.TextAlign = ContentAlignment.MiddleCenter;
            GameLabel.ForeColor = Color.FromArgb(0, 126, 249);
            GameLabel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            GameLabel.Location = new Point(12 + panelLocationX, 42 + panelLocationY);
            GameLabel.Text = data.Name;
            GameLabel.BackColor = Color.FromArgb(27, 32, 54);

            GamePanel PanelToAdd = new GamePanel();
            PanelToAdd.LocationX = GamePanel.Location.X;
            PanelToAdd.LocationY = GamePanel.Location.Y;

            GameLabel LabelToAdd = new GameLabel();
            LabelToAdd.LocationX = GameLabel.Location.X;
            LabelToAdd.LocationY = GameLabel.Location.Y;

            GameData gameSettings = new GameData();
            gameSettings.XRow = XRow;
            gameSettings.YRow = YRow;
            gameSettings.Name = data.Name;
            gameSettings.GamePath = data.GamePath;
            gameSettings.StartupParameters = data.StartupParameters;
            gameSettings.GameImagePath = data.GameImagePath;
            gameSettings.GamePanel = PanelToAdd;
            gameSettings.GameLabel = LabelToAdd;

            GamePanel.DoubleClick += delegate (object sender, EventArgs e) { StartGame(sender, e, gameSettings); };
            GamePanel.Click += delegate (object sender, EventArgs e) { ShowEditMenu(sender, e as MouseEventArgs, gameSettings, GamePanel, GameLabel); };
            GamePanel.Enter += delegate (object sender, EventArgs e) { SelectGame(selectedPanel: GamePanel); };
            GamePanel.Leave += delegate (object sender, EventArgs e) { SelectGame(selectedPanel: GamePanel); };

            GamesPanel.Invoke((MethodInvoker)delegate { GamesPanel.Controls.Add(GamePanel); });
            GamesPanel.Invoke((MethodInvoker)delegate { GamesPanel.Controls.Add(GameLabel); });
            GamePanel.Invoke((MethodInvoker) delegate { GamePanel.BringToFront(); });
            GameLabel.Invoke((MethodInvoker) delegate { GameLabel.BringToFront(); });

            Games.Add(GamePanel);
            GameLabels.Add(GameLabel);
            if (save)
            {
                gameSaveData.Add(gameSettings);
                SaveGameData(gameSaveData);
            }
            if (XRow == 0 && YRow == 0)
            {
                CurrentGameNum = 0;
                SelectGame(0);
            }
            XRow++;
        }

        private void StartGame(object sender, EventArgs e, GameData gameSettings)
        {
            try
            {
                GameRunning = true;
                this.TopMost = false;
                Process gameProcess = Process.Start(gameSettings.GamePath, gameSettings.StartupParameters);
                ShowLoadingScreen(true);
                new Thread(() => AwaitProcessToDie(gameProcess, Path.GetFileNameWithoutExtension(gameSettings.GamePath))).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SE Arcade Launcher");
            }
        }

        public void ShowLoadingScreen(bool Visible)
        {
            if (Visible)
            {
                Image img = Image.FromFile(GetRandomImageFile());
                LoadingAnimation.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
                LoadingAnimation.Location = new Point((BlurPanel.Width / 2) - (LoadingAnimation.Width / 2), (BlurPanel.Height / 2) - (LoadingAnimation.Height / 2));
                LoadingAnimation.Image = img;
                LoadingAnimation.Parent = BlurPanel;
                LoadingAnimation.BackColor = Color.Transparent;
                LoadingAnimation.SizeMode = PictureBoxSizeMode.Zoom;
                Bitmap bmp = Snapshot.TakeSnapshot(this);
                bmp = new GaussianBlur(bmp).Process(5);
                BlurPanel.BackgroundImage = bmp;
                BlurPanel.Visible = true;
                BlurPanel.BringToFront();
                btnCancelLoad.Visible = true;
                btnCancelLoad.BringToFront();
            }
            else
            {
                BlurPanel.Visible = false;
            }
        }

        public void AwaitProcessToDie(Process gameProcess, string gamename)
        {
            redo:
            while (!gameProcess.HasExited) { Thread.Sleep(1000); }
            gameProcess.WaitForExit();
            Thread.Sleep(1000);
            retry:
            try
            {
                Process[] foundprocesses = Process.GetProcesses();
                foreach (Process pro in foundprocesses)
                {
                    if (pro.ProcessName.ToLower().Contains(gamename.ToLower()))
                    {
                        gameProcess = pro;
                        goto redo;
                    }
                    else if (pro.Id == gameProcess.Id)
                    {
                        gameProcess = pro;
                        goto redo;
                    }
                }

                Process Idpro = Process.GetProcessById(gameProcess.Id);
                if (!Idpro.HasExited)
                {
                    gameProcess = Idpro;
                    goto redo;
                }

                GameRunning = false;
                this.TopMost = true;
                this.Invoke((MethodInvoker)delegate { ShowLoadingScreen(false); });
            }
            catch
            {
                Thread.Sleep(1000);
                goto retry;
            }
        }

        private void ShowEditMenu(object sender, MouseEventArgs e, GameData gameSettings, Panel gamePanel, Label gameLabel)
        {
            if (e.Button == MouseButtons.Right && LoginSystem.LoggedInAccount.Admin)
            {
                SelectedGameData = gameSettings;
                SelectedGamePanel = gamePanel;
                SelectedGameLabel = gameLabel;
                EditGameMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void SaveGameData(List<GameData> gameData)
        {   
            string json = System.Text.Json.JsonSerializer.Serialize(gameData);
            File.WriteAllText("GameData.json", json);
        }

        private void LoadGameData(string filter = "")
        {
            using (StreamReader r = new StreamReader("GameData.json"))
            {
                string json = r.ReadToEnd();
                List<GameData> data = JsonConvert.DeserializeObject<List<GameData>>(json);
                foreach (GameData newGameData in data)
                {
                    if (newGameData.Name.ToLower().Contains(filter))
                    {
                        gameSaveData.Add(newGameData);
                        AddGame(newGameData, false);
                    }
                }
            }
        }

        private void ClearGames()
        {
            foreach (Panel x in Games)
            {
                x.Dispose();
            }
            foreach (Label x in GameLabels)
            {
                x.Dispose();
            }
            Games.Clear();
            GameLabels.Clear();
            gameSaveData.Clear();
            YRow = 0;
            XRow = 0;
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    GameData data = new GameData();
                    data.Name = ofd.SafeFileName.Replace(Path.GetExtension(ofd.FileName), "");
                    data.GamePath = ofd.FileName;
                    data.StartupParameters = "";
                    data.GameImagePath = "";
                    AddGame(data, true);
                }
            }
        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            if (SearchBox.Text == " Search for games...")
            {
                SearchBox.Clear();
            }
        }

        private void EditGame_Click(object sender, EventArgs e)
        {
            frmEditGame frmEditGame = new frmEditGame();
            frmEditGame.SelectedGameData = SelectedGameData;
            string lastSavedImagePath = SelectedGameData.GameImagePath;
            string lastSavedGamePath = SelectedGameData.GamePath;

            if (frmEditGame.ShowDialog() == DialogResult.OK)
            {
                SelectedGameLabel.Text = frmEditGame.SelectedGameData.Name;
                SelectedGameData.Name = frmEditGame.SelectedGameData.Name;
                SelectedGameData.StartupParameters = frmEditGame.SelectedGameData.StartupParameters;
                SelectedGameData.GamePath = frmEditGame.SelectedGameData.GamePath;

                if (lastSavedImagePath != SelectedGameData.GameImagePath)
                {
                    SelectedGamePanel.BackgroundImage = Image.FromFile(frmEditGame.SelectedGameData.GameImagePath);
                    SelectedGameData.GameImagePath = frmEditGame.SelectedGameData.GameImagePath;
                }

                frmEditGame.Dispose();

                var obj = gameSaveData.FirstOrDefault(x => x.GamePath == lastSavedGamePath);
                if (obj != null)
                {
                    obj.Name = SelectedGameData.Name;
                    obj.GamePath = SelectedGameData.GamePath;
                    obj.StartupParameters = SelectedGameData.StartupParameters;
                    if (SelectedGameData.GameImagePath != null)
                        obj.GameImagePath = SelectedGameData.GameImagePath;
                }
                SaveGameData(gameSaveData);
            }
        }

        private void btnRemoveGame_Click(object sender, EventArgs e)
        {
            var obj = gameSaveData.FirstOrDefault(x => x.GamePath == SelectedGameData.GamePath);
            if (obj != null)
                gameSaveData.Remove(obj);

            SaveGameData(gameSaveData);
            ClearGames();
            LoadGameData();
        }
        #endregion Game Handler

        #region Login Handler
        private void lblUsername_Click(object sender, EventArgs e)
        {
            UserProfilePicture_Click(null, null);
        }

        private void UserProfilePicture_Click(object sender, EventArgs e)
        {
            frmLogin Login = new frmLogin();
            DialogResult dr = Login.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                lblUsername.Text = LoginSystem.LoggedInAccount.Username;
                lblCredits.Text = "Credits: " + LoginSystem.LoggedInAccount.Credits;
                if (LoginSystem.LoggedInAccount.Admin)
                {
                    btnAddGame.Visible = true;
                    btnScanForGames.Visible = true;
                    btnClearGames.Visible = true;
                    btnExit.Visible = true;
                    Taskbar.Show();
                }

                Notification.Alert("Successfully logged in!", Notification.enmType.Success);
            }
        }

        #endregion Login Handler

        private void btnScanForGames_Click(object sender, EventArgs e)
        {
            ShowLoadingScreen(true);
            GamesPanel.AutoScroll = false;
            int gamecount = 0;
            Thread tr = new Thread(() => ScanForGames(out gamecount));
            tr.Start();
            new Thread(() =>
            {
                while (!FinishedScanning) { Thread.Sleep(100); }
                Notification.Alert($"Successfully found {gamecount} games!", Notification.enmType.Success); // not showing up??
            }).Start();
            FinishedScanning = false;
        }

        public void ScanForGames(out int gamecount)
        {
            gamecount = 0;
            foreach (string path in GameScanner.FindGames())
            {
                if (CheckIfFiltered(path))
                {
                    GameData data = new GameData();
                    data.Name = Path.GetFileName(path);
                    data.GamePath = path;
                    data.StartupParameters = "";
                    data.GameImagePath = "";
                    AddGame(data, true);
                    gamecount++;
                }
                Thread.Sleep(50); // to extend load animation cuz sex
            }
            GamesPanel.Invoke((MethodInvoker) delegate { GamesPanel.AutoScroll = true; });
            this.Invoke((MethodInvoker) delegate {  ShowLoadingScreen(false); });
            FinishedScanning = true;
        }

        private bool CheckIfFiltered(string path)
        {
            ImageConverter converter = new ImageConverter();
            byte[] iconBytes = (byte[])converter.ConvertTo(Icon.ExtractAssociatedIcon(path).ToBitmap(), typeof(byte[]));
            string currentIconData = Convert.ToBase64String(iconBytes);
            //if (path.Contains("vcredist_x86.exe"))
            //{
            //    File.WriteAllText(Environment.CurrentDirectory + "\\Filters\\IconFilter2.txt", currentIconData);
            //}
            if (IconFilterString.ToLower().Contains(currentIconData.ToLower()))
                return false;
            else
                return true;
        }

        private void btnClearGames_Click(object sender, EventArgs e)
        {
            ClearGames();
            SaveGameData(gameSaveData);
            CurrentGameNum = 0;
            SelectGame(0);
        }

        private Random rnd = new Random();
        private string GetRandomImageFile()
        {
            string file = null;
            if (!string.IsNullOrEmpty(Environment.CurrentDirectory + "\\LoadingAnimations"))
            {
                var extensions = new string[] { ".png", ".jpg", ".gif" };
                try
                {
                    var di = new DirectoryInfo(Environment.CurrentDirectory + "\\LoadingAnimations");
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    int fileCount = rgFiles.Count();
                    if (fileCount > 0)
                    {
                        int x = rnd.Next(0, fileCount);
                        file = rgFiles.ElementAt(x).FullName;
                    }
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            return file;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            ClearGames();
            LoadGameData(SearchBox.Text);
        }

        private void copyIconDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageConverter converter = new ImageConverter();
            var obj = gameSaveData.FirstOrDefault(x => x.GamePath == SelectedGameData.GamePath);
            if (obj != null) 
                Clipboard.SetText(Convert.ToBase64String((byte[])converter.ConvertTo(Icon.ExtractAssociatedIcon(SelectedGameData.GamePath).ToBitmap(), typeof(byte[]))));
        }

        private void PerformanceTimer_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            CPUChart.Series["CPU"].Points.AddY(fcpu);
            RAMChart.Series["RAM"].Points.AddY(fram);

            if (CPUChart.Series[0].Points.Count() >= 40)
                PerformanceTimer.Interval = 100;

            if (CPUChart.Series[0].Points.Count() >= 40)
                CPUChart.Series[0].Points.RemoveAt(0);

            if (RAMChart.Series[0].Points.Count() >= 40)
                RAMChart.Series[0].Points.RemoveAt(0);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (JoystickTesting)
            {
                btnStartTest.Text = "Start Test";
                JoystickTesting = false;
            }
            else
            {
                btnStartTest.Text = "Stop Test";
                JoystickTesting = true;
            }
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!LoginSystem.LoggedInAccount.Admin)
                e.Cancel = true;
            else
                Environment.Exit(98);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(99);
        }

        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        private void LockdownTimer_Tick(object sender, EventArgs e)
        {
            if (!GameRunning)
                try { SetForegroundWindow(this.ActiveControl.Handle); } catch { }
        }

        private bool RuneEasterEgg(XBoxController xbc)
        {
            if (EasterEggRuneCounter == 0 && xbc.Up.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 1 && xbc.Up.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 2 && xbc.Down.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 3 && xbc.Down.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 4 && xbc.Left.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 5 && xbc.Right.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 6 && xbc.Left.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 7 && xbc.Right.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 8 && xbc.B.Value)
                EasterEggRuneCounter++;
            else if (EasterEggRuneCounter == 9 && xbc.A.Value)
            {
                Notification.Alert("Rune mode activated", Notification.enmType.Success);
                EasterEggRuneCounter = 0;
                return true;
            }
            else
            {
                if (EasterEggRuneCounter > 5 && !JoystickTesting)
                    Notification.Alert("hmm... Maybe try on testing mode?", Notification.enmType.Info);

                EasterEggRuneCounter = 0;
            }

            return false;
        }

        private bool SusEasterEgg(XBoxController xbc)
        {
            if (EasterEggSusCounter == 0 && xbc.B.Value)
                EasterEggSusCounter++;
            else if (EasterEggSusCounter == 1 && xbc.A.Value)
                EasterEggSusCounter++;
            else if (EasterEggSusCounter == 2 && xbc.RightShoulder.Value)
                EasterEggSusCounter++;
            else if (EasterEggSusCounter == 3 && xbc.RightShoulder.Value)
                EasterEggSusCounter++;
            else if (EasterEggSusCounter == 4 && xbc.Y.Value)
            {
                Notification.Alert("Sus mode activated", Notification.enmType.Success);
                EasterEggSusCounter = 0;
                return true;
            }
            else
            {
                if (EasterEggRuneCounter > 2 && !JoystickTesting)
                    Notification.Alert("hmm... Maybe try on testing mode?", Notification.enmType.Info);

                EasterEggSusCounter = 0;
            }

            return false;
        }

        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls);
        }

        private void ReloadLauncher()
        {
            this.Hide();
            Intro.Reload(this);
        }

        private void PlaySus()
        {
            SoundPlayer sus = new SoundPlayer(Properties.Resources.sus);
            sus.PlaySync();
        }
    }
}