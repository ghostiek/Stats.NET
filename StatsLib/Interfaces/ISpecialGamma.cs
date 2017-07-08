namespace StatsLib.Interfaces
{
    interface ISpecialGamma
    {
        /// <summary>
        /// This parameter can never be less than or equal to 0
        /// </summary>
        double Lambda { get; }
    }
}
