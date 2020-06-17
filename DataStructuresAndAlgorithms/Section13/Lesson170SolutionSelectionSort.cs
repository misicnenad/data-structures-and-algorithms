using System;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Section13
{
    public class Lesson170SolutionSelectionSort
    {
        private static readonly int[] _defaultArray = new int[] { 56, 1, 99, 4, 21, 2, 6, 5, 14 };

        public void Run(int[] array = default)
        {
            array = array ?? _defaultArray;

            Console.WriteLine(array.ToPyString());

            var len = array.Length;

            for (var pos = 0; pos < len - 1; pos++)
            {
                var smallestIndex = pos;
                for (var current = smallestIndex + 1; current < len; current++)
                {
                    if (array[smallestIndex] > array[current])
                    {
                        smallestIndex = current;
                    }
                }
                var temp = array[pos];
                array[pos] = array[smallestIndex];
                array[smallestIndex] = temp;
            }

            Console.WriteLine(array.ToPyString());
        }
    }
}
