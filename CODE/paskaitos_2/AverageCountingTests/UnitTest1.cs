using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AverageCountingTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfAverageNumberWillWorkWithPositiveNumbers()
        {
            // Arange

            int[] numbers = { 1, 2, 3 };

            // Act

            int answer = .ForEachLoopAverageNumberInArray(numbers);
            Assert.Pass();
        }
    }
}