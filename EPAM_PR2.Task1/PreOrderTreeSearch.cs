using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLibrary
{
    public class PreOrderTreeSearch<T> : ITreeSearch<T>
                    where T : IComparable<T>
    {
        public IEnumerator<T> TreeSearch(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();

                yield return node.Value;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
    }
}

