using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    internal interface IQueue<E>
    {
        int Size();
        bool IsEmpty();
        void Enqueue(E e);
        E Dequeue();
        E First();

    }
}
