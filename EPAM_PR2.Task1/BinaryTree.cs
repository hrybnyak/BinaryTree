using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreeLibrary
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        private Node<T> _head;
        private ITreeSearch<T> _treeSearchStrategy;
        public ITreeSearch<T> TreeSearchStrategy
        {
            get => _treeSearchStrategy ?? (_treeSearchStrategy = new InOrderTreeSearch<T>());
            set => _treeSearchStrategy = value ?? throw new ArgumentNullException("Tree search strategy can't be null");
        }
        public BinaryTree()
        {}
        public BinaryTree(ITreeSearch<T> search)
        {
            _treeSearchStrategy = search ?? throw new ArgumentNullException("Tree search can't be null!");
        }
        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new Node<T>(item);
            }
            else
            {
                AddTo(_head, item);
            }
            Count++;
            OnNodeAdded(new Node<T>(item));
        }
        private static void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item, out var _) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }
            var items = TreeSearchStrategy.TreeSearch(_head);
            while(items.MoveNext())
            {
                array[arrayIndex++] = items.Current;
            }
        }
        private Node<T> Find(T value, out Node<T> parent)
        {
            var current = _head;
            parent = null;

            while (current != null)
            {
                var result = current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return TreeSearchStrategy.TreeSearch(_head);
        }

        public bool Remove(T item)
        {
            var current = Find(item, out var parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftMost;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                    }
                }
            }
            return true;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(T node in this)
            {
                sb.Append($"{node.ToString()} ");
            }
            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public delegate void NodeAddedEventHandler(object sender, NodeAddedEventArgs<T> e);
        public NodeAddedEventHandler NodeAdded = null;
        protected virtual void OnNodeAdded(Node<T> added)
        {
            if (NodeAdded != null) NodeAdded(this, new NodeAddedEventArgs<T>(added));
        }

    }
}
