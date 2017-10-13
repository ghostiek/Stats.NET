using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Utility;
using System;

namespace StatsLibTests
{
    [TestClass]
    public class MathUtilityTesting
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

            Assert.AreEqual(210, Stat.BinomialCoef(success,size));
        }

        [TestMethod]
        public void SummationTesting()
        {
            var summation = Calculate.SequenceSummation(1, 4, x => x + x);

            Assert.AreEqual(20, summation);
        }


        [TestMethod]
        public void ProductTesting()
        {
            var product = Calculate.SequenceProduct(1, 4, x => x + x);

            Assert.AreEqual(2*4*6*8, product);
        }

    }
}
