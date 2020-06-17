using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Lessons.Section7
{
    public class Lesson76HashCollisions : IBaseLesson
    {
        public void Run()
        {
            var user = new Dictionary<string, object>
            {
                ["age"] = 54,
                ["name"] = "Kyle",
                ["magic"] = true,
                ["scream"] = (Action) (() => Console.WriteLine("ahhhhhh!"))
            };

            Console.WriteLine(user["age"]);  // O(1)
            user["spell"] = "abra kadabra";  // O(1)
            Console.WriteLine(user["spell"]);
            ((Action)user["scream"])();  // O(1)

            // Collisions slow hash tables down to O(n)
        }
    }
}
