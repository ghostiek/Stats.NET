using System;
using StatsLib.Distributions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatsLib.TableTests
{
    [TestClass]
    public class ChiSquaredProbAndStat
    {
        [TestMethod]
        public void GetChiStat()
        {
            var chi = new ChiSquared(2); //DOF = 1
            var ExpectedChiStat = chi.GetChiSquaredStatistic(0.025); //This should give 5.024

            Assert.AreEqual(5.024, ExpectedChiStat);

        }

        [TestMethod]
        public void GetProb()
        {
            var chi = new ChiSquared(2); //DOF = 1
            var ObservedChiStat = 5;
            var Prob = chi.GetProbabilityLessThan(ObservedChiStat); //This should give 0.025 with 5 (or 5.024) as an input

            Assert.AreEqual(0.025, Prob);

        }
    }
}
