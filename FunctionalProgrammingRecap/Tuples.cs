
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class Tuples
    {
        public static Tuple<double, double> Tupless()
        {
            Random myRandom = new Random();

            var x = myRandom.NextDouble()*10;
            var y = myRandom.NextDouble()*10;


            return Tuple.Create(x , y );

        }

        public static Predicate<Tuple<double, double>> myPred = p => (p.Item1 * p.Item1 + p.Item2 * p.Item2) < 150;

        public static void RunTuples()
        {
              Console.WriteLine("number 1  {0}, number 2 {1}", Tupless().Item1, Tupless().Item2);

              Console.WriteLine("is less than - {0}", myPred(Tupless()));
              

        }
    }
}
