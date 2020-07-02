using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section13
{
    public class Lesson170SolutionSelectionSort : IBaseLesson
    {
        private static readonly IList<int> _defaultList = new List<int> { 56, 1, 99, 4, 21, 2, 6, 5, 14 };

        public void Run()
        {
            Console.WriteLine("Original array: " + _defaultList.ToPyString());
            
            var sortedArray = GetSelectionSortedArray(_defaultList);

            Console.WriteLine("Sorted array: " + sortedArray.ToPyString());
        }

        private static IList<int> GetSelectionSortedArray(IList<int> array)
        {
            var len = array.Count;

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

            return array;
        }
    }
}
