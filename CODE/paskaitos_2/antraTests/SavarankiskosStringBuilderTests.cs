using antra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P10_DebugAndStringBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10_DebugAndStringBuilder.Tests
{
    [TestClass()]
    public class SavarankiskosStringBuilderTests
    {
        [TestMethod()]
        public void CreateCsvLine_ShouldReturnCorrectCsvLine_WhenAllFieldsAreNonEmpty()
        {
            // Arrange
            string field1 = "John";
            string field2 = "Doe";
            string field3 = "30";

            // Act
            string actual = Program.CreateCsvLine(field1, field2, field3);

            // Assert
            string expected = "\"John\",\"Doe\",\"30\"";
            // Added equality
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field1Empty()
        {
            // +
            // Arrange
            string field1 = "";
            string field2 = "Doe";
            string field3 = "30";

            // Act
            Program.CreateCsvLine(field1, field2, field3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field2Empty()
        {
            // +
            // Arrange
            string field1 = "John";
            string field2 = "";
            string field3 = "30";

            // Act
            Program.CreateCsvLine(field1, field2, field3);

        }

        [TestMethod]
        public void CreateCsvLine_ShouldReturnCorrectCsvLine_Field3Empty()
        {
            // +
            // Arrange
            string field1 = "John";
            string field2 = "Doe";
            string field3 = "";
            Program.sbulder.Clear();

            // Act
            var actual = Program.CreateCsvLine(field1, field2, field3);

            // Assert
            string expected = "\"John\",\"Doe\",\"\"";
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void CreateCsvLine_ShouldReturnCorrectCsvLine_Field1Length10()
        {
            // +
            // Arrange
            string field1 = "1234567890";
            string field2 = "Doe";
            string field3 = "30";

            // Act
            var actual = Program.CreateCsvLine(field1, field2, field3);
            Program.sbulder.Clear();

            // Assert
            string expected = "\"1234567890\",\"Doe\",\"30\"";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CreateCsvLine_ShouldReturnCorrectCsvLine_Field2Length11()
        {
            // +
            // Arrange
            string field1 = "John";
            string field2 = "12345678901";
            string field3 = "30";
            Program.sbulder.Clear();

            // Act
            var actual = Program.CreateCsvLine(field1, field2, field3);

            // Assert
            string expected = "\"John\",\"12345678901\",\"30\"";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CreateCsvLine_ShouldReturnCorrectCsvLine_Field3Length9()
        {
            // +
            // Arrange
            string field1 = "John";
            string field2 = "Doe";
            string field3 = "123456789";
            Program.sbulder.Clear();

            // Act
            var actual = Program.CreateCsvLine(field1, field2, field3);
            Program.sbulder.Clear();

            // Assert
            string expected = "\"John\",\"Doe\",\"123456789\"";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateCsvLine_ShouldReturnCorrectTwoCsvLines_TwoPersonsAdded()
        {
            // +
            // Arrange
            Program.sbulder.Clear();

            // Act
            var actual = Program.CreateCsvLine("John", "Doe", "30");
            actual = Program.CreateCsvLine("Jane", "Doe", "25");

            // Assert
            string expected = "\"John\",\"Doe\",\"30\"\n\"Jane\",\"Doe\",\"25\"";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field1ContainComma()
        {
            // +
            // Arrange
            string field1 = "John,";
            string field2 = "Doe";
            string field3 = "30";

            // Act
            Program.CreateCsvLine(field1, field2, field3);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field2ContainComma()
        {
            // Arrange
            string field1 = "John";
            string field2 = "Doe,";
            string field3 = "30";

            // Act
            Program.CreateCsvLine(field1, field2, field3);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field3ContainComma()
        {
            // Arrange
            string field1 = "John";
            string field2 = "Doe";
            string field3 = "30,";

            // Act
            Program.CreateCsvLine(field1, field2, field3);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field1Length11()
        {
            // Arrange
            string field1 = "12345678901";
            string field2 = "Doe";
            string field3 = "30";

            // Act
            Program.CreateCsvLine(field1, field2, field3);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field2Length12()
        {
            // Arrange
            string field1 = "John";
            string field2 = "123456789012";
            string field3 = "30";

            // Act
            Program.CreateCsvLine(field1, field2, field3);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCsvLine_ShouldThrowArgumentException_Field3Length10()
        {
            // Arrange
            string field1 = "John";
            string field2 = "Doe";
            string field3 = "1234567890";

            // Act
            Program.CreateCsvLine(field1, field2, field3);

        }

    }
}