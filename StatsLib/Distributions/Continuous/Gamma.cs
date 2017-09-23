using System;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{
    public class Gamma : IDistribution, IProbability, IGamma
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
        public double GetMean()
        {
            return Alpha * Beta;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return Alpha * Beta * Beta;
        }

        public double GetMgf(double t)
        {
            return 1 / Math.Pow(1 - t / Beta, Alpha);
        }

        public string GetPmf()
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
