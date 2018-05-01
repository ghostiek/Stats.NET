using System;
using StatsLib.Utility;
using System.Collections.Generic;
using StatsLib.Interfaces;

namespace StatsLib.Distributions
{
    class Hypergeometric : IDiscreteDistribution, IProbability, IHypergeometric
    {
        #region Properties and Backing fields
        private uint _sampleSize;
        public uint PopulationSize { get; private set; }
        public uint SampleSize
        {
            get
            {
                return _sampleSize;
            }
            private set
            {
                if (value > PopulationSize)
                    throw new ArgumentOutOfRangeException("SampleSize", "SampleSize cannot be larger than PopulationSize");
                _sampleSize = value;
            }
        }
        public uint NumberOfSuccessInPopulation { get; private set; }
        #endregion


        public Hypergeometric(uint populationSize, uint sampleSize, uint numberOfSuccessInPopulation)
        {
            PopulationSize = populationSize;
            SampleSize = sampleSize;
            NumberOfSuccessInPopulation = numberOfSuccessInPopulation;
        }



        public double GetCdf(double x)
        {
            throw new System.NotImplementedException();
        }

        public double GetMean()
        {
            return SampleSize * NumberOfSuccessInPopulation / PopulationSize;
        }

        public double GetMgf(double t)
        {
            throw new System.NotImplementedException();
        }

        public double GetMode()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Parameter stands for number of success in the sample
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetPdf(double x)
        {
            if(x > NumberOfSuccessInPopulation)
            {
                throw new ArgumentOutOfRangeException("x", "Number of Sample successes cannot be greater than Population Success");
            }
            var firstCoef = Stat.BinomialCoef(x, NumberOfSuccessInPopulation);
            var secondCoef = Stat.BinomialCoef(SampleSize - x, PopulationSize - NumberOfSuccessInPopulation);
            var thirdCoef = Stat.BinomialCoef(SampleSize, PopulationSize);

            return firstCoef * secondCoef / thirdCoef;
        }

        public double GetProbabilityLessThan(double input)
        {
            throw new System.NotImplementedException();
        }

        public double GetProbabilityLessThanOrEqual(double input)
        {
            throw new System.NotImplementedException();
        }

        public double GetProbabilityMoreThan(double input)
        {
            throw new System.NotImplementedException();
        }

        public double GetProbabilityMoreThanOrEqual(double input)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<double> GetRandomSample(int size)
        {
            throw new System.NotImplementedException();
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public double GetVariance()
        {
            return SampleSize * NumberOfSuccessInPopulation * (PopulationSize - NumberOfSuccessInPopulation) * (PopulationSize - SampleSize) / (PopulationSize * PopulationSize * (PopulationSize - 1));
        }
    }
}
