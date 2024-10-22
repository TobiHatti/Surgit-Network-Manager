﻿using MarkdownSharp;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.XlsIO.Implementation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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
#pragma warning disable IDE1006
    public partial class SurgitMain : RibbonForm
    {
        private readonly WrapSQLite sql = null;
        private bool showGroupDetails = false;

        public SurgitMain()
        {
            InitializeComponent();

            

            // Copy DB-File if not existent
            if (!File.Exists(SurgitManager.SurgitDatabaseLocation))
            {
                File.Copy("surgitBlank.db", SurgitManager.SurgitDatabaseLocation);
            }

            // Initialize DBConnection
            sql = new WrapSQLite(SurgitManager.SurgitDatabaseLocation, true);

            // Test DB Connections
            try
            {
                sql.Open();
                sql.Close();
            }
            catch
            {
                throw new Exception("Could not connect to DB [SQL]");
            }

           // Configure and Initialize form elements
            grvDevices.LargeImageList = NetDevice.GetImageList();
            cbxSortBy.SelectedIndex = 5;
            cbxSortOrder.SelectedIndex = 0;

            // Initialize Surgit
            ApplyFormStyle();
            UpdateDeviceList();

            sql.Open();
            lblIPRangeStart.Text = sql.ExecuteScalar<string>($"SELECT Value FROM Settings WHERE Key = 'IPRangeStart'");
            lblIPRangeEnd.Text = sql.ExecuteScalar<string>($"SELECT Value FROM Settings WHERE Key = 'IPRangeEnd'");
            sql.Close();

            // Start the power-state check
            if (!bgwCheckPowerState.IsBusy) bgwCheckPowerState.RunWorkerAsync();
        }

        private void SurgitMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            tmrStartPowerCheck.Stop();
            if (bgwCheckPowerState.WorkerSupportsCancellation) bgwCheckPowerState.CancelAsync();
        }

        /// <summary>
        /// Changes and modifies general appearance of the form
        /// </summary>
        private void ApplyFormStyle()
        {
            this.Appearance = AppearanceType.Office2007;
            this.ColorScheme = ColorSchemeType.Silver;
            this.EnableAeroTheme = true;
            this.Borders = new Padding(-1);

            this.Text = $"Surgit Network Manager  (Version {System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(3)})";

            this.rbcRibbonMenu.TitleFont = new Font("Calibri", 11);

            Write2WebControll(webMarkdown, "");
        }

        /// <summary>
        /// Updates the Device-View
        /// </summary>
        private void UpdateDeviceList()
        {
            // Clear Device-View
            grvDevices.GroupViewItems.Clear();

            // Check if view gets sorted Ascending or descending
            string orderDirection;
            string orderDirectionRev;
            switch (cbxSortOrder.SelectedIndex)
            {
                case 0: orderDirection = "ASC"; orderDirectionRev = "DESC"; break;
                case 1: orderDirection = "DESC"; orderDirectionRev = "ASC"; break;
                default: orderDirection = ""; orderDirectionRev = ""; break;
            }

            // Check by which value(s) the view gets sorted
            string orderBy;
            switch (cbxSortBy.SelectedIndex)
            {
                case 0: orderBy = $"ORDER BY Name {orderDirection}"; break;
                case 1: orderBy = $"ORDER BY IP4Address {orderDirection}"; break;
                case 2: orderBy = $"ORDER BY MACAddress {orderDirection}"; break;
                case 3: orderBy = $"ORDER BY DeviceType {orderDirection}, Name {orderDirection}"; break;
                case 4: orderBy = $"ORDER BY LastSeen {orderDirection}, DeviceType {orderDirection}, Name {orderDirection}"; break;
                case 5: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, Name {orderDirection}"; break;
                case 6: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, IP4Address {orderDirection}"; break;
                case 7: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, MACAddress {orderDirection}"; break;
                case 8: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, DeviceType {orderDirection}, Name {orderDirection}"; break;
                case 9: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, LastSeen {orderDirection}, DeviceType {orderDirection}, Name {orderDirection}"; break;
                default: orderBy = ""; break;
            }

            string sqlQuery;
            if (!showGroupDetails)
            {
                if (chbShowDevicesInGroups.Checked)
                {
                    sqlQuery = $@"
                    SELECT * FROM 
                    (
                        SELECT
	                        Devices.MACAddress AS MACAddress,
	                        Devices.DeviceType AS DeviceType,
	                        Devices.Name AS Name,
	                        Devices.Description AS Description,
	                        Devices.Hostname AS Hostname,
	                        Devices.IP4Address AS IP4Address,
	                        Devices.IP6Address AS IP6Address,
	                        Devices.LastSeen AS LastSeen,
	                        Devices.LastPowerState AS LastPowerState,
	                        Devices.IsHidden AS IsHidden,
	                        false AS IsGroup,
                            0 AS GroupID
                        FROM Devices 
                        LEFT JOIN GroupAssigns ON Devices.MACAddress = GroupAssigns.MACAddress 
                        WHERE GroupAssigns.MACAddress IS NULL
                        UNION ALL
                        SELECT
	                        GDevices.MACAddress AS MACAddress,
	                        Groups.DeviceType AS DeviceType,
	                        Groups.Name AS Name,
	                        Groups.Description AS Description,
	                        GDevices.Hostname AS Hostname,
	                        GDevices.IP4Address AS IP4Address,
	                        GDevices.IP6Address AS IP6Address,
	                        GDevices.LastSeen AS LastSeen,
	                        GDevices.LastPowerState AS LastPowerState,
	                        GDevices.IsHidden AS IsHidden,
	                        true AS IsGroup,
                            Groups.ID AS GroupID
                        FROM Groups
                        LEFT JOIN GroupAssigns AS GGroupAssigns
                        ON Groups.ID = GGroupAssigns.GroupID
                        LEFT JOIN Devices AS GDevices
                        ON GGroupAssigns.MACAddress = GDevices.MACAddress
                        WHERE GGroupAssigns.MACAddress IS NOT NULL
                        AND GGroupAssigns.IsPrimary = true
                        GROUP BY GGroupAssigns.GroupID
                    )
                    {orderBy}
                ";
                }
                else
                {
                    sqlQuery = $"SELECT *, false AS IsGroup FROM Devices {orderBy}";
                }
            }
            else
            {
                sqlQuery = $@"SELECT Devices.MACAddress AS MACAddress,

                            Devices.DeviceType AS DeviceType,
	                        Devices.Name AS Name,
	                        Devices.Description AS Description,
	                        Devices.Hostname AS Hostname,
	                        Devices.IP4Address AS IP4Address,
	                        Devices.IP6Address AS IP6Address,
	                        Devices.LastSeen AS LastSeen,
	                        Devices.LastPowerState AS LastPowerState,
	                        Devices.IsHidden AS IsHidden,
	                        false AS IsGroup,
                            0 AS GroupID FROM Groups INNER JOIN GroupAssigns ON Groups.ID = GroupAssigns.GroupID INNER JOIN Devices ON GroupAssigns.MACAddress = Devices.MACAddress WHERE Groups.ID = '{selectedGroupID}'  {orderBy}";
            }

            // Load all devices and add then to the view
            sql.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery(sqlQuery))
            {
                while (reader.Read())
                {
                    string powerState;
                    string devicePrefix = "";

                    if (!Convert.ToBoolean(reader["IsHidden"]) || (Convert.ToBoolean(reader["IsHidden"]) && chbShowHiddenDevices.Checked))
                    {
                        if (Convert.ToBoolean(reader["IsGroup"]))
                        {
                            powerState = "_GroupON";
                            if (string.IsNullOrEmpty(Convert.ToString(reader["LastPowerState"])) || !Convert.ToBoolean(reader["LastPowerState"])) powerState = "_GroupOFF";
                        }
                        else
                        {
                            powerState = "_ON";
                            if (string.IsNullOrEmpty(Convert.ToString(reader["LastPowerState"])) || !Convert.ToBoolean(reader["LastPowerState"])) powerState = "_OFF";
                        }

                        if (Convert.ToBoolean(reader["IsHidden"])) devicePrefix = "[H] ";

                        // Add device to view
                        GroupViewItem gvi = new GroupViewItem(
                            devicePrefix + Convert.ToString(reader["Name"]),
                            grvDevices.LargeImageList.Images.IndexOfKey(
                                Convert.ToString(reader["DeviceType"]) + powerState)
                        );
                        gvi.Tag = Convert.ToString(reader["MACAddress"]);

                        grvDevices.GroupViewItems.Add(gvi);
                    }
                }
            }

            int entryCtr = sql.ExecuteScalar<int>("SELECT COUNT(*) FROM Devices");
            int onlineCtr = sql.ExecuteScalar<int>("SELECT COUNT(*) FROM Devices WHERE LastPowerState = true");

            sql.Close();

            // Update info-display
            lblDeviceCount.Text = $"{entryCtr} Devices Registered";
            lblDeviceOnlineCount.Text = $"{onlineCtr} Devices Online";
        }

        
        /// <summary>
        /// Launches the discover-dialog and Updates entries when finished
        /// </summary>
        private void BtnDiscover_Click(object sender, EventArgs e)
        {
            DiscoverDialog discover = new DiscoverDialog
            {
                IPRangeStart = lblIPRangeStart.Text,
                IPRangeEnd = lblIPRangeEnd.Text
            };

            // Open dialog and ask if entries should be updated upon completion
            if ( discover.ShowDialog() == DialogResult.OK && 
                discover.DiscoveredDevices.Count > 0 && 
                MessageBox.Show("Do you want to update your device-list with the new entries? (If a device already exists, only the IP-Address and Hostname get updated.)", "Import new devices", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Update DB
                sql.Open();
                try
                {
                    sql.TransactionBegin();
                    foreach (NetDevice device in discover.DiscoveredDevices)
                        if (sql.ExecuteScalar<int>("SELECT COUNT(*) FROM Devices WHERE MACAddress = ?", device.MAC) > 0)
                            sql.ExecuteNonQuery($"UPDATE Devices SET IP4Address = '{device.IPv4}', Hostname = '{device.Hostname}', LastSeen = '{DateTime.Now:yyyy-MM-dd H:mm:ss}' WHERE MACAddress = '{device.MAC}'");
                        else
                            sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, DeviceType, Name, Hostname, IP4Address, LastSeen) VALUES ('{device.MAC}','{device.DeviceType}','{device.Name}','{device.Hostname}','{device.IPv4}','{DateTime.Now:yyyy-MM-dd H:mm:ss}')");
                    sql.TransactionCommit();
                }
                catch
                {
                    sql.TransactionRollback();
                }
                sql.Close();
            }

            UpdateDeviceList();
        }

        private int selectedIndex = 0;
        private bool skipNextIndexCheck = false;

        private bool groupSelected = false;
        private int selectedGroupID = 0;

        private void grvDevices_GroupViewItemSelected(object sender, EventArgs e)
        {
            LoadDeviceData();
        }

        private void LoadDeviceData()
        {
            if (skipNextIndexCheck)
            {
                skipNextIndexCheck = false;
                return;
            }


            if (btnSaveChanges.Enabled)
            {
                DialogResult qResponse = MessageBox.Show($"Do you want to save the changes you made to \"{txbDeviceName.Text}\"?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (qResponse == DialogResult.Cancel)
                {
                    skipNextIndexCheck = true;
                    grvDevices.SelectedItem = selectedIndex;
                    return;
                }

                if (qResponse == DialogResult.Yes)
                {
                    SaveChanges();
                }
            }

            txbDeviceName.Enabled = true;
            txbDeviceDescription.Enabled = true;
            btnChangeDeviceType.Enabled = true;
            btnSaveChanges.Enabled = false;
            btnDiscardChanges.Enabled = false;
            btnHideDevice.Enabled = true;
            selectedIndex = grvDevices.SelectedItem;

            btnDeleteDevice.Enabled = true;
            btnEditDevice.Enabled = true;

            btnStartDeviceWOL.Enabled = true;
            btnUpdatePowerState.Enabled = true;

            btnStartAutoRDP.Enabled = true;
            btnOpenRDPSettings.Enabled = true;

            btnLinkRDP.Enabled = true;
            btnManageRDPFiles.Enabled = true;

            btnAddDeviceSite.Enabled = true;
            btnManageDeviceSites.Enabled = true;

            webMarkdown.Visible = true;
            txbDeviceDescription.Visible = false;



            string sqlQuery;

            if (chbShowDevicesInGroups.Checked && !showGroupDetails)
            {
                sqlQuery = $@"
                    SELECT * FROM 
                    (
                        SELECT
	                        Devices.MACAddress AS MACAddress,
	                        Devices.DeviceType AS DeviceType,
	                        Devices.Name AS Name,
	                        Devices.Description AS Description,
	                        Devices.Hostname AS Hostname,
	                        Devices.IP4Address AS IP4Address,
	                        Devices.IP6Address AS IP6Address,
	                        Devices.LastSeen AS LastSeen,
	                        Devices.LastPowerState AS LastPowerState,
	                        Devices.IsHidden AS IsHidden,
	                        false AS IsGroup,
                            0 AS GroupID
                        FROM Devices 
                        LEFT JOIN GroupAssigns ON Devices.MACAddress = GroupAssigns.MACAddress 
                        WHERE GroupAssigns.MACAddress IS NULL
                        UNION ALL
                        SELECT
	                        GDevices.MACAddress AS MACAddress,
	                        Groups.DeviceType AS DeviceType,
	                        Groups.Name AS Name,
	                        Groups.Description AS Description,
	                        GDevices.Hostname AS Hostname,
	                        GDevices.IP4Address AS IP4Address,
	                        GDevices.IP6Address AS IP6Address,
	                        GDevices.LastSeen AS LastSeen,
	                        GDevices.LastPowerState AS LastPowerState,
	                        GDevices.IsHidden AS IsHidden,
	                        true AS IsGroup,
                            Groups.ID AS GroupID
                        FROM Groups
                        LEFT JOIN GroupAssigns AS GGroupAssigns
                        ON Groups.ID = GGroupAssigns.GroupID
                        LEFT JOIN Devices AS GDevices
                        ON GGroupAssigns.MACAddress = GDevices.MACAddress
                        WHERE GGroupAssigns.MACAddress IS NOT NULL
                        AND GGroupAssigns.IsPrimary = true
                        GROUP BY GGroupAssigns.GroupID
                    )
                    WHERE MACAddress = '{grvDevices.GroupViewItems[grvDevices.SelectedItem].Tag}'
                ";
            }
            else
            {
                try
                {
                    sqlQuery = $"SELECT *, false AS IsGroup, 0 AS GroupID FROM Devices WHERE MACAddress = '{grvDevices.GroupViewItems[grvDevices.SelectedItem].Tag}'";
                }
                catch 
                {
                    return;
                }
                    
                if (showGroupDetails)
                {
                    tsbRemoveDeviceFromGroup.Enabled = true;
                    tsbSetDeviceAsGroupPrimary.Enabled = true;
                }
            }

            sql.Open();

            using (SQLiteDataReader reader = sql.ExecuteQuery(sqlQuery))
            {
                while (reader.Read())
                {
                    if (Convert.ToBoolean(reader["IsGroup"]))
                    {
                        groupSelected = true;
                        selectedGroupID = Convert.ToInt32(reader["GroupID"]);
                        btnHideDevice.Enabled = false;

                        btnEditGroup.Enabled = true;
                        btnDeleteGroup.Enabled = true;
                        tsbEnterGroupview.Enabled = true;

                    }
                    else
                    {
                        groupSelected = false;

                        if (!showGroupDetails)
                        {
                            btnEditGroup.Enabled = false;
                            btnDeleteGroup.Enabled = false;
                            tsbEnterGroupview.Enabled = false;
                        }
                    }

                    txbDeviceName.Text = Convert.ToString(reader["Name"]);
                    btnChangeDeviceType.Text = SurgitManager.ReadableString(Convert.ToString(reader["DeviceType"])) + " (click to change)";
                    txbDeviceDescription.Text = Convert.ToString(reader["Description"]);
                    if (string.IsNullOrEmpty(Convert.ToString(reader["LastSeen"]))) txbDeviceLastSeen.Text = "No Records";
                    else txbDeviceLastSeen.Text = Convert.ToDateTime(reader["LastSeen"]).ToString("d. MMMM yyyy, H:mm:ss");

                    txbDeviceHostname.Text = Convert.ToString(reader["Hostname"]);
                    txbDeviceIPv4.Text = Convert.ToString(reader["IP4Address"]);
                    txbDeviceIPv6.Text = Convert.ToString(reader["IP6Address"]);
                    txbDeviceMac.Text = Convert.ToString(reader["MACAddress"]);

                    Markdown md = new Markdown();
                    Write2WebControll(webMarkdown, md.Transform(Convert.ToString(reader["Description"])));

                    Debug.Print(md.Transform(Convert.ToString(reader["Description"])));

                    deviceType = Convert.ToString(reader["DeviceType"]);

                    if (Convert.ToBoolean(reader["IsHidden"])) btnHideDevice.Text = "Show Device";
                    else btnHideDevice.Text = "Hide Device";

                    txbDeviceManufacturer.Text = "";

                    if(bgwLoadMacVendor.WorkerSupportsCancellation)
                    {
                        bgwLoadMacVendor.CancelAsync();
                        if (!bgwLoadMacVendor.IsBusy)
                            bgwLoadMacVendor.RunWorkerAsync();
                    }

                    
                }
            }

            sql.Close();


            LoadRDPLinks();
            LoadDeviceLinks();
        }

        private void txbDeviceName_KeyDown(object sender, KeyEventArgs e)
        {
            btnSaveChanges.Enabled = true;
            btnDiscardChanges.Enabled = true;
        }

        private void txbDeviceDescription_KeyDown(object sender, KeyEventArgs e)
        {
            btnSaveChanges.Enabled = true;
            btnDiscardChanges.Enabled = true;
        }

        private string deviceType = null;
        private void btnChangeDeviceType_Click(object sender, EventArgs e)
        {
            DeviceTypeSelector devSelect = new DeviceTypeSelector();

            if(devSelect.ShowDialog() == DialogResult.OK)
            {
                btnChangeDeviceType.Text = devSelect.SelectedDeviceType + " (click to change)";
                deviceType = devSelect.SelectedDeviceType.Replace(" ", "");

                btnSaveChanges.Enabled = true;
                btnDiscardChanges.Enabled = true;
            }
        }

        

        private void SaveChanges()
        {
            sql.Open();
            if (groupSelected && selectedGroupID != 0)
            {
                btnSaveChanges.Enabled = false;
                btnDiscardChanges.Enabled = false;
                sql.ExecuteNonQuery($"UPDATE Groups SET Name = '{txbDeviceName.Text}', Description = '{txbDeviceDescription.Text}', DeviceType = '{deviceType}' WHERE ID = '{selectedGroupID}'");
            }
            else
            {
                if (sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM Devices WHERE Name = '{txbDeviceName.Text}' AND MACAddress != '{txbDeviceMac.Text}'") == 0)
                {
                    btnSaveChanges.Enabled = false;
                    btnDiscardChanges.Enabled = false;
                    sql.ExecuteNonQuery($"UPDATE Devices SET Name = '{txbDeviceName.Text}', Description = '{txbDeviceDescription.Text}', DeviceType = '{deviceType}' WHERE MACAddress = '{txbDeviceMac.Text}'");
                }
                else MessageBox.Show("The entered Device-Name already exitst. Please enter a unique name for each device!", "Name duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            sql.Close();
            UpdateDeviceList();
            LoadDeviceData();
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = false;
            btnDiscardChanges.Enabled = false;
            DeselectItem();
        }

        private void tmrStartPowerCheck_Tick(object sender, EventArgs e)
        {
            if (!bgwCheckPowerState.IsBusy) bgwCheckPowerState.RunWorkerAsync();
        }

        private void btnUpdateDevices_Click(object sender, EventArgs e)
        {
            UpdateEntries upd = new UpdateEntries
            {
                IPStartRange = lblIPRangeStart.Text,
                IPEndRange = lblIPRangeEnd.Text
            };

            if (upd.ShowDialog() == DialogResult.OK)
                UpdateDeviceList();
        }

        private void btnDiscoverSelf_Click(object sender, EventArgs e)
        {
            DiscoverLocal locDiscover = new DiscoverLocal();
            if(locDiscover.ShowDialog() == DialogResult.OK)
            {
                sql.Open();
                if (sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM Devices WHERE MACAddress = '{locDiscover.MAC}'") == 0)
                {
                    sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, IP4Address, IP6Address, Hostname, Name, DeviceType, LastSeen, LastPowerState) VALUES ('{locDiscover.MAC}','{locDiscover.IPv4}','{locDiscover.IPv6}','{locDiscover.Hostname}','Device-{locDiscover.MAC}','{DeviceType.UnknownDevice}','{DateTime.Now:yyyy-MM-dd H:mm:ss}','1')");
                }
                else MessageBox.Show("The selected Device already exists. Please select another interface.", "Duplicate MAC-Addresses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sql.Close();
                UpdateDeviceList();
            }
            
        }

        private void bgwCheckPowerState_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) => SurgitManager.PowerStateCheck(lblIPRangeStart.Text, lblIPRangeEnd.Text, bgwCheckPowerState);
        private void btnSaveChanges_Click(object sender, EventArgs e) => SaveChanges();
        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
            DeselectItem();
        }
        private void cbxSortOrder_SelectedIndexChanged(object sender, EventArgs e) => UpdateDeviceList();
        private void btnRefresh_Click(object sender, EventArgs e) => UpdateDeviceList();

        private void bgwCheckPowerState_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (bgwCheckPowerState.CancellationPending) return;

            if (!btnSaveChanges.Enabled) UpdateDeviceList();
            lblProgressReport.Text = "Surgit Network Manager - Last Auto-PowerCheck finished at " + DateTime.Now.ToLongTimeString();
        }

        private void bgwCheckPowerState_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                string[] ipStartParts = lblIPRangeStart.Text.Split('.');
                string[] ipEndParts = lblIPRangeEnd.Text.Split('.');

                pgbPowerCheck.Maximum = Convert.ToInt32(ipEndParts[3]) - Convert.ToInt32(ipStartParts[3]);
                pgbPowerCheck.Minimum = 0;

                string currentIP = $"{ipStartParts[0]}.{ipStartParts[1]}.{ipStartParts[2]}.{e.ProgressPercentage}";

                lblProgressReport.Text = "Checking Power-State of " + currentIP + "...";

                if (e.ProgressPercentage <= pgbPowerCheck.Maximum)
                    pgbPowerCheck.Value = e.ProgressPercentage;
            }
            catch
            {
                lblProgressReport.Text = "An error occured during the PowerState-Check. Check if the IP-Range is correct.";
                if (bgwCheckPowerState.WorkerSupportsCancellation) bgwCheckPowerState.CancelAsync();
            }
        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright information\r\n\r\nAny images used, excluding the Surgit-Logo, are default Windows icons and therefor owned and copyrighted by Microsoft.\r\n\r\nThis program is partially built using the Syncfusion Framework under the Syncfusion Comunity Licence.\r\n\r\nThe program, as is, is property of Tobias Hattinger @ Endix Development.\r\nView the Licence at https://github.com/TobiHatti/Surgit-Network-Manager for more information.", "Copyright and Licence information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditIPRange_Click(object sender, EventArgs e)
        {
            EditIPRange ipedit = new EditIPRange
            {
                IPStartRange = lblIPRangeStart.Text,
                IPEndRange = lblIPRangeEnd.Text
            };

            if(ipedit.ShowDialog() == DialogResult.OK)
            {
                sql.Open();
                try
                {
                    sql.TransactionBegin();
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{ipedit.IPStartRange}' WHERE Key = 'IPRangeStart'");
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{ipedit.IPEndRange}' WHERE Key = 'IPRangeEnd'");
                    sql.TransactionCommit();
                }
                catch
                {
                    sql.TransactionRollback();
                }
                sql.Close();

                lblIPRangeStart.Text = ipedit.IPStartRange;
                lblIPRangeEnd.Text = ipedit.IPEndRange;

                if (bgwCheckPowerState.WorkerSupportsCancellation)
                    bgwCheckPowerState.CancelAsync();
            }
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the Device \"{txbDeviceName.Text}\"?", "Delete device", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                sql.ExecuteNonQueryACon($"DELETE FROM Devices WHERE MACAddress = '{txbDeviceMac.Text}'");
                UpdateDeviceList();

                DeselectItem();
            }
        }

        private void ClearDeviceInfo()
        {
            txbDeviceName.Text = "";
            txbDeviceDescription.Text = "";
            txbDeviceLastSeen.Text = "";
            txbDeviceIPv4.Text = "";
            txbDeviceIPv6.Text = "";
            txbDeviceMac.Text = "";
            txbDeviceManufacturer.Text = "";
            txbDeviceHostname.Text = "";

            btnChangeDeviceType.Enabled = false;
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            AddEditDevice addDevice = new AddEditDevice
            {
                IsEditMode = false
            };

            if (addDevice.ShowDialog() == DialogResult.OK)
            {
                sql.Open();
                sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, Name, DeviceType, Description, Hostname, IP4Address, IP6Address) VALUES ('{addDevice.DeviceMac}','{addDevice.DeviceName}','{addDevice.DeviceTType}','{addDevice.DeviceDescription}','{addDevice.DeviceHostname}','{addDevice.DeviceIPv4}','{addDevice.DeviceIPv6}')");
                sql.Close();
                UpdateDeviceList();
            }
        }

        private void btnEditDevice_Click(object sender, EventArgs e)
        {
            AddEditDevice editDevice = new AddEditDevice
            {
                IsEditMode = true,
                DeviceName = txbDeviceName.Text,
                DeviceDescription = txbDeviceDescription.Text,
                DeviceTType = deviceType,
                DeviceHostname = txbDeviceHostname.Text,
                DeviceIPv4 = txbDeviceIPv4.Text,
                DeviceIPv6 = txbDeviceIPv6.Text,
                DeviceMac = txbDeviceMac.Text
            };

            if (editDevice.ShowDialog() == DialogResult.OK)
            {
                sql.Open();
                sql.ExecuteNonQuery($"UPDATE Devices SET Name = '{editDevice.DeviceName}', Description = '{editDevice.DeviceDescription}', DeviceType = '{editDevice.DeviceTType}', Hostname = '{editDevice.DeviceHostname}', IP4Address = '{editDevice.DeviceIPv4}', IP6Address = '{editDevice.DeviceIPv6}' WHERE MACAddress = '{editDevice.OriginalDeviceMac}'");
                if(editDevice.DeviceMac != editDevice.OriginalDeviceMac) sql.ExecuteNonQuery($"UPDATE Devices SET MACAddress = '{editDevice.DeviceMac}' WHERE MACAddress = '{editDevice.OriginalDeviceMac}'");
                sql.Close();

                UpdateDeviceList();
                LoadDeviceData();
            }
        }

        private void btnStartDeviceWOL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Do you want to attempt to start the device \"{txbDeviceName.Text}\" via Wake-On-Lan?", "Start Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txbDeviceIPv4.Text) && !string.IsNullOrEmpty(txbDeviceMac.Text))
                {
                    WOLStart wol = new WOLStart
                    {
                        MACAddress = txbDeviceMac.Text,
                        IPv4 = txbDeviceIPv4.Text
                    };
                    wol.ShowDialog();
                    UpdateDeviceList();
                    DeselectItem();
                }
                else MessageBox.Show("Could not wake device. IPv4 and MAC address are required.", "WOL Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbShowHiddenDevices_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
            DeselectItem();
        }

        private void btnHideDevice_Click(object sender, EventArgs e)
        {
            sql.Open();
            if (sql.ExecuteScalar<int>($"SELECT IsHidden FROM Devices WHERE MACAddress = '{txbDeviceMac.Text}'") == 1)
                sql.ExecuteNonQuery($"UPDATE Devices SET IsHidden = 0 WHERE MACAddress = '{txbDeviceMac.Text}'");
            else
                sql.ExecuteNonQuery($"UPDATE Devices SET IsHidden = 1 WHERE MACAddress = '{txbDeviceMac.Text}'");
            sql.Close();

            UpdateDeviceList();
            DeselectItem();
        }

        private void DeselectItem()
        {
            ClearDeviceInfo();

            txbDeviceName.Enabled = false;
            txbDeviceDescription.Enabled = false;
            btnChangeDeviceType.Enabled = false;

            webMarkdown.Visible = true;
            txbDeviceDescription.Visible = false;

            btnSaveChanges.Enabled = false;
            btnDiscardChanges.Enabled = false;
            btnHideDevice.Enabled = false;

            btnDeleteDevice.Enabled = false;
            btnEditDevice.Enabled = false;

            btnStartDeviceWOL.Enabled = false;
            btnUpdatePowerState.Enabled = false;

            btnStartAutoRDP.Enabled = false;
            btnOpenRDPSettings.Enabled = false;

            btnLinkRDP.Enabled = false;
            btnManageRDPFiles.Enabled = false;

            btnAddDeviceSite.Enabled = false;
            btnManageDeviceSites.Enabled = false;

            while (tseDeviceSites.Items.Count > 3)
                tseDeviceSites.Items.RemoveAt(3);

            while (tseRDPLinks.Items.Count > 3)
                tseRDPLinks.Items.RemoveAt(3);

            Write2WebControll(webMarkdown, "");
        }

        private void btnUpdatePowerState_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbDeviceIPv4.Text))
            {
                Ping ping = new Ping();
                PingReply reply;
                int online = 0;
                for (int i = 0; i < 3; i++)
                {
                    reply = ping.Send(txbDeviceIPv4.Text, 500);
                    if (reply.Status == IPStatus.Success) online = 1;
                }

                sql.ExecuteNonQueryACon($"UPDATE Devices SET LastPowerState = '{online}' WHERE MACAddress = '{txbDeviceMac.Text}'");

                UpdateDeviceList();
                DeselectItem();
            }
            else MessageBox.Show("Could not ping the device. No IPv4-Address.", "Ping Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnStartAutoRDP_Click(object sender, EventArgs e)
        {
            RDPConnect rdp = new RDPConnect
            {
                MachineNameOrIP = txbDeviceIPv4.Text
            };

            sql.Open();
            rdp.MultiMonitor = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPMultiMonitor'"));
            rdp.FullScreen = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPFullScreen'"));
            rdp.WindowWidth = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenWidth'"));
            rdp.WindowHeight = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenHeight'"));
            rdp.PublicMode = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPPublicMode'"));
            sql.Close();

            rdp.StartRDP();
        }

        private void btnOpenRDPSettings_Click(object sender, EventArgs e)
        {
            RDPSettings rdpSettings = new RDPSettings();

            sql.Open();
            rdpSettings.MultiMonitor = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPMultiMonitor'"));
            rdpSettings.FullScreen = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPFullScreen'"));
            rdpSettings.WindowWidth = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenWidth'"));
            rdpSettings.WindowHeight = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenHeight'"));
            rdpSettings.PublicMode = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPPublicMode'"));
            sql.Close();

            if(rdpSettings.ShowDialog() == DialogResult.OK)
            {
                sql.Open();
                try
                {
                    sql.TransactionBegin();
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.MultiMonitor}' WHERE Key = 'RDPMultiMonitor'");
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.FullScreen}' WHERE Key = 'RDPFullScreen'");
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.WindowWidth}' WHERE Key = 'RDPScreenWidth'");
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.WindowHeight}' WHERE Key = 'RDPScreenHeight'");
                    sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.PublicMode}' WHERE Key = 'RDPPublicMode'");
                    sql.TransactionCommit();
                }
                catch
                {
                    sql.TransactionRollback();
                }
                sql.Close();
            }
        }

        private void btnLinkRDP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ofdOpenRDPFile.FileName)) ofdOpenRDPFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else ofdOpenRDPFile.InitialDirectory = Path.GetDirectoryName(ofdOpenRDPFile.FileName);

            ofdOpenRDPFile.FileName = "";

            if(ofdOpenRDPFile.ShowDialog() == DialogResult.OK)
            {
                string name = Path.GetFileNameWithoutExtension(ofdOpenRDPFile.FileName);
                sql.ExecuteNonQueryACon($"INSERT INTO RDPFiles (MACAddress, Name, Path) VALUES ('{txbDeviceMac.Text}','{name}','{ofdOpenRDPFile.FileName}')");
                LoadDeviceData();
            }
        }

        private void LoadRDPLinks()
        {
            sql.Open();


            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM RDPFiles WHERE MACAddress = '{txbDeviceMac.Text}'"))
            {
                while(tseRDPLinks.Items.Count > 3)
                    tseRDPLinks.Items.RemoveAt(3);

                while (reader.Read())
                {


                    ToolStripButton tsb = new ToolStripButton(Convert.ToString(reader["Name"]), Properties.Resources.rdpIco.ToBitmap())
                    {
                        ImageScaling = ToolStripItemImageScaling.None,
                        TextImageRelation = TextImageRelation.ImageAboveText,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                        Tag = Convert.ToString(reader["Path"])
                    };

                    tsb.Click += new EventHandler(CallRDP);

                    tseRDPLinks.Items.Add(tsb);
                }
            }

            sql.Close();
        }

        private void LoadDeviceLinks()
        {
            sql.Open();


            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM DeviceSites WHERE MACAddress = '{txbDeviceMac.Text}'"))
            {
                while (tseDeviceSites.Items.Count > 3)
                    tseDeviceSites.Items.RemoveAt(3);

                while (reader.Read())
                {
                    ToolStripButton tsb = new ToolStripButton(Convert.ToString(reader["Name"]), Properties.Resources.webIco.ToBitmap())
                    {
                        ImageScaling = ToolStripItemImageScaling.None,
                        TextImageRelation = TextImageRelation.ImageAboveText,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                        Tag = Convert.ToString(reader["Site"])
                    };

                    tsb.Click += new EventHandler(CallSite);

                    tseDeviceSites.Items.Add(tsb);
                }
            }

            sql.Close();
        }

        void CallRDP(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton tsb = sender as ToolStripButton;

                Process rdcProcess = new Process();
                rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
                rdcProcess.StartInfo.Arguments = tsb.Tag.ToString() + " "; // ip or name of computer to connect
                rdcProcess.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not launch RDP. Please ensure that the RDP-File still exists. More information below:\r\n\r\n" + ex.Message);
            }
        }

        void CallSite(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton tsb = sender as ToolStripButton;
                Process.Start(tsb.Tag.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not launch the Device-Site. More information below:\r\n\r\n" + ex.Message);
            }
        }

        private void btnAddDeviceSite_Click(object sender, EventArgs e)
        {
            AddDeviceSite ads = new AddDeviceSite();
            if(ads.ShowDialog() == DialogResult.OK)
            {
                sql.ExecuteNonQueryACon($"INSERT INTO DeviceSites (Name, Site, MACAddress) VALUES ('{ads.DeviceName}','{ads.DeviceSiteURL}','{txbDeviceMac.Text}')");
                LoadDeviceData();
            }
        }

        private void btnManageRDPFiles_Click(object sender, EventArgs e)
        {
            ManageRDPFiles manageRDP = new ManageRDPFiles
            {
                MACAddress = txbDeviceMac.Text
            };
            manageRDP.ShowDialog();

            LoadDeviceData();
        }

        private void btnManageDeviceSites_Click(object sender, EventArgs e)
        {
            ManageDeviceSites manageSites = new ManageDeviceSites
            {
                MACAddress = txbDeviceMac.Text
            };
            manageSites.ShowDialog();

            LoadDeviceData();
        }

        private void SurgitMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            spcSplitter.SplitterDistance = 480;
        }

        private void SurgitMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void grvDevices_GroupViewItemDoubleClick(GroupView sender, GroupViewItemDoubleClickEventArgs e)
        {
            LoadDeviceData();
            if (groupSelected)
            {
                EnterGroupView();
            }
        }

        private string macVendor = "";
        private void bgwLoadMacVendor_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            macVendor = "Could not load MAC-Vendor.";

            try
            {
                if (bgwLoadMacVendor.CancellationPending) return;
                using (WebClient webClient = new WebClient())
                    macVendor = webClient.DownloadString("http://api.macvendors.com/" + WebUtility.UrlEncode(txbDeviceMac.Text));
            }
            catch { }
        }

        private void bgwLoadMacVendor_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            txbDeviceManufacturer.Text = macVendor;
        }

        private void Write2WebControll(WebBrowser web, string content)
        {
            web.Navigate("about:blank");
            web.Document.Write(string.Empty);
            web.DocumentText = "<style>*{font-family: Calibri, sans-serif;font-weight: lighter;}html{margin:0;padding:0;border:1px solid #888888;}body{margin:3px;padding:0;}p{margin:0;}h1,h2,h3,h4,h5,h6{margin:5px 0px;color:#1E90FF;}ul{margin:1px auto;}</style>" + content;
        }

        private void webMarkdown_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webMarkdown.Document.Body.MouseDown += new HtmlElementEventHandler(Body_MouseDown);
        }

        void Body_MouseDown(Object sender, HtmlElementEventArgs e)
        {
            if(grvDevices.SelectedItem != -1 && e.MouseButtonsPressed == MouseButtons.Left)
            {
                webMarkdown.Visible = false;
                txbDeviceDescription.Visible = true;
                txbDeviceDescription.Focus();
                txbDeviceDescription.Select();
            }
        }

        private void chbShowDevicesInGroups_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
            DeselectItem();
        }

        private void tsbEnterGroupview_Click(object sender, EventArgs e)
        {
            EnterGroupView();
        }

        private void tsbExitGroupview_Click(object sender, EventArgs e)
        {
            ExitGroupView();
        }

        private void ExitGroupView()
        {
            lblDeviceViewTitle.Text = "Devices";

            tsbSetDeviceAsGroupPrimary.Enabled = false;
            tsbRemoveDeviceFromGroup.Enabled = false;
            tsbExitGroupview.Enabled = false;
            btnEditGroup.Enabled = false;
            btnCreateGroup.Enabled = true;
            btnDeleteGroup.Enabled = false;

            showGroupDetails = false;
            UpdateDeviceList();
            DeselectItem();
        }

        private void EnterGroupView()
        {
            lblDeviceViewTitle.Text = "Devices - Group: " + sql.ExecuteScalarACon<string>($"SELECT Name FROM Groups WHERE ID = '{selectedGroupID}'");

            tstGroups.Checked = true;

            tsbEnterGroupview.Enabled = false;
            tsbExitGroupview.Enabled = true;
            btnEditGroup.Enabled = true;
            btnCreateGroup.Enabled = false;
            btnDeleteGroup.Enabled = true;

            showGroupDetails = true;
            UpdateDeviceList();

        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this device group?\r\n\r\n(This action only deletes the group, not the devices.)", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                sql.Open();
                sql.TransactionBegin();
                try
                {
                    sql.ExecuteNonQuery($"DELETE FROM Groups WHERE ID = '{selectedGroupID}'");
                    sql.ExecuteNonQuery($"DELETE FROM GroupAssigns WHERE GroupID = '{selectedGroupID}'");
                    sql.TransactionCommit();
                }
                catch
                {
                    sql.TransactionRollback();
                }
                sql.Close();

                ExitGroupView();
            }
        }

        private void tsbSetDeviceAsGroupPrimary_Click(object sender, EventArgs e)
        {
            if (selectedGroupID != 0 && !string.IsNullOrEmpty(txbDeviceMac.Text))
            {
                sql.Open();
                sql.TransactionBegin();
                try
                {
                    sql.ExecuteNonQuery($"UPDATE GroupAssigns SET IsPrimary = '0' WHERE GroupID = '{selectedGroupID}'");
                    sql.ExecuteNonQuery($"UPDATE GroupAssigns SET IsPrimary = '1' WHERE GroupID = '{selectedGroupID}' AND MACAddress = '{txbDeviceMac.Text}'");
                    sql.TransactionCommit();
                }
                catch
                {
                    sql.TransactionRollback();
                }

                sql.Close();

                UpdateDeviceList();
                DeselectItem();
                MessageBox.Show("Primary-Device for the group has been set successfully!", "Primary Device", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Could not set primary-device of the group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            AddEditGroup addGroup = new AddEditGroup();
            addGroup.IsEditMode = false;

            if(addGroup.ShowDialog() == DialogResult.OK)
            {
                UpdateDeviceList();
                DeselectItem();
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            AddEditGroup editGroup = new AddEditGroup();
            editGroup.IsEditMode = true;
            editGroup.GroupID = selectedGroupID;

            if (editGroup.ShowDialog() == DialogResult.OK)
            {
                UpdateDeviceList();
                DeselectItem();
            }
        }

        private void tsbRemoveDeviceFromGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this device from the group?", "Remove device", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql.Open();
                sql.ExecuteNonQuery($"DELETE FROM GroupAssigns WHERE MACAddress = '{txbDeviceMac.Text}' AND GroupID = '{selectedGroupID}'");
                
                // If the group is empty, delete it
                int groupItemCount = sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM GroupAssigns WHERE GroupID = '{selectedGroupID}'");
                if (groupItemCount == 0) sql.ExecuteNonQuery($"DELETE FROM Groups WHERE ID = '{selectedGroupID}'");
                else
                {
                    // if the primary-device gets removed, re-assign it
                    if (sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM GroupAssigns WHERE GroupID = '{selectedGroupID}' AND IsPrimary = '1'") == 0)
                    {
                        int newPrimaryID = sql.ExecuteScalar<int>($"SELECT ID FROM GroupAssigns WHERE GroupID = '{selectedGroupID}' LIMIT 1");
                        sql.ExecuteNonQuery($"UPDATE GroupAssigns SET IsPrimary = '1' WHERE ID = '{newPrimaryID}'");
                    }
                }

                sql.Close();

                if(groupItemCount == 0) ExitGroupView();
                UpdateDeviceList();
                DeselectItem();
            }
        }
    }
#pragma warning restore IDE1006
}