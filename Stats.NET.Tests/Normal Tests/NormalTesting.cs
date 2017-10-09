using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Distributions;
using System;
using StatsLib.Distributions.Continuous;

namespace StatsLibTests
{
    [TestClass]
    public class NormalTesting
    {
        [TestMethod]
        public void WikiTest()
        {
            var norm = new Normal(20, 4);
            var sol = norm.GetProbabilityLessThanOrEqual(16);
            Assert.AreEqual(sol, norm.GetProbabilityLessThan(16));
        }

        [TestMethod]
        public void MGFTest()
        {
            var norm = new Normal(20, 4);
            var sol = norm.GetMgf(2);
            Assert.AreEqual(sol, Math.Exp(48));
        }

        [TestMethod]
        public void NameOfCheckTest()
        {
            var norm = new Normal(20, -4);
            Assert.AreEqual(norm.Sigma, -4);
        }

    }
}
