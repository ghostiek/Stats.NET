using System.Collections.Generic;

namespace StatsLib.Interfaces
{
    public interface IMode
    {
        IEnumerable<double> Modes { get; }
        int? Frequency { get; }
    }
}
