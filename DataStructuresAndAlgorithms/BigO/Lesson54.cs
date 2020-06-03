using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.BigO
{
    public class Lesson54
    {
        public void Run()
        {
            var array = new int[] { 6, 4, 3, 2, 1, 7 };
            var sum = 9;

            //var result = HasPairWithSum(array, sum);
            var result = HasPairWithSum2(array, sum);
            Console.WriteLine(result);
        }

        // Naive 
        private bool HasPairWithSum(int[] arr, int sum)
        {
            var len = arr.Length;
            for (var i = 0; i < len-1; i++)
            {
                for (var j = i+1; j < len; j++)
                {
                    if (arr[i] + arr[j] == sum)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Better
        private bool HasPairWithSum2(int[] arr, int sum)
        {
            var mySet = new HashSet<int>();
            var len = arr.Length;
            for (var i = 0; i < len; i++)
            {
                if (mySet.Contains(arr[i]))
                {
                    return true;
                }
                mySet.Add(sum - arr[i]);
            }
            return false;
        }
    }
}
