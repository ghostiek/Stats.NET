using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Utility;

namespace Stats.NET.Tests.Utility_Tests
{
    [TestClass]
    public class MatrixUtilityTesting
    {
        public static double[][] TestArray =
        {
            new double[]
            {
                1, 2, 3, 4, 5
            },
            new double[]
            {
                6, 7, 8, 9, 10
            },
            new double[]
            {
                11, 12, 13, 14, 15
            }
        };

        [TestMethod]
        public void TestMethod1()
        {
            //Note, I would be using Multi-dim arrays over jagged but I can't because DataTable won't let me do it cleanly.
            //It is important to note that those arrays inside the jagged arrays are VERTICAL VECTORS
            var transpose = new double[][]
            {
                new double[]
                {
                    1, 6, 11
                },
                new double[]
                {
                    2, 7, 12
                },
                new double[]
                {
                    3, 8, 13
                },
                new double[]
                {
                    4, 9, 14
                },
                new double[]
                {
                    5, 10, 15
                }

            };
            var test = TestArray.ToTranspose();

        }
    }
}
