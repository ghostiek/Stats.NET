using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsLib.Distributions;
using StatsLib.Mapping;
using StatsLib.Tables.Classes;
using System.Collections.Generic;
using System.IO;

namespace StatsLibTests
{
    [TestClass]
    public class ChiSquaredTableTests
    {
        [TestMethod]
        public void ChiSquaredCSVOpen()
        {
            string SolutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string ChiSquaredPath = Path.Combine(SolutionPath, @"StatsLib\Tables\ChiSquaredTable.csv");
            using (StreamReader Reader = new StreamReader(ChiSquaredPath))
            {
            }
        }


        [TestMethod]
        public void GetRowFromCSV()
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
                    if (csv.TryGetField(0, out int intField) && (csv.GetField<int>(0) == 3))
                    {
                        record = csv.GetRecord<ChiSquaredTable>();
                    }
                }
            }
        }

        [TestMethod]
        public void GetDictionary()
        {
            var Chi = new ChiSquared(5);
            var Dict = Chi.GetChiSquaredTable().GetDictionary();
            var TestDict = new Dictionary<double, double>()
            {
                {0.995, 0.207},
                {0.975,0.484},
                {0.2, 5.989},
                {0.1,7.779},
                {0.05,9.488},
                {0.025, 11.143},
                {0.02, 11.668},
                {0.01,13.277},
                {0.005, 14.86},
                {0.002, 16.924},
                {0.001,18.467}
            };

            CollectionAssert.AreEqual(TestDict, Dict);
        }

        [TestMethod]
        public void GetProbability()
        {
            var Chi = new ChiSquared(3);
            var ChiSquaredStat = Chi.GetChiSquaredStatistic(0.995);
            Assert.AreEqual(ChiSquaredStat, 0.01);
        }
    }
}
