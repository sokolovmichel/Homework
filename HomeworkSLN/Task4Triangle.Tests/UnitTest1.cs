using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task4Triangle;

namespace Task4Triangle.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void CalculateAreaTest()
        {
            //Arrange
            double a = 2;
            double b = 2;
            double c = 3;
            //Act
            Triangle myTriangle = new Triangle(a, b, c);
            double result = Math.Round(myTriangle.CalculateArea(),2);
            //Assert
            Assert.AreEqual(1.98, result);

        }

        [TestMethod]
        public void CalculatePerimeterTest()
        {
            //Arrange
            double a = 2;
            double b = 2;
            double c = 3;
            //Act
            Triangle myTriangle = new Triangle(a, b, c);
            double result = myTriangle.CalculatePerimeter();
            //Assert
            Assert.AreEqual(7.00, result);

        }

    }
}
