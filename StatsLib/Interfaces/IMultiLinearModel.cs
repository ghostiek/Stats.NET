using System;
using System.Collections.Generic;
using StatsLib.LinearModels;
using StatsLib.Tests;


namespace StatsLib.Interfaces
{
    public interface IMultiLinearModel
    {
        Coefficients Slopes { get; }
        Residuals Residuals { get; }
        FTest FStatistic { get; }
        int DegreeOfFreedom { get; }
        double RSquared { get; }
        double RSquaredAdjusted { get; }
        Func<IEnumerable<double?>, double?> Model { get; }
        double SumSquaredTotal { get; }
        double MeanSquaredTotal { get; }
    }
}
