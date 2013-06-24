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
        public static void ExampleMethod(){
            List<Player> result;
            SqlCeConnection cn = new SqlCeConnection(Properties.Settings.Default.DapperDataConnectionString);
            if (cn.State != System.Data.ConnectionState.Closed)
            {
                result = cn.Query<Player>("select * from player where teamid=1").ToList();
                var firstplayer = cn.Query<Player>("select * from player where playerid=1").First();
                var nofirstplayer = cn.Query<Player>("select * from player where playerid=100").FirstOrDefault();

                cn.Close();
            }
            
        }
        }
    }

