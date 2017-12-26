using System;
using System.Data;
using System.Collections.Generic;
using StatsLib.Tests;
using StatsLib.Utility;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatsLib.Interfaces;

namespace StatsLib.Linear_Models
{
    public class SimpleLinearModel : ISimpleLinearModel
    {
        public Coefficients Slopes { get; private set; }

        public FTest FStatistic { get; private set; }

        public int DegreeOfFreedom { get; private set; }

        public Residuals Residuals { get; private set; }

        public Func<double?, double?> Model { get; private set; }

        public double RSquared { get; private set; }

        public double RSquaredAdjusted { get; private set; }

        public double SumSquaredTotal { get; private set; }

        public double MeanSquaredTotal { get; private set; }

        public SimpleLinearModel(DataColumn independentVariable, DataColumn dependentVariable)
        {
            if (independentVariable.Table.Rows.Count != dependentVariable.Table.Rows.Count)
                throw new ArgumentException("The DataColumns do not have the same length");

            GetCoefs(independentVariable, dependentVariable);
            GetResiduals(independentVariable, dependentVariable);

            SumSquaredTotal = Slopes.SumSquaredRegression.Sum() + Residuals.SumSquaredErrors.Value;
            MeanSquaredTotal = Slopes.MeanSquaredRegression.Sum() + Residuals.SumSquaredErrors.Value;

            RSquared = Slopes.SumSquaredRegression.Sum() / SumSquaredTotal;
            RSquaredAdjusted = 1 - ((1 - RSquared) * (DegreeOfFreedom - 1) / (DegreeOfFreedom - 2));
            FStatistic = new FTest(this);
            
        }

        private void GetCoefs(DataColumn independentVariable, DataColumn dependentVariable)
        {
            var Y = new List<double?>();
            var X = new List<double?>();
            double? sumY = 0.0;
            double? sumX = 0.0;
            double? sumXSquared = 0.0;
            double? sumXY = 0.0;
            int counter = 0;

            foreach (DataRow row in independentVariable.Table.Rows)
            {
                var x = row[independentVariable] as double?;
                var y = row[dependentVariable] as double?;

                if (x == null || y == null)
                {
                    continue;
                }
                //Number of values that we have iterated through, we skip this is x or y is null
                ++counter;
                sumX += x;
                sumY += y;
                sumXSquared += x * x;
                sumXY += x * y;
                Y.Add(y);
                X.Add(x);
            }

            var intercept = (sumY * sumXSquared - sumX * sumXY) / (counter * sumXSquared - sumX * sumX);
            var slope = (counter * sumXY - sumX * sumY) / (counter * sumXSquared - sumX * sumX);

            Model = (double? x) => intercept + slope * x;
            //sum((mtcars$mpg-pred)^2)/(nrow(mtcars)-2))

            var sigma = 0.0;
            var predictedVals = X.Select(x => Model(x)).ToList();
            for(int i = 0; i < Y.Count; i++)
            {
                sigma += Math.Pow((Y[i] - predictedVals[i]).Value, 2);
            }
            sigma = Math.Sqrt(sigma / (counter - 2));

            var SXX = X.Sum(x => Math.Pow((x - X.Average()).Value, 2));

            var interceptStdError = sigma * Math.Sqrt((1.0 / counter) + (Math.Pow(X.Average().Value, 2) / SXX));

            var slopeStdError = sigma / Math.Sqrt(SXX);

            var stdErrors = new List<double?>() { interceptStdError, slopeStdError };

            Slopes = new Coefficients(intercept, new List<double?> { slope }, stdErrors, X, Y, Model);
        }

        private void GetResiduals(DataColumn independentVariable, DataColumn dependentVariable)
        {
            var actualValue = new List<double?>();
            var predictedValue = new List<double?>();
            int counter = 0;

            foreach (DataRow row in dependentVariable.Table.Rows)
            {
                var x = row[independentVariable] as double?;
                var y = row[dependentVariable] as double?;
                if (x == null || y == null)
                {
                    //We need to make sure to skip again so we have the same length as we did in the previous loop
                    continue;
                }

                actualValue.Add(y);
                predictedValue.Add(Slopes.Beta[0] + Slopes.Beta[1] * x);
                counter++;
            }

            DegreeOfFreedom = predictedValue.Count - 2;

            Residuals = new Residuals(predictedValue, actualValue, DegreeOfFreedom);
        }
    }
}   
