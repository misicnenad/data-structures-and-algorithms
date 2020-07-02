using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section13
{
    public class Lesson174SolutionInsertionSort : IBaseLesson
    {
        private static readonly IList<int> _defaultList = new List<int> { 56, 1, 99, 4, 21, 2, 6, 5, 14 };

        public void Run()
        {
            Console.WriteLine("Original array: " + _defaultList.ToPyString());

            var sortedArray = GetInsertionSortedArray(_defaultList);

            Console.WriteLine("Sorted array: " + sortedArray.ToPyString());
        }

        private static IList<int> GetInsertionSortedArray(IList<int> array)
        {
            var length = array.Count;

            for (var i = 1; i < length; i++)
            {
                var current = array[i];
                if (current < array[0])
                {
                    array.RemoveAt(i);
                    array.Insert(0, current);
                }
                else
                {
                    for (var j = 1; j < i; j++)
                    {
                        if (array[i] > array[j-1] && array[i] < array[j])
                        {
                            array.RemoveAt(i);
                            array.Insert(j, current);
                        }
                    }
                }
            }

            return array;
        }
    }
}
