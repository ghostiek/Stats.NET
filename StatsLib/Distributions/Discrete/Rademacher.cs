using System;
using System.Collections.Generic;
using StatsLib.Interfaces;

namespace StatsLib.Distributions.Discrete
{
    public class Rademacher : IRademacher, IDistribution, IProbability
    {
        public const double Probability = 0.5;

        private int _tries;

        public int Tries
        {
            get
            {
                return _tries;
            }
            private set
            {
                if (_tries < 1) throw new ArgumentOutOfRangeException("Tries", "Tries cannot be smaller than 1");
                _tries = value;
            }
        }

        public Rademacher(int tries)
        {
            _tries = tries;
        }

        #region IDistribution Methods
        public double GetMean()
        {
            return 0;
        }

        public double GetVariance()
        {
            return 1;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetMgf(double t)
        {
            return Math.Cosh(t);
        }

        public string GetPmf()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            var rand = new Random();

            double[] nums = new double[size];
            for(int i = 0; i < size; ++i)
            {
                //We start at 0
                var step = 0;
                //We loop through a number of Tries
                for (int j = 0; j  < Tries; j++)
                {
                    //Will return a number between 0 and 1
                    var prob = rand.Next(0, 2);
                    //Go back one step
                    if (prob == 0) step -= 1;
                    //Go forward one step
                    else step += 1;
                }
                nums[i] = step;
            }
            return nums;
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
        #endregion
    }
}
