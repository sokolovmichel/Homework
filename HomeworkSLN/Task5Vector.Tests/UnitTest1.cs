using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task5Vector.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void VectorOperatorAdditionTest()
        {
            //arrange
            Vector a = new Vector(3, 3, 3);
            Vector b = new Vector(2, 2, 2);
            //act
            Vector c = a + b;
            //assert
            Assert.AreEqual("(5;5;5)", c.ToString());
        }

        [TestMethod]
        public void VectorOperatorSubtractionTest()
        {
            //arrange
            Vector a = new Vector(3, 3, 3);
            Vector b = new Vector(2, 2, 2);
            //act
            Vector c = a - b;
            //assert
            Assert.AreEqual("(1;1;1)", c.ToString());
        }

        [TestMethod]
        public void VectorOperatorMultiplicationTest()
        {
            //arrange
            Vector a = new Vector(3, 3, 3);
            double M = 5;
            //act
            Vector c = a * M;
            //assert
            Assert.AreEqual("(15;15;15)", c.ToString());
        }

        [TestMethod]
        public void VectorOperatorProductTest()
        {
            //arrange
            Vector a = new Vector(3, 3, 3);
            Vector b = new Vector(2, 2, 2);
            //act
            double c = a * b;
            //assert
            Assert.AreEqual(18, c);
        }
    }
}
