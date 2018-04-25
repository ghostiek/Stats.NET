using System;
using System.IO;
using System.Linq;
using CsvHelper;
using StatsLib.Interfaces;
using StatsLib.Mapping;
using StatsLib.Tables.Classes;
using System.Collections.Generic;

namespace StatsLib.Distributions.Continuous
{
    public class ChiSquared : IContinuousDistribution, IProbability, IChiSquared
    {
        #region Properties and Backing Field

        /// <inheritdoc />
        /// <summary>
        /// Degree of Freedom of ChiSquared Distribution
        /// Always Population - 1
        /// </summary>
        public uint DegreeOfFreedom => PopulationSize - 1;

        private uint _populationSize;

        /// <inheritdoc />
        /// <summary>
        /// The amount of individuals in the sample
        /// </summary>
        public uint PopulationSize
        {
            get => _populationSize;
            private set
            {
                if (value <= 1) throw new ArgumentOutOfRangeException(nameof(PopulationSize),
                    "Population Size cannot be smaller than or equal to 1");
                _populationSize = value;
            }
        }
        #endregion

        public ChiSquared(uint populationSize)
        {
            PopulationSize = populationSize;
        }

        #region IDistribution Methods
        public double GetMean() => DegreeOfFreedom;

        public double GetVariance() => 2 * DegreeOfFreedom;

        public double GetStandardDeviation() => Math.Sqrt(GetVariance());

        public double GetMode() => Math.Max(DegreeOfFreedom - 2, 0);

        public double GetMgf(double t)
        {
            if (t >= 0.5) throw new ArgumentOutOfRangeException(nameof(t), "t cannot be smaller than 0.5");
            return 1 / Math.Pow((1 - 2 * t), DegreeOfFreedom / 2.0);
        }

        public double GetPdf(double x)
        {
            throw new NotImplementedException();
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

        #region GetProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            var table = GetChiSquaredTable().GetDictionary();

            //Fix this. This is just giving them a pass for 10% error
            var prob = table.FirstOrDefault(x => input >= x.Value - x.Value * 0.1 && input <= x.Value + x.Value * 0.1).Key;

            return prob;
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

        #region IChiSquared Methods
        /// <inheritdoc />
        /// <summary>
        /// Used to get the Chi Squared Statistic
        /// </summary>
        /// <param name="probability"></param>
        /// <returns></returns>
        public double GetChiSquaredStatistic(double probability)
        {
            //This grabs the Probabilities and its ChiSquared Statistics from the row
            var row = GetChiSquaredTable().GetDictionary();

            var chiSquaredStatistic = row[probability];

            return chiSquaredStatistic;
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a DataTable depending on your degree of freedom
        /// Useful if you want to get multiple Chi Squared Statistics
        /// </summary>
        /// <returns></returns>
        public ChiSquaredTable GetChiSquaredTable()
        {
            //Gets Path to CSV
            var solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var chiSquaredPath = Path.Combine(solutionPath, @"StatsLib\Tables\CSVs\ChiSquaredTable.csv");
            using (var reader = new StreamReader(chiSquaredPath))
            {
                var csv = new CsvReader(reader);

                csv.Configuration.RegisterClassMap<ChiSquaredTableMap>();

                ChiSquaredTable record = null;
                //Value #1 = DoF
                //Value #2 to end of line = Chi Squared Statistic
                while (csv.Read())
                {
                    if (!csv.TryGetField(0, out int _) || (csv.GetField<int>(0) != DegreeOfFreedom)) continue;
                    record = csv.GetRecord<ChiSquaredTable>();
                    break;
                }
                return record;
            }
        }
        #endregion
    }
}