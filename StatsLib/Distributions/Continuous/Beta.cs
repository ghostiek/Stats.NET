using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{
    public class Beta : IBeta, IDistribution, IProbability
    {
        private double _a;
        private double _b;
        public double A
        {
            get => _a;
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(A), "A cannot be smaller or equal to 0");
                _a = value;
            }
        }
        public double B
        {
            get => _b;
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(B), "B cannot be smaller or equal to 0");
                _b = value;
            }
        }

        public Beta(double alpha, double beta)
        {
            A = alpha;
            B = beta;
        }
        public double GetMean() => A / (A + B);

        public double GetVariance() => A * B / (Math.Pow(A + B, 2) * (A + B + 1));

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetMgf(double t)
        {
            throw new NotImplementedException();
        }

        public double GetPdf(double x)
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            if (input < 0 || input > 1) throw new ArgumentOutOfRangeException(nameof(input),
                "Parameter cannot be smaller than 0 or larger than 1");

            throw new NotImplementedException();
        }

        public double GetProbabilityLessThan(double input)
        {
            return GetProbabilityLessThanOrEqual(input);
        }

        public double GetProbabilityMoreThanOrEqual(double input)
        {
            return 1 - GetProbabilityLessThanOrEqual(input);
        }

        public double GetProbabilityMoreThan(double input)
        {
            return 1 - GetProbabilityLessThanOrEqual(input);
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            throw new NotImplementedException();
        }
    }
}
