using System;
using SE_Arcade_Launcher.Libraries;

namespace SE_Arcade_Launcher
{
    partial class frmMainMenu
    {
        public GameData gameSettings;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCredits = new System.Windows.Forms.Button();
            this.btnPerformance = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnHighscores = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.UserProfilePicture = new System.Windows.Forms.PictureBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.GamesPanel = new System.Windows.Forms.Panel();
            this.btnClearGames = new System.Windows.Forms.Button();
            this.btnScanForGames = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.EditGameMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditGame = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIconDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HighscoresPanel = new System.Windows.Forms.Panel();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.RJoystickArea = new System.Windows.Forms.Panel();
            this.LJoystickArea = new System.Windows.Forms.Panel();
            this.lblDeadzone = new System.Windows.Forms.Label();
            this.RTriggerTrackbar = new Siticone.UI.WinForms.SiticoneTrackBar();
            this.LTriggerTrackbar = new Siticone.UI.WinForms.SiticoneTrackBar();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnTestRMotor = new System.Windows.Forms.Button();
            this.btnTestLMotor = new System.Windows.Forms.Button();
            this.LTriggerValueLabel = new System.Windows.Forms.Label();
            this.RTriggerValueLabel = new System.Windows.Forms.Label();
            this.ControllerButton_RStick = new System.Windows.Forms.PictureBox();
            this.ControllerButton_LStick = new System.Windows.Forms.PictureBox();
            this.ControllerButton_L2 = new System.Windows.Forms.PictureBox();
            this.ControllerButton_R2 = new System.Windows.Forms.PictureBox();
            this.ControllerButton_TouchPad = new System.Windows.Forms.PictureBox();
            this.ControllerButton_Options = new System.Windows.Forms.PictureBox();
            this.ControllerButton_R1 = new System.Windows.Forms.PictureBox();
            this.ControllerButton_Share = new System.Windows.Forms.PictureBox();
            this.ControllerButton_L1 = new System.Windows.Forms.PictureBox();
            this.ControllerButton_Square = new System.Windows.Forms.PictureBox();
            this.ControllerButton_Triangle = new System.Windows.Forms.PictureBox();
            this.ControllerButton_Circle = new System.Windows.Forms.PictureBox();
            this.ControllerButton_X = new System.Windows.Forms.PictureBox();
            this.ControllerButton_PS = new System.Windows.Forms.PictureBox();
            this.MaxYValue = new Siticone.UI.WinForms.SiticoneVTrackBar();
            this.MaxValueLabels = new System.Windows.Forms.Label();
            this.MaxXValue = new Siticone.UI.WinForms.SiticoneVTrackBar();
            this.RightStickValueLabel = new System.Windows.Forms.Label();
            this.LeftStickValueLabel = new System.Windows.Forms.Label();
            this.GameController = new System.Windows.Forms.PictureBox();
            this.ControllerInfo = new System.Windows.Forms.Label();
            this.JoystickOutput = new System.Windows.Forms.RichTextBox();
            this.joystickTimer = new System.Windows.Forms.Timer(this.components);
            this.PerformancePanel = new System.Windows.Forms.Panel();
            this.CPUChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RAMChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PerformanceTimer = new System.Windows.Forms.Timer(this.components);
            this.CreditsPanel = new System.Windows.Forms.Panel();
            this.lblCreditsAIΩN = new System.Windows.Forms.Label();
            this.picCreditsAIΩN = new System.Windows.Forms.PictureBox();
            this.lblCreditsBulldog = new System.Windows.Forms.Label();
            this.picCreditsBulldog = new System.Windows.Forms.PictureBox();
            this.lblCreditsPsyke = new System.Windows.Forms.Label();
            this.picCreditsPsyke = new System.Windows.Forms.PictureBox();
            this.lblCreditsFriendlyFrank = new System.Windows.Forms.Label();
            this.picCreditsFriendlyFrank = new System.Windows.Forms.PictureBox();
            this.lblCreditsZebratic = new System.Windows.Forms.Label();
            this.picCreditsZebratic = new System.Windows.Forms.PictureBox();
            this.lblCreditsTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.LockdownTimer = new System.Windows.Forms.Timer(this.components);
            this.lblControllerDebug = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePicture)).BeginInit();
            this.GamesPanel.SuspendLayout();
            this.EditGameMenu.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_RStick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_LStick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_R2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_TouchPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_R1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Share)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_L1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Square)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Triangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Circle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_PS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameController)).BeginInit();
            this.PerformancePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPUChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMChart)).BeginInit();
            this.CreditsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsAIΩN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsBulldog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsPsyke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsFriendlyFrank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsZebratic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnCredits);
            this.panel1.Controls.Add(this.btnPerformance);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnHighscores);
            this.panel1.Controls.Add(this.btnGames);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 1080);
            this.panel1.TabIndex = 0;
            // 
            // btnCredits
            // 
            this.btnCredits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCredits.FlatAppearance.BorderSize = 0;
            this.btnCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCredits.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnCredits.Image = global::SE_Arcade_Launcher.Properties.Resources.Conact;
            this.btnCredits.Location = new System.Drawing.Point(0, 954);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(186, 42);
            this.btnCredits.TabIndex = 4;
            this.btnCredits.Text = "Credits";
            this.btnCredits.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCredits.UseVisualStyleBackColor = true;
            this.btnCredits.Click += new System.EventHandler(this.btnCredits_Click);
            this.btnCredits.Leave += new System.EventHandler(this.btnCredits_Leave);
            // 
            // btnPerformance
            // 
            this.btnPerformance.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPerformance.FlatAppearance.BorderSize = 0;
            this.btnPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerformance.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerformance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnPerformance.Image = global::SE_Arcade_Launcher.Properties.Resources.diagram;
            this.btnPerformance.Location = new System.Drawing.Point(0, 996);
            this.btnPerformance.Name = "btnPerformance";
            this.btnPerformance.Size = new System.Drawing.Size(186, 42);
            this.btnPerformance.TabIndex = 3;
            this.btnPerformance.Text = "Performance";
            this.btnPerformance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPerformance.UseVisualStyleBackColor = true;
            this.btnPerformance.Click += new System.EventHandler(this.btnPerformance_Click);
            this.btnPerformance.Leave += new System.EventHandler(this.btnPerformance_Leave);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 154);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 42);
            this.pnlNav.TabIndex = 2;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnSettings.Image = global::SE_Arcade_Launcher.Properties.Resources.settings;
            this.btnSettings.Location = new System.Drawing.Point(0, 1038);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(186, 42);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnSettings.Leave += new System.EventHandler(this.btnsettings_Leave);
            // 
            // btnHighscores
            // 
            this.btnHighscores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHighscores.FlatAppearance.BorderSize = 0;
            this.btnHighscores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighscores.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighscores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnHighscores.Image = global::SE_Arcade_Launcher.Properties.Resources.calendar;
            this.btnHighscores.Location = new System.Drawing.Point(0, 196);
            this.btnHighscores.Name = "btnHighscores";
            this.btnHighscores.Size = new System.Drawing.Size(186, 42);
            this.btnHighscores.TabIndex = 1;
            this.btnHighscores.Text = "Highscores";
            this.btnHighscores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHighscores.UseVisualStyleBackColor = true;
            this.btnHighscores.Click += new System.EventHandler(this.btnHighscores_Click);
            this.btnHighscores.Leave += new System.EventHandler(this.btnHighscores_Leave);
            // 
            // btnGames
            // 
            this.btnGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGames.FlatAppearance.BorderSize = 0;
            this.btnGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGames.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnGames.Image = global::SE_Arcade_Launcher.Properties.Resources.home;
            this.btnGames.Location = new System.Drawing.Point(0, 154);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(186, 42);
            this.btnGames.TabIndex = 1;
            this.btnGames.Text = "All Games";
            this.btnGames.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGames.UseVisualStyleBackColor = true;
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            this.btnGames.Leave += new System.EventHandler(this.btnDashbord_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCredits);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.UserProfilePicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 154);
            this.panel2.TabIndex = 0;
            // 
            // lblCredits
            // 
            this.lblCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblCredits.Location = new System.Drawing.Point(0, 122);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(186, 12);
            this.lblCredits.TabIndex = 2;
            this.lblCredits.Text = "Credits: 0";
            this.lblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblUsername.Location = new System.Drawing.Point(0, 97);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(186, 16);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Click here to login!";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // UserProfilePicture
            // 
            this.UserProfilePicture.Image = global::SE_Arcade_Launcher.Properties.Resources.Untitled_11;
            this.UserProfilePicture.Location = new System.Drawing.Point(60, 22);
            this.UserProfilePicture.Name = "UserProfilePicture";
            this.UserProfilePicture.Size = new System.Drawing.Size(63, 63);
            this.UserProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserProfilePicture.TabIndex = 0;
            this.UserProfilePicture.TabStop = false;
            this.UserProfilePicture.Click += new System.EventHandler(this.UserProfilePicture_Click);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lbltitle.Location = new System.Drawing.Point(197, 23);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(155, 32);
            this.lbltitle.TabIndex = 10;
            this.lbltitle.Text = "All Games";
            // 
            // GamesPanel
            // 
            this.GamesPanel.AutoScroll = true;
            this.GamesPanel.Controls.Add(this.btnClearGames);
            this.GamesPanel.Controls.Add(this.btnScanForGames);
            this.GamesPanel.Controls.Add(this.SearchBox);
            this.GamesPanel.Controls.Add(this.btnAddGame);
            this.GamesPanel.Location = new System.Drawing.Point(186, 58);
            this.GamesPanel.Name = "GamesPanel";
            this.GamesPanel.Size = new System.Drawing.Size(1722, 1007);
            this.GamesPanel.TabIndex = 32;
            // 
            // btnClearGames
            // 
            this.btnClearGames.FlatAppearance.BorderSize = 0;
            this.btnClearGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearGames.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnClearGames.Location = new System.Drawing.Point(1355, 2);
            this.btnClearGames.Name = "btnClearGames";
            this.btnClearGames.Size = new System.Drawing.Size(113, 31);
            this.btnClearGames.TabIndex = 89;
            this.btnClearGames.Text = "Clear Games";
            this.btnClearGames.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClearGames.UseVisualStyleBackColor = true;
            this.btnClearGames.Visible = false;
            this.btnClearGames.Click += new System.EventHandler(this.btnClearGames_Click);
            // 
            // btnScanForGames
            // 
            this.btnScanForGames.FlatAppearance.BorderSize = 0;
            this.btnScanForGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanForGames.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanForGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnScanForGames.Location = new System.Drawing.Point(1471, 2);
            this.btnScanForGames.Name = "btnScanForGames";
            this.btnScanForGames.Size = new System.Drawing.Size(113, 31);
            this.btnScanForGames.TabIndex = 88;
            this.btnScanForGames.Text = "Scan For Games";
            this.btnScanForGames.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnScanForGames.UseVisualStyleBackColor = true;
            this.btnScanForGames.Visible = false;
            this.btnScanForGames.Click += new System.EventHandler(this.btnScanForGames_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.SearchBox.Location = new System.Drawing.Point(12, 8);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(292, 22);
            this.SearchBox.TabIndex = 87;
            this.SearchBox.Text = " Search for games...";
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.Enter += new System.EventHandler(this.SearchBox_Enter);
            // 
            // btnAddGame
            // 
            this.btnAddGame.FlatAppearance.BorderSize = 0;
            this.btnAddGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGame.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnAddGame.Location = new System.Drawing.Point(1587, 2);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(113, 31);
            this.btnAddGame.TabIndex = 86;
            this.btnAddGame.Text = "Add Game";
            this.btnAddGame.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddGame.UseVisualStyleBackColor = true;
            this.btnAddGame.Visible = false;
            this.btnAddGame.Click += new System.EventHandler(this.btnAddGame_Click);
            // 
            // EditGameMenu
            // 
            this.EditGameMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.EditGameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditGame,
            this.btnRemoveGame,
            this.copyIconDataToolStripMenuItem});
            this.EditGameMenu.Name = "EditGame";
            this.EditGameMenu.Size = new System.Drawing.Size(156, 70);
            // 
            // EditGame
            // 
            this.EditGame.Name = "EditGame";
            this.EditGame.Size = new System.Drawing.Size(155, 22);
            this.EditGame.Text = "Edit";
            this.EditGame.Click += new System.EventHandler(this.EditGame_Click);
            // 
            // btnRemoveGame
            // 
            this.btnRemoveGame.Name = "btnRemoveGame";
            this.btnRemoveGame.Size = new System.Drawing.Size(155, 22);
            this.btnRemoveGame.Text = "Remove";
            this.btnRemoveGame.Click += new System.EventHandler(this.btnRemoveGame_Click);
            // 
            // copyIconDataToolStripMenuItem
            // 
            this.copyIconDataToolStripMenuItem.Name = "copyIconDataToolStripMenuItem";
            this.copyIconDataToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.copyIconDataToolStripMenuItem.Text = "Copy Icon Data";
            this.copyIconDataToolStripMenuItem.Click += new System.EventHandler(this.copyIconDataToolStripMenuItem_Click);
            // 
            // HighscoresPanel
            // 
            this.HighscoresPanel.AutoScroll = true;
            this.HighscoresPanel.Location = new System.Drawing.Point(186, 58);
            this.HighscoresPanel.Name = "HighscoresPanel";
            this.HighscoresPanel.Size = new System.Drawing.Size(1722, 1007);
            this.HighscoresPanel.TabIndex = 89;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.AutoScroll = true;
            this.SettingsPanel.Controls.Add(this.lblControllerDebug);
            this.SettingsPanel.Controls.Add(this.RJoystickArea);
            this.SettingsPanel.Controls.Add(this.LJoystickArea);
            this.SettingsPanel.Controls.Add(this.lblDeadzone);
            this.SettingsPanel.Controls.Add(this.RTriggerTrackbar);
            this.SettingsPanel.Controls.Add(this.LTriggerTrackbar);
            this.SettingsPanel.Controls.Add(this.btnStartTest);
            this.SettingsPanel.Controls.Add(this.btnTestRMotor);
            this.SettingsPanel.Controls.Add(this.btnTestLMotor);
            this.SettingsPanel.Controls.Add(this.LTriggerValueLabel);
            this.SettingsPanel.Controls.Add(this.RTriggerValueLabel);
            this.SettingsPanel.Controls.Add(this.ControllerButton_RStick);
            this.SettingsPanel.Controls.Add(this.ControllerButton_LStick);
            this.SettingsPanel.Controls.Add(this.ControllerButton_L2);
            this.SettingsPanel.Controls.Add(this.ControllerButton_R2);
            this.SettingsPanel.Controls.Add(this.ControllerButton_TouchPad);
            this.SettingsPanel.Controls.Add(this.ControllerButton_Options);
            this.SettingsPanel.Controls.Add(this.ControllerButton_R1);
            this.SettingsPanel.Controls.Add(this.ControllerButton_Share);
            this.SettingsPanel.Controls.Add(this.ControllerButton_L1);
            this.SettingsPanel.Controls.Add(this.ControllerButton_Square);
            this.SettingsPanel.Controls.Add(this.ControllerButton_Triangle);
            this.SettingsPanel.Controls.Add(this.ControllerButton_Circle);
            this.SettingsPanel.Controls.Add(this.ControllerButton_X);
            this.SettingsPanel.Controls.Add(this.ControllerButton_PS);
            this.SettingsPanel.Controls.Add(this.MaxYValue);
            this.SettingsPanel.Controls.Add(this.MaxValueLabels);
            this.SettingsPanel.Controls.Add(this.MaxXValue);
            this.SettingsPanel.Controls.Add(this.RightStickValueLabel);
            this.SettingsPanel.Controls.Add(this.LeftStickValueLabel);
            this.SettingsPanel.Controls.Add(this.GameController);
            this.SettingsPanel.Controls.Add(this.ControllerInfo);
            this.SettingsPanel.Controls.Add(this.JoystickOutput);
            this.SettingsPanel.Location = new System.Drawing.Point(186, 58);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(1722, 1007);
            this.SettingsPanel.TabIndex = 90;
            // 
            // RJoystickArea
            // 
            this.RJoystickArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.RJoystickArea.Location = new System.Drawing.Point(705, 535);
            this.RJoystickArea.Name = "RJoystickArea";
            this.RJoystickArea.Size = new System.Drawing.Size(100, 100);
            this.RJoystickArea.TabIndex = 99;
            // 
            // LJoystickArea
            // 
            this.LJoystickArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.LJoystickArea.Location = new System.Drawing.Point(496, 535);
            this.LJoystickArea.Name = "LJoystickArea";
            this.LJoystickArea.Size = new System.Drawing.Size(100, 100);
            this.LJoystickArea.TabIndex = 98;
            // 
            // lblDeadzone
            // 
            this.lblDeadzone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.lblDeadzone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadzone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblDeadzone.Location = new System.Drawing.Point(1062, 18);
            this.lblDeadzone.Name = "lblDeadzone";
            this.lblDeadzone.Size = new System.Drawing.Size(101, 31);
            this.lblDeadzone.TabIndex = 97;
            this.lblDeadzone.Text = "Deadzone";
            this.lblDeadzone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RTriggerTrackbar
            // 
            this.RTriggerTrackbar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.RTriggerTrackbar.HoveredState.Parent = this.RTriggerTrackbar;
            this.RTriggerTrackbar.Location = new System.Drawing.Point(777, 9);
            this.RTriggerTrackbar.Maximum = 65535;
            this.RTriggerTrackbar.Name = "RTriggerTrackbar";
            this.RTriggerTrackbar.Size = new System.Drawing.Size(121, 23);
            this.RTriggerTrackbar.TabIndex = 96;
            this.RTriggerTrackbar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.RTriggerTrackbar.Value = 0;
            // 
            // LTriggerTrackbar
            // 
            this.LTriggerTrackbar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.LTriggerTrackbar.HoveredState.Parent = this.LTriggerTrackbar;
            this.LTriggerTrackbar.Location = new System.Drawing.Point(394, 8);
            this.LTriggerTrackbar.Maximum = 65535;
            this.LTriggerTrackbar.Name = "LTriggerTrackbar";
            this.LTriggerTrackbar.Size = new System.Drawing.Size(121, 23);
            this.LTriggerTrackbar.TabIndex = 95;
            this.LTriggerTrackbar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.LTriggerTrackbar.Value = 0;
            // 
            // btnStartTest
            // 
            this.btnStartTest.FlatAppearance.BorderSize = 0;
            this.btnStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTest.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStartTest.Location = new System.Drawing.Point(594, 426);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(113, 31);
            this.btnStartTest.TabIndex = 94;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnTestRMotor
            // 
            this.btnTestRMotor.FlatAppearance.BorderSize = 0;
            this.btnTestRMotor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestRMotor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestRMotor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnTestRMotor.Location = new System.Drawing.Point(844, 468);
            this.btnTestRMotor.Name = "btnTestRMotor";
            this.btnTestRMotor.Size = new System.Drawing.Size(122, 31);
            this.btnTestRMotor.TabIndex = 93;
            this.btnTestRMotor.Text = "Test Right Motor";
            this.btnTestRMotor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTestRMotor.UseVisualStyleBackColor = true;
            // 
            // btnTestLMotor
            // 
            this.btnTestLMotor.FlatAppearance.BorderSize = 0;
            this.btnTestLMotor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestLMotor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestLMotor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnTestLMotor.Location = new System.Drawing.Point(347, 468);
            this.btnTestLMotor.Name = "btnTestLMotor";
            this.btnTestLMotor.Size = new System.Drawing.Size(122, 31);
            this.btnTestLMotor.TabIndex = 92;
            this.btnTestLMotor.Text = "Test Left Motor";
            this.btnTestLMotor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTestLMotor.UseVisualStyleBackColor = true;
            // 
            // LTriggerValueLabel
            // 
            this.LTriggerValueLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.LTriggerValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTriggerValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.LTriggerValueLabel.Location = new System.Drawing.Point(501, 37);
            this.LTriggerValueLabel.Name = "LTriggerValueLabel";
            this.LTriggerValueLabel.Size = new System.Drawing.Size(53, 31);
            this.LTriggerValueLabel.TabIndex = 30;
            this.LTriggerValueLabel.Text = "0";
            this.LTriggerValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RTriggerValueLabel
            // 
            this.RTriggerValueLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.RTriggerValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTriggerValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.RTriggerValueLabel.Location = new System.Drawing.Point(733, 40);
            this.RTriggerValueLabel.Name = "RTriggerValueLabel";
            this.RTriggerValueLabel.Size = new System.Drawing.Size(58, 31);
            this.RTriggerValueLabel.TabIndex = 29;
            this.RTriggerValueLabel.Text = "0";
            this.RTriggerValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControllerButton_RStick
            // 
            this.ControllerButton_RStick.Image = global::SE_Arcade_Launcher.Properties.Resources.RStick;
            this.ControllerButton_RStick.Location = new System.Drawing.Point(692, 218);
            this.ControllerButton_RStick.Name = "ControllerButton_RStick";
            this.ControllerButton_RStick.Size = new System.Drawing.Size(115, 100);
            this.ControllerButton_RStick.TabIndex = 28;
            this.ControllerButton_RStick.TabStop = false;
            this.ControllerButton_RStick.Visible = false;
            // 
            // ControllerButton_LStick
            // 
            this.ControllerButton_LStick.Image = global::SE_Arcade_Launcher.Properties.Resources.LStick;
            this.ControllerButton_LStick.Location = new System.Drawing.Point(491, 221);
            this.ControllerButton_LStick.Name = "ControllerButton_LStick";
            this.ControllerButton_LStick.Size = new System.Drawing.Size(108, 96);
            this.ControllerButton_LStick.TabIndex = 27;
            this.ControllerButton_LStick.TabStop = false;
            this.ControllerButton_LStick.Visible = false;
            // 
            // ControllerButton_L2
            // 
            this.ControllerButton_L2.Image = global::SE_Arcade_Launcher.Properties.Resources.L2;
            this.ControllerButton_L2.Location = new System.Drawing.Point(411, 37);
            this.ControllerButton_L2.Name = "ControllerButton_L2";
            this.ControllerButton_L2.Size = new System.Drawing.Size(88, 33);
            this.ControllerButton_L2.TabIndex = 26;
            this.ControllerButton_L2.TabStop = false;
            this.ControllerButton_L2.Visible = false;
            // 
            // ControllerButton_R2
            // 
            this.ControllerButton_R2.Image = global::SE_Arcade_Launcher.Properties.Resources.R2;
            this.ControllerButton_R2.Location = new System.Drawing.Point(793, 39);
            this.ControllerButton_R2.Name = "ControllerButton_R2";
            this.ControllerButton_R2.Size = new System.Drawing.Size(92, 32);
            this.ControllerButton_R2.TabIndex = 25;
            this.ControllerButton_R2.TabStop = false;
            this.ControllerButton_R2.Visible = false;
            // 
            // ControllerButton_TouchPad
            // 
            this.ControllerButton_TouchPad.Image = global::SE_Arcade_Launcher.Properties.Resources.TouchPad;
            this.ControllerButton_TouchPad.Location = new System.Drawing.Point(539, 82);
            this.ControllerButton_TouchPad.Name = "ControllerButton_TouchPad";
            this.ControllerButton_TouchPad.Size = new System.Drawing.Size(219, 127);
            this.ControllerButton_TouchPad.TabIndex = 24;
            this.ControllerButton_TouchPad.TabStop = false;
            this.ControllerButton_TouchPad.Visible = false;
            // 
            // ControllerButton_Options
            // 
            this.ControllerButton_Options.Image = global::SE_Arcade_Launcher.Properties.Resources.Options;
            this.ControllerButton_Options.Location = new System.Drawing.Point(752, 88);
            this.ControllerButton_Options.Name = "ControllerButton_Options";
            this.ControllerButton_Options.Size = new System.Drawing.Size(53, 59);
            this.ControllerButton_Options.TabIndex = 20;
            this.ControllerButton_Options.TabStop = false;
            this.ControllerButton_Options.Visible = false;
            // 
            // ControllerButton_R1
            // 
            this.ControllerButton_R1.Image = global::SE_Arcade_Launcher.Properties.Resources.R1;
            this.ControllerButton_R1.Location = new System.Drawing.Point(793, 69);
            this.ControllerButton_R1.Name = "ControllerButton_R1";
            this.ControllerButton_R1.Size = new System.Drawing.Size(94, 23);
            this.ControllerButton_R1.TabIndex = 23;
            this.ControllerButton_R1.TabStop = false;
            this.ControllerButton_R1.Visible = false;
            // 
            // ControllerButton_Share
            // 
            this.ControllerButton_Share.Image = global::SE_Arcade_Launcher.Properties.Resources.Share;
            this.ControllerButton_Share.Location = new System.Drawing.Point(496, 87);
            this.ControllerButton_Share.Name = "ControllerButton_Share";
            this.ControllerButton_Share.Size = new System.Drawing.Size(48, 55);
            this.ControllerButton_Share.TabIndex = 21;
            this.ControllerButton_Share.TabStop = false;
            this.ControllerButton_Share.Visible = false;
            // 
            // ControllerButton_L1
            // 
            this.ControllerButton_L1.Image = global::SE_Arcade_Launcher.Properties.Resources.L1;
            this.ControllerButton_L1.Location = new System.Drawing.Point(405, 69);
            this.ControllerButton_L1.Name = "ControllerButton_L1";
            this.ControllerButton_L1.Size = new System.Drawing.Size(93, 21);
            this.ControllerButton_L1.TabIndex = 22;
            this.ControllerButton_L1.TabStop = false;
            this.ControllerButton_L1.Visible = false;
            // 
            // ControllerButton_Square
            // 
            this.ControllerButton_Square.Image = global::SE_Arcade_Launcher.Properties.Resources.Square;
            this.ControllerButton_Square.Location = new System.Drawing.Point(777, 159);
            this.ControllerButton_Square.Name = "ControllerButton_Square";
            this.ControllerButton_Square.Size = new System.Drawing.Size(48, 45);
            this.ControllerButton_Square.TabIndex = 19;
            this.ControllerButton_Square.TabStop = false;
            this.ControllerButton_Square.Visible = false;
            // 
            // ControllerButton_Triangle
            // 
            this.ControllerButton_Triangle.Image = global::SE_Arcade_Launcher.Properties.Resources.Triangle;
            this.ControllerButton_Triangle.Location = new System.Drawing.Point(826, 115);
            this.ControllerButton_Triangle.Name = "ControllerButton_Triangle";
            this.ControllerButton_Triangle.Size = new System.Drawing.Size(42, 41);
            this.ControllerButton_Triangle.TabIndex = 18;
            this.ControllerButton_Triangle.TabStop = false;
            this.ControllerButton_Triangle.Visible = false;
            // 
            // ControllerButton_Circle
            // 
            this.ControllerButton_Circle.Image = global::SE_Arcade_Launcher.Properties.Resources.Circle;
            this.ControllerButton_Circle.Location = new System.Drawing.Point(870, 158);
            this.ControllerButton_Circle.Name = "ControllerButton_Circle";
            this.ControllerButton_Circle.Size = new System.Drawing.Size(46, 46);
            this.ControllerButton_Circle.TabIndex = 17;
            this.ControllerButton_Circle.TabStop = false;
            this.ControllerButton_Circle.Visible = false;
            // 
            // ControllerButton_X
            // 
            this.ControllerButton_X.Image = global::SE_Arcade_Launcher.Properties.Resources.X;
            this.ControllerButton_X.Location = new System.Drawing.Point(823, 206);
            this.ControllerButton_X.Name = "ControllerButton_X";
            this.ControllerButton_X.Size = new System.Drawing.Size(47, 43);
            this.ControllerButton_X.TabIndex = 16;
            this.ControllerButton_X.TabStop = false;
            this.ControllerButton_X.Visible = false;
            // 
            // ControllerButton_PS
            // 
            this.ControllerButton_PS.Image = global::SE_Arcade_Launcher.Properties.Resources.PS;
            this.ControllerButton_PS.Location = new System.Drawing.Point(628, 252);
            this.ControllerButton_PS.Name = "ControllerButton_PS";
            this.ControllerButton_PS.Size = new System.Drawing.Size(40, 40);
            this.ControllerButton_PS.TabIndex = 15;
            this.ControllerButton_PS.TabStop = false;
            this.ControllerButton_PS.Visible = false;
            // 
            // MaxYValue
            // 
            this.MaxYValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.MaxYValue.HoveredState.Parent = this.MaxYValue;
            this.MaxYValue.Location = new System.Drawing.Point(1114, 87);
            this.MaxYValue.Maximum = 65535;
            this.MaxYValue.Name = "MaxYValue";
            this.MaxYValue.Size = new System.Drawing.Size(23, 416);
            this.MaxYValue.TabIndex = 14;
            this.MaxYValue.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.MaxYValue.Value = 65535;
            // 
            // MaxValueLabels
            // 
            this.MaxValueLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.MaxValueLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxValueLabels.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.MaxValueLabels.Location = new System.Drawing.Point(1037, 54);
            this.MaxValueLabels.Name = "MaxValueLabels";
            this.MaxValueLabels.Size = new System.Drawing.Size(158, 31);
            this.MaxValueLabels.TabIndex = 13;
            this.MaxValueLabels.Text = "X: 65535      Y: 65535";
            this.MaxValueLabels.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxXValue
            // 
            this.MaxXValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.MaxXValue.HoveredState.Parent = this.MaxXValue;
            this.MaxXValue.Location = new System.Drawing.Point(1085, 87);
            this.MaxXValue.Maximum = 65535;
            this.MaxXValue.Name = "MaxXValue";
            this.MaxXValue.Size = new System.Drawing.Size(23, 416);
            this.MaxXValue.TabIndex = 12;
            this.MaxXValue.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.MaxXValue.Value = 65535;
            // 
            // RightStickValueLabel
            // 
            this.RightStickValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightStickValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.RightStickValueLabel.Location = new System.Drawing.Point(710, 341);
            this.RightStickValueLabel.Name = "RightStickValueLabel";
            this.RightStickValueLabel.Size = new System.Drawing.Size(84, 51);
            this.RightStickValueLabel.TabIndex = 11;
            this.RightStickValueLabel.Text = "X: 65535\r\nY: 65535";
            this.RightStickValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeftStickValueLabel
            // 
            this.LeftStickValueLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.LeftStickValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftStickValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.LeftStickValueLabel.Location = new System.Drawing.Point(502, 341);
            this.LeftStickValueLabel.Name = "LeftStickValueLabel";
            this.LeftStickValueLabel.Size = new System.Drawing.Size(84, 51);
            this.LeftStickValueLabel.TabIndex = 10;
            this.LeftStickValueLabel.Text = "X: 65535\r\nY: 65535";
            this.LeftStickValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameController
            // 
            this.GameController.Image = global::SE_Arcade_Launcher.Properties.Resources.Dualshock_4_Layout;
            this.GameController.Location = new System.Drawing.Point(300, 34);
            this.GameController.Name = "GameController";
            this.GameController.Size = new System.Drawing.Size(695, 469);
            this.GameController.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameController.TabIndex = 8;
            this.GameController.TabStop = false;
            // 
            // ControllerInfo
            // 
            this.ControllerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.ControllerInfo.Location = new System.Drawing.Point(9, 8);
            this.ControllerInfo.Name = "ControllerInfo";
            this.ControllerInfo.Size = new System.Drawing.Size(285, 51);
            this.ControllerInfo.TabIndex = 5;
            this.ControllerInfo.Text = "ControllerInfo";
            this.ControllerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JoystickOutput
            // 
            this.JoystickOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.JoystickOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.JoystickOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoystickOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.JoystickOutput.Location = new System.Drawing.Point(9, 59);
            this.JoystickOutput.Name = "JoystickOutput";
            this.JoystickOutput.Size = new System.Drawing.Size(285, 435);
            this.JoystickOutput.TabIndex = 4;
            this.JoystickOutput.Text = "";
            // 
            // joystickTimer
            // 
            this.joystickTimer.Enabled = true;
            this.joystickTimer.Tick += new System.EventHandler(this.joystickTimer_Tick);
            // 
            // PerformancePanel
            // 
            this.PerformancePanel.AutoScroll = true;
            this.PerformancePanel.Controls.Add(this.CPUChart);
            this.PerformancePanel.Controls.Add(this.RAMChart);
            this.PerformancePanel.Location = new System.Drawing.Point(186, 58);
            this.PerformancePanel.Name = "PerformancePanel";
            this.PerformancePanel.Size = new System.Drawing.Size(1722, 1007);
            this.PerformancePanel.TabIndex = 90;
            // 
            // CPUChart
            // 
            this.CPUChart.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.CPUChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.CPUChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.CPUChart.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.CPUChart.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.CPUChart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.CPUChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameTitle1;
            chartArea3.Name = "ChartArea1";
            this.CPUChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.CPUChart.Legends.Add(legend3);
            this.CPUChart.Location = new System.Drawing.Point(9, 8);
            this.CPUChart.Name = "CPUChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "CPU";
            this.CPUChart.Series.Add(series3);
            this.CPUChart.Size = new System.Drawing.Size(452, 284);
            this.CPUChart.TabIndex = 1;
            this.CPUChart.Text = "chart1";
            // 
            // RAMChart
            // 
            this.RAMChart.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.RAMChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.RAMChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.RAMChart.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.RAMChart.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.RAMChart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.RAMChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameTitle1;
            chartArea4.Name = "ChartArea1";
            this.RAMChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.RAMChart.Legends.Add(legend4);
            this.RAMChart.Location = new System.Drawing.Point(467, 8);
            this.RAMChart.Name = "RAMChart";
            this.RAMChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "RAM";
            this.RAMChart.Series.Add(series4);
            this.RAMChart.Size = new System.Drawing.Size(452, 284);
            this.RAMChart.TabIndex = 0;
            this.RAMChart.Text = "chart1";
            // 
            // PerformanceTimer
            // 
            this.PerformanceTimer.Interval = 1;
            this.PerformanceTimer.Tick += new System.EventHandler(this.PerformanceTimer_Tick);
            // 
            // CreditsPanel
            // 
            this.CreditsPanel.AutoScroll = true;
            this.CreditsPanel.Controls.Add(this.lblCreditsAIΩN);
            this.CreditsPanel.Controls.Add(this.picCreditsAIΩN);
            this.CreditsPanel.Controls.Add(this.lblCreditsBulldog);
            this.CreditsPanel.Controls.Add(this.picCreditsBulldog);
            this.CreditsPanel.Controls.Add(this.lblCreditsPsyke);
            this.CreditsPanel.Controls.Add(this.picCreditsPsyke);
            this.CreditsPanel.Controls.Add(this.lblCreditsFriendlyFrank);
            this.CreditsPanel.Controls.Add(this.picCreditsFriendlyFrank);
            this.CreditsPanel.Controls.Add(this.lblCreditsZebratic);
            this.CreditsPanel.Controls.Add(this.picCreditsZebratic);
            this.CreditsPanel.Controls.Add(this.lblCreditsTitle);
            this.CreditsPanel.Location = new System.Drawing.Point(186, 58);
            this.CreditsPanel.Name = "CreditsPanel";
            this.CreditsPanel.Size = new System.Drawing.Size(1722, 1007);
            this.CreditsPanel.TabIndex = 90;
            // 
            // lblCreditsAIΩN
            // 
            this.lblCreditsAIΩN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblCreditsAIΩN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsAIΩN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblCreditsAIΩN.Location = new System.Drawing.Point(1159, 499);
            this.lblCreditsAIΩN.Name = "lblCreditsAIΩN";
            this.lblCreditsAIΩN.Size = new System.Drawing.Size(151, 16);
            this.lblCreditsAIΩN.TabIndex = 21;
            this.lblCreditsAIΩN.Text = "AIΩN";
            this.lblCreditsAIΩN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCreditsAIΩN
            // 
            this.picCreditsAIΩN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCreditsAIΩN.Image = global::SE_Arcade_Launcher.Properties.Resources.AIΩN;
            this.picCreditsAIΩN.Location = new System.Drawing.Point(1159, 347);
            this.picCreditsAIΩN.Name = "picCreditsAIΩN";
            this.picCreditsAIΩN.Size = new System.Drawing.Size(151, 150);
            this.picCreditsAIΩN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCreditsAIΩN.TabIndex = 20;
            this.picCreditsAIΩN.TabStop = false;
            // 
            // lblCreditsBulldog
            // 
            this.lblCreditsBulldog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblCreditsBulldog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsBulldog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblCreditsBulldog.Location = new System.Drawing.Point(972, 499);
            this.lblCreditsBulldog.Name = "lblCreditsBulldog";
            this.lblCreditsBulldog.Size = new System.Drawing.Size(151, 16);
            this.lblCreditsBulldog.TabIndex = 19;
            this.lblCreditsBulldog.Text = "Bulldog";
            this.lblCreditsBulldog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCreditsBulldog
            // 
            this.picCreditsBulldog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCreditsBulldog.Image = global::SE_Arcade_Launcher.Properties.Resources.Bulldog;
            this.picCreditsBulldog.Location = new System.Drawing.Point(972, 347);
            this.picCreditsBulldog.Name = "picCreditsBulldog";
            this.picCreditsBulldog.Size = new System.Drawing.Size(151, 150);
            this.picCreditsBulldog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCreditsBulldog.TabIndex = 18;
            this.picCreditsBulldog.TabStop = false;
            // 
            // lblCreditsPsyke
            // 
            this.lblCreditsPsyke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblCreditsPsyke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsPsyke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblCreditsPsyke.Location = new System.Drawing.Point(785, 499);
            this.lblCreditsPsyke.Name = "lblCreditsPsyke";
            this.lblCreditsPsyke.Size = new System.Drawing.Size(151, 16);
            this.lblCreditsPsyke.TabIndex = 17;
            this.lblCreditsPsyke.Text = "Psyke";
            this.lblCreditsPsyke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCreditsPsyke
            // 
            this.picCreditsPsyke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCreditsPsyke.Image = global::SE_Arcade_Launcher.Properties.Resources.Psyke;
            this.picCreditsPsyke.Location = new System.Drawing.Point(785, 347);
            this.picCreditsPsyke.Name = "picCreditsPsyke";
            this.picCreditsPsyke.Size = new System.Drawing.Size(151, 150);
            this.picCreditsPsyke.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCreditsPsyke.TabIndex = 16;
            this.picCreditsPsyke.TabStop = false;
            // 
            // lblCreditsFriendlyFrank
            // 
            this.lblCreditsFriendlyFrank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblCreditsFriendlyFrank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsFriendlyFrank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblCreditsFriendlyFrank.Location = new System.Drawing.Point(598, 499);
            this.lblCreditsFriendlyFrank.Name = "lblCreditsFriendlyFrank";
            this.lblCreditsFriendlyFrank.Size = new System.Drawing.Size(151, 16);
            this.lblCreditsFriendlyFrank.TabIndex = 15;
            this.lblCreditsFriendlyFrank.Text = "Friendly Frank";
            this.lblCreditsFriendlyFrank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCreditsFriendlyFrank
            // 
            this.picCreditsFriendlyFrank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCreditsFriendlyFrank.Image = global::SE_Arcade_Launcher.Properties.Resources.FriendlyFrank;
            this.picCreditsFriendlyFrank.Location = new System.Drawing.Point(598, 347);
            this.picCreditsFriendlyFrank.Name = "picCreditsFriendlyFrank";
            this.picCreditsFriendlyFrank.Size = new System.Drawing.Size(151, 150);
            this.picCreditsFriendlyFrank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCreditsFriendlyFrank.TabIndex = 14;
            this.picCreditsFriendlyFrank.TabStop = false;
            // 
            // lblCreditsZebratic
            // 
            this.lblCreditsZebratic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblCreditsZebratic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsZebratic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblCreditsZebratic.Location = new System.Drawing.Point(412, 499);
            this.lblCreditsZebratic.Name = "lblCreditsZebratic";
            this.lblCreditsZebratic.Size = new System.Drawing.Size(150, 16);
            this.lblCreditsZebratic.TabIndex = 13;
            this.lblCreditsZebratic.Text = "Zebratic";
            this.lblCreditsZebratic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCreditsZebratic
            // 
            this.picCreditsZebratic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCreditsZebratic.Image = global::SE_Arcade_Launcher.Properties.Resources.Zebratic;
            this.picCreditsZebratic.Location = new System.Drawing.Point(412, 347);
            this.picCreditsZebratic.Name = "picCreditsZebratic";
            this.picCreditsZebratic.Size = new System.Drawing.Size(150, 150);
            this.picCreditsZebratic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCreditsZebratic.TabIndex = 12;
            this.picCreditsZebratic.TabStop = false;
            // 
            // lblCreditsTitle
            // 
            this.lblCreditsTitle.AutoSize = true;
            this.lblCreditsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblCreditsTitle.Location = new System.Drawing.Point(740, 17);
            this.lblCreditsTitle.Name = "lblCreditsTitle";
            this.lblCreditsTitle.Size = new System.Drawing.Size(242, 73);
            this.lblCreditsTitle.TabIndex = 11;
            this.lblCreditsTitle.Text = "Credits";
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnExit.Location = new System.Drawing.Point(1877, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 29);
            this.btnExit.TabIndex = 90;
            this.btnExit.Text = "X";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LockdownTimer
            // 
            this.LockdownTimer.Enabled = true;
            this.LockdownTimer.Tick += new System.EventHandler(this.LockdownTimer_Tick);
            // 
            // lblControllerDebug
            // 
            this.lblControllerDebug.AutoSize = true;
            this.lblControllerDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControllerDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblControllerDebug.Location = new System.Drawing.Point(1284, 37);
            this.lblControllerDebug.Name = "lblControllerDebug";
            this.lblControllerDebug.Size = new System.Drawing.Size(61, 16);
            this.lblControllerDebug.TabIndex = 100;
            this.lblControllerDebug.Text = "DEBUG";
            this.lblControllerDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.PerformancePanel);
            this.Controls.Add(this.CreditsPanel);
            this.Controls.Add(this.HighscoresPanel);
            this.Controls.Add(this.GamesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   ";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainMenu_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePicture)).EndInit();
            this.GamesPanel.ResumeLayout(false);
            this.GamesPanel.PerformLayout();
            this.EditGameMenu.ResumeLayout(false);
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_RStick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_LStick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_R2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_TouchPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_R1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Share)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_L1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Square)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Triangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_Circle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerButton_PS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameController)).EndInit();
            this.PerformancePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CPUChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMChart)).EndInit();
            this.CreditsPanel.ResumeLayout(false);
            this.CreditsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsAIΩN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsBulldog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsPsyke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsFriendlyFrank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCreditsZebratic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox UserProfilePicture;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnContactUs;
        private System.Windows.Forms.Button btnCalender;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Button btnHighscores;
        private System.Windows.Forms.Panel GamesPanel;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.ContextMenuStrip EditGameMenu;
        private System.Windows.Forms.ToolStripMenuItem EditGame;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveGame;
        private System.Windows.Forms.Button btnScanForGames;
        private System.Windows.Forms.Panel HighscoresPanel;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.RichTextBox JoystickOutput;
        private System.Windows.Forms.Timer joystickTimer;
        private System.Windows.Forms.Label ControllerInfo;
        private System.Windows.Forms.PictureBox GameController;
        private System.Windows.Forms.Label LeftStickValueLabel;
        private System.Windows.Forms.Label RightStickValueLabel;
        private Siticone.UI.WinForms.SiticoneVTrackBar MaxXValue;
        private System.Windows.Forms.Label MaxValueLabels;
        private Siticone.UI.WinForms.SiticoneVTrackBar MaxYValue;
        private System.Windows.Forms.PictureBox ControllerButton_PS;
        private System.Windows.Forms.PictureBox ControllerButton_X;
        private System.Windows.Forms.PictureBox ControllerButton_Circle;
        private System.Windows.Forms.PictureBox ControllerButton_Triangle;
        private System.Windows.Forms.PictureBox ControllerButton_Square;
        private System.Windows.Forms.PictureBox ControllerButton_Options;
        private System.Windows.Forms.PictureBox ControllerButton_Share;
        private System.Windows.Forms.PictureBox ControllerButton_L1;
        private System.Windows.Forms.PictureBox ControllerButton_R1;
        private System.Windows.Forms.PictureBox ControllerButton_TouchPad;
        private System.Windows.Forms.PictureBox ControllerButton_R2;
        private System.Windows.Forms.PictureBox ControllerButton_L2;
        private System.Windows.Forms.PictureBox ControllerButton_LStick;
        private System.Windows.Forms.PictureBox ControllerButton_RStick;
        private System.Windows.Forms.Label LTriggerValueLabel;
        private System.Windows.Forms.Label RTriggerValueLabel;
        private System.Windows.Forms.Button btnClearGames;
        private System.Windows.Forms.ToolStripMenuItem copyIconDataToolStripMenuItem;
        private System.Windows.Forms.Button btnTestLMotor;
        private System.Windows.Forms.Button btnTestRMotor;
        private System.Windows.Forms.Button btnPerformance;
        private System.Windows.Forms.Panel PerformancePanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart RAMChart;
        private System.Windows.Forms.Timer PerformanceTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart CPUChart;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnCredits;
        private System.Windows.Forms.Panel CreditsPanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblCreditsTitle;
        private System.Windows.Forms.PictureBox picCreditsZebratic;
        private System.Windows.Forms.Label lblCreditsZebratic;
        private System.Windows.Forms.Label lblCreditsFriendlyFrank;
        private System.Windows.Forms.PictureBox picCreditsFriendlyFrank;
        private System.Windows.Forms.Label lblCreditsPsyke;
        private System.Windows.Forms.PictureBox picCreditsPsyke;
        private System.Windows.Forms.Label lblCreditsBulldog;
        private System.Windows.Forms.PictureBox picCreditsBulldog;
        private System.Windows.Forms.Label lblCreditsAIΩN;
        private System.Windows.Forms.PictureBox picCreditsAIΩN;
        private System.Windows.Forms.Timer LockdownTimer;
        private Siticone.UI.WinForms.SiticoneTrackBar RTriggerTrackbar;
        private Siticone.UI.WinForms.SiticoneTrackBar LTriggerTrackbar;
        private System.Windows.Forms.Label lblDeadzone;
        private System.Windows.Forms.Panel LJoystickArea;
        private System.Windows.Forms.Panel RJoystickArea;
        private System.Windows.Forms.Label lblControllerDebug;
    }
}

