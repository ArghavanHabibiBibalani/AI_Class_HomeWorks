using DataStructures.Lists.PositionalLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public interface ITree<E> : IEnumerable<E>
    {
        IPosition<E> Root { get; set; }
        IPosition<E> Parent(IPosition<E> ppsition);
        IEnumerable<IPosition<E>> Children(IPosition<E> position);
        int Numchildren(IPosition<E> position);
        bool IsInternal(IPosition<E> position);
        bool IsExternal(IPosition<E> position);
        bool IsRoot(IPosition<E> position);
        bool IsLeaf(IPosition<E> position);
        int Size();
        bool IsEmpty();
        IEnumerator<E> Enumerator();
        IEnumerable<IPosition<E>> Positions();

    }
}
