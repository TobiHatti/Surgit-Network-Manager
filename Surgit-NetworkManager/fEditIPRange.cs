using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class EditIPRange : SfForm
    {
        public string IPStartRange = "";
        public string IPEndRange = "";

        public EditIPRange()
        {
            InitializeComponent();
        }

        private void EditIPRange_Load(object sender, EventArgs e)
        {
            txbIPRangeStart.Text = IPStartRange;
            txbIPRangeEnd.Text = IPEndRange;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool ipStartValid;
            // Check if start-IP is valid
            if (IPAddress.TryParse(txbIPRangeStart.Text, out IPAddress ipStartRange) && ipStartRange.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) ipStartValid = true;
            else
            {
                MessageBox.Show("The given range-start is not a valid IPv4-Address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ipEndValid;
            // Check if end-IP is valid
            if (IPAddress.TryParse(txbIPRangeEnd.Text, out IPAddress ipEndRange) && ipEndRange.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) ipEndValid = true;
            else
            {
                MessageBox.Show("The given range-end is not a valid IPv4-Address", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the start and end IPs are in the same subnet and that they are in a class C subnet
            if (ipStartValid && ipEndValid && SurgitManager.CheckIPClassCValidity(txbIPRangeStart.Text, txbIPRangeEnd.Text))
            {
                IPStartRange = txbIPRangeStart.Text;
                IPEndRange = txbIPRangeEnd.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("The given range is not valid. Make sure the IPs are in the same subnet. Note: Only C-Class IP-Adresses are currently supported", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
#pragma warning restore IDE1006
}
