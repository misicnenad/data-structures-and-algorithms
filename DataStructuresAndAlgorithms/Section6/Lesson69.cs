using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Section6
{
    public class Lesson69
    {
        public void Run()
        {
            var array1 = new int[] { 0, 3, 4, 31 };
            var array2 = new int[] { 4, 6, 30 };
            var result = MergeSortedArrays(array1, array2);

            Console.WriteLine(string.Join(" ", result));
        }

        private int[] MergeSortedArrays(int[] array1, int[] array2)
        {
            var mergedLength = array1.Length + array2.Length;
            var mergedArray = new List<int>(mergedLength);

            int? array1Item = array1[0];
            int? array2Item = array2[0];
            var i = 0;
            var j = 0;

            if (array1.Length == 0)
            {
                return array2;
            }
            if (array2.Length == 0)
            {
                return array1;
            }

            while ((array1Item != null || array2Item != null)
                && (i < array1.Length || j < array2.Length))
            {
                if (array2Item is null || array1Item < array2Item)
                {
                    mergedArray.Add(array1Item.Value);
                    array1Item = array1[i];
                    i++;
                }
                else
                {
                    mergedArray.Add(array2Item.Value);
                    array2Item = array2[j];
                    j++;
                }
            }

            return mergedArray.ToArray();
        }
    }
}
