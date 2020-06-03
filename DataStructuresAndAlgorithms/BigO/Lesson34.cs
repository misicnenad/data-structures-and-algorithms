using System;
using System.Linq;

namespace DataStructuresAndAlgorithms.BigO
{
    public class Lesson34
    {
        public void Run()
        {
            var nemo = new string[] { "nemo" };
            var everyone = new string[] { "dory", "bruce", "marlin", "nemo", "gill", "bloat", "nigel", "squirt", "darla", "hank" };
            var large = Enumerable.Repeat("nemo", 100000).ToArray();

            FindNemo(large);
        }

        // "Big O" value: O(n) --> Worst case
        private void FindNemo(string[] array)
        {
            for (var i= 0; i < array.Length; i++)
            {
                Console.WriteLine("running");
                if (array[i] == "nemo")
                {
                    Console.WriteLine("Found NEMO!");
                    break;
                }
            }
        }
    }
}
