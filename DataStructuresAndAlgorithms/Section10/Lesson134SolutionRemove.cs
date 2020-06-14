using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Section10
{
    public class Lesson134SolutionRemove
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
            //Console.WriteLine(tree.Lookup(9));
            //Console.WriteLine(tree.Lookup(90));
            //Console.WriteLine(tree.Lookup(20));
            //Console.WriteLine(tree.Lookup(170));
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

            public bool Remove(int value)
            {
                if (Root == null)
                    return false;
                
                var currentNode = Root;
                Node parentNode = null;

                while (currentNode != null)
                {
                    if (value < currentNode.Value)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.Left;
                    }
                    else if (value > currentNode.Value)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        // We have a match, get to work!

                        // Option 1: No right child
                        if (currentNode.Right == null)
                        {
                            if (parentNode == null)
                            {
                                Root = currentNode.Left;
                            }
                            else
                            {
                                // if parent > current value, make current
                                // left child a child of parent
                                if (currentNode.Value < parentNode.Value)
                                {
                                    parentNode.Left = currentNode.Left;
                                }

                                // if parent < current value, make left
                                // child  a right child of parent
                                else if (currentNode.Value > parentNode.Value)
                                {
                                    parentNode.Right = currentNode.Left;
                                }
                            }
                        }

                        // Option 2: Right child which doesnt have a
                        // left child
                        else if (currentNode.Right.Left == null)
                        {
                            if (parentNode == null)
                            {
                                Root = currentNode.Left;
                            }
                            else
                            {
                                currentNode.Right.Left = currentNode.Left;

                                // if parent > current, make right child
                                // of the left the parent
                                if (currentNode.Value < parentNode.Value)
                                {
                                    parentNode.Left = currentNode.Right;
                                }

                                // if parent < current, make right child a
                                // right child of the parent
                                else if (currentNode.Value > parentNode.Value)
                                {
                                    parentNode.Right = currentNode.Right;
                                }
                            }
                        }

                        // Option 3: Right child that has a left child
                        else
                        {
                            // find the Right child's left most child
                            var leftmost = currentNode.Right.Left;
                            var leftmostParent = currentNode.Right;
                            while (leftmost.Left != null)
                            {
                                leftmostParent = leftmost;
                                leftmost = leftmost.Left;
                            }

                            // Parent's left subtree is now leftmost's
                            // right subtree
                            leftmostParent.Left = leftmost.Right;
                            leftmost.Left = currentNode.Left;
                            leftmost.Right = currentNode.Right;

                            if (parentNode == null)
                            {
                                Root = leftmost;
                            }
                            else
                            {
                                if (currentNode.Value < parentNode.Value)
                                {
                                    parentNode.Left = leftmost;
                                }
                                else if (currentNode.Value > parentNode.Value)
                                {
                                    parentNode.Right = leftmost;
                                }
                            }
                        }

                        return true;
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
