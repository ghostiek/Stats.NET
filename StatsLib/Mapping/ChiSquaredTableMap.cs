using CsvHelper.Configuration;
using StatsLib.Tables.Classes;

namespace StatsLib.Mapping
{
    public sealed class ChiSquaredTableMap : CsvClassMap<ChiSquaredTable>
    {
        public ChiSquaredTableMap()
        {
            Map(m => m.DegreeOfFreedom).Name("DF");
            Map(m => m.P1).Name("0.995");
            Map(m => m.P2).Name("0.975");
            Map(m => m.P3).Name("0.2");
            Map(m => m.P4).Name("0.1");
            Map(m => m.P5).Name("0.05");
            Map(m => m.P6).Name("0.025");
            Map(m => m.P7).Name("0.02");
            Map(m => m.P8).Name("0.01");
            Map(m => m.P9).Name("0.005");
            Map(m => m.P10).Name("0.002");
            Map(m => m.P11).Name("0.001");
        }
    }
}
