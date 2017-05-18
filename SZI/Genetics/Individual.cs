using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Genetics
{
    class Individual
    {

        public Tile[,] tiles { set; get; }
        public int fitness = 0;

        public Individual(int individualSizeX, int individualSizeY)
        {
            tiles = TileGenerator.GetInstance().CreateTiles(new RandomTileGeneratorStrategy(), individualSizeX, individualSizeY);
        }
        public void GenerateIndivdual(int individualSizeX, int individualSizeY)
        {
            tiles = TileGenerator.GetInstance().CreateTiles(new RandomTileGeneratorStrategy(), individualSizeX, individualSizeY);
        }
        public int GetFitness()
        {
            if (fitness == 0)
            {
                fitness = FitnessCalc.GetFitness(this);
            }
            return fitness;
        }

        public Plant.PlantTypesEnum GetIndividualGene(int x, int y)
        {
            return tiles[x, y].plant.plantType;
        }

        public override string ToString()
        {
            string types="";
            for(int y = 0; y < tiles.GetLength(1); y++)
            {
                types += "[ ";
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    types += " " + tiles[x, y].getPlantTypeName() + " ";
                }
                types += " ]\n";
            }
            return types;
        }

    }
}
