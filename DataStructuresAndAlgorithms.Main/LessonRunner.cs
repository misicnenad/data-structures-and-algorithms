using DataStructuresAndAlgorithms.Lessons;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Main
{
    public class LessonRunner
    {
        private const string _show = "show";
        private const string _s = "s";
        private const string _no = "no";
        private const string _n = "n";

        private const StringComparison _ordinalIgnoreCase = StringComparison.OrdinalIgnoreCase;

        public void Run()
        {
            var lessonsDict = LessonInitializer.Initialize();

            OutputIntroMessage(lessonsDict);

            RunLessons(lessonsDict);
        }

        private static void OutputIntroMessage(IDictionary<int, IList<IBaseLesson>> lessonsDict)
        {
            Console.WriteLine("Hello. To run the lessons simply follow the instructions below\n");
            OutputAvailableLessons(lessonsDict);
        }

        private static void OutputAvailableLessons(IDictionary<int, IList<IBaseLesson>> lessonsDict)
        {
            Console.WriteLine("Available lessons:\n");
            foreach (var (lessonNumber, lessonObject) in lessonsDict)
            {
                Console.WriteLine(lessonNumber + ". " + string.Join(", ", lessonObject.Select(lesson => lesson.GetType().Name)));
            }
        }

        private static void RunLessons(IDictionary<int, IList<IBaseLesson>> lessonsDict)
        {
            var runAnotherLesson = true;
            while (runAnotherLesson)
            {
                Console.Write($"Enter the number of the lesson example you want to run or type \"{_show}\" or \"{_s}\" (without quotes) to see available lessons: ");

                var input = Console.ReadLine().Trim();

                if (!TryGetLesson(input, lessonsDict, out var lesson))
                {
                    continue;
                }

                Console.WriteLine($"Running {lesson.GetType().Name}...\n");
                lesson.Run();

                runAnotherLesson = ShouldRunAnotherLesson();
            }
        }

        private static bool TryGetLesson(string input, IDictionary<int, IList<IBaseLesson>> lessonsDict, out IBaseLesson lesson)
        {
            lesson = default;

            var success = !TryOutputAvailableLessons(input, lessonsDict)
                && TryParseInt(input, out var lessonNumber)
                && TryGetLessonFromDict(lessonNumber, lessonsDict, out lesson);

            return success;
        }

        private static bool TryGetLesson(string input, IDictionary<int, IBaseLesson> lessonsDict, out IBaseLesson lesson)
        {
            lesson = default;

            var success = TryParseInt(input, out var lessonNumber)
                && TryGetLessonFromDict(lessonNumber, lessonsDict, out lesson);

            return success;
        }

        private static bool TryGetLessonFromDict(int lessonNumber, IDictionary<int, IList<IBaseLesson>> lessonsDict, out IBaseLesson lesson)
        {
            lesson = default;

            if (lessonsDict.TryGetValue(lessonNumber, out var lessons))
            {

                if (lessons.Count == 1)
                {
                    lesson = lessons.SingleOrDefault();
                }
                else
                {
                    if (!TryGetSublesson(lessons, out lesson))
                    {
                        return false;
                    }
                }
                return true;
            }

            Console.WriteLine("Unfortunatelly there's no lesson with that lesson number :( Press any key to try again");
            Console.ReadLine();
            return false;
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

        private static bool TryGetSublesson(IList<IBaseLesson> lessons, out IBaseLesson lesson)
        {
            lesson = default;

            var tempDict = 
                lessons.Select((l, index) => (index: index + 1, lesson: l))
                    .ToDictionary(x => x.index, x => x.lesson);

            Console.WriteLine("Available exercises in the lesson: ");
            foreach (var item in tempDict)
            {
                Console.WriteLine($"{item.Key}. {item.Value.GetType().Name}");
            }

            Console.Write("Which lesson do you want to run? ");
            var input = Console.ReadLine().Trim();
            
            if (!TryGetLesson(input, tempDict, out lesson))
            {
                return false;
            }

            return true;
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

        private static bool TryOutputAvailableLessons(string input, IDictionary<int, IList<IBaseLesson>> lessonsDict)
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

        private static bool ShouldRunAnotherLesson()
        {
            Console.WriteLine($"\nGreat! Type \"{_no}\" or \"{_n}\" to exit, or hit any other key to run another lesson.");
            Console.Write("Run another lesson? ");
            var input = Console.ReadLine().Trim();

            return !IsEqualToNo(input);
        }

        private static bool IsEqualToNo(string input)
        {
            return input.Equals(_no, _ordinalIgnoreCase) || input.Equals(_n, _ordinalIgnoreCase);
        }
    }
}
