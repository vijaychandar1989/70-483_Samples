using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDTestApp
{
    class EventsSample
    {

        public event Action OnChange = delegate { };

        public void Raise()
        {
            OnChange();

        }


    }
    class EventHandlerSample
    {
        public event EventHandler onChange = delegate { };
        public void Raise()
        {
            onChange(this,new EventArgs());
        }
    }

    class MainClass
    {
         static void Main()
        {
           
 

            MainClass m = new MainClass();
            m.MethodCall();
            m.EventArgsMethodCall();

            EventHandlerSample ex = new EventHandlerSample();
            ex.Raise();
        }
         public void EventArgsMethodCall()
         {
             EventHandlerSample eh = new EventHandlerSample();
             eh.onChange += s_OnChange;
         }

        public void MethodCall()
        {
            EventsSample s = new EventsSample();
            s.OnChange += s_OnChange;
            new EventsSample().Raise();
        }

        public void s_OnChange()
        {
            Console.WriteLine("Event called");
            Console.Read();
        }

        public void s_OnChange(object sende, EventArgs e)
        {
            Console.WriteLine("Event Handler Sample called");
            Console.Read();
        }
    }
}
