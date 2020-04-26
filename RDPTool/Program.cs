using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace RDPTool
{
    class Program
    {
        static void Main(string[] args)
        {
            String machinename = "";
            String username = @"";
            String password = @"";


            string tsScript = $"mstsc /v:{machinename}";
            string cmdKey = $"cmdkey /generic:TERMSVR/{machinename} /user:{username} /pass:{password}";

            using (Runspace rs = RunspaceFactory.CreateRunspace())
            {
                rs.Open();

                using (Pipeline pl = rs.CreatePipeline())
                {
                    pl.Commands.AddScript(cmdKey);
                    pl.Commands.AddScript(tsScript);
                    pl.Invoke();
                }
            }
        }

        private void StartRDP(RDPConnectionDetails rdpDetails)
        {

        }
    }

    class RDPConnectionDetails
    {
        

    }
}
