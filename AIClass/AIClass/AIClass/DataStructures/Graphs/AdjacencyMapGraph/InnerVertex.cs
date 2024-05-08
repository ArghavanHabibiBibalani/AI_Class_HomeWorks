using DataStructures.Lists.PositionalLists;
using DataStructures.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.AdjacencyMapGraph
{
    public class InnerVertex<V, E> : IVertex<V>
    {
        private V element;
        private IPosition<IVertex<V>> position;
        private IMap<IVertex<V>, IEdge<E>> outGoing;
        private IMap<IVertex<V>, IEdge<E>> inComing;

        public InnerVertex(V e, bool graphIsDirected)
        {
            element = e;
            outGoing = new Map<IVertex<V>, IEdge<E>>();

            if (graphIsDirected)
            {
                inComing = new Map<IVertex<V>, IEdge<E>>();
            }
            else
            {
                inComing = outGoing;
            }
        }

        V IVertex<V>.Vertex { get => element; set => element = value; }

        public void setPosition(IPosition<IVertex<V>> p) 
        { 
            position = p; 
        }

        public IPosition<IVertex<V>> getPosition() 
        { 
            return position; 
        }

        public IMap<IVertex<V>, IEdge<E>> GetOutgoing() 
        {
            return outGoing; 
        }
        public IMap<IVertex<V>, IEdge<E>> GetIncoming() 
        { 
            return inComing; 
        }
    }

}
