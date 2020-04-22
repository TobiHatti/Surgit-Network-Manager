using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverTool
{
    class Program
    {
        static void Main(string[] args)
        {



            for(int i = 1; i <= 254; i++)
            {
                Console.Write("10.0.0." + i.ToString() + "");
                Console.Write(" Mac Address: " + GetMacAddress("10.0.0." + i.ToString()));
                if (GetMacAddress("10.0.0." + i.ToString()) != "not found")
                    Console.WriteLine(" Name: " + GetMachineNameFromIPAddress("10.0.0." + i.ToString()));
                else Console.WriteLine("");


            }
        }

        private static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);

                machineName = hostEntry.HostName;
            }
            catch (Exception ex)
            {
                // Machine not found...
            }
            return machineName;
        }

        public static string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
            {
                pProcess.StartInfo.FileName = "arp";
                pProcess.StartInfo.Arguments = "-a " + ipAddress;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
                string strOutput = pProcess.StandardOutput.ReadToEnd();
                string[] substrings = strOutput.Split('-');
                if (substrings.Length >= 8)
                {
                    macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                             + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                             + "-" + substrings[7] + "-"
                             + substrings[8].Substring(0, 2);
                    return macAddress;
                }

                else
                {
                    return "not found";
                }
            }
        }
    }
}
