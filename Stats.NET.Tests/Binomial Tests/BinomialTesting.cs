using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Distributions;
using System;
using StatsLib.Distributions.Discrete;


namespace StatsLibTests
{
    [TestClass]
    public class BinomialTesting
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RangeAttributeTest()
        {
            var _bin = new Binomial(3, 30);
        }

        [TestMethod]
        public void MeanTesting()
        {
            var _bin = new Binomial(0.5, 30);

            Assert.AreEqual(_bin.GetMean(), 15);
        }
        [TestMethod]
        public void VarianceTesting()
        {
            var _bin = new Binomial(0.5, 30);

            Assert.AreEqual(_bin.GetVariance(), 7.5);
        }
        [TestMethod]
        public void StandardDeviationTesting()
        {
            var _bin = new Binomial(0.5, 30);

            Assert.AreEqual(_bin.GetStandardDeviation(), Math.Sqrt(7.5));
        }

        [TestMethod]
        public void MGFTest()
        {
            var _bin = new Binomial(0.5, 30);


            Assert.AreEqual(_bin.GetMgf(1), Math.Pow(1-0.5+0.5*Math.E, 30));
        }


    }
}
