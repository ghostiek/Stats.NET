using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Regression
{
    public class MultiLinearRegression
    {

        public double? Intercept { get; private set; }
        public double? Slope { get; private set; }
        public List<double?> Residuals { get; private set; }


        public MultiLinearRegression(IEnumerable<DataColumn> independentVariables, DataColumn dependentVariable)
        {
            //For optimization purposes

            //Checks through to see if the columns aren't the same lengths

            var dataColumns = independentVariables as IList<DataColumn> ?? independentVariables.ToList();
            if (dataColumns.Any(dataColumn => dataColumn.Table.Rows.Count != dependentVariable.Table.Rows.Count))
            {
                throw new ArgumentException("The DataColumns do not have the same length");
            }
            //Creating our X Predictor Matrix
            var X = new double[dataColumns[0].Table.Columns.Count + 1][];


            for (var i = 0; i <= dataColumns[0].Table.Columns.Count; i++)
            {
                X[i] = new double[dataColumns[0].Table.Rows.Count];
            }

            //Our 1s vector
            for (var i = 0; i < dataColumns[0].Table.Rows.Count; i++)
            {
                X[0][i] = 1;
            }

            var index = 1;
            foreach (var dataColumn in dataColumns)
            {
                X[index] = dataColumn.Table.Rows.Cast<DataRow>()
                    .Select(row => (double)row[dataColumn.ColumnName])
                    .ToArray();
                ++index;
            }


            //var X = new double[dataColumns.Count, dataColumns[0].Table.Rows.Count];

            ////Initialize first column to be all 1s
            //for (var i = 0; i < dataColumns[0].Table.Rows.Count; i++)
            //{
            //    X[0, i] = 1;
            //}

            //for (int i = 0; i < UPPER; i++)
            //{

            //}


        }



    }
}

