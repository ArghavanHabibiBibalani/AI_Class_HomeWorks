using DataStructures.Lists.PositionalLists.LinkesPositionalList;
using DataStructures.Lists.PositionalLists;

namespace DataStructures.Graphs.AdjacencyMapGraph
{
    public class AdjacencyMapGraph<V, E> : IGraph<V, E>
    {
        private bool isDirected;
        private IPositionalList<IVertex<V>> vertices;
        private IPositionalList<IEdge<E>> edges;
        public AdjacencyMapGraph(bool directed) 
        {
            isDirected = directed;
            vertices = new LinkedPositionalList<IVertex<V>>();
            edges = new LinkedPositionalList<IEdge<E>>();
        }

        public bool IsDirected => isDirected;

        public IEnumerable<IEdge<E>> Edges()
        {
            return (IEnumerable<IEdge<E>>)edges;
        }

        public IVertex<V>[] EndVertices(IEdge<E> e)
        {
            InnerEdge<V, E> edge = (InnerEdge<V, E>)e;
            return edge.GetEndpoints();
        }

        public IEdge<E> GetEdge(IVertex<V> u, IVertex<V> v)
        {
            InnerVertex<V, E> origin = (InnerVertex<V, E>)u;
            return origin.GetOutgoing().Get(v);
        }

        public IEnumerable<IEdge<E>> IncomingEdges(IVertex<V> v)
        {
            InnerVertex<V, E> vert = (InnerVertex<V, E>)v;
            return vert.GetIncoming().Values();
        }

        public int InDegree(IVertex<V> v)
        {
            InnerVertex<V, E> vert = (InnerVertex<V, E>)v;

            return vert.GetIncoming().Size();
        }

        public IEdge<E> InsertEdge(IVertex<V> u, IVertex<V> v, E element)
        {
            if (GetEdge(u, v) == null)
            {
                InnerEdge<V, E> e = new InnerEdge<V, E>(u, v, element);
                e.SetPosition(edges.AddLast(e));

                InnerVertex<V, E> origin = (InnerVertex<V, E>)u;
                InnerVertex<V, E> dest = (InnerVertex<V, E>)v;

                origin.GetOutgoing().Put(v, e);
                dest.GetIncoming().Put(u, e);

                return e;
                }
            else
            {
                throw new ArgumentException("Edge from u to v exists");
            }
        }

        public IVertex<V> InsertVertex(V element)
        {
            InnerVertex<V, E> v = new InnerVertex<V, E>(element, isDirected);

            v.setPosition(vertices.AddLast(v));

            return v;
        }

        public int NumEdges()
        {
            return edges.Size();
        }

        public int NumVertices()
        {
            return vertices.Size();
        }

        public IVertex<V> Opposite(IVertex<V> v, IEdge<E> e)
        {
            InnerEdge<V, E> edge = (InnerEdge<V, E>)e;

            IVertex<V>[] endpoints = edge.GetEndpoints();

            if (endpoints[0] == v)
            {
                return endpoints[1];
            }

            else if (endpoints[1] == v)
            {
                return endpoints[0];
            }

            else
            {
                throw new ArgumentException("v is not incident to this edge");
            }
        }

        public int OutDegree(IVertex<V> v) 
        {
            InnerVertex<V, E> vert = (InnerVertex<V, E>)v;

            return vert.GetOutgoing().Size();
        }

        public IEnumerable<IEdge<E>> OutgoingEdges(IVertex<V> v)
        {
            InnerVertex<V, E> vert = (InnerVertex<V, E>)v;
            return vert.GetOutgoing().Values();
        }

        public void RemoveEdge(IEdge<E> e)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertex(IVertex<V> v)
        {
            throw new NotImplementedException();
/*
            InnerVertex<V, E> vert = (InnerVertex<V, E>)v;

            foreach (IEdge<E> e in vert.GetOutgoing().Values())
            {
                RemoveEdge(e);
            }
            foreach (IEdge<E> e in vert.GetIncoming().Values())
            {
                RemoveEdge(e);
            }

            vertices.Remove(vert.getPosition());
*/
        }

        public IEnumerable<IVertex<V>> Vertices()
        {
            return (IEnumerable<IVertex<V>>)vertices;
        }
    }
}
