using System;
using System.Collections.Generic;
using System.Linq;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section7
{
    public class Lesson84SolutionFirstRecurringCharacter : IBaseLesson
    {
        private static readonly object[] _defaultArray = new object[] { 2, 5, 1, 2, 3, 5, 1, 2, 4 };

        public void Run()
        {
            var array = GetArray();
            if (array == null)
            {
                Console.WriteLine("Oops, invalid input");
                return;
            }

            var result = FirstRecurringCharacter2(array);
            Console.WriteLine("First reccuring character is: " + result);
        }

        private static object[] GetArray()
        {
            Console.Write("Input comma separated array (or press \"Enter\" for the default array): ");
            var input = Console.ReadLine().Trim();
            var array = _defaultArray;
            if (!string.IsNullOrEmpty(input))
            {
                array = input.Split(',').Select(c => c.Trim()).ToArray();
                if (array.Length == 0)
                {
                    return null;
                }
            }

            Console.Write("Input array is: " + array.ToPyString() + Environment.NewLine);
            return array;
        }

        // "Big O": O(n^2)
        private static object FirstRecurringCharacter(object[] input)
        {
            for (var i = 0; i < input.Length-1; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        return input[i];
                    }
                }
            }

            return null;
        }

        // "Big O": O(n)
        private static object FirstRecurringCharacter2(object[] input)
        {
            var map = new Dictionary<object, object>();
            for (var i = 0; i < input.Length; i++)
            {
                if (map.ContainsKey(input[i]))
                {
                    return input[i];
                }
                else
                {
                    map[input[i]] = i;
                }
                Console.WriteLine(map.ToPyString());
            }
            return null;
        }
    }
}
