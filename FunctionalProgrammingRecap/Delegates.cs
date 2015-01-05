using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class Delegates
    {

        delegate double myDelegate(double x);
        public static void DelegatesPlay()
        {
            myDelegate del = delegate(double x)
            {
                Console.WriteLine("hello world {0}", x);
                return x;
            };

            //del(17);

            myDelegate del1 = x =>  x;

           // del(798);

            Func<double, double> f = Math.Sin;
            Func<double, double> l = x => x * 2;
            Func<string, bool> pred = x => x.Length > 3;

            Action<string> printTT = Console.WriteLine;

           

            //printTT += SayHello;
            //printTT("tiger");

            Func<double, double> myFUnc = delegate(double x) {
                Console.WriteLine("sthis is funny {0}", x + 1 * x);
                return x + 1 * x; };
            myFUnc+= p => p + 66;

          
            printTT(myFUnc(7).ToString());

            Predicate<string> myPred = delegate(string x) { return x.Length > 3; };
            Func<string, string> predFunc = delegate(string x) { return Convert.ToString(x.Length > 3);};

            printTT(predFunc("sd"));

            int[] intArray = Enumerable.Range(1, 2000).ToArray();
            Predicate<int> thePred = x => x>500;
            Console.WriteLine("First try {0}", intArray.CountTT(thePred));
            Console.WriteLine("Second try {0} ", intArray.CountTT1(thePred));

            Console.WriteLine(CountTT(intArray, thePred));
            Console.WriteLine(CountTT(intArray, delegate(int i) { return i > 700; }));

            // intArray.ToList().ForEach(p => Console.WriteLine(p));

            Func<int, bool> myFunc = p => p > 200;

            Console.WriteLine(intArray.Count(myFunc));
            Console.WriteLine(intArray.Any(p => p == 2001));

            intArray.TakeWhile(p => p < 30).ToList().ForEach(p => Console.WriteLine(p)); ;

            string[] stringArray = new[] { "simeon", "mitar", "Pera", "Zoran", "luka", "dejan", "Zabrtko" };
            stringArray.Select(p => p + " addendum").ToList().ForEach(p => Console.WriteLine(p));


            //stringArray.OrderBy(p=> p.Length).ThenBy(p=> p[0].ToString()).ToList().ForEach(p=>Console.WriteLine(p));

            //stringArray.MySelect(delegate(string x) { return x + " addendum"; }).ToList().ForEach(p=> Console.WriteLine(p));

            //HigherOrderFunctions();

            AsyncShit();
          
        }

        public static void AsyncShit()
        {
            Func<int, int, int> myFunc = delegate(int x, int y) { return x * y; };

            IAsyncResult async = myFunc.BeginInvoke(4,5, null, null);

            while (async.IsCompleted)
            {
                Thread.Sleep(2000);
            }

            Console.WriteLine(myFunc.EndInvoke(async));

        }

        public static void HigherOrderFunctions()
        {
            Func<int, int> XtoY = delegate(int x) { return x * 10; };
            Func<int, int> YtoZ = delegate(int x) { return x + 10; };
            Func<int, int> XtoZ = delegate(int x) { return YtoZ(XtoY(x)); };

            Console.WriteLine("Higher Order {0}", XtoZ(25));
        }

        public static IEnumerable<T> MySelect<T>(this IEnumerable<T> collection, Func<T, T> criteria)
        {
            List<T> newList = new List<T>();
            foreach(var i in collection)
            {
                newList.Add(criteria(i));
            }

            return newList;
        }

        public static void SayHello(string message)
        {
            Console.WriteLine("Hello {0}", message);
        }

            //clever thing
        public static int CountTT<T>(this IEnumerable<T> collection, Predicate<T> pred)
        {
            Expression<Func<T, bool>> expression = p => pred(p);
            return collection.AsQueryable<T>().Where(expression).Count();
        }

       public static int CountTT1<T>(this IEnumerable<T> collection, Predicate<T> pred)
        {
            return collection.AsQueryable<T>().Where(p => pred(p)).Count();
            //collection.ToList<T>().Select(p => pred(p)).ToList().ForEach(p => Console.WriteLine(p));
            //return 0; 
           
        }

        public static void Use<T>(T obj, Action<T> theAction) where T : IDisposable
       {
            using(obj)
            {
                theAction(obj);
            };
       }
    }
}
