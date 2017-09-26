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
        public double A { get; set; }
        public double B { get; set; }

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

        public string GetPmf()
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityLessThan(double input)
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityMoreThanOrEqual(double input)
        {
            throw new NotImplementedException();
        }

        public double GetProbabilityMoreThan(double input)
        {
            throw new NotImplementedException();
        }
    }
}
