using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class CheckForNetwork
    {
        public static void Main()
        {
            CheckForInternetConnection();
        }
        public static bool CheckForInternetConnection()
        {
            Console.WriteLine("Started");
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    Console.WriteLine("Checked GG");
                    using (var stream1 = client.OpenRead("http://distriplus.net"))
                    {
                        Console.WriteLine("Connecting Distriplus....");
                        return true;
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally { Console.Read(); }

        }
    }
}
