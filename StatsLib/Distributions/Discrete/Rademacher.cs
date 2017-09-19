using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Rademacher : IDistribution
    {
        private const double probability = 0.5;

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

        public double GetMGF(double t)
        {
            return Math.Cosh(t);
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
