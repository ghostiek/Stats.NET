namespace StatsLib.Interfaces
{
    interface IProbability
    {
        double GetProbabilityLessThanOrEqual(double input);
        double GetProbabilityLessThan(double input);
        double GetProbabilityMoreThanOrEqual(double input);
        double GetProbabilityMoreThan(double input);
    }
}
