using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlServerCe;
using DapperHowToData.POCOs;
using System.Reflection;
using System.Dynamic;
using System.Linq;
namespace DapperHowToData
{
    public class DapperCaseExamples
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

        public static Player Return_A_PlayerType_ByID(int playerID)
        {
            Player result = new Player();
            using (DataConnection dc = new DataConnection(Properties.Settings.Default.DapperDataConnectionString))
            {
                result = dc.Connection.Query<Player>("select * from player where playerID = @playerID", new { playerID = playerID }).FirstOrDefault();
            }
            return result;
        }
        public static dynamic Return_A_PlayerDynamic_ByID(int playerID)
        {
            dynamic result;
            using (DataConnection dc = new DataConnection(Properties.Settings.Default.DapperDataConnectionString))
            {
                result = dc.Connection.Query("select * from player where playerID = @playerID", new { playerID = playerID }).FirstOrDefault();
            }
            return result;
        }
    }
}
