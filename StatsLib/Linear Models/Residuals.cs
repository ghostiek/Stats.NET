using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Linear_Models
{
    public class Residuals
    {
        public List<double?> Errors { get; private set; }

        public List<double?> StandardizedErrors { get; private set; }

        public double? SumSquaredErrors { get; private set; }

        public double? MeanSquaredErrors { get; private set; }

        public double? ResidualSquaredErrors { get; private set; }

        public int DegreeOfFreedom { get; private set; }

        public Residuals(List<double?> predictedValue, List<double?> actualValue, int degreeOfFreedom)
        {
            DegreeOfFreedom = degreeOfFreedom;
            Errors = new List<double?>();
            StandardizedErrors = new List<double?>();
            for(int i = 0; i < predictedValue.Count; i++)
            {
                Errors.Add(actualValue[i] - predictedValue[i]);
                StandardizedErrors.Add(Errors[i] / Math.Sqrt(predictedValue[i].Value));
            }
            SumSquaredErrors = Errors.Sum(x => x * x);
            MeanSquaredErrors = SumSquaredErrors / (DegreeOfFreedom);
            ResidualSquaredErrors = Math.Sqrt(MeanSquaredErrors.Value);
        }
    }
}
