using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MCSDTestApp
{
    class CustomAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    class SampleAttribute : Attribute
    {
        public int Value { get; set; }
        public SampleAttribute(string value)
            : base()
        {

        }

        public SampleAttribute(int value)
            : base()
        {

            Value = value;
        }
    }

    [Sample(3)]
    class TestAttribute
    {
        int val;
        public TestAttribute()
        {

        }
    }
}
