using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLibrary
{
    public class Node<T> : IComparable<T> 
                    where T : IComparable<T>
    {
        public T Value { get; }
        public Node (T value)
        {
            Value = value;
        }
        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int CompareNode(Node<T> node)
        {
            return Value.CompareTo(node.Value);
        }

        public int CompareTo(T node)
        {
            return Value.CompareTo(node);
        }

    }
}
