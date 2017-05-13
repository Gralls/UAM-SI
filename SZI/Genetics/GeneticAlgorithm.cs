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
                Tile indiv1 = TournamentSelection(pop);
                Tile indiv2 = TournamentSelection(pop);
                Tile newIndiv = crossOver(indiv1, indiv2);
                newPopulation.SaveIndividual(i, newIndiv);
            }

            for(int i = elitismOffset; i < newPopulation.Size(); i++)
            {
                mutate(newPopulation.getIndividual(i));
            }

            return newPopulation;
        }

        private static Tile crossOver(Tile indiv1, Tile indiv2)
        {
            Tile newSol = new Tile();
           
            for(int i = 0; i < indiv1.Size(); i++)
            {
                if(RandomStaticProvider.RandomDouble() <= uniformRate)
                {
                    newSol.SetGene(i, indiv1.GetGene(i));
                }
                else
                {
                    newSol.SetGene(i, indiv2.GetGene(i));
                }
            }

            return newSol;
        }

        private static void mutate(Tile indiv)
        {
         
            for (int i = 0; i < indiv.Size(); i++)
            {
                if(RandomStaticProvider.RandomDouble() <= mutationRate)
                {
                    indiv.SetGene(i, RandomStaticProvider.RandomInteger(0,100));
                }
            }
        }

        private static Tile TournamentSelection(Population pop)
        {
            Population tournament = new Population(tournamentSize);
          
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(RandomStaticProvider.RandomDouble() * pop.Size());
                tournament.SaveIndividual(i, pop.getIndividual(randomId));
            }

            Tile fittest = tournament.GetFittest();
            return fittest;
        }

    }
}
