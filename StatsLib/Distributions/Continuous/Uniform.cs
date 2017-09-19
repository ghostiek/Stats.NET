using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{

    public class Uniform : IDistribution, IProbability, IUniform
    {
        #region Properties and Backing Field
        private double upperBound;

        /// <summary>
        /// First Bound
        /// </summary>
        public double LowerBound { get; private set; }

        /// <summary>
        /// Second Bound
        /// Needs to be larger than LowerBound
        /// </summary>
        public double UpperBound
        {
            get
            {
                return upperBound;
            }
            private set
            {
                if (value < LowerBound) throw new ArgumentException("The Upperbound parameter was smaller than the Lowerbound one");
                else upperBound = value;
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

        public double GetMGF(double t)
        {
            if (t == 0) return 1;
            return (Math.Exp(t * UpperBound) - Math.Exp(t * LowerBound)) / (t * (UpperBound - LowerBound));
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IProbability Methods
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
        #endregion

    }
}
