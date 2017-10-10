using System.Collections.Generic;


namespace StatsLib.Interfaces
{
    public interface ISimpleLinearRegression
    {
        double? Intercept { get; }
        double? Slope { get; }
        List<double?> Residuals { get;}
    }
}
