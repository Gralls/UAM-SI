using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI.ImageRecognition
{


    public class PythonExecuter
    {
        static private String pythonFullPath = "C:\\Python\\Python35\\python.exe";
        private bool pythonTestPassed = false;


        public PythonExecuter()
        {
            this.pythonTestPassed = testPython();
        }
        public bool testPython()
        {
            ProcessStartInfo procInfo = new ProcessStartInfo();
            Process proc;
            string result = null;
            procInfo.FileName = pythonFullPath;
            procInfo.Arguments = "-c print(2+8)";
            procInfo.CreateNoWindow = true;
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardOutput = true;
            try
            {
                proc = Process.Start(procInfo);
                
                using (Process process = Process.Start(procInfo))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        result = reader.ReadToEnd();
                    }
                }
                proc.WaitForExit();
                proc.Close();
                if (result == "10\r\n")
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return false;
            }
            
        }
        public String runCommand(string cmd, string args)
        {
            if (!pythonTestPassed)
                return null;
            ProcessStartInfo procInfo = new ProcessStartInfo();
            Process proc;
            string result = null;
            procInfo.FileName = pythonFullPath;
            procInfo.Arguments = string.Format("{0} {1}", cmd, args);
            procInfo.CreateNoWindow = true;
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardOutput = true;
            try
            {
                proc = Process.Start(procInfo);

                using (Process process = Process.Start(procInfo))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        result = reader.ReadToEnd();
                    }
                }
                proc.WaitForExit();
                proc.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return null;
            }

        }
    }
}
