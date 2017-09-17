using System.Collections.Generic;

namespace StatsLib.Interfaces
{
    interface INormal
    {
        /// <summary>
        /// Also known as Mean or Average
        /// </summary>
        double Mu { get; }

        /// <summary>
        /// Also known as Variance
        /// Cannot be negative
        /// </summary>
        double Sigma { get; }

        double ZScore(double input);
    }
}
