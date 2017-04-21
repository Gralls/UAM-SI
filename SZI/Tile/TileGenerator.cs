using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    #region TileGeneratorStrategy
    //interface dla wygody użytkowania
    interface ITileGeneratorStrategy
    {
        Tile[,] GenerateTiles(int sizeX, int sizeY);

    }

    class RandomTileGeneratorStrategy : ITileGeneratorStrategy
    {
        public RandomTileGeneratorStrategy()
        {

        }
        public Tile[,] GenerateTiles(int sizeX, int sizeY)
        {
            Tile[,] tiles = new Tile[sizeX,sizeY];
            TileImageLoader imageLoader = TileImageLoader.GetInstance();
            for (int x = 0; x < sizeY; x++)
                for (int y = 0; y < sizeX; y++)
                {
                    tiles[x, y] = new Tile();
                    tiles[x, y].location = new Location(x, y);
                    tiles[x, y].terrainType = GetRandomTerrainType();
                    tiles[x, y].tileBackground = imageLoader.GetRandomImageCorrespondingToTerrainType(tiles[x, y].terrainType.type);
                }
            return tiles;
        }

        public ITerrainType GetRandomTerrainType()
        {
            Random rnd = new Random();
            ITerrainType terrain;
            TerrainFactory terrainFactory = TerrainFactory.GetInst();
            int randomNumber = rnd.Next(0, 3);
            switch (randomNumber)
            {
                case 0: terrain = terrainFactory.CreateDrainPlainTile(); break;
                case 1: terrain = terrainFactory.CreateNormalPlainTile(); break;
                case 2: terrain = terrainFactory.CreateRoadTile(); break;
                case 3: terrain = terrainFactory.CreateWetPlainTile(); break;
                default: terrain = terrainFactory.CreateNormalPlainTile(); break;
            }
            return terrain;
        }
    }
    #endregion
    class TileGenerator
    {
        public Tile[,] CreateTiles(ITileGeneratorStrategy strategy, int sizeX, int sizeY)
        {
            return strategy.GenerateTiles(sizeX, sizeY);
        }

        private TileGenerator()
        {
        }
        private static TileGenerator instance;
        public static TileGenerator GetInstance()
        {
            if (instance == null)
                instance = new TileGenerator();
            return instance;
        }
    }
}
