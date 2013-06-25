using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using Dapper;
using DapperHowToData.POCOs;

namespace DapperHowToData
{
    public static class ExamplesForIEnumerable
    {
        public static void ExampleMethod()
        {

            SqlCeConnection cn = new SqlCeConnection(Properties.Settings.Default.DapperDataConnectionString);
            cn.Open();
            string queryteamID2 = "select * from player where teamid=2";
            IEnumerable<Player> enumerableexample = cn.Query<Player>(queryteamID2);
            List<Player> listexample = cn.Query<Player>(queryteamID2).ToList();
            Player[] arrayexample = cn.Query<Player>(queryteamID2).ToArray();
            Dictionary<int, Player> dictionaryexample = cn.Query<Player>(queryteamID2).ToDictionary(p => p.PlayerID, p => p);

            //reference type
            Player firstplayer = cn.Query<Player>("select * from player where teamID=1").First();

            string queryplayerIDNull = "select * from player where playerid=100";
            try
            {
                Player nofirstplayer = cn.Query<Player>(queryplayerIDNull).First();
            }
            catch (InvalidOperationException invalidopex)
            {
                //Notice that we didn't catch Execption ex, we narrowed down the type
                //to the specific kind of exception that could happen.
                //If at all possible, narrow down your exception handling.
                Console.WriteLine(string.Format("Error! {0}", invalidopex.Message));
            }

            Player nofirstplayerdefault = cn.Query<Player>(queryplayerIDNull).FirstOrDefault();

            string queryplayerNameNull = "select playername from player where playerID = 100";

            Player playerdoesnotexist = new Player();
            playerdoesnotexist.PlayerID = -1;
            playerdoesnotexist.PlayerName = "No such player.";
            playerdoesnotexist.TeamID = -1;
            
            Player firstplayernalt = cn.Query<Player>(queryplayerNameNull).DefaultIfEmpty(playerdoesnotexist).FirstOrDefault();
            
            string firstplayername = cn.Query<string>(queryplayerNameNull).FirstOrDefault();
            try
            {
                //Why doesn't this work?
                string firstplayernamepropr = cn.Query<Player>(queryplayerNameNull).FirstOrDefault().PlayerName;
                //Because we are first returning the default, which is null, which has no values for property names
                //even though the default value of the PlayerName property is null, it can't get that far because
                //the object that it is attached to is null.  There's no THERE there.;
            }
            catch (NullReferenceException exnull)
            {
                Console.WriteLine(string.Format("Error! {0}", exnull.Message));
            }


            //value types
            string queryplayerIDDoesNotExist = "select playerID from player where playerID = 100";
            int nofirstplayerID = cn.Query<int>(queryplayerIDDoesNotExist).FirstOrDefault();
            int? nofirstplayerIDNullable = cn.Query<int?>(queryplayerIDDoesNotExist).FirstOrDefault();
            //int? is very helpful when dealing with database tables because
            //often times a column type in the record set will be an int that allows nulls.
            //Always allowing the default value to go through could be misleading.

            int nofirstplayerIDAlter = cn.Query<int>(queryplayerIDDoesNotExist).DefaultIfEmpty(-1).FirstOrDefault();

            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }

        }
    }
}

