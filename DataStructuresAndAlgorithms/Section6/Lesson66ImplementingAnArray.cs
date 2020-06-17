using System;
using System.Collections.Generic;
using System.Linq;

using Collections.Extensions.ToPyString;

namespace DataStructuresAndAlgorithms.Section6
{
    public class Lesson66ImplementingAnArray
    {
        public void Run()
        {
            var newArray = new MyArray();

            newArray.Push("hi");
            newArray.Push("you");
            newArray.Push("!");
            newArray.Delete(0);
            newArray.Push("are");
            newArray.Push("nice");
            newArray.Delete(1);
            Console.WriteLine(newArray);
        }

        // Implementing arrays in C# doesn't make a lot of sense
        // but this is here to showcase how it can be done
        // and would happen under the hood
        private class MyArray
        {
            private int _length = 0;
            private readonly IList<object> _data = new List<object>();

            public object this[int index]
            {
                get => _data[index];
                set => _data[index] = value;
            }

            public int Push(object item)
            {
                _data.Add(item);
                _length++;
                
                return _length;
            }

            public object Pop()
            {
                var lastItem = _data[_length - 1];
                _data.Remove(lastItem);
                _length--;

                return lastItem;
            }

            public void Delete(int index)
            {
                ShiftItems(index);
            }

            private void ShiftItems(int index)
            {
                for (var i = index; i < _length-1; i++)
                {
                    _data[i] = _data[i + 1];
                }
                _data.RemoveAt(_length - 1);
                _length--;
            }

            public override string ToString()
            {
                var array = _data.Select((d, i) => $"{i}: '{d}'");
                return $"{{ length: {_length}, data: {{ {array.ToPyString()} }} }}";
            }
        }
    }
}
