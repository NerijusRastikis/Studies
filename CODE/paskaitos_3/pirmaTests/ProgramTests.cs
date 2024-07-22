using Microsoft.VisualStudio.TestTools.UnitTesting;
using P13_Kartojimas;
using pirma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pirma.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        // TC1. Null masyvas
        // TC2. Tuscias masyvas
        // TC3. Masyvas su vienu elementu
        // TC4. Salygoje aprasytas masyvas su 3 elementais
        // TC5. Masyvas su tuscia reiksme
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        [TestMethod()]
        // TC1. Null masyvas
        public static void ArrayIsNull()
        {
            // Arange

            string[] array = null;
            string[] expected = { };

            // Act

            string[] actual = Program.VaisiaiCreateArrayWithLetterCount(array);

            // Assert

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        // TC2. Tuscias masyvas
        public static void ArrayIsEmpty()
        {
            // Arange

            string[] array = { };
            string[] expected = { };

            // Act

            string[] actual = Program.VaisiaiCreateArrayWithLetterCount(array);

            // Assert

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        // TC3. Masyvas su vienu elementu
        public static void ArrayWithOneElement()
        {
            // Arange

            string[] array = { "Obuolys" };
            string[] expected = { "Obuolys", "7" };

            // Act

            string[] actual = Program.VaisiaiCreateArrayWithLetterCount(array);

            // Assert

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        // TC4. Salygoje aprasytas masyvas su 3 elementais

        public static void ArrayWithThreeElements()
        {

            // Arange

            string[] array = { "Obuolys", "Bananai", "Braškė" };
            string[] expected = { "Obuolys", "7", "Bananai", "7", "Braškė", "7" };

            // Act
            string[] actual = Program.VaisiaiCreateArrayWithLetterCount(array);

            // Assert

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        // TC5. Masyvas su tuscia reiksme
        public static void ArrayWithEmptyValue()
        {
            // Arange
            string[] array = { "" };
            string[] expected = { "", "0" };

            // Act

            string[] actual = Program.VaisiaiCreateArrayWithLetterCount(array);

            //Assert

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}