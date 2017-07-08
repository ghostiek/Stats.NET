using CsvHelper;
using StatsLib.Interfaces;
using StatsLib.Mapping;
using StatsLib.Tables.Classes;
using System;
using System.IO;

namespace StatsLib.Distributions
{
    public class ChiSquared : IDistribution, IProbability, IChiSquared
    {
        #region Properties and Backing Field

        /// <summary>
        /// Degree of Freedom of ChiSquared Distribution
        /// Always Population - 1
        /// </summary>
        public uint DegreeOfFreedom
        {
            get
            {
                return PopulationSize - 1;
            }

        }

        private uint populationSize;

        /// <summary>
        /// The amount of individuals in the sample
        /// </summary>
        public uint PopulationSize
        {
            get
            {
                return populationSize;
            }
            private set
            {
                if (value <= 1) throw new ArgumentOutOfRangeException("Population Size cannot be smaller than or equal to 1");
                else populationSize = value;
            }
        }
        #endregion

        public ChiSquared(uint populationSize)
        {
            PopulationSize = populationSize;
        }

        #region IDistribution Methods
        public double GetMean()
        {
            return DegreeOfFreedom;
        }

        public double GetVariance()
        {
            return 2 * DegreeOfFreedom;
        }

        public double GetStandardDeviation()
        {
            return Math.Sqrt(GetVariance());
        }

        public string GetMGF()
        {
            throw new NotImplementedException();
        }

        public string GetPMF()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetProbability Methods
        public double GetProbabilityLessThan(double input)
        {
            throw new NotImplementedException();
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
        /// <summary>
        /// Used to get the Chi Squared Statistic
        /// </summary>
        /// <param name="probability"></param>
        /// <returns></returns>
        public double GetChiSquaredStatistic(double probability)
        {
            //This grabs the Probabilities and its ChiSquared Statistics from the row
            var row = GetChiSquaredTable().GetDictionary();

            var ChiSquaredStatistic = row[probability];

            return ChiSquaredStatistic;
        }

        /// <summary>
        /// Returns a DataTable depending on your degree of freedom
        /// Useful if you want to get multiple Chi Squared Statistics
        /// </summary>
        /// <returns></returns>
        public ChiSquaredTable GetChiSquaredTable()
        {
            //Gets Path to CSV
            string SolutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string ChiSquaredPath = Path.Combine(SolutionPath, @"StatsLib\Tables\CSVs\ChiSquaredTable.csv");
            using (StreamReader Reader = new StreamReader(ChiSquaredPath))
            {
                var csv = new CsvReader(Reader);

                csv.Configuration.RegisterClassMap<ChiSquaredTableMap>();

                ChiSquaredTable record = null;
                //Value #1 = DoF
                //Value #2 to end of line = Chi Squared Statistic
                while (csv.Read())
                {
                    if (csv.TryGetField(0, out int intField) && (csv.GetField<int>(0) == DegreeOfFreedom))
                    {
                        record = csv.GetRecord<ChiSquaredTable>();
                        break;
                    }
                }
                return record;
            }
        }
        #endregion
    }
}