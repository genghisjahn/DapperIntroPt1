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
        public static void ExampleMethods()
        {

            SqlCeConnection cn = new SqlCeConnection(Properties.Settings.Default.DapperDataConnectionString);
            cn.Open();


            string queryteamID2 = "select * from player where teamid=2";
            IEnumerable<Player> enumerableexample = cn.Query<Player>(queryteamID2);
            List<Player> listexample = cn.Query<Player>(queryteamID2).ToList();
            Player[] arrayexample = cn.Query<Player>(queryteamID2).ToArray();
            Dictionary<int, Player> dictionaryexample = cn.Query<Player>(queryteamID2).ToDictionary(p => p.PlayerID, p => p);




            /******************************************/


            //reference types
            Player firstplayer = cn.Query<Player>("select * from player where teamID=1").First();
            string queryplayerIDNull = "select * from player where playerid=100";
            try
            {
                Player nofirstplayer = cn.Query<Player>(queryplayerIDNull).First();
                /*
                 * There is no first element, so we get an exception.
                 * */

            }
            catch (InvalidOperationException invalidopex)
            {
                Console.WriteLine(string.Format("Error! {0}", invalidopex.Message));
            }

            /*
             * The default value of a reference type is null. 
             * We see here that since we don't assign a value with a new keyword,
             * We have a variable with no value to use. 
             * If we reference it code, we get a compile time error.
             * */
            
            Player tempPlayer;
            //Console.WriteLine("Player name is {0}.", tempPlayer);

                        
            Player nofirstplayerdefault = cn.Query<Player>(queryplayerIDNull).FirstOrDefault();

            Player playerdoesnotexist = new Player();
            playerdoesnotexist.PlayerID = -1;
            playerdoesnotexist.PlayerName = "No such player.";
            playerdoesnotexist.TeamID = -1;
            
            Player firstplayernaltdefault = cn.Query<Player>(queryplayerIDNull).DefaultIfEmpty(playerdoesnotexist).FirstOrDefault();


            /******************************************/



            string queryplayerNameNull = "select playername from player where playerID = 100";
            string firstplayername = cn.Query<string>(queryplayerNameNull).FirstOrDefault();
            try
            {
                //Why doesn't this work?
                string firstplayernamepropr = cn.Query<Player>(queryplayerNameNull).FirstOrDefault().PlayerName;
                /*
                 * Three things are happening:
                 * 1. cn.Query() returns IEnumerable of Player
                 * 2. .FirstOrDefault() gives us the first item if it exists.  
                 *    Since there are none, we return null.
                 * 3. .PlayerName can only return a string if the variable has a value.
                 *    If it's null, it can't have a value.
                 * 
                 * And we are rewarded with a Null Reference exception.
                */
            }
            catch (NullReferenceException exnull)
            {
                Console.WriteLine(string.Format("Error! {0}", exnull.Message));
            }


            //But this will work.
            try
            {
                string firstplayernamepropr = cn.Query<Player>(queryplayerNameNull).DefaultIfEmpty(playerdoesnotexist).FirstOrDefault().PlayerName;
                /*
                 * Four things are happening here.
                 * 1. cn.Query() is return IEnumerable of Player
                 * 2. Then we say, if this winds up being null, return this variable of type Player instead.
                 * 3. Then we ask for the .FirstOrDefault() item, since there are none, the variable playerdoesnotexist,
                 *    which is of type Player.
                 * 4. Then we get the PlayerName property from the variable playerdoesnotexist: "No such player."
                 * */
            }
            catch (NullReferenceException exnull)
            {
                Console.WriteLine(string.Format("Error! {0}", exnull.Message));
            }


            /******************************************/

            //value types - by definiation, they have a value.  They are never null.
            
            int firstplayerID = cn.Query<int>("select playerID from player where teamID= 8").FirstOrDefault();

            string queryplayerIDDoesNotExist = "select playerID from player where playerID = 100";
            int nofirstplayerID = cn.Query<int>(queryplayerIDDoesNotExist).FirstOrDefault();
            
            //Nullable Types  the ?
            int? nofirstplayerIDNullable = cn.Query<int?>(queryplayerIDDoesNotExist).FirstOrDefault();
            int? firstplayerIDNullable = cn.Query<int?>("select playerID from player where teamID= 8").FirstOrDefault();
            //int? is very helpful when dealing with database tables because
            //often times a column type in the record set will be an int that allows nulls.
            //Always allowing the default value to go through could be misleading.

            if (firstplayerIDNullable.HasValue)
            {
                int regularint = firstplayerIDNullable.Value;
                Console.WriteLine("Int value {0}.", regularint.ToString());
            }

            //string? test; 
            //Does not work because string is already a reference type and can be null.


            int nofirstplayerIDAlter = cn.Query<int>(queryplayerIDDoesNotExist).DefaultIfEmpty(-1).FirstOrDefault();






            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }

        }
    }
}

