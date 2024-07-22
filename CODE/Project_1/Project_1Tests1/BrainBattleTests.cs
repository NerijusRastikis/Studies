using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Tests
{
    [TestClass()]
    public class BrainBattleTests
    {
        [TestMethod()]
        public void SortsDescending_PrintScoreboardTest()
        {
            // ARANGE

            var listOfUsers = new Dictionary<string, string>()
            {
                {"Tomas", "Tomauskas" },
                {"Saulius", "Sauliauskas" },
                {"Azuolas", "Azuoliauskas" },
                {"Zaneta", "Zanetaite" }
            };
            var signedUser = new Dictionary<string, string>()
            {
                { "Mykolas", "Mykolauskas" }
            };
            bool isNewPlayer = false;
            bool hasPlayed = true;
            string gameLogo = "W E L C O M E!\n";
            int tempScore = 0;
            var expected = new Dictionary<string, int>()
           {
                { "Zaneta", 32 },
                { "Azuolas", 13 },
                { "Tomas", 10 },
                { "Saulius", 7 }
           };
            // ACT
            var actual = BrainBattle.CompareValues(listOfUsers, (signedUser, isNewPlayer), hasPlayed, tempScore);
            // ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}