using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class DelegateSample
    {

        delegate int Calc1(int x, int y);
        void Add()
        {
            //Method to be called 
            Console.WriteLine("Action Delegate Called");
            Console.Read();
        }

        public static void Main()
        {
            Action Calc;
            Calc1 c;
            //Method called using delegate
            DelegateSample dc = new DelegateSample();
            Calc = dc.Add;

            // Using lamda exp
            Calc = () => { Console.WriteLine("Hello World;"); };
            Calc += () => { Console.WriteLine("Hello World;"); };
            Calc();

            // Returning values using Lamda exp
            c = (x, y) => { return x + y; };
            Console.WriteLine(c(2, 3).ToString());

            // Sample for Build in Action delegate. Returns no values. Intakes two int parameters.
            Action<int,int> delegateAction = (x,y) => Console.WriteLine("X={0}", 6);

            // Sample for Build in Func Delegate. Must return a value. Intakes two parameters
            Func<int,int,int> delegateFunc=(x,y)=> x+y; // no need to use return keyword.

            delegateAction(2,3);

            delegateFunc(2, 3);


        }
    }
}
