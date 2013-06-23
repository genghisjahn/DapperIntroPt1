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
    public static class HowToMethods
    {
        public static Team GetTeam()
        {
            Team result = new Team();
            SqlCeConnection cn = new SqlCeConnection(Properties.Settings.Default.DapperDataConnectionString);
            cn.Open();
            result =  cn.Query<Team>("select * from team where teamID=1",new { teamID = 1,city="Dallas" }).FirstOrDefault();
            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }
            return result;
        }
        public static Team GetTeamByID(int teamID)
        {
            Team result = new Team();
            SqlCeConnection cn = new SqlCeConnection(Properties.Settings.Default.DapperDataConnectionString);
            cn.Open();
            
            string query = "select * from team where teamID=@teamID";
            result = cn.Query<Team>(query, new { teamID = teamID,city="Dallas" }).FirstOrDefault();

            var deferredtest = cn.Query<Team>(query, new { teamID = teamID, city = "Dallas" });

            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }
            return result;
        }
        public static Team SelectTeamByParameterWithDifferntFieldName(int teamID)
        {
            Team result = new Team();
            SqlCeConnection cn = new SqlCeConnection(Properties.Settings.Default.DapperDataConnectionString);
            cn.Open();
            string query = "select *,teamname as othername from team where teamID = @teamID";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("teamID", teamID);
            result = cn.Query<Team>(query, dp).FirstOrDefault();
            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }
            return result;
        }
    }
}
