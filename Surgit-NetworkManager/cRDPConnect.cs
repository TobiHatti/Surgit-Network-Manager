using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region COPYRIGHT NOTICE (Surgit Network Manager - Copyright(C) 2020  Tobias Hattinger)

/* Surgit Network Manager
 * Copyright(C) 2020  Tobias Hattinger
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<https://www.gnu.org/licenses/>.
 */
#endregion

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
