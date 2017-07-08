using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Gamma : IDistribution, IProbability, IGamma
    {
        #region Properties and Backing fields
        private double alpha;
        private double beta;

        /// <summary>
        /// Shape Parameter
        /// Has to be greater than 0
        /// </summary>
        public double Alpha
        {
            get
            {
                return alpha;
            }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Alpha cannot be smaller than or equal to 0");
                else alpha = value;
            }          
        }
        /// <summary>
        /// Rate Parameter
        /// Has to be greater than 0
        /// </summary>
        public double Beta
        {
            get
            {
                return beta;
            }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Beta cannot be smaller than or equal to 0");
                else beta = value;
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

        public string GetMGF()
        {
            throw new NotImplementedException();
        }

        public string GetPMF()
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
