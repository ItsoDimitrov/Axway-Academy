using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace _01.AsynchronousCodeExample
{
    class Asynchronous
    {
        static void Main(string[] args)
        {

            Task task = new Task(TakeMaxValueOfIntAsync);
            task.Start();
            Console.WriteLine("Im calculating but you are not blocked");
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "exit")
                {
                    break;
                }

                command = Console.ReadLine();
            }
        }

        private static void TakeMaxValueOfIntAsync()
        {
            for (int i = 0; true; i++)
            {
                if (i == int.MaxValue)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
