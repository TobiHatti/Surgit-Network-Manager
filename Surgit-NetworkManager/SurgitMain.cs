using Syncfusion.Windows.Forms.Tools;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surgit_NetworkManager
{
    public partial class SurgitMain : RibbonForm
    {
        private CSQLite sql = null;

        public SurgitMain()
        {
            InitializeComponent();

            sql = new CSQLite($@"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\surgit.db")}");

            if (!sql.ConnectionTest()) throw new Exception("Could not connect to DB");

           
            grvDevices.LargeImageList = NetDevice.GetImageList();

            ApplyFormStyle();
            UpdateDeviceList();
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
            using(SQLiteDataReader reader = sql.ExecuteQuery("SELECT * FROM Devices"))
            {
                while(reader.Read())
                {
                    GroupViewItem gvi = new GroupViewItem(Convert.ToString(reader["Name"]),0);
                    gvi.ImageIndex = grvDevices.LargeImageList.Images.IndexOfKey(Convert.ToString(reader["DeviceType"]));
                    grvDevices.GroupViewItems.Add(gvi);
                }
            }
            sql.connection.Close();
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
                        foreach(NetDevice device in discover.DiscoveredDevices)
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
            if (sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM Devices WHERE Name = '{txbDeviceName.Text}' AND MACAddress != '{txbDeviceMac.Text}'") == 0)
            {
                btnSaveChanges.Enabled = false;
                btnDiscardChanges.Enabled = false;
                sql.ExecuteNonQuery($"UPDATE Devices SET Name = '{txbDeviceName.Text}', Description = '{txbDeviceDescription.Text}', DeviceType = '{newDeviceType}' WHERE MACAddress = '{txbDeviceMac.Text}'");
            }
            else MessageBox.Show("The entered Device-Name already exitst. Please enter a unique name for each device!", "Name duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            UpdateDeviceList();
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = false;
            btnDiscardChanges.Enabled = false;
        }
    }
}
