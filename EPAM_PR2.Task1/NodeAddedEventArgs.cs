using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLibrary
{
    public class NodeAddedEventArgs<T>: System.EventArgs where T: IComparable<T>
    {
        public readonly Node<T> Node;
        public NodeAddedEventArgs(Node<T> node)
        {
            Node = node;
        }
    }
}
