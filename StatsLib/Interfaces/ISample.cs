using StatsLib.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Interfaces
{
    interface ISample
    {
        Sample Union(Sample otherSamp);
        Sample Intersect(Sample otherSamp);
        Sample Add(Sample otherSamp);
        Sample Subtract(Sample otherSamp);
    }
}
