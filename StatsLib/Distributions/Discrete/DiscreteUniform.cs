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
        public int A { get; private set; }
        public int B { get; private set; }

        public DiscreteUniform(int lowerBound, int upperBound)
        {
            A = lowerBound;
            B = upperBound;
        }
        public double GetMean() => (A + B) / 2.0;

        public double GetVariance() => (Math.Pow(B - A + 1, 2) - 1) / 12;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetMgf(double t) => (Math.Exp(A * t) - Math.Exp((B + 1) * t)) / ((B - A + 1) * (1 - Math.Exp(t)));

        public string GetPmf()
        {
            throw new NotImplementedException();
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
