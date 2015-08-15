using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class TypeCasting
    {

        public static void Main()
        {
            GetValue(5.36F);
        }
        public static void GetValue(float val)
        {
            object obj = val;
            int value = (int)(float)obj;
        }
    }
}
