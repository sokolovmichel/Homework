using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Homework;

namespace HomeworkTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConvertTest()
        {
            string s;
            s = ReadData.Convert("11.11,22.22");
            //Assert.AreEqual("11,11 22,22", s);
            Assert.AreEqual("X: 11,11Y: 22,22", s);
        }
    }
}
