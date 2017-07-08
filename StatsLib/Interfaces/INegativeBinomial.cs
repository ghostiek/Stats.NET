namespace StatsLib.Interfaces
{
    interface INegativeBinomial
    {
        double Probability { get; }
        uint FailureNumber { get; }
    }
}
