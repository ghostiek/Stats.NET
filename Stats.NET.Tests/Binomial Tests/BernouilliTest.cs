using System;
using StatsLib.Distributions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Distributions.Discrete;

namespace StatsLib.BinomialTests
{
    [TestClass]
    public class BernouilliTest
    {
        [TestMethod]
        public void GetMean()
        {
            var bernouilli = new Bernouilli(0.2);

            var mean = bernouilli.GetMean();

            Assert.AreEqual(mean, 0.2);
        }

        [TestMethod]
        public void GetVariance()
        {
            var bernouilli = new Bernouilli(0.2);

            var variance = bernouilli.GetVariance();

            Assert.AreEqual(variance, 0.8*0.2);
        }
    }
}
