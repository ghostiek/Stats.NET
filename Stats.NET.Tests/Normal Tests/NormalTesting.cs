using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Distributions;
using System;

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
       
    }
}
