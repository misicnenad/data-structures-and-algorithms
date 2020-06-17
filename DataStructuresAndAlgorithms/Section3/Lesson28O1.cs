using System;
using System.Linq;

namespace DataStructuresAndAlgorithms.Lessons.Section3
{
    public class Lesson28O1 : IBaseLesson
    {
        public void Run()
        {
            var boxes = Enumerable.Range(0, 6).ToArray();

            LogFirstTwoBoxes(boxes);
        }

        private static void LogFirstTwoBoxes(int[] boxes)
        {
            Console.WriteLine(boxes[0]); // O(1)
            Console.WriteLine(boxes[1]); // O(1)
        }
    }
}
