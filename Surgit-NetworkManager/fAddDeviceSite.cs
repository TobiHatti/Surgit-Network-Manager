using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class AddDeviceSite : SfForm
    {
        public string DeviceName { get; set; } = "";
        public string DeviceSiteURL { get; set; } = "";
        public AddDeviceSite()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            DeviceSiteURL = txbDeviceURL.Text;
            DeviceName = txbSiteName.Text;

            if (!string.IsNullOrEmpty(DeviceName))
            {
                if (Uri.TryCreate(DeviceSiteURL, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Please enter a valid HTTP/HTTPS URL", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Please enter a Name for the site", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
#pragma warning restore IDE1006
}
