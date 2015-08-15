using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class PLINQ
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(0, 10);
            var even = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();


            foreach (var item  in even)
            {
                Console.WriteLine(item.ToString());
            }
            
            Console.Read();
        }
    }
}
