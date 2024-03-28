using DataStructures.Lists.PositionalLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    internal interface IBinaryTree<E> : ITree<E>
    {
        IPosition<E> Left(IPosition<E> position);
        IPosition<E> Right(IPosition<E> position);
        IPosition<E> Sibling(IPosition<E> position);
    }
}
