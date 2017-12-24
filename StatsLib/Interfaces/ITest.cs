namespace StatsLib.Interfaces
{
    public interface ITest
    {
        double? Statistic { get; }
        double? PValue { get; }
        int DegreeOfFreedom { get; }
    }
}
