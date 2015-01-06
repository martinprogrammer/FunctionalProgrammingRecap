using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class AsyncAwait
    {
        public static void DoThings()
        {
            Func<int> bookHotel = delegate()
            {
                SleepABit(2000);
                Console.WriteLine("booking hotel");
                return 1;
            };
            Func<int> bookCar = delegate()
            {
                SleepABit(2000);
                Console.WriteLine("booking car");
                return 2;
            };
            Func<int> bookPlane = delegate()
            {
                SleepABit(2000);
                Console.WriteLine("booking plane");
                return 3;
            };

            //Task<int> HotelTask = new Task<int>(bookPlane);
            //HotelTask.Start();
           // Console.WriteLine(HotelTask.Result);
            //Func<string, Task> printIt = delegate(string p)
            //{
            //    return Task.Factory.StartNew(new Action(()=>(Console.WriteLine(p))));
            //};

            Task<int> HotelTask = Task.Factory.StartNew<int>(bookHotel);
            Task<int> CarTask = Task.Factory.StartNew<int>(bookCar);
            Task<int> PlaneTask = Task.Factory.StartNew<int>(bookPlane);

            List<Func<int>> funcs = new List<Func<int>>{
                bookHotel,
                bookCar,
                bookPlane
            };



            //List<Task<int>> tasks = new List<Task<int>>{
            //    HotelTask,
            //    CarTask,
            //    PlaneTask
            //};

            Task.Run(() => bookHotel);
            Task.Run(() =>
            {
                bookHotel();
                bookPlane();
                bookCar();

            });

            //Task.Run(bookHotel);

            //tasks.Select(p => p.ContinueWith(printIt));

        }

        public static void ExecuteThis()
        {

            Console.WriteLine(ReturnSomethingAfterWait(2000).Result);
            Console.WriteLine("Done1");
            Console.WriteLine(ReturnSomethingAfterWait(1000).Result);
            Console.WriteLine("Done2");
            Console.WriteLine(ReturnSomethingAfterWait(5000).Result);
            Console.WriteLine("Done3");
            Console.WriteLine(ReturnSomethingAfterWait(500).Result);
            Console.WriteLine("Done4");
        }

        public static Task SleepABit(int duration)
        {
            return Task.Factory.StartNew(()=> Thread.Sleep(duration));
        }

        public static Task<string> ReturnSomethingAfterWait(int duration)
        {
           
            //var result=  Task.Run(() => String.Format("Came back after {0}", duration));
            var result = Task.Factory.StartNew<string>(
                delegate()
                {
                    SleepABit(duration);
                    return String.Format("Came bsck after {0}", duration);
                });

            return result;
        }
    }
}
