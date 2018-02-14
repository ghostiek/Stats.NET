using System;
using StatsLib.LinearModels;
using StatsLib.Tests;


namespace StatsLib.Interfaces
{
    public interface ISimpleLinearModel
    {
        Coefficients Slopes { get; }
        Residuals Residuals { get; }
        FTest FStatistic { get; }
        int DegreeOfFreedom { get; }
        double RSquared { get; }
        double RSquaredAdjusted { get; }
        Func<double?, double?> Model { get; }
        double SumSquaredTotal { get; }
        double MeanSquaredTotal { get; }
    }
}
