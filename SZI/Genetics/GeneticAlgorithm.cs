using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Genetics
{
    class GeneticAlgorithm
    {

        private static double uniformRate = 0.5;
        private static double mutationRate = 0.05;
        private static int tournamentSize = 5;
        private static bool elitism = true;

        public static Population EvolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.GetPopulationSize());

            if (elitism)
            {
                newPopulation.SaveIndividual(0, pop.GetFittest());
            }

            int elitismOffset;
            if (elitism)
            {
                elitismOffset = 1;
            }
            else
            {
                elitismOffset = 0;
            }

            for (int i = elitismOffset; i < pop.GetPopulationSize(); i++)
            {
                Individual indiv1 = TournamentSelection(pop);
                Individual indiv2 = TournamentSelection(pop);
                Individual newIndiv = CrossOver(indiv1, indiv2);
                newPopulation.SaveIndividual(i, newIndiv);
            }

            for (int i = elitismOffset; i < newPopulation.GetPopulationSize(); i++)
            {
                Mutate(newPopulation.GetIndividual(i));
            }

            return newPopulation;
        }

        private static Individual CrossOver(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual();

            for (int y = 0; y < indiv1.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < indiv1.tiles.GetLength(0); x++)
                {
                    if (newSol.tiles[x, y].terrainType.type == TerrainFactory.TerrainTypesEnum.road)
                        continue;
                    if (RandomStaticProvider.RandomDouble() <= uniformRate)
                    {
                        newSol.tiles[x, y].SetPlantType(indiv1.tiles[x, y].GetPlantType());
                    }
                    else
                    {
                        newSol.tiles[x, y].SetPlantType(indiv2.tiles[x, y].GetPlantType());
                    }
                }

            }
            return newSol;
        }

        private static void Mutate(Individual indiv)
        {
            for (int y = 0; y < indiv.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < indiv.tiles.GetLength(0); x++)
                {
                    if (indiv.tiles[x, y].terrainType.type == TerrainFactory.TerrainTypesEnum.road)
                        continue;
                    if (RandomStaticProvider.RandomDouble() <= mutationRate)
                    {
                        indiv.tiles[x, y].SetPlantType((Plant.PlantTypesEnum)RandomStaticProvider.RandomInteger(0, 5));
                    }
                }

            }

        }

        private static Individual TournamentSelection(Population pop)
        {
            Population tournament = new Population(tournamentSize);

            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(RandomStaticProvider.RandomDouble() * pop.GetPopulationSize());
                tournament.SaveIndividual(i, pop.GetIndividual(randomId));
            }

            Individual fittest = tournament.GetFittest();
            return fittest;
        }

    }
}
