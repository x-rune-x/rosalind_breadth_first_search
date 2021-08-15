using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BreadthFirstSearch
{
    class Graph
    {
        public int numberOfVertices; // n
        public int numberOfEdges; // m        
        public List<Vertex> vertexList;

        public Graph(string filePath)
        {            
            using StreamReader sr = new (filePath);
            {
                string nAndMString = sr.ReadLine(); // The first line contains n and m.
                string[] nAndM = nAndMString.Split(" ");
                numberOfVertices = Int32.Parse(nAndM[0]);
                numberOfEdges = Int32.Parse(nAndM[1]);
                vertexList = new();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> edgeComponents = line.Split(" ").ToList();
                    int originVertex = Int32.Parse(edgeComponents[0]);
                    int destinationVertex = Int32.Parse(edgeComponents[1]);
                    if (vertexList.Exists(x => x.vertexName == originVertex) == false)
                    {
                        vertexList.Add(new Vertex(originVertex));
                    }

                    if (vertexList.Exists(x => x.vertexName == destinationVertex) == false)
                    {
                        vertexList.Add(new Vertex(destinationVertex));
                    }

                    vertexList.Find(x => x.vertexName == originVertex).connectedVertices.Add(destinationVertex);
                }                
            }

            for (int i = 1; i <= numberOfVertices; i++) // This step is to account for vertices that are not part of an edge.
            {
                if (vertexList.Find(x => x.vertexName == i) == null)
                {
                    vertexList.Add(new Vertex(i));
                }
            }
            vertexList = vertexList.OrderBy(x => x.vertexName).ToList();
        }
    }
}
