using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void SetTiles(Tile[,] tiles)
        {
            xSize = tiles.GetLength(0);
            ySize = tiles.GetLength(1);
            allTiles = tiles;
        }

        public Tile[,] GetTiles()
        {
            return allTiles;
        }

        public IEnumerable<Tile> GetNeigbours(Tile tile)
        {

            Location[] locations = new Location[]
            {
                new Location(1, 0),
                new Location(-1, 0),
                new Location(0, 1),
                new Location(0, -1)
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
            if (x < 0 || x >= xSize
                || y < 0 || y >= ySize)
                return null;
            return allTiles[x,y];
        }

        public Tile FindTile(Location pos)
        {
            return FindTile(pos.x, pos.y);
        }
        private int xSize { get; set; }
        private int ySize { get; set; }
        private Tile[,] allTiles { get; set; }
    }

    //This will be class for having informations about every tile.
    public class Tile
    {
        public Location location { get; set; }
        public Image tileBackground { get; set; }
        public ITerrainType terrainType { get; set; }
        public Button correspondingButton { get; set; }
        
    }

}
