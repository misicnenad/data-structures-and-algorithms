using System;

namespace DataStructuresAndAlgorithms.Section3
{
    public class Lesson36BigORule3
    {
        public void Run()
        {
            var boxes1 = new string[] { "box1", "box2", "box3" };
            var boxes2 = new string[] { "box4", "box5", "box6" };

            CompressBoxexTwice(boxes1, boxes2);
        }

        // "Big O" value: O(boxes1 + boxes2) --> Different Terms For Inputs
        private void CompressBoxexTwice(string[] boxes1, string[] boxes2)
        {
            foreach (var box in boxes1)
            {
                Console.WriteLine(box);
            }

            foreach (var box in boxes2)
            {
                Console.WriteLine(box);
            }
        }
    }
}
