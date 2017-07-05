using System;

namespace StatsLib.Distributions
{
    public abstract class ParameterLimits
    {
        /// <summary>
        /// Magic Numbers. The limits of how small and large a probability can be
        /// </summary>
        const double _minP = 0;
        const double _maxP = 1;


        /// <summary>
        /// Useful for every distribution
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private uint _populationSize;
        public uint PopulationSize
        {
            get
            {
                return _populationSize;
            }
            set
            {
                if (value < 2) throw new ArgumentOutOfRangeException("Population Size cannot be smaller than 2");
                else _populationSize = value;
            }
        }

        /// <summary>
        /// Used in Uniform Distributions
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private double _upperbound;
        public double LowerBound { get; set; }
        public double UpperBound
        {
            get
            {
                return _upperbound;
            }
            set
            {
                if (value < LowerBound) throw new ArgumentException("The Upperbound parameter was smaller than the Lowerbound one");
                else _upperbound = value;
            }
        }

        /// <summary>
        /// Used in Binomial, Negative Binomial, Geometric
        /// </summary> 
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private double _probability;
        public double Probability
        {
            get
            {
                return _probability;
            }
            set
            {
                if (value > _maxP || value < _minP) throw new ArgumentOutOfRangeException("The number inputted was out of bounds (0-1)");
                else _probability = value;
            }
        }

        /// <summary>
        /// Used in negative binomial
        /// </summary>
        public uint FailureNumber { get; set; }

        /// <summary>
        /// Used in Poisson/Exponential Distributions
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private double lambda;
        public double Lambda
        {
            get
            {
                return lambda;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Lambda cannot be smaller than 0");
                else lambda = value;
            }
        }

        /// <summary>
        /// Used in Normal Distributions
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private double _sigma;
        public double Mu { get; set; }
        public double Sigma
        {
            get
            {
                return _sigma;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("The variance was negative");
                else _sigma = value;
            }
        }

        /// <summary>
        /// Used in Gamma Distributions
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private double _alpha;
        private double _beta;
        public double Alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Alpha cannot be smaller than 0");
                else _alpha = value;
            }
        }
        public double Beta
        {
            get
            {
                return _beta;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Beta cannot be smaller than 0");
                else _beta = value;
            }
        }

        /// <summary>
        /// Used in Chi-Squared Distributions
        /// </summary>
        public uint DegreeOfFreedom
        {
            get
            {
                return PopulationSize - 1;
            }
        }

    }
}
