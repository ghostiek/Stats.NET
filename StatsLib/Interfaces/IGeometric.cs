namespace StatsLib.Interfaces
{
    interface IGeometric
    {
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        double Probability { get; }

        /// <summary>
        ///  Method to get the exact probability of an event occuring, rather than the sum of a number of events
        /// </summary>
        /// <param name="probability"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        double GetExactGeometricProbability(double probability, double number);
    }
}
