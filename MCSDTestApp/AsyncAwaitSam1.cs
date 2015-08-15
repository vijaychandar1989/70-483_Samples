using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace MCSDTestApp
{
    class AsyncAwaitSam1
    {

        public static void Main()
        {
            Console.WriteLine("Starting the Main");
            RunLoop();
            Console.WriteLine("End of  the Main");
            Console.Read();
        }

        static async void  RunLoop()
        {
            Console.WriteLine("Start of  the RunLoop");
            //await Task.Run(()=> Sleep());
            await Task.Run(()=> Sleep());
            Console.WriteLine("End of  the RunLoop");
          

        }

        static int Sleep()
        {
            Console.WriteLine("Start of  the Sleep");
            Thread.Sleep(10000);
            Console.WriteLine("End of  the Sleep");
            return 0;
        }


    }
}
