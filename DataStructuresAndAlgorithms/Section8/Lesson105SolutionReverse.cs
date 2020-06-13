using System;
using System.Text;

namespace DataStructuresAndAlgorithms.Section8
{
    public class Lesson105SolutionReverse
    {
        private static readonly object[] _defaultArray = new object[] { 2, 5, 1, 3, 4 };

        public void Run(object[] array = null)
        {
            array = array ?? _defaultArray;

            var linkedList = new LinkedList(array);

            Console.WriteLine(linkedList);
            ReverseRecursive(linkedList);
            Console.WriteLine(linkedList);
        }

        private static void Reverse(LinkedList linkedList)
        {
            _ = linkedList ?? throw new ArgumentNullException(nameof(linkedList));

            linkedList.Tail = linkedList.Head;
            Node previous = null;
            var current = linkedList.Head;
            var next = current?.Next;

            while (current != null)
            {
                current.Next = previous;
                previous = current;
                current = next;
                next = next?.Next;
            }

            linkedList.Head = previous;
        }

        private static void ReverseRecursive(LinkedList linkedList)
        {
            ReverseInner(null, linkedList.Head, linkedList);
        }

        private static void ReverseInner(Node previous, Node current, LinkedList linkedList)
        {
            if (current.Next == null)
            {
                linkedList.Head = current;
            }
            else
            {
                ReverseInner(current, current.Next, linkedList);
            }

            linkedList.Tail = current;
            current.Next = previous;
        }
    }

    public class LinkedList
    {
        public LinkedList(params object[] initialValues)
        {
            if (initialValues == null)
            {
                throw new ArgumentNullException(nameof(initialValues));
            }

            var len = initialValues.Length;

            if (len == 0)
            {
                throw new ArgumentException("Length can't be zero");
            }

            Head = new Node(initialValues[0]);
            Tail = Head;

            for (var i = 1; i < len; i++)
            {
                Tail.Next = new Node(initialValues[i]);
                Tail = Tail.Next;
            }
        }

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var current = Head;

            while (current != null)
            {
                sb.Append(current.Value);
                sb.Append(" ");
                current = current.Next;
            }

            return sb.ToString();
        }
    }

    public class Node
    {
        public Node(object value, Node next = null)
        {
            Value = value;
            Next = next;
        }

        public object Value { get; set; }
        public Node Next { get; set; }
    }
}
