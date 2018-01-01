using System;
using System.Collections.Generic;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{
    public class Exponential : IDistribution, IProbability, ISpecialGamma
    {
        #region Property and Backing Field
        private double _lambda;
        /// <inheritdoc />
        /// <summary>
        /// This parameter can never be less than or equal to 0
        /// </summary>
        public double Lambda
        {
            get => _lambda;
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Lambda), "Lambda cannot be smaller than or equal to 0");
                _lambda = value;
            }
        }
        #endregion

        public Exponential(double lambda)
        {
            Lambda = lambda;
        }

        #region IDistribution Methods
        public double GetMean()
        {
            return 1 / Lambda;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return 1 / Math.Pow(Lambda, 2);
        }

        public double GetMgf(double t)
        {
            if (t >= Lambda) throw new ArgumentOutOfRangeException(nameof(t), "t cannot be larger or equal to Lambda");
            return Lambda / (Lambda - t);
        }


        public double GetPdf(double x)
        {
            return Lambda * Math.Exp(-Lambda * x);
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            //y = ‎1 − e−λx
            //x = ln(1-y)/(−λ)
            var sample = new double[size];
            var rand = new Random();
            for(int i = 0; i < size; ++i)
            {
                sample[i] = Math.Log(rand.NextDouble()) / (-Lambda);
            }
            return sample;
        }
        #endregion

        #region GetProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException(nameof(input), "Input cannot be smaller than 0");
            else return 1 - Math.Pow(Math.E, -Lambda * input);
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
