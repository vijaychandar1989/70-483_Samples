using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCSDTestApp
{
    class LivingThings
    {
        protected bool hasLife;
        public LivingThings()
        {
            Console.WriteLine("Living Things Def constructor");
            hasLife = true;
        }

        public LivingThings(string Name)
        {
            Console.WriteLine("Living Things with Name {0}", Name);
            hasLife = true;
        }

        public  void isAlive()
        {
            int age = 0;
            Console.WriteLine("Thing is alive: {0}", hasLife);

        }
    }
    class Animals : LivingThings
    {
        public Animals()
        {
            Console.WriteLine("Animal Def constructor");
            hasLife = true;
        }
        public void isAlive()
        {

            Console.WriteLine("Animal is alive: {0}", hasLife);

        }
        
    }


    class Inheritance
    {
        static void Main(string[] args)
        {

            LivingThings l = new LivingThings();
            LivingThings l1 = new LivingThings("Human");
            Animals a = new Animals();
            LivingThings al = new Animals();
            l.isAlive();
            l1.isAlive();
            a.isAlive();
            al.isAlive();


        }

    }
}
