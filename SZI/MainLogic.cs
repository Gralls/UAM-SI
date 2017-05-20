using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZI.AstarNamespace;
using SZI.Genetics;

namespace SZI
{
    class MainLogic
    {
        private static MainLogic instance;
        Tile actualPlayerPosition = null;
        int turnTimer;
        int turnLength = 500;
        int populationFittestGrade = 0;
        public static MainLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainLogic();
                }
                return instance;
            }
        }

        public void SetActualPlayerTile(Tile tile)
        {
            if (actualPlayerPosition != null)
            {
                actualPlayerPosition.havePlayer = false;
                actualPlayerPosition.rotationOfPlayer = Tile.RotationEnum.none;
                actualPlayerPosition.Notify();
            }
            else
                tile.rotationOfPlayer = Tile.RotationEnum.west;
            this.actualPlayerPosition = tile;
            actualPlayerPosition.havePlayer = true;
            actualPlayerPosition.Notify();
        }

        public Tile GetActualPlayerTile()
        {
            return this.actualPlayerPosition;
        }

        void CheckTurn()
        {
            while (turnTimer > turnLength)
            {
                turnTimer -= turnLength;
                TileContainer.GetInstance().ProceedTurnOnEveryTile();
            }
        }

        void AddToTurnTimer(int value)
        {
            turnTimer += value;
            CheckTurn();
        }

        public void MovePlayer(Tile target)
        {
            Astar astar = new Astar();
            int moveCost = 0;
            List<Tile> locationsVisited = astar.GetPath(
                actualPlayerPosition, target, out moveCost);
            foreach (Tile location in locationsVisited)
            {
                int sleepTime = 250;
                System.Threading.Thread.Sleep(sleepTime);
                Tile actualTile = TileContainer.GetInstance().FindTile(location.location);
                actualTile = location;
                MainLogic.Instance.SetActualPlayerTile(actualTile);
                actualTile.Notify();
            }
            TileContainer.GetInstance().ClearTilesRotationExceptPlayerLocation();
            AddToTurnTimer(moveCost);

        }

        public List<string> StartWorkAtTile(Tile tile)
        {

            if (tile.terrainType.type == TerrainFactory.TerrainTypesEnum.road)
                return null;
            ID3.ID3Tree id3 = ID3.ID3Tree.GetInst();
            AbstractOrder order;
            List<string> ordersLog = new List<string>();
            order = AbstractOrder.CreateOrder(id3.GetDecisionForTile(tile));
            while (order.orderNumber != -1)
            {
                order.ExecuteOrder(tile);
                String orderLog = String.Format("Wykonano rozkaz {0}.", order.logName).ToString();
                ordersLog.Add(orderLog);
                order = AbstractOrder.CreateOrder(id3.GetDecisionForTile(tile));
                AddToTurnTimer(order.timeCost);
            }
            if (ordersLog.Count > 0)
                ordersLog.Add("Zakończono kolejkę rozkazów.");
            return ordersLog;
        }

        public List<string> GenerateBestPopulation()
        {
            List<string> results=new List<string>();
            Population pop = new Population(50);
            int generationCount = 0;
            populationFittestGrade = pop.GetFittest().GetFitness();
            Console.WriteLine(pop.GetPopulationSize());
            int equalsFittestRate = 0;
            while (equalsFittestRate < 50)
            {
                Console.WriteLine("Generation: " + generationCount + " Fittest: " + populationFittestGrade);
                Console.WriteLine(pop.GetFittest().ToString());
                generationCount++;

                pop = GeneticAlgorithm.EvolvePopulation(pop);
                if (populationFittestGrade == pop.GetFittest().GetFitness())
                    equalsFittestRate++;
                populationFittestGrade = pop.GetFittest().GetFitness();
            }
            results.Add(pop.GetFittest().ToString());
            results.Add("Zyski: " + populationFittestGrade);
            results.Add("Generacja: " + generationCount);
            results.Add("Rozwiązanie znalezione!");
            TileContainer.GetInstance().SetTiles(pop.GetFittest().tiles);
            return results;
        }

      
    }
}
