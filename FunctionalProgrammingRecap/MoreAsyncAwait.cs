using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgrammingRecap
{
    public static class MoreAsyncAwait
    {
        public static void ExecuteThis()
        {
            //MoreAsync();
            SomeWebsites();
        }

        public static void MoreAsync()
        {
            Action<string> Print = delegate(string p) { Console.WriteLine(p); };
            Action<int> WaitABit = p => Thread.Sleep(p);

            Task<int> hotelBookingTask = new Task<int>(delegate()
            {
                WaitABit(2000);
                Print("HotelBooked");
                return 1234;
            });
            Task<int> carBookingTask = new Task<int>(delegate()
            {
                WaitABit(3000);
                Print("CarBooked");
                return 52234;
            });
            Task AirplaneBookingTask = new Task(delegate()
            {
                WaitABit(5000);
                Print("AirplaneBooked");
                
            });


            //carBookingTask.Start();
            //AirplaneBookingTask.RunSynchronously();


           Task.WhenAny(hotelBookingTask, carBookingTask, AirplaneBookingTask).ContinueWith(p=> AirplaneBookingTask.Start());
           hotelBookingTask.Start();
            

        }

        public static void SomeWebsites()
        {
            string[] websites = new string[]{
                "http://www.bbc.co.uk",
                "http://www.antiquestradegazette.com",
                "http://www.guardian.co.uk",
                "http://www.gumtree.com"
            };

            List<Task<string>> tasks = new List<Task<string>>();

            websites.ToList().ForEach(
                delegate (string p)
                {
                Console.WriteLine("Done with {0}", p);
                CreateTask(p);
                });

        }

        private  static async void CreateTaskAsync(string p)
        {
            WebClient myClient = new WebClient();
            Uri myUri = new Uri(p, UriKind.Absolute);

            //myClient.DownloadStringCompleted+= (sender, e) => await e.Result;

            Console.Write(await myClient.DownloadStringTaskAsync(myUri));
            

          
        }

    



    }
}
