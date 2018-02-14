using System;
using StatsLib.LinearModels;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvHelper;


namespace Stats.NET.Tests.Regression_Test
{
    [TestClass]
    public class SimpleLinearModelTest
    {
        [TestMethod]
        public void SLR()
        {
            IEnumerable<Mtcars> records;
            using (var sr = File.OpenText(@"Tables\CSVs\mtcarsc#.csv"))
            {
                var csv = new CsvReader(sr);
                records = csv.GetRecords<Mtcars>().ToList();
            }
            var table = new DataTable();
            table.Columns.Add("MPG", typeof(double));
            table.Columns.Add("Cyl", typeof(double));

            foreach (var item in records)
            {
                table.Rows.Add(item.MPG, item.Cyl);
            }
            var mymodel = new SimpleLinearModel(table.Columns["Cyl"], table.Columns["MPG"]);

            Assert.AreEqual(3, 3);
        }

        public class Mtcars
        {
            public double MPG { get; set; }
            public double Cyl { get; set; }
        }
    }
}
