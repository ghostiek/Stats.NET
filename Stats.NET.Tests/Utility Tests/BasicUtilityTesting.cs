﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Utility;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StatsLibTests.BasicUtility
{
    [TestClass]
    public class ExtensionsTesting
    {
        public List<double> li = new List<double>() { 1, 2, 3, 4, 5 };

        [TestMethod]
        public void ArithmeticMean()
        {
            var mean = Stat.ArithmeticMean(li);
            Assert.AreEqual(3, mean);
        }

        [TestMethod]
        public void GeometricMean()
        {
            var mean = Stat.GeometricMean(li);
            Assert.AreEqual(2.605, Math.Round(mean, 3));
        }

        [TestMethod]
        public void HarmonicMean()
        {
            var mean = Stat.HarmonicMean(li);
            Assert.AreEqual(300.0 / 137, mean);
        }

        [TestMethod]
        public void SD()
        {
            var sd = Stat.StandardDeviation(li);
            Assert.AreEqual(Math.Sqrt(5 / 2), sd);
        }

        [TestMethod]
        public void OddMedianSorted()
        {
            var median = Stat.Median(li);
            Assert.AreEqual(3, median);
        }

        [TestMethod]
        public void EvenMedianNotSorted()
        {
            var otherli = li;
            otherli.Add(2.5);
            var median = Stat.Median(li);
            Assert.AreEqual(2.75, median);
        }

        [TestMethod]
        public void CummulativeSummation()
        {
            var csum = Stat.CumSum(li);
            var expected = new List<double>() { 1, 3, 6, 10, 15 };
            CollectionAssert.AreEqual(expected, csum.ToList());
        }

        [TestMethod]
        public void ModeMultiple()
        {
            var otherli = li;
            otherli.Add(1);
            otherli.Add(2);

            var expectedLi = new List<double> { 1, 2 };
            var expectedMode = new Mode(expectedLi, 2);
            var mode = Stat.Mode(li);
            Assert.AreEqual(expectedMode.Frequency, mode.Frequency);
            CollectionAssert.AreEqual(expectedMode.Modes.ToList(), mode.Modes.ToList());
        }

    }
}
