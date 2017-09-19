﻿using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class Poisson : IDistribution, IProbability, ISpecialGamma
    {
        #region Property
        /// <summary>
        /// This parameter can never be less than or equal to 0
        /// </summary>
        public double Lambda { get; private set; }
        #endregion

        public Poisson(double lambda)
        {
            Lambda = lambda;
        }

        #region IDistribution Methods
        public double GetMean()
        {
            return Lambda;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(Lambda);
        }

        public double GetVariance()
        {
            return Lambda;
        }

        public double GetMGF(double t)
        {
            return Math.Exp(Lambda * (Math.Exp(t) - 1));
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            if (input < 0) throw new ArgumentException("Parameter cannot be smaller than 0");
            double solution = 0;
            for (double i = 0; i < input; i++)
            {
                solution += (Math.Pow(Lambda, i) * Math.Pow(Math.E, -Lambda)) / i.Factorial();
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException("Parameter cannot be smaller than 0");
            double solution = 0;
            for (double i = 0; i <= input; i++)
            {
                solution += (Math.Pow(Lambda, i) * Math.Pow(Math.E, -Lambda)) / i.Factorial();
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
    }
}
