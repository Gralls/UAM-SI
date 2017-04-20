using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
