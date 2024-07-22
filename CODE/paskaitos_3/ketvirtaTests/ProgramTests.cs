using Microsoft.VisualStudio.TestTools.UnitTesting;
using ketvirta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketvirta.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CountryAndCapitalTest()
        {
            var dict = new Dictionary<string, string>()
            {
                {"lithuania", "vilnius" }
            };
            var choice = "lithuania";
            string actual = "vilnius";
            string expected = Program.CountryAndCapital(dict, choice);
            Assert.AreEqual(expected, actual.ToUpperInvariant());
        }

        [TestMethod()]
        public void ModifyFruitBasketAddTest()
        {
            var dict = new Dictionary<string, int>
            {
                {"Apple", 1 }
            };
            string choice1 = "Banana";
            int choice2 = 5;
            var expected = new Dictionary<string, int>
            {
                {choice1, choice2 }
            };
            var actual = Program.ModifyFruitBasket(dict);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ModifyFruitEditTest()
        {
            var dict = new Dictionary<string, int>
            {
                {"Apple", 1 }
            };
            string choice1 = "Apple";
            int choice2 = 5;
            var expected = new Dictionary<string, int>
            {
                {choice1, choice2 }
            };
            var actual = Program.ModifyFruitBasket(dict);
            Assert.AreEqual(expected, actual);
        }
    }
}