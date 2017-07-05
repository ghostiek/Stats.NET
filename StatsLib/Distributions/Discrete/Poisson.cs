using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class Poisson : ParameterLimits, IDistribution, IProbability
    {
        public Poisson(double lambda)
        {
            Lambda = lambda;
        }

        public double GetMean()
        {
            return Lambda;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(Lambda);
        }

        public double GetVariance()
        {
            return Lambda;
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
            if (input < 0) throw new ArgumentException("Parameter cannot be smaller than 0");
            double solution = 0;
            for (double i = 0; i < input; i++)
            {
                solution += (Math.Pow(Lambda, i) * Math.Pow(Math.E, -Lambda)) / i.Factorial();
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException("Parameter cannot be smaller than 0");
            double solution = 0;
            for (double i = 0; i <= input; i++)
            {
                solution += (Math.Pow(Lambda, i) * Math.Pow(Math.E, -Lambda)) / i.Factorial();
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
