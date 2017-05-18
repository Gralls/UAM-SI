using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Genetics
{
    class FitnessCalc
    {
        public static int GetFitness(Individual individual)
        {
            int fitness = 0;

            for (int y = 0; y < individual.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < individual.tiles.GetLength(0); x++)
                {
                    Plant.PlantTypesEnum plantType= individual.tiles[x, y].plant.plantType;
                    if (individual.tiles[x, y].terrainType.type == TerrainFactory.TerrainTypesEnum.road)
                    {
                        continue;
                    }
                    else if (plantType == Plant.PlantTypesEnum.empty)
                    {
                        fitness -= 10;
                        continue;
                    }
                    else if (plantType==Plant.PlantTypesEnum.beetroot)
                    {
                        fitness += 20;
                    }
                    else if (plantType == Plant.PlantTypesEnum.carrot)
                    {
                        fitness += 10;
                    }
                    else if (plantType == Plant.PlantTypesEnum.flower)
                    {
                        fitness += 5;
                    }
                    else if (plantType == Plant.PlantTypesEnum.walnut)
                    {
                        fitness += 30;
                    }

                    if (SearchAroundPlant(individual, x, y, Plant.PlantTypesEnum.walnut))
                    {
                        fitness -= 25;
                    }
                    else if (SearchAroundPlant(individual, x, y, Plant.PlantTypesEnum.road))
                    {
                        fitness -= 30;
                    }
                }
            }

            return fitness;
        }

        public static int getTarget()
        {
            return 250;
        }

        public static bool SearchAroundPlant(Individual indiv, int x, int y, Plant.PlantTypesEnum plantType)
        {
            if (x > 0 && indiv.tiles[x - 1, y].plant.plantType == plantType)
            {
                return true;
            }
            if (x < indiv.tiles.GetLength(0) - 1 && indiv.tiles[x + 1, y].plant.plantType == plantType)
            {
                return true;
            }
            if (y > 0 && indiv.tiles[x, y - 1].plant.plantType == plantType)
            {
                return true;
            }
            if (y < indiv.tiles.GetLength(1) - 1 && indiv.tiles[x, y + 1].plant.plantType == plantType)
            {
                return true;
            }

            return false;
        }
    }
}
