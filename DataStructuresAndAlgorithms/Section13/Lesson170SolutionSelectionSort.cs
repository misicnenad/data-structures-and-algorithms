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
            if (!GetInputArray(out var array))
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Original array: " + array.ToPyString());

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

            Console.WriteLine("Sorted array: " + array.ToPyString());
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
