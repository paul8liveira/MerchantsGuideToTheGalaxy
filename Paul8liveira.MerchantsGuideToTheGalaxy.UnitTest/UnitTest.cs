using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paul8liveira.MerchantsGuideToTheGalaxy.Infra.CrossCutting;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodInput1()
        {
            Assert.AreEqual(Converter.Start("how much is pish tegj glob glob ?").ToLower(), "pish tegj glob glob is 42");
        }

        [TestMethod]
        public void TestMethodInput2()
        {
            Assert.AreEqual(Converter.Start("how many Credits is glob prok Silver ?").ToLower(), "glob prok silver is 68 credits");
        }

        [TestMethod]
        public void TestMethodInput3()
        {
            Assert.AreEqual(Converter.Start("how many Credits is glob prok Gold?").ToLower(), "glob prok gold is 57800 credits");
        }

        [TestMethod]
        public void TestMethodInput4()
        {
            Assert.AreEqual(Converter.Start("how many Credits is glob prok Iron ?").ToLower(), "glob prok iron is 782 credits");
        }

        [TestMethod]
        public void TestMethodInput5()
        {
            Assert.AreEqual(Converter.Start("how much wood could a woodchuck chuck if a woodchuck could chuck wood?"), "InvalidInput01: The intergalactics numbers doesn't exists.");
        }

        [TestMethod]
        public void TestMethodInput6()
        {
            Assert.AreEqual(Converter.Start("how much prok prok?"), "InvalidInput02: Some intergalactics numbers exceeded the maximum repetition.");
        }        
    }
}
