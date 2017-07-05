using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Gamma : ParameterLimits, IDistribution, IProbability
    {
        public Gamma(double alpha, double beta)
        {
            Alpha = alpha;
            Beta = beta;
        }
        public double GetMean()
        {
            return Alpha * Beta;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return Alpha * Beta * Beta;
        }

        public string GetMGF()
        {
            throw new NotImplementedException();
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityLessThan(double input)
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            return GetProbabilityLessThan(input);
        }

        public double GetProbabilityMoreThanOrEqual(double input)
        {
            return 1 - GetProbabilityLessThan(input);
        }

        public double GetProbabilityMoreThan(double input)
        {
            return 1 - GetProbabilityLessThanOrEqual(input);
        }


    }
}
