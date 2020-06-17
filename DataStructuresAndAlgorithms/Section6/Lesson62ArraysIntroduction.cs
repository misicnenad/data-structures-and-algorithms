using System;
using System.Collections.Generic;
using System.Linq;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Section6
{
    public class Lesson62ArraysIntroduction
    {
        public void Run()
        {
            ShowcaseArrays();
        }

        // In .NET Lists and IEnumerables are used more often than arrays
        private static void ShowcaseLists()
        {
            // Lists are internally represented as dynamic arrays
            var strings = new List<string> { "a", "b", "c", "d" };
            // 4x2 = 8 bytes of storage in .NET

            // push
            strings.Add("e"); // O(1)

            // C# doesn't have the JavaScript "pop" method for Lists
            strings.RemoveAt(strings.Count - 1);
            strings.RemoveAt(strings.Count - 1); // O(1)

            // Since lists internally have a dynamic array
            // it needs to move all the elements to the right
            // in order to insert "x"
            strings.Insert(0, "x"); // O(n)

            // There is no C# equivalent to JavaScript's "splice"
            strings.Insert(2, "alien"); // O(n)

            Console.WriteLine(strings.ToPyString());
        }

        private static void ShowcaseArrays()
        {
            var strings = new string[] { "a", "b", "c", "d" };
            // 4x2 = 8 bytes of storage in .NET

            // push
            // string[] is fixed size, so extensions methods are necessary
            strings = strings.Append("e").ToArray(); // O(n)

            // C# doesn't have the JavaScript "pop" method for arrays
            strings = strings.Take(strings.Length - 1).ToArray();
            strings = strings.Take(strings.Length - 1).ToArray(); // O(n)

            // Same as JavaScript "unshift" method
            strings = strings.Prepend("x").ToArray(); // O(n)

            // There is no C# equivalent to JavaScript's "splice"
            // Inserting into arrays in C# is inefficient
            var tempList = strings.ToList();
            tempList.Insert(2, "alien");
            strings = tempList.ToArray();

            Console.WriteLine(strings.ToPyString());
        }
    }
}
