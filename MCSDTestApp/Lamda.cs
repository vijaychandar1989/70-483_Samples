using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class Lamda
    {
        delegate int Calculator(int x,int y);
      static   Calculator Calc = (x, y) => x + y;


        public static void Main()
        {
           
            Console.WriteLine(Calc(3,4));


            Console.Read();
        }

    }
}
