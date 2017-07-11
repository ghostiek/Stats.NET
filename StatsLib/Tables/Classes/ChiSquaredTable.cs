using StatsLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StatsLib.Tables.Classes
{
    //Note to self. Please find a better way to do this.
    public class ChiSquaredTable
    {
        public int DegreeOfFreedom { get; set; }

        [Probability(0.995)]
        public double P1 { get; set; }

        [Probability(0.975)]
        public double P2 { get; set; }

        [Probability(0.2)]
        public double P3 { get; set; }

        [Probability(0.1)]
        public double P4 { get; set; }

        [Probability(0.05)]
        public double P5 { get; set; }

        [Probability(0.025)]
        public double P6 { get; set; }

        [Probability(0.02)]
        public double P7 { get; set; }

        [Probability(0.01)]
        public double P8 { get; set; }

        [Probability(0.005)]
        public double P9 { get; set; }

        [Probability(0.002)]
        public double P10 { get; set; }

        [Probability(0.001)]
        public double P11 { get; set; }

        private Dictionary<double, double> Row { get; set; }


        public Dictionary<double, double> GetDictionary()
        {
            if (Row != null) return Row;

            Row = new Dictionary<double, double>();
            PropertyInfo[] PropsInfo = typeof(ChiSquaredTable).GetProperties();

            foreach (var PropInfo in PropsInfo)
            {
                if (PropInfo.CustomAttributes.Count() > 0)
                {
                    var PropAttribute = (ProbabilityAttribute)PropInfo.GetCustomAttribute(typeof(ProbabilityAttribute));

                    double Prob = PropAttribute.RelativeProbability;

                    Row.Add(Prob, Convert.ToDouble(PropInfo.GetValue(this)));
                }
            }
            return Row;
        }
    }
}
