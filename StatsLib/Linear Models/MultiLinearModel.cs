using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using StatsLib.Interfaces;
using StatsLib.Utility;
using StatsLib.Linear_Models;
using StatsLib.Tests;

namespace StatsLib.Regression
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
            var jaggedX = new double[dataColumns[0].Table.Columns.Count + 1][];


            for (var i = 0; i <= dataColumns[0].Table.Columns.Count; i++)
            {
                jaggedX[i] = new double[dataColumns[0].Table.Rows.Count];
            }

            //Our 1s vector
            for (var i = 0; i < dataColumns[0].Table.Rows.Count; i++)
            {
                jaggedX[0][i] = 1;
            }

            var index = 1;
            foreach (var dataColumn in dataColumns)
            {
                jaggedX[index] = dataColumn.Table.Rows.Cast<DataRow>()
                    .Select(row => (double)row[dataColumn.ColumnName])
                    .ToArray();
                ++index;
            }

            //This may seem inefficient but I would rather have something clear for the user to input. With a 2d array the X and Y values
            //are much clearer than the jagged array we had
            var matrixX = jaggedX.To2D();

            var matrixXTranspose = matrixX.ToTranspose();

            var xTransposeX = Matrix.Multiply(matrixXTranspose, matrixX);

            var inverse = Matrix.Inverse(xTransposeX);
        }

    
    }
}

