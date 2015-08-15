using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MCSDTestApp
{
    class Task2
    {

        public static void Main()
        {
            Task<Int32[]> t = Task<Int32[]>.Run(() =>
            {
                int i;

                var result = new Int32[3];

                new Task(() =>
                {
                    result[0] = 1;
                }, TaskCreationOptions.AttachedToParent);
                new Task(() =>
                {
                    result[1] = 2;
                }, TaskCreationOptions.AttachedToParent);
                new Task(() =>
                {
                    result[2] = 3;
                }, TaskCreationOptions.AttachedToParent);

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,TaskContinuationOptions.AttachedToParent);
                tf.StartNew(() => {
                    Thread.Sleep(1000);
                    result[0] = 1;
                });
                tf.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    result[1] = 2;
                });

                tf.StartNew(() =>
                {
                    Thread.Sleep(3000);
                    result[2] = 3;
                });


                return result;

            });
            Task.WaitAll(t);
            t.ContinueWith((parenttask) =>
            {
                foreach (var item in parenttask.Result)
                {
                    Console.WriteLine(item.ToString());
                }
            });

            
            Console.Read();
        }
    }
}
