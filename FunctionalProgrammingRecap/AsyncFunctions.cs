using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class AsyncFunctions
    {

        public static void RunThis()
        {

            Func<int, int, int> SlowFunction = delegate(int x, int y)
            {
                Thread.Sleep(x);
                return y;
            };

            //Action<int> printIt = p => Console.WriteLine(p.ToString());
            
            IAsyncResult myResult = SlowFunction.BeginInvoke(2000, 300, async =>
                {
                    var ass = (AsyncResult)async;
                    var fn = (Func<int,int,int>)ass.AsyncDelegate;
                    var res = fn.EndInvoke(ass);

                    Console.WriteLine("hello " + res.ToString());
                }, null);

            Console.WriteLine(Func3(func1, func2)(666));
          
        }

        public static void MyAsyncFunction()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Hello World");
        }

        static Func<int, int> func1 = x => x + x;
        static Func<int, int> func2 = x => x + 100;

        static Func<T1, T3> Func3<T1, T2,T3>(Func<T1,T2> f1, Func<T2,T3> f2)
        {
            return (p) => f2(f1(p));
        }

     
        
    }
}
