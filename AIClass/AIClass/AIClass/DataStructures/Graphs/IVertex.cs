using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public interface IVertex<V>
    {
        V Vertex { get; }
    }
}
