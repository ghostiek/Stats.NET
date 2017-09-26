using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Utility
{
    public static class Calculate
    {
        public static double Factorial(this double val)
        {
            if (val < 0) throw new ArithmeticException("Cannot find factorial of a negative number.");
            if (val <= 1) return 1;
            return val * Factorial(val - 1);
        }

        public static double SequenceSummation(int from, int to, Func<double, double> equation)
        {
            double total = 0;
            for (var i = from; i <= to; i++)
            {
                total += equation(i);
            }
            return total;
        }

        public static double SequenceProduct(int from, int to, Func<double, double> equation)
        {
            double total = 1;
            for (var i = from; i <= to; i++)
            {
                total *= equation(i);
            }
            return total;
        }
    }
}
