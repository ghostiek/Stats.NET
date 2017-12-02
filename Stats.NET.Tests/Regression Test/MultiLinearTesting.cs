using System;
using System.Collections.Generic;
using System.Data;
using StatsLib.Regression;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stats.NET.Tests.Regression_Test
{
    [TestClass]
    public class MultiLinearTesting
    {
        [TestMethod]
        public void ConstructorMultiLinear()
        {
            var table = new DataTable();
            table.Columns.Add("A", typeof(double));
            table.Columns.Add("B", typeof(double));
            table.Columns.Add("Y", typeof(double));

            table.Rows.Add(1.0, 2.0, 10.0);
            table.Rows.Add(3.0, 6.0, 20.0);
            table.Rows.Add(5.0, 2.0, 30.0);
            table.Rows.Add(9.0, 4.0, 50.0);

            var dcs = new List<DataColumn>()
            {
                table.Columns["A"],
                table.Columns["B"]
            };
            var x = new MultiLinearModel(dcs, table.Columns["Y"]);
        }

    }
}
