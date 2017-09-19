using StatsLib.Interfaces;
using System;

namespace StatsLib.Distributions
{
    class MGF //implement IMGF
    {
        public string RawMGF { get; set; }

        public MGF(IDistribution dist)
        {

        }
        public MGF[] GetOrders(int orderNumer)
        {
            if (orderNumer < 1) throw new ArgumentOutOfRangeException("There are no negative or 0th orders");

            var ordersArray = new MGF[orderNumer];
            for(int i = 0; i < orderNumer; ++i)
            {
                //ordersArray[i] = Stats.TakeDerivative(currentMGF); // send get request maybe
            }

            return ordersArray;
        }
    }
}
