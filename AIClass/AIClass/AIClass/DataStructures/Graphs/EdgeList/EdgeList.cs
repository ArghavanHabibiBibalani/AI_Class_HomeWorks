using System;
using System.Collections.Generic;

public class EdgeList<TVertex>
{
    private Dictionary<TVertex, HashSet<TVertex>> adjacencyList;

    public EdgeList()
    {
        adjacencyList = new Dictionary<TVertex, HashSet<TVertex>>();
    }

    public void AddEdge(TVertex source, TVertex destination)
    {
        AddVertex(source);
        AddVertex(destination);

        adjacencyList[source].Add(destination);
        adjacencyList[destination].Add(source);
    }



    public void AddVertex(TVertex vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new HashSet<TVertex>();
        }
    }

    public IEnumerable<TVertex> GetNeighbors(TVertex vertex)
    {
        if (adjacencyList.ContainsKey(vertex))
        {
            return adjacencyList[vertex];
        }
        else
        {
            return new HashSet<TVertex>();
        }
    }


    public IEnumerable<TVertex> GetAllVertices()
    {
        return adjacencyList.Keys;
    }
}
