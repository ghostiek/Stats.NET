using CsvHelper;
using StatsLib.Interfaces;
using StatsLib.Mapping;
using StatsLib.Tables.Classes;
using System;
using System.IO;

namespace StatsLib.Distributions
{
    public class ChiSquared : ParameterLimits, IDistribution, IProbability, IChiSquared
    {

        public ChiSquared(uint populationSize)
        {
            PopulationSize = populationSize;
        }

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


        public double GetChiSquaredStatistic(double probability)
        {
            //This grabs the Probabilities and its ChiSquared Statistics from the row
            var row = GetChiSquaredTable().GetDictionary();

            var ChiSquaredStatistic = row[probability];

            return ChiSquaredStatistic;
        }

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
    }
}