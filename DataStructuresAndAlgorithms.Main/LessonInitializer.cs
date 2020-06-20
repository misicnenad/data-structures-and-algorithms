using DataStructuresAndAlgorithms.Lessons;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Main
{
    public static class LessonInitializer
    {
        private const int _lessonNumberStartIndex = 6;

        public static IDictionary<int, IList<IBaseLesson>> Initialize()
        {
            var lessonTypes = typeof(IBaseLesson).Assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i == typeof(IBaseLesson)))
                .GroupBy(type => GetLessonNumber(type))
                .OrderBy(group => group.Key);

            return lessonTypes.ToDictionary(group => group.Key, group => GetLessons(group));
        }

        private static int GetLessonNumber(Type type)
        {
            var lessonNumberSubstring =
                new string(type.Name.Substring(_lessonNumberStartIndex)
                    .TakeWhile(c => char.IsDigit(c))
                    .ToArray());

            return int.Parse(lessonNumberSubstring);
        }

        private static IList<IBaseLesson> GetLessons(IGrouping<int, Type> group)
        {
            return group.Select(type => (IBaseLesson) Activator.CreateInstance(type)).ToList();
        }
    }
}
