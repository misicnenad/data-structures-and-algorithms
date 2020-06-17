using System;

namespace DataStructuresAndAlgorithms.Section12
{
    public class Lesson160ExerciseReverseStringWithRecursion
    {
        public void Run(string str = "yoyo master")
        {
            var result = ReverseStringRecursive(str);
            Console.WriteLine(result);
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
