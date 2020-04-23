using Syncfusion.Windows.Forms.Tools;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
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

            //ltvDevices.LargeImageList = NetDevice.GetImageList();
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

        private void grvDevices_GroupViewItemSelected(object sender, EventArgs e)
        {
            sql.connection.Open();

            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM Devices WHERE Name = '{grvDevices.GroupViewItems[grvDevices.SelectedItem].Text}'"))
            {
                while(reader.Read())
                {
                    txbDeviceName.Text = Convert.ToString(reader["Name"]);
                    btnChangeDeviceType.Text = Convert.ToString(reader["DeviceType"]) + " (click to change)";
                    txbDeviceDescription.Text = Convert.ToString(reader["Description"]);
                    txbDeviceLastSeen.Text = Convert.ToDateTime(reader["LastSeen"]).ToLongDateString();

                    txbDeviceHostname.Text = Convert.ToString(reader["Hostname"]);
                    txbDeviceIPv4.Text = Convert.ToString(reader["IP4Address"]);
                    txbDeviceIPv6.Text = Convert.ToString(reader["IP6Address"]);
                    txbDeviceMac.Text = Convert.ToString(reader["MACAddress"]);

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

    }
}
