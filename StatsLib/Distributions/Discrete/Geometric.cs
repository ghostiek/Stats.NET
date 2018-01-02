using System;
using System.Collections.Generic;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Discrete
{
    public class Geometric : IDistribution, IProbability, IGeometric
    {
        #region Property and Backing Field
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
                if (value >= 0 || value <= 1) throw new ArgumentOutOfRangeException(nameof(Probability),
                    "The number inputted was out of bounds (0-1)");
                _probability = value;
            }
        }
        #endregion

        public Geometric(double probability)
        {
            Probability = probability;
        }

        #region IDistribution Methods
        public double GetMean() => 1 / Probability;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetVariance() => (1 - Probability) / Math.Pow(Probability, 2);

        public double GetMode() => 1;

        public double GetMgf(double t)
        {
            if (t >= -Math.Log(1 - Probability))
                throw new ArgumentOutOfRangeException(nameof(t), "t cannot be greater than or equal to -ln(1-p)");
            return Probability * Math.Exp(t) / (1 - (1 - Probability) * Math.Exp(t));
        }

        /// <summary>
        /// The parameter is the number of trials
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetPdf(double x)
        {
            if (x <= 0)
                throw new ArgumentOutOfRangeException(nameof(x), "x cannot be smaller than 1");
            return Math.Pow(1 - Probability, x - 1) * Probability; 
        }

        public double GetCdf(double x)
        {
            if (x <= 0)
                throw new ArgumentOutOfRangeException(nameof(x), "x cannot be smaller than 1");
            return 1 - Math.Pow(1 - Probability, x);
        }
        public IEnumerable<double> GetRandomSample(int size)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            if (input < 1) throw new ArgumentOutOfRangeException(nameof(input), "Parameter cannot be smaller than 1");
            double solution = 0;
            for (var i = 0; i < input; i++)
            {
                solution += GetExactGeometricProbability(Probability, i);
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 1) throw new ArgumentOutOfRangeException(nameof(input), "Parameter cannot be smaller than 1");
            double solution = 0;
            for (var i = 0; i <= input; i++)
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
        /// <inheritdoc />
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
