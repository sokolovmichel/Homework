using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HomeworkForMoq;
using FormattingCoordinates;


namespace HomeworkTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConvertTest()
        {
            //arange
            Mock<FormatText> mock = new Mock<FormatText>();
            mock.Setup(m => m.FormatMyText(It.IsAny<string>())).Returns<string>(total => total);
            FormatText target = mock.Object;
            string s = target.FormatMyText("11.11,22.22");

            //act

            string s1 = ReadDataNew.Convert(s);          


            //assert
            Assert.AreEqual("X: 11,11Y: 22,22", s1);
        }
    }
}