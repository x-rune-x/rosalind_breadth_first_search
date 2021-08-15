using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Vertex
    {
        public int vertexName;
        public List<int> connectedVertices;
        public int distanceFromBaseVertex;
        public bool visited;

        public Vertex(int name)
        {
            vertexName = name;
            connectedVertices = new();
            visited = false;
            distanceFromBaseVertex = -1;
        }
    }
}
