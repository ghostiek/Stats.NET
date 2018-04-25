using StatsLib.Samples;
using System.Collections.Generic;

namespace StatsLib.Interfaces
{
    public interface ISample
    {
        List<double> Values { get; }
        ISample Union(ISample otherSamp);
        ISample Intersect(ISample otherSamp);
        ISample Add(ISample otherSamp);
        ISample Subtract(ISample otherSamp);
    }
}
