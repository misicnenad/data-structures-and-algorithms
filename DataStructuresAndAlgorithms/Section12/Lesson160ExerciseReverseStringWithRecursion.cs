using System;

namespace DataStructuresAndAlgorithms.Lessons.Section12
{
    public class Lesson160ExerciseReverseStringWithRecursion : IBaseLesson
    {
        public void Run()
        {
            Console.Write("Input string to reverse: ");
            var str = Console.ReadLine();
            Console.WriteLine("Original string: " + str);

            var reversed = ReverseStringRecursive(str);
            Console.WriteLine("Reversed string: " + reversed);
        }

        private string ReverseStringRecursive(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return ReverseStringRecursive(str.Substring(1)) + str[0];
        }
    }
}
