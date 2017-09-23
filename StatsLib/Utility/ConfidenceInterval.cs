using System;
using StatsLib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Utility
{
    public class ConfidenceInterval : IMode
    {
        public IEnumerable<double> Modes { get; private set; }
        public int? Frequency { get; private set; }

        public ConfidenceInterval(IEnumerable<double> modes, int? frequency)
        {
            Modes = modes;
            Frequency = frequency;
        }
    }
}
