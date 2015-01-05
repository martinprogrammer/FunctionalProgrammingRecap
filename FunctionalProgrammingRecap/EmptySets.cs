using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class EmptySets
    {
        public static Predicate<T> Empty<T>()
        {
            return x => false;
        }

        public static Predicate<T> All<T>()
        {
            return x => true;
        }

        public static Predicate<T> Singleton<T>(T e)
        {
            return x => x.Equals(x);
        }

        //public static Action<Employee> Age(Employee e)
        //{
        //    Console.WriteLine(DateTime.Now.Year - e.YearOfBirth);
        //}

        public static void Execute()
        {
            //Console.WriteLine("Is 7 in the set?");
            //Console.WriteLine(Empty<int>()(7));

            //Console.WriteLine("Is 7 in the set?");
            //Console.WriteLine(All<int>()(7));

            //Console.WriteLine("is 7 in the singleton?");
            //Console.WriteLine(Singleton<int>(1)(0));
            //Console.Read();

            //List<Employee> employees = new List<Employee>
            //{                
            //    new Employee{Name="Zika", Sex='M', YearOfBirth=1967},
            //     new Employee{Name="Petar", Sex='M', YearOfBirth=1935},
            //      new Employee{Name="Rubinija", Sex='Z', YearOfBirth=2000},
            //       new Employee{Name="Petrinja", Sex='Z', YearOfBirth=1977}
            //};


            //employees.Where(p=> p.YearOfBirth> 1967).Take(2).ToList().ForEach(x=>Console.WriteLine(x.Name));

            Action<string> pr = delegate(string p)
            {
                Console.WriteLine(p);
                Console.Read();
            };

            //myDelegate f = delegate(string x) { return x + " this is it"; };
            //pr(f("Hello Moci"));

            //conventientDelegate trig = Math.Sin;
            //pr(trig(232).ToString());

            //Func<string, string> capitalise = p => p.ToUpper();
            //pr(capitalise(f("Hello Moci")));

            //Predicate<string> Empty = p => String.IsNullOrEmpty(p);

            //pr(Empty("").ToString());
            string x = "9808";
            string y = "5";
            string z = "9808";

            Func<object, string> hash = p => p.GetHashCode().ToString();
            //pr(x.Equals(z).ToString());
            //pr(x.Equals(y).ToString()) ;

            conventientDelegate f1 = Math.Sin;
            conventientDelegate f2 = Math.Exp;

            //pr((f1(23)+ f2(34)).ToString());

            Func<double, double> f11 = delegate(double m) { return m * m; };

            //pr(f1(234).ToString());

            conventientDelegate multi = new conventientDelegate((p) => p * p);
            multi += (p) => p - p + 1;
            multi += (p) => p + p;


            pr(multi(2).ToString());

            multi.GetInvocationList().ToList().ForEach(p => pr(p.Method.Name));

            Func<string, string> myString = delegate(string l) { return x + "!!!!"; };

            Counting();

        }

        public static int CountTT<T>(T[] arr, Predicate<T> pred)
        {
            return arr.Where(p => pred(p)).Count();
        }

        static Predicate<string> EmptyStrings = (x) => String.IsNullOrEmpty(x);

        static string[] myArray = new[] { "Silly", "me", "I", "have", "never", "purchased", "such"};

        public static void Counting()
        {
            Console.WriteLine("Not null " + myArray.Count(delegate(string x) { return !String.IsNullOrEmpty(x); }));
            Console.WriteLine("Longest " + myArray.Count(p => EmptyStrings(p)));
            Console.WriteLine("Counting " + CountTT(myArray, EmptyStrings).ToString());

            Func<string, char> ReturnFirstLetter = delegate(string x)
            {
                return x.ToLower()[0];
            };

            myArray.OrderBy(ReturnFirstLetter).ToList().ForEach(p => Console.WriteLine(p));
            myArray.Select(ReturnFirstLetter).ToList().ForEach(p => Console.WriteLine(p));

            Records.ExteMethod(conversionFunc).ToList().ForEach(p => Console.WriteLine(p.Name));
        }

        public class Record
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Size { get; set; }
        }

        public class Cassette
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string CassetteType { get; set; }
        }

        public static List<Record> Records = new List<Record>{
            new Record{
                ID = 1,
                Name = "Weather Report",
                Size = "12 inches"
            },
             new Record{
                ID = 2,
                Name = "Lou Reed",
                Size = "12 inches"
            },
             new Record{
                ID = 3,
                Name = "Beatles",
                Size = "5 inches"
            },
             new Record{
                ID = 4,
                Name = "Keith Jarrett",
                Size = "12 inches"
            },
             new Record{
                ID = 5,
                Name = "Rolling Stones",
                Size = "5 inches"
            },
        };

        public static Func<string, string> TypeOfCassette = delegate(string recordSize){
            if(recordSize == "12 inches")
                return "C90";
            else
                return "C45";
        };

        public static Func<Record, Cassette> conversionFunc = delegate(Record myRecord)
        {
            return new Cassette
            {
                ID = myRecord.ID,
                Name = myRecord.Name,
                CassetteType = TypeOfCassette(myRecord.Size)
            };
        };

        public static IEnumerable<T2> ExteMethod<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> theFunc)
        {
            return collection.Select(p => theFunc(p));
        }



        public static void Usingg<T>(T obj, Action<T> act) where T : IDisposable
        {
            using (obj)
            {
                act(obj);
            }
        }




        delegate string myDelegate(string x);
        delegate double conventientDelegate(double x);




    }


}
