using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MCSDTestApp
{
    class RegularExpression
    {
        public static void Main()
        {
            string ValueToCheck = Console.ReadLine();

            //Match match = Regex.Match(ValueToCheck, "[0-9]{6}\\.[a-zA-z]{2}");
            //Console.WriteLine(match.Success.ToString());
            Regex regex = new Regex("[0-6]{2,}",RegexOptions.None);
            Console.WriteLine(regex.Replace(ValueToCheck, ""));
            
            Console.Read();
        }
    }
}
