using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Lessons.Section13
{
    public class Lesson180OptionalExerciseQuickSort : IBaseLesson
    {
        private static readonly IList<int> _defaultList = new List<int> { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

        public void Run()
        {
            Console.WriteLine("Original array: " + _defaultList.ToPyString());

            var sortedArray = QuickSort(_defaultList, 0, _defaultList.Count - 1);

            Console.WriteLine("Sorted array: " + sortedArray.ToPyString());
        }

        private static IList<int> QuickSort(IList<int> array, int left, int right)
        {
            var len = array.Count;
            
            if (left < right)
            {
                var pivot = right;
                var partitionIndex = Partition(array, pivot, left, right);

                //sort left and right
                QuickSort(array, left, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, right);
            }
            return array;
        }

        private static int Partition(IList<int> array, int pivot, int left, int right)
        {
            var pivotValue = array[pivot];
            var partitionIndex = left;

            for (int i = left; i < right; i++)
            {
                if (array[i] < pivotValue)
                {
                    Swap(array, i, partitionIndex);
                    partitionIndex++;
                }
            }
            Swap(array, right, partitionIndex);
            return partitionIndex;
        }

        private static void Swap(IList<int> array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
