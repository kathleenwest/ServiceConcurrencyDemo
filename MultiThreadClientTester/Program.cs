using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiThreadClientTester.ServiceConcurrencyProxyReference;


namespace MultiThreadClientTester
{
    /// <summary>
    /// TestClient
    /// Runs a simple console application that creates multiple
    /// threads to call the service to test and demo
    /// concurrency and instance modes
    /// </summary>
    class Program
    {
        // Holds Proxy to Service
        private static TestServiceClient proxy = null;
        // Holds List of Total Thread Times
        private static List<int> threadTimes = new List<int>();

        /// <summary>
        /// Main Method
        /// Main method for the program
        /// </summary>
        /// <param name="args">none used</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Press <ENTER> to begin...");
            Console.ReadLine();

            int numThreads = 50;
            proxy = new TestServiceClient();

            // Create and Run 5 threads in Parallel
            ParallelLoopResult result = Parallel.For(0, numThreads, x =>
            {
                ServiceThread(x);
            }
            );

            Console.WriteLine("Wait for all 5 threads to finish then..");
            Console.WriteLine("Press <ENTER> to run statistics...");
            Console.ReadLine();
            PrintStatistics();

            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();

        } // end of main method

        /// <summary>
        /// ServiceThread
        /// Aysynchronous method, each thread calls this method
        /// </summary>
        /// <param name="state">not used</param>
        private static async void ServiceThread(object state)
        {
            DateTime start = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Red;
            int id = (int)state;
            Console.WriteLine("Thread {0} starting...", id);

            // Thread waits for the the service call to finish.
            int svcTime = await proxy.TestMethodAsync();

            DateTime end = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thread {0} ended.  Time in thread: {1:0} ms, Time in service call: {2} ms.",
                id, end.Subtract(start).TotalMilliseconds, svcTime);
            Console.ResetColor();

            // Add this to the thread time list
            // So that statistics can be run later
            threadTimes.Add((int)end.Subtract(start).TotalMilliseconds);
        }

        /// <summary>
        /// PrintStatistics
        /// Prints statistics for the multi-thread service call
        /// tests
        /// </summary>
        private static void PrintStatistics()
        {
            Console.WriteLine();
            Console.WriteLine("Statistics...");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Average Thread Time: {threadTimes.Average()} ms");
            Console.WriteLine($"Maximum Thread Time: {threadTimes.Max()} ms");
            Console.WriteLine($"Minimum Thread Time: {threadTimes.Min()} ms");
            Console.WriteLine(new string('=', 50));
        } // end of method

    } // end of class
} // end of namespace
