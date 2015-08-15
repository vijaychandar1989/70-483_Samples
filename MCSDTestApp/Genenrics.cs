using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCSDTestApp
{
    abstract class Animal
    {
        public bool hasLegs { get; set; }
        public bool hasFins { get; set; }
        public bool hasWings { get; set; }
        public int Legs { get; set; }
        public string Gender { get; set; }
    }

    class Hen<T> : Animal
    {
       public Hen()
        {
            this.Legs = 2;
            this.hasFins = false;
            this.hasLegs = true;
            this.hasWings = true;
           
        }

    }

    class Fish : Animal
    {
        Fish()
        {
            this.Legs = 0;
            this.hasFins = true;
            this.hasLegs = false;
            this.hasWings = false;
        }

    }
    class Egg : Animal
    {
        public string Color { get; set; }
    }


    class Genenrics
    {


        static void Main(string[] args)
        {
            Hen<Egg> hen1 = new Hen<Egg>();

            
        }

    }
}
