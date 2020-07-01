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
            if (!GetInputArray(out var array))
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Original array: " + array.ToPyString());

            var sortedArray = GetInsertionSortedArray(array);

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

        private bool GetInputArray(out IList<int> array)
        {
            Console.WriteLine("Please insert a comma-separated array of integers (no spaces) or press \"Enter\" to use the input example below.");
            Console.WriteLine($"Input example: {string.Join(",", _defaultList)}\n");

            Console.Write("Input: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                array = _defaultList;
                return true;
            }

            var numberStrings = input.Split(',');
            array = new List<int>(numberStrings.Length);
            foreach (var numStr in numberStrings)
            {
                if (!int.TryParse(numStr, out var number))
                {
                    Console.WriteLine("Oops, invalid input :(");
                    return false;
                }

                array.Add(number);
            }

            return true;
        }
    }
}
