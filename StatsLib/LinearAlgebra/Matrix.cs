using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.LinearAlgebra
{
    public class Matrix
    {
        public List<List<double>> ListOfRows { get; private set; }

        public Matrix(double[][] source)
        {
            ListOfRows = new List<List<double>>();
            ListOfRows = source.Select(x => x.ToList()).ToList();

            foreach(var row in ListOfRows)
            {
                if(row.Count != ListOfRows[0].Count)
                    throw new InvalidOperationException("The given jagged array is not rectangular.");
            }

        }

        public Matrix(double[,] source)
        {
            ListOfRows = new List<List<double>>();
            for(int i = 0; i < source.GetLength(0); ++i)
            {
                var temp = new List<double>();
                for(int j = 0; j < source.GetLength(1); ++j)
                {
                    temp.Add(source[i,j]);
                }
                ListOfRows.Add(temp);
            }
        }

        public Matrix(List<List<double>> listOfRows)
        {         
            ListOfRows = listOfRows;

            foreach (var row in ListOfRows)
            {
                if (row.Count != ListOfRows[0].Count)
                    throw new InvalidOperationException("The given List of List<double> is not rectangular.");
            }
        }

        public Matrix ToTranspose()
        {
            var rowCount = ListOfRows.Count;
            var columnCount = ListOfRows[0].Count;

            var transposed = new List<List<double>>();

            if (rowCount == columnCount)
            {
                transposed = ListOfRows;
                for (int i = 1; i < rowCount; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        var temp = transposed[i][j];
                        transposed[i][j] = transposed[j][i];
                        transposed[j][i] = temp;
                    }
                }
            }
            else
            {
                for (int column = 0; column < columnCount; column++)
                {
                    var temp = new List<double>();
                    for (int row = 0; row < rowCount; row++)
                    {
                        temp.Add(ListOfRows[row][column]);
                    }
                    transposed.Add(temp);
                }
            }
            return new Matrix(transposed);
        }

        public Matrix Add(Matrix matrix)
        {
            if (ListOfRows.Count != matrix.ListOfRows.Count || ListOfRows[0].Count != matrix.ListOfRows[0].Count)
                throw new ArgumentException(
                    "The dimmensions of the matrices are not the same");

            var finalMatrix = new double[ListOfRows.Count, ListOfRows[0].Count];

            for (int i = 0; i < ListOfRows.Count; ++i)
            {
                for (int j = 0; j < ListOfRows[0].Count; ++j)
                {
                    finalMatrix[i, j] = ListOfRows[i][j] + matrix.ListOfRows[i][j];
                }
            }

            return new Matrix(finalMatrix);
        }

        public Matrix Subtract(Matrix matrix)
        {
            if (ListOfRows.Count != matrix.ListOfRows.Count || ListOfRows[0].Count != matrix.ListOfRows[0].Count)
                throw new ArgumentException(
                    "The dimmensions of the matrices are not the same");

            var finalMatrix = new double[ListOfRows.Count, ListOfRows[0].Count];

            for (int i = 0; i < ListOfRows.Count; ++i)
            {
                for (int j = 0; j < ListOfRows[0].Count; ++j)
                {
                    finalMatrix[i, j] = ListOfRows[i][j] - matrix.ListOfRows[i][j];
                }
            }

            return new Matrix(finalMatrix);
        }

        public Matrix Multiply(Matrix matrix)
        {
            if (ListOfRows[0].Count != matrix.ListOfRows.Count)
                throw new ArgumentException(
                    "The number of columns of the 1st Matrix is not equal to the number of rows of the 2nd Matrix");

            var finalMatrix = new double[ListOfRows.Count, matrix.ListOfRows[0].Count];


            for (int i = 0; i < ListOfRows.Count; ++i)
            {
                for (int j = 0; j < matrix.ListOfRows[0].Count; ++j)
                {
                    for (int k = 0; k < ListOfRows[0].Count; ++k)
                    {
                        finalMatrix[i, j] += ListOfRows[i][k] * matrix.ListOfRows[k][j];
                    }
                }
            }
            return new Matrix(finalMatrix);
        }

        public Matrix Inverse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Binds a matrix by column to the right
        /// </summary>
        /// <param name="rightMatrix"></param>
        /// <returns></returns>
        public Matrix ColumnBind(Matrix rightMatrix)
        {
            if(ListOfRows.Count != rightMatrix.ListOfRows.Count)
            {
                throw new ArgumentException("Matrices do not have the same number of Rows");
            }

            var finalList = new List<List<double>>();
            for(int i = 0; i < ListOfRows.Count; ++i)
            {
                finalList.Add(ListOfRows[i].Concat(rightMatrix.ListOfRows[i]).ToList());
            }
            return new Matrix(finalList);
        }

        /// <summary>
        /// Binds a matrix by row, under the matrix making the call
        /// </summary>
        /// <param name="underMatrix"></param>
        /// <returns></returns>
        public Matrix RowBind(Matrix underMatrix)
        {
            if (ListOfRows[0].Count != underMatrix.ListOfRows[0].Count)
            {
                throw new ArgumentException("Matrices do not have the same number of Columns");
            }

            var finalList = ListOfRows.Concat(underMatrix.ListOfRows).ToList();

            return new Matrix(finalList);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB) => matrixA.Multiply(matrixB);
        public static Matrix operator +(Matrix matrixA, Matrix matrixB) => matrixA.Add(matrixB);
        public static Matrix operator -(Matrix matrixA, Matrix matrixB) => matrixA.Subtract(matrixB);
    }
}
