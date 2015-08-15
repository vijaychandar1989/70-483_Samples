﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.IO;

namespace MCSDTestApp
{
    class AsyncAwait
    {

        static void Main()
        {
            // Create task and start it.
            // ... Wait for it to complete.
            Task task = new Task(ProcessDataAsync);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        static async void ProcessDataAsync()
        {
            // Start the HandleFile method.
            Task<int> task = HandleFileAsync("C:\\enable1.txt");

            // Control returns here before HandleFileAsync returns.
            // ... Prompt the user.
            Console.WriteLine("Please wait patiently " +
                "while I do something important.");

            // Wait for the HandleFile task to complete.
            // ... Display its results.
            int x = await task;
            Console.WriteLine("Count: " + x);
        }

        static async Task<int> HandleFileAsync(string file)
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
        }
    }
}
