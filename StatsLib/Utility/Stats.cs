using System;
using StatsLib.Utility;
using System.Collections.Generic;
using System.Linq;

namespace StatsLib.Extensions
{
    public static class Stats
    {
        public static double ArithmeticMean(IEnumerable<double> nums) => nums.Sum() / nums.Count();
        public static double Variance(IEnumerable<double> nums)
        {
            //Saving it here rather than finding it again every loop
            var mean = ArithmeticMean(nums);
            return nums.Sum(x => Math.Pow(x - mean, 2)) / nums.Count();

        }
        public static double StandardDeviation(IEnumerable<double> nums) => Math.Sqrt(Variance(nums));
        
        /// <summary>
        /// Gets the median of the IEnumerable provided. If already sorted you can specify it to make it more performent
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="isSorted"></param>
        /// <returns></returns>
        public static double Median(IEnumerable<double> nums, bool isSorted = false)
        {
            var sortedNums = nums;
            if (!isSorted)
            {
                sortedNums = nums.OrderBy(x => x);
            }
            double size = sortedNums.Count();
            var numsToSkip = (int)Math.Floor(size / 2);

            //Odd
            if (size % 2 != 0)
            {
                return sortedNums.Skip(numsToSkip).FirstOrDefault();
            }

            //Even (We take the Mean of both of them)
            var middleNums = sortedNums.Skip(numsToSkip - 1).Take(2);
            return ArithmeticMean(middleNums);
        }


        public static Mode Mode(IEnumerable<double> nums)
        {
            //Key is the number of the IEnumerable<double>, Value is the frequency
            var freqDic = new Dictionary<double, int>();
            foreach (var num in nums)
            {
                if (freqDic.TryGetValue(num, out _ ))
                {
                    freqDic[num]++;
                }
                else
                {
                    freqDic.Add(num, 1);
                }
            }

            //Gets Max Frequency. Rather than repeating it later on
            var maxFreq = freqDic.Values.Max();
            //Gets Keys with the largest frequencies
            var modes = freqDic.Where(x => x.Value == maxFreq).Select(x => x.Key).ToList();
            return new Mode(modes, maxFreq);
        }


        public static IEnumerable<double> CumSum(IEnumerable<double> nums)
        {
            var cumSum = new List<double>();
            double lastSum = 0;
            foreach (var num in nums)
            {
                cumSum.Add(num + lastSum);
                lastSum += num;
            }
            return cumSum;
        }


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
