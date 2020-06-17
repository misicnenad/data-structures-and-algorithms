using System;

namespace DataStructuresAndAlgorithms.Lessons.Section3
{
    public class Lesson38BigORule4 : IBaseLesson
    {
        public void Run()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            PrintAllNumbersThenAllPairSums(numbers);
        }

        // "Big O" value: O(n + n^2) = O(n^2) --> Drop Non Dominants
        // Another example: O(x^2 + 3x + 100 + x/2) = O(x^2)
        private static void PrintAllNumbersThenAllPairSums(int[] numbers)
        {
            Console.WriteLine("these are the numbers:");
            foreach (var number in numbers) // O(n)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("and these are their sums:");
            foreach (var firstNumber in numbers)  // O(n^2)
            {
                foreach (var secondNumber in numbers)
                {
                    Console.WriteLine(firstNumber + secondNumber);
                }
            }
        }
    }
}
