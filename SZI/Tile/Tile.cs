﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZI.Genetics;

namespace SZI
{
    public class TileContainer 
    {
        private TileContainer()
        {
        }

        private static TileContainer instance;
        public static TileContainer GetInstance()
        {
            if (instance == null)
                instance = new TileContainer();
            return instance;
        }

        public void SetTiles(Tile[,] tiles)
        {
            xSize = tiles.GetLength(0);
            ySize = tiles.GetLength(1);
            allTiles = tiles;
        }

        public Tile[,] GetTiles()
        {
            return allTiles;
        }

        public Tile[,] GetCopyOfTiles()
        {
            Tile[,] newTiles = new Tile[xSize, ySize];
            for(int y = 0; y < ySize; y++)
            {
                for(int x = 0; x < xSize; x++)
                {
                    newTiles[x, y] = allTiles[x, y].Clone();
                }
            }
            return newTiles;
        }

        public void ClearTilesRotationExceptPlayerLocation()
        {
            foreach (Tile t in allTiles)
            {
                if (t != MainLogic.Instance.GetActualPlayerTile())
                {
                    t.rotationOfPlayer = Tile.RotationEnum.none;
                }
            }
        }

        internal void ClearTilesRotationExceptLocations(List<Tile> path)
        {
            foreach (Tile t in allTiles)
            {
                if (!path.Contains(t))
                    t.rotationOfPlayer = Tile.RotationEnum.none;
            }
        }

        public void ProceedTurnOnEveryTile()
        {
            foreach (Tile t in allTiles)
                t.NextTurn();
        }
        public IEnumerable<Tile> GetNeigbours(Tile tile)
        {

            Location[] locations = new Location[]
            {
                new Location(1, 0),
                new Location(-1, 0),
                new Location(0, 1),
                new Location(0, -1)
            };
            foreach (var loc in locations)
            {
                Tile next = FindTile(tile.location.x + loc.x, tile.location.y + loc.y);
                if (next != null)
                    yield return next;
            }
        }

        public Tile FindTile(int x, int y)
        {
            if (x < 0 || x >= xSize
                || y < 0 || y >= ySize)
                return null;
            return allTiles[x, y];
        }

        public Tile FindTile(Location pos)
        {
            return FindTile(pos.x, pos.y);
        }

        private int xSize { get; set; }
        private int ySize { get; set; }
        private Tile[,] allTiles { get; set; }

       
    }

    //This will be class for having informations about every tile.
    public class Tile : Subject, IObserver
    {
        public Tile() : base()
        {
        }
        public Location location { get; set; }
        public string tileBackgroundName { get; set; }
        public bool havePlayer { get; set; }
        public ITerrainType terrainType { get; private set; }
        public enum RotationEnum { north, east, south, west, none }
        public RotationEnum rotationOfPlayer { get; set; }
        public Plant plant { get; set; }
        public FertilizeStatus fertilizeStatus { get; set; }
        private int[] genes;

        public ITerrainType recognizedTerrainType { get; set; }
        public void SetTerrainType(ITerrainType value)
        {
            if (terrainType != null)
                terrainType.Detach(this);
            terrainType = value;
            if (value != null)
                value.Attach(this);
        }
        public string GetID3WaterStatusStr()
        {
            string waterStatusStr;
            switch (terrainType.type)
            {
                case TerrainFactory.TerrainTypesEnum.dryPlain: waterStatusStr = TileParameters.SoilLowHumidity; break;
                case TerrainFactory.TerrainTypesEnum.normalPlain: waterStatusStr = TileParameters.SoilMediumHumidity; break;
                case TerrainFactory.TerrainTypesEnum.wetPlain: waterStatusStr = TileParameters.SoilHighHumidity; break;
                default: waterStatusStr = TileParameters.SoilMediumHumidity; break;
            }
            return waterStatusStr;
        }

        public void NextTurn()
        {
            plant.CropStatusChange(this);
            terrainType.NextTurn(this);
            fertilizeStatus.NextTurn();
        }

        public void ChangeTerrain(string terrainName)
        {
            tileBackgroundName = terrainName;
            terrainType = TerrainFactory.GetInst().GetTerrainTypeFromTerrainName(terrainName);
            Notify();
        }
        public Tile Clone()
        {
            Tile tile = new Tile();
            tile.location = this.location;
            tile.tileBackgroundName = this.tileBackgroundName;
            tile.havePlayer = this.havePlayer;
            tile.terrainType = this.terrainType;
            tile.rotationOfPlayer = this.rotationOfPlayer;
            return tile;
        }

        public void UpdateAfterSubjectChanged()
        {
            tileBackgroundName = TileImageLoader.GetInstance().GetRandomImageNameCorrespondingToTerrainType(terrainType.type);
            Notify();
        }
        public Plant.PlantTypesEnum GetPlantType()
        {
            return plant.plantType;
        }

        public string getPlantTypeName()
        {
            string plantName;
            switch (plant.plantType)
            {
                case Plant.PlantTypesEnum.beetroot:
                    plantName = "Burak";
                    break;
                case Plant.PlantTypesEnum.walnut:
                    plantName = "Orzech";
                    break;
                case Plant.PlantTypesEnum.carrot:
                    plantName = "Marchew";
                    break;
                case Plant.PlantTypesEnum.flower:
                    plantName = "Kwiat";
                    break;
                case Plant.PlantTypesEnum.empty:
                    plantName = "Pusto";
                    break;
                case Plant.PlantTypesEnum.road:
                    plantName = "Droga";
                    break;
                default:
                    plantName = "";
                    break;
            }
            return plantName;
        }
        public void SetPlantType(Plant.PlantTypesEnum value)
        {
            plant.plantType = value;
        }

        public void GeneratePlants()
        {
            plant = new Plant(terrainType.type == TerrainFactory.TerrainTypesEnum.road);
        }

        public override string ToString()
        {
            return getPlantTypeName();
        }
    }
}
