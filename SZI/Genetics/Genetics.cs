using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    class Genetics
    {
        Tile[,] tiles;
        public Genetics()
        {
            tiles = TileContainer.GetInstance().GetTiles();
            tiles = Population(tiles, 30, 100);
            int grade = PopulationGrade(tiles, 100);
        }

        public Tile Individual(Tile tile,int min, int max)
        {
            Random rnd = new Random();
            tile.gen1 = rnd.Next(min, max);
            tile.gen2 = rnd.Next(min, max);
            tile.gen3 = rnd.Next(min, max);
            tile.gen4 = rnd.Next(min, max);

            return tile;
        }

        public Tile[,] Population(Tile[,] tiles,int min, int max)
        {
            for(int y = 0; y < tiles.GetLength(1); y++)
            {
                for(int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y] = Individual(tiles[x, y], min, max);
                }
            }

            return tiles;
        }

        public int Fitness(Tile tile,int target)
        {
            int points = Math.Abs(tile.gen1 - 50) + tile.gen2*4-Math.Abs(tile.gen3-30)+Math.Abs(tile.gen4-100);
            return Math.Abs(target - points);
        }

        public int PopulationGrade(Tile[,] tiles, int target)
        {
            int points = 0;

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    points += Fitness(tiles[x, y], target);
                }
            }

            return points / tiles.Length;
        }

        public void Evolve(Tile[,]tiles,int target, double retain, double randomSelect, double mutate)
        {
            List<Tile> graded = new List<Tile>();
            Dictionary<int, Tile> dict = new Dictionary<int, Tile>();
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    dict.Add(Fitness(tiles[x, y], target), tiles[x, y]);
                }
            }
            List<int> list = dict.Keys.ToList();
            list.Sort();

            foreach(int key in list)
            {
                graded.Add(dict[key]);
            }

            int retainLenght = (int)(graded.Count * retain);
            List<Tile> parents = graded.GetRange(0,retainLenght);

            foreach(Tile individual in graded.GetRange(retainLenght, graded.Count))
            {
                if(randomSelect>new Random().NextDouble())
                {
                    parents.Add(individual);
                }
            }

            foreach(Tile individual in parents)
            {
                if(mutate > new Random().NextDouble())
                {
                    int positionToMutate = new Random().Next(0, 4);
                    int[] gens = new int[4];
                    gens[0] = individual.gen1;
                    gens[1] = individual.gen2;
                    gens[2] = individual.gen3;
                    gens[3] = individual.gen4;
                   
                    switch (positionToMutate)
                    {
                        case 1:
                            individual.gen1 = new Random().Next(gens.Min(), gens.Max());
                            break;
                        case 2:
                            individual.gen2 = new Random().Next(gens.Min(), gens.Max());
                            break;
                        case 3:
                            individual.gen3 = new Random().Next(gens.Min(), gens.Max());
                            break;
                        case 4:
                            individual.gen4 = new Random().Next(gens.Min(), gens.Max());
                            break;
                    }
                }
            }
            int parentsLenght = parents.Count;
            int desiredLenght = tiles.Length - parentsLenght;
            

        }
    }
}
