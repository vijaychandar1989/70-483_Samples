using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MCSDTestApp
{
    class ParallelClass
    {
        public static void Main()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("For =>" + i.ToString());
            });


            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Foreach =>" + i.ToString());
            });


            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
{
    if (i == 500)
    {
        Console.WriteLine("Breaking loop" + i.ToString());
        //loopState.Break();
        loopState.Stop();
    }

    return;
});
            Console.WriteLine(result.IsCompleted.ToString() + result.LowestBreakIteration.ToString());

            Console.Read();
        }
    }
}
