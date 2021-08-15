using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new("C:/Users/masterofdoom/code projects/C#/BreadthFirstSearch/rosalind_bfs.txt");

            List<Vertex> verticesToSearch = new() { graph.vertexList.Find(x => x.vertexName == 1) };
            int distanceFromBase = 0;

            while (verticesToSearch.Count != 0)
            {
                List<Vertex> verticesToAdd = new(); // Build up the vertices to search in layers by exploring all the vertices currently in the list and then replacing it at the end with a list of all their connected vertices. 

                foreach (Vertex vertex in verticesToSearch)
                {
                    if (vertex.visited == false)
                    {
                        vertex.distanceFromBaseVertex = distanceFromBase;
                        foreach (int namefVertexToAdd in vertex.connectedVertices)
                        {
                            var vertexToAdd = graph.vertexList.First(x => x.vertexName == namefVertexToAdd);
                            if (!verticesToAdd.Contains(vertexToAdd) && vertexToAdd.visited == false)
                            {
                                verticesToAdd.Add(vertexToAdd);
                            }                            
                        }
                        vertex.visited = true;
                    }
                }
                verticesToSearch = verticesToAdd; // Once the layer has been searched, replace it with the next layer of vertices.
                distanceFromBase += 1; // Since the graph is unweighted, the vertices in each layer have a distance of 1 from the previous vertex in the path back to the base vertex.
            }
            
            foreach (Vertex vertex in graph.vertexList)
            {
                Console.WriteLine($"{vertex.vertexName} {vertex.distanceFromBaseVertex}");
            }
            Console.WriteLine(graph.numberOfVertices);
            Console.WriteLine(graph.vertexList.Count);

            using StreamWriter sw = new("C:/Users/masterofdoom/code projects/C#/BreadthFirstSearch/solution.txt");
            {
                foreach (Vertex vertex in graph.vertexList)
                {
                    sw.Write(vertex.distanceFromBaseVertex + " ");
                }
            }
        }
    }
}
