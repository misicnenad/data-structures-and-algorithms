using DataStructuresAndAlgorithms.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Main
{
    class Program
    {
        private const string _show = "show";
        private const string _s = "s";
        private const string _no = "no";
        private const string _n = "n";
        private const int _lessonNumberStartIndex = 6;


        private const StringComparison _ordinalIgnoreCase = StringComparison.OrdinalIgnoreCase;

        static void Main(string[] args)
        {
            var lessonsDict = InitializeLessonsDict();

            OutputIntroMessage(lessonsDict);

            RunLessons(lessonsDict);
        }

        private static IDictionary<int, IBaseLesson> InitializeLessonsDict()
        {
            var lessonTypes = typeof(IBaseLesson).Assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseLesson)));

            return lessonTypes.ToDictionary(GetKey, GetValue);
        }

        private static int GetKey(Type type)
        {
            var lessonNumberSubstring = 
                new string(type.Name.Substring(_lessonNumberStartIndex)
                                    .TakeWhile(c => char.IsDigit(c))
                                    .ToArray());

            return int.Parse(lessonNumberSubstring);
        }

        private static IBaseLesson GetValue(Type type)
        {
            return (IBaseLesson) Activator.CreateInstance(type);
        }

        private static void RunLessons(IDictionary<int, IBaseLesson> lessonsDict)
        {
            var runAnotherLesson = true;
            while (runAnotherLesson)
            {
                Console.Write($"Enter the number of the lesson example you want to run or type \"{_show}\" or \"{_s}\" (without quotes) to see available lessons: ");

                var input = Console.ReadLine();

                if (!TryGetLesson(input, lessonsDict, out var lesson))
                {
                    continue;
                }

                Console.WriteLine($"Running {lesson.GetType().Name}...\n");
                lesson.Run();

                runAnotherLesson = ShouldRunAnotherLesson();
            }
        }

        private static bool TryGetLesson(string input, IDictionary<int, IBaseLesson> lessonsDict, out IBaseLesson lesson)
        {
            lesson = default;

            var success = !TryOutputAvailableLessons(input, lessonsDict)
                && TryParseInt(input, out var lessonNumber)
                && TryGetLessonFromDict(lessonNumber, lessonsDict, out lesson);

            return success;
        }

        private static bool TryGetLessonFromDict(int lessonNumber, IDictionary<int, IBaseLesson> lessonsDict, out IBaseLesson lesson)
        {
            if (lessonsDict.TryGetValue(lessonNumber, out lesson))
            {
                return true;
            }

            Console.WriteLine("Unfortunatelly there's no lesson with that lesson number :( Press any key to try again");
            Console.ReadLine();
            return false;
        }

        private static bool TryParseInt(string input, out int lessonNumber)
        {
            if (int.TryParse(input, out lessonNumber))
            {
                return true;
            }

            Console.WriteLine("Oops, that's not an integer! Press any key to try again");
            Console.ReadLine();
            return false;
        }

        private static bool TryOutputAvailableLessons(string input, IDictionary<int, IBaseLesson> lessonsDict)
        {
            if (IsEqualToShow(input))
            {
                OutputAvailableLessons(lessonsDict);

                return true;
            }

            return false;
        }

        private static bool IsEqualToShow(string input)
        {
            return input.Equals(_show, _ordinalIgnoreCase) || input.Equals(_s, _ordinalIgnoreCase);
        }

        private static void OutputIntroMessage(IDictionary<int, IBaseLesson> lessonsDict)
        {
            Console.WriteLine("Hello. To run the lessons simply follow the instructions below\n");
            OutputAvailableLessons(lessonsDict);
        }

        private static void OutputAvailableLessons(IDictionary<int, IBaseLesson> lessonsDict)
        {
            Console.WriteLine("Available lessons:\n");
            foreach (var (lessonNumber, lessonObject) in lessonsDict)
            {
                Console.WriteLine(lessonNumber + ": " + lessonObject.GetType().Name);
            }
        }

        private static bool ShouldRunAnotherLesson()
        {
            Console.WriteLine($"\nGreat! Type \"{_no}\" or \"{_n}\" to exit, or hit any other key to run another lesson.");
            Console.Write("Run another lesson? ");
            var input = Console.ReadLine();

            return !IsEqualToNo(input);
        }

        private static bool IsEqualToNo(string input)
        {
            return input.Equals(_no, _ordinalIgnoreCase) || input.Equals(_n, _ordinalIgnoreCase);
        }
    }
}
