namespace StatsLib.Interfaces
{
    interface IHypergeometric
    {
        uint PopulationSize { get; }
        uint SampleSize { get; }
        uint NumberOfSuccessInPopulation { get; }
    }
}
