using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _02.RaceCondition
{
    public class RaceConditionExample
    {
        private static List<int> _numbers;

        static void Main(string[] args)
        {
            _numbers = Enumerable.Range(0, 100).ToList();
            //Thread t1 = new Thread(RemoveFromList);
            //Thread t2 = new Thread(RemoveFromList);
            //Thread t3 = new Thread(RemoveFromList);
            List<Thread> threads = new List<Thread>
            {
                new Thread(RemoveFromList),
                new Thread(RemoveFromList),
                new Thread(RemoveFromList),

            };
            foreach (var thread in threads)
            {
                thread.Start();
            }


        }

        public static void RemoveFromList()
        {
            lock (_numbers)
            {
                while (_numbers.Count > 0)
                {
                    int lastIndex = _numbers.Count - 1;
                    _numbers.RemoveAt(lastIndex);
                }
            }
            
        }

    }
}
