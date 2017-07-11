namespace StatsLib.Interfaces
{
    interface IBinomial
    {
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        double Probability { get; }

        /// <summary>
        /// The amount of individuals in the sample
        /// </summary>
        uint PopulationSize { get; }
    }
}
