using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Exponential : ParameterLimits, IDistribution, IProbability
    {
        public Exponential(double lambda)
        {
            Lambda = lambda;
        }
        public double GetMean()
        {
            return 1 / Lambda;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return 1 / Math.Pow(Lambda, 2);
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
            if (input < 0) throw new ArgumentOutOfRangeException("Input cannot be smaller than 0");
            else return 1 - Math.Pow(Math.E, -Lambda * input);
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
