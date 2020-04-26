using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
    public partial class DiscoverLocal : SfForm
    {
        public string IPv4;
        public string IPv6;
        public string MAC;
        public string Hostname;

        public DiscoverLocal()
        {
            InitializeComponent();
            LoadInterfaces();
        }

        private void LoadInterfaces()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            ImageList ilt = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };
            ilt.Images.Add("NWC", Properties.Resources.networkCard);
            grvInterfaces.LargeImageList = ilt;
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                grvInterfaces.GroupViewItems.Add(new GroupViewItem($"{adapter.Name} - {adapter.Description}", 0));
            }
            Console.WriteLine();
        }

        private void grvInterfaces_GroupViewItemSelected(object sender, EventArgs e)
        {
            btnAddDevice.Enabled = true;

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                if($"{adapter.Name} - {adapter.Description}" == grvInterfaces.GroupViewItems[grvInterfaces.SelectedItem].Text)
                {
                    foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            txbIPv4.Text = ip.Address.ToString();

                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                            txbIPv6.Text = ip.Address.ToString();

                        PhysicalAddress address = adapter.GetPhysicalAddress();
                        StringBuilder sb = new StringBuilder();
                        byte[] bytes = address.GetAddressBytes();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            sb.Append(bytes[i].ToString("X2"));
                            if (i != bytes.Length - 1) sb.Append("-");
                        }

                        txbMAC.Text = sb.ToString();

                        txbHostname.Text = Dns.GetHostEntry("").HostName;
                    }

                    //IPInterfaceProperties properties = adapter.GetIPProperties();

                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            IPv4 = txbIPv4.Text;
            IPv6 = txbIPv6.Text;
            MAC = txbMAC.Text;
            Hostname = txbHostname.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
