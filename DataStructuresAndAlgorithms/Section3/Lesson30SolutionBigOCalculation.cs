using System;
using System.Linq;

namespace DataStructuresAndAlgorithms.Section3
{
    public class Lesson30SolutionBigOCalculation
    {
        public void Run()
        {
            var input = Enumerable.Repeat(new object(), 100).ToArray();

            FunChallenge(input);
        }

        // "Big O" value: O(3 + 4n) = O(n)
        private static int FunChallenge(object[] input)
        {
            var a = 10; // O(1)
            a = 50 + 3; // O(1)

            for (var i= 0; i < input.Length; i++)  // O(n)
            {
                AnotherFunction(); // O(n)
                var stranger = true; // O(n)
                a++; // O(n)
            }

            return a; // O(1)
        }

        private static void AnotherFunction()
        {
            Console.WriteLine("Another Function");
        }
    }
}
