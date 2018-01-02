using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Discrete
{
    public class DiscreteUniform : IDiscreteUniform, IDistribution, IProbability
    {
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }

        public DiscreteUniform(int lowerBound, int upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
        public double GetMean() => (LowerBound + UpperBound) / 2.0;

        public double GetVariance() => (Math.Pow(UpperBound - LowerBound + 1, 2) - 1) / 12;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetMode()
        {
            throw new NotImplementedException();
        }
        public double GetMgf(double t) => (Math.Exp(LowerBound * t) - Math.Exp((UpperBound + 1) * t)) / ((UpperBound - LowerBound + 1) * (1 - Math.Exp(t)));

        /// <summary>
        /// Note: No matter what x is the Pmf will be the same
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetPdf(double x = 0)
        {
            return 1 / (UpperBound - LowerBound - 1);
        }

        public double GetCdf(double x)
        {
            if (x < LowerBound || x > UpperBound)
                throw new ArgumentOutOfRangeException(
                    nameof(x), "The parameter x cannot be smaller than the LowerBound or greater than UpperBound");

            return (Math.Floor(x) - LowerBound - 1) / (UpperBound - LowerBound + 1);
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            double[] sample = new double[size];
            var n = UpperBound - LowerBound + 1;
            var interval = 1.0 / n;
            var rand = new Random();
            for (int i = 0; i < size; ++i)
            {
                var probs = rand.NextDouble();
                var generatedNumber = Math.Floor(probs / interval);
                sample[i] = generatedNumber;
            }
            return sample;
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            var roundedDown = Math.Floor(input);
            return 1 / roundedDown;
        }

        public double GetProbabilityLessThan(double input)
        {
            if (Math.Floor(input) == input)
            {
                return 1 / (input - 1);
            }
            return 1 / Math.Floor(input);
        }

        public double GetProbabilityMoreThanOrEqual(double input)
        {
            return 1 - GetProbabilityLessThanOrEqual(input);
        }

        public double GetProbabilityMoreThan(double input)
        {
            return 1 - GetProbabilityLessThan(input);
        }
    }
}
