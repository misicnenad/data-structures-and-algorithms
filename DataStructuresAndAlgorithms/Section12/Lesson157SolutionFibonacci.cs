using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Section12
{
    public class Lesson157SolutionFibonacci
    {
        public void Run(int number = 7)
        {
            var result = FibonacciRecursive(number);
            Console.WriteLine(result);
        }

        // Time "Big O": O(n)
        // Space "Big O": O(n)
        private int FibonacciIterative(int n)
        {
            var list = new List<int> { 0, 1 };

            for (var i = 2; i <= n; i++)
            {
                list.Add(list[i - 2] + list[i - 1]);
            }

            return list[n];
        }

        // Time "Big O": O(n)
        // Space "Big O": O(1)
        private int FibonacciIterativeMemoryEfficient(int n)
        {
            if (n < 2)
                return n;
            
            int previous = 0, result = 1;

            for (var i = 2; i <= n; i++)
            {
                result += previous;
                previous = result - previous;
            }

            return result;
        }

        // Time "Big O": O(2^n)
        // Space "Big O": O(n)
        private int FibonacciRecursive(int number)
        {
            if (number < 2)
                return number;

            return FibonacciRecursive(number - 1) + FibonacciRecursive(number - 2);
        }
    }
}
