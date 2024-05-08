using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIClass.AI.BlindSearch
{
    public class Data<V>: IComparable<Data<V>>
    {
        public V vertex;
        public bool VF;
        public bool VNF;

        public int CompareTo(V? other)
        {
            if (other == null)
            {
                return 1;
            }
            return Comparer<V>.Default.Compare(vertex, other);
        }

        public int CompareTo(Data<V>? other)
        {
            if (other == null)
            {
                return 1;
            }
            return Comparer<V>.Default.Compare(vertex, other.vertex);
        }
    }
}
