using System.Collections.Generic;
using StatsLib.Distributions.Discrete;
using StatsLib.Distributions.Continuous;
using StatsLib.Samples;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stats.NET.Tests.Samples_Test
{
    [TestClass]
    public class DistributionInitialization
    {
        [TestMethod]
        public void DiscreteUniform()
        {
            var a = 0;
            var b = 5;
            var uni = new DiscreteUniform(a, b);

            var samp = new Sample(uni, 10000000);

            var frequency = new List<int>();
            for(int i = a; i <= b; i++)
            {
                frequency.Add(samp.Values.Count(x => x == i));
            }

            //Just using this to put a breakpoint. If this works, frequency should be around the same for all.
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void Uniform()
        {
            var a = 0;
            var b = 5;
            var uni = new Uniform(a, b);
            var samp = new Sample(uni, 20);
            //Just using this to put a breakpoint. To observe the variables
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void Rademacher()
        {
            var tries = 7;
            var rad = new Rademacher(tries);
            var samp = new Sample(rad, 20);
            //Just using this to put a breakpoint. To observe the variables
            Assert.AreEqual(0, 0);
        }
    }
}
