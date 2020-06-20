using System;
using System.Collections.Generic;
using System.Linq;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section6
{
    public class Lesson72TwoSum : IBaseLesson
    {
        private static readonly int[] _defaultNums = new int[] { 2, 7, 11, 15 };

        public void Run()
        {
            var nums = GetArray();
            if (nums == null)
            {
                Console.WriteLine("Oops, invalid input");
                return;
            }
            var target = GetTarget();
            if (target == null)
            {
                Console.WriteLine("Oops, invalid target sum");
                return;
            }

            var result = TwoSum(nums, target.Value);
            Console.WriteLine(result.ToPyString());
        }

        private static int[] GetArray()
        {
            Console.Write("Input comma separated array of integers (or press \"Enter\" for the default array): ");
            var input = Console.ReadLine().Trim();
            IList<int> list = _defaultNums;
            if (!string.IsNullOrEmpty(input))
            {
                var strArray = input.Split(',').Select(c => c.Trim()).ToArray();
                if (strArray.Length == 0)
                {
                    return null;
                }

                list = new List<int>();
                foreach (var item in strArray)
                {
                    if (!int.TryParse(item, out var res))
                    {
                        Console.WriteLine($"Can't parse {item} into an integer :(");
                        return null;
                    }
                    list.Add(res);
                }
            }

            Console.Write("Input array is: " + list.ToPyString());
            return list.ToArray();
        }

        private int? GetTarget()
        {
            Console.Write("What is the target sum? ");
            var input = Console.ReadLine().Trim();
            if (int.TryParse(input, out var sum))
            {
                return sum;
            }

            return null;
        }

        private static int[] TwoSum(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;

            while (start < end)
            {
                var currentResult = nums[start] + nums[end];
                if (currentResult == target)
                {
                    return new int[] { start, end };
                }
                else if (currentResult < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
