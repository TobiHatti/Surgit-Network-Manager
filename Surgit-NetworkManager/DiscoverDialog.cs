using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
    public partial class DiscoverDialog : SfForm
    {
        public List<NetDevice> DiscoveredDevices = new List<NetDevice>();

        string[] ipStartParts = null;
        string[] ipEndParts = null;

        public DiscoverDialog()
        {
            InitializeComponent();

#if DEBUG
            btnFinishDiscover.Enabled = true;
#endif
        }

        private void BtnStartDiscovery_Click(object sender, EventArgs e)
        {
            bool ipStartValid = false;
            bool ipEndValid = false;

            // Check if start-IP is valid
            if(IPAddress.TryParse(txbDiscoveryStart.Text, out IPAddress ipStartRange) && ipStartRange.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) ipStartValid = true;
            else
            {
                MessageBox.Show("The given range-start is not a valid IPv4-Address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if end-IP is valid
            if (IPAddress.TryParse(txbDiscoveryStart.Text, out IPAddress ipEndRange) && ipEndRange.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) ipEndValid = true;
            else
            {
                MessageBox.Show("The given range-end is not a valid IPv4-Address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the start and end IPs are in the same subnet and that they are in a class C subnet
            if(ipStartValid && ipEndValid)
            {
                ipStartParts = txbDiscoveryStart.Text.Split('.');
                ipEndParts = txbDiscoveryEnd.Text.Split('.');

                if(ipStartParts[0] == ipEndParts[0] && ipStartParts[1] == ipEndParts[1] && ipStartParts[2] == ipEndParts[2])
                {
                    if(!bgwDiscovery.IsBusy)
                    {
                        bgwDiscovery.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("The given range is not valid. Make sure the IPs are in the same subnet. Note: Only C-Class IP-Adresses are currently supported", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Discover()
        {
            DiscoveredDevices.Clear();
            txbDiscoveryOutput.Text = "";

            int deviceCount = 0;

            int rangeSize = 0;

            rangeSize = Convert.ToInt32(ipEndParts[3]) - Convert.ToInt32(ipStartParts[3]);

#if !DEBUG
            prbDiscoveryProgress.Value = 0;
            prbDiscoveryProgress.Minimum = 0;
            prbDiscoveryProgress.Maximum = rangeSize;
#endif

            if (chbPingCheck.Checked)
            {
                rangeSize *= 2;
                prbDiscoveryProgress.Maximum = rangeSize;

                txbDiscoveryOutput.Text += "Starting ping-check..." + Environment.NewLine;

                for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
                {
                    string currentIP = ipStartParts[0] + "." + ipStartParts[1] + "." + ipStartParts[2] + "." + i.ToString();

                    try
                    {
                        Ping ping = new Ping();
                        ping.Send(currentIP, 500);

                        txbDiscoveryOutput.Text += "Sent Ping to " + currentIP + Environment.NewLine;
                        txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
                        txbDiscoveryOutput.ScrollToCaret();
                    }
                    catch (Exception)
                    { }

                    if (prbDiscoveryProgress.Value < prbDiscoveryProgress.Maximum)
                        prbDiscoveryProgress.Value++;
                }
            }
#if !DEBUG
            txbDiscoveryOutput.Text += "Starting discovery..." + Environment.NewLine;
            txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
            txbDiscoveryOutput.ScrollToCaret();
#endif
            // Start the discovery
            for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
            {
                string currentIP = ipStartParts[0] + "." + ipStartParts[1] + "." + ipStartParts[2] + "." + i.ToString();
                string currentMAC = NetExplore.GetMacAddress(currentIP);
                string currentHostname = string.Empty;

                if (!string.IsNullOrEmpty(currentMAC))
                {
                    currentHostname = NetExplore.GetMachineNameFromIPAddress(currentIP);

                    NetDevice ntd = new NetDevice
                    {
                        IPv4 = currentIP,
                        MAC = currentMAC,
                        Hostname = currentHostname,
                        Name = "Device-" + currentMAC
                    };

                    

                    DiscoveredDevices.Add(ntd);

                    deviceCount++;
#if !DEBUG
                    txbDiscoveryOutput.Text += "Found device at " + currentIP + " (" + currentHostname + ")" + Environment.NewLine;
                    txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
                    txbDiscoveryOutput.ScrollToCaret();
#endif
                }

#if !DEBUG
                if(prbDiscoveryProgress.Value < prbDiscoveryProgress.Maximum)
                    prbDiscoveryProgress.Value++;
#endif
            }
#if !DEBUG
            prbDiscoveryProgress.Value = rangeSize;

            btnFinishDiscover.Enabled = true;
#endif
            MessageBox.Show("Discovery finished!" + Environment.NewLine + $"Found a total of {deviceCount} devices.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void BtnFinishDiscover_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DiscoverDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwDiscovery.WorkerSupportsCancellation)
            {
                bgwDiscovery.CancelAsync();
            }
        }

        private void bgwDiscovery_DoWork(object sender, DoWorkEventArgs e)
        {
            Discover();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwDiscovery.WorkerSupportsCancellation)
            {
                bgwDiscovery.CancelAsync();
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
