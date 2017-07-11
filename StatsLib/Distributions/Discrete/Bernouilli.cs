using StatsLib.Extensions;
using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    public class Bernouilli : Binomial
    {
        public Bernouilli(double probability) : base(probability, 1)
        {
        }
    }
}
