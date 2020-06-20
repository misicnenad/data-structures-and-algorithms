using System;

namespace DataStructuresAndAlgorithms.Lessons.Section12
{
    public class Lesson155SolutionFactorial : IBaseLesson
    {
        public void Run()
        {
            var number = GetNumber();
            if (number == null)
            {
                Console.WriteLine("Oops, invalid input");
                return;
            }

            var result = FindFactorialIterative(number.Value);
            Console.WriteLine(result);
        }

        private int? GetNumber()
        {
            Console.Write("Input the number for which you want a factorial: ");
            var input = Console.ReadLine().Trim();
            if (int.TryParse(input, out var sum))
            {
                return sum;
            }

            return null;
        }

        // "Big O": O(n)
        private int FindFactorialRecursive(int number)
        {
            if (number < 2)
                return 1;

            return number * FindFactorialRecursive(number - 1);
        }

        // "Big O": O(n)
        private int FindFactorialIterative(int number)
        {
            if (number < 3)
                return number;
            
            var result = 2;

            for (var i = 3; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
