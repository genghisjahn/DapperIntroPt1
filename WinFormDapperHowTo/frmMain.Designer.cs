namespace WinFormDapperHowTo
{
    partial class frmMain
    {
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
            this.listboxTeams = new System.Windows.Forms.ListBox();
            this.cmTeam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gboxTeams = new System.Windows.Forms.GroupBox();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.ttTeam = new System.Windows.Forms.ToolTip(this.components);
            this.gboxPlayers = new System.Windows.Forms.GroupBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.listboxPlayers = new System.Windows.Forms.ListBox();
            this.cmPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeletePlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.cboTeams = new System.Windows.Forms.ComboBox();
            this.cmTeam.SuspendLayout();
            this.gboxTeams.SuspendLayout();
            this.gboxPlayers.SuspendLayout();
            this.cmPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxTeams
            // 
            this.listboxTeams.ContextMenuStrip = this.cmTeam;
            this.listboxTeams.FormattingEnabled = true;
            this.listboxTeams.Location = new System.Drawing.Point(19, 44);
            this.listboxTeams.Name = "listboxTeams";
            this.listboxTeams.Size = new System.Drawing.Size(210, 108);
            this.listboxTeams.TabIndex = 0;
            this.ttTeam.SetToolTip(this.listboxTeams, "Double-click to change a team name.");
            this.listboxTeams.SelectedIndexChanged += new System.EventHandler(this.listboxTeams_SelectedIndexChanged);
            this.listboxTeams.DoubleClick += new System.EventHandler(this.listboxTeams_DoubleClick);
            // 
            // cmTeam
            // 
            this.cmTeam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDelete});
            this.cmTeam.Name = "cmMain";
            this.cmTeam.Size = new System.Drawing.Size(125, 26);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(124, 22);
            this.menuItemDelete.Text = "Delete {0}";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // gboxTeams
            // 
            this.gboxTeams.Controls.Add(this.btnAddTeam);
            this.gboxTeams.Controls.Add(this.listboxTeams);
            this.gboxTeams.Location = new System.Drawing.Point(12, 12);
            this.gboxTeams.Name = "gboxTeams";
            this.gboxTeams.Size = new System.Drawing.Size(242, 198);
            this.gboxTeams.TabIndex = 1;
            this.gboxTeams.TabStop = false;
            this.gboxTeams.Text = "Teams";
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Location = new System.Drawing.Point(19, 158);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(75, 23);
            this.btnAddTeam.TabIndex = 1;
            this.btnAddTeam.Text = "Add &Team";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // gboxPlayers
            // 
            this.gboxPlayers.Controls.Add(this.cboTeams);
            this.gboxPlayers.Controls.Add(this.btnAddPlayer);
            this.gboxPlayers.Controls.Add(this.listboxPlayers);
            this.gboxPlayers.Enabled = false;
            this.gboxPlayers.Location = new System.Drawing.Point(280, 12);
            this.gboxPlayers.Name = "gboxPlayers";
            this.gboxPlayers.Size = new System.Drawing.Size(242, 198);
            this.gboxPlayers.TabIndex = 3;
            this.gboxPlayers.TabStop = false;
            this.gboxPlayers.Text = "Players";
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(18, 158);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 2;
            this.btnAddPlayer.Text = "Add &Player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // listboxPlayers
            // 
            this.listboxPlayers.ContextMenuStrip = this.cmPlayer;
            this.listboxPlayers.FormattingEnabled = true;
            this.listboxPlayers.Location = new System.Drawing.Point(18, 44);
            this.listboxPlayers.Name = "listboxPlayers";
            this.listboxPlayers.Size = new System.Drawing.Size(210, 108);
            this.listboxPlayers.TabIndex = 0;
            this.ttTeam.SetToolTip(this.listboxPlayers, "Double Click to update player name.");
            this.listboxPlayers.SelectedIndexChanged += new System.EventHandler(this.listboxPlayers_SelectedIndexChanged);
            this.listboxPlayers.DoubleClick += new System.EventHandler(this.listboxPlayers_DoubleClick);
            // 
            // cmPlayer
            // 
            this.cmPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeletePlayer});
            this.cmPlayer.Name = "cmPlayer";
            this.cmPlayer.Size = new System.Drawing.Size(125, 26);
            // 
            // menuDeletePlayer
            // 
            this.menuDeletePlayer.Name = "menuDeletePlayer";
            this.menuDeletePlayer.Size = new System.Drawing.Size(124, 22);
            this.menuDeletePlayer.Text = "Delete {0}";
            this.menuDeletePlayer.Click += new System.EventHandler(this.menuDeletePlayer_Click);
            // 
            // cboTeams
            // 
            this.cboTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeams.FormattingEnabled = true;
            this.cboTeams.Location = new System.Drawing.Point(18, 20);
            this.cboTeams.Name = "cboTeams";
            this.cboTeams.Size = new System.Drawing.Size(210, 21);
            this.cboTeams.TabIndex = 3;
            this.cboTeams.SelectedIndexChanged += new System.EventHandler(this.cboTeams_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 235);
            this.Controls.Add(this.gboxPlayers);
            this.Controls.Add(this.gboxTeams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dapper How To";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.cmTeam.ResumeLayout(false);
            this.gboxTeams.ResumeLayout(false);
            this.gboxPlayers.ResumeLayout(false);
            this.cmPlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxTeams;
        private System.Windows.Forms.GroupBox gboxTeams;
        private System.Windows.Forms.ToolTip ttTeam;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.ContextMenuStrip cmTeam;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.GroupBox gboxPlayers;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.ListBox listboxPlayers;
        private System.Windows.Forms.ContextMenuStrip cmPlayer;
        private System.Windows.Forms.ToolStripMenuItem menuDeletePlayer;
        private System.Windows.Forms.ComboBox cboTeams;
    }
}

