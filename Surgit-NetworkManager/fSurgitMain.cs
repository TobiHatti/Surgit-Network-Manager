using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
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

            // Initialize DBConnection
            sql = new CSQLite(SurgitManager.SurgitDatabaseLocation);

            // Test DB Connections
            if (!sql.ConnectionTest()) throw new Exception("Could not connect to DB [SQL]");

           // Configure and Initialize form elements
            grvDevices.LargeImageList = NetDevice.GetImageList();
            cbxSortBy.SelectedIndex = 4;
            cbxSortOrder.SelectedIndex = 0;

            // Initialize Surgit
            ApplyFormStyle();
            UpdateDeviceList();

            // Start the power-state check
            if (!bgwCheckPowerState.IsBusy) bgwCheckPowerState.RunWorkerAsync();
        }

        private void SurgitMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            this.rbcRibbonMenu.TitleFont = new Font("Calibri", 11);
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
                case 3: orderBy = $"ORDER BY LastSeen {orderDirection}"; break;
                case 4: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, Name {orderDirection}"; break;
                case 5: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, IP4Address {orderDirection}"; break;
                case 6: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, MACAddress {orderDirection}"; break;
                case 7: orderBy = $"ORDER BY LastPowerState {orderDirectionRev}, LastSeen {orderDirection}"; break;
                default: orderBy = ""; break;
            }

            int entryCtr = 0;
            int onlineCtr = 0;

            // Load all devices and add then to the view
            sql.connection.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM Devices {orderBy}"))
            while(reader.Read())
            {
                string powerState = "_ON";

                // Check if the device is powered
                if (!string.IsNullOrEmpty(Convert.ToString(reader["LastPowerState"])) && Convert.ToBoolean(reader["LastPowerState"])) onlineCtr++;
                else powerState = "_OFF";

                // Add device to view
                grvDevices.GroupViewItems.Add(
                    new GroupViewItem(
                        Convert.ToString(reader["Name"]), 
                        grvDevices.LargeImageList.Images.IndexOfKey(
                            Convert.ToString(reader["DeviceType"]) + powerState)
                ));

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
                IPRangeStart = txbIPRangeStart.Text,
                IPRangeEnd = txbIPRangeEnd.Text
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
            if(skipNextIndexCheck)
            {
                skipNextIndexCheck = false;
                return;
            }


            if (btnSaveChanges.Enabled)
            {
                DialogResult qResponse = MessageBox.Show($"Do you want to save the changes you made to \"{txbDeviceName.Text}\"?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if(qResponse == DialogResult.Cancel)
                {
                    skipNextIndexCheck = true;
                    grvDevices.SelectedItem = selectedIndex;
                    return;
                }

                if(qResponse == DialogResult.Yes)
                {
                    SaveChanges();
                }
            }

            txbDeviceName.Enabled = true;
            txbDeviceDescription.Enabled = true;
            btnChangeDeviceType.Enabled = true;
            btnSaveChanges.Enabled = false;
            btnDiscardChanges.Enabled = false;
            selectedIndex = grvDevices.SelectedItem;


            sql.connection.Open();

            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM Devices WHERE Name = '{grvDevices.GroupViewItems[grvDevices.SelectedItem].Text}'"))
            {
                while(reader.Read())
                {
                    txbDeviceName.Text = Convert.ToString(reader["Name"]);
                    btnChangeDeviceType.Text = SurgitManager.ReadableString(Convert.ToString(reader["DeviceType"])) + " (click to change)";
                    txbDeviceDescription.Text = Convert.ToString(reader["Description"]);
                    txbDeviceLastSeen.Text = Convert.ToDateTime(reader["LastSeen"]).ToLongDateString();

                    txbDeviceHostname.Text = Convert.ToString(reader["Hostname"]);
                    txbDeviceIPv4.Text = Convert.ToString(reader["IP4Address"]);
                    txbDeviceIPv6.Text = Convert.ToString(reader["IP6Address"]);
                    txbDeviceMac.Text = Convert.ToString(reader["MACAddress"]);

                    newDeviceType = Convert.ToString(reader["DeviceType"]);

                    txbDeviceManufacturer.Text = "";

                    try 
                    {
                        using (WebClient webClient = new WebClient())
                            txbDeviceManufacturer.Text = webClient.DownloadString("http://api.macvendors.com/" + WebUtility.UrlEncode(Convert.ToString(reader["MACAddress"])));
                    }
                    catch { }
                }
            }

            sql.connection.Close();
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

        private string newDeviceType = null;
        private void btnChangeDeviceType_Click(object sender, EventArgs e)
        {
            DeviceTypeSelector devSelect = new DeviceTypeSelector();

            if(devSelect.ShowDialog() == DialogResult.OK)
            {
                btnChangeDeviceType.Text = devSelect.SelectedDeviceType + " (click to change)";
                newDeviceType = devSelect.SelectedDeviceType.Replace(" ", "");

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
                sql.ExecuteNonQuery($"UPDATE Devices SET Name = '{txbDeviceName.Text}', Description = '{txbDeviceDescription.Text}', DeviceType = '{newDeviceType}' WHERE MACAddress = '{txbDeviceMac.Text}'");
            }
            else MessageBox.Show("The entered Device-Name already exitst. Please enter a unique name for each device!", "Name duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sql.connection.Close();
            UpdateDeviceList();
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = false;
            btnDiscardChanges.Enabled = false;
        }

        private void tmrStartPowerCheck_Tick(object sender, EventArgs e)
        {
            if (!bgwCheckPowerState.IsBusy) bgwCheckPowerState.RunWorkerAsync();
        }

        

        private void btnUpdateDevices_Click(object sender, EventArgs e)
        {
            UpdateEntries upd = new UpdateEntries
            {
                IPStartRange = txbIPRangeStart.Text,
                IPEndRange = txbIPRangeEnd.Text
            };

            if (upd.ShowDialog() == DialogResult.OK)
                UpdateDeviceList();
        }

        private void bgwCheckPowerState_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) => SurgitManager.PowerStateCheck(txbIPRangeStart.Text, txbIPRangeEnd.Text);
        private void btnSaveChanges_Click(object sender, EventArgs e) => SaveChanges();
        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e) => UpdateDeviceList();
        private void cbxSortOrder_SelectedIndexChanged(object sender, EventArgs e) => UpdateDeviceList();
        private void btnRefresh_Click(object sender, EventArgs e) => UpdateDeviceList();
        
    }
#pragma warning restore IDE1006
}
