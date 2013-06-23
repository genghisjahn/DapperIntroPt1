using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DapperHowToData;
using DapperHowToData.POCOs;
namespace DapperHowToTests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void SelectTeamWithID1()
        {
            var team= HowToMethods.GetTeam();
            Assert.IsTrue(team.TeamID > 0);
        }
        [TestMethod]
        public void SelectByTeamIDParamter()
        {
            Team team = HowToMethods.GetTeamByID(2);
            Assert.IsTrue(team.TeamID == 2);
        }

        [TestMethod]
        public void SelectByTeamInvalidIDParamter()
        {
            Team team = HowToMethods.GetTeamByID(100);
            Assert.IsNull(team);
        }

        [TestMethod]
        public void SelectByTeamIDParamterWithExraFieldName()
        {
            Team team = HowToMethods.SelectTeamByParameterWithDifferntFieldName(1);
            Assert.IsTrue(team.TeamID == 1);
        }
        [TestMethod]
        public void SelectByTeamIDParamterWithExtraPropertyName()
        {
            Team team = HowToMethods.GetTeamByID(1);
            Assert.IsTrue(team.TeamID == 1);
        }
    }
}
