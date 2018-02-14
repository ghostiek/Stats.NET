using System;
using StatsLib.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.LinearModels
{
    public class Coefficients
    {
        public List<double> SumSquaredRegression { get; private set; }

        //Has DoF 1, so its the same
        public List<double> MeanSquaredRegression { get; private set; }

        public List<double?> Beta { get; private set; }

        public List<double?> StandardErrors { get; private set; }

        public List<TTest> TStatistic { get; private set; }

        public Coefficients(double? intercept, List<double?> beta, List<double?> standardErrors, List<double?> X, List<double?> Y, Func<double?, double?> model)
        {
            beta.Insert(0, intercept);
            Beta = beta;

            StandardErrors = standardErrors;

            TStatistic = new List<TTest>();

            for(var i = 0; i < Beta.Count; i++)
            {
                TStatistic.Add(new TTest(Beta[i], StandardErrors[i]));
            }

            SumSquaredRegression = new List<double>() { X.Sum(x => Math.Pow((model(x) - Y.Average()).Value, 2)) };
            MeanSquaredRegression = SumSquaredRegression;

        }

        public Coefficients(List<double?> beta, List<double?> standardErrors, List<double?> X, List<double?> Y, Func<double?, double?> model)
        {
            Beta = beta;

            StandardErrors = standardErrors;

            TStatistic = new List<TTest>();

            for (var i = 0; i < Beta.Count; i++)
            {
                TStatistic.Add(new TTest(Beta[i], StandardErrors[i]));
            }

            SumSquaredRegression = new List<double>() { X.Sum(x => Math.Pow((model(x) - Y.Average()).Value, 2)) };
            MeanSquaredRegression = SumSquaredRegression;
        }
    }
}
