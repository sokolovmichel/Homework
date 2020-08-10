using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Triangle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task4Triangle.Tests
{
    [TestClass()]
    public class CheckTests
    {
        [TestMethod()]
        public void CheckTriangleTest()
        {
            //Arrange
            string a = "2";
            string b = "2";
            string c = "3";
            //Act
            Check.CheckTriangle(a, b, c, out double A, out double B, out double C);
            //Assert
            Assert.AreEqual(2, A);
            Assert.AreEqual(2, B);
            Assert.AreEqual(3, C);
        }
    }
}