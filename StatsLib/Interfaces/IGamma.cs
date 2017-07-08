namespace StatsLib.Interfaces
{
    interface IGamma
    {
        /// <summary>
        /// Shape Parameter
        /// Has to be greater than 0
        /// </summary>
        double Alpha { get; }

        /// <summary>
        /// Rate Parameter
        /// Has to be greater than 0
        /// </summary>
        double Beta { get;}
    }
}
