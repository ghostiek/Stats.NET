using StatsLib.Samples;

namespace StatsLib.Interfaces
{
    public interface ISample
    {
        Sample Union(Sample otherSamp);
        Sample Intersect(Sample otherSamp);
        Sample Add(Sample otherSamp);
        Sample Subtract(Sample otherSamp);
    }
}
