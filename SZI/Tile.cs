using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    //This will be class for having informations about every tile.
    public class Tile
    {
        public Coordinates coords { get; set; }
        public TileImage tileBackground { get; set; }
        public Button correspondingButton { get; set; }
    }
}
