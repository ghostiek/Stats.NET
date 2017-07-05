using StatsLib.Tables.Classes;

namespace StatsLib.Interfaces
{
    interface IChiSquared
    {
        /// <summary>
        /// Used to get the Chi Squared Statistic
        /// </summary>
        /// <param name="probability"></param>
        /// <returns></returns>
        double GetChiSquaredStatistic(double probability);

        /// <summary>
        /// Returns a DataTable depending on your degree of freedom
        /// Useful if you want to get multiple Chi Squared Statistics
        /// </summary>
        /// <returns></returns>
        ChiSquaredTable GetChiSquaredTable();
    }
}
