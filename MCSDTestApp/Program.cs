using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace MCSDTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(ThreadMethod));
            //t1.Priority = ThreadPriority.Lowest;
            t1.IsBackground = true;
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(ThreadMethod2));
            t2.Priority = ThreadPriority.Highest;
            t2.Start();


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(10);
            }
           
            if (t1.IsAlive)
            {
                Console.WriteLine("Thread 1 is alive. Trying abort");
                t1.Abort();

            }
            else
            {
                t1.Join();                
            }
            t2.Join();

        }

        public static void ThreadMethod()
        {

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("ThreadProc: {0} Lowest ", i);
                Thread.Sleep(10);
            }

        }

        public static void ThreadMethod2()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc2: {0} Highest", i);
                Thread.Sleep(10);
            }

        }
    }
}
