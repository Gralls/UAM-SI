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


        public String recognizeTile(Tile tile)
        {
            string imageToRecognize = tile.tileBackgroundName;
            PythonExecuter exec = new PythonExecuter();
            return exec.runCommand(commandForImageRecognition, imageToRecognize);
        }
    }
}
