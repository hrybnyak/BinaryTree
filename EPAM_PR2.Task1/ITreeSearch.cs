using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLibrary
{
    public interface ITreeSearch<T> where T: IComparable<T>
    {
        IEnumerator<T> TreeSearch(Node<T> node);
    }
}
