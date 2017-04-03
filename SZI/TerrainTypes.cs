using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    class TerrainFactory
    {
        public enum TerrainTypes {
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

        public AbstractTerrainType CreateTerrainType(TerrainTypes type)
        {
            AbstractTerrainType terrainType;
            switch (type)
            {
                case TerrainTypes.dryPlain: terrainType = CreateDrainPlainTile(); break;
                case TerrainTypes.normalPlain: terrainType = CreateNormalPlainTile(); break;
                case TerrainTypes.wetPlain: terrainType = CreateWetPlainTile(); break;
                case TerrainTypes.road: terrainType = CreateRoadTile(); break;
                default: terrainType = CreateNormalPlainTile(); break;
            }

            return terrainType;
        }

        public AbstractTerrainType CreateNormalPlainTile()
        {
            return new Plain("pole", TerrainTypes.normalPlain);
        }

        public AbstractTerrainType CreateWetPlainTile()
        {
            return new Plain("zalane pole", TerrainTypes.wetPlain);
        }

        public AbstractTerrainType CreateDrainPlainTile()
        {
            return new Plain("suche pole", TerrainTypes.dryPlain);
        }
        public AbstractTerrainType CreateRoadTile()
        {
            return new Road();
        }
    }

    class AbstractTerrainType
    {
        public int moveCost { get; set; }
        public bool passable { get; set; }
        public string name { get; set; }
        public TerrainFactory.TerrainTypes type { get; set; } 
        public AbstractTerrainType(int moveCost, bool passable, string name, TerrainFactory.TerrainTypes type)
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
        public Plain(string name, TerrainFactory.TerrainTypes type) : base(2, true, name, type)
        {
        }
    }

    class Road : AbstractTerrainType
    {
        public Road() : base(1, true, "droga", TerrainFactory.TerrainTypes.road)
        {
        }
    }

#endregion
}
