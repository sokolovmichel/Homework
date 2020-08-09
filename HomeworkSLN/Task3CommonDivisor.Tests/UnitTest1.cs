using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3CommonDivisor;

namespace Task3CommonDivisor.Tests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        [TestMethod]
        public void CalculateEuclideanGCD_1068And3096_12Returned()
        {
            //arrange
            int a = 1068;
            int b = 3096;
            
            //act
            int result = GreatestCommonDivisor.CalculateEuclideanGCD(a, b);

            //assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void CalculateSteinGCD_1071And462_21Returned()
        {
            //arrange
            int a = 1071;
            int b = 462;

            //act
            int result = GreatestCommonDivisor.CalculateSteinGCD(a, b);

            //assert
            Assert.AreEqual(21, result);
        }
    }
}
