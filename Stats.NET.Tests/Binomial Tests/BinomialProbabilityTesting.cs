using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Distributions;
using System;
using StatsLib.Distributions.Discrete;

namespace StatsLibTests
{
    [TestClass]
    public class BinomialProbabilityTesting
    {
        [TestMethod]
        public void GetProbabilityLessThanOrEqualTest()
        {
            var _bin = new Binomial(0.1, 3);
            var _prob = _bin.GetProbabilityLessThanOrEqual(0);

            Assert.AreEqual(Math.Pow(0.9, 3), _prob);
        }

        [TestMethod]
        public void GetProbabilityLessThanTest()
        {
            var _bin = new Binomial(0.1, 3);
            var _prob = _bin.GetProbabilityLessThan(3);

            Assert.AreEqual(1, Math.Round(_prob));
        }
    }

}
