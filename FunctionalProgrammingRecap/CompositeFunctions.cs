using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class CompositeFunctions
    {
        public static void ExecuteThis()
        {
            Func<int, int> func1 = delegate(int x) { return x * x; };
            Func<int, int> func2 = delegate(int x) { return x / 5; };
            Func<int, int> func3 = delegate(int x) { return x - 17; };

            Console.WriteLine(Composite(func1, func3)(35));
        }

        public static Func<T1, T3> Composite<T1, T2, T3>(Func<T1, T2> firstOne, Func<T2, T3> secondOne)
        {
            return (x) => secondOne(firstOne(x));
        }
          
           
    }
}
