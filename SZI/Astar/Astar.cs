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
        private SimplePriorityQueue<Tile> frontier;

        public List<Tile> GetPath(Tile begining, Tile goal)
        {
            CreatePath(begining, goal); //tworzenie sciezki

            //odtwarzanie sciezki
            Tile current = goal;
            List<Tile> path = new List<Tile>();
            path.Add(goal);
            while (current != begining)
            {
                //zapisywanie potencjalnie nadpisanej rotacji
                current.rotationOfPlayer = CalcRotation(cameFrom[current].location, current.location);
                current = cameFrom[current];
                path.Add(current);
            }
            begining.rotationOfPlayer = CalcRotation(current.location, path.Last().location);
            path.Reverse(); //odwracanie sciezki by dostac ja od startu do konca
            //czyszczenie rotacji
            TileContainer.GetInstance().ClearTilesRotationExceptLocations(path);
            return path;
        }

        private Tile.RotationEnum CalcRotation(Location from, Location to)
        {
            Location calc = from - to;
            if (calc.x == -1)
                return Tile.RotationEnum.west;
            if (calc.x == 1)
                return Tile.RotationEnum.east;
            if (calc.y == 1)
                return Tile.RotationEnum.north;
            if (calc.y == -1)
                return Tile.RotationEnum.south;
            return Tile.RotationEnum.north;
        }

        private int CalcRotationCost(Tile from, Tile.RotationEnum rotationTo)
        {
            Tile.RotationEnum rotationFrom = from.rotationOfPlayer;
            if (rotationFrom == rotationTo)
                return 0;
            int rotationNumber = 1;
            /* matematyka na enumach. Jeśli rotacje są naprzeciwko siebie to odjęcie ich od siebie daje liczbę parzystą.
             * Jeśli są obok siebie - nieparzystą  */
            int rotationEnumAbsDif = Math.Abs(rotationFrom - rotationTo);
            if (rotationEnumAbsDif % 2 == 0)
                rotationNumber = 2;
            return rotationNumber * from.terrainType.moveCost *2;
        }
        private void CreatePath(Tile begining, Tile goal)
        {
            //działamy na sklonowanych wartościach, żeby nie nadpisywać aktualnie używanych tile
            //begining = begining.Clone();
            //goal = goal.Clone();
            //przygotowywanie warunków początkowych na wypadek kilkukrotnego użycia tej samej instancji
            frontier = new SimplePriorityQueue<Tile>();
            frontier.Enqueue(begining, 0);
            
            cameFrom = new Dictionary<Tile, Tile>();
            costSoFar = new Dictionary<Tile, int>();
            cameFrom.Add(begining, null);
            costSoFar.Add(begining, 0);

            while (frontier.Count != 0)
            {
                Tile current = frontier.Dequeue();

                if (current == goal)
                    break;

                IEnumerable<Tile> neigbours = TileContainer.GetInstance().GetNeigbours(current);
                foreach (Tile next in neigbours) //sprawdzamy sasiadow aktualnie wzietego elementu kolejki
                {
                    //Tile next = nextNotCloned.Clone(); //wymagane żeby nie wylecieć z IEnumerable
                    Tile.RotationEnum rotationTo = CalcRotation(current.location, next.location);

                    int newCost = costSoFar[current] + next.terrainType.moveCost + CalcRotationCost(current, rotationTo);
                    if (costSoFar.ContainsKey(next) != true || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        next.rotationOfPlayer = rotationTo;
                        cameFrom[next] = current;
                        int priority = newCost + Heuristic(goal, next);
                        frontier.Enqueue(next, priority);
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
