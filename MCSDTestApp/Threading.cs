using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MCSDTestApp
{
    class Threading
    {
        [ThreadStatic]
        static int inc;


        static void StaticThreadMethod(Object stateInfo) 
        {
            Console.WriteLine("Called Static Thread Method");
        }



        public void ThreadMethod(object calledfrom)
        {
            inc = 10;
            ThreadLocal<int> local = new ThreadLocal<int>(() =>
            {
                return DateTime.Now.Millisecond;
            });


            new Thread(() =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                inc += local.Value;
                Console.WriteLine(local.Value);
                Console.WriteLine(inc);
                Console.WriteLine(Thread.CurrentThread.Priority);
                for (int i = 0; i < 100; i++)
                {

                    Console.WriteLine("Highest {0}", i);
                    Thread.Sleep(10);

                }
                new Thread(() =>
                {

                    Console.WriteLine("Child Thread" + Thread.CurrentThread.Priority);


                }).Start();

            }).Start();
            //Thread.Sleep(100);
            new Thread(() =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                inc += local.Value;
                Console.WriteLine(local.Value);
                Console.WriteLine(inc);
                Console.WriteLine(Thread.CurrentThread.Priority);
                for (int i = 0; i < 100; i++)
                {

                    Console.WriteLine("Lowest {0}", i);
                    Thread.Sleep(10);
                }
            }).Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    inc++;
            //    Console.WriteLine("ThreadProc: {0} Lowest| from Thread {1} | incr {2}", i.ToString(), calledfrom.ToString(), inc.ToString());
            //    Thread.Sleep(10);
            //}

        }



        static void Main(string[] args)
        {
            bool stopped = false;



            //Thread t = new Thread(new ThreadStart(() =>
            //{
            //    while (!stopped)
            //    {
            //        inc++;
            //        Console.WriteLine("Running..." + inc.ToString());
            //        Thread.Sleep(1000);
            //    }
            //}));
            //t.Start();

            //new Threading().ThreadMethod(0);

            ThreadPool.QueueUserWorkItem(new WaitCallback(StaticThreadMethod));
            Console.WriteLine("Main thread does some work, then sleeps.");
           
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits.");

            //Console.WriteLine(local.Value);
            //Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod));
            ////t2.Priority = ThreadPriority.Highest;
            //t2.Start("1");

            //Thread t3 = new Thread(new ParameterizedThreadStart(ThreadMethod));
            ////t2.Priority = ThreadPriority.Highest;
            //t3.Start("2");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            //t.Join();

            //Console.WriteLine("T1" + inc.ToString());

        }
    }
}
