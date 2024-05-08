using System.IO;
using AIClass.AI.BlindSearch;
using AIClass.DataStructures.Graphs;
using DataStructures.Graphs;
using DataStructures.Graphs.AdjacencyMapGraph;

namespace AIClass
{
    class Program
    {
        static void Main(string[] args)
        {
            BFSMain();
        }

        private static void BFSMain()
        {
            string filePath = @"E:\University\AI\Tests\Test 1.txt";

            var edgeList = new EdgeList<int>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] vertices = line.Split('\t');

                    if (vertices.Length >= 2)
                    {
                        if (int.TryParse(vertices[0], out int source) && int.TryParse(vertices[1], out int destination))
                        {
                            edgeList.AddEdge(source, destination);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line: {line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            BlindSearch<int, int> bs = new BlindSearch<int, int>();


            bool v = bs.BFS<int>(5, 10, edgeList, false);

            Console.WriteLine(v);
        }
    }
}