using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Astar
{
    interface WeightedGraph
    {
        int Cost(Coordinates a, Coordinates b);
        IEnumerable<Coordinates> Neighbours(Coordinates id);
    }
}
