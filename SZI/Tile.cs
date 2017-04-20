using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    public class TileContainer
    {
        private TileContainer()
        {
        }
        private static TileContainer instance;
        public static TileContainer GetInstance()
        {
            if (instance == null)
                instance = new TileContainer();
            return instance;
        }

        public void SetTiles(Tile[][] tiles)
        {
            xSize = tiles.GetLength(0);
            ySize = tiles.GetLength(1);
            allTiles = tiles;
        }

        public IEnumerable<Tile> GetNeigbours(Tile tile)
        {

            Location[] locations = new Location[]
            {
                new Location(1, 1),
                new Location(1, -1),
                new Location(-1, 1),
                new Location(-1, -1)
            };
            foreach (var loc in locations)
            {
                Tile next = FindTile(tile.location.x + loc.x, tile.location.y + loc.y);
                if (next != null)
                    yield return next;
            }
        }

        public Tile FindTile(int x, int y)
        {
            if (x < 0 || x > xSize
                || y < 0 || y > ySize)
                return null;
            return allTiles[x][y];
        }
        private int xSize { get; set; }
        private int ySize { get; set; }
        public Tile[][] allTiles { get; set; }
    }

    //This will be class for having informations about every tile.
    public class Tile
    {
        public Location location { get; set; }
        public TileImage tileBackground { get; set; }
        public ITerrainType terrainType { get; set; }
        public Button correspondingButton { get; set; }
        
    }

}
