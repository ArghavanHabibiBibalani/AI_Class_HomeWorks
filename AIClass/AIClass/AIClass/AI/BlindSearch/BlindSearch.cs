using AIClass.DataStructures.Graphs;
using DataStructures.Graphs;
using DataStructures.Graphs.AdjacencyMapGraph;
using DataStructures.Lists.ArrayList;
using DataStructures.Queue.ArrayBasedQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIClass.AI.BlindSearch
{
    public class BlindSearch<V, E> where V : IComparable<V>
    {
        private ArrayQueue<Data<V>> queue;
        private ArrayQueue<int> final;
        //HashSet<IVertex<V>> visited;
        public BlindSearch()
        {
            queue = new ArrayQueue<Data<V>>();
            final = new ArrayQueue<int>();
            //visited = new HashSet<IVertex<V>>();
        }

        public bool BFS<V> (V rootNode, V goalNode, EdgeList<V> graph, bool isAscending)
        {
            HashSet<V> visited = new HashSet<V>(); // TO DO: if u can please write a class for hash.
            ArrayQueue<V> queue = new ArrayQueue<V>(); 

            queue.Enqueue(rootNode);
            visited.Add(rootNode);

            while (queue.Size() > 0)
            {
                V currentNode = queue.Dequeue();

                if (currentNode.Equals(goalNode))
                    return true;

                IEnumerable<V> neighbors = graph.GetNeighbors(currentNode);

                foreach (V neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                        Console.WriteLine($"Visited: {neighbor}");
                    }

                }
            }
            return false;
        }

        //public bool DepthFirstSearch<V>(V rootNode, V goalNode, EdgeList<V> graph, bool isFromLeft)
        //{








        //    return null;
        //}

    }
}

