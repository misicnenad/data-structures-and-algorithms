using System;

namespace DataStructuresAndAlgorithms.Section3
{
    public class Lesson35BigORule2
    {
        public void Run()
        {
            var items = new string[] { "item1", "item2", "item3" };

            PrintFirstItemThenFirstHalfThenSayHi100Times(items);
        }

        // "Big O" value: O(1 + n/2 + 100) = O(n/2 + 101) = O(n/2 + 1) = O(n + 1) = O(n) --> Remove Contants
        private void PrintFirstItemThenFirstHalfThenSayHi100Times(string[] items)
        {
            Console.WriteLine(items[0]); // O(1)

            var middleIndex = Math.Floor(items.Length / 2.0);
            var index = 0;

            while (index < middleIndex)  // O(n/2)
            {
                Console.WriteLine(items[index]);
                index++;
            }

            for (var i= 0; i < 100; i++) // O(100)
            {
                Console.WriteLine("hi");
            }
        }

        // "Big O" value: O(2n) = O(n)
        private void CompressBoxexTwice(string[] boxes)
        {
            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
