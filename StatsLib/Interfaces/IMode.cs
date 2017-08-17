using System.Collections.Generic;

namespace StatsLib.Interfaces
{
    interface IMode
    {
        IEnumerable<double> Modes { get; }
        int Frequency { get; }
    }
}
