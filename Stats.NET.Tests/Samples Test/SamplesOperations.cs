using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Samples;
using System.Collections.Generic;

namespace StatsLibTests
{
    [TestClass]
    public class SamplesOperations
    {
        Sample a = new Sample(new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        Sample b = new Sample(new List<double>() { 1, 2 });


        [TestMethod]
        public void UnionTest()
        {
            var expected = new Sample(new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(expected.Values, a.Union(b).Values);
            CollectionAssert.AreEqual(expected.Values, (a | b).Values);


        }

        [TestMethod]
        public void IntersectionTest()
        {
            var expected = new Sample(new List<double> { 1, 2 });
            CollectionAssert.AreEqual(expected.Values, a.Intersect(b).Values);
            CollectionAssert.AreEqual(expected.Values, (a & b).Values);

        }

        [TestMethod]
        public void AddTest()
        {
            var expected = new Sample(new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2 });
            CollectionAssert.AreEqual(expected.Values, a.Add(b).Values);
            CollectionAssert.AreEqual(expected.Values, (a + b).Values);

        }

        [TestMethod]
        public void Subtract()
        {
            var expected = new Sample(new List<double> {  3, 4, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(expected.Values, a.Subtract(b).Values);
            CollectionAssert.AreEqual(expected.Values, (a - b).Values);
        }

    }
}
