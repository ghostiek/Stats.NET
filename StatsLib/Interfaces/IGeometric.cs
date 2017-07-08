namespace StatsLib.Interfaces
{
    interface IGeometric
    {
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        double Probability { get; }
    }
}
