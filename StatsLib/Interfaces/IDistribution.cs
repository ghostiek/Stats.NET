namespace StatsLib.Interfaces
{
    interface IDistribution
    {

        double GetMean();
        double GetVariance();
        double GetStandardDeviation();
        string GetMGF();
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
