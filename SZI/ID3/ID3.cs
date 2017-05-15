using Accord;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Statistics.Filters;
using Accord.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZI.Orders;

namespace SZI.ID3
{
    public class ID3Tree
    {
        private ID3Learning id3learning;
        private Codification codebook;
        private DecisionTree tree;
        int[][] inputs;
        int[] outputs;
        private static ID3Tree instance;
        public DataTable CreateTrainingDataTable()
        {
            DataTable data = new DataTable("Zachowanie traktora");
            data.Columns.Add("SoilHumidity", "PlantStatus", "FertilizerStatus", "Action");

            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilNoPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilGrowingPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilSickPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilMaturePlants, TileParameters.SoilEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilNoPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilGrowingPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilSickPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilLowHumidity, TileParameters.SoilMaturePlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.WaterOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilNoPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.PlantOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilGrowingPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.NoOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilSickPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.HealCropsOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilMaturePlants, TileParameters.SoilEnoughFertilizer, OrdersResource.CutCropsOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilNoPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.FertilizeOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilGrowingPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.FertilizeOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilSickPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.HealCropsOrder);
            data.Rows.Add(TileParameters.SoilMediumHumidity, TileParameters.SoilMaturePlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.CutCropsOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilNoPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.NoOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilGrowingPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.NoOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilSickPlants, TileParameters.SoilEnoughFertilizer, OrdersResource.HealCropsOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilMaturePlants, TileParameters.SoilEnoughFertilizer, OrdersResource.CutCropsOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilNoPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.FertilizeOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilGrowingPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.FertilizeOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilSickPlants, TileParameters.SoilNotEnoughFertilizer, OrdersResource.HealCropsOrder);
            data.Rows.Add(TileParameters.SoilHighHumidity, TileParameters.SoilMaturePlants, TileParameters.SoilNotEnoughFertilizer,  OrdersResource.CutCropsOrder);
            return data;
        }

        private void initializeID3()
        {
            DecisionVariable[] attributes =
            {
                new DecisionVariable("SoilHumidity", 3),
                new DecisionVariable("PlantStatus", 4),
                new DecisionVariable("FertilizerStatus", 2)
            };

            int orderCount = 6;
            tree = new DecisionTree(attributes, orderCount);
            id3learning = new ID3Learning(tree);
        }

        private ID3Tree()
        {
            initializeID3();
            DataTable table = CreateTrainingDataTable();
            codebook = new Codification(table);
            DataTable symbols = codebook.Apply(table);
            inputs = symbols.ToArray<int>("SoilHumidity", "PlantStatus", "FertilizerStatus");
            outputs = symbols.ToIntArray("Action").GetColumn(0);

            id3learning.Run(inputs, outputs);
        }

        public static ID3Tree GetInst()
        {
            if (instance == null)
                instance = new ID3Tree();
            return instance;
        }

        public string GetDecisionForTile(Tile tile)
        {
            int[] query = codebook.Translate(tile.GetID3WaterStatusStr(), tile.plant.GetID3String(), tile.fertilizeStatus.GetID3String());
            int output = tree.Compute(query);
            string answer = codebook.Translate("Action", output);
            return answer;
        }

        public string GetDecision(string waterStatus, string plantStatus, string fertilizerStatus)
        {
            int[] query = codebook.Translate(waterStatus, plantStatus, fertilizerStatus);
            int output = tree.Compute(query);
            string answer = codebook.Translate("Action", output);
            return answer;
        }
    }
    
}
