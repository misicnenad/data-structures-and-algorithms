using System;

namespace DataStructuresAndAlgorithms.Lessons.Section10
{
    public class Lesson131SolutionInsert : IBaseLesson
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

            Console.WriteLine(tree);
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
                    return InsertPatternMatchingInternal(value, newNode);
                }
            }

            private BinarrySearchTree InsertInternal(int value, Node newNode)
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

            private BinarrySearchTree InsertPatternMatchingInternal(int value, Node newNode)
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
                        else
                        {
                            currentNode = currentNode.Left;
                        }
                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = newNode;
                            return this;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                }
            }

            //
            //
            //
            // ATTENTION: method below is the same as above, but uses pattern matching and requires 
            // the project to use C# version 8.
            //
            // To enable it, go to DataStructuresAndAlgorithms.csproj and in <PropertyGroup> tag insert
            // the tag below:
            //              "<LangVersion>8</LangVersion>" (without quotes)
            //
            //private BinarrySearchTree InsertPatternMatchingInternal(int value, Node newNode)
            //{
            //    var currentNode = Root;
            //    while (true)
            //    {
            //        switch (value < currentNode.Value, currentNode.Left, currentNode.Right)
            //        {
            //            case (true, null, _):
            //                currentNode.Left = newNode;
            //                return this;
            //            case (true, _, _):
            //                currentNode = currentNode.Left;
            //                break;
            //            case (_, _, null):
            //                currentNode.Right = newNode;
            //                return this;
            //            case (_, _, _):
            //                currentNode = currentNode.Right;
            //                break;
            //            default:
            //                throw new NotImplementedException($"({value < currentNode.Value}, {currentNode.Left}, {currentNode.Right})");
            //        }
            //    }
            //}
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
