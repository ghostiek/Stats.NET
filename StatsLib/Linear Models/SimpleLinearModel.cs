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

        public Func<double?, double?> Model => (double? x) => Slopes.Beta[0] + Slopes.Beta[1] * x;

        public double RSquared => Slopes.SumSquaredRegression.Sum(x => x.Value) / SumSquaredTotal;

        public double RSquaredAdjusted => 1 - ((1 - RSquared) * (DegreeOfFreedom - 1) / (DegreeOfFreedom - 2));

        public double SumSquaredTotal => Slopes.SumSquaredRegression.Sum(x => x.Value) + Residuals.SumSquaredErrors.Value;

        public double MeanSquaredTotal => Slopes.MeanSquaredRegression.Sum(x => x.Value) + Residuals.SumSquaredErrors.Value;



        public SimpleLinearModel(DataColumn independentVariable, DataColumn dependentVariable)
        {
            if (independentVariable.Table.Rows.Count != dependentVariable.Table.Rows.Count)
                throw new ArgumentException("The DataColumns do not have the same length");

            var model = GetCoefs(independentVariable, dependentVariable).GetResiduals(independentVariable, dependentVariable);
        }

        private SimpleLinearModel GetCoefs(DataColumn independentVariable, DataColumn dependentVariable)
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

            //sum((mtcars$mpg-pred)^2)/(nrow(mtcars)-2))
            var sigma = Math.Sqrt(Y.Sum(x => Math.Pow(x.Value - Model(x).Value, 2))) / (counter - 2);

            var SXX = X.Sum(x => x - X.Average()).Value;
            var interceptStdError = sigma * Math.Sqrt(1 / counter + Math.Pow(X.Average().Value, 2) / SXX);

            var slopeStdError = sigma / Math.Sqrt(SXX);

            var stdErrors = new List<double?>() { interceptStdError, slopeStdError };

            Slopes = new Coefficients(intercept, new List<double?> { slope }, stdErrors);
            return this;
        }

        private SimpleLinearModel GetResiduals(DataColumn independentVariable, DataColumn dependentVariable)
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

                actualValue[counter] = y;
                predictedValue[counter] = Slopes.Beta[0] + Slopes.Beta[1] * x;
                counter++;
            }

            DegreeOfFreedom = predictedValue.Count - 2;

            Residuals = new Residuals(predictedValue, actualValue, DegreeOfFreedom);

            return this;
        }
    }
}   
