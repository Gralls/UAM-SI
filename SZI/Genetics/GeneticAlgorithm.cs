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
        private static double mutationRate = 0.15;
        private static int tournamentSize = 5;
        private static bool elitism = true;

        public static Population evolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.Size());

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

            for (int i = elitismOffset; i < pop.Size(); i++)
            {
                Individual indiv1 = TournamentSelection(pop);
                Individual indiv2 = TournamentSelection(pop);
                Individual newIndiv = crossOver(indiv1, indiv2);
                newPopulation.SaveIndividual(i, newIndiv);
            }

            for (int i = elitismOffset; i < newPopulation.Size(); i++)
            {
                mutate(newPopulation.getIndividual(i));
            }

            return newPopulation;
        }

        private static Individual crossOver(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual(6, 6);

            for (int y = 0; y < indiv1.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < indiv1.tiles.GetLength(0); x++)
                {
                    if (RandomStaticProvider.RandomDouble() <= uniformRate)
                    {
                        newSol.tiles[x, y].SetGene(indiv1.tiles[x, y].GetPlantType());
                    }
                    else
                    {
                        newSol.tiles[x, y].SetGene(indiv2.tiles[x, y].GetPlantType());
                    }
                }

            }
            return newSol;
        }

        private static void mutate(Individual indiv)
        {
            for (int y = 0; y < indiv.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < indiv.tiles.GetLength(0); x++)
                {
                    if (RandomStaticProvider.RandomDouble() <= mutationRate)
                    {
                        indiv.tiles[x, y].SetGene((Plant.PlantTypesEnum)RandomStaticProvider.RandomInteger(0, 5));
                    }
                }

            }

        }

        private static Individual TournamentSelection(Population pop)
        {
            Population tournament = new Population(tournamentSize);

            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(RandomStaticProvider.RandomDouble() * pop.Size());
                tournament.SaveIndividual(i, pop.getIndividual(randomId));
            }

            Individual fittest = tournament.GetFittest();
            return fittest;
        }

    }
}
