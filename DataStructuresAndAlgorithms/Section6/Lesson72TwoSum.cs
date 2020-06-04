﻿using System;

namespace DataStructuresAndAlgorithms.Section6
{
    public class Lesson72TwoSum
    {
        private readonly int[] _defaultNums = new int[] { 2, 7, 11, 15 };

        public void Run(int[] nums = null, int target = 9)
        {
            nums ??= _defaultNums;
            var result = TwoSum(nums, target);
            Console.WriteLine(string.Join(", ", result));
        }

        private int[] TwoSum(int[] nums, int target)
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
