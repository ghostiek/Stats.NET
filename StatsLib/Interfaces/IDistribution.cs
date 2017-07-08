namespace StatsLib.Interfaces
{
    interface IDistribution
    {
        /// <summary>
        /// Returns the Expected Value
        /// </summary>
        /// <returns></returns>
        double GetMean();

        /// <summary>
        /// The expectation of the squared deviation of a Random Variable from its mean
        /// </summary>
        /// <returns></returns>
        double GetVariance();

        /// <summary>
        /// The square root of the variance
        /// </summary>
        /// <returns></returns>
        double GetStandardDeviation();

        /// <summary>
        /// Returns the Moment Generating Function
        /// </summary>
        /// <returns></returns>
        string GetMGF();

        /// <summary>
        /// Returns the Probability Mass Function
        /// </summary>
        /// <returns></returns>
        string GetPMF();

        //Learn those proofs for each Distribution before adding them
        /*
        double GetMode();
        double GetSkewness();
        double GetKurtosis();
        double GetEntropy();
        double GetCF();
        double GetPGF();
        double GetFisherInformation();
        */

    }
}
