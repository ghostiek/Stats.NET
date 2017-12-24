using System;
using StatsLib.Interfaces;
using StatsLib.Linear_Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Tests
{
    public class TTest : ITest
    {
        public double? Statistic { get; private set; }

        public double? PValue { get; private set; }

        public int DegreeOfFreedom { get; private set; }

        public TTest(double? beta, double? standardError)
        {
            Statistic = beta / standardError;
        }

    }
}
