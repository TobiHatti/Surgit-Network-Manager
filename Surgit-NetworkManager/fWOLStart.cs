﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using WrapSQL;

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
#pragma warning disable IDE1006
    public partial class WOLStart : SfForm
    {
        public string MACAddress = "";
        public string IPv4 = "";

        private readonly WrapSQLite sql = new WrapSQLite(SurgitManager.SurgitDatabaseLocation, true);

        private TimeSpan elapsedTime;

        public WOLStart()
        {
            InitializeComponent();
        }

        private void WOLStart_Load(object sender, EventArgs e)
        {
            elapsedTime = new TimeSpan(0, 0, 0);

            if (!string.IsNullOrEmpty(MACAddress))
            {
                WakeOnLan(MACAddress.Split('-').Select(x => Convert.ToByte(x, 16)).ToArray());

                if (!bgwMonitorProgress.IsBusy)
                    bgwMonitorProgress.RunWorkerAsync();
            }
            else this.Close();
        }

        private void tmrTimeElapsed_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            lblTimeElapsed.Text = "Time elapsed: " + elapsedTime.ToString("mm':'ss");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwMonitorProgress.WorkerSupportsCancellation)
                bgwMonitorProgress.CancelAsync();

            this.Close();
        }

        private void bgwMonitorProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            Ping ping = new Ping();
            PingReply rep;

            if (!string.IsNullOrEmpty(IPv4))
            {
                do
                {
                    if (bgwMonitorProgress.CancellationPending) return;
                    rep = ping.Send(IPv4, 100);
                }
                while (rep.Status != IPStatus.Success);
            }

            bgwMonitorProgress.ReportProgress(100);
        }

        private void bgwMonitorProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblWOLStatus.Text = "Device Online!";
            tmrTimeElapsed.Stop();
            prgWOLState.Value = 100;
            prgWOLState.Style = ProgressBarStyle.Continuous;

            sql.ExecuteNonQueryACon($"UPDATE Devices SET LastPowerState = '1' WHERE MACAddress = '{MACAddress}'");

            MessageBox.Show("Device is Online!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WakeOnLan(byte[] mac)
        {
            // WOL packet is sent over UDP 255.255.255.0:40000.
            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 40000);

            // WOL packet contains a 6-bytes trailer and 16 times a 6-bytes sequence containing the MAC address.
            byte[] packet = new byte[17 * 6];

            // Trailer of 6 times 0xFF.
            for (int i = 0; i < 6; i++)
                packet[i] = 0xFF;

            // Body of magic packet contains 16 times the MAC address.
            for (int i = 1; i <= 16; i++)
                for (int j = 0; j < 6; j++)
                    packet[i * 6 + j] = mac[j];

            // Send WOL packet.
            client.Send(packet, packet.Length);
        }
    }
#pragma warning restore IDE1006
}
