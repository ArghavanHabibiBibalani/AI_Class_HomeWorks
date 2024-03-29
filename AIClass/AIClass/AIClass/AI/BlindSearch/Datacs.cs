using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIClass.AI.BlindSearch
{
    internal class Data<V>
    {
        public IVertex<V> vertex;
        public bool VF;
        public bool VNF;
    }
}
