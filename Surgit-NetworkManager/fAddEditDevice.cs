using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
    public partial class AddEditDevice : SfForm
    {
        public bool IsEditMode = false;
        public string DeviceName = "";
        public string DeviceDescription = "";
        public string DeviceTType = DeviceType.UnknownDevice.ToString();
        public string DeviceHostname = "";
        public string DeviceIPv4 = "";
        public string DeviceIPv6 = "";
        public string DeviceMac = "";
        public string OriginalDeviceMac = "";

        private CSQLite sql = new CSQLite(SurgitManager.SurgitDatabaseLocation);

        public AddEditDevice()
        {
            InitializeComponent();
        }

        private void AddEditDevice_Load(object sender, EventArgs e)
        {
            if (IsEditMode) this.Text = "Edit Device " + DeviceName;
            else this.Text = "Add New Device";

            if (IsEditMode)
            {
                txbDeviceName.Text = DeviceName;
                txbDeviceDescription.Text = DeviceDescription;
                btnSelectDeviceType.Text = SurgitManager.ReadableString(DeviceTType) + " (click to change)";
                txbDeviceHostname.Text = DeviceHostname;
                txbDeviceIPv4.Text = DeviceIPv4;
                txbDeviceIPv6.Text = DeviceIPv6;
                txbDeviceMac.Text = DeviceMac;

                OriginalDeviceMac = DeviceMac;

                btnAdd.Text = "Update Device";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbDeviceName.Text)) DeviceName = txbDeviceName.Text;
            else
            {
                MessageBox.Show("Please enter a Device-Name.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbDeviceName.Focus();
                return;
            }

            DeviceDescription = txbDeviceDescription.Text;
            DeviceHostname = txbDeviceHostname.Text;

            if (string.IsNullOrEmpty(txbDeviceIPv4.Text) || (IPAddress.TryParse(txbDeviceIPv4.Text, out IPAddress ipv4Check) && ipv4Check.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)) DeviceIPv4 = txbDeviceIPv4.Text;
            else
            {
                MessageBox.Show("The entered IPv4-Address is not valid. Please enter a valid IPv4-Address.\r\n\r\nFormat: XXX.XXX.XXX.XXX", "Faulty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbDeviceIPv4.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txbDeviceIPv6.Text) || (IPAddress.TryParse(txbDeviceIPv6.Text, out IPAddress ipv6Check) && ipv6Check.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)) DeviceIPv6 = txbDeviceIPv6.Text;
            else
            {
                MessageBox.Show("The entered IPv6-Address is not valid. Please enter a valid IPv6-Address.", "Faulty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbDeviceIPv6.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txbDeviceMac.Text))
            {
                if (Regex.IsMatch(txbDeviceMac.Text, "^[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}") && txbDeviceMac.Text.Length == 17)
                {
                    if(sql.ExecuteScalarA<int>($"SELECT COUNT(*) FROM Devices WHERE MACAddress = '{txbDeviceMac.Text}' AND MACAddress != '{OriginalDeviceMac}'") == 0) DeviceMac = txbDeviceMac.Text;
                    else
                    {
                        MessageBox.Show("The entered MAC-Address already exists. Please enter a new MAC-Address.\r\n\r\nFormat: XX-XX-XX-XX-XX-XX", "Duplicate MAC-Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbDeviceMac.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The entered MAC-Address is not valid. Please enter a valid MAC-Address.\r\n\r\nFormat: XX-XX-XX-XX-XX-XX", "Faulty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbDeviceMac.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter a MAC-Address.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbDeviceMac.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelectDeviceType_Click(object sender, EventArgs e)
        {
            DeviceTypeSelector devSelect = new DeviceTypeSelector();

            if (devSelect.ShowDialog() == DialogResult.OK)
            {
                btnSelectDeviceType.Text = devSelect.SelectedDeviceType + " (click to change)";
                DeviceTType = devSelect.SelectedDeviceType.Replace(" ", "");
            }
        }
    }
}
