using System;

namespace DataStructuresAndAlgorithms.Section10
{
    public class Lesson134SolutionLookup
    {
        public void Run()
        {
            var tree = new BinarrySearchTree();
            tree.Insert(9);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(20);
            tree.Insert(170);
            tree.Insert(15);
            tree.Insert(1);

            Console.WriteLine(tree.Lookup(9));
            Console.WriteLine(tree.Lookup(90));
            Console.WriteLine(tree.Lookup(20));
            Console.WriteLine(tree.Lookup(170));
        }

        private class BinarrySearchTree
        {
            public Node Root { get; private set; }

            public override string ToString()
            {
                return Root.ToString();
            }

            public BinarrySearchTree Insert(int value)
            {
                var newNode = new Node(value);

                if (Root == null)
                {
                    Root = newNode;
                    return this;
                }
                else
                {
                    var currentNode = Root;
                    while (true)
                    {
                        if (value < currentNode.Value)
                        {
                            if (currentNode.Left == null)
                            {
                                currentNode.Left = newNode;
                                return this;
                            }

                            currentNode = currentNode.Left;
                        }
                        else
                        {
                            if (currentNode.Right == null)
                            {
                                currentNode.Right = newNode;
                                return this;
                            }

                            currentNode = currentNode.Right;
                        }
                    }
                }
            }

            public object Lookup(int value)
            {
                // This part is unnecessary since the while loop would automatically exit
                // but is here to be the same as in the lesson video
                if (Root == null)
                {
                    return false;
                }
                var currentNode = Root;
                while (currentNode != null)
                {
                    if (value < currentNode.Value)
                    {
                        currentNode = currentNode.Left;
                    }
                    else if (value > currentNode.Value)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        return currentNode;
                    }
                }
                return false;
            }
        }

        private class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public override string ToString()
            {
                const string nullString = "null";
                var left = Left != null ? Left.ToString() : nullString;
                var right = Right != null ? Right.ToString() : nullString;
                return $"{{\"{nameof(Value)}\":{Value},\"{nameof(Left)}\":{left},\"{nameof(Right)}\":{right}}}";
            }
        }
    }
}
