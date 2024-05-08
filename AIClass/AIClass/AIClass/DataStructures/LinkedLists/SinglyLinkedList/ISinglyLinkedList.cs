using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedLists.SinglyLinkedList
{
    public interface ISinglyLinkedList<E>
    {
        int Size { get; }
        bool IsEmpty();
        E First();
        E Last();
        void AddFirst(E e);
        void AddLast(E e);
        E RemoveFirst();
    }
}
