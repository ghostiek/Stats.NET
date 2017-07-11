using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class Geometric : IDistribution, IProbability, IGeometric
    {
        #region Property and Backing Field
        private double probability;
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        public double Probability
        {
            get
            {
                return probability;
            }
            private set
            {
                if (value >= 0 || value <= 1) throw new ArgumentOutOfRangeException("The number inputted was out of bounds (0-1)");
                else probability = value;
            }
        }
        #endregion

        public Geometric(double probability)
        {
            Probability = probability;
        }

        #region IDistribution Methods
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
        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            if (input < 1) throw new ArgumentOutOfRangeException("Parameter cannot be smaller than 1");
            double solution = 0;
            for (int i = 0; i < input; i++)
            {
                solution += GetExactGeometricProbability(Probability, i);
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 1) throw new ArgumentOutOfRangeException("Parameter cannot be smaller than 1");
            double solution = 0;
            for (int i = 0; i <= input; i++)
            {
                solution += GetExactGeometricProbability(Probability, i);
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
        #endregion

        #region IGeometric Methods
        /// <summary>
        /// Method to get the exact probability of an event occuring, rather than the sum of a number of events
        /// </summary>
        /// <param name="probability"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public double GetExactGeometricProbability(double probability, double number)
        {
            return Math.Pow(1 - probability, number - 1) * probability;
        }
        #endregion
    }
}
