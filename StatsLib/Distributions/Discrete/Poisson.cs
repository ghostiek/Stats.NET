using System;
using StatsLib.Utility;
using StatsLib.Interfaces;
using System.Collections.Generic;

namespace StatsLib.Distributions.Discrete
{
    public class Poisson : IDiscreteDistribution, IProbability, ISpecialGamma
    {
        #region Property
        /// <inheritdoc />
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

        public double GetMode()
        {
            //Floor(Lamda)-1 too, find a better impl
            return Math.Floor(Lambda);
        }
        public double GetMgf(double t)
        {
            return Math.Exp(Lambda * (Math.Exp(t) - 1));
        }

        public double GetPdf(double x)
        {
            return Math.Pow(Lambda, x) * Math.Exp(-Lambda) / x.Factorial();
        }

        public double GetCdf(double x)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException(nameof(input), "Parameter cannot be smaller than 0");
            double solution = 0;
            for (double i = 0; i < input; i++)
            {
                solution += (Math.Pow(Lambda, i) * Math.Pow(Math.E, -Lambda)) / i.Factorial();
            }
            return solution;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException(nameof(input), "Parameter cannot be smaller than 0");
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
