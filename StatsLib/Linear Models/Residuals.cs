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

        public double? SumSquaredErrors => Errors.Sum(x => x * x);

        public double? MeanSquaredErrors => SumSquaredErrors / (DegreeOfFreedom);

        public double? ResidualSquaredErrors => Math.Sqrt(MeanSquaredErrors.Value);

        public int DegreeOfFreedom { get; private set; }

        public Residuals(List<double?> predictedValue, List<double?> actualValue, int degreeOfFreedom)
        {
            DegreeOfFreedom = degreeOfFreedom;
            Errors = new List<double?>();
            for(int i = 0; i < predictedValue.Count; i++)
            {
                Errors[i] = actualValue[i] - predictedValue[i];
                StandardizedErrors[i] = Errors[i] / Math.Sqrt(predictedValue[i].Value);
            }
        }
    }
}
