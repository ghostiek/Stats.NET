using System;
using StatsLib.Utility;
using System.Collections.Generic;
using System.Linq; 

namespace StatsLib.Utility
{
    public static class Stat
    {
        /// <summary>
        /// Returns the Geometric Mean
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static double GeometricMean(IEnumerable<double> nums)
        {
            var enumerable = nums as IList<double> ?? nums.ToList();
            return Math.Pow(enumerable.Aggregate((a, b) => a * b), 1.0 / enumerable.Count());
        }

        /// <summary>
        /// Returns the Harmonic Mean
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static double HarmonicMean(IEnumerable<double> nums)
        {
            var enumerable = nums as IList<double> ?? nums.ToList();
            return enumerable.Count() / (enumerable.Sum(x => 1 / x));
        }

        /// <summary>
        /// Returns the Arithmetic mean, the most commonly used average
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static double ArithmeticMean(IEnumerable<double> nums)
        {
            var enumerable = nums as IList<double> ?? nums.ToList();
            return enumerable.Sum() / enumerable.Count();
        }

        /// <summary>
        /// Returns the Variance of the IEnumerable
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static double Variance(IEnumerable<double> nums)
        {
            //Saving it here rather than finding it again every loop
            var enumerable = nums as IList<double> ?? nums.ToList();
            var mean = ArithmeticMean(enumerable);
            return enumerable.Sum(x => Math.Pow(x - mean, 2)) / enumerable.Count();

        }

        /// <summary>
        /// Returns the Standard Deviation of the IEnumerable
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
            var enumerable = sortedNums as IList<double> ?? sortedNums.ToList();
            double size = enumerable.Count();
            var numsToSkip = (int)Math.Floor(size / 2);

            //Odd
            if (size % 2 != 0)
            {
                return enumerable.Skip(numsToSkip).FirstOrDefault();
            }

            //Even (We take the Mean of both of them)
            var middleNums = enumerable.Skip(numsToSkip - 1).Take(2);
            return ArithmeticMean(middleNums);
        }

        /// <summary>
        /// Returns the Mode of the IEnumerable
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the Cumulative Sum. First the sum of the 1st and 2nd element, then its sum with the 3rd etc...
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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

        public static double Range(IEnumerable<double> nums)
        {
            var enumerable = nums as IList<double> ?? nums.ToList();
            return enumerable.Max() - enumerable.Min();
        }
        
    }
}
