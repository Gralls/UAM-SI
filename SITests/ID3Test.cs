using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SZI.ID3;
using System.Collections.Generic;
using SZI;

namespace SITests
{
    class PlantMock : Plant
    {
        public void SetSick()
        {
            growthStatus = Plant.GrowthStatusEnum.sickPlant;
        }

        public void SetMature()
        {
            growthStatus = GrowthStatusEnum.maturePlant;
        }
    }

    [TestClass]
    public class ID3TreeTest
    {
        ID3Tree tree = ID3Tree.GetInst();
        [TestMethod]
        public void WaterDryPlainTest()
        {
            Tile tile = new Tile();
            tile.plant = new Plant();
            tile.plant.PlantPlant();
            tile.SetTerrainType(TerrainFactory.GetInst().CreateDryPlainTile());
            tile.fertilizeStatus = new FertilizeStatus(true);
            string decision = tree.GetDecisionForTile(tile);
            string properOrder = "WaterOrder";
            StringAssert.Equals(decision, properOrder);
        }
        [TestMethod]
        public void HealPlantsTest()
        {
            Tile tile = new Tile();
            PlantMock plant = new PlantMock();
            plant.PlantPlant();
            plant.SetSick();
            tile.plant = plant;
            tile.SetTerrainType(TerrainFactory.GetInst().CreateNormalPlainTile());
            tile.fertilizeStatus = new FertilizeStatus(true);
            string decision = tree.GetDecisionForTile(tile);
            string properOrder = "HealCropsOrder";
            StringAssert.Equals(decision, properOrder);
        }
        [TestMethod]
        public void PlantCropsTest()
        {
            Tile tile = new Tile();
            tile.plant = new Plant();
            tile.SetTerrainType(TerrainFactory.GetInst().CreateNormalPlainTile());
            tile.fertilizeStatus = new FertilizeStatus(true);
            string decision = tree.GetDecisionForTile(tile);
            string properOrder = "FertilizeOrder";
            StringAssert.Equals(decision, properOrder);
        }
        [TestMethod]
        public void FertilizePlaintOrder()
        {
            Tile tile = new Tile();
            tile.plant = new Plant();
            tile.plant.PlantPlant();
            tile.SetTerrainType(TerrainFactory.GetInst().CreateNormalPlainTile());
            tile.fertilizeStatus = new FertilizeStatus(false);
            string decision = tree.GetDecisionForTile(tile);
            string properOrder = "FertilizeOrder";
            StringAssert.Equals(decision, properOrder);
        }
        [TestMethod]
        public void PlantPlainOrder()
        {
            Tile tile = new Tile();
            tile.plant = new Plant();
            tile.SetTerrainType(TerrainFactory.GetInst().CreateNormalPlainTile());
            tile.fertilizeStatus = new FertilizeStatus(true);
            string decision = tree.GetDecisionForTile(tile);
            string properOrder = "PlantOrder";
            StringAssert.Equals(decision, properOrder);
        }
        [TestMethod]
        public void CombinedOrders()
        {
            Tile tile = new Tile();
            tile.plant = new PlantMock();
            tile.SetTerrainType(TerrainFactory.GetInst().CreateDryPlainTile());
            tile.fertilizeStatus = new FertilizeStatus(true);
            string decision = tree.GetDecisionForTile(tile);
            string properOrder = "WaterOrder";

            StringAssert.Equals(decision, properOrder);
            tile.SetTerrainType(TerrainFactory.GetInst().CreateNormalPlainTile());
            decision = tree.GetDecisionForTile(tile);
            properOrder = "PlantOrder";

            StringAssert.Equals(decision, properOrder);
            (tile.plant as PlantMock).SetMature();
            decision = tree.GetDecisionForTile(tile);
            properOrder = "CutOrder";
            StringAssert.Equals(decision, properOrder);
        }
    }
}
