using StatsLib.Tables.Classes;

namespace StatsLib.Interfaces
{
    public interface IChiSquared
    {
        /// <summary>
        /// The amount of individuals in the sample
        /// </summary>
        uint PopulationSize { get; }

        /// <summary>
        /// Degree of Freedom of ChiSquared Distribution
        /// Always Population - 1
        /// </summary>
        uint DegreeOfFreedom { get; }

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
