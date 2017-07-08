namespace StatsLib.Interfaces
{
    interface IUniform
    {
        /// <summary>
        /// First Bound
        /// </summary>
        double LowerBound { get; }

        /// <summary>
        /// Second Bound
        /// Needs to be larger than LowerBound
        /// </summary>
        double UpperBound { get; }
    }
}
