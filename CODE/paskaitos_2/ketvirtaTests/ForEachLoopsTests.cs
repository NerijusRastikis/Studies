using NUnit.Framework;
using ketvirta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace ketvirta.Tests
{
    [TestFixture()]
    public class ForEachLoopsTests
    {
        [Test()]
        public void ForEachLoopAverageNumberInArray_WithPositiveNumbers_Test()
        {
            // Arange

            int[] positiveNumbers = {1, 2, 3};

            // Act

            int answer = ForEachLoops.ForEachLoopAverageNumberInArray(positiveNumbers);

            //Assert

            Assert.AreEqual(6, answer);
        }
        [Test()]
        public void ForEachLoopAverageNumberInArray_WithNegativeNumbers_Test()
        {
            // Arange

            int[] negativeNumbers = { -1, -2, -3 };

            // Act

            int answer = ForEachLoops.ForEachLoopAverageNumberInArray(negativeNumbers);

            //Assert

            Assert.AreEqual(-6, answer);
        }
        [Test()]
        public void ForEachLoopMixedNumbers_Test()
        {
            // Arange

            int[] mixedNumbers = { 1, -1, 2, -2, 3, -3 };

            // Act

            int sum = 0;
            int[] answers = ForEachLoops.ForEachLoopPositiveNumbersInArray(mixedNumbers);
            foreach (var answer in answers)
            {
                sum += answer;
            }
            Assert.AreEqual(6, sum);
        }
        [Test()]
        public void ForEachLoopPositiveNumbers_Test()
        {
            // Arange

            int[] mixedNumbers = { 1, 1, 2, 2, 3, 3 };

            // Act

            int sum = 0;
            int[] answers = ForEachLoops.ForEachLoopPositiveNumbersInArray(mixedNumbers);
            foreach (var answer in answers)
            {
                sum += answer;
            }
            Assert.AreEqual(12, sum);
        }
    }
}