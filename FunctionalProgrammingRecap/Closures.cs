using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class Closures
    {
        public static void Go()
        {
            var x = 0;
            //Func<int, int> add = delegate(int p) { x += p; return x; };
            //x = 10;
            //pr(add(7).ToString());
            //pr(add(21).ToString());
            var add = ReturnClosures.ReturnClosure();
            pr(add(15).ToString());
            pr(add(25).ToString());

            Action increment = () => x++;
            Action decrement = () => x--;
            Action printd = () => Console.WriteLine(x);

            increment();
            printd();
            decrement();
            printd();
           

        }

        public static void pr (string something)
        {
            Console.WriteLine(something);
        }

       

    }

    public static class ReturnClosures
    {
        static int newValue = 0;

        public static Func<int, int> ReturnClosure()
        {
           
            Func<int, int> add = p => newValue += p;
            newValue = 35;
            return add;
        }

    }
}
