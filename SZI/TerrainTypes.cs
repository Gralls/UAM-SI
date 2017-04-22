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
            road //inne
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
                case TerrainTypesEnum.dryPlain: terrainType = CreateDrainPlainTile(); break;
                case TerrainTypesEnum.normalPlain: terrainType = CreateNormalPlainTile(); break;
                case TerrainTypesEnum.wetPlain: terrainType = CreateWetPlainTile(); break;
                case TerrainTypesEnum.road: terrainType = CreateRoadTile(); break;
                default: terrainType = CreateNormalPlainTile(); break;
            }

            return terrainType;
        }

        public AbstractTerrainType CreateNormalPlainTile()
        {
            return new Plain("pole", TerrainTypesEnum.normalPlain);
        }

        public AbstractTerrainType CreateWetPlainTile()
        {
            return new Plain("zalane pole", TerrainTypesEnum.wetPlain);
        }

        public AbstractTerrainType CreateDrainPlainTile()
        {
            return new Plain("suche pole", TerrainTypesEnum.dryPlain);
        }
        public AbstractTerrainType CreateRoadTile()
        {
            return new Road();
        }
    }

    public interface ITerrainType
    {
        int moveCost { get; set; }
        bool passable { get; set; }
        string name { get; set; }
        TerrainFactory.TerrainTypesEnum type { get; set; }
    }

    public class AbstractTerrainType : ITerrainType
    {
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

    class Plain : AbstractTerrainType
    {
        public Plain(string name, TerrainFactory.TerrainTypesEnum type) : base(20, true, name, type)
        {
        }
    }

    class Road : AbstractTerrainType
    {
        public Road() : base(10, true, "droga", TerrainFactory.TerrainTypesEnum.road)
        {
        }
    }

#endregion
}
