namespace StatsLib.Interfaces
{
    public interface INegativeBinomial
    {
        /// <summary>
        /// Needs to be between 0 and 1
        /// </summary>
        double Probability { get; }

        /// <summary>
        /// Number of failures until the experiment is stopped
        /// </summary>
        uint FailureNumber { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="probability"></param>
        /// <param name="number"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        double GetExactNegativeBinomialProbability(double probability, uint number, double input);
    }
}
