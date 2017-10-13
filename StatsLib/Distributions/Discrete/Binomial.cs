using System;
using StatsLib.Utility;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Discrete
{
    public class Binomial : IDistribution , IProbability, IBinomial
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

        public double GetMgf(double t)
        {
            return Math.Pow(1 - Probability + Probability * Math.Exp(t), PopulationSize);
        }

        public string GetPmf()
        {
            throw new NotImplementedException();
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
