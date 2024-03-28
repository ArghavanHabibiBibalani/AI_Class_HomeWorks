using DataStructures.Lists.PositionalLists;
using System;
using System.Net;
using System.Security.Cryptography;

namespace DataStructures.Graphs.AdjacencyMapGraph
{
    internal class InnerEdge<V, E> : IEdge<E>
    {
        private E element;
        private IPosition<IEdge<E>> position;
        private IVertex<V>[] endPoints;

        public InnerEdge(IVertex<V> u, IVertex<V> v, E e)
        {
            element = e;
            endPoints = new IVertex<V>[] { u, v };
            
        }
        public E GetElement() 
        {
            return element;
        }
        public IVertex<V>[] GetEndpoints() 
        {
            return endPoints;
        }
        public void SetPosition(IPosition<IEdge<E>> p) 
        {
            position = p;
        }
        public IPosition<IEdge<E>> GetPosition() 
        {
            return position;
        }
        public E Edge => element;
    }
}