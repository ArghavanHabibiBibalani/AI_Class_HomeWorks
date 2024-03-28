using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Iteratore
{
    internal interface IIterator<E> : IEnumerator<E>
    {
        public bool HasNext();
        public E Next();
        public void Remove();
    }
}
