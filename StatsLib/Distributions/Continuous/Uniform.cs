using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Uniform : ParameterLimits, IDistribution, IProbability
    {
        public Uniform(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
        public double GetMean()
        {
            return (LowerBound + UpperBound) / 2;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return Math.Pow(UpperBound - LowerBound, 2) / 12;
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
            double solution = 0;
            for (double i = LowerBound; i <= UpperBound; i++)
            {
                solution += 1 / (UpperBound - i);
            }
            return solution;
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
