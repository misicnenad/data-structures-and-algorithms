using System;
using System.Linq;

namespace DataStructuresAndAlgorithms.BigO
{
    public class Lesson28
    {
        public void Run()
        {
            var boxes = Enumerable.Range(0, 6).ToArray();

            LogFirstTwoBoxes(boxes);
        }

        private void LogFirstTwoBoxes(int[] boxes)
        {
            Console.WriteLine(boxes[0]); // O(1)
            Console.WriteLine(boxes[1]); // O(1)
        }
    }
}
