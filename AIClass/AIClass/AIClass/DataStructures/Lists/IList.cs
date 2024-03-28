using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    internal interface IList<E>
    {
        int Size();
        bool IsEmpty();
        E Get(int index);
        E Set(int index, E value);
        void Add(int index, E value);
        E Remove(int index);

    }
}
