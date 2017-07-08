namespace StatsLib.Interfaces
{
    interface INegativeBinomial
    {
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        double Probability { get; }

        /// <summary>
        /// Number of failures until the experiment is stopped
        /// </summary>
        uint FailureNumber { get; }
    }
}
