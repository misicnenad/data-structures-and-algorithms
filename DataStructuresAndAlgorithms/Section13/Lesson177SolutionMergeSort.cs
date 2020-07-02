using System;
using System.Collections.Generic;
using System.Linq;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section13
{
    public class Lesson177SolutionMergeSort : IBaseLesson
    {
        private static readonly IList<int> _defaultList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

        public void Run()
        {
            Console.WriteLine("Original array: " + _defaultList.ToPyString());

            var sortedArray = GetMergeSortedArray(_defaultList);

            Console.WriteLine("Sorted array: " + sortedArray.ToPyString());
        }

        private static IList<int> GetMergeSortedArray(IList<int> array)
        {
            if (array.Count == 1)
            {
                return array;
            }

            var length = array.Count;
            var middle = length / 2;
            var left = array.Take(middle).ToList();
            var right = array.Skip(middle).ToList();
            //Console.WriteLine("left:" + left.ToPyString());
            //Console.WriteLine("right:" + right.ToPyString());

            return GetMerged(
                GetMergeSortedArray(left),
                GetMergeSortedArray(right)
                );
        }

        private static IList<int> GetMerged(IList<int> left, IList<int> right)
        {
            var result = new List<int>();
            var leftIndex = 0;
            var rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            //Console.WriteLine(left.ToPyString() + " " + right.ToPyString());
            return result.Concat(left.Skip(leftIndex)).Concat(right.Skip(rightIndex)).ToList();
        }
    }
}
