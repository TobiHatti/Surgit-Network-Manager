using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using Syncfusion.XlsIO.Parser.Biff_Records;

namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class UpdateEntries : SfForm
    {
        public string IPStartRange { get; set; } = "";
        public string IPEndRange { get; set; } = "";

        private string[] ipStartParts;
        private string[] ipEndParts;

        public CSQLite sql = null;

        public UpdateEntries()
        {
            InitializeComponent();
        }
        private void UpdateEntries_Load(object sender, EventArgs e)
        {
            sql = new CSQLite($@"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\surgit.db")}");

            // Ping all devices in Network Range
            ipStartParts = IPStartRange.Split('.');
            ipEndParts = IPEndRange.Split('.');

            pgbProgress.Minimum = Convert.ToInt32(ipStartParts[3]);
            pgbProgress.Maximum = Convert.ToInt32(ipEndParts[3]);

            pgbProgress.Value = pgbProgress.Minimum;

            if (!bgwUpdateEntries.IsBusy)
                bgwUpdateEntries.RunWorkerAsync();
        }

        private void bgwUpdateEntries_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, bool> DevicePowerState = new Dictionary<string, bool>();

            // Get all devices, set powerstate to false
            DevicePowerState.Clear();
            sql.connection.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery("SELECT * FROM Devices"))
                while (reader.Read()) DevicePowerState.Add(Convert.ToString(reader["MACAddress"]), false);
            sql.connection.Close();

            Ping ping = new Ping();
            StringBuilder sqlSB = new StringBuilder();

            if (ipStartParts[0] == ipEndParts[0] && ipStartParts[1] == ipEndParts[1] && ipStartParts[2] == ipEndParts[2])
            {
                for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
                {
                    if (bgwUpdateEntries.CancellationPending) return;

                    bgwUpdateEntries.ReportProgress(i);

                    string currentIP = ipStartParts[0] + "." + ipStartParts[1] + "." + ipStartParts[2] + "." + i.ToString();
                    PingReply reply = ping.Send(currentIP, 100);

                    if (reply.Status == IPStatus.Success)
                    {
                        string currentMAC = NetExplore.GetMacAddress(currentIP);

                        if (!string.IsNullOrEmpty(currentMAC))
                        {
                            // Update the power-state of the device
                            if (DevicePowerState.ContainsKey(currentMAC))
                            {
                                // Known device, only update values
                                DevicePowerState[currentMAC] = true;
                                sqlSB.Append($"UPDATE Devices SET IP4Address = '{currentIP}', LastSeen = '{DateTime.Now:yyyy-MM-dd H:mm:ss}' WHERE MACAddress = '{currentMAC}';");
                            }
                            else
                            {
                                // New, unknown device, add to DB
                                DevicePowerState.Add(currentMAC, true);
                                sqlSB.Append($"INSERT INTO Devices (MACAddress, DeviceType, Name, IP4Address, LastSeen) VALUES ('{currentMAC}','{DeviceType.UnknownDevice}','Device-{currentMAC}','{currentIP}','{DateTime.Now:yyyy-MM-dd H:mm:ss}')");
                            }
                        }
                    }
                    else continue;
                }

                if (bgwUpdateEntries.CancellationPending) return;

                // Update IP and LastSeen, add new entries
                sql.ExecuteNonQueryA(sqlSB.ToString());

                // Update last power-state
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, bool> entry in DevicePowerState)
                {
                    int state = 0;
                    if (entry.Value) state = 1;
                    sb.Append($"UPDATE Devices SET LastPowerState = '{state}' WHERE MACAddress = '{entry.Key}';");
                }
                sql.ExecuteNonQueryA(sb.ToString());

            }
        }

        private void bgwUpdateEntries_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgressReport.Text = $"Checking IP {ipStartParts[0]}.{ipStartParts[1]}.{ipStartParts[2]}." + e.ProgressPercentage.ToString();
            pgbProgress.Value = e.ProgressPercentage;
        }

        private void bgwUpdateEntries_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwUpdateEntries.CancellationPending) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwUpdateEntries.WorkerSupportsCancellation)
                bgwUpdateEntries.CancelAsync();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
#pragma warning restore IDE1006
}
