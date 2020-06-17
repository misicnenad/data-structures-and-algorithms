using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Section7
{
    public class Lesson84SolutionFirstRecurringCharacter
    {
        private static readonly int[] _defaultArray = new int[] { 2, 5, 1, 2, 3, 5, 1, 2, 4 };

        public void Run(int[] array = null)
        {
            array = array ?? _defaultArray;

            var result = FirstRecurringCharacter2(array);
            Console.WriteLine(result);
        }

        // "Big O": O(n^2)
        private static int? FirstRecurringCharacter(int[] input)
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
        private static int? FirstRecurringCharacter2(int[] input)
        {
            var map = new Dictionary<int, int>();
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
