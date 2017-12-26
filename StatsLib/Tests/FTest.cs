using System;
using StatsLib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Tests
{
    public class FTest : ITest
    {
        public double? Statistic { get; private set; }

        public double? PValue { get; private set; }

        public int DegreeOfFreedom { get; private set; }

        public FTest(ISimpleLinearModel model)
        {
            Statistic = model.Slopes.MeanSquaredRegression.Sum() / model.Residuals.MeanSquaredErrors;
            DegreeOfFreedom = model.DegreeOfFreedom;
        }

    }
}
