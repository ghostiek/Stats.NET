using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using StatsLib.Interfaces;
using StatsLib.Utility;
using StatsLib.Tests;
using StatsLib.LinearAlgebra;

namespace StatsLib.LinearModels
{
    public class MultiLinearModel : IMultiLinearModel
    {
        public Coefficients Slopes { get; private set; }

        public FTest FStatistic { get; private set; }

        public int DegreeOfFreedom { get; private set; }

        public Residuals Residuals { get; private set; }

        public Func<IEnumerable<double?>, double?> Model { get; private set; }

        public double RSquared { get; private set; }

        public double RSquaredAdjusted { get; private set; }

        public double SumSquaredTotal { get; private set; }

        public double MeanSquaredTotal { get; private set; }

        public MultiLinearModel(IEnumerable<DataColumn> independentVariables, DataColumn dependentVariable)
        {
            //Checks through to see if the columns aren't the same lengths

            var dataColumns = independentVariables as IList<DataColumn> ?? independentVariables.ToList();

            if (dataColumns.Any(dataColumn => dataColumn.Table.Rows.Count != dependentVariable.Table.Rows.Count))
            {
                throw new ArgumentException("The DataColumns do not have the same length");
            }

            //Creating our X Predictor Matrix
            var jaggedX = new double[dataColumns[0].Table.Columns.Count][];


            for (var i = 0; i < dataColumns[0].Table.Columns.Count; i++)
            {
                jaggedX[i] = new double[dataColumns[0].Table.Rows.Count];
            }

            //Our 1s vector
            var onesVector = new double[1][];
            for (var i = 0; i < dataColumns[0].Table.Rows.Count; i++)
            {
                onesVector[0][i] = 1;
            }

            var index = 0;
            foreach (var dataColumn in dataColumns)
            {
                jaggedX[index] = dataColumn.Table.Rows.Cast<DataRow>()
                    .Select(row => (double)row[dataColumn.ColumnName])
                    .ToArray();
                ++index;
            }
            var onesMatrix = new Matrix(onesVector);
            var matrixX = new Matrix(jaggedX);

            var X = matrixX.ColumnBind(onesMatrix);

            var jaggedY = new double[1][];
            jaggedY[1] = new double[dataColumns[0].Table.Rows.Count];
            jaggedY[1] = dependentVariable.Table.Rows.Cast<DataRow>()
                            .Select(row => (double)row[dependentVariable.ColumnName])
                            .ToArray();

            var Y = new Matrix(jaggedY);

            var slopesMatrix = (X.ToTranspose() * X).Inverse() * X.ToTranspose() * Y;

            var slopes = slopesMatrix.ListOfRows[0];
        }

        //This may seem inefficient but I would rather have something clear for the user to input. With a 2d array the X and Y values
        //are much clearer than the jagged array we had
        //var matrixX = jaggedX.To2D();

        //var matrixXTranspose = matrixX.ToTranspose();

        //var xTransposeX = Matrix.Multiply(matrixXTranspose, matrixX);

        //var inverse = Matrix.Inverse(xTransposeX);
    }


}

