using System;

namespace StatsLib.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ProbabilityAttribute : Attribute
    {
        public double RelativeProbability { get; private set; }
        public ProbabilityAttribute(double relativeProbability)
        {
            RelativeProbability = relativeProbability;
        }

    }
}
