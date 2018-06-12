using System;
using System.Collections.Generic;
using StatsLib.Utility;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Continuous
{
    public class Beta : IBeta, IContinuousDistribution, IProbability
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

        public double GetMode() => (A - 1) / (A + B - 2);

        public double GetMgf(double t)
        {
            //No point in having k exceed 171 since 170! results into infinity making the rest of the equation 0.
            return 1 + Calculate.SequenceSummation(1, 171, 
                k => Calculate.SequenceProduct(0, k - 1, r => (A + r) / (A + B + r)) * Math.Pow(t, k) / k.Factorial());
        }

        public double GetPdf(double x)
        {
            throw new NotImplementedException();
        }

        public double GetCdf(double x)
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
