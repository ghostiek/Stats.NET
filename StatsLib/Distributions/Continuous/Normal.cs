﻿using System;
using System.Collections.Generic;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{
    public class Normal : IDistribution, IProbability, INormal
    {
        #region Properties and Backing Field
        private double _sigma;
        /// <inheritdoc />
        /// <summary>
        /// Also known as Mean or Average
        /// </summary>
        public double Mu { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Also known as Variance
        /// Cannot be negative
        /// </summary>
        public double Sigma
        {
            get => _sigma;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(Sigma), "The variance was negative");
                _sigma = value;
            }
        }
        #endregion

        public Normal(double mean, double variance)
        {
            Mu = mean;
            Sigma = variance;
        }

        #region IDistribution Methods
        public double GetMean()
        {
            return Mu;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(Sigma);
        }

        public double GetVariance()
        {
            return Sigma;
        }
        public double GetMgf(double t)
        {
            return Math.Exp(Mu * t + 0.5 * GetVariance() * Math.Pow(t, 2));
        }

        public string GetPmf()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region INormal Methods
        public double ZScore(double input)
        {
            return (input - Mu) / Math.Sqrt(Sigma);
        }

        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            //Formula taken from https://www.johndcook.com/blog/csharp_phi/
            //Gets the Z score
            var z = ZScore(input);


            //Constants
            const double a1 = 0.254829592;
            const double a2 = -0.284496736;
            const double a3 = 1.421413741;
            const double a4 = -1.453152027;
            const double a5 = 1.061405429;
            const double p = 0.3275911;

            //Save the sign of z
            int sign = 1;
            if (z < 0) sign = -1;

            z = Math.Abs(z) / Math.Sqrt(2.0);

            var t = 1.0 / (1.0 + p * z);
            var y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-z * z);

            return 0.5 * (1.0 + sign * y);

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
