using System;
using System.Collections.Generic;
using System.Globalization;

namespace DataStructuresAndAlgorithms.Section6
{
    public class Lesson68
    {
        public void Run()
        {
            var result = Reverse("Hi My name is Andrei!");
            Console.WriteLine(result);
        }

        // Create a function that reverses a string:
        // 'Hi My name is Andrei!' should be:
        // 'ierdnA si eman yM iH'
        private string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length < 2)
            {
                return "hmm that is not good";
            }

            var backwards = new List<char>();
            var totalItems = str.Length - 1;
            for (var i = totalItems; i >= 0; i--)
            {
                backwards.Add(str[i]);
            }

            var result = string.Join(string.Empty, backwards);
            Console.WriteLine(result);

            return result;
        }

        public string ReverseCSharpWay(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string ReverseCSharpWayMoreEfficient(string str)
        {
            return string.Create(str.Length, str, (chars, state) =>
            {
                var enumerator = StringInfo.GetTextElementEnumerator(state);
                var position = state.Length;
                while (enumerator.MoveNext())
                {
                    var cluster = ((string) enumerator.Current).AsSpan();
                    cluster.CopyTo(chars.Slice(position - cluster.Length));
                    position -= cluster.Length;
                }
            });
        }

        private string ReverseCSharpWayMostEfficient(string str)
        {
            return string.Create(str.Length, str, (chars, state) =>
            {
                var position = 0;
                var stateSpan = state.AsSpan();
                var indexes = StringInfo.ParseCombiningCharacters(state); // skips string creation
                var len = indexes.Length;
                for (var i = len - 1; i >= 0; i--)
                {
                    var index = indexes[i];
                    var spanLength = i == len - 1 ? state.Length - index : indexes[i + 1] - index;
                    stateSpan.Slice(index, spanLength).CopyTo(chars.Slice(position));
                    position += spanLength;
                }
            });
        }
    }
}
