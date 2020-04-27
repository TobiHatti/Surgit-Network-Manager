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
using Syncfusion.XlsIO.Implementation;

namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class DiscoverDialog : SfForm
    {
        public List<NetDevice> DiscoveredDevices = new List<NetDevice>();

        public string IPRangeStart { get; set; } = null;
        public string IPRangeEnd { get; set; } = null;

        public DiscoverDialog()
        {
            InitializeComponent();
        }

        private void DiscoverDialog_Load(object sender, EventArgs e)
        {
            txbDiscoveryStart.Text = IPRangeStart;
            txbDiscoveryEnd.Text = IPRangeEnd;
        }

        private void BtnStartDiscovery_Click(object sender, EventArgs e)
        {
            bool ipStartValid;
            // Check if start-IP is valid
            if (IPAddress.TryParse(txbDiscoveryStart.Text, out IPAddress ipStartRange) && ipStartRange.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) ipStartValid = true;
            else
            {
                MessageBox.Show("The given range-start is not a valid IPv4-Address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ipEndValid;
            // Check if end-IP is valid
            if (IPAddress.TryParse(txbDiscoveryEnd.Text, out IPAddress ipEndRange) && ipEndRange.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) ipEndValid = true;
            else
            {
                MessageBox.Show("The given range-end is not a valid IPv4-Address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the start and end IPs are in the same subnet and that they are in a class C subnet
            if (ipStartValid && ipEndValid && SurgitManager.CheckIPClassCValidity(txbDiscoveryStart.Text, txbDiscoveryEnd.Text))
            {
                if(!bgwDiscovery.IsBusy) bgwDiscovery.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("The given range is not valid. Make sure the IPs are in the same subnet. Note: Only C-Class IP-Adresses are currently supported", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private readonly Dictionary<int, Tuple<string, string>> FoundIPAtPercentage = new Dictionary<int, Tuple<string, string>>();
        private void Discover()
        {
            DiscoveredDevices.Clear();
            txbDiscoveryOutput.Text = "";

            string[] ipStartParts = txbDiscoveryStart.Text.Split('.');
            string[] ipEndParts = txbDiscoveryEnd.Text.Split('.');

            int deviceCount = 0;
            int progressCounter = 0;

            int rangeSize = Convert.ToInt32(ipEndParts[3]) - Convert.ToInt32(ipStartParts[3]);
            bgwDiscovery.ReportProgress(-rangeSize);
            bgwDiscovery.ReportProgress(0);

            if (chbPingCheck.Checked)
            {
                rangeSize *= 2;
                bgwDiscovery.ReportProgress(-rangeSize);
                bgwDiscovery.ReportProgress(0);

                bgwDiscovery.ReportProgress(2000000);
                
                for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
                {
                    string currentIP = ipStartParts[0] + "." + ipStartParts[1] + "." + ipStartParts[2] + "." + i.ToString();

                    if (bgwDiscovery.CancellationPending) return;

                    try
                    {
                        Ping ping = new Ping();
                        ping.Send(currentIP, 500);

                        FoundIPAtPercentage.Add(progressCounter, new Tuple<string, string>(currentIP, ""));
                        bgwDiscovery.ReportProgress(5000000 + progressCounter);
                    }
                    catch (Exception)
                    { }

                    bgwDiscovery.ReportProgress(progressCounter++);
                }
            }

            bgwDiscovery.ReportProgress(3000000);

            // Start the discovery
            for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
            {
                if (bgwDiscovery.CancellationPending) return;

                string currentIP = ipStartParts[0] + "." + ipStartParts[1] + "." + ipStartParts[2] + "." + i.ToString();
                string currentMAC = NetExplore.GetMacAddress(currentIP);
                if (!string.IsNullOrEmpty(currentMAC))
                {
                    string currentHostname = NetExplore.GetMachineNameFromIPAddress(currentIP);
                    NetDevice ntd = new NetDevice
                    {
                        IPv4 = currentIP,
                        MAC = currentMAC,
                        Hostname = currentHostname,
                        Name = "Device-" + currentMAC
                    };

                    FoundIPAtPercentage.Add(progressCounter, new Tuple<string, string>(currentIP, currentHostname));
                    bgwDiscovery.ReportProgress(4000000 + progressCounter);

                    DiscoveredDevices.Add(ntd);

                    deviceCount++;
                }

                bgwDiscovery.ReportProgress(progressCounter++);
            }

            MessageBox.Show("Discovery finished!" + Environment.NewLine + $"Found a total of {DiscoveredDevices.Count} devices.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void BtnFinishDiscover_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DiscoverDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwDiscovery.WorkerSupportsCancellation)
                bgwDiscovery.CancelAsync();
        }

        private void bgwDiscovery_DoWork(object sender, DoWorkEventArgs e) => Discover();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwDiscovery.WorkerSupportsCancellation)
                bgwDiscovery.CancelAsync();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bgwDiscovery_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage < 0)
            {
                prbDiscoveryProgress.Value = 0;
                prbDiscoveryProgress.Minimum = 0;
                prbDiscoveryProgress.Maximum = -e.ProgressPercentage;
            }
            else if (e.ProgressPercentage == 2000000)
            {
                txbDiscoveryOutput.Text += "Starting ping-check..." + Environment.NewLine;
                txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
                txbDiscoveryOutput.ScrollToCaret();
            }

            else if (e.ProgressPercentage == 3000000)
            {
                txbDiscoveryOutput.Text += "Starting discovery..." + Environment.NewLine;
                txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
                txbDiscoveryOutput.ScrollToCaret();
            }
            else if(e.ProgressPercentage >= 4000000 && e.ProgressPercentage < 4999999)
            {
                txbDiscoveryOutput.Text += "Found device at " + FoundIPAtPercentage[e.ProgressPercentage-4000000].Item1 + " (" + FoundIPAtPercentage[e.ProgressPercentage - 4000000].Item2 + ")" + Environment.NewLine;
                txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
                txbDiscoveryOutput.ScrollToCaret();
            }
            else if (e.ProgressPercentage >= 5000000 && e.ProgressPercentage < 5999999)
            {
                txbDiscoveryOutput.Text += "Sent Ping to " + FoundIPAtPercentage[e.ProgressPercentage - 5000000].Item1 + Environment.NewLine;
                txbDiscoveryOutput.SelectionStart = txbDiscoveryOutput.TextLength;
                txbDiscoveryOutput.ScrollToCaret();
            }
            else if (prbDiscoveryProgress.Value < prbDiscoveryProgress.Maximum)
            {
                prbDiscoveryProgress.Value = e.ProgressPercentage;
            }
        }

        private void bgwDiscovery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwDiscovery.CancellationPending) return;

            prbDiscoveryProgress.Value = prbDiscoveryProgress.Maximum;
            btnFinishDiscover.Enabled = true;
        }
    }
#pragma warning restore IDE1006
}
