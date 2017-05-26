using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SZI
{
    public class TerrainFactory
    {
        public enum TerrainTypesEnum {
            dryPlain, normalPlain, wetPlain, //pola
            road, //inne
        };
        private TerrainFactory()
        {
            
        }

        private static TerrainFactory inst = null;
        public static TerrainFactory GetInst()
        {
            if (inst == null)
                inst = new TerrainFactory();
            return inst;
        }

        public AbstractTerrainType GetTerrainTypeFromTerrainName(string name)
        {
            Regex reg = new Regex("road*");
            if (reg.IsMatch(name))
                return CreateTerrainType(TerrainTypesEnum.road);
            reg = new Regex("dry_soil*");
            if (reg.IsMatch(name))
                return CreateTerrainType(TerrainTypesEnum.dryPlain);
            reg = new Regex("wet_soil*");
            if (reg.IsMatch(name))
                return CreateTerrainType(TerrainTypesEnum.wetPlain);
            reg = new Regex("soil*");
            if (reg.IsMatch(name))
                return CreateTerrainType(TerrainTypesEnum.normalPlain);
            //default
            return CreateTerrainType(TerrainTypesEnum.normalPlain);

        }

        public AbstractTerrainType CreateTerrainType(TerrainTypesEnum type)
        {
            AbstractTerrainType terrainType;
            switch (type)
            {
                case TerrainTypesEnum.dryPlain: terrainType = CreateDryPlainTile(); break;
                case TerrainTypesEnum.normalPlain: terrainType = CreateNormalPlainTile(); break;
                case TerrainTypesEnum.wetPlain: terrainType = CreateWetPlainTile(); break;
                case TerrainTypesEnum.road: terrainType = CreateRoadTile(); break;
                default: terrainType = CreateNormalPlainTile(); break;
            }

            return terrainType;
        }

        public AbstractTerrainType CreateNormalPlainTile()
        {
            return new Plain("pole", TerrainTypesEnum.normalPlain, 5);
        }

        public AbstractTerrainType CreateWetPlainTile()
        {
            return new Plain("zalane pole", TerrainTypesEnum.wetPlain, 8);
        }

        public AbstractTerrainType CreateDryPlainTile()
        {
            return new Plain("suche pole", TerrainTypesEnum.dryPlain, 2);
        }
        public AbstractTerrainType CreateRoadTile()
        {
            return new Road();
        }
    }

    public interface ITerrainType
    {

        void NextTurn(Tile tile);
        int moveCost { get; set; }
        bool passable { get; set; }
        string name { get; set; }
        TerrainFactory.TerrainTypesEnum type { get; set; }
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();

    }

    public abstract class AbstractTerrainType : Subject, ITerrainType
    {

        public abstract void NextTurn(Tile tile);
        public int moveCost { get; set; }
        public bool passable { get; set; }
        public string name { get; set; }
        public TerrainFactory.TerrainTypesEnum type { get; set; } 
        protected AbstractTerrainType(int moveCost, bool passable, string name, TerrainFactory.TerrainTypesEnum type)
        {
            this.moveCost = moveCost;
            this.passable = passable;
            this.name = name;
            this.type = type;
        }
    }

#region TERRAIN_TYPES

    public class Plain : AbstractTerrainType
    {
        int isNormal = 4;
        int isWet = 8;
        public Plain(string name, TerrainFactory.TerrainTypesEnum type, int waterStatus) : base(40, true, name, type)
        {
            this.waterLevel = waterStatus;
        }

        int waterLevel;

        void changeType(TerrainFactory.TerrainTypesEnum newType)
        {
            type = newType;
            if (type == TerrainFactory.TerrainTypesEnum.normalPlain)
                name = "pole";
            else if (type == TerrainFactory.TerrainTypesEnum.dryPlain)
                name = "suche pole";
            else if (type == TerrainFactory.TerrainTypesEnum.wetPlain)
                name = "zalane pole";
        }

        public void WaterPlain()
        {
            waterLevel = isWet -1;
            changeType(TerrainFactory.TerrainTypesEnum.normalPlain);
            Notify();
        }

        public override void NextTurn(Tile tile)
        {
            waterLevel--;
            if (waterLevel < 0)
                waterLevel = 0;
            if (waterLevel < isNormal && type != TerrainFactory.TerrainTypesEnum.dryPlain)
            {
                changeType(TerrainFactory.TerrainTypesEnum.dryPlain);
                Notify();
            }
            else if (waterLevel >= isNormal && waterLevel < isWet && type != TerrainFactory.TerrainTypesEnum.normalPlain)
            {
                changeType(TerrainFactory.TerrainTypesEnum.normalPlain);
                Notify();
            }
            else if (waterLevel > 10 && type != TerrainFactory.TerrainTypesEnum.dryPlain)
                waterLevel = 10;
            else if (waterLevel >= isWet && type != TerrainFactory.TerrainTypesEnum.wetPlain)
            {
                changeType(TerrainFactory.TerrainTypesEnum.wetPlain);
                Notify();
            }

        }
    }

    class Road : AbstractTerrainType
    {
        public Road() : base(10, true, "droga", TerrainFactory.TerrainTypesEnum.road)
        {
        }

        public override void NextTurn(Tile tile) { }
    }

#endregion
}
