using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public interface IGraph<V, E>
    {
        bool IsDirected { get; }
        int NumVertices();
        int NumEdges();
        IEnumerable<IVertex<V>> Vertices();
        IEnumerable<IEdge<E>> Edges();
        IEdge<E> GetEdge(IVertex<V> u, IVertex<V> v);
        IVertex<V>[] EndVertices(IEdge<E> e);
        IVertex<V> Opposite(IVertex<V> v, IEdge<E> e);
        int OutDegree(IVertex<V> v);
        int InDegree(IVertex<V> v);
        IEnumerable<IEdge<E>> OutgoingEdges(IVertex<V> v);
        IEnumerable<IEdge<E>> IncomingEdges(IVertex<V> v);
        IVertex<V> InsertVertex(V element);
        IEdge<E> InsertEdge(IVertex<V> u, IVertex<V> v, E element);
        void RemoveVertex(IVertex<V> v);
        void RemoveEdge(IEdge<E> e);

    }
}
