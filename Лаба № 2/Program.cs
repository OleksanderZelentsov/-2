using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба___2
{
    public class Graph
    {
        private int vertices;
        private List<int>[] adjList;

        public Graph(int v)
        {
            vertices = v;
            adjList = new List<int>[v];
            for (int i = 0; i < v; i++)
                adjList[i] = new List<int>();
        }
        public void AddEdgeDirected(int v, int b)
        {
            adjList[v].Add(b);
        }
        public void AddEdgeUndirected(int v, int b)
        {
            adjList[v].Add(b);
            adjList[b].Add(v);
        }
        private void RecursionDFS(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (int adj in adjList[v])
            {
                if (!visited[adj])
                    RecursionDFS(adj, visited);
            }
        }
        public void DFS(int first)
        {
            bool[] visited = new bool[vertices];
            RecursionDFS(first, visited);
            Console.WriteLine();
        }
        public void BFS(int first)
        {
            bool[] visited = new bool[vertices];
            Queue<int> queue = new Queue<int>();
            visited[first] = true;
            queue.Enqueue(first);
            while (queue.Count > 0)
            {
                first = queue.Dequeue();
                Console.Write(first + " ");

                foreach (int adj in adjList[first])
                {
                    if (!visited[adj])
                    {
                        visited[adj] = true;
                        queue.Enqueue(adj);
                    }
                }
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Graph undirectedGraph = new Graph(9);
            undirectedGraph.AddEdgeUndirected(0, 1);
            undirectedGraph.AddEdgeUndirected(0, 3);
            undirectedGraph.AddEdgeUndirected(1, 3);
            undirectedGraph.AddEdgeUndirected(1, 4);
            undirectedGraph.AddEdgeUndirected(1, 5);
            undirectedGraph.AddEdgeUndirected(2, 2);
            undirectedGraph.AddEdgeUndirected(2, 3);
            undirectedGraph.AddEdgeUndirected(2, 4);
            undirectedGraph.AddEdgeUndirected(2, 5);

            Graph directedGraph = new Graph(12);
            directedGraph.AddEdgeDirected(0, 1);
            directedGraph.AddEdgeDirected(0, 3);
            directedGraph.AddEdgeDirected(0, 4);
            directedGraph.AddEdgeDirected(1, 2);
            directedGraph.AddEdgeDirected(1, 3);
            directedGraph.AddEdgeDirected(1, 4);
            directedGraph.AddEdgeDirected(1, 5);
            directedGraph.AddEdgeDirected(2, 2);
            directedGraph.AddEdgeDirected(2, 3);
            directedGraph.AddEdgeDirected(2, 4);
            directedGraph.AddEdgeDirected(2, 5);
            directedGraph.AddEdgeDirected(2, 4);
            directedGraph.AddEdgeDirected(3, 2);
            directedGraph.AddEdgeDirected(3, 4);
            directedGraph.AddEdgeDirected(4, 5);

            Console.WriteLine("Оберіть граф:");
            Console.WriteLine("1. Орієнтований граф");
            Console.WriteLine("2. Неорієнтований граф");
            int graphChoice = int.Parse(Console.ReadLine());
            Graph selectedGraph = (graphChoice == 1) ? directedGraph : undirectedGraph;
            Console.Write("Введіть номер стартової вершини: ");
            int startVertex = int.Parse(Console.ReadLine());
            Console.WriteLine("DFS:");
            selectedGraph.DFS(startVertex);
            Console.WriteLine("BFS:");
            selectedGraph.BFS(startVertex);
            Console.ReadLine();
        }
    }

}
