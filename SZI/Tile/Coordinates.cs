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

        public static Location operator +(Location l1, Location l2)
        {
            return new Location(l1.x + l2.x, l1.y + l2.y);
        }

        public static Location operator -(Location l1, Location l2)
        {
            return new Location(l1.x - l2.x, l1.y - l2.y);
        }
    }
}
