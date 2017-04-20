using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.AstarNamespace
{
    using Priority_Queue;
    class Astar
    {

        public Astar()
        {
        }
        private Dictionary<Tile, Tile> cameFrom;
        private Dictionary<Tile, int> costSoFar;
        private SimplePriorityQueue<Tile> friontier;

        public List<Tile> GetPath(Tile begining, Tile goal)
        {
            CreatePath(begining, goal); //tworzenie sciezki

            //odtwarzanie sciezki
            Tile current = goal;
            List<Tile> path = new List<Tile>();
            path.Add(goal);
            while (current != begining)
            {
                current = cameFrom[current];
                path.Add(current);
            }
            path.Reverse(); //odwracanie sciezki by dostac ja od startu do konca
            return path;
        }

        private void CreatePath(Tile begining, Tile goal)
        {
            //przygotowywanie warunków początkowych na wypadek kilkukrotnego użycia tej samej instancji
            friontier = new SimplePriorityQueue<Tile>();
            friontier.Enqueue(begining, 0);
            
            cameFrom = new Dictionary<Tile, Tile>();
            costSoFar = new Dictionary<Tile, int>();
            cameFrom.Add(begining, null);
            costSoFar.Add(begining, 0);

            while (friontier.Count != 0)
            {
                Tile current = friontier.Dequeue();

                if (current == goal)
                    break;

                IEnumerable<Tile> neigbours = TileContainer.GetInstance().GetNeigbours(current);
                foreach (Tile next in neigbours) //sprawdzamy sasiadow aktualnie wzietego elementu kolejki
                {
                    int newCost = costSoFar[current] + next.terrainType.moveCost;
                    if (costSoFar.ContainsKey(next) != true || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        cameFrom[next] = current;
                        int priority = newCost + Heuristic(goal, next);
                        friontier.Enqueue(next, newCost + priority);
                    }

                }
            }
        }

        public int Heuristic(Tile tile1, Tile tile2)
        {
            return Math.Abs(tile1.location.x - tile2.location.x) + Math.Abs(tile1.location.y - tile2.location.y);
        }

    }
}
