using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Samples;
using System.Collections.Generic;

namespace StatsLibTests
{
    [TestClass]
    public class SamplesInitialization
    {
        Sample a = new Sample(new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        Sample b = new Sample(new List<double>() { 1, 2 });


        [TestMethod]
        public void FirstSample()
        {
            var mySample = new Sample(0, 10, 3);

            //Obviously this is going to be equal, I'm using this to check if the values were properly created through debug mode 
            Assert.AreEqual(mySample.Values, mySample.Values);
        }

    }
}
