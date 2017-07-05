using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Binomial : ParameterLimits , IDistribution , IProbability
    {
 
        public Binomial(double probability, uint populationSize)
        {
            Probability = probability;
            PopulationSize = populationSize;
        }

        public double GetMean()
        {
            return Probability * PopulationSize;
        }

        public double GetVariance()
        {
            return (1 - Probability) * Probability * PopulationSize;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public string GetMGF()
        {
            //May have to be a class to find orders, its doing p much nothing as a string
            return $"(1-{Probability}+{Probability}*e^t)^{PopulationSize}";
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Probability there are less than or equal to a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityLessThanOrEqual(double input)
        {
            double solution = 0;
            for (int i = 0; i <= input; i++)
            {
                solution += Stats.BinomialCoef(i, PopulationSize) * (Math.Pow(Probability, i) * Math.Pow(1 - Probability, PopulationSize - i));
            }

            return solution;
        }

        /// <summary>
        /// Gets Probability there are less than or a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityLessThan(double input)
        {
            double solution = 0;
            for (int i = 0; i < input; i++)
            {
                solution += Stats.BinomialCoef(i, PopulationSize) * (Math.Pow(Probability, i) * Math.Pow(1 - Probability, PopulationSize - i));
            }

            return solution;
        }

        /// <summary>
        /// Gets Probability there are more than or equal to a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityMoreThanOrEqual(double input)
        {
            return 1 - GetProbabilityLessThan(input);
        }

        /// <summary>
        /// Gets Probability there are more than a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityMoreThan(double input)
        {
            return 1 - GetProbabilityLessThanOrEqual(input);
        }
    }
}
