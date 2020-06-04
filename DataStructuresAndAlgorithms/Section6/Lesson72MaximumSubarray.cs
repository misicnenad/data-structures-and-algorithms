using System;

namespace DataStructuresAndAlgorithms.Section6
{
    public class Lesson72MaximumSubarray
    {
        private readonly int[] _defaultArray = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        public void Run(int[] array = null)
        {
            array ??= _defaultArray;

            var result = MaxSubarrayBigONSquared(array);

            Console.WriteLine(result);
        }

        // "Big O" value: O(n^2)
        public int MaxSubarrayBigONSquared(int[] nums)
        {
            var maxSum = int.MinValue;

            var len = nums.Length;
            for (var i = 0; i < len; i++)
            {
                var currentSum = nums[i];
                for (var j = i + 1; j < len; j++)
                {
                    currentSum += nums[j];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum;
        }
    }
}
