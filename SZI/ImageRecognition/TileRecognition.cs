using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.ImageRecognition
{
    public class TileRecognition
    {
        private static String commandForImageRecognition = "C:\\Useful\\PythonPackages\\tf_files\\label_image.py";
        
        public TileRecognition()
        {
        }


        public bool recognizeTiles(Tile[,] tiles)
        {
            try
            {
                String imagesToRecognize = "";
                String key;
                Dictionary<String, List<Tile>> backgroundToTileDict = new Dictionary<String, List<Tile>>();
                foreach (Tile tile in tiles)
                {
                    key = tile.tileBackgroundName;
                    imagesToRecognize += key;
                    imagesToRecognize += " ";
                    if (!backgroundToTileDict.ContainsKey(key))
                        backgroundToTileDict.Add(key, new List<Tile>());
                    backgroundToTileDict[key].Add(tile);
                }
                PythonExecuter exec = new PythonExecuter();
                Dictionary<String, String> recognitionResultDict = new Dictionary<string, string>();
                string recognitionResult = exec.runCommand(commandForImageRecognition, imagesToRecognize);
                if (recognitionResult == null)
                    return false;
                String[] recognitionResultSplittedByLines = recognitionResult.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < recognitionResultSplittedByLines.Length; i++)
                {
                    String[] recognitionResultSplitted = recognitionResultSplittedByLines[i].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    recognitionResultDict.Add(recognitionResultSplitted[0], recognitionResultSplitted[1]);
                }



                foreach (String iter in backgroundToTileDict.Keys)
                {
                    String result = recognitionResultDict[iter];
                    foreach (Tile tile in backgroundToTileDict[iter])
                    {
                        if (result.Contains("dry"))
                            tile.recognizedTerrainType = TerrainFactory.GetInst().CreateTerrainType(TerrainFactory.TerrainTypesEnum.dryPlain);
                        else if (result.Contains("normal"))
                            tile.recognizedTerrainType = TerrainFactory.GetInst().CreateTerrainType(TerrainFactory.TerrainTypesEnum.normalPlain);
                        else if (result.Contains("road"))
                            tile.recognizedTerrainType = TerrainFactory.GetInst().CreateTerrainType(TerrainFactory.TerrainTypesEnum.road);
                        else if (result.Contains("wet"))
                            tile.recognizedTerrainType = TerrainFactory.GetInst().CreateTerrainType(TerrainFactory.TerrainTypesEnum.wetPlain);
                        else
                            return false;
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
