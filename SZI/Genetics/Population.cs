using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Genetics
{
    class Population
    {
        public Tile[] individuals;

        public Population(int populationSize)
        {
            individuals = new Tile[populationSize];
        }
        public Population(Tile[,]tiles)
        {

            List<Tile> tilesList = new List<Tile>();
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for(int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[x,y].terrainType.type != TerrainFactory.TerrainTypesEnum.road)
                    {
                        tilesList.Add(tiles[x, y]);
                    }
                }
            }
            individuals = tilesList.ToArray();
        }
        public Tile getIndividual(int index)
        {
            return individuals[index];
        }

        public Tile GetFittest()
        {
            return individuals.Aggregate((current, next) => Math.Abs(current.GetFitness() - FitnessCalc.getTarget()) < Math.Abs(next.GetFitness() - FitnessCalc.getTarget()) ? current : next); ;
        }

        public int Grade()
        {
            int grade = 0;
            for(int i = 0; i < Size(); i++)
            {
                grade += individuals[i].GetFitness();
            }
            return grade / (Size());
        }

        public int Size()
        {
            return individuals.Length;
        }

        public void SaveIndividual(int index, Tile indiv)
        {
            individuals[index] = indiv;
        }

        
    }
}
