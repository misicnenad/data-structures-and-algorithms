using System;
using System.Collections.Generic;
using System.Linq;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section6
{
    public class Lesson72MaximumSubarray : IBaseLesson
    {
        private static readonly int[] _defaultArray = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        public void Run()
        {
            var array = GetArray();
            if (array == null)
            {
                Console.WriteLine("Oops, invalid input");
                return;
            }

            var result = MaxSubarrayBigON(array);

            Console.WriteLine(result);
        }

        private static int[] GetArray()
        {
            Console.Write("Input comma separated array of integers (or press \"Enter\" for the default array): ");
            var input = Console.ReadLine().Trim();
            IList<int> list = _defaultArray;
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

            Console.Write("Input array is: " + list.ToPyString() + Environment.NewLine);
            return list.ToArray();
        }

        // Explanation: Set a maximum sum to a minimum int value
        // and find all possible sums in the array;
        // whenever you find a sum larger than the maximum sum
        // set the maximum sum to its value.
        // 
        // "Big O" value: O(n^2)
        private static int MaxSubarrayBigONSquared(int[] nums)
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

        // Explanation: Any subarray's sum is bigger with the
        // maximum sum subarray (MSS) then without it.
        // 
        // So we first need to find the subarray that starts at the
        // beginning of the input array (first index equal 0 
        // of original array) and ends at the end of the MSS 
        // (its last index is equal to MSS's last index);
        // then find out at which index does the MSS begin.
        //
        // At that point the maximum sum is found.
        // 
        // "Big O" value: O(n)
        private static int MaxSubarrayBigON(int[] nums)
        {
            var len = nums.Length;

            // If any of following two cases then
            // there is no need for further processing
            if (len == 0) return 0;
            else if (len == 1) return nums[0];

            int lastIndex = 0,
                maxSum = nums[0],
                currSum = nums[0];

            // Find MSS's last index
            for (var index = 1; index < len; index++)
            {
                currSum += nums[index];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    lastIndex = index;
                }
            }

            // Assign the current maximum sum
            currSum = maxSum;

            // Find the MSS's first index
            for (var index = 0; index < lastIndex; index++)
            {
                currSum -= nums[index];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }

            // Return the maximum sum
            return maxSum;
        }


        private static int MaxSubarrayBigONOptimized(int[] nums)
        {
            int maxSum = nums[0];
            int currSum = nums[0];
            var len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                currSum = Math.Max(nums[i], currSum + nums[i]);
                maxSum = Math.Max(maxSum, currSum);
            }

            return maxSum;
        }

    }
}
