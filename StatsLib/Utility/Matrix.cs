using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Utility
{
    public static class Matrix
    {
        public static double[][] ToTranspose(this double[][] matrix)
        {
            var rowCount = matrix.Length;
            var columnCount = matrix[0].Length;
            var transposed = new double[columnCount][];


            if (rowCount == columnCount)
            {
                transposed = (double[][]) matrix.Clone();
                for (var i = 1; i < rowCount; i++)
                {
                    for (var j = 0; j < i; j++)
                    {
                        double temp = transposed[i][j];
                        transposed[i][j] = transposed[j][i];
                        transposed[j][i] = temp;
                    }
                }
            }
            else
            {
                for (var column = 0; column < columnCount; column++)
                {
                    transposed[column] = new double[rowCount];
                    for (var row = 0; row < rowCount; row++)
                    {
                        transposed[column][row] = matrix[row][column];
                    }
                }
            }
            return transposed;
        }

    }
}
