using System;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Discrete
{
    public class Rademacher : IDistribution
    {
        public const double Probability = 0.5;

        #region IDistribution Methods
        public double GetMean()
        {
            return 0;
        }

        public double GetVariance()
        {
            return 1;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetMgf(double t)
        {
            return Math.Cosh(t);
        }

        public string GetPmf()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
