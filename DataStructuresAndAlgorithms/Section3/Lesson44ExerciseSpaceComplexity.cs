using System;

namespace DataStructuresAndAlgorithms.Section3
{
    public class Lesson44ExerciseSpaceComplexity
    {
        public void Run()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Booooo(array);

            var hiArray = ArrayOfHiNTimes(6);
            Console.WriteLine(string.Join(" ", hiArray));
        }

        // Space complexity value: O(1)
        private void Booooo(int[] n)
        {
            for (var i= 0; i < n.Length; i++)
            {
                Console.WriteLine("boooooo!");
            }
        }

        // Space complexity value: O(n)
        private string[] ArrayOfHiNTimes(int n)
        {
            var hiArray = new string[n];

            for (var i = 0; i < n; i++)
            {
                hiArray[i] = "hi";
            }

            return hiArray;
        }
    }
}
