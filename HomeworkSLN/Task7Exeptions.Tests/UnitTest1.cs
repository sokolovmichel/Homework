using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task7Exeptions.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        // Проверяет операцию сложения матриц
        public void MatrixOperatorAdditionTest()
        {
            //arrange
            Matrix a = new Matrix(3, 3) { numbers = new[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } } };
            Matrix b = new Matrix(3, 3) { numbers = new[,] { { 4, 4, 4 }, { 5, 5, 5 }, { 6, 6, 6 } } };
            //act
            Matrix c = a + b;
            Matrix d = new Matrix(3, 3) { numbers = new[,] { { 5, 5, 5 }, { 7, 7, 7 }, { 9, 9, 9 } } };
            //assert
            Assert.IsTrue(MyEquals.Equals(d, c));
        }

        [TestMethod]
        // Проверяет операцию вычитания матриц
        public void MatrixOperatorSubtractionTest()
        {
            //arrange
            Matrix a = new Matrix(3, 3) { numbers = new[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } } };
            Matrix b = new Matrix(3, 3) { numbers = new[,] { { 4, 4, 4 }, { 5, 5, 5 }, { 6, 6, 6 } } };
            //act
            Matrix c = b - a;
            Matrix d = new Matrix(3, 3) { numbers = new[,] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } } };
            //assert
            Assert.IsTrue(MyEquals.Equals(d, c));
        }

        [TestMethod]
        // Проверяет операцию умножения матриц
        public void MatrixOperatorMultiplicationTest()
        {
            //arrange
            Matrix a = new Matrix(3, 3) { numbers = new[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } } };
            Matrix b = new Matrix(3, 2) { numbers = new[,] { { 4, 4 }, { 5, 5 }, {6, 6 } } };
            //act
            Matrix c = a * b;
            Matrix d = new Matrix(3, 2) { numbers = new[,] { { 15, 15 }, { 30, 30 }, { 45, 45 } } };
            //assert
            Assert.IsTrue(MyEquals.Equals(d, c));
        }


    }
}
