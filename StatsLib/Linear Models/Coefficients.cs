using System;
using StatsLib.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Linear_Models
{
    public class Coefficients
    {
        public List<double?> SumSquaredRegression { get; private set; }

        //Has DoF 1, so its the same
        public List<double?> MeanSquaredRegression => SumSquaredRegression;

        public List<double?> Beta { get; private set; }

        public List<double?> StandardErrors { get; private set; }

        public List<TTest> TStatistic { get; private set; }

        public Coefficients(double? intercept, List<double?> beta, List<double?> standardErrors)
        {
            beta.Insert(0, intercept);
            Beta = beta;

            StandardErrors = standardErrors;

            TStatistic = new List<TTest>();

            for(var i = 0; i < Beta.Count; i++)
            {
                TStatistic.Add(new TTest(Beta[i], StandardErrors[i]));
            }

        }

        public Coefficients(List<double?> beta, List<double?> standardErrors)
        {
            Beta = beta;

            StandardErrors = standardErrors;

            TStatistic = new List<TTest>();

            for (var i = 0; i < Beta.Count; i++)
            {
                TStatistic.Add(new TTest(Beta[i], StandardErrors[i]));
            }
        }
    }
}
