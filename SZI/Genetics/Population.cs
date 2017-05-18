using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Genetics
{
    class Population
    {
        public Individual[] individuals;

        public Population(int populationSize)
        {
            individuals = new Individual[populationSize];
            for (int i = 0; i < populationSize; i++) 
            {
                individuals[i] = new Individual(6, 6);
            }
        }
        public Population(Individual[] individuals)
        {
            this.individuals = individuals;
        }
        public Individual getIndividual(int index)
        {
            return individuals[index];
        }

        public Individual GetFittest()
        {
            return individuals.Aggregate((current, next) => Math.Abs(current.GetFitness() - FitnessCalc.getTarget()) < Math.Abs(next.GetFitness() - FitnessCalc.getTarget()) ? current : next); ;
        }

        public int Grade()
        {
            int grade = 0;
            for (int i = 0; i < Size(); i++)
            {
                grade += individuals[i].GetFitness();
            }
            return grade / (Size());
        }

        public int Size()
        {
            return individuals.Length;
        }

        public void SaveIndividual(int index, Individual indiv)
        {
            individuals[index] = indiv;
        }


    }
}
