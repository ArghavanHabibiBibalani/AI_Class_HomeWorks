using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{
    public interface IStack<E>
    {
        int Size();
        bool IsEmpty();
        void Push(E e);
        E Pop();
        E Top();
    }
}
