using System.IO;
using DataStructures.Graphs.AdjacencyMapGraph;

namespace AIClass
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"E:\University\AI\Tests\Test 1.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                List<int> myList = line.Split('\t').Select(int.Parse).ToList(); // have unhandeled exeption
                foreach(int i in myList)
                {
                    Console.WriteLine(i);
                }
            }

            AdjacencyMapGraph<int, int> graph = new AdjacencyMapGraph<int, int>(false); //graph is not direcred.

            





        }
    }

}