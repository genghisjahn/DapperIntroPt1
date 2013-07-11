using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperHowToTests
{
    [TestClass]
    public class MiscUnitTest_P3
    {
        [TestMethod,TestCategory("Part 3")]
        public void AutoImplement2()
        {
            var team = DapperHowToData.HowToMethods.GetTeamAltDefault();
            Assert.AreEqual(1, team.TeamID);
        }

        [TestMethod, TestCategory("Part 3")]
        public void AlternateConstruction()
        {
            var team = DapperHowToData.HowToMethods.GetTeamAltConstructor();
            Assert.AreEqual(1, team.TeamID);
        }
    }
}
