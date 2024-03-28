using System.IO;

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
                Console.WriteLine(line);
            }
        }
    }

}