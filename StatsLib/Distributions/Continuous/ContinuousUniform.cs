using System;
using System.Linq;
using System.Collections.Generic;
using StatsLib.Interfaces;
using StatsLib.Utility;

namespace StatsLib.Distributions.Continuous
{

    public class ContinuousUniform : IContinuousDistribution, IProbability, IUniform
    {
        #region Properties and Backing Field
        private double _upperBound;

        /// <inheritdoc />
        /// <summary>
        /// First Bound
        /// </summary>
        public double LowerBound { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Second Bound
        /// Needs to be larger than LowerBound
        /// </summary>
        public double UpperBound
        {
            get => _upperBound;
            private set
            {
                if (value < LowerBound) throw new ArgumentException("The Upperbound parameter was smaller than the Lowerbound one");
                _upperBound = value;
            }
        }
        #endregion

        public ContinuousUniform(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        #region IDistribution Methods
        public double GetMean() => (LowerBound + UpperBound) / 2;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetVariance() => Math.Pow(UpperBound - LowerBound, 2) / 12;

        public double GetMode() => throw new NotImplementedException();

        public double GetMgf(double t)
        {
            if (t == 0) return 1;
            return (Math.Exp(t * UpperBound) - Math.Exp(t * LowerBound)) / (t * (UpperBound - LowerBound));
        }

        public double GetPdf(double x) => x >= LowerBound || x <= UpperBound ? 1 / (UpperBound - LowerBound) : 0;

        public double GetCdf(double x)
        {
            if (x < LowerBound) return 0;
            if (x >= UpperBound) return 1;
            return (x - LowerBound) / (UpperBound - LowerBound);
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            double[] sample = new double[size];
            var n = UpperBound - LowerBound;
            var interval = 1.0 / n;
            var rand = new Random();
            for (int i = 0; i < size; ++i)
            {
                var probs = rand.NextDouble();
                var generatedNumber = probs / interval;
                sample[i] = generatedNumber;
            }
            return sample;
        }
        #endregion

        #region IProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            double solution = 0;
            for (var i = LowerBound; i <= UpperBound; i++)
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
