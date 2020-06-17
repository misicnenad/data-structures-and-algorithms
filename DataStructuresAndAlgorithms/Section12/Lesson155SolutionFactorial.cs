using System;

namespace DataStructuresAndAlgorithms.Section12
{
    public class Lesson155SolutionFactorial
    {
        public void Run(int number = 5)
        {
            var result = FindFactorialIterative(number);
            Console.WriteLine(result);
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
