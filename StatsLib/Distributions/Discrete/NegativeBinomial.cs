using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class NegativeBinomial : ParameterLimits, IDistribution, IProbability
    {
        public NegativeBinomial(double probability, uint failureNumber)
        {
            Probability = probability;
            FailureNumber = failureNumber;
        }
        public double GetMean()
        {
            return FailureNumber / Probability;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return Probability * (1 - FailureNumber) / Math.Pow((1 - Probability), 2);
        }

        public string GetMGF()
        {
            throw new NotImplementedException();
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// X = number of trials until Rth success
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double GetProbabilityLessThan(double input)
        {
            double solution = 0;
            for (int i = 0; i < input; i++)
            {
                solution += Stats.GetExactNegativeBinomialProbability(Probability, FailureNumber, i);
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            double solution = 0;
            for (int i = 0; i <= input; i++)
            {
                solution += Stats.GetExactNegativeBinomialProbability(Probability, FailureNumber, i);
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
