using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surgit_NetworkManager
{
    class RDPConnect
    {
        public bool FullScreen { get; set; } = true;
        public int WindowWidth { get; set; } = 800;
        public int WindowHeight { get; set; } = 480;
        public bool PublicMode { get; set; } = false;
        public bool MultiMonitor { get; set; } = false;

        public string MachineNameOrIP { get; set; } = "";

        public void StartRDP()
        {
            try
            {
                string rdpArguments = $@"/v:""{MachineNameOrIP}""";

                if (FullScreen)
                {
                    rdpArguments += $@" /f";
                    if (MultiMonitor) rdpArguments += $@" /multimon";
                }
                else rdpArguments += $@" /w:{WindowWidth} /h:{WindowHeight}";

                if (PublicMode) rdpArguments += $@" /public";
   
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                System.Security.SecureString ssPwd = new System.Security.SecureString();
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.FileName = "mstsc.exe";
                proc.StartInfo.Arguments = rdpArguments;
                proc.Start();
            }
            catch
            {
                MessageBox.Show("Could not start RDP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
