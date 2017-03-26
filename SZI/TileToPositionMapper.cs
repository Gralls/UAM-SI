using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    static class TileToPositionMapper
    {
        public static Coordinates getPosition(Button tile)
        {
            String name = tile.Name;
            int x = int.Parse(name.Substring(-1));
            int y = int.Parse(name.Substring(-2));
            Coordinates coords = new Coordinates(x, y);
            return coords;
        }
    }
}
