using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.LinearAlgebra;

namespace Stats.NET.Tests.Matrix_Test
{
    [TestClass]
    public class MatrixUtilityTesting
    {
        //It is important to note that those arrays inside the jagged arrays are VERTICAL VECTORS
        public static double[][] JaggedTestArray =
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

        public static double[,] MultiDimTestArray = new double[,]
        {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
        };

        [TestMethod]
        public void InitializeJagged()
        {
            var matrix = new Matrix(JaggedTestArray);

            for (int i = 0; i < JaggedTestArray.GetLength(0); ++i)
            {
                for (int j = 0; j < JaggedTestArray[0].Length; ++j)
                {
                    Assert.AreEqual(matrix.ListOfRows[i][j], JaggedTestArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void InitializeMultiDim()
        {
            var matrix = new Matrix(MultiDimTestArray);

            for (int i = 0; i < MultiDimTestArray.GetLength(0); ++i)
            {
                for (int j = 0; j < MultiDimTestArray.GetLength(1); ++j)
                {
                    Assert.AreEqual(matrix.ListOfRows[i][j], MultiDimTestArray[i, j]);
                }
            }
        }

        [TestMethod]
        public void ToTranspose()
        {
            var transposedMatrix = new Matrix(JaggedTestArray).ToTranspose();

            var transpose = new double[,]
            {
                {1, 6, 11},
                {2, 7, 12},
                {3, 8, 13},
                {4, 9, 14},
                {5, 10, 15}
            };

            for (int i = 0; i < JaggedTestArray[0].Length; ++i)
            {
                for (int j = 0; j < JaggedTestArray.GetLength(0); ++j)
                {
                    Assert.AreEqual(transposedMatrix.ListOfRows[i][j], transpose[i, j]);
                }
            }
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

            var mat1 = new Matrix(arr1);
            var mat2 = new Matrix(arr2);

            var solutionMat = mat1 * mat2;

            for (int i = 0; i < solution.GetLength(0); ++i)
            {
                for (int j = 0; j < solution.GetLength(1); ++j)
                {
                    Assert.AreEqual(solutionMat.ListOfRows[i][j], solution[i, j]);
                }
            }
        }

        [TestMethod]
        public void Add()
        {
            var solution = new double[,]
            {
                {2,4,6,8,10 },
                {12,14,16,18,20 },
                {22,24,26,28,30 },
            };

            var mat1 = new Matrix(JaggedTestArray);
            var mat2 = new Matrix(MultiDimTestArray);

            var solutionMat = mat1 + mat2;

            for (int i = 0; i < solution.GetLength(0); ++i)
            {
                for (int j = 0; j < solution.GetLength(1); ++j)
                {
                    Assert.AreEqual(solutionMat.ListOfRows[i][j], solution[i, j]);
                }
            }
        }

        [TestMethod]
        public void Subtract()
        {
            var solution = new double[,]
            {
                {0,0,0,0,0 },
                {0,0,0,0,0 },
                {0,0,0,0,0 },
            };

            var mat1 = new Matrix(JaggedTestArray);
            var mat2 = new Matrix(MultiDimTestArray);

            var solutionMat = mat1 - mat2;

            for (int i = 0; i < solution.GetLength(0); ++i)
            {
                for (int j = 0; j < solution.GetLength(1); ++j)
                {
                    Assert.AreEqual(solutionMat.ListOfRows[i][j], solution[i, j]);
                }
            }
        }

        [TestMethod]
        public void ColumnBind()
        {
            var solution = new double[,]
            {
                {1,2,3,4,5,1,2,3,4,5 },
                {6, 7, 8, 9, 10, 6, 7, 8, 9, 10 },
                {11, 12, 13, 14, 15, 11, 12, 13, 14, 15 },
            };

            var mat1 = new Matrix(JaggedTestArray);
            var mat2 = new Matrix(MultiDimTestArray);

            var testMatrix = mat1.ColumnBind(mat2);

            for (int i = 0; i < solution.GetLength(0); ++i)
            {
                for (int j = 0; j < solution.GetLength(1); ++j)
                {
                    Assert.AreEqual(testMatrix.ListOfRows[i][j], solution[i, j]);
                }
            }
        }
    }
}
