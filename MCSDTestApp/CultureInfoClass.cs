using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class CultureInfoClass
    {


        public static void Main()
        {
            DateTime now = DateTime.Now;
            CultureInfo   en_in =new CultureInfo("fr-FR");
            Console.WriteLine(now.ToString("D", en_in));

            Console.Read();
        }
    }
}
