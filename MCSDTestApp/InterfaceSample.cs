using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    interface IAnimal
    {
         int Legs { get; set; }
         void CanMove();
    }

    class InterfaceSample:IAnimal   
    {
        public int Legs { get; set; }
        public void CanMove()
        {
            Console.WriteLine("Animal can move..!!!");
        }
    }

    class InterfaceMainClass
    {
        public static void Main()
        {
            InterfaceSample interfacesample = new InterfaceSample();
            interfacesample.CanMove();
 
        }
    }
}
