using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static SZI.TerrainFactory;
using System.Text.RegularExpressions;
using System.IO;

namespace SZI
{
    class TileImageLoader
    {
        Random rand = new Random();

        public string GetRandomImageNameCorrespondingToTerrainType(TerrainTypesEnum type)
        {
            string regexStr;
            switch (type)
            {
                case TerrainTypesEnum.dryPlain: regexStr = "dry_soil*"; break;
                case TerrainTypesEnum.normalPlain: regexStr = "soil*"; break;
                case TerrainTypesEnum.road: regexStr = "road*"; break;
                case TerrainTypesEnum.wetPlain: regexStr = "wet_soil*"; break;
                default: regexStr = "soil*"; break;
            }
            return GetRandomImageNameMatchingRegex(regexStr);
        }

        private string GetRandomImageNameMatchingRegex(string regexStr)
        {
            Regex reg = new Regex(regexStr);
            var files = Directory.GetFiles(spritesLocation)
                                .Where(path => reg.IsMatch(path))
                                .ToList();

            int number = rand.Next(0, files.Count);
            return files[number];
        }

        public Image GetImageByName(string name)
        {
            return Image.FromFile(name);
        }

        public Image GetPlayerImage()
        {
            string spritesLocation = System.IO.Path.Combine(Environment.CurrentDirectory, "..\\..\\res\\sprites");
            return Image.FromFile(spritesLocation + "\\machine.png");
        }
        
        private string spritesLocation;
        private TileImageLoader()
        {
            spritesLocation = Path.Combine(Environment.CurrentDirectory, "..\\..\\res\\sprites\\");
        }
        private static TileImageLoader instance;
        public static TileImageLoader GetInstance()
        {
            if (instance == null)
                instance = new TileImageLoader();
            return instance;
        }
    }
}
