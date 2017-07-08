using System;
using StatsLib.Distributions;
using StatsLib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stats.NET.Tests.Intellisense_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var normal = new Normal(3, 4);
            var mean = normal.Mu;

            var chi = new ChiSquared(3);
            var dof = chi.DegreeOfFreedom;


        }
    }
}
