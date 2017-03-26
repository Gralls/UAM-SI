using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    public static class TileToPositionMapper
    {
        public static Coordinates getPosition(Button tile)
        {
            String name = tile.Name;
            int x = int.Parse(name.Substring(name.Length - 2, 1));
            int y = int.Parse(name.Substring(name.Length - 1, 1));
            Coordinates coords = new Coordinates(x, y);
            return coords;
        }
    }
}
