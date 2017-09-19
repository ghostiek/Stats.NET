using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class NegativeBinomial : IDistribution, IProbability, INegativeBinomial
    {
        #region Properties and Backing Field
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

        /// <summary>
        /// Number of failures until the experiment is stopped
        /// </summary>
        public uint FailureNumber { get; private set; }
        #endregion

        public NegativeBinomial(double probability, uint failureNumber)
        {
            Probability = probability;
            FailureNumber = failureNumber;
        }

        #region IDistribution Methods
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

        public double GetMGF(double t)
        {
            if (t >= -Math.Log(Probability)) throw new ArgumentOutOfRangeException("t", "t cannot be larger than or equal to -log(Probability)");
            return Math.Pow((1 - Probability) / (1 - Probability * Math.Exp(t)), FailureNumber);
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IProbability Methods
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
                solution += GetExactNegativeBinomialProbability(Probability, FailureNumber, i);
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            double solution = 0;
            for (int i = 0; i <= input; i++)
            {
                solution += GetExactNegativeBinomialProbability(Probability, FailureNumber, i);
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

        #region Negative Binomial Methods
        public double GetExactNegativeBinomialProbability(double probability, uint number, double input)
        {
            return Stats.BinomialCoef(input - 1, number - 1) * Math.Pow(probability, number) * Math.Pow(1 - probability, input - number);
        }
        #endregion
    }
}
