using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Extensions;
using System;

namespace StatsLibTests
{
    [TestClass]
    public class ExtensionsTesting
    {
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void FactorialTesting()
        {
            double num = -1;
            num.Factorial();
        }

        [TestMethod]
        public void BinomialCoefTesting()
        {
            double success = 4;
            double size = 10;

            Assert.AreEqual(210, StatsLib.Extensions.Stats.BinomialCoef(success,size));
        }
    }
}
