using System.Collections.Generic;


namespace StatsLib.Interfaces
{
    public interface ILinearRegression
    {
        double? Intercept { get; }
        double? Slope { get; }
        List<double?> Residuals { get;}
    }
}
