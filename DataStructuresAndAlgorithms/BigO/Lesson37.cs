using System;

namespace DataStructuresAndAlgorithms.BigO
{
    public class Lesson37
    {
        public void Run()
        {
            var boxes = new string[] { "a", "b", "c", "d", "e" };

            LogAllPairsOfArray(boxes);
        }

        // "Big O" value: O(n * n) = O(n^2) --> Quadratic Time
        private void LogAllPairsOfArray(string[] array)
        {
            for (var i= 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    Console.WriteLine($"{array[i]} {array[j]}");
                }
            }
        }
    }
}
