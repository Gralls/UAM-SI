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
                individuals[i] = new Individual();
            }
        }
       
        public Individual GetIndividual(int index)
        {
            return individuals[index];
        }

        public Individual GetFittest()
        {
            return individuals.Aggregate((current, next) => Math.Abs(current.GetFitness() - FitnessCalc.GetTarget()) < Math.Abs(next.GetFitness() - FitnessCalc.GetTarget()) ? current : next); ;
        }

        public int Grade()
        {
            int grade = 0;
            for (int i = 0; i < GetPopulationSize(); i++)
            {
                grade += individuals[i].GetFitness();
            }
            return grade / (GetPopulationSize());
        }

        public int GetPopulationSize()
        {
            return individuals.Length;
        }

        public void SaveIndividual(int index, Individual indiv)
        {
            individuals[index] = indiv;
        }


    }
}
