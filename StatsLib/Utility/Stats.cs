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

        /// <summary>
        /// Gets the number of outcomes depending on the parameters
        /// </summary>
        /// <remarks>Although this seems like it should belong in the Binomial Class and the IBinomial Interface
        /// Getting the number of outcomes is used in many more distributions and thus belongs here as a Utility Method</remarks>
        /// <param name="successes"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static double BinomialCoef(double successes, double size)
        {
            return size.Factorial() / (successes.Factorial() * (size - successes).Factorial());
        }
    }
}
