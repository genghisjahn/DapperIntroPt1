using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperHowToData.POCOs;
using System.Data.SqlServerCe;
using Dapper;
namespace DapperHowToData
{
    public static class DapperMethods
    {
        #region "DataConnection"
        private static string ConnString = Properties.Settings.Default.DapperDataConnectionString;

        private class DataConnection : IDisposable
        {
            SqlCeConnection cn;

            public DataConnection(string cnstring)
            {
                cn = new SqlCeConnection(cnstring);
            }
            public SqlCeConnection Connection
            {
                get
                {
                    return this.cn;
                }
                private set { }
            }
            void IDisposable.Dispose()
            {
                if (cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
        #endregion

        #region "Team Methods"
        public static List<Team> GetTeams(string teamname)
        {
            List<Team> result = new List<Team>();
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"select 
                                    teamID,teamname
                                from 
                                    team 
                                where 
                                    teamname like '%'+@teamname+'%' 
                                order by 
                                    teamname";

                result = dc.Connection.Query<Team>(query, new { teamname = teamname }).ToList();
                #region "other queries"
                
                // These have to be case sensitive based on return fields of the record set.
                /*
                result = dc.Connection.Query(query, new { teamname = teamname })
                    .Select(
                        row => new Team((int)row.teamID, (string)row.teamname, DateTime.UtcNow))
                        .ToList();
                 * */
                /*
                result = dc.Connection.Query(query, new { teamname = teamname })
                    .Select(
                        row => new Team((int)row.teamID, (string)row.teamname, DateTime.UtcNow) { City = "Utopia" })
                        .ToList();
                */
                #endregion
            }
            return result;
        }
        public static void AddTeam(string teamname)
        {
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"insert into 
                                    team 
                                        (teamname) 
                                    values 
                                        (@teamname)";
                dc.Connection.Execute(query, new { teamname = teamname });
            }
        }
        public static void UpdateTeam(int teamID, string teamname)
        {
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"update 
                                    team 
                                set 
                                    teamname = @teamname 
                                where 
                                    teamID=@teamID";
                dc.Connection.Execute(query, new { teamname = teamname, teamID = teamID });
            }
        }
        public static void DeleteTeam(int teamID)
        {
            string query = @"delete from
                                team 
                             where 
                                teamID=@teamID;";
            using (DataConnection dc = new DataConnection(ConnString))
            {
                dc.Connection.Execute(query, new { teamID = teamID });
            }
        }
        #endregion

        #region "Player Methods"
        public static List<Player> GetPlayers(int teamID)
        {
            List<Player> result = new List<Player>();
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"select * 
                                from 
                                    player 
                                where 
                                    teamID = @teamID
                                order by 
                                    playername";
                result = dc.Connection.Query<Player>(query, new { teamID = teamID }).ToList();
            }
            return result;
        }
        public static void AddPlayer(int teamID, string playername)
        {
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"insert into 
                                   player 
                                        (playername,teamID) 
                                    values 
                                        (@playername,@teamID)";
                dc.Connection.Execute(query, new { playername = playername, teamID = teamID });
            }
        }
        public static void UpdatePlayerName(int playerID, string playername)
        {
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"update 
                                   player 
                                 set
                                    playername = @playername
                                 where
                                    playerID = @playerID";
                dc.Connection.Execute(query, new { playername = playername, playerID = playerID });
            }
        }
        public static void UpdatePlayerTeam(int playerID, int teamID)
        {
            using (DataConnection dc = new DataConnection(ConnString))
            {
                string query = @"update 
                                   player 
                                 set
                                    teamID = @teamID
                                 where
                                    playerID = @playerID";
                dc.Connection.Execute(query, new { teamID = teamID, playerID = playerID });
            }
        }
        public static void DeletePlayer(int playerID)
        {
            string query = @"delete from
                                player 
                             where 
                                playerID=@playerID;";
            using (DataConnection dc = new DataConnection(ConnString))
            {
                dc.Connection.Execute(query, new { playerID = playerID });
            }
        }
        #endregion
    }

}
