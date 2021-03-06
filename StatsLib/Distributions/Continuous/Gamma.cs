﻿using System;
using StatsLib.Utility;
using System.Collections.Generic;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{
    public class Gamma : IContinuousDistribution, IProbability, IGamma
    {
        #region Properties and Backing fields
        private double _alpha;
        private double _beta;

        /// <inheritdoc />
        /// <summary>
        /// Shape Parameter
        /// Has to be greater than 0
        /// </summary>
        public double Alpha
        {
            get => _alpha;
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Alpha), "Alpha cannot be smaller than or equal to 0");
                _alpha = value;
            }          
        }
        /// <inheritdoc />
        /// <summary>
        /// Rate Parameter
        /// Has to be greater than 0
        /// </summary>
        public double Beta
        {
            get => _beta;
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Beta), "Beta cannot be smaller than or equal to 0");
                _beta = value;
            }
        }
        #endregion

        public Gamma(double alpha, double beta)
        {
            Alpha = alpha;
            Beta = beta;
        }

        #region IDistribution Methods
        public double GetMean() => Alpha * Beta;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());
        
        public double GetVariance() => Alpha * Beta * Beta;

        public double GetMgf(double t) => 1 / Math.Pow(1 - t / Beta, Alpha);
            
        public double GetMode() => (Alpha - 1) / Beta;

        public double GetPdf(double x) => Math.Pow(Beta, Alpha) * Math.Pow(x, Alpha - 1) * Math.Exp(-Beta * x) / (Alpha - 1).Factorial();

        public double GetCdf(double x)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetProbabilities Methods
        public double GetProbabilityLessThan(double input)
        {
            throw new NotImplementedException();
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
