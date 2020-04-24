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
    public partial class SurgitMain : RibbonForm
    {
        private CSQLite sql = null;
        private CSQLite sqlBGW = null;

        Dictionary<string, bool> DevicePowerState = new Dictionary<string, bool>();

        public SurgitMain()
        {
            InitializeComponent();

            sql = new CSQLite($@"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\surgit.db")}");
            sqlBGW = new CSQLite($@"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\surgit.db")}");

            if (!sql.ConnectionTest()) throw new Exception("Could not connect to DB [SQL]");
            if (!sqlBGW.ConnectionTest()) throw new Exception("Could not connect to DB [SQLBGW]");

            
           
            grvDevices.LargeImageList = NetDevice.GetImageList();

            ApplyFormStyle();
            UpdateDeviceList();

            cbxSortBy.SelectedIndex = 4;
            cbxSortOrder.SelectedIndex = 0;

            if (!bgwCheckPowerState.IsBusy)
                bgwCheckPowerState.RunWorkerAsync();
        }

        private void ApplyFormStyle()
        {
            this.Appearance = AppearanceType.Office2007;
            this.ColorScheme = ColorSchemeType.Blue;
            this.EnableAeroTheme = true;
            this.Borders = new Padding(-1);

            this.rbcRibbonMenu.TitleFont = new Font("Calibri", 11);
        }

        private void UpdateDeviceList()
        {
            grvDevices.GroupViewItems.Clear();
            sql.connection.Open();

            string orderBy = "";
            string orderDirection = "";
            string orderDirectionRev = "";

            switch (cbxSortOrder.SelectedIndex)
            {
                case 0: orderDirection = "ASC"; orderDirectionRev = "DESC"; break;
                case 1: orderDirection = "DESC"; orderDirectionRev = "ASC"; break;
                default: orderDirection = ""; break;
            }
            
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

      
            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM Devices {orderBy}"))
            {
                while(reader.Read())
                {
                    entryCtr++;

                    GroupViewItem gvi = new GroupViewItem(Convert.ToString(reader["Name"]),0);

                    if(Convert.ToBoolean(reader["LastPowerState"])) gvi.ImageIndex = grvDevices.LargeImageList.Images.IndexOfKey(Convert.ToString(reader["DeviceType"]) + "_ON");
                    else gvi.ImageIndex = grvDevices.LargeImageList.Images.IndexOfKey(Convert.ToString(reader["DeviceType"]) + "_OFF");

                    grvDevices.GroupViewItems.Add(gvi);
                }
            }
            sql.connection.Close();

            lblDeviceCount.Text = $"{entryCtr} Devices Registered";
        }

        private string ReadableString(string pInput)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pInput.Length; i++)
            {
                if (pInput[i] == '_' || (char.IsLetter(pInput[i]) && ((i != 0 && (char.IsLower(pInput[i - 1]) && char.IsUpper(pInput[i]))) || (i != pInput.Length - 1 && (char.IsUpper(pInput[i]) && char.IsLower(pInput[i + 1])))))) sb.Append(" ");
                if (pInput[i] != '_') sb.Append(pInput[i]);
            }

            return sb.ToString();
        }

        private void BtnDiscover_Click(object sender, EventArgs e)
        {
            DiscoverDialog discover = new DiscoverDialog();
            
            if(discover.ShowDialog() == DialogResult.OK)
            {
                if(discover.DiscoveredDevices.Count > 0)
                {
                    if(MessageBox.Show("Do you want to update your device-list with the new entries? (If a device already exists, only the IP-Address and Hostname get updated.)", "Import new devices", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sql.connection.Open();
                        foreach (NetDevice device in discover.DiscoveredDevices)
                        {
                            if(sql.ExecuteScalar<int>("SELECT COUNT(*) FROM Devices WHERE MACAddress = ?", device.MAC) > 0)
                            {
                                sql.ExecuteNonQuery($"UPDATE Devices SET IP4Address = '{device.IPv4}', Hostname = '{device.Hostname}', LastSeen = '{DateTime.Now:yyyy-MM-dd H:mm:ss}' WHERE MACAddress = '{device.MAC}'");
                            }
                            else
                            {
                                sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, DeviceType, Name, Hostname, IP4Address, LastSeen) VALUES ('{device.MAC}','{device.DeviceType}','{device.Name}','{device.Hostname}','{device.IPv4}','{DateTime.Now:yyyy-MM-dd H:mm:ss}')");
                            }
                        }
                        sql.connection.Close();
                    }
                }
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
                    btnChangeDeviceType.Text = ReadableString(Convert.ToString(reader["DeviceType"])) + " (click to change)";
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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChanges();
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
            Debug.Print("Attempting...");
            if (!bgwCheckPowerState.IsBusy)
                bgwCheckPowerState.RunWorkerAsync();
        }

        private void SurgitMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrStartPowerCheck.Stop();

            

            if (bgwCheckPowerState.WorkerSupportsCancellation)
                bgwCheckPowerState.CancelAsync();
        }

        private void bgwCheckPowerState_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PowerStateCheck();
        }

        private void PowerStateCheck()
        {
            Debug.Print("Starting...");
            // Get all devices, set powerstate to false
            DevicePowerState.Clear();
            sqlBGW.connection.Open();
            using (SQLiteDataReader reader = sqlBGW.ExecuteQuery("SELECT * FROM Devices"))
            while(reader.Read()) DevicePowerState.Add(Convert.ToString(reader["MACAddress"]), false);
            sqlBGW.connection.Close();

            // Ping all devices in Network Range
            string[] ipStartParts = txbIPRangeStart.Text.Split('.');
            string[] ipEndParts = txbIPRangeEnd.Text.Split('.');

            Ping ping = new Ping();
            PingReply reply = null;
            StringBuilder sqlSB = new StringBuilder();

            if (ipStartParts[0] == ipEndParts[0] && ipStartParts[1] == ipEndParts[1] && ipStartParts[2] == ipEndParts[2])
            {
                for (int i = Convert.ToInt32(ipStartParts[3]); i <= Convert.ToInt32(ipEndParts[3]); i++)
                {
                    string currentIP = ipStartParts[0] + "." + ipStartParts[1] + "." + ipStartParts[2] + "." + i.ToString();
                    reply = ping.Send(currentIP, 100);
                    Debug.Print("Pinged " + currentIP);
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
                                sqlSB.Append($"INSERT INTO Devices (MACAddress, DeviceType, Name, IP4Address, LastSeen) VALUES ('{currentMAC}','{DeviceType.UnknownDevice.ToString()}','Device-{currentMAC}','{currentIP}','{DateTime.Now:yyyy-MM-dd H:mm:ss}')");
                            }
                        }
                    }
                    else continue;
                }

                // Update IP and LastSeen, add new entries
                sqlBGW.connection.Open();
                sqlBGW.ExecuteNonQuery(sqlSB.ToString());
                sqlBGW.connection.Close();

                // Update last power-state
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, bool> entry in DevicePowerState)
                {
                    int state = 0;
                    if (entry.Value) state = 1;
                    sb.Append($"UPDATE Devices SET LastPowerState = '{state}' WHERE MACAddress = '{entry.Key}';");
                }
                sqlBGW.connection.Open();
                sqlBGW.ExecuteNonQuery(sb.ToString());
                sqlBGW.connection.Close();
            }
            else
            {
                MessageBox.Show("The given range is not valid. Make sure the IPs are in the same subnet. Note: Only C-Class IP-Adresses are currently supported", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void cbxSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }
    }
}
