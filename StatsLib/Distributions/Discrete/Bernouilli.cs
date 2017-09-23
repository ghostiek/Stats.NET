namespace StatsLib.Distributions.Discrete
{
    public class Bernouilli : Binomial
    {
        public Bernouilli(double probability) : base(probability, 1)
        {
        }
    }
}
