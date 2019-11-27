using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLibrary
{
    public class InOrderTreeSearch<T> : ITreeSearch<T>
                    where T: IComparable<T>
    {
        public IEnumerator<T> TreeSearch(Node<T> node)
        {
            var stack = new Stack<Node<T>>();

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
