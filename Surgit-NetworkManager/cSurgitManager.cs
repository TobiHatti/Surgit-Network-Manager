using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public class SurgitManager
    {
        public static string SurgitDatabaseLocation
        { get => "surgit.db"; }

        public static string ReadableString(string pInput)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pInput.Length; i++)
            {
                if (pInput[i] == '_' || (char.IsLetter(pInput[i]) && ((i != 0 && (char.IsLower(pInput[i - 1]) && char.IsUpper(pInput[i]))) || (i != pInput.Length - 1 && (char.IsUpper(pInput[i]) && char.IsLower(pInput[i + 1])))))) sb.Append(" ");
                if (pInput[i] != '_') sb.Append(pInput[i]);
            }

            return sb.ToString();
        }

        public static bool CheckIPClassCValidity(string pIPRangeStart, string pIPRangeEnd)
        {
            string[] ipStartParts = pIPRangeStart.Split('.');
            string[] ipEndParts = pIPRangeEnd.Split('.');

            if (ipStartParts[0] == ipEndParts[0] && ipStartParts[1] == ipEndParts[1] && ipStartParts[2] == ipEndParts[2] && Convert.ToInt32(ipStartParts[3]) <= Convert.ToInt32(ipEndParts[3])) return true;
            else return false;
        }

        public static void PowerStateCheck(string pIPRangeStart, string pIPRangeEnd, BackgroundWorker pProgressReplyBGW = null)
        {
            using (WrapSQLite tsql = new WrapSQLite(SurgitManager.SurgitDatabaseLocation, true))
            {
                Dictionary<string, bool> DevicePowerState = new Dictionary<string, bool>();
   
                // Get all devices, set powerstate to false
                DevicePowerState.Clear();
                tsql.Open();
                using (SQLiteDataReader reader = tsql.ExecuteQuery("SELECT * FROM Devices"))
                    while (reader.Read()) DevicePowerState.Add(Convert.ToString(reader["MACAddress"]), false);
                tsql.Close();


                // Ping all devices in Network Range
                Ping ping = new Ping();
                StringBuilder sqlSB = new StringBuilder();

                if (CheckIPClassCValidity(pIPRangeStart, pIPRangeEnd))
                {
                    string[] ipStartParts = pIPRangeStart.Split('.');
                    string[] ipEndParts = pIPRangeEnd.Split('.');

                    for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
                    {
                        if (pProgressReplyBGW.CancellationPending) return;

                        if (pProgressReplyBGW != null) pProgressReplyBGW.ReportProgress(i);

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

                    // Update IP and LastSeen, add new entries
                    tsql.ExecuteNonQueryACon(sqlSB.ToString());

                    // Update last power-state
                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, bool> entry in DevicePowerState)
                        sb.Append($"UPDATE Devices SET LastPowerState = '{(entry.Value ? 1 : 0)}' WHERE MACAddress = '{entry.Key}';");
                    tsql.ExecuteNonQueryACon(sb.ToString());
                }
                else
                {
                    if (pProgressReplyBGW.CancellationPending) return;
                    MessageBox.Show("The given range is not valid. Make sure the IPs are in the same subnet. Note: Only C-Class IP-Adresses are currently supported", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
