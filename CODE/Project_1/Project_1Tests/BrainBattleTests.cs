using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YourNamespace.Tests
{
    [TestClass]
    public class LogInDetailsTests
    {
        private Dictionary<string, string> accountList;
        private const string introText = "Welcome to the System";

        [TestInitialize]
        public void TestInitialize()
        {
            accountList = new Dictionary<string, string>();
        }

        private void SetConsoleInput(string input)
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            Console.SetIn(new StreamReader(inputStream));
        }

        private string GetConsoleOutput()
        {
            using (var outputStream = new MemoryStream())
            {
                var originalOutput = Console.Out;
                var writer = new StreamWriter(outputStream) { AutoFlush = true };
                Console.SetOut(writer);

                // Reset the console output to original
                Console.SetOut(originalOutput);
                outputStream.Position = 0;
                using (var reader = new StreamReader(outputStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        [TestMethod]
        public void LogInDetails_ValidName_ReturnsTrue()
        {
            // Arrange
            SetConsoleInput("John\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, result.Item1.Count);
            Assert.IsTrue(result.Item1.ContainsKey("John"));
            Assert.AreEqual("Doe", result.Item1["John"]);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void LogInDetails_EmptyFirstName_RetriesUntilValid()
        {
            // Arrange
            SetConsoleInput("\nJohn\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, result.Item1.Count);
            Assert.IsTrue(result.Item1.ContainsKey("John"));
            Assert.AreEqual("Doe", result.Item1["John"]);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void LogInDetails_EmptyLastName_RetriesUntilValid()
        {
            // Arrange
            SetConsoleInput("John\n\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, result.Item1.Count);
            Assert.IsTrue(result.Item1.ContainsKey("John"));
            Assert.AreEqual("Doe", result.Item1["John"]);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void LogInDetails_NewUser_AddsToAccountList()
        {
            // Arrange
            SetConsoleInput("John\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, accountList.Count);
            Assert.IsTrue(accountList.ContainsKey("John"));
            Assert.AreEqual("Doe", accountList["John"]);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void LogInDetails_ExistingUser_DoesNotAddToAccountList()
        {
            // Arrange
            accountList.Add("John", "Doe");
            SetConsoleInput("John\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, accountList.Count);
            Assert.IsTrue(accountList.ContainsKey("John"));
            Assert.AreEqual("Doe", accountList["John"]);
            Assert.IsFalse(result.Item2);
        }

        [TestMethod]
        public void LogInDetails_InvalidFirstName_RejectsNonLetters()
        {
            // Arrange
            SetConsoleInput("J0hn\nJohn\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, accountList.Count);
            Assert.IsTrue(accountList.ContainsKey("John"));
            Assert.AreEqual("Doe", accountList["John"]);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void LogInDetails_InvalidLastName_RejectsNonLetters()
        {
            // Arrange
            SetConsoleInput("John\nD0e\nDoe\n");

            // Act
            var result = BrainBattle.LogInDetails(accountList, introText, out string userName);

            // Assert
            Assert.AreEqual("John Doe", userName);
            Assert.AreEqual(1, accountList.Count);
            Assert.IsTrue(accountList.ContainsKey("John"));
            Assert.AreEqual("Doe", accountList["John"]);
            Assert.IsTrue(result.Item2);
        }
    }
}
