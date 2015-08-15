using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCSDTestApp
{
    class ClassSample
    {
       protected string Prop
        {
             get;
             set;
        }
        static void Main(string[] args)
        {

            DogClass d1 = new DogClass();
            DogStruct d2 = new DogStruct();

            ClassSample c = new ClassSample();
            d1.Color = "Red";
            d1.Name = "Dog1";

            //d2.Color = "Red";
            //d2.Name = "Dog2";
            Console.WriteLine("***************Dog 1**********************");
            Console.WriteLine("Color" + d1.Color + " ; Name: " + d1.Name);
            Console.WriteLine("***************Dog 2**********************");
            Console.WriteLine("Color" + d2.Color + " ; Name: " + d2.Name);
            c.PrintValue(d1);
            c.PrintValue(d2);
            Console.WriteLine("***************After Print value**********************");
            Console.WriteLine("***************Dog 1**********************");
            Console.WriteLine("Color" + d1.Color + " ; Name: " + d1.Name);
            Console.WriteLine("***************Dog 2**********************");
            Console.WriteLine("Color" + d2.Color + " ; Name: " + d2.Name);

        }

        public void PrintValue(DogClass dg1)
        {
            Console.WriteLine("Inside the Method Print value- Class");
            dg1.Color = "RedModified";
            dg1.Name = "Dog1Modified";
            Console.WriteLine("Color" + dg1.Color + " ; Name: " + dg1.Name);


        }
        public void PrintValue(DogStruct dg1)
        {
            //Console.WriteLine("Inside the Method Print value- Struct");
            //dg1.Color = "RedModified";
            //dg1.Name = "Dog1Modified";
            Console.WriteLine("Color" + dg1.Color + " ; Name: " + dg1.Name);

        }
    }

    class DogClass
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public DogStruct S1;

        public DogClass()
        {

        }
    }
    struct DogStruct
    {
        public string Color;//{ get; private set; }
        public string Name;//  { get; private set; }
        public void GetValue() { }
        public DogStruct(string _color, string _name)
        {
            this.Color = "RedModified";
            this.Name = "Dog1Modified";
        }

    }
}
