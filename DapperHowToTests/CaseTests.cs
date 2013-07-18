using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DapperHowToData;
using DapperHowToData.POCOs;
using System.Dynamic;
namespace DapperHowToTests
{
    [TestClass]
    public class CaseTests
    {
        [TestMethod,TestCategory("Case Tests")]
        public void Get_Player_Type()
        {
           var result  =  DapperCaseExamples.Return_A_PlayerType_ByID(1);
           Assert.IsTrue(result.GetType() ==typeof(Player));
        }

        [TestMethod, TestCategory("Case Tests")]
        public void Get_Player_Dynamic_Expando()
        {
            var result = DapperCaseExamples.Return_A_PlayerType_ByID(1);
            dynamic dynPlayer = new ExpandoObject();
            dynPlayer.playerID = result.PlayerID;
            Assert.AreEqual(1, dynPlayer.playerID);
        }

        [TestMethod, TestCategory("Case Tests")]
        public void Get_Player_Dynamic()
        {
            var result = DapperCaseExamples.Return_A_PlayerDynamic_ByID(1);
            Assert.AreEqual(1, result.playerID);
        }

        [TestMethod, TestCategory("Case Tests")]
        [ExpectedException(typeof(System.InvalidCastException),
        "The returned object type doesn't match the expected type.")]
        public void GetPlayer_Dynamic_Match_Player_Type()
        {
            var result = DapperCaseExamples.Return_A_PlayerDynamic_ByID(1);
            Player player = (Player)result;
   
        }

     
        [TestMethod, TestCategory("Case Tests")]
        [ExpectedException(typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException),
        "Could not match up class property with object property.")]
        public void GetPlayer_Dynamic_Match_Player_Property_Invalid()
        {
            var result = DapperCaseExamples.Return_A_PlayerDynamic_ByID(1);
            Player player = new Player();
            player.PlayerID = result.PlayerID;

        }

        [TestMethod, TestCategory("Case Tests")]
        public void GetPlayer_Dynamic_Match_Player_Property()
        {
            var result = DapperCaseExamples.Return_A_PlayerDynamic_ByID(1);
            Player player = new Player();
            player.PlayerID = result.playerID;
            Assert.IsTrue(player.PlayerID == 1);
        }

    }
}
