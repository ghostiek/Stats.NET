using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class Geometric : ParameterLimits, IDistribution, IProbability
    {
        public Geometric(double probability)
        {
            Probability = probability;
        }

        public double GetMean()
        {
            return 1 / Probability;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return (1 - Probability) / Math.Pow(Probability, 2);
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
            if (input < 1) throw new ArgumentOutOfRangeException("Parameter cannot be smaller than 1");
            double solution = 0;
            for (int i = 0; i < input; i++)
            {
                solution += Stats.GetExactGeometricProbability(Probability, i);
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 1) throw new ArgumentOutOfRangeException("Parameter cannot be smaller than 1");
            double solution = 0;
            for (int i = 0; i <= input; i++)
            {
                solution += Stats.GetExactGeometricProbability(Probability, i);
            }
            return solution;
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
