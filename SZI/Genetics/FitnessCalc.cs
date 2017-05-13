using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.Genetics
{
    class FitnessCalc
    {

        private static int[] solution;

        public static void setSolution(int[] newSolution)
        {
            solution = newSolution;
        }
        public static int GetFitness(Tile individual)
        {
            
            return Math.Abs(individual.GetGene(0) - individual.GetGene(1)*2 + Math.Abs(individual.GetGene(2)-40) - individual.GetGene(3) *2);
        }

        public static int getTarget()
        {
            return 250;
        }
    }
}
