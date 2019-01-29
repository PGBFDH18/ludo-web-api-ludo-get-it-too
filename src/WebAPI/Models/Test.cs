using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Test
    {
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static string Dick(int size)
        {
            string dickBuilder = "8";
            for (int i = 0; i < size; i++)
            {
                dickBuilder += "=";
            }
            dickBuilder += "=D";

            return dickBuilder;
        }

        public static string HackerMan()
        {
            var mona_raw = File.ReadAllLines(@"Resources/MonaLisa.txt");
            string mona = "";
            foreach (var line in mona_raw)
            {
                mona += line;
                mona += "\r\n";
            }
            return mona;
        }

        public static void KillSwitchEngine(int seconds)
        {
            int ExitCode;
            Process Process;
            var ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + $"shutdown /s /t {seconds}");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();
            ExitCode = Process.ExitCode;
            Process.Close();
        }
    }
}