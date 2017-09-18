using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Samples;
using System.Collections.Generic;
using System;

namespace StatsLibTests
{
    [TestClass]
    public class SamplesInitialization
    {
        Sample a = new Sample(new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        Sample b = new Sample(new List<double>() { 1, 2 });


        [TestMethod]
        public void SecondCtorDefault()
        {
            var mySample = new Sample(0, 10, 3);

            //Obviously this is going to be equal, I'm using this to check if the values were properly created through debug mode 
            Assert.AreEqual(mySample.Values, mySample.Values);
        }

        [TestMethod]
        public void SecondCtorUnique()
        {
            var mySample = new Sample(0, 10, 3, true);
                
            //Obviously this is going to be equal, I'm using this to check if the values were properly created through debug mode 
            Assert.AreEqual(mySample.Values, mySample.Values);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SecondCtorException()
        {
            var mySample = new Sample(0, 3, 10, true);
        }

        [TestMethod]
        public void ThirdCtorDefault()
        {
            var mySample = new Sample(0.0, 10, 10);

            //Obviously this is going to be equal, I'm using this to check if the values were properly created through debug mode 
            Assert.AreEqual(mySample.Values, mySample.Values);
        }

        [TestMethod]
        public void FourthCtorDefault()
        {
            var mySample = new Sample(0, 4, 5, new List<double> { 0.6, 0.3, 0.05, 0.05, 0 });

            //Obviously this is going to be equal, I'm using this to check if the values were properly created through debug mode 
            Assert.AreEqual(mySample.Values, mySample.Values);
        }

    }
}
