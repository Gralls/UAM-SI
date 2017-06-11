using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI.ImageRecognition
{
    public class WeatherRecognition
    {
        private static String commandForImageRecognition = "C:\\Users\\worad\\tf_files\\label_image.py";
        
        public WeatherRecognition()
        {

        }

        public String recognizeWeather(String filename)
        {
            try
            {
                PythonExecuter exec = new PythonExecuter();
                string result = exec.runCommand(commandForImageRecognition, filename);
                if (result == null)
                    return "Error";
                if (result.Contains("sun"))
                    return "Sunny";
                else if (result.Contains("cloud"))
                    return "Cloudy";
                else if (result.Contains("rain"))
                    return "Rainy";
                else if (result.Contains("snow"))
                    return "Snowy";
                else
                    return "Unrecognized";
            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        
    }
}
