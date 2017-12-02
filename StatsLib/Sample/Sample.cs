using System;
using System.Collections.Generic;
using System.Linq;
using StatsLib.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace StatsLib.Samples
{
    public class Sample : ISample
    {
        public List<double> Values { get; private set; }

        public Sample(IEnumerable<double> val)
        {
            Values = val.ToList();
        }

        public Sample(int from, int to, int size, bool unique = false)
        {
            if (from > to) throw new ArgumentOutOfRangeException(nameof(@from), "from is larger than to");
            if (to - from < size && unique) throw new ArgumentOutOfRangeException(
                    nameof(to), "The interval between from and to is too small. Consider changing the interval, decreasing the size or having replace as true");

            //Initializing our List of Values
            Values = new List<double>();

            var rand = new Random();
            for (var i = 0; i < size; i++)
            {
                //Gets Random Number
                var rngNum = rand.Next(from, to + 1);

                //If replace is True and we already have the value inside the List then we will regenerate the number
                while(unique && Values.Contains(rngNum))
                {
                    rngNum = rand.Next(from, to + 1);
                }

                Values.Add(rngNum);
            }

        }

        public Sample(double from, double to, int size, bool unique = false)
        {
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from), "from is larger than to");

            //Initializing our List of Values
            Values = new List<double>();

            var rand = new Random();

            for (var i = 0; i < size; i++)
            {
                var rngNum = rand.Next((int)from, (int)to - 1) + rand.NextDouble();

                //This is super unlikely to ever happen considering the precision
                while (unique && Values.Contains(rngNum))
                {
                    rngNum = rand.Next((int)from, (int)to - 1) + rand.NextDouble();
                }
                Values.Add(rngNum);
            }
        }

        public Sample(int from, int to, int size, IEnumerable<double> weighedProb)
        {
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from), "from is larger than to");
            if (weighedProb.Sum() != 1) throw new ArgumentOutOfRangeException(nameof(weighedProb), "Probability IEnumerable doesn't add up to 1");
            if (weighedProb.All(x => x < 0 || x > 1)) throw new ArgumentOutOfRangeException(nameof(weighedProb), "Some probabilities are smaller than 0 or larger than 1");

            //Initializing our List of Values
            Values = new List<double>();

            var rand = new Random();
            //Our sequence to pick from
            var sequence = Enumerable.Range(from, size);
            for (var i = 0; i < size; i++)
            {
                //Probability, picking the number
                var rngNum = rand.NextDouble();

                var index = 0;
                foreach (var prob in weighedProb)
                {
                    //Removes the prob element from rngNum to find out which element the probability landed on
                    rngNum -= prob;
                    //Checks if we've reached the probability yet
                    if (rngNum < 0)
                    {
                        break;
                    }
                    //If we have not we increase our index
                    ++index;
                }
                Values.Add(sequence.ElementAt(index));
            }
        }

        //Calls constructor Sample(IEnumerable<double> val)
        public Sample(IDistribution dist, int size) : this(dist.GetRandomSample(size)){}

        /// <summary>
        /// Returns the Union of 2 Samples
        /// </summary>
        /// <param name="otherSamp"></param>
        /// <returns></returns>
        public Sample Union(Sample otherSamp) => new Sample(Values.Union(otherSamp.Values));

        /// <summary>
        /// Union Operator
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Sample operator |(Sample A, Sample B) => A.Union(B);

        /// <summary>
        /// Returns the Intersect of 2 Samples
        /// </summary>
        /// <param name="otherSamp"></param>
        /// <returns></returns>
        public Sample Intersect(Sample otherSamp) => new Sample(Values.Intersect(otherSamp.Values));

        /// <summary>
        /// Interesect Operator 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Sample operator &(Sample A, Sample B) => A.Intersect(B);

        /// <summary>
        /// Adds two Samples
        /// </summary>
        /// <param name="otherSamp"></param>
        /// <returns></returns>
        public Sample Add(Sample otherSamp)
        {
            var placeholder = new List<double>(Values);
            placeholder.AddRange(otherSamp.Values);
            return new Sample(placeholder);
        }

        /// <summary>
        /// Operator shortcut to add two samples
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Sample operator +(Sample A, Sample B) => A.Add(B);

        /// <summary>
        /// Removes all elements that are in common and returns a new Sample
        /// </summary>
        /// <param name="otherSamp"></param>
        /// <returns></returns>
        public Sample Subtract(Sample otherSamp)
        {
            var placeholder = new List<double>(Values);
            foreach (var val in otherSamp.Values)
            {
                placeholder.Remove(val);
            }
            return new Sample(placeholder);
        }

        /// <summary>
        /// Operator shortcut for subtracting two samples
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Sample operator -(Sample A, Sample B) => A.Subtract(B);












        /// <summary>
        /// Returns the Confidence Interval depending on the certainty you input. Warning: The <code>Certainty</code> needs to be between
        /// 0 and 1 (Since it is a percentage)
        /// </summary>
        /// <param name="certainty"></param>
        /// <param name="isTwoTailed"></param>
        /// <returns></returns>
        //public ConfidenceInterval ConfidenceInterval(IEnumerable<double> sample, double certainty, bool isTwoTailed, int iterations = 1,
        //    double? PopulationSD = null)
        //{
        //    if (certainty < 0 || certainty > 1) throw new ArgumentOutOfRangeException("certainty", "Cannot be smaller than 0 or greater than 1");

        //    for (int i = 0; i < iterations; i++)
        //    {

        //    }
        //}
    }
}
