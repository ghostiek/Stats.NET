namespace StatsLib.Interfaces
{
    interface IProbability
    {
        /// <summary>
        /// Returns the probability of a certain event happening
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double GetProbabilityLessThanOrEqual(double input);

        /// <summary>
        /// Returns the probability of a certain event happening
        /// Is always equal to <c>GetProbabilityLessThanOrEqual(double input)</c> in continuous distributions
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double GetProbabilityLessThan(double input);

        /// <summary>
        /// Returns the probability of a certain event happening
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double GetProbabilityMoreThanOrEqual(double input);

        /// <summary>
        /// Returns the probability of a certain event happening
        /// Is always equal to <c>GetProbabilityMoreThanOrEqual(double input)</c> in continuous distributions
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double GetProbabilityMoreThan(double input);
    }
}
