using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZI.Orders;
//Klasy odpowiedzialne za zapisywanie i 

namespace SZI
{
    public interface IOrder
    {
        void ExecuteOrder(Tile tile);
    }

    public abstract class AbstractOrder : IOrder
    {
        public abstract void ExecuteOrder(Tile tile);
        public int orderNumber { get; }
        public string orderName { get; }
        public string logName { get; }
        public int timeCost { get; }
        protected AbstractOrder(int orderNumber, string orderName, int timeCost, string logName)
        {
            this.orderNumber = orderNumber;
            this.orderName = orderName;
            this.timeCost = timeCost;
            this.logName = logName;
        }

        static public AbstractOrder CreateOrder(string name)
        {
            if (name == OrdersResource.WaterOrder)
                return new WaterOrder();
            if (name == OrdersResource.HealCropsOrder)
                return new HealCropsOrder();
            if (name == OrdersResource.CutCropsOrder)
                return new CutCropsOrder();
            if (name == OrdersResource.FertilizeOrder)
                return new FertilizeOrder();
            if (name == OrdersResource.PlantOrder)
                return new PlantOrder();
            return new NoOrder();
        }

        public static bool operator ==(AbstractOrder a, AbstractOrder b)
        {
            return a.orderNumber == b.orderNumber;
        }

        public static bool operator !=(AbstractOrder a, AbstractOrder b)
        {
            return !(a == b);
        }
    }

    public class NoOrder : AbstractOrder
    {
        public NoOrder() : base(-1, OrdersResource.NoOrder, 0, "brak rozkazu") { }

        public override void ExecuteOrder(Tile tile)
        {
            return;
        }
    }

    public class WaterOrder : AbstractOrder
    {
        public WaterOrder() : base(0, OrdersResource.WaterOrder, 20, "podlewania") { }

        public override void ExecuteOrder(Tile tile)
        {
            ITerrainType terrain = tile.terrainType;
            if (terrain is Plain)
                (terrain as Plain).WaterPlain();
        }
    }

    public class HealCropsOrder : AbstractOrder
    {
        public HealCropsOrder() : base(1, OrdersResource.HealCropsOrder, 20, "leczenia roślin") { }

        public override void ExecuteOrder(Tile tile)
        {
            tile.plant.HealPlant();
        }
    }

    public class CutCropsOrder : AbstractOrder
    {
        public CutCropsOrder() : base(2, OrdersResource.CutCropsOrder, 15, "ścięcia roślin") { }

        public override void ExecuteOrder(Tile tile)
        {
            tile.plant.CutPlant();
        }
    }

    public class FertilizeOrder : AbstractOrder
    {
        public FertilizeOrder() : base(3, OrdersResource.FertilizeOrder, 20, "nawożenia pola") { }

        public override void ExecuteOrder(Tile tile)
        {
            tile.fertilizeStatus.Fertilize();
        }
    }

    public class PlantOrder : AbstractOrder
    {
        public PlantOrder() : base(4, OrdersResource.PlantOrder, 15, "zasadzenia pola") { }

        public override void ExecuteOrder(Tile tile)
        {
            tile.plant.PlantPlant();
        }
    }
}
