using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Lessons.Section7
{
    public class Lesson80Keys : IBaseLesson
    {
        public void Run()
        {
            var myHashTable = new HashTable(50);

            myHashTable.Set("grapes", 10000);
            Console.WriteLine(myHashTable);

            myHashTable.Set("apples", 54);
            Console.WriteLine(myHashTable);

            myHashTable.Set("oranges", 2);
            Console.WriteLine(myHashTable);

            var value = myHashTable.Keys();
            Console.WriteLine(string.Join(", ", value));
        }

        private class HashTable
        {
            private readonly List<object[]>[] _data;

            public HashTable(int size)
            {
                _data = new List<object[]>[size];
            }

            // "Big O": O(1)
            private int Hash(string key)
            {
                var hash = 0;
                for (var i = 0; i < key.Length; i++)
                {
                    hash = (hash + key[i] * i) % _data.Length;
                }

                return hash;
            }

            // "Big O": O(1)
            public List<object[]>[] Set(object key, object value)
            {
                var address = Hash(key.ToString());
                if (_data[address] == null)
                {
                    _data[address] = new List<object[]>();
                }
                _data[address].Add(new object[] { key, value });

                return _data;
            }

            // "Big O": O(1)
            public object Get(object key)
            {
                var address = Hash(key.ToString());
                var currentBucket = _data[address];
                var currentBucketString = currentBucket.Select(cb => $"[{cb[0]}, {cb[1]}]");
                Console.WriteLine(string.Join(", ", currentBucketString));
                if (currentBucket != null)
                {
                    for (var i = 0; i < currentBucket.Count; i++)
                    {
                        if (currentBucket[i][0] == key)
                        {
                            return currentBucket[i][1];
                        }
                    }
                }
                return null;
            }

            public List<object> Keys()
            {
                var keysArray = new List<object>();
                for (var i = 0; i < _data.Length; i++)
                {
                    if (_data[i] != null)
                    {
                        for (var j = 0; j < _data[i].Count; j++)
                        {
                            keysArray.Add(_data[i][j][0]);
                        }
                    }
                }

                return keysArray;
            }

            // C# doesn't have an inbuilt support for printing 
            // arrays, lists, dictionaries etc.
            public override string ToString()
            {
                var stringArray = _data.Where(list => list != null).Select(list => $"[{ListOfArraysToString(list)}]");
                return $"[{string.Join(", ", stringArray)}]";
            }

            private static string ListOfArraysToString(List<object[]> list)
            {
                return string.Join(", ", list.Select(keyValue => $"[{keyValue[0]}, {keyValue[1]}]"));
            }
        }
    }
}
