using DataStructures.Graphs;
using DataStructures.Graphs.AdjacencyMapGraph;
using DataStructures.Lists.ArrayList;
using DataStructures.Queue.ArrayBasedQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIClass.AI.BlindSearch
{
    internal class BlindSearch<V, E>
    {
        ArrayQueue<Data<V>> queue;
        ArrayQueue<int> final;
        //HashSet<IVertex<V>> visited;//defult class in c#
        public BlindSearch()//tree get.
        {
            queue = new ArrayQueue<Data<V>>();
            final = new ArrayQueue<int>();
            //visited = new HashSet<IVertex<V>>();
        }

        public bool BFS(IVertex<V> rootNode, V goalNode, AdjacencyMapGraph<V, E> graph, bool isAscending)
        {
            Data<V> _firstData = new Data<V>();
            //Data<V> _addData = new Data<V>();
            ArrayList<Data<V>> _data = new ArrayList<Data<V>>();
         
            _firstData.vertex = rootNode;
            _firstData.VNF = true;
            _firstData.VF = false;

            queue.Enqueue(_firstData); //add to the queue

            if (goalNode.Equals(rootNode.Vertex))
            {
                return true;
            }

            while (!queue.IsEmpty())
            {
                var incomingEdges = graph.IncomingEdges(rootNode);
                foreach (var edge in incomingEdges)
                {
                    Data<V> newData = new Data<V>();
                    newData.vertex = (IVertex<V>)edge;
                    newData.VNF = false;
                    newData.VF = false;

                    _data.Add(_data.Size(), newData);

                }

                var outgoingEdges = graph.OutgoingEdges(rootNode);
                foreach (var edge in outgoingEdges)
                {
                    Data<V> newData = new Data<V>();
                    newData.vertex = (IVertex<V>)edge;
                    newData.VNF = false;
                    newData.VF = false;

                    _data.Add(_data.Size(), newData);

                }

                if (isAscending)
                {
                    _data.QuickSortAscending();
                }
                else
                {
                    _data.QuickSortDescending();
                }

                for (int j = 0; j < _data.Size(); j++)
                {
                    Data<V> newData = new Data<V>();
                    newData.vertex = (IVertex<V>)_data.Get(j);
                    newData.VNF = true;
                    newData.VF = false;

                    queue.Enqueue(newData);
                } //add other datas to queue

                if (goalNode.Equals(queue.First()))
                {
                    return true;
                }
                queue.First().VF = true;
                queue.Dequeue();
                
            }

            return false;
        }

    }
}
