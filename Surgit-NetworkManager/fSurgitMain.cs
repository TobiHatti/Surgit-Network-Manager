using MarkdownSharp;
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
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class SurgitMain : RibbonForm
    {
        private readonly CSQLite sql = null;

        public SurgitMain()
        {
            InitializeComponent();

            // Copy DB-File if not existent
            if (!File.Exists(SurgitManager.SurgitDatabaseLocation))
            {
                File.Copy("surgitBlank.db", SurgitManager.SurgitDatabaseLocation);
            }

            // Initialize DBConnection
            sql = new CSQLite(SurgitManager.SurgitDatabaseLocation);

            // Test DB Connections
            if (!sql.ConnectionTest()) throw new Exception("Could not connect to DB [SQL]");

           // Configure and Initialize form elements
            grvDevices.LargeImageList = NetDevice.GetImageList();
            cbxSortBy.SelectedIndex = 5;
            cbxSortOrder.SelectedIndex = 0;

            // Initialize Surgit
            ApplyFormStyle();
            UpdateDeviceList();

            sql.connection.Open();
            lblIPRangeStart.Text = sql.ExecuteScalar<string>($"SELECT Value FROM Settings WHERE Key = 'IPRangeStart'");
            lblIPRangeEnd.Text = sql.ExecuteScalar<string>($"SELECT Value FROM Settings WHERE Key = 'IPRangeEnd'");
            sql.connection.Close();

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

            this.Text = $"Surgit Network Manager  (Version {System.Reflection.Assembly.GetEntryAssembly().GetName().Version})";

            this.rbcRibbonMenu.TitleFont = new Font("Calibri", 11);

            Write2WebControll(webMarkdown, "");

            spcSplitter.SplitterDistance = 410;
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
                case 3: orderBy = $"ORDER BY DeviceType {orderDirection}"; break;
                case 4: orderBy = $"ORDER BY LastSeen {orderDirection}"; break;
                case 5: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, Name {orderDirection}"; break;
                case 6: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, IP4Address {orderDirection}"; break;
                case 7: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, DeviceType {orderDirection}"; break;
                case 8: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, MACAddress {orderDirection}"; break;
                case 9: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, LastSeen {orderDirection}"; break;
                default: orderBy = ""; break;
            }

            int entryCtr = 0;
            int onlineCtr = 0;

            // Load all devices and add then to the view
            sql.connection.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM Devices {orderBy}"))
            while(reader.Read())
            {
                if (!Convert.ToBoolean(reader["IsHidden"]) || (Convert.ToBoolean(reader["IsHidden"]) && chbShowHiddenDevices.Checked))
                {
                    string powerState = "_ON";

                    // Check if the device is powered
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["LastPowerState"])) && Convert.ToBoolean(reader["LastPowerState"])) onlineCtr++;
                    else powerState = "_OFF";

                    string devicePrefix = "";
                    if (Convert.ToBoolean(reader["IsHidden"])) devicePrefix = "[H] ";

                    // Add device to view
                    grvDevices.GroupViewItems.Add(
                    new GroupViewItem(
                        devicePrefix + Convert.ToString(reader["Name"]),
                        grvDevices.LargeImageList.Images.IndexOfKey(
                            Convert.ToString(reader["DeviceType"]) + powerState)
                    ));
                }

                entryCtr++;
            }
            sql.connection.Close();

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
                sql.connection.Open();
                foreach (NetDevice device in discover.DiscoveredDevices)
                    if(sql.ExecuteScalar<int>("SELECT COUNT(*) FROM Devices WHERE MACAddress = ?", device.MAC) > 0)
                        sql.ExecuteNonQuery($"UPDATE Devices SET IP4Address = '{device.IPv4}', Hostname = '{device.Hostname}', LastSeen = '{DateTime.Now:yyyy-MM-dd H:mm:ss}' WHERE MACAddress = '{device.MAC}'");
                    else
                        sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, DeviceType, Name, Hostname, IP4Address, LastSeen) VALUES ('{device.MAC}','{device.DeviceType}','{device.Name}','{device.Hostname}','{device.IPv4}','{DateTime.Now:yyyy-MM-dd H:mm:ss}')");
                sql.connection.Close();
            }

            UpdateDeviceList();
        }

        private int selectedIndex = 0;
        private bool skipNextIndexCheck = false;
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

            sql.connection.Open();

            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM Devices WHERE Name = '{grvDevices.GroupViewItems[grvDevices.SelectedItem].Text.Replace("[H] ", "")}'"))
            {
                while (reader.Read())
                {
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

            sql.connection.Close();


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
            sql.connection.Open();
            if (sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM Devices WHERE Name = '{txbDeviceName.Text}' AND MACAddress != '{txbDeviceMac.Text}'") == 0)
            {
                btnSaveChanges.Enabled = false;
                btnDiscardChanges.Enabled = false;
                sql.ExecuteNonQuery($"UPDATE Devices SET Name = '{txbDeviceName.Text}', Description = '{txbDeviceDescription.Text}', DeviceType = '{deviceType}' WHERE MACAddress = '{txbDeviceMac.Text}'");
            }
            else MessageBox.Show("The entered Device-Name already exitst. Please enter a unique name for each device!", "Name duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sql.connection.Close();
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
                sql.connection.Open();
                if (sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM Devices WHERE MACAddress = '{locDiscover.MAC}'") == 0)
                {
                    sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, IP4Address, IP6Address, Hostname, Name, DeviceType, LastSeen, LastPowerState) VALUES ('{locDiscover.MAC}','{locDiscover.IPv4}','{locDiscover.IPv6}','{locDiscover.Hostname}','Device-{locDiscover.MAC}','{DeviceType.UnknownDevice}','{DateTime.Now:yyyy-MM-dd H:mm:ss}','1')");
                }
                else MessageBox.Show("The selected Device already exists. Please select another interface.", "Duplicate MAC-Addresses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sql.connection.Close();
                UpdateDeviceList();
            }
            
        }

        private void bgwCheckPowerState_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) => SurgitManager.PowerStateCheck(lblIPRangeStart.Text, lblIPRangeEnd.Text, bgwCheckPowerState);
        private void btnSaveChanges_Click(object sender, EventArgs e) => SaveChanges();
        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e) => UpdateDeviceList();
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
                sql.connection.Open();
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{ipedit.IPStartRange}' WHERE Key = 'IPRangeStart'");
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{ipedit.IPEndRange}' WHERE Key = 'IPRangeEnd'");
                sql.connection.Close();

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
                sql.ExecuteNonQueryA($"DELETE FROM Devices WHERE MACAddress = '{txbDeviceMac.Text}'");
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
                sql.connection.Open();
                sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, Name, DeviceType, Description, Hostname, IP4Address, IP6Address) VALUES ('{addDevice.DeviceMac}','{addDevice.DeviceName}','{addDevice.DeviceTType}','{addDevice.DeviceDescription}','{addDevice.DeviceHostname}','{addDevice.DeviceIPv4}','{addDevice.DeviceIPv6}')");
                sql.connection.Close();
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
                sql.connection.Open();
                sql.ExecuteNonQuery($"UPDATE Devices SET Name = '{editDevice.DeviceName}', Description = '{editDevice.DeviceDescription}', DeviceType = '{editDevice.DeviceTType}', Hostname = '{editDevice.DeviceHostname}', IP4Address = '{editDevice.DeviceIPv4}', IP6Address = '{editDevice.DeviceIPv6}' WHERE MACAddress = '{editDevice.OriginalDeviceMac}'");
                if(editDevice.DeviceMac != editDevice.OriginalDeviceMac) sql.ExecuteNonQuery($"UPDATE Devices SET MACAddress = '{editDevice.DeviceMac}' WHERE MACAddress = '{editDevice.OriginalDeviceMac}'");
                sql.connection.Close();

                UpdateDeviceList();
                LoadDeviceData();
            }
        }

        private void btnStartDeviceWOL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Do you want to attempt to start the device \"{txbDeviceName.Text}\" via Wake-On-Lan?", "Start Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                WOLStart wol = new WOLStart
                {
                    MACAddress = txbDeviceMac.Text,
                    IPv4 = txbDeviceIPv4.Text
                };
                wol.ShowDialog();
            }
        }

        private void chbShowHiddenDevices_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
            DeselectItem();
        }

        private void btnHideDevice_Click(object sender, EventArgs e)
        {
            sql.connection.Open();
            if (sql.ExecuteScalar<int>($"SELECT IsHidden FROM Devices WHERE MACAddress = '{txbDeviceMac.Text}'") == 1)
                sql.ExecuteNonQuery($"UPDATE Devices SET IsHidden = 0 WHERE MACAddress = '{txbDeviceMac.Text}'");
            else
                sql.ExecuteNonQuery($"UPDATE Devices SET IsHidden = 1 WHERE MACAddress = '{txbDeviceMac.Text}'");
            sql.connection.Close();

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
            Ping ping = new Ping();
            PingReply reply;
            int online = 0;
            for (int i = 0; i < 3; i++)
            {
                reply = ping.Send(txbDeviceIPv4.Text,500);
                if (reply.Status == IPStatus.Success) online = 1;
            }

            sql.ExecuteNonQueryA($"UPDATE Devices SET LastPowerState = '{online}' WHERE MACAddress = '{txbDeviceMac.Text}'");

            UpdateDeviceList();
            DeselectItem();
        }

        private void btnStartAutoRDP_Click(object sender, EventArgs e)
        {
            RDPConnect rdp = new RDPConnect
            {
                MachineNameOrIP = txbDeviceIPv4.Text
            };

            sql.connection.Open();
            rdp.MultiMonitor = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPMultiMonitor'"));
            rdp.FullScreen = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPFullScreen'"));
            rdp.WindowWidth = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenWidth'"));
            rdp.WindowHeight = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenHeight'"));
            rdp.PublicMode = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPPublicMode'"));
            sql.connection.Close();

            rdp.StartRDP();
        }

        private void btnOpenRDPSettings_Click(object sender, EventArgs e)
        {
            RDPSettings rdpSettings = new RDPSettings();

            sql.connection.Open();
            rdpSettings.MultiMonitor = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPMultiMonitor'"));
            rdpSettings.FullScreen = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPFullScreen'"));
            rdpSettings.WindowWidth = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenWidth'"));
            rdpSettings.WindowHeight = Convert.ToInt32(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPScreenHeight'"));
            rdpSettings.PublicMode = Convert.ToBoolean(sql.ExecuteScalar<string>("SELECT Value FROM Settings WHERE Key = 'RDPPublicMode'"));
            sql.connection.Close();

            if(rdpSettings.ShowDialog() == DialogResult.OK)
            {
                sql.connection.Open();
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.MultiMonitor}' WHERE Key = 'RDPMultiMonitor'");
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.FullScreen}' WHERE Key = 'RDPFullScreen'");
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.WindowWidth}' WHERE Key = 'RDPScreenWidth'");
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.WindowHeight}' WHERE Key = 'RDPScreenHeight'");
                sql.ExecuteNonQuery($"UPDATE Settings SET Value = '{rdpSettings.PublicMode}' WHERE Key = 'RDPPublicMode'");
                sql.connection.Close();
            }
        }

        private void btnLinkRDP_Click(object sender, EventArgs e)
        {
            ofdOpenRDPFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if(ofdOpenRDPFile.ShowDialog() == DialogResult.OK)
            {
                string name = Path.GetFileNameWithoutExtension(ofdOpenRDPFile.FileName);
                sql.ExecuteNonQueryA($"INSERT INTO RDPFiles (MACAddress, Name, Path) VALUES ('{txbDeviceMac.Text}','{name}','{ofdOpenRDPFile.FileName}')");
                LoadDeviceData();
            }
        }

        private void LoadRDPLinks()
        {
            sql.connection.Open();


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

            sql.connection.Close();
        }

        private void LoadDeviceLinks()
        {
            sql.connection.Open();


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

            sql.connection.Close();
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
                sql.ExecuteNonQueryA($"INSERT INTO DeviceSites (Name, Site, MACAddress) VALUES ('{ads.DeviceName}','{ads.DeviceSiteURL}','{txbDeviceMac.Text}')");
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
        }

        private void SurgitMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void grvDevices_GroupViewItemDoubleClick(GroupView sender, GroupViewItemDoubleClickEventArgs e)
        {
            LoadDeviceData();
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
    }
#pragma warning restore IDE1006
}