using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Utility;

namespace Stats.NET.Tests.Utility_Tests
{
    [TestClass]
    public class MatrixUtilityTesting
    {
        //It is important to note that those arrays inside the jagged arrays are VERTICAL VECTORS
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
        public void To2DTest()
        {
            var multidimArray = new double[,]
            {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
            };

            var test = TestArray.To2D();

            CollectionAssert.AreEqual(multidimArray, test);

        }

        [TestMethod]
        public void ToTranspose()
        {
            var test = TestArray.To2D().ToTranspose();

            var transpose = new double[,]
            {
                {1, 6, 11},
                {2, 7, 12},
                {3, 8, 13},
                {4, 9, 14},
                {5, 10, 15}
            };

            CollectionAssert.AreEqual(transpose, test);
        }

        [TestMethod]
        public void Mult()
        {

            var arr1 = new double[,]
            {
                {5, 1, 7},
                {9, 20, 12},
                {1, 0, 9},
                {1,2,5 }
            };

            var arr2 = new double[,]
            {
                {1, 2, 3, 1},
                {5, 7, 8, 2},
                {10, 12, 14, 0}
            };

            var solution = new double[,]
            {
                {80,101,121,7 },
                {229,302,355,49 },
                {91, 110,129,1 },
                {61, 76, 89, 5 }
            };
            var test = Matrix.Multiply(arr1, arr2);

            CollectionAssert.AreEqual(solution, test);

        }
    }
}
