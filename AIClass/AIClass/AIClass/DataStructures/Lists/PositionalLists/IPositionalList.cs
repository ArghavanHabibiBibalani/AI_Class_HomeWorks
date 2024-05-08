using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists.PositionalLists
{
    public interface IPositionalList<E>
    {
        int Size();
        bool IsEmpty();
        IPosition<E> First();
        IPosition<E> Last();
        IPosition<E> Befor(IPosition<E> position);
        IPosition<E> After(IPosition<E> position);
        IPosition<E> AddFirst(E element);
        IPosition<E> AddLast(E element);
        IPosition<E> AddAfter(IPosition<E> position, E element);
        IPosition<E> AddBefore(IPosition<E> position, E element);
        E Set(IPosition<E> position, E element);
        E Remove(IPosition<E> position);

    }
}
