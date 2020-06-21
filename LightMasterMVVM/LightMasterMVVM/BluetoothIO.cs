using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LightMasterMVVM
{
    public class BluetoothIO
    {
        public static void StartBluetooth()
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.CreateNoWindow = true;
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                proc.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
            }
            else
            {
                proc.StartInfo.FileName = Path.Combine(Path.Combine(Path.Combine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer), "Macintosh HD"), "usr"), "local"), "bin"), "node");
                Console.WriteLine(Path.Combine(Path.Combine(Path.Combine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer), "Macintosh HD"), "usr"), "local"), "bin"), "node").ToString());
            }
            
            Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                proc.StartInfo.WorkingDirectory = @"C:\Users\djree\source\repos\lightmaster\LightMasterHub";
            }
            else
            {
                proc.StartInfo.WorkingDirectory = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "lightmaster"), "LightMasterHub");
                Console.WriteLine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "lightmaster"), "LightMasterHub").ToString());
            }
            
            proc.Start();
            proc.BeginOutputReadLine();

            proc.StandardInput.WriteLine("npm start");
            proc.OutputDataReceived += proc_OutputDataReceived;
            proc.WaitForExit();
        }

        private static void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }
}
