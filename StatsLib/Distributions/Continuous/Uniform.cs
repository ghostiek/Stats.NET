using System;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{

    public class Uniform : IDistribution, IProbability, IUniform
    {
        #region Properties and Backing Field
        private double _upperBound;

        /// <inheritdoc />
        /// <summary>
        /// First Bound
        /// </summary>
        public double LowerBound { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Second Bound
        /// Needs to be larger than LowerBound
        /// </summary>
        public double UpperBound
        {
            get => _upperBound;
            private set
            {
                if (value < LowerBound) throw new ArgumentException("The Upperbound parameter was smaller than the Lowerbound one");
                _upperBound = value;
            }
        }
        #endregion

        public Uniform(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        #region IDistribution Methods
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

        public double GetMgf(double t)
        {
            if (t == 0) return 1;
            return (Math.Exp(t * UpperBound) - Math.Exp(t * LowerBound)) / (t * (UpperBound - LowerBound));
        }

        public string GetPmf()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            double solution = 0;
            for (var i = LowerBound; i <= UpperBound; i++)
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
        #endregion

    }
}
