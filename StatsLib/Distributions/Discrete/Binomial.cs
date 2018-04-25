using System;
using StatsLib.Utility;
using StatsLib.Interfaces;
using System.Collections.Generic;

namespace StatsLib.Distributions.Discrete
{
    public class Binomial : IDiscreteDistribution, IProbability, IBinomial
    {
        #region Properties and Backing Fields
        private double _probability;

        /// <inheritdoc />
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        public double Probability
        {
            get => _probability;
            private set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException(nameof(Probability),
                    "The number inputted was out of bounds (0-1)");
                _probability = value;
            }
        }

        private uint _populationSize;

        /// <inheritdoc />
        /// <summary>
        /// The amount of individuals in the sample
        /// </summary>
        public uint PopulationSize
        {
            get => _populationSize;
            private set
            {
                if (value < 1) throw new ArgumentOutOfRangeException(nameof(PopulationSize), "Population Size cannot be smaller than 1");
                _populationSize = value;
            }
        }
        #endregion

        public Binomial(double probability, uint populationSize)
        {
            Probability = probability;
            PopulationSize = populationSize;
        }

        #region IDistribution Methods
        public double GetMean() => Probability * PopulationSize;

        public double GetVariance() => (1 - Probability) * Probability * PopulationSize;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetMode()
        {
            if (Probability == 1) return PopulationSize;
            if (Probability == 0 || Math.Floor((PopulationSize + 1) * Probability) == (PopulationSize + 1) * Probability)
            {
                return Math.Floor((PopulationSize + 1) * Probability);
            }
            return (PopulationSize + 1) * Probability; //Also (PopulationSize + 1) * Probability - 1, fix the Mode impl
        }
        public double GetMgf(double t)
        {
            return Math.Pow(1 - Probability + Probability * Math.Exp(t), PopulationSize);
        }

        /// <summary>
        /// The parameter is the number of successes
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetPdf(double x)
        {
            return Stat.BinomialCoef(x, PopulationSize) * Math.Pow(Probability, x) *
                Math.Pow(1 - Probability, PopulationSize - x);
        }

        public double GetCdf(double x)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<double> GetRandomSample(int size)
        {
            var samp = new List<double>();
            var rand = new Random();
            for (int i = 0; i < size; i++)
            {
                int x = 0;
                for (int j = 0; j < PopulationSize; j++)
                {
                    if (rand.NextDouble() < Probability) ++x;
                }
                samp.Add(x);
            }
            return samp;
        }
        #endregion

        #region IProbability Methods
        /// <inheritdoc />
        /// <summary>
        /// Gets Probability there are less than or equal to a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityLessThanOrEqual(double input)
        {
            double solution = 0;
            for (var i = 0; i <= input; i++)
            {
                solution += Stat.BinomialCoef(i, PopulationSize) * (Math.Pow(Probability, i) * Math.Pow(1 - Probability, PopulationSize - i));
            }

            return solution;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets Probability there are less than or a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityLessThan(double input)
        {
            double solution = 0;
            for (var i = 0; i < input; i++)
            {
                solution += Stat.BinomialCoef(i, PopulationSize) * (Math.Pow(Probability, i) * Math.Pow(1 - Probability, PopulationSize - i));
            }

            return solution;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets Probability there are more than or equal to a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityMoreThanOrEqual(double input)
        {
            return 1 - GetProbabilityLessThan(input);
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets Probability there are more than a given amount of successes
        /// </summary>
        /// <returns></returns>
        public double GetProbabilityMoreThan(double input)
        {
            return 1 - GetProbabilityLessThanOrEqual(input);
        }
        #endregion
    }
}
