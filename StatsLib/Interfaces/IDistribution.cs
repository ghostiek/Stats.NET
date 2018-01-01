using System.Collections.Generic;

namespace StatsLib.Interfaces
{
    public interface IDistribution
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
        /// Returns the Moment Generating Function at a certain point t
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        double GetMgf(double t);

        /// <summary>
        /// Returns the Probability Density Function
        /// </summary>
        /// <returns></returns>
        double GetPdf(double x);

        /// <summary>
        /// Returns an IEnumerable of Sample values
        /// </summary>
        /// <returns></returns>
        IEnumerable<double> GetRandomSample(int size);

        /// <summary>
        /// Returns the Mode of the Distribution
        /// </summary>
        /// <returns></returns>
        //double GetMode();

        //Learn those proofs for each Distribution before adding them
        /*
        double GetSkewness();
        double GetKurtosis();
        double GetEntropy();
        double GetCF();
        double GetPGF();
        double GetFisherInformation();
        */

    }
}
