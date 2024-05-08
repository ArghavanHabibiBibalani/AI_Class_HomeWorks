using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIClass.DataStructures.Graphs
{
    public class Vertex<V> : IVertex<V>
    {
        private V vertex;

        V IVertex<V>.Vertex { get => vertex; set => vertex = value; }

        public Vertex(V vertex)
        {
            ((IVertex<V>)this).Vertex = vertex;
        }
    }
}
