using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Kartojimas1.Program;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Kartojimas1.Program.Tests
{

    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void PlaceOrderTest()
        {
            // Arange
            var logger = new EmptyMyLogger();
            var actual = new Order(0.1, 100);
            var sut = new OrderService(logger);
            // Act
            var expected = sut.PlaceOrder();
            // Assert
            Assert.AreEqual<Order>(expected, actual);
        }
    }
}