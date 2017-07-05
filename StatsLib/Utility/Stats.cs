using System;

namespace StatsLib.Extensions
{
    public static class Stats
    {
        public static double Factorial(this double val)
        {
            if (val < 0) throw new ArithmeticException("Cannot find factorial of a negative number.");
            if (val <= 1) return 1;
            return val * Factorial(val - 1);
        }

        public static double BinomialCoef(double successes, double size)
        {
            return size.Factorial() / (successes.Factorial() * (size - successes).Factorial());
        }
      
        public static double GetExactGeometricProbability(double probability, double number)
        {
            return Math.Pow(1 - probability, number - 1) * probability;
        }

        public static double GetExactNegativeBinomialProbability(double probability, uint number, double input)
        {
            return BinomialCoef(input - 1, number - 1) * Math.Pow(probability, number) * Math.Pow(1 - probability, input - number);
        }
    }
}
