using System;
using System.Data;
using System.Collections.Generic;
using StatsLib.Utility;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatsLib.Interfaces;

namespace StatsLib.Regression
{
    public class SimpleLinearModel : ISimpleLinearRegression
    {
        public double? Intercept { get; private set; }
        public double? Slope { get; private set; }
        public List<double?> Residuals { get; private set; }


        public SimpleLinearModel(DataColumn independentVariable, DataColumn dependentVariable)
        {
            if (independentVariable.Table.Rows.Count != dependentVariable.Table.Rows.Count)
                throw new ArgumentException("The DataColumns do not have the same length");

            double? sumY = 0.0;
            double? sumX = 0.0;
            double? sumXSquared = 0.0;
            double? sumXY = 0.0;
            int counter = 0;

            foreach (DataRow row in independentVariable.Table.Rows)
            {
                var x = row[independentVariable] as double?;
                var y = row[dependentVariable] as double?;

                if ((x ?? y) == null)
                {
                    continue;
                }
                //Number of values that we have iterated through, we skip this is x or y is null
                ++counter;
                sumX += x;
                sumY += y;
                sumXSquared += x * x;
                sumXY += x * y;
            }

            Intercept = (sumY * sumXSquared - sumX * sumXY) / (counter * sumXSquared - sumX * sumX);

            Slope = (counter * sumXY - sumX * sumY) / (counter * sumXSquared - sumX * sumX);

            Residuals = new List<double?>();
            foreach (DataRow row in dependentVariable.Table.Rows)
            {
                var x = row[independentVariable] as double?;
                var y = row[dependentVariable] as double?;
                if ((x ?? y) == null)
                {
                    //We need to make sure to skip again so we have the same length as we did in the previous loop
                    continue;
                }

                var predictedValue = Intercept + Slope * x;
                Residuals.Add(y-predictedValue);
            }
        }   


        
    }
}
