using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DapperHowToData;
using DapperHowToData.POCOs;
namespace WinFormDapperHowTo
{
    public partial class frmMain : Form
    {
        private const string STR_Delete = @"Delete {0}";
        private bool loadingteams;

        #region "Form Methods"
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadTeams();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DapperHowToData.DBCleanUpHack.CopyDBBackToSourceCodeLocation();
        }
        #endregion

        #region "Team Controls"
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            frmNewItem frmNew = new frmNewItem(frmNewItem.eItemType.Team, frmNewItem.eActionType.Insert);
            frmNew.ShowDialog();
            if (frmNew.DialogResult == DialogResult.OK)
            {
                DapperMethods.AddTeam(frmNew.ItemText);
                LoadTeams();
            }

        }
        private void listboxTeams_DoubleClick(object sender, EventArgs e)
        {
            if (listboxTeams.SelectedIndex >= 0)
            {
                Team team = (Team)listboxTeams.SelectedItem;
                frmNewItem frmNew = new frmNewItem(frmNewItem.eItemType.Team, frmNewItem.eActionType.Update, team.ToString());
                frmNew.ShowDialog();
                if (frmNew.DialogResult == DialogResult.OK)
                {
                    DapperMethods.UpdateTeam(team.TeamID, frmNew.ItemText);
                    LoadTeams();
                }
            }
        }
        private void listboxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listboxTeams.SelectedIndex >= 0)
            {
                loadingteams = true;
                Team team = (Team)listboxTeams.SelectedItem;
                cboTeams.SelectedItem = team;
                this.menuItemDelete.Text = string.Format(STR_Delete, team.TeamName);
                LoadPlayers(team);
                loadingteams = false;
            }

        }
        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (this.listboxTeams.SelectedIndex >= 0)
            {
                Team team = (Team)listboxTeams.SelectedItem;
                DialogResult dresult = MessageBox.Show(string.Format("Are you sure you want to delete the {0}?", team.TeamName.ToUpper()), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dresult == DialogResult.Yes)
                {
                    DapperMethods.DeleteTeam(team.TeamID);
                    LoadTeams();
                    listboxPlayers.Items.Clear();
                }

            }
        }
        #endregion
           
        #region "Player Controls"
        private void cboTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingteams)
            {
                string msg = @"Are you sure you want to move {0} from the {1} to the {2}?";

                Team newteam = (Team)cboTeams.SelectedItem;
                Team oldteam = (Team)listboxTeams.SelectedItem;
                Player player = (Player)listboxPlayers.SelectedItem;
                DialogResult dresult = MessageBox.Show(string.Format(msg, player.PlayerName.ToUpper(), oldteam.TeamName.ToUpper(), newteam.TeamName.ToUpper()), "Confirm Team Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dresult == DialogResult.Yes)
                {
                    DapperMethods.UpdatePlayerTeam(player.PlayerID, newteam.TeamID);
                    LoadPlayers(oldteam);
                }

                loadingteams = true;
                cboTeams.SelectedItem = oldteam;
                loadingteams = false;

            }
        }
        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Team team = (Team)listboxTeams.SelectedItem;
            if (team != null)
            {
                frmNewItem frmNew = new frmNewItem(frmNewItem.eItemType.Player, frmNewItem.eActionType.Insert);
                frmNew.ShowDialog();
                if (frmNew.DialogResult == DialogResult.OK)
                {
                    DapperMethods.AddPlayer(teamID: team.TeamID, playername: frmNew.ItemText);
                    LoadPlayers(team);
                }
            }
        }
        private void listboxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listboxPlayers.SelectedIndex >= 0)
            {
                Player player = (Player)listboxPlayers.SelectedItem;
                this.menuDeletePlayer.Text = string.Format(STR_Delete, player.PlayerName);
            }
        }
        private void listboxPlayers_DoubleClick(object sender, EventArgs e)
        {
            if (listboxPlayers.SelectedIndex >= 0)
            {
                Player player = (Player)listboxPlayers.SelectedItem;
                frmNewItem frmNew = new frmNewItem(frmNewItem.eItemType.Player, frmNewItem.eActionType.Update, player.PlayerName);
                frmNew.ShowDialog();
                if (frmNew.DialogResult == DialogResult.OK)
                {
                    DapperMethods.UpdatePlayerName(player.PlayerID, frmNew.ItemText);
                    LoadPlayers((Team)listboxTeams.SelectedItem);
                }
            }
        }
        private void menuDeletePlayer_Click(object sender, EventArgs e)
        {
            if (this.listboxPlayers.SelectedIndex >= 0)
            {

                Player player = (Player)listboxPlayers.SelectedItem;
                DialogResult dresult = MessageBox.Show(string.Format("Are you sure you want to delete {0}?", player.PlayerName.ToUpper()), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dresult == DialogResult.Yes)
                {
                    DapperMethods.DeletePlayer(playerID: player.PlayerID);
                    LoadPlayers((Team)listboxTeams.SelectedItem);
                }

            }
        }
        #endregion
        
        #region "Other methods."
        private void LoadTeams()
        {
            loadingteams = true;
            listboxTeams.Items.Clear();
            cboTeams.Items.Clear();
            var teams = DapperMethods.GetTeams("");
            teams.ForEach(t => AddTeamsToControls(t));
            gboxPlayers.Enabled = false;
            loadingteams = false;
        }
        private void AddTeamsToControls(Team team)
        {
            listboxTeams.Items.Add(team);
            cboTeams.Items.Add(team);
        }

        private void LoadPlayers(Team team)
        {
            listboxPlayers.Items.Clear();
            var players = DapperMethods.GetPlayers(teamID: team.TeamID);
            players.ForEach(p => listboxPlayers.Items.Add(p));
            gboxPlayers.Text = string.Format(@"{0} players", team.TeamName);
            gboxPlayers.Enabled = true;

        }
        #endregion
       
    }
}
