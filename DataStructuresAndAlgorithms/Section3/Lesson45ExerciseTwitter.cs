using System;

namespace DataStructuresAndAlgorithms.Section3
{
    public class Lesson45ExerciseTwitter
    {
        // Find 1st, Find Nth..
        public void Run()
        {
            var array = new string[] { "hi", "my", "teddy" };

            Console.WriteLine(array[0]); // O(1)
            Console.WriteLine(array[array.Length - 1]); // O(1)

            // Comparing dates would have the "Big O" value: O(n^2) 
            // Might need to change the data structure
            var array2 = new object[]
            {
                new
                {
                    tweet = "hi",
                    date = 2012
                },
                new
                {
                    tweet = "my",
                    date = 2014
                },
                new
                {
                    tweet = "teddy",
                    date = 2018
                },
            };

            // In C# this has "Big O" value: O(1)
            var length = "asdfasdfasdfadsfa".Length;
        }
    }
}
