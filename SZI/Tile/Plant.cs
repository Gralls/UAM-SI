using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SZI.TerrainFactory;
using static SZI.Tile;

namespace SZI
{
    public class Plant
    {
        public Plant(bool isRoad)
        {
            growthStatus = GrowthStatusEnum.noPlant;
            growthLevel = 0;
            plantType = isRoad ? PlantTypesEnum.road : (Plant.PlantTypesEnum)RandomStaticProvider.RandomInteger(0, 4);
        }
        public PlantTypesEnum plantType { get; set; }
        public enum PlantTypesEnum
        {
            beetroot, walnut, carrot, flower, empty, road
        }

        public void CropStatusChange(Tile tile)
        {
            TerrainTypesEnum terrainType = tile.terrainType.type;
            bool isFertilized = tile.fertilizeStatus.isFertilized;
            if (growthLevel == 0)
                growthStatus = GrowthStatusEnum.noPlant;

            if (growthStatus == GrowthStatusEnum.noPlant)
                return;

            if (growthStatus == GrowthStatusEnum.sickPlant)
                growthLevel--;
            //roślina choruje jeśli oba warunki są złe
            if (!isSoilOK(terrainType) && !tile.fertilizeStatus.isFertilized)
            {
                growthStatus = GrowthStatusEnum.sickPlant;
                return;
            }
            //roślina rośnie wolniej jeśli jeden warunek jest zły
            if (!isSoilOK(terrainType) || !isFertilized)
            {
                growthLevel++;
            }
            if (isSoilOK(terrainType) && isFertilized)
            {
                growthLevel += 2;
            }
            if (growthLevel >= 10)
            {
                growthLevel = 10;
                growthStatus = GrowthStatusEnum.maturePlant;
            }

        }

        public string StringInfo()
        {
            string info = "";
            if (growthStatus == GrowthStatusEnum.noPlant)
            {
                info = "brak";
                return info;
            }
            if (growthLevel < 10)
                info = "Rośnie";
            else
                info = "Dorosła";
            if (growthStatus == GrowthStatusEnum.sickPlant)
                info += ", chora";
            return info;
        }

        public string PlantTypeInfo()
        {
            if (plantType == PlantTypesEnum.beetroot)
                return "Burak";
            else if (plantType == PlantTypesEnum.carrot)
                return "Marchew";
            else if (plantType == PlantTypesEnum.empty)
                return "Pusto";
            else if (plantType == PlantTypesEnum.flower)
                return "Kwiat";
            else if (plantType == PlantTypesEnum.walnut)
                return "Orzech";
            else
                return "";
        }

        public void HealPlant()
        {
            if (growthStatus == GrowthStatusEnum.noPlant)
                return;
            if (growthLevel < 10)
                growthStatus = GrowthStatusEnum.growingPlant;
            growthStatus = GrowthStatusEnum.maturePlant;
        }

        public void CutPlant()
        {
            growthStatus = GrowthStatusEnum.noPlant;
            growthLevel = 0;
        }

        public void PlantPlant()
        {
            growthStatus = GrowthStatusEnum.growingPlant;
            growthLevel = 1;
        }

        private bool isSoilOK(TerrainTypesEnum terrainType)
        {
            if (terrainType == TerrainTypesEnum.wetPlain || terrainType == TerrainTypesEnum.dryPlain)
                return false;
            return true;
        }

        public bool healthy { get; set; }
        public enum GrowthStatusEnum { noPlant, growingPlant, maturePlant, sickPlant }
        GrowthStatusEnum growthStatus;
        int growthLevel;

        public string GetID3String()
        {
            string ret;
            switch (growthStatus)
            {
                case GrowthStatusEnum.noPlant: ret = TileParameters.SoilNoPlants; break;
                case GrowthStatusEnum.growingPlant: ret = TileParameters.SoilGrowingPlants; break;
                case GrowthStatusEnum.maturePlant: ret = TileParameters.SoilMaturePlants; break;
                case GrowthStatusEnum.sickPlant: ret = TileParameters.SoilSickPlants; break;
                default: ret = TileParameters.SoilNoPlants; break;
            }
            return ret;
        }
    }
}
