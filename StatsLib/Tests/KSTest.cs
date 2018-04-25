using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatsLib.Interfaces;

namespace StatsLib.Tests
{
    public class KSTest
    {
        public double PValue { get; private set; }
        public double D { get; private set; }

        /// <summary>
        /// One Sample KS Test
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="continuousDistribution"></param>
        public KSTest(ISample sample, Func<double, double> function, IContinuousDistribution continuousDistribution,
            double sigLevel = 0.05)
        {
            var distances = new List<double>();
            foreach (var i in sample.Values)
            {
                var y = function(i);
                distances.Add(Math.Abs(y - continuousDistribution.GetCdf(i)));
            }

            D = Math.Sqrt(sample.Values.Count) * distances.Max();

            //Find how to do P value


        }

        /// <summary>
        /// Two Sample KS Test
        /// </summary>
        /// <param name="firstSample"></param>
        /// <param name="secondSample"></param>
        /// <param name="alpha"></param>

        public KSTest(ISample firstSample, ISample secondSample, double alpha = 0.05)
        {
            //var firstSampleWithRef = (Values: firstSample.Values, Treatment: Enumerable.Repeat(1, firstSample.Values.Count));
            //var secondSampleWithRef = (Values: secondSample.Values, Treatment: Enumerable.Repeat(2, firstSample.Values.Count));

            //var combinedSample = (firstSample.Union(secondSample), treatment);

            //var combinedInfo = new List<(double x, double cdf1, double cdf2, double absdif)>();

            //foreach(var i in firstSample.Values)
            //{
            //    var cdf1 = firstSample.Values.Count(x => x == i) / firstSample.Values.Count;
            //    var cdf2 = secondSample.Values.Count(x => x == i) / secondSample.Values.Count;
            //    var absdif = Math.Abs(cdf1 - cdf2);

            //    combinedInfo.Add((i, cdf1, cdf2, absdif));
            //}


            ////Number of KS >= KS Observed
            //int counter = 0;

            //foreach (var element in firstSample.Values)
            //{

            //}

            //PValue = counter;

            throw new NotImplementedException();
        }
    }
}
