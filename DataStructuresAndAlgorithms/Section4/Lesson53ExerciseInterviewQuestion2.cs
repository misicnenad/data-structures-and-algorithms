using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Section4
{
    public class Lesson53ExerciseInterviewQuestion2
    {
        public void Run()
        {
            var array1 = new object[] { "a", "b", false, "x" };
            var array2 = new object[] { "z", true, "y" };

            var result = ContainsCommonItem4(array1, array2);
            Console.WriteLine(result);
        }

        // "Big O" value: O(a*b)
        // Space complexity value: O(1)
        private static bool ContainsCommonItem(object[] arr1, object[] arr2)
        {
            for (var i = 0; i < arr1.Length; i++)
            {
                for (var j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // "Big O" value: O(a + b)
        // Space complexity value: O(a)
        private static bool ContainsCommonItem2(object[] arr1, object[] arr2)
        {
            // loop through first array and 
            // create dictionary where keys == items in 
            // the array

            // can we assume always 2 params?
            
            var map = new Dictionary<object, bool>();
            for (var i = 0; i < arr1.Length; i++)
            {
                map[arr1[i]] = true;
            }

            // loop through second array and check
            // if item in second array exists on 
            // created object
            for (var j = 0; j < arr2.Length; j++)
            {
                if (map.ContainsKey(arr2[j]))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ContainsCommonItem3(object[] arr1, object[] arr2)
        {
            return arr1.Any(item => arr2.Contains(item));
        }

        // C# way of doing intersection
        private static bool ContainsCommonItem4(object[] arr1, object[] arr2)
        {
            //return arr1.Intersect(arr2).Any();
            return arr1.Join(arr2, o => o, i => i, (o, i) => o).Any(); // More performant
        }
    }
}
