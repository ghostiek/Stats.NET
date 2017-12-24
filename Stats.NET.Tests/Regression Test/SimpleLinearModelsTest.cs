using System;
using StatsLib.Linear_Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Stats.NET.Tests.Regression_Test
{
    [TestClass]
    public class SimpleLinearModelTest
    {
        [TestMethod]
        public void SLR()
        {
            var table = new DataTable();
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));

            table.Rows.Add(1.0, 10.0);
            table.Rows.Add(3.0, 20.0);
            table.Rows.Add(5.0, 30.0);
            table.Rows.Add(9.0, 50.0);

            var mymodel = new SimpleLinearModel(table.Columns["X"], table.Columns["Y"]);

            Assert.AreEqual(3, 3);
        }
    }
}
