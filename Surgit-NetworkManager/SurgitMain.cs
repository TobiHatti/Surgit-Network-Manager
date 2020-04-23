using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

            ApplyFormStyle();
        }

        private void ApplyFormStyle()
        {
            this.Appearance = AppearanceType.Office2007;
            this.ColorScheme = ColorSchemeType.Blue;
            this.EnableAeroTheme = true;
            this.Borders = new Padding(-1);

            this.rbcRibbonMenu.TitleFont = new Font("Calibri", 11);
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
                                sql.ExecuteNonQuery("UPDATE Devices SET IP4Address = ?, Hostname = ?, LastConnected = ? WHERE MACAddress = ?", device.IPv4, device.Hostname, DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), device.MAC);
                            }
                            else
                            {
                                sql.ExecuteNonQuery($"INSERT INTO Devices (MACAddress, DeviceType, Name, Hostname, IP4Address, LastConnected) VALUES ('{device.MAC}','{device.DeviceType}','{device.Name}','{device.Hostname}','{device.IPv4}','{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}')");
                            }
                        }
                    }
                }
            }
        }
    }
}
